using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace JeuDeCasseBrique
{
    class GestionJeu
    {
        enum CoteObjets { NULL, NORD, SUD, EST, OUEST, NORD_EST, NORD_OUEST };

        #region Attriuts
        GameWindow window;
        Vector2[] listeDroitesCarre = new Vector2[4];
        #endregion

        #region ConstructeurInitialisation

        public void directionDictionary()
        {
            IDictionary<CoteObjets, Vector2[]> forme = new Dictionary<CoteObjets, Vector2[]>();
            forme.Add(CoteObjets.EST, listeDroitesCarre);
            forme.Add(CoteObjets.NORD, listeDroitesCarre);
            forme.Add(CoteObjets.NORD_EST, listeDroitesCarre);
            forme.Add(CoteObjets.NORD_OUEST, listeDroitesCarre);
            forme.Add(CoteObjets.NULL, listeDroitesCarre);
            forme.Add(CoteObjets.OUEST, listeDroitesCarre);
            forme.Add(CoteObjets.SUD, listeDroitesCarre);

        }

        public GestionJeu(GameWindow window)
        {
            this.window = window;
            start();
        }
        
         private void start()
        {

            double nbrIPS = 60.0;
            double dureeAffichageCHaqueImage = 1.0 / nbrIPS;

            window.Load += chargement;
            window.UpdateFrame += update;
            window.RenderFrame += rendu;

            window.Run(dureeAffichageCHaqueImage);
            // test 123
      

        }

        private void chargement (object sender, EventArgs arg)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            //changement couleur
        }

        private void update(object sender, FrameEventArgs arg)
        {
            //code 
        }
        #endregion //ConstructeurInitialisation

        #region GestionAffichage
        private void rendu(object sender, FrameEventArgs arg)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            window.SwapBuffers();

        }
        #endregion
    }
}
