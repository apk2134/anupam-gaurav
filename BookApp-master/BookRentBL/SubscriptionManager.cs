using BookEntity;
using BookRentRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentBL
{
   public class SubscriptionManager
    {
        public IEnumerable<Subscriptions> GetAllSubscription()
        {
            using (var repository = new CommonRepository<Subscriptions>())
            {
                return repository.GetAll().ToList();
            }
        }
    }
}
