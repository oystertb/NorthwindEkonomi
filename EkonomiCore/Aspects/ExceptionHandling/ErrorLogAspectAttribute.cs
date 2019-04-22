using EkonomiCore.CrossCuttingConcern.ExceptionHandling;
using EkonomiCore.CrossCuttingConcern.Logging;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EkonomiCore.Aspects.ExceptionHandling
{
    [Serializable]
    public class ErrorLogAspectAttribute :OnExceptionAspect
    {
        ILogService _logService;
        Type _logType;

        public ErrorLogAspectAttribute(Type logType)
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
        public override void OnException(MethodExecutionArgs args) //Bu methodu ezdik
        {
            args.FlowBehavior = FlowBehavior.RethrowException;

            if (args.Exception is ValidationException)
                return;

            _logService.Error(args.Arguments, args.Exception);
        }
    }
}
