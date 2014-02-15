namespace FreakyByte.Elija.Entities.DataContracts
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Data Contract used to carry any information from the server to the client in response to a service request.
    /// </summary>

    [DataContract]
    public class Result : IResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }



    public interface IResult
    {
        bool Success { get; set; }
        string Message { get; set; }
    }


    [DataContract]
    public class Result<T> : Result
    {
        public T Data { get; set; }
    }

}