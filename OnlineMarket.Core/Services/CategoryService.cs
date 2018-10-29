using OnlineMarket.DataModels.Models;
using OnlineMarket.DataModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Core.Services
{
    public class CategoryService :ICategoryService
    {
        private IRepository _repository;

        public CategoryService(IRepository repository)
        {
            _repository = repository;
        }

        public void AddCategory(Category category)
        {
            _repository.Add(category);
        }

        public void DeleteCategory(Category category)
        {
            _repository.Delete(category);
        }

        public List<Category> GetCategories()
        {
            var result = _repository.GetAll<Category>().ToList();
            return result;
        }

        public void UpdateCategory(Category category)
        {
            _repository.Update(category);
        }
    }
}
