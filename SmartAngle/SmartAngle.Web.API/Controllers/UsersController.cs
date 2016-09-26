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
        public HttpResponseMessage CrearUsuario([FromBody]User user)
        {
            try
            {
                var newId = service.CreateUser(user);
                return Request.CreateResponse(HttpStatusCode.Created, newId);
            }
            catch (Exception exU)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error en el servidor. Estamos trabajando para solucionar inconvenientes.");
            }
        }

    }
}
