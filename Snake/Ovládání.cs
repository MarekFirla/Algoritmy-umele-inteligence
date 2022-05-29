using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace Snake
{
    class Ovladani // pro vstup s klávesnice 
    {
        private static Hashtable Klavesa = new Hashtable();

        public static bool KeyPress(Keys key)
        {
            if (Klavesa[key] == null)
            {
                return false;
            }
            return (bool)Klavesa[key];
        }

        public static void Zmena(Keys key, bool StavKlavesy)
        {
            Klavesa[key] = StavKlavesy;
        }
    }
}
