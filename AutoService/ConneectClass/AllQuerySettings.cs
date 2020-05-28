using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.ConneectClass
{
    class AllQuerySettings
    {
	private static DateTime? dateforReady;
	private static int clientID;
	private static int masterID;
	private static DateTime dateVisit;
	private static string clientFIO;
	private static string carInfo;
	private static string masterFIO;

	public static DateTime? DateForReady
	{
	    get { return dateforReady; }
	    set { dateforReady = value; }
	}
	public static int MasterID
	{
	    get { return masterID; }
	    set { masterID = value; }
	}
	public static int ClientID
	{
	    get { return clientID; }
	    set { clientID = value; }
	}
	public static DateTime DateVisit
	{
	    get { return dateVisit; }
	    set { dateVisit = value; }
	}
	public static string ClientFIO
	{
	    get { return clientFIO; }
	    set { clientFIO = value.Trim(); }
	}
	public static string MasterFIO
	{
	    get { return masterFIO; }
	    set { masterFIO = value.Trim(); }
	}
	public static string CarInfo
	{
	    get { return carInfo; }
	    set { carInfo = value.Trim(); }
	}
	public static bool Done
	{
	    get ; set ;
	}
	public static DateTime Birthday
	{
	    get ; 
	    set ; 
	}
    }
}
