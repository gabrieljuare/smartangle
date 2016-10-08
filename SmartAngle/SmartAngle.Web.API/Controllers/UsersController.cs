using SmartAngle.Data.Entities;
using SmartAngle.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartAngle.Web.API.Controllers
{
    public class UsersController : ApiController
    {
        IUserService service;
        public UsersController(IUserService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("api/usuario")]
        public HttpResponseMessage PutUser([FromBody]User userToUpdate)
        {
            Guid userId = GetUserFromTicket();
            try
            {
                userToUpdate.Id = userId;
                service.UpdateUser(userToUpdate);
                User updatedUser = service.GetUserById(userId);
                return Request.CreateResponse(HttpStatusCode.Created, updatedUser);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotModified, ex.Message);
            }
        }

        private Guid GetUserFromTicket()
        {
            throw new NotImplementedException();
        }
    }
}
