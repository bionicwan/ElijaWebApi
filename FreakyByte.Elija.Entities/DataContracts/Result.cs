using System;

namespace FreakyByte.Elija.Entities.DataContracts
{
    /// <summary>
    ///     Data Contract used to carry any information from the server to the client in response to a service request.
    /// </summary>
    [Serializable]
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


    [Serializable]
    public class Result<T> : Result
    {
        public T Data { get; set; }
    }
}