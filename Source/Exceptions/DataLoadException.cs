using System;

namespace StorageSystem
{
    public class DataLoadException : Exception
    {
        public DataLoadException(string message) : base(message) { }
    }
}