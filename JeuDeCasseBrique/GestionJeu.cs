using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace JeuDeCasseBrique
{
    class GestionJeu
    {
        #region Attriuts
        GameWindow window;
        #endregion

        #region ConstructeurInitialisation
        public GestionJeu(GameWindow window)
        {
            this.window = window;
        }
        #endregion
         private void start()
        {
            double nbrIPS = 60.0;
            double dureeAffichageCHaqueImage = 1.0 / nbrIPS;

            window.Run(dureeAffichageCHaqueImage);

        }
    }
}
