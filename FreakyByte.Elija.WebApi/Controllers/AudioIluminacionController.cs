using System.Web.Http;
using FreakyByte.Elija.Entities.DataContracts;
using FreakyByte.Elija.Processing.Services;

namespace FreakyByte.Elija.WebApi.Controllers
{
    public class AudioIluminacionController : ApiController
    {
        public Result<SectionModel> Get(int id, int page=0, int screenDensity = 5, bool isWifi = true)
        {
            var result = ElijaServiceManager.GetSectionArticles(id, page, screenDensity, isWifi);
            return result;
        }
    }
}