using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkonomiCore.CrossCuttingConcern.Caching
{
    public interface ICacheService
    {
        void Add(string key, object data, int cacheTime = 360); //default değeri 60.

        T Get<T>(string key);

        void Remove(string key);

        bool IsExist(string key);
    }
}
