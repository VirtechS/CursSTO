using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using General = AutoService.ConneectClass.General;

namespace AutoService.ConneectClass
{

    public class MarkaAutoSettings
    {
        // Список картинок
        private static List<Image> images = new List<Image>();
        private static List<string> nameimages = new List<string>();
        private static string namepic = "";
        private static string namecar = "";

        public static string NameCar
        {
            get { return namecar; }
            set { namecar = value.Trim(); }
        }

        public static int ID { get; set; }
        public static string TextBtn { get; set; }
        public static bool is_click { get; set; }

        public static Image logo;
        public static string namePicture;


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
                        images.Add(Image.FromFile(General.directory + "\\images\\Марки\\" + namepic));
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
