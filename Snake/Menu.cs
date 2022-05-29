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
    public partial class Menu_form : Form
    {
        public Menu_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Nastaveni();
            if (HrajeHracRadioButton.Checked) //hraje hráč
            {
                Nastaveni.HrajeAI = false;
                Nastaveni.HrajeAIExpert = false;
            }
            if (HrajeAIRadioButton.Checked) //hraje AI A* se spustí vždy při generaci nového jídla
            {
                Nastaveni.HrajeAI = true;
                Nastaveni.HrajeAIExpert = false;
            }
            if (AIExpertRadioButton.Checked) //hraje Ai A* se spustí po každém pohybu
            {
                Nastaveni.HrajeAI = false;
                Nastaveni.HrajeAIExpert = true;
            }
            Nastaveni.RychlostHry = ObtiznostTrackBar.Value; //nastavení rychlosti hry 
            Game game = new Game();//spuštění hry 
            game.ShowDialog();               
        }

        private void Konec_button_Click(object sender, EventArgs e) // ukončí aplikaci
        {
            Application.Exit();
        }

        private void ObtiznostTrackBar_Scroll(object sender, EventArgs e) // výpis obtížnosti
        {
            Obtiznostlabel.Text = ObtiznostTrackBar.Value.ToString();
        }
        private void HrajeHrac_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void HrajeAI_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
