using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookEntity;
using BookRentRepository;

namespace BookRentBL
{
   public class AuthorManager
    {

        public void CreateAuthor(Authors author)
        {
            using (var repository = new CommonRepository<Authors>())
            {
                repository.Create(author);
            }
        }
         public IEnumerable<Authors> GetAllAuthors()
        {
            using (var repository = new CommonRepository<Authors>())
            {
                return repository.GetAll().ToList();
            }
        }
    }
    }

