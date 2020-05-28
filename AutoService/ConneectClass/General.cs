using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.ConneectClass
{
    class General
    {
	public enum Status { Admin = 1, User = 2 }
	public static AutoServiceEntities context = new AutoServiceEntities(); // контейнер
    public static string directory = Directory.GetCurrentDirectory(); // путь
	public static string pathNoImage = directory + "\\images\\noimage.png"; // 404 img
	public static int mode { get ;  set ; } // режим доступа
	public static string nickname { get; set; } // ник
    }
}
