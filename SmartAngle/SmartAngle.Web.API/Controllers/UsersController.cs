using Microsoft.AspNet.Identity;
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
    [Authorize]
    public class UsersController : ApiController
    {
        IUserService userService;
        public UsersController()
        {
            userService = new UserService();
        }
        public UsersController(IUserService service)
        {
            this.userService = service;
        }

        [HttpPost]
        [Route("api/usuario")]
        public HttpResponseMessage PutUser([FromBody]User userToUpdate)
        {
            Guid userId = GetUserIdFromToken();
            try
            {
                userToUpdate.Id = userId;
                userService.UpdateUser(userToUpdate);
                User updatedUser = userService.GetUserById(userId);
                return Request.CreateResponse(HttpStatusCode.Created, updatedUser);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotModified, ex.Message);
            }
        }

        private Guid GetUserIdFromToken()
        {
            return new Guid(RequestContext.Principal.Identity.GetUserId());
        }
    }
}
