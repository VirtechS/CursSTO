using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoService.ConneectClass
{
    // Для работы с авто
    class AutoClientSettings
    {
        private static int carID;
        private static string model;
        private static string grs;
        private static string color;
        private static string pts;
        private static string ennumber;

        public static int CarID
        {
            get { return carID; }
            set { carID = value; }
        }
        public static string Model
        {
            get { return model; }
            set { model = value.Trim(); }
        }
        public static string GRS
        {
            get { return grs; }
            set { grs = value.Trim(); }
        }
        public static string COLOR
        {
            get { return color; }
            set { color = value.Trim(); }
        }
        public static string PTS
        {
            get { return pts; }
            set { pts = value.Trim(); }
        }
        public static string EnNumber
        {
            get { return ennumber; }
            set { ennumber = value.Trim(); }
        }
    }
}
