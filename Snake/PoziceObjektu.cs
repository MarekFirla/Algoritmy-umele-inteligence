using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class PoziceObjektu
    {
        public int X { get; set; } //pozice v ose X
        public int Y { get; set; } //pozice v ose Y
        public int Vaha { get; set; } //vzdalenost doposud g(x)
        public int Vzdalenost { get; set; } //heuristicka funkce h(x)
        public int VahaVzdalenost => Vaha + Vzdalenost; //součet funci  f(x)
        public PoziceObjektu Rodic { get; set; } // předešlé políčko 

        public void SetVzdaleost(int CilX, int CilY)
        {
            this.Vzdalenost = Math.Abs(CilX - X) + Math.Abs(CilY - Y); // výpočet metriky
        }

        public PoziceObjektu()
        { X = 0; Y = 0; }//výchozí hodnoty pozice
    }
}
