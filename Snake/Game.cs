using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Game : Form
    {
        private static List<PoziceObjektu> Had = new List<PoziceObjektu>(); //list kde se ukládají pozice dílků hada
        private static List<string> Pohyby = new List<string>(); //list kde se ukládá trasa k jídlu 
        private static PoziceObjektu Jidlo = new PoziceObjektu(); //uožení pozice jídla na herním plánu
        
        public Game()
        {
            InitializeComponent();//vytvoření 

            GameTimer.Interval = (1000/Nastaveni.RychlostHry); //nastevení rychlosti tikání tieru, definuje rychlossti hry 
            GameTimer.Tick += Aktualizace; //nastavení metody která s zavolá při každém ticku
            GameTimer.Start(); //spuštění Timeru 
            Start(); //zahajení hry 
        }

        private void Aktualizace(object sender, EventArgs e)
        {

            if (Nastaveni.GameOver == true)
            {
                if (Ovladani.KeyPress(Keys.Enter)) //restart hry při stisku enter
                {
                    Start();
                }
                if (Ovladani.KeyPress(Keys.Escape)) // ukonšení hry stiskem esc
                {
                    Ovladani.Zmena(Keys.Escape, false); // nasavení klávesy jako nestisknutá 
                    this.Dispose(); // uvolnění prostředků
                    this.Close(); // zavření okna 
                }
            }

            else
            {
                if (Nastaveni.HrajeAI || Nastaveni.HrajeAIExpert) //hraje AI nastavení směr pohybu podle lístu pohyby
                {
                    if(Pohyby.Count>0)
                    {
                        if (Pohyby[0] == "L") //vlevo
                        {
                            Nastaveni.smery = SmeryPohybu.Vlevo;
                        }
                        if (Pohyby[0] == "P") //vpravo
                        {
                            Nastaveni.smery = SmeryPohybu.Vpravo;
                        }
                        if (Pohyby[0] == "D")//dolů
                        {
                            Nastaveni.smery = SmeryPohybu.Dolu;
                        }
                        if (Pohyby[0] == "N")//bahoru
                        {
                            Nastaveni.smery = SmeryPohybu.Nahoru;
                        }
                        Pohyby.RemoveAt(0);
                    }
                }

                else // ovládání hráčem klávsami WASD nebo šipkami
                {
                    if ((Ovladani.KeyPress(Keys.Right) || Ovladani.KeyPress(Keys.D)) && Nastaveni.smery != SmeryPohybu.Vlevo)
                    {
                        Nastaveni.smery = SmeryPohybu.Vpravo;
                    }
                    else if ((Ovladani.KeyPress(Keys.Left) || Ovladani.KeyPress(Keys.A)) && Nastaveni.smery != SmeryPohybu.Vpravo)
                    {
                        Nastaveni.smery = SmeryPohybu.Vlevo;
                    }
                    else if ((Ovladani.KeyPress(Keys.Up) || Ovladani.KeyPress(Keys.W)) && Nastaveni.smery != SmeryPohybu.Dolu)
                    {
                        Nastaveni.smery = SmeryPohybu.Nahoru;
                    }
                    else if ((Ovladani.KeyPress(Keys.Down) || Ovladani.KeyPress(Keys.S)) && Nastaveni.smery != SmeryPohybu.Nahoru)
                    {
                        Nastaveni.smery = SmeryPohybu.Dolu;
                    }
                }  
                
                Pohyb(); // zavoláníí mtody pro posun dílků hada
            }
            GameBox.Invalidate(); //aktualizace herní plochy 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Keyisup(object sender, KeyEventArgs e) //vráti false pokud není klávesa stisknuta
        {
            Ovladani.Zmena(e.KeyCode, false);
        }

        private void Keyisdown(object sender, KeyEventArgs e) //vráti true pokud je klávesa stisknuta
        {
            Ovladani.Zmena(e.KeyCode, true);
        }

        private void GrafikaHada(object sender, PaintEventArgs e)
        {
            Graphics gameBox = e.Graphics; //třida pro tvorbu jdnoduché grafiky 

            if (Nastaveni.GameOver == false) //ověření zda hra již není u konce 
            {
                Brush BarvaObjektu;

                if (Nastaveni.HrajeAIExpert) //nastavení pro expert AI A* se provede při kardé aktualizaci obrazu
                {
                    List<string> mapa = GenerujHerniPole();
                    Pohyby = AStar(mapa);
                }

                for (int i = 0; i < Had.Count; i++) //vytvoření objektů pro celého hada 
                {
                    if (i == 0)
                    {
                        BarvaObjektu = Brushes.Black; //přepne vytvořiní dílku na černou barvu - první dílek hada je černý 
                    }
                    else
                    {
                        BarvaObjektu = Brushes.Red; //přepne vytvořiní dílku na červenou barvu - zbytek hada je červený
                    }
                    //nakreslí kruh na pozici dílku hada o velikosti políčka 
                    gameBox.FillEllipse(BarvaObjektu,  new Rectangle(
                                            Had[i].X * Nastaveni.SirkaPolicka,
                                            Had[i].Y * Nastaveni.DelkaPolicka, 
                                            Nastaveni.SirkaPolicka, Nastaveni.DelkaPolicka)); 
                }
                //nakreslí kruh na pozici dílku hada o velikosti políčka
                gameBox.FillEllipse(Brushes.Green,
                                    new Rectangle(
                                        Jidlo.X * Nastaveni.SirkaPolicka,
                                        Jidlo.Y * Nastaveni.DelkaPolicka,
                                        Nastaveni.SirkaPolicka, Nastaveni.DelkaPolicka));
            }
            else //pokud hra je u konce vypíše se end screen
            {            
                EndScreen.Text = "Konec Hry \n" + "Finání skoré je: " + Nastaveni.Score + "\n Enter pro restart \n" + "Escape pro ukončení hry \n";
                EndScreen.Visible = true;

            }
        }

        private void Start()
        {
            EndScreen.Visible = false; // nastaví end screen na neviditelný        
            Nastaveni.GameOver = false; // přepne indikátor na hra neskončila
            Nastaveni.Score = 0; // resetuje scoré 
            Had.Clear(); // vymaže list s dílky hada 
            Pohyby.Clear(); // vymaže list s pohyby hada pro AI
            PoziceObjektu Hlava = new PoziceObjektu { X = 18, Y = 8 }; //vytvoří první dílek hada a nastaví jeho pozici
            Had.Add(Hlava); //přidá přidá první dílek do listu had
            Score.Text = Nastaveni.Score.ToString(); //zobrazaní score  
            GeneraceJidla(); //vygeneruje první jídlo pro hada 

        }

        private void Konec() // nastaví hru na ukončenou 
        {
            Nastaveni.GameOver = true;
        }

        private void Pohyb()
        {
            for (int i = Had.Count-1; i >= 0; i--) 
            {
                if (i == 0)// pro první dílek - hlava hada 
                {
                    switch (Nastaveni.smery) //sjistí kterým směrem se má had pohybovat a mění pozice jednotlivých dílků
                    {
                        case SmeryPohybu.Vpravo:
                            Had[i].X++;
                            break;
                        case SmeryPohybu.Vlevo:
                            Had[i].X--;
                            break;
                        case SmeryPohybu.Nahoru:
                            Had[i].Y--;
                            break;
                        case SmeryPohybu.Dolu:
                            Had[i].Y++;
                            break;
                    }

                    // čast která omezuje aby had neodešel z herního boxu
                    int maxXpos = GameBox.Size.Width / Nastaveni.SirkaPolicka-1;
                    int maxYpos = GameBox.Size.Height / Nastaveni.DelkaPolicka-1;

                    if (Had[i].X < 0)
                    {
                        Had[i].X = maxXpos;
                    }

                    if (Had[i].Y < 0)
                    {
                        Had[i].Y = maxYpos;
                    }

                    if (Had[i].X > maxXpos)
                    {
                        Had[i].X = 0; 
                    }

                    if (Had[i].Y > maxYpos)
                    {
                        Had[i].Y = 0;
                    }

                    for (int j = 1; j < Had.Count; j++) // pokud se pozice nějakého dílku hada rovaná jinému hra se ukončí
                    {
                        if (Had[i].X == Had[j].X && Had[i].Y == Had[j].Y)
                        {
                            Konec();
                        }
                    }

                    if (Had[0].X == Jidlo.X && Had[0].Y == Jidlo.Y) // pokud první dílek hada narazí na jídlo 
                    {
                        Jez();
                    }

                }
                else // posune ostatní dílky hada
                {
                    Had[i].X = Had[i - 1].X;
                    Had[i].Y = Had[i - 1].Y;
                }
            }
        }

        private void GeneraceJidla() //nháhodně generuje jídlo v hracím poli
        {
            int maxXpos = GameBox.Size.Width / Nastaveni.SirkaPolicka; // maximání rozměry pole
            int maxYpos = GameBox.Size.Height / Nastaveni.DelkaPolicka;
            Random rnd = new Random(); //Vytvoření random třídy 
            int xPos = rnd.Next(0, maxXpos);//vygenerování náhodných souřadnic
            int yPos = rnd.Next(0, maxYpos);
            bool Kolize = true;
            int pocitadlo = 0;

            while(Kolize && pocitadlo < 10) // 10 krát kontola zda se jídlo nevygenerovalo do pozice kde se nachází dílky hada
            {
                Kolize = false;
                for (int i = 0; i < Had.Count; i++)
                {
                    if (Had[i].X == xPos && Had[i].Y == yPos)
                    {
                        xPos = rnd.Next(0, maxXpos);
                        yPos = rnd.Next(0, maxYpos);
                        Kolize = true;
                        pocitadlo += 1;
                        break;
                    }
                }
            }


            Jidlo = new PoziceObjektu { X = xPos, Y = yPos };// vytvoří jídlo na náhodné pozici

            if (Nastaveni.HrajeAI)// pro AI najde nejkratší cestu k jídlu a směry k němu 
            {
                List<string> mapa = GenerujHerniPole(); 
                Pohyby = AStar(mapa);
            }
        }
      
        private void Jez()
        {
            PoziceObjektu telo = new PoziceObjektu //vytvoří nový dílek s pozicí na konci hada 
            {
                X = Had[Had.Count - 1].X,
                Y = Had[Had.Count - 1].Y
            };

            Had.Add(telo); //přidá nový dílek do listu had
            Nastaveni.Score += Nastaveni.Body; //přičte se score 
            Score.Text = Nastaveni.Score.ToString(); // aktualizuje se score
            GeneraceJidla(); // vygeneruje se další jídlo
        }

        static private List<string> AStar(List<string> mapa) //funkce pro nalezení nejkratší cesty 
        {
            List<string> pohyby = new List<string>(); // ist kde se ukládají směry nekratší cesty 

            var start = new PoziceObjektu(); // startovní pozice 
            start.Y = Had[0].Y;
            start.X = Had[0].X;

            var finish = new PoziceObjektu(); // cílová pozce
            finish.Y = Jidlo.Y;
            finish.X = Jidlo.X;

            start.SetVzdaleost(finish.X, finish.Y);//euklidovská vzdálenost

            var AktivniPozice = new List<PoziceObjektu>(); // pozice která se zrovna prohledává
            AktivniPozice.Add(start); // zavínáme se startem 
            var ProhledanePozice = new List<PoziceObjektu>(); //list pozic které se již prohledaly

            while (AktivniPozice.Any())//kontorlujme dokud nvyčerpáme všechny možné pozice 
            {
                var ZkontrolovanePozice = AktivniPozice.OrderBy(x => x.VahaVzdalenost).First();

                if (ZkontrolovanePozice.X == finish.X && ZkontrolovanePozice.Y == finish.Y)//pokud dosáhneme cíle uložíme cestu do listu
                {
                    var PoziceKZapsani = ZkontrolovanePozice;
                    List<int> cestaX = new List<int>();
                    List<int> cestaY = new List<int>();

                    while (true)
                    {
                        cestaX.Add(PoziceKZapsani.X);//Rozdělení pozic na X a Y k urcění směru
                        cestaY.Add(PoziceKZapsani.Y);
                        PoziceKZapsani = PoziceKZapsani.Rodic;
                        if (PoziceKZapsani == null)
                        {
                            for (int i = 0; i < cestaX.Count() - 1; i++) //určí se směr a zapíše se do listu
                            {
                                if (cestaX[i] < cestaX[i + 1])//Směr Doleva
                                {
                                    pohyby.Add("L");
                                }

                                if (cestaX[i] > cestaX[i + 1])//Směr Doprava
                                {
                                    pohyby.Add("P");
                                }

                                if (cestaY[i] < cestaY[i + 1])//Směr Nahoru
                                {
                                    pohyby.Add("N");
                                }

                                if (cestaY[i] > cestaY[i + 1])//Směr Dolu
                                {
                                    pohyby.Add("D");
                                }

                            }
                            pohyby.Reverse();//Prevratit seznam na Strt -> Cil
                            return pohyby;
                        }
                    }
                }

                ProhledanePozice.Add(ZkontrolovanePozice);//Dalsi pozice
                AktivniPozice.Remove(ZkontrolovanePozice);

                var VolnePozice = GetPrazdnePozice(mapa, ZkontrolovanePozice, finish);//Neobsazene pozice

                foreach (var PrazdnaPozice in VolnePozice)
                {
                    if (ProhledanePozice.Any(x => x.X == PrazdnaPozice.X && x.Y == PrazdnaPozice.Y))//tato pozice se již porohledala
                    {
                        continue;
                    }
                  
                    if (AktivniPozice.Any(x => x.X == PrazdnaPozice.X && x.Y == PrazdnaPozice.Y))//hledání nejlepší cesty
                    {
                        var existingTile = AktivniPozice.First(x => x.X == PrazdnaPozice.X && x.Y == PrazdnaPozice.Y);

                        if (existingTile.VahaVzdalenost > ZkontrolovanePozice.VahaVzdalenost)// nalezení lepší cesty a přidání do listu
                        {
                            AktivniPozice.Remove(existingTile);
                            AktivniPozice.Add(PrazdnaPozice);
                        }
                    }
                    else
                    {
                        //neprohledaná pozice 
                        AktivniPozice.Add(PrazdnaPozice);
                    }
                }
            }
            pohyby.Clear();
            pohyby.Add("NONE");//cesta nenalezena
            return pohyby;
        }

        private static List<PoziceObjektu> GetPrazdnePozice(List<string> map, PoziceObjektu Pozice, PoziceObjektu CilovaPozice)
        {
            var MoznePozice = new List<PoziceObjektu>()
            {
        new PoziceObjektu { X = Pozice.X, Y = Pozice.Y - 1, Rodic = Pozice, Vaha = Pozice.Vaha + 1 },
        new PoziceObjektu { X = Pozice.X, Y = Pozice.Y + 1, Rodic = Pozice, Vaha = Pozice.Vaha + 1},
        new PoziceObjektu { X = Pozice.X - 1, Y = Pozice.Y, Rodic = Pozice, Vaha = Pozice.Vaha + 1 },
        new PoziceObjektu { X = Pozice.X + 1, Y = Pozice.Y, Rodic = Pozice, Vaha = Pozice.Vaha + 1 },
            };
            MoznePozice.ForEach(temp => temp.SetVzdaleost(CilovaPozice.X, CilovaPozice.Y));
            var maxX = map.First().Length - 1;
            var maxY = map.Count - 1;
            return MoznePozice
                    .Where(temp => temp.X >= 0 && temp.X <= maxX)
                    .Where(temp => temp.Y >= 0 && temp.Y <= maxY)
                    .Where(temp => map[temp.Y][temp.X] == ' ' || map[temp.Y][temp.X] == 'B')
                    .ToList();
        } //vráti list prázdných pozic

        private List<string> GenerujHerniPole()//vytroření součastného stavu herního pole pro A*
        {
            List<string> mapa = new List<string>(); //list do kterého see bude ukládat po řádcích herní plán 
            int maxXpos = GameBox.Size.Width / Nastaveni.SirkaPolicka - 1;
            int maxYpos = GameBox.Size.Height / Nastaveni.DelkaPolicka - 1;
            string temp; 

            for (int y = 0; y <= maxYpos; y++)//vygenerování prázdné mapy v podobě listu
            {
                temp = null;
                for (int x = 0; x <= maxXpos; x++) //vygenerování jednoho rádku mapy
                {
                    temp +=" ";
                }
                mapa.Add(temp); // přidání do listu
            }

            for (int i = 0; i < Had.Count; i++) // přídání do mapy dílky hada 
            {
                string temp_str = mapa[Had[i].Y];
                char[] temp_ch = temp_str.ToCharArray();
                temp_ch[Had[i].X] = 'X';
                string newstring = new string(temp_ch);
                mapa[Had[i].Y] = newstring;
            }                         
            return mapa;
        }

        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            GameTimer.Stop();//zastavení timeru
            GameTimer.Tick -= Aktualizace;
            GameTimer.Dispose();
            GameTimer = null;
        }
    }
}