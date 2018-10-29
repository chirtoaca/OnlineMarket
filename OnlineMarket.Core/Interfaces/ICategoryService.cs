using OnlineMarket.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Core.Services
{
    public interface ICategoryService
    {
        List<Category> GetCategories();

        void AddCategory (Category category);
        void DeleteCategory(Category category);
        void UpdateCategory(Category category);
    }
}
