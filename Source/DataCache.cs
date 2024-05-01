using System;
using System.Threading.Tasks;

namespace StorageSystem
{
    /// <summary>
    /// Manages the Cashing game data
    /// </summary>
    /// <typeparam name="T">Type of the data to Cache.</typeparam>
    public class DataCache<T>
    {
        private T m_CachedData;

        public async Task<T> GetDataAsync(Func<Task<T>> dataRetriever)
        {
            if (m_CachedData == null)
            {
                m_CachedData = await dataRetriever();
            }
            return m_CachedData;
        }

        public void InvalidateCache()
        {
            m_CachedData = default(T);
        }
    }
}