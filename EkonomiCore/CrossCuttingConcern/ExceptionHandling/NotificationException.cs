using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkonomiCore.CrossCuttingConcern.ExceptionHandling
{
    public class NotificationException : Exception // Exception fırlatabilmek için Exceptiondan türemesi lazım. inherit
    {
        public NotificationException(string message):base(message)
        {

        }
    }
}
