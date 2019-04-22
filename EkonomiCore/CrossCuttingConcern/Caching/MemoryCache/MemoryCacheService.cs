using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace EkonomiCore.CrossCuttingConcern.Caching.MemoryCache
{
    public class MemoryCacheService : ICacheService
    {
        //önce DLL i refere edeceğiz. Referance dan add referance yaptık. system.runtime.cachingi ekledik.
        ObjectCache cache = System.Runtime.Caching.MemoryCache.Default;

        static object _lock = new object();//statik yaptık ki tüm kullanıcılar için aynı nesne geçerli olsun. new lenmesin

        public void Add(string key, object data, int cacheTime = 360)
        {
            if (!IsExist(key) && data!=null)
            {
                var policy = new CacheItemPolicy
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(cacheTime) //cache bu belirtilen dk sonra silinecek demek
                };

                lock (_lock) //başka bir kullanıcı buraya gelirse, kendinden önceki kullanıcının işinin bitmesini beklemek zorunda. Sonra devam edebilir.
                {
                    if (IsExist(key))
                        return;

                    cache.Add(key, data, policy);
                }

                
            }
        }

        public T Get<T>(string key)
        {
            var data = cache[key];

            return (T)data;
        }

        public bool IsExist(string key)
        {
            return cache.Contains(key);
        }

        public void Remove(string key)
        {
            cache.Remove(key);
        }
    }
}
