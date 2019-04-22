using EkonomiCore.CrossCuttingConcern.Caching;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EkonomiCore.Aspects.Caching
{
    [Serializable]
    public class CacheRemoveAspectAttribute : OnMethodBoundaryAspect
    {
        ICacheService _cacheService;
        private readonly string _key;
        Type _cacheType;

        public CacheRemoveAspectAttribute(string key, Type cacheType)
        {
            _key = key;
            _cacheType = cacheType;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            base.RuntimeInitialize(method);

            if (!typeof(ICacheService).IsAssignableFrom(_cacheType))
            {
                throw new ArgumentException("Geçerli Cache Servisi Bulunamadı!", nameof(_cacheType));
            }


            _cacheService = Activator.CreateInstance(_cacheType) as ICacheService;
        }
        public override void OnSuccess(MethodExecutionArgs args)
        {
            _cacheService.Remove(_key);
        }
    }
}
