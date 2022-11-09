﻿using BookstoreWebApp.Models;
using BookstoreWebApp.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace BookstoreWebApp.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _unitOfWork.Product.GetAll(includeProps: "Category,CoverType");
            return View(products);
        }

        public IActionResult Details(int productId)
        {
            ShoppingCart cart = new()
            {
                ProductId = productId,
                Product = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == productId, "Category,CoverType"),
                Count = 1
            };

            return View(cart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            var claimsId = (ClaimsIdentity) User.Identity;
            var claim = claimsId.FindFirst(ClaimTypes.NameIdentifier);
            shoppingCart.ApplicationUserId = claim.Value;

            var cart = _unitOfWork.ShoppingCart
                .GetFirstOrDefault(u => u.ApplicationUserId == claim.Value && 
                u.ProductId == shoppingCart.ProductId);

            if(cart == null)
            {
                _unitOfWork.ShoppingCart.Add(shoppingCart);
            }
            else
            {
                _unitOfWork.ShoppingCart.IncrementCount(cart, shoppingCart.Count);
            }

            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}