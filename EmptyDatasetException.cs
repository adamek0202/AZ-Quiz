using System;

namespace AZ_Kviz
{
    internal class EmptyDatasetException : Exception
    {
        public EmptyDatasetException() {}
        public EmptyDatasetException(string message) : base(message) {}
        public EmptyDatasetException(string message, Exception innerException) : base(message, innerException) {}
    }
}
