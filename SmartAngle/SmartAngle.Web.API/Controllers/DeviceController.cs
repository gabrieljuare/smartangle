using Microsoft.AspNet.Identity;
using SmartAngle.Data.Entities;
using SmartAngle.Web.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SmartAngle.Web.API.Controllers
{
    [Authorize]
    public class DeviceController : ApiController
    {

        private IUserService userService;
        private IDeviceService deviceService;

        public DeviceController()
        {
            userService = new UserService();
            deviceService = new DeviceService();
        }

        public DeviceController(IUserService _userService, IDeviceService _deviceService)
        {
            userService = _userService;
            deviceService = _deviceService;
        }

        // GET api/dispositivo
        [HttpGet]
        [Route("")]
        public HttpResponseMessage GetDevices()
        {
            try
            {
                User user = GetUserFromTicket();
                List<Device> devices = deviceService.GetAllDevices(user.Id);
                return Request.CreateResponse(HttpStatusCode.OK, devices);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        // GET api/dispositivo/5
        [HttpGet]
        [Route("api/dispositivo/{id}")]
        public HttpResponseMessage GetDispositivo(Guid id)
        {
            User user = GetUserFromTicket();
            try
            {
                Device device = deviceService.GetDevice(user.Id);
                return Request.CreateResponse(HttpStatusCode.OK, device);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }

        // POST api/dispositivo
        [HttpPost]
        [Route("")]
        public HttpResponseMessage PostDevice([FromBody]Device deviceToAdd)
        {
            User user = GetUserFromTicket();
            try
            {
                SaveImageOfDevice(deviceToAdd);
                Guid createdDeviceId = deviceService.AddDevice(user.Id, deviceToAdd);
                Device createdDevice = deviceService.GetDevice(createdDeviceId);
                return Request.CreateResponse(HttpStatusCode.OK, createdDevice);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }

        private void SaveImageOfDevice(Device device)
        {
            try
            {
                var request = HttpContext.Current.Request;
                if (request.Files.Count > 0)
                {
                    HttpPostedFile imagen = request.Files["imagen"];
                    var extension = System.IO.Path.GetExtension(imagen.FileName);
                    string nombreImagen = device.Id + extension;
                    var filePath = HttpContext.Current.Server.MapPath(string.Format("~/TempImages/{0}", nombreImagen));
                    imagen.SaveAs(filePath);
                    device.ImageUrl = filePath;
                }
            }
            catch (Exception)
            {
                //TODO: Set default image
                device.ImageUrl = "";
            }
        }

        // PUT api/dispositivo/5
        [HttpPut]
        [Route("api/dispositivo/{id}")]
        public HttpResponseMessage PutDevice(Guid deviceId, [FromBody]Device deviceToUpdate)
        {
            GetUserFromTicket();
            try
            {
                deviceService.UpdateDevice(deviceId, deviceToUpdate);
                Device updatedDevice = deviceService.GetDevice(deviceId);
                return Request.CreateResponse(HttpStatusCode.Accepted, updatedDevice);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotModified, ex.Message);
            }
        }

        // DELETE api/dispositivo/5
        [HttpDelete]
        [Route("{id}")]
        public HttpResponseMessage Delete(Guid deviceId)
        {
            User user = GetUserFromTicket();
            try
            {
                //TODO: Verify that user has device
                deviceService.DeleteDevice(deviceId);
                return Request.CreateResponse(HttpStatusCode.Accepted);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotModified, ex.Message);
            }
        }

        private User GetUserFromTicket()
        {
            Guid idFromToken = new Guid(RequestContext.Principal.Identity.GetUserId());
            return userService.GetUserById(idFromToken);
        }

    }
}
