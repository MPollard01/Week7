using Microsoft.EntityFrameworkCore;
using SpartaTodo.Models;

namespace SpartaTodo.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var db = new SpataTodoContext(serviceProvider.GetRequiredService<DbContextOptions<SpataTodoContext>>()))
            {
                if (db.Todos.Any()) return;

                db.Todos.AddRange
                    (
                        new Todo
                        {
                            Title = "Teach C#",
                            Description = "Teach Eng128/151 has to use ASP.NET MVC",
                            Complete = true,
                            Date = new DateTime(2022, 10, 28)
                        },
                          new Todo
                          {
                              Title = "Sleep",
                              Description = "Go to bed early",
                              Complete = true,
                          }

                    );
                db.SaveChanges();
            }
        }
    }
}
