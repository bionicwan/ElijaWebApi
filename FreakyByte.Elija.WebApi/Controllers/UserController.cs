using System.Net;
using System.Net.Http;
using System.Web.Http;
using FreakyByte.Elija.Entities.DataContracts;
using FreakyByte.Elija.Processing.Services;

namespace FreakyByte.Elija.WebApi.Controllers
{
    public class UserController : ApiController
    {
        public HttpResponseMessage Post([FromBody] UserDeviceModel userDevice)
        {
            var service = new ElijaServiceManager();
            var response = new HttpResponseMessage();
            Result<string> result = service.RegisterUser(userDevice);
            response.StatusCode = HttpStatusCode.Created;

            return response;
        }
    }
}