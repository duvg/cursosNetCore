using System;
using System.Linq;
using cursosNetCore.Models;
namespace cursosNetCore.Data
{
    public class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            // Create database
            context.Database.EnsureCreated();

            // Search records if exist in category table
            if (context.Category.Any())
            {
                return;
            }

            var categories = new Category[]
            {
                new Category{ Name="Diseño Grafico", Description="Cursos de diseño grafico", Status=true},
                new Category{ Name="Diseño Web", Description="Cursos de diseño web", Status=true }
            };

            foreach (Category c in categories)
            {
                context.Category.Add(c);
            }
            context.SaveChanges();
        }

        public DbInitializer()
        {
        }
    }
}
