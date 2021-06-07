using Application.Core.Entities.Concrete;
using Application.DataAccess.Abstract;
using Application.DataAccess.Concrete.EntityFramework.Context;
using Application.DataAccess.Concrete.EntityFramework.Repository;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Application.Core.Configuration.Context;

namespace Application.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfRepositoryBase<User, int>, IUserDal
    {
        private readonly IApplicationConfigurationContext _appConfigurationContext;

        public EfUserDal(IApplicationConfigurationContext appConfigurationContext) : base(appConfigurationContext.ConnectionString)
        {
            _appConfigurationContext = appConfigurationContext;
        }

        public List<OperationClaim> GetClaimsByUserId(int id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext(_appConfigurationContext.ConnectionString))
            {
                return context
                    .UserOperationClaims
                        .Where(userOperationClaim => userOperationClaim.UserId == id)
                    .Select(userOperationClaim => userOperationClaim.OperationClaim)
                    .ToList();
            }
        }

        public User GetUser(string email, string password)
        {
            using (var context = new ApplicationDbContext(_appConfigurationContext.ConnectionString))
            {
                return context.Users.FirstOrDefault(user => user.Email == email && user.Password == password);
            }
        }
    }
}
