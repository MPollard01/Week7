﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookstoreWebApp.Models
{
	public class OrderDetail
	{
		public int Id { get; set; }
		[Required]
		public int OrderId { get; set; }
		[ForeignKey("OrderId")]
		[ValidateNever]
		public OrderHeader OrderHeader { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        [ValidateNever]
        public Product Product { get; set; }
		public int Count { get; set; }
		public double Price { get; set; }
	}
}
