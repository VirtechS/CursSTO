using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.ConneectClass
{
    // Для работы с клиентами
    class ClientAutoSettings
    {
	// Список картинок
	private static List<Image> images = new List<Image>();
	private static List<string> nameimages = new List<string>();

	private static string name = "";
	private static string surname = "";
	private static string patronymic = "";
	private static string phone = "";
	private static DateTime birthday;
	private static string namepic = "";
	private static string address = "";
	private static string numvu = "";

	public static string NameClient
	{
	    get { return name; }
	    set { name = value.Trim(); }
	}
	public static string SurnameClient
	{
	    get { return surname; }
	    set { surname = value.Trim(); }
	}
	public static string PatronymicClient
	{
	    get { return patronymic; }
	    set { patronymic = value.Trim(); }
	}
	public static string PhoneClient
	{
	    get { return phone; }
	    set { phone = value.Trim(); }
	}
	public static string AddressClient
	{
		get { return address; }
		set { address = value.Trim(); }
	}
	public static string NumvuClient
	{
		get { return numvu; }
		set { numvu = value.Trim(); }
	}
	public static DateTime BirthdayClient
	{
	    get { return birthday; }
	    set { birthday = value; }
	}
	public static int ID { get; set; }

	public static string TextBtn { get; set; }
	public static bool is_click { get; set; }


	public static string namePicture { get; set; }

	public static List<Image> GetPicture(System.Windows.Forms.DataGridView dtg, out List<string> nameimage)
	{
	    images.Clear();
	    nameimages.Clear();
	    for (int i = 0; i < dtg.RowCount; i++)
	    {
		try
		{
		    namepic = dtg.Rows[i].Cells["imagename"].FormattedValue.ToString().Trim();
		    if (namepic != "")
		    {
			images.Add(Image.FromFile(General.directory + "\\images\\Клиенты\\" + namepic));
			nameimages.Add(namepic);
		    }
		    else
		    {
			images.Add(Image.FromFile(General.pathNoImage));
			nameimages.Add("noimage.png");
		    }
		}
		catch (Exception)
		{
		    images.Add(Image.FromFile(General.pathNoImage));
		}
	    }
	    nameimage = nameimages;
	    return images;
	}
    }
}
