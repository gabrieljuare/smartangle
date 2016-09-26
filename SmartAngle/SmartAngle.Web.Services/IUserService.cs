using SmartAngle.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAngle.Web.Services
{
    public interface IUserService : IDisposable
    {
        Guid CreateUser(User user);
        User GetUserById(Guid id);
        User UpdateUser(User user);
    }
}
