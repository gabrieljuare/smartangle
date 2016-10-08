using Microsoft.AspNet.Identity;
using SmartAngle.Data.Entities;
using SmartAngle.Web.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace SmartAngle.Web.API.Controllers
{
    [Authorize]
    public class RegisterController : ApiController
    {
        private IUserService userService;
        private IDeviceService deviceService;
        private IRegisterService registerService;

        public RegisterController()
        {
            userService = new UserService();
            deviceService = new DeviceService();
            registerService = new RegisterService();
        }

        public RegisterController(IUserService _userService,
                                    IDeviceService _deviceService,
                                    IRegisterService _registerService)
        {
            registerService = _registerService;
        }

        // GET api/registro
        [HttpGet]
        [Route("api/registro/{idDispositivo}")]
        public HttpResponseMessage GetRegistersFromDevice(Guid deviceId, string variableName)
        {

            User user = GetUserFromTicket();
            try
            {
                //TODO: Validate correct user and device
                List<Register> registersOfDevice = registerService.GetRegisters(deviceId, variableName);
                return Request.CreateResponse(HttpStatusCode.OK, registersOfDevice);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }



        // GET api/registro/
        [HttpGet]
        [Route("api/registro")]
        public HttpResponseMessage GetRegister(Guid deviceId, Guid registerId)
        {
            User authenticatedUser = GetUserFromTicket();
            try
            {
                //TODO: Check user has device
                Register register = registerService.GetRegister(deviceId, registerId);
                return Request.CreateResponse(HttpStatusCode.OK, register);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // POST api/registro
        [HttpPost]
        [Route("api/registro")]
        public HttpResponseMessage Post(Guid deviceId, [FromBody]Register register)
        {
            User user = GetUserFromTicket();
            try
            {
                //TODO: check user has device
                register.DateOfMeasure = DateTime.Now;
                Guid newRegisterId = registerService.AddRegister(deviceId, register);
                Register addedRegister = registerService.GetRegister(deviceId, newRegisterId);
                return Request.CreateResponse(HttpStatusCode.Accepted, addedRegister);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        //TODO: change uri
        [HttpGet]
        [Route("api/registro")]
        public HttpResponseMessage DownloadReport(Guid deviceId, string variableName, DateTime initialDate, DateTime finalDate, string reportFormat)
        {
            User user = GetUserFromTicket();
            try
            {
                //TODO: Check that user has device
                var regs = registerService.GetRegisters(deviceId, variableName);
                var filtered = regs.Where(r => (r.DateOfMeasure >= initialDate) && (r.DateOfMeasure <= finalDate)).ToList();
                HttpResponseMessage report = GenerateReport(filtered, reportFormat);
                return report;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        private HttpResponseMessage GenerateReport(List<Register> selected, string formato)
        {
            switch (formato)
            {
                case "PDF":
                    return GenerarPdf(selected);
                default:
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        HttpResponseMessage GenerarPdf(List<Register> registers)
        {
            var archivo = BuildPdf(registers);

            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(archivo.GetBuffer())
            };
            result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
            {
                FileName = "ReporteSmartAngle.pdf"
            };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            return result;
        }

        private MemoryStream BuildPdf(List<Register> registers)
        {
            //TODO: Install PDF generator nuget package
            /*
            var document = new Document(PageSize.A4, 50, 50, 25, 25);
*/
            MemoryStream stream = new MemoryStream();
            /*
            var writer = PdfWriter.GetInstance(document, stream);
            document.Open();

            AddDataToPdf(document, registros);

            document.Close();
    */
            stream.Close();
            return stream;
        }

        /*
        private void AddDataToPdf(Document document, List<Register> registros)
        {
            var titulo = new Paragraph("Reporte de registros");

            var tabla = new PdfPTable(2);
            tabla.HorizontalAlignment = 0;
            tabla.SpacingBefore = 10;
            tabla.SpacingAfter = 10;
            var negrita = FontFactory.GetFont("Arial", 12, Font.BOLD);

            tabla.AddCell(new Phrase("Valor", negrita));
            tabla.AddCell(new Phrase("Fecha", negrita));

            foreach (var reg in registros)
            {
                tabla.AddCell(reg.Valor.ToString());
                tabla.AddCell(reg.FechaTomada.ToShortDateString());
                tabla.AddCell(reg.FechaTomada.ToLongTimeString());
            }

            document.Add(titulo);
            document.Add(tabla);
        }
        */

        private User GetUserFromTicket()
        {
            Guid idFromToken = new Guid(RequestContext.Principal.Identity.GetUserId());
            return userService.GetUserById(idFromToken);
        }

    }
}
