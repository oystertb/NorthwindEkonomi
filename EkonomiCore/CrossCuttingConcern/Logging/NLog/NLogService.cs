using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkonomiCore.CrossCuttingConcern.Logging.NLog
{
    public class NLogService : ILogService
    {
        Logger _logger;

        public NLogService()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public void Error(string message, Exception exception)
        {
            if (_logger.IsErrorEnabled)
            {
                _logger.Error(exception, message);
            }
        }

        public void Error(object data, Exception exception)
        {
            if (_logger.IsErrorEnabled)
            {
                var message = JsonConvert.SerializeObject(data);
                _logger.Error(exception, message); //Newtonson Json kütüphanesini indirdik bu noktada. Objeyi jsona, json ı objeye convert etmek için
            }
        }

        public void Info(string message)
        {
            if (_logger.IsInfoEnabled)
            {
                _logger.Info(message);
            }
        }

        public void Info(object data)
        {
            if (_logger.IsInfoEnabled)
            {
                var message = JsonConvert.SerializeObject(data);
                _logger.Info(message);
            }
        }

        public void Warn(string message)
        {
            if (_logger.IsWarnEnabled)
            {
                _logger.Warn(message);
            }
        }

        public void Warn(object data)
        {
            if (_logger.IsWarnEnabled)
            {
                var message = JsonConvert.SerializeObject(data);
                _logger.Warn(message);
            }
        }
    }
}
