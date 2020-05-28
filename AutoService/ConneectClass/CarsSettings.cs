using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.ConneectClass
{
    class CarsSettings
    {
	public static AutoServiceEntities context = new AutoServiceEntities();
	public string directory = Directory.GetCurrentDirectory();

    }
}
