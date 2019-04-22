using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkonomiCore.CrossCuttingConcern.Validation
{
    //generic olmalı (<T>)
    public interface IValidationService<T>
    {
        void Validate(T obj);
    }
}
