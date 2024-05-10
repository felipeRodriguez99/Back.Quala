using Application.Interfaces;
using Domain.Enitities;
using Persistence.Contexts;

namespace Persistence.Repository
{
    public class CurrencyRepository : RepositoryAsync<Currency>, ICurrencyRepository
    {                
        public CurrencyRepository(PersistenceContext context) : base(context)
        {
        }
    }
}
