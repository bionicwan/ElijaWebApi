using System.Web.Http;
using FreakyByte.Elija.Entities.DataContracts;
using FreakyByte.Elija.Processing.Services;

namespace FreakyByte.Elija.WebApi.Controllers
{
    public class AudioIluminacionController : ApiController
    {
        public Result<SectionModel> Get(int id, int screenDensity = 5, bool isWifi = true)
        {
            Result<SectionModel> result = ElijaServiceManager.GetSectionArticles(id, screenDensity, isWifi);
            return result;
        }
    }
}