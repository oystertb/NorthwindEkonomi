using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwindEkonomi.MvcUI.Models
{
    //Modelin isimlendirme standardı 'Home' + 'Demo' + View + Model
    public class HomeDemoViewModel
    {
        public List<string> Isimler { get; set; }

        public List<int> Sayilar { get; set; }
    }
}