using System.Collections.Generic;

namespace FreakyByte.Elija.Entities.DataContracts
{
    public class SectionModel
    {
        public string Section { get; set; }
        public IEnumerable<ArticleModel> Article { get; set; }
    }
}