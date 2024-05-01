using System;

namespace StorageSystem
{
    public class DataSaveException : Exception
    {
        public DataSaveException(string message) : base(message) { }
    }
}