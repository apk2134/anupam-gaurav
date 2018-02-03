using BookEntity;
using BookRentRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentBL
{
    public class Manager
    {
        public void Createitems(Authors author,Books book,Category cateory)
        {
            using (var repository = new CommonRepository<Books>())
            {
                repository.Create(book);
            }
            using (var repository = new CommonRepository<Authors>())
            {
                repository.Create(author);
            }
            using (var repository = new CommonRepository<Category>())
            {
                repository.Create(cateory);
            }

        }
    }
}
