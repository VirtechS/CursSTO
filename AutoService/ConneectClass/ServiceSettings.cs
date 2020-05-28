using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.ConneectClass
{
    class ServiceSettings
    {

	private static string nameService = "";
	private static string discription = "";
	private static decimal price = 0;


	public static int ID { get; set; }
	public static string NameService
	{
	    get { return nameService; }
	    set { nameService = value.Trim(); }
	}
    public static string Discription
	{
        get { return discription; }
        set { discription = value.Trim(); }
	}
    public static decimal Price
    {
        get { return price; }
        set { price = value; }
    }
    public static string TextBtn { get; set; }
    public static bool is_click { get; set; }
    }
}
