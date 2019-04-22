using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkonomiCore.CrossCuttingConcern.ExceptionHandling
{
    public class ValidationException : NotificationException
    {
        public ValidationException(string message) : base(message)
        {
        }
    }
}
