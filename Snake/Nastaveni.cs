using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
    public partial class Nastaveni
    {

        public static int SirkaPolicka { get; set; } //nastavení vekosti jednoho dílku
        public static int DelkaPolicka { get; set; } 
        public static int RychlostHry { get; set; } //nastavení rychlosti hry
        public static int Score { get; set; } //nastavení celkového score
        public static int Body { get; set; } //nastavení kolik bodů se přidá za jedno jídlo
        public static bool GameOver { get; set; } //určení jestli hra probíhá nebo již skončila 
        public static bool HrajeAI { get; set; } //určení kdo ovládá hru
        public static bool HrajeAIExpert { get; set; }
        public static SmeryPohybu smery { get; set; } //směry pohybu po hracím poli

        public Nastaveni()
        {
            //nastavení výchozích hodnot
            SirkaPolicka = 15; 
            DelkaPolicka = 15; 
            RychlostHry = 20;
            Score = 0; 
            Body = 100;
            HrajeAI = false;
            GameOver = false;
            smery = SmeryPohybu.Dolu;
          
        }
    }
    public enum SmeryPohybu 
    {
        Nahoru,
        Dolu,
        Vlevo,
        Vpravo,
    }
}
