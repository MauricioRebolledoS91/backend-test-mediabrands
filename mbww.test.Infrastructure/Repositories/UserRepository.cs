using mbww.test.Domain.Entities;
using mbww.test.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbww.test.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(MbwwTestDbContext dbContext) : base(dbContext)
        {

        }

        
    }
}
