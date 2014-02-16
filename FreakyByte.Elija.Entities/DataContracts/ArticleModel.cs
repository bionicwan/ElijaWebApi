namespace FreakyByte.Elija.Entities.DataContracts
{
    public class ArticleModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Descrition { get; set; }
        public ArticleImageModel Images { get; set; }
    }
}