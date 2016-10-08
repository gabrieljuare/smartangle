using SmartAngle.Data.Entities;
using SmartAngle.Web.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartAngle.Web.API.Controllers
{
    [Authorize]
    public class DeviceTypeController : ApiController
    {
        private IDeviceTypeService deviceTypeService;
        public HttpResponseMessage Get()
        {
            List<DeviceType> deviceTypes = new List<DeviceType>();
            try
            {
                deviceTypes = deviceTypeService.GetDeviceTypes();
                return Request.CreateResponse(HttpStatusCode.OK, deviceTypes);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        // GET api/tipodispositivo/5
        [HttpGet]
        [Route("api/tipodispositivo")]
        public HttpResponseMessage GetDeviceType(Guid id)
        {
            try
            {
                DeviceType deviceType = deviceTypeService.GetDeviceType(id);
                return Request.CreateResponse(HttpStatusCode.OK, deviceType);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        private User GetUserFromTicket()
        {
            throw new NotImplementedException();
        }
    }
}
