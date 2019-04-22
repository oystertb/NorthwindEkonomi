using EkonomiCore.CrossCuttingConcern.Logging;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EkonomiCore.Aspects.ExceptionHandling
{
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Method)] // Sadece methodları loglamasını istiyoruz. Böylece constructor ve propertyleri loglamayacağız.
    public class LogAspectAttribute : OnMethodBoundaryAspect
    {
        ILogService _logService;
        Type _logType;

        public LogAspectAttribute(Type logType)
        {
            _logType = logType;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            base.RuntimeInitialize(method);

            if (!typeof(ILogService).IsAssignableFrom(_logType))
            {
                throw new ArgumentException("Geçerli Log Servisi Bulunamadı!", nameof(_logType));
            }


            _logService = Activator.CreateInstance(_logType) as ILogService;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            var attrs = args.Method.GetCustomAttributes(typeof(NoLogAttribute), true); //Her yerde log alacak ama product ın getall methodun da almayacak. Çünkü ona NoLog tanımladık.

            if (attrs.Length > 0)
                return;

            string fullName = string.Format("{0}.{1}", args.Method.DeclaringType?.FullName, args.Method.Name);
            _logService.Info(new { Method = fullName, Args = args.Arguments });
        }
    }
}
