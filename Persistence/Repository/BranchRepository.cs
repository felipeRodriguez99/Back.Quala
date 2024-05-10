using Application.Interfaces;
using Domain.Enitities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class BranchRepository : RepositoryAsync<Branch>, IBranchRepository
    {
        public BranchRepository(PersistenceContext context) : base(context)
        {
        }
    }
}
