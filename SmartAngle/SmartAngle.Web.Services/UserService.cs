using SmartAngle.Data.Entities;
using SmartAngle.Data.Repository;
using System;

namespace SmartAngle.Web.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork unitOfWork;
        public Guid CreateUser(User user)
        {
            ValidateUser(user);
            if (UserDoesNotExists(user))
            {
                User createdUser = this.BuildUser(user);
                this.unitOfWork.UserRepository.Insert(createdUser);
                this.unitOfWork.Save();
                return createdUser.Id;
            }
            else
            {
                throw new Exception("Invalid user");
            }
        }

        private void ValidateUser(User user)
        {
            ValidateEmail(user.Email);
        }

        private void ValidateEmail(string email)
        {
            throw new NotImplementedException();
        }

        private bool UserDoesNotExists(User user)
        {
            bool exists= false;

            return exists;
        }

        private User BuildUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(Guid id)
        {
            throw new NotImplementedException();
        }

        public User UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

}
