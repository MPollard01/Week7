using SpartaTodo.Models;
using SpartaTodo.Models.ViewModels;

namespace SpartaTodo.Controllers
{
    public static class Utils
    {
        public static TodoViewModel TodoToViewModel(Todo todo) =>
            new TodoViewModel
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                Complete = todo.Complete
            };
    }
}
