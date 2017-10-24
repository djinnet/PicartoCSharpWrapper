using System;


namespace PicartoWrapperAPI.Helpers
{
    public class PicartoExeption : Exception
    {
        public PicartoExeption()
        {

        }

        public PicartoExeption(string message) : this(message, null)
        {

        }

        public PicartoExeption(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
