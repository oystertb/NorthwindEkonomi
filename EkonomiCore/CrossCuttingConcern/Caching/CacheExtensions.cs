using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkonomiCore.CrossCuttingConcern.Caching
{
    public static class CacheExtensions
    {
        public static T Cache<T>(this ICacheService cacheService, string key, Func<T> method, int cacheTime = 360)
        {
            if (cacheService.IsExist(key))
                return cacheService.Get<T>(key);

            var data = method.Invoke();

            cacheService.Add(key, data, cacheTime);

            return data;
        }
    }
}
