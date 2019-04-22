using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkonomiCore.CrossCuttingConcern.Logging
{
    public interface ILogService
    {
        void Info(string message);
        void Info(object data);

        void Warn(string message);
        void Warn(object data);

        void Error(string message, Exception exception);
        void Error(object data, Exception exception);
    }
}
