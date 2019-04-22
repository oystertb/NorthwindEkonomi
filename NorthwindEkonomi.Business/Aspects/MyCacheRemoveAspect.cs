using EkonomiCore.Aspects.Caching;
using EkonomiCore.CrossCuttingConcern.Caching.MemoryCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindEkonomi.Business.Aspects
{
    [Serializable]
    public class MyCacheRemoveAspect : CacheRemoveAspectAttribute
    {
        public MyCacheRemoveAspect(string key) : base(key, typeof(MemoryCacheService))
        {
        }
    }
}
