using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;

namespace JeuDeCasseBrique
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Attributs
            int largeurFenetre = 1080;
            int hauteurFenetre = 720; 
            string titreFenetre = "Projet casse-brique";
            #endregion //Attributs

           //teste guillaume
            #region code
            GameWindow window = new GameWindow(largeurFenetre, hauteurFenetre, GraphicsMode.Default, titreFenetre);
            GestionJeu fenetrePrincipale = new GestionJeu(window);
            #endregion //code
        }
    }
}
