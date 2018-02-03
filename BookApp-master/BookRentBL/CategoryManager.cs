using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookEntity;
using BookRentRepository;

namespace BookRentBL
{
    public class CategoryManager
    {
        public void CreateCategory(Category category)
        {
            using (var repository = new CommonRepository<Category>())
            {
                repository.Create(category);
            }
        }
        public IEnumerable<Category> GetAllCategories()
        {
            using (var repository = new CommonRepository<Category>())
            {
                return repository.GetAll().ToList();
            }
        }
    }
}
