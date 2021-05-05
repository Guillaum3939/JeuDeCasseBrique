﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace JeuDeCasseBrique
{
    enum CoteObjets { NULL, NORD, SUD, EST, OUEST, NORD_EST, NORD_OUEST };

    class GestionJeu
    {

        #region Attriuts
        GameWindow window;
        Raquette raquette;
        List<Brique> brique;
        Balle balle;
        GestionAudio audio;
        Vector2[] listeDroitesBrique = new Vector2[4];
        #endregion

        #region ConstructeurInitialisation

        public void directionDictionary()
        {
            IDictionary<CoteObjets, Vector2[]> forme = new Dictionary<CoteObjets, Vector2[]>();
            forme.Add(CoteObjets.EST, listeDroitesBrique);
            forme.Add(CoteObjets.NORD, listeDroitesBrique);
            forme.Add(CoteObjets.NORD_EST, listeDroitesBrique);
            forme.Add(CoteObjets.NORD_OUEST, listeDroitesBrique);
            forme.Add(CoteObjets.NULL, listeDroitesBrique);
            forme.Add(CoteObjets.OUEST, listeDroitesBrique);
            forme.Add(CoteObjets.SUD, listeDroitesBrique);

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
            window.Resize += redimensionner;
            window.UpdateFrame += update;
            window.RenderFrame += rendu;
            window.KeyPress += Window_KeyPress;
            
            window.Run(dureeAffichageCHaqueImage);
            // test 123
           
        }

        private void redimensionner(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, window.Width, window.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-350.0, 350.0, -250, 250.0, -1.0, 1.0);
            GL.MatrixMode(MatrixMode.Modelview);
            
        }

        private void chargement (object sender, EventArgs arg)
        {
            //Musique de fond
            audio = new GestionAudio();
            audio.demarrerMusiqueDeFond();

            //couleur de fond
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            
            brique = new List<Brique>();

            // ranger 1
            brique.Add(new Brique("./image/caiseDebois.bmp", new Vector2(-300.0f, 210.0f), new Vector2(-300.0f, 230.0f), new Vector2(-250.0f, 230.0f), new Vector2(-250.0f, 210.0f)));
            brique.Add(new Brique("./image/caiseDebois.bmp", new Vector2(-240.0f, 210.0f), new Vector2(-240.0f, 230.0f), new Vector2(-190.0f, 230.0f), new Vector2(-190.0f, 210.0f)));
            brique.Add(new Brique("./image/caiseDebois.bmp", new Vector2(-180.0f, 210.0f), new Vector2(-180.0f, 230.0f), new Vector2(-130.0f, 230.0f), new Vector2(-130.0f, 210.0f)));
            brique.Add(new Brique("./image/caiseDebois.bmp", new Vector2(-120.0f, 210.0f), new Vector2(-120.0f, 230.0f), new Vector2(-70.0f, 230.0f), new Vector2(-70.0f, 210.0f)));
            brique.Add(new Brique("./image/caiseDebois.bmp", new Vector2(-60.0f, 210.0f), new Vector2(-60.0f, 230.0f), new Vector2(-10.0f, 230.0f), new Vector2(-10.0f, 210.0f)));
            brique.Add(new Brique("./image/caiseDebois.bmp", new Vector2(0.0f, 210.0f), new Vector2(0.0f, 230.0f), new Vector2(50.0f, 230.0f), new Vector2(50.0f, 210.0f)));
            brique.Add(new Brique("./image/caiseDebois.bmp", new Vector2(60.0f, 210.0f), new Vector2(60.0f, 230.0f), new Vector2(110.0f, 230.0f), new Vector2(110.0f, 210.0f)));
            brique.Add(new Brique("./image/caiseDebois.bmp", new Vector2(120.0f, 210.0f), new Vector2(120.0f, 230.0f), new Vector2(170.0f, 230.0f), new Vector2(170.0f, 210.0f)));
            brique.Add(new Brique("./image/caiseDebois.bmp", new Vector2(180.0f, 210.0f), new Vector2(180.0f, 230.0f), new Vector2(230.0f, 230.0f), new Vector2(230.0f, 210.0f)));
            brique.Add(new Brique("./image/caiseDebois.bmp", new Vector2(240.0f, 210.0f), new Vector2(240.0f, 230.0f), new Vector2(290.0f, 230.0f), new Vector2(290.0f, 210.0f)));

            //ranger 2
            brique.Add(new Brique("./image/caiseDebois.bmp", new Vector2(-300.0f, 180.0f), new Vector2(-300.0f, 200.0f), new Vector2(-250.0f, 200.0f), new Vector2(-250.0f, 180.0f)));
            brique.Add(new Brique("./image/caiseDebois.bmp", new Vector2(-240.0f, 180.0f), new Vector2(-240.0f, 200.0f), new Vector2(-190.0f, 200.0f), new Vector2(-190.0f, 180.0f)));
            brique.Add(new Brique("./image/caiseDebois.bmp", new Vector2(-180.0f, 180.0f), new Vector2(-180.0f, 200.0f), new Vector2(-130.0f, 200.0f), new Vector2(-130.0f, 180.0f)));
            brique.Add(new Brique("./image/caiseDebois.bmp", new Vector2(-120.0f, 180.0f), new Vector2(-120.0f, 200.0f), new Vector2(-70.0f, 200.0f), new Vector2(-70.0f, 180.0f)));
            brique.Add(new Brique("./image/caiseDebois.bmp", new Vector2(-60.0f, 180.0f), new Vector2(-60.0f, 200.0f), new Vector2(-10.0f, 200.0f), new Vector2(-10.0f, 180.0f)));
            brique.Add(new Brique("./image/caiseDebois.bmp", new Vector2(0.0f, 180.0f), new Vector2(0.0f, 200.0f), new Vector2(50.0f, 200.0f), new Vector2(50.0f, 180.0f)));
            brique.Add(new Brique("./image/caiseDebois.bmp", new Vector2(60.0f, 180.0f), new Vector2(60.0f, 200.0f), new Vector2(110.0f, 200.0f), new Vector2(110.0f, 180.0f)));
            brique.Add(new Brique("./image/caiseDebois.bmp", new Vector2(120.0f, 180.0f), new Vector2(120.0f, 200.0f), new Vector2(170.0f, 200.0f), new Vector2(170.0f, 180.0f)));
            brique.Add(new Brique("./image/caiseDebois.bmp", new Vector2(180.0f, 180.0f), new Vector2(180.0f, 200.0f), new Vector2(230.0f, 200.0f), new Vector2(230.0f, 180.0f)));
            brique.Add(new Brique("./image/caiseDebois.bmp", new Vector2(240.0f, 180.0f), new Vector2(240.0f, 200.0f), new Vector2(290.0f, 200.0f), new Vector2(290.0f, 180.0f)));

            //ranger 3
            brique.Add(new Brique("./image/caiseDebois.bmp", new Vector2(-300.0f, 150.0f), new Vector2(-300.0f, 170.0f), new Vector2(-250.0f, 170.0f), new Vector2(-250.0f, 150.0f)));
            brique.Add(new Brique("./image/caiseDebois.bmp", new Vector2(-240.0f, 150.0f), new Vector2(-240.0f, 170.0f), new Vector2(-190.0f, 170.0f), new Vector2(-190.0f, 150.0f)));
            brique.Add(new Brique("./image/caiseDebois.bmp", new Vector2(-180.0f, 150.0f), new Vector2(-180.0f, 170.0f), new Vector2(-130.0f, 170.0f), new Vector2(-130.0f, 150.0f)));
            brique.Add(new Brique("./image/caiseDebois.bmp", new Vector2(-120.0f, 150.0f), new Vector2(-120.0f, 170.0f), new Vector2(-70.0f, 170.0f), new Vector2(-70.0f, 150.0f)));
            brique.Add(new Brique("./image/caiseDebois.bmp", new Vector2(-60.0f, 150.0f), new Vector2(-60.0f, 170.0f), new Vector2(-10.0f, 170.0f), new Vector2(-10.0f, 150.0f)));
            brique.Add(new Brique("./image/caiseDebois.bmp", new Vector2(0.0f, 150.0f), new Vector2(0.0f, 170.0f), new Vector2(50.0f, 170.0f), new Vector2(50.0f, 150.0f)));
            brique.Add(new Brique("./image/caiseDebois.bmp", new Vector2(60.0f, 150.0f), new Vector2(60.0f, 170.0f), new Vector2(110.0f, 170.0f), new Vector2(110.0f, 150.0f)));
            brique.Add(new Brique("./image/caiseDebois.bmp", new Vector2(120.0f, 150.0f), new Vector2(120.0f, 170.0f), new Vector2(170.0f, 170.0f), new Vector2(170.0f, 150.0f)));
            brique.Add(new Brique("./image/caiseDebois.bmp", new Vector2(180.0f, 150.0f), new Vector2(180.0f, 170.0f), new Vector2(230.0f, 170.0f), new Vector2(230.0f, 150.0f)));
            brique.Add(new Brique("./image/caiseDebois.bmp", new Vector2(240.0f, 150.0f), new Vector2(240.0f, 170.0f), new Vector2(290.0f, 170.0f), new Vector2(290.0f, 150.0f)));



            Vector2 pointE = new Vector2(-40.0f, -225.0f);
            Vector2 pointF = new Vector2(-40.0f,-215.0f);
            Vector2 pointG = new Vector2(32.0f, -215.0f);
            Vector2 pointH = new Vector2(32.0f, -225.0f);
            raquette = new Raquette(pointE, pointF, pointG, pointH);

            Vector2 pointa = new Vector2(-20.0f, -210.0f);
            Vector2 pointb = new Vector2(-20.0f, -200.0f);
            Vector2 pointc = new Vector2(0.0f, -200.0f);
            Vector2 pointd = new Vector2(0.0f, -210.0f);
            balle = new Balle(pointa, pointb, pointc, pointd);
            

        }

        private void update(object sender, EventArgs arg)
        {
            balle.update(); //update de la balle
            detectionCollision();

            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Key.A) || keyboardState.IsKeyDown(Key.D) || keyboardState.IsKeyDown(Key.Right) || keyboardState.IsKeyDown(Key.Left) )
            {
                raquette.update();
                
            }
            
            
            //brique.update();
           
        }
        #endregion //ConstructeurInitialisation

        #region GestionAffichage
        private void rendu(object sender, EventArgs arg)
        {
            
            GL.Clear(ClearBufferMask.ColorBufferBit);

            raquette.dessiner();
            balle.dessiner();
            foreach (Brique brique in brique)
            {
                brique.dessiner();
            }
            window.SwapBuffers();

        }
        #endregion

        #region Action clavier

        private void Window_KeyPress(object sender, KeyPressEventArgs e)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Key.A) || keyboardState.IsKeyDown(Key.Right))
            {
                Console.WriteLine(e.KeyChar.ToString());
                //raquetteEnMvmt = true;
                raquette.Direction = false;
                
            }
            else if (keyboardState.IsKeyDown(Key.D) || keyboardState.IsKeyDown(Key.Left))
            {
                //raquetteEnMvmt = true;
                raquette.Direction = true;
                Console.WriteLine(e.KeyChar.ToString());
            }

        }

        #endregion clavier

        #region gestionCollisions
        private void detectionCollision()
        {
            Dictionary<CoteObjets, Vector2[]> listeDroitesBalle = balle.getDroitesCotes();
            Dictionary<CoteObjets, Vector2[]> listeDroitesRaquette = raquette.getDroitesCotes(); ;
            Dictionary<CoteObjets, Vector2[]> listeDroitesBrique;
            bool SiCollisionBalle = false;
            CoteObjets coteCollision = CoteObjets.NULL;

            foreach(KeyValuePair<CoteObjets, Vector2[]> droiteRaquette in listeDroitesRaquette){
                foreach (KeyValuePair<CoteObjets, Vector2[]> droiteBalle in listeDroitesBalle){
                if(intersection(droiteRaquette.Value, droiteBalle.Value))
                    {
                        SiCollisionBalle = true;
                        coteCollision = droiteBalle.Key;
                    }
                }
            }
            if (SiCollisionBalle)
            {
                Console.WriteLine(" Il y  a eu collision sur le cote : " + coteCollision.ToString());
                balle.inverserDirection();
            }

           
        }
        #region methodesWeb
        private bool intersection(Vector2[] droiteTriangle, Vector2[] droiteCarre)
        {
            // **************************************************
            // Méthodes trouvées sur le web
            // Traduite en français pour aider à la compréhension
            // **************************************************

            /*
             * Une droite est représentée par cette équation : y = ax + b
             * où "a" représente la pente et "b" est le décalage de "y" à l'origine
             * 
             * NOTE : Une division par zéro a pour résultat l'INFINI.
             * Si une droite est verticale, l'équation pour trouver "a" retournera l'INFINI
             * */
            bool siIntersection = false;

            // Calculer les valeur "a" pour chacune de deux droites
            float a_Triangle = (droiteTriangle[1].Y - droiteTriangle[0].Y) / (droiteTriangle[1].X - droiteTriangle[0].X);
            float a_Carre = (droiteCarre[1].Y - droiteCarre[0].Y) / (droiteCarre[1].X - droiteCarre[0].X);

            // Calculer les valeur "b" pour chacune de deux droites
            float b_Triangle = droiteTriangle[1].Y - a_Triangle * droiteTriangle[1].X;
            float b_Carre = droiteCarre[1].Y - a_Carre * droiteCarre[1].X;

            // Calculer les valeurs "x" et "y" pour le point d'intersection des deux lignes
            float x = (b_Carre - b_Triangle) / (a_Triangle - a_Carre);
            float y = a_Triangle * x + b_Triangle;

            // **************
            // Début des test
            if (float.IsInfinity(a_Triangle) && float.IsInfinity(a_Carre))
            {
                // Si les deux valeurs "a" sont l'INFINI, alors on a deux droites verticales.
                // Si les deux droites partagent le même "x", alors on vérifie alors la valeur "y".
                siIntersection = (droiteTriangle[0].X == droiteCarre[0].X) && (
                                    (droiteCarre[0].Y <= droiteTriangle[0].Y && droiteTriangle[0].Y <= droiteCarre[1].Y)
                                    || (droiteCarre[0].Y <= droiteTriangle[1].Y && droiteTriangle[1].Y <= droiteCarre[1].Y)
                                    );
            }
            else if (float.IsInfinity(a_Triangle) && !float.IsInfinity(a_Carre))
            {
                // La droite du triangle EST vertical et celle de la caisse NE L'EST PAS
                x = droiteTriangle[0].X;
                y = b_Carre * x + b_Carre;

                siIntersection = (
                    ((droiteTriangle[0].Y <= droiteTriangle[1].Y && LTE(droiteTriangle[0].Y, y) && GTE(droiteTriangle[1].Y, y)) || (droiteTriangle[0].Y >= droiteTriangle[1].Y && GTE(droiteTriangle[0].Y, y) && LTE(droiteTriangle[1].Y, y))) &&
                    ((droiteCarre[0].X <= droiteCarre[1].X && LTE(droiteCarre[0].X, x) && GTE(droiteCarre[1].X, x)) || (droiteCarre[0].X >= droiteCarre[1].X && GTE(droiteCarre[0].X, x) && LTE(droiteCarre[1].X, x))) &&
                    ((droiteCarre[0].Y <= droiteCarre[1].Y && LTE(droiteCarre[0].Y, y) && GTE(droiteCarre[1].Y, y)) || (droiteCarre[0].Y >= droiteCarre[1].Y && GTE(droiteCarre[0].Y, y) && LTE(droiteCarre[1].Y, y)))
                    );
            }
            else if (!float.IsInfinity(a_Triangle) && float.IsInfinity(a_Carre))
            {
                // La droite du triangle N'EST PAS vertical et celle de la caisse L'EST
                x = droiteCarre[0].X;
                y = a_Triangle * x + b_Triangle;

                siIntersection = (
                    ((droiteTriangle[0].X <= droiteTriangle[1].X && LTE(droiteTriangle[0].X, x) && GTE(droiteTriangle[1].X, x)) || (droiteTriangle[0].X >= droiteTriangle[1].X && GTE(droiteTriangle[0].X, x) && LTE(droiteTriangle[1].X, x))) &&
                    ((droiteTriangle[0].Y <= droiteTriangle[1].Y && LTE(droiteTriangle[0].Y, y) && GTE(droiteTriangle[1].Y, y)) || (droiteTriangle[0].Y >= droiteTriangle[1].Y && GTE(droiteTriangle[0].Y, y) && LTE(droiteTriangle[1].Y, y))) &&
                    ((droiteCarre[0].Y <= droiteCarre[1].Y && LTE(droiteCarre[0].Y, y) && GTE(droiteCarre[1].Y, y)) || (droiteCarre[0].Y >= droiteCarre[1].Y && GTE(droiteCarre[0].Y, y) && LTE(droiteCarre[1].Y, y)))
                    );
            }

            // Finalement, vérifier si le point d'interception est à l'intérieur de tous les points
            if (!siIntersection)
            {
                siIntersection = (
                    ((droiteTriangle[0].X <= droiteTriangle[1].X && LTE(droiteTriangle[0].X, x) && GTE(droiteTriangle[1].X, x)) || (droiteTriangle[0].X >= droiteTriangle[1].X && GTE(droiteTriangle[0].X, x) && LTE(droiteTriangle[1].X, x))) &&
                    ((droiteTriangle[0].Y <= droiteTriangle[1].Y && LTE(droiteTriangle[0].Y, y) && GTE(droiteTriangle[1].Y, y)) || (droiteTriangle[0].Y >= droiteTriangle[1].Y && GTE(droiteTriangle[0].Y, y) && LTE(droiteTriangle[1].Y, y))) &&
                    ((droiteCarre[0].X <= droiteCarre[1].X && LTE(droiteCarre[0].X, x) && GTE(droiteCarre[1].X, x)) || (droiteCarre[0].X >= droiteCarre[1].X && GTE(droiteCarre[0].X, x) && LTE(droiteCarre[1].X, x))) &&
                    ((droiteCarre[0].Y <= droiteCarre[1].Y && LTE(droiteCarre[0].Y, y) && GTE(droiteCarre[1].Y, y)) || (droiteCarre[0].Y >= droiteCarre[1].Y && GTE(droiteCarre[0].Y, y) && LTE(droiteCarre[1].Y, y))));
            }

            return siIntersection;
        }
        
        // ****************************
        // Méthodes trouvées sur le web
        // Celles-ci permettent d'ajuster la précision lors des différentes comparaisons possibles.
        // ****************************

        /// <summary>
        /// Less Than or Equal: Tells you if the left value is less than or equal to the right value
        /// with floating point precision error taken into account.
        /// </summary>
        /// <param name="leftVal">The value on the left side of comparison operator</param>
        /// <param name="rightVal">The value on the right side of comparison operator</param>
        /// <returns>True if the left value and right value are within 0.000001 of each other, or if leftVal is less than rightVal</returns>
        private bool LTE(float leftVal, float rightVal)
        {
            return (EE(leftVal, rightVal) || leftVal < rightVal);

        }

        /// <summary>
        /// Greather Than or Equal: Tells you if the left value is greater than or equal to the right value
        /// with floating point precision error taken into account.
        /// </summary>
        /// <param name="leftVal">The value on the left side of comparison operator</param>
        /// <param name="rightVal">The value on the right side of comparison operator</param>
        /// <returns>True if the left value and right value are within 0.000001 of each other, or if leftVal is greater than rightVal</returns>
        private bool GTE(float leftVal, float rightVal)
        {
            return (EE(leftVal, rightVal) || leftVal > rightVal);
        }

        /// <summary>
        /// Equal-Equal: Tells you if two doubles are equivalent even with floating point precision errors
        /// </summary>
        /// <param name="Val1">First double value</param>
        /// <param name="Val2">Second double value</param>
        /// <returns>true if they are within 0.000001 of each other, false otherwise.</returns>
        private bool EE(float Val1, float Val2)
        {
            return (System.Math.Abs(Val1 - Val2) < 0.000001f);
        }

        /// <summary>
        /// Equal-Equal: Tells you if two doubles are equivalent even with floating point precision errors
        /// </summary>
        /// <param name="Val1">First double value</param>
        /// <param name="Val2">Second double value</param>
        /// <param name="Epsilon">The delta value the two doubles need to be within to be considered equal</param>
        /// <returns>true if they are within the epsilon value of each other, false otherwise.</returns>
        private bool EE(float Val1, float Val2, float Epsilon)
        {
            return (System.Math.Abs(Val1 - Val2) < Epsilon);
        }
        #endregion // methodesWeb
        #endregion // gestionCollisions
        
    }
}
