using System;
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
        List<Brique> TableauDebrique;
        Brique brique;
        Balle balle;
        GestionAudio audio;
        Vector2[] listeDroitesBrique = new Vector2[4];
        Texte cptrBalle;
        int nbBalle;
        string texteBalle;
        Texte cptrPoints;
        int nbPoints;
        string textePoints;
        Texte cptrTableau;
        int nbTableau;
        string texteTableau;
        #endregion

        #region ConstructeurInitialisation

        public void directionDictionary()
        {
            //IDictionary<CoteObjets, Vector2[]> forme = new Dictionary<CoteObjets, Vector2[]>();
            //forme.Add(CoteObjets.EST, listeDroitesBrique);
            //forme.Add(CoteObjets.NORD, listeDroitesBrique);
            //forme.Add(CoteObjets.NORD_EST, listeDroitesBrique);
            //forme.Add(CoteObjets.NORD_OUEST, listeDroitesBrique);
            //forme.Add(CoteObjets.NULL, listeDroitesBrique);
            //forme.Add(CoteObjets.OUEST, listeDroitesBrique);
            //forme.Add(CoteObjets.SUD, listeDroitesBrique);

        }

        public GestionJeu(GameWindow window)
        {
            this.window = window;
            nbBalle = 10;
            texteBalle = "Nombre de balle : ";
            textePoints = "Nombre de points : ";
            nbPoints = 0;
            texteTableau = "Tableau :  #";
            nbTableau = 1;
            start();
        }

        private string getTxtCompletBalle(string texteBalle, int nbBalle)
        {
            string conca;
            conca = texteBalle + nbBalle;
            return conca;
        }

        private string getTxtCompletPoints(string textePoints, int nbPoints)
        {
            string conca;
            conca = textePoints + nbPoints;
            return conca;
        }

        private string getTxtCompletTableau(string texteTableau, int nbTableau)
        {
            string conca;
            conca = texteTableau + nbTableau;
            return conca;
        }

        private void start()
        {

            double nbrIPS = 60.0;
            double dureeAffichageCHaqueImage = 1.0 / nbrIPS;

            window.Load += chargement;
            window.Resize += redimensionner;
            window.UpdateFrame += update;
            window.RenderFrame += rendu;
            window.KeyDown += Window_KeyPress;   //Remplacer KeyPress par keyDown et le bug est disparu :)
            window.KeyDown += Window_KeyDown; // ultiliser pour la barre espace (lancement de la balle)
            window.Run(dureeAffichageCHaqueImage);
            // test 123
           
        }


        private string GetTxtCompletBalle(string texteBalle, int nbBalle)
        {
            string conca;
            conca = texteBalle + nbBalle;
            return conca;
        }

        private string GetTxtCompletPoints(string textePoints, int nbPoints)
        {
            string conca;
            conca = textePoints + nbPoints;
            return conca;
        }

        private string GetTxtCompletTableau(string texteTableau, int nbTableau)
        {
            string conca;
            conca = texteTableau + nbTableau;
            return conca;
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
            GL.Enable(EnableCap.Texture2D);         //Cette saloperie de ligne !!!!!!! **********

            // instanciation des briques
            TableauDebrique = new List<Brique>();

            float x = 60.0f;
            float y = 30f;

            float x1 = -300f;
            float x2 = -250f;

            float y1 = 180f;
            float y2 = 200f;

            string green = "./images/green.bmp";
            string blue = "./images/blue.bmp";
            string red = "./images/red.bmp";
            string yellow = "./images/yellow.bmp";
            string pink= "./images/pink.bmp";
            string orange = "./images/orange.bmp";

            string color = green;


            TableauDebrique.Add(new Brique(color, new Vector2(-300.0f, 180.0f), new Vector2(-300.0f, 200.0f), new Vector2(-250.0f, 200.0f), new Vector2(-250.0f, 180.0f)));
            for(int j = 0; j<6; j++)
            {
               
                for (int i = 0; i<10; i++)
                { 
               
                    TableauDebrique.Add(new Brique(color, new Vector2(x1, y1), new Vector2(x1, y2), new Vector2(x2, y2), new Vector2(x2,y1)));
                    x1 += x;
                    x2 += x;
                    

                }
                x1 = -300f;
                x2 = -250f;

                y1 -= y;
                y2 -= y;

                switch (j+1)
                {
                    case 1: color = blue;
                        break;
                    case 2:
                        color = pink;
                        break;
                    case 3:
                        color = red;
                        break;
                    case 4:
                        color = orange;
                        break;
                    case 5:
                        color = yellow;
                        break;
                }
            }


            #region ancienne brique

            ////ranger 1
            //TableauDebrique.Add(new Brique("./images/green.bmp", new Vector2(-300.0f, 180.0f), new Vector2(-300.0f, 200.0f), new Vector2(-250.0f, 200.0f), new Vector2(-250.0f, 180.0f)));
            //TableauDebrique.Add(new Brique("./images/green.bmp", new Vector2(-240.0f, 180.0f), new Vector2(-240.0f, 200.0f), new Vector2(-190.0f, 200.0f), new Vector2(-190.0f, 180.0f)));
            //TableauDebrique.Add(new Brique("./images/green.bmp", new Vector2(-180.0f, 180.0f), new Vector2(-180.0f, 200.0f), new Vector2(-130.0f, 200.0f), new Vector2(-130.0f, 180.0f)));
            //TableauDebrique.Add(new Brique("./images/green.bmp", new Vector2(-120.0f, 180.0f), new Vector2(-120.0f, 200.0f), new Vector2(-70.0f, 200.0f), new Vector2(-70.0f, 180.0f)));
            //TableauDebrique.Add(new Brique("./images/green.bmp", new Vector2(-60.0f, 180.0f), new Vector2(-60.0f, 200.0f), new Vector2(-10.0f, 200.0f), new Vector2(-10.0f, 180.0f)));
            //TableauDebrique.Add(new Brique("./images/green.bmp", new Vector2(0.0f, 180.0f), new Vector2(0.0f, 200.0f), new Vector2(50.0f, 200.0f), new Vector2(50.0f, 180.0f)));
            //TableauDebrique.Add(new Brique("./images/green.bmp", new Vector2(60.0f, 180.0f), new Vector2(60.0f, 200.0f), new Vector2(110.0f, 200.0f), new Vector2(110.0f, 180.0f)));
            //TableauDebrique.Add(new Brique("./images/green.bmp", new Vector2(120.0f, 180.0f), new Vector2(120.0f, 200.0f), new Vector2(170.0f, 200.0f), new Vector2(170.0f, 180.0f)));
            //TableauDebrique.Add(new Brique("./images/green.bmp", new Vector2(180.0f, 180.0f), new Vector2(180.0f, 200.0f), new Vector2(230.0f, 200.0f), new Vector2(230.0f, 180.0f)));
            //TableauDebrique.Add(new Brique("./images/green.bmp", new Vector2(240.0f, 180.0f), new Vector2(240.0f, 200.0f), new Vector2(290.0f, 200.0f), new Vector2(290.0f, 180.0f)));

            ////ranger 2
            //TableauDebrique.Add(new Brique("./images/orange.bmp", new Vector2(-300.0f, 150.0f), new Vector2(-300.0f, 170.0f), new Vector2(-250.0f, 170.0f), new Vector2(-250.0f, 150.0f)));
            //TableauDebrique.Add(new Brique("./images/orange.bmp", new Vector2(-240.0f, 150.0f), new Vector2(-240.0f, 170.0f), new Vector2(-190.0f, 170.0f), new Vector2(-190.0f, 150.0f)));
            //TableauDebrique.Add(new Brique("./images/orange.bmp", new Vector2(-180.0f, 150.0f), new Vector2(-180.0f, 170.0f), new Vector2(-130.0f, 170.0f), new Vector2(-130.0f, 150.0f)));
            //TableauDebrique.Add(new Brique("./images/orange.bmp", new Vector2(-120.0f, 150.0f), new Vector2(-120.0f, 170.0f), new Vector2(-70.0f, 170.0f), new Vector2(-70.0f, 150.0f)));
            //TableauDebrique.Add(new Brique("./images/orange.bmp", new Vector2(-60.0f, 150.0f), new Vector2(-60.0f, 170.0f), new Vector2(-10.0f, 170.0f), new Vector2(-10.0f, 150.0f)));
            //TableauDebrique.Add(new Brique("./images/orange.bmp", new Vector2(0.0f, 150.0f), new Vector2(0.0f, 170.0f), new Vector2(50.0f, 170.0f), new Vector2(50.0f, 150.0f)));
            //TableauDebrique.Add(new Brique("./images/orange.bmp", new Vector2(60.0f, 150.0f), new Vector2(60.0f, 170.0f), new Vector2(110.0f, 170.0f), new Vector2(110.0f, 150.0f)));
            //TableauDebrique.Add(new Brique("./images/orange.bmp", new Vector2(120.0f, 150.0f), new Vector2(120.0f, 170.0f), new Vector2(170.0f, 170.0f), new Vector2(170.0f, 150.0f)));
            //TableauDebrique.Add(new Brique("./images/orange.bmp", new Vector2(180.0f, 150.0f), new Vector2(180.0f, 170.0f), new Vector2(230.0f, 170.0f), new Vector2(230.0f, 150.0f)));
            //TableauDebrique.Add(new Brique("./images/orange.bmp", new Vector2(240.0f, 150.0f), new Vector2(240.0f, 170.0f), new Vector2(290.0f, 170.0f), new Vector2(290.0f, 150.0f)));

            ////ranger 3
            //TableauDebrique.Add(new Brique("./images/red.bmp", new Vector2(-300.0f, 120.0f), new Vector2(-300.0f, 140.0f), new Vector2(-250.0f, 140.0f), new Vector2(-250.0f, 120.0f)));
            //TableauDebrique.Add(new Brique("./images/red.bmp", new Vector2(-240.0f, 120.0f), new Vector2(-240.0f, 140.0f), new Vector2(-190.0f, 140.0f), new Vector2(-190.0f, 120.0f)));
            //TableauDebrique.Add(new Brique("./images/red.bmp", new Vector2(-180.0f, 120.0f), new Vector2(-180.0f, 140.0f), new Vector2(-130.0f, 140.0f), new Vector2(-130.0f, 120.0f)));
            //TableauDebrique.Add(new Brique("./images/red.bmp", new Vector2(-120.0f, 120.0f), new Vector2(-120.0f, 140.0f), new Vector2(-70.0f, 140.0f), new Vector2(-70.0f, 120.0f)));
            //TableauDebrique.Add(new Brique("./images/red.bmp", new Vector2(-60.0f, 120.0f), new Vector2(-60.0f, 140.0f), new Vector2(-10.0f, 140.0f), new Vector2(-10.0f, 120.0f)));
            //TableauDebrique.Add(new Brique("./images/red.bmp", new Vector2(0.0f, 120.0f), new Vector2(0.0f, 140.0f), new Vector2(50.0f, 140.0f), new Vector2(50.0f, 120.0f)));
            //TableauDebrique.Add(new Brique("./images/red.bmp", new Vector2(60.0f, 120.0f), new Vector2(60.0f, 140.0f), new Vector2(110.0f, 140.0f), new Vector2(110.0f, 120.0f)));
            //TableauDebrique.Add(new Brique("./images/red.bmp", new Vector2(120.0f, 120.0f), new Vector2(120.0f, 140.0f), new Vector2(170.0f, 140.0f), new Vector2(170.0f, 120.0f)));
            //TableauDebrique.Add(new Brique("./images/red.bmp", new Vector2(180.0f, 120.0f), new Vector2(180.0f, 140.0f), new Vector2(230.0f, 140.0f), new Vector2(230.0f, 120.0f)));
            //TableauDebrique.Add(new Brique("./images/red.bmp", new Vector2(240.0f, 120.0f), new Vector2(240.0f, 140.0f), new Vector2(290.0f, 140.0f), new Vector2(290.0f, 120.0f)));

            ////ranger 4
            //TableauDebrique.Add(new Brique("./images/yellow.bmp", new Vector2(-300.0f, 90.0f), new Vector2(-300.0f, 110.0f), new Vector2(-250.0f, 110.0f), new Vector2(-250.0f, 90.0f)));
            //TableauDebrique.Add(new Brique("./images/yellow.bmp", new Vector2(-240.0f, 90.0f), new Vector2(-240.0f, 110.0f), new Vector2(-190.0f, 110.0f), new Vector2(-190.0f, 90.0f)));
            //TableauDebrique.Add(new Brique("./images/yellow.bmp", new Vector2(-180.0f, 90.0f), new Vector2(-180.0f, 110.0f), new Vector2(-130.0f, 110.0f), new Vector2(-130.0f, 90.0f)));
            //TableauDebrique.Add(new Brique("./images/yellow.bmp", new Vector2(-120.0f, 90.0f), new Vector2(-120.0f, 110.0f), new Vector2(-70.0f, 110.0f), new Vector2(-70.0f, 90.0f)));
            //TableauDebrique.Add(new Brique("./images/yellow.bmp", new Vector2(-60.0f, 90.0f), new Vector2(-60.0f, 110.0f), new Vector2(-10.0f, 110.0f), new Vector2(-10.0f, 90.0f)));
            //TableauDebrique.Add(new Brique("./images/yellow.bmp", new Vector2(0.0f, 90.0f), new Vector2(0.0f, 110.0f), new Vector2(50.0f, 110.0f), new Vector2(50.0f, 90.0f)));
            //TableauDebrique.Add(new Brique("./images/yellow.bmp", new Vector2(60.0f, 90.0f), new Vector2(60.0f, 110.0f), new Vector2(110.0f, 110.0f), new Vector2(110.0f, 90.0f)));
            //TableauDebrique.Add(new Brique("./images/yellow.bmp", new Vector2(120.0f, 90.0f), new Vector2(120.0f, 110.0f), new Vector2(170.0f, 110.0f), new Vector2(170.0f, 90.0f)));
            //TableauDebrique.Add(new Brique("./images/yellow.bmp", new Vector2(180.0f, 90.0f), new Vector2(180.0f, 110.0f), new Vector2(230.0f, 110.0f), new Vector2(230.0f, 90.0f)));
            //TableauDebrique.Add(new Brique("./images/yellow.bmp", new Vector2(240.0f, 90.0f), new Vector2(240.0f, 110.0f), new Vector2(290.0f, 110.0f), new Vector2(290.0f, 90.0f)));

            ////ranger 5
            //TableauDebrique.Add(new Brique("./images/blue.bmp", new Vector2(-300.0f, 60.0f), new Vector2(-300.0f, 80.0f), new Vector2(-250.0f, 80.0f), new Vector2(-250.0f, 60.0f)));
            //TableauDebrique.Add(new Brique("./images/blue.bmp", new Vector2(-240.0f, 60.0f), new Vector2(-240.0f, 80.0f), new Vector2(-190.0f, 80.0f), new Vector2(-190.0f, 60.0f)));
            //TableauDebrique.Add(new Brique("./images/blue.bmp", new Vector2(-180.0f, 60.0f), new Vector2(-180.0f, 80.0f), new Vector2(-130.0f, 80.0f), new Vector2(-130.0f, 60.0f)));
            //TableauDebrique.Add(new Brique("./images/blue.bmp", new Vector2(-120.0f, 60.0f), new Vector2(-120.0f, 80.0f), new Vector2(-70.0f, 80.0f), new Vector2(-70.0f, 60.0f)));
            //TableauDebrique.Add(new Brique("./images/blue.bmp", new Vector2(-60.0f, 60.0f), new Vector2(-60.0f, 80.0f), new Vector2(-10.0f, 80.0f), new Vector2(-10.0f, 60.0f)));
            //TableauDebrique.Add(new Brique("./images/blue.bmp", new Vector2(0.0f, 60.0f), new Vector2(0.0f, 80.0f), new Vector2(50.0f, 80.0f), new Vector2(50.0f, 60.0f)));
            //TableauDebrique.Add(new Brique("./images/blue.bmp", new Vector2(60.0f, 60.0f), new Vector2(60.0f, 80.0f), new Vector2(110.0f, 80.0f), new Vector2(110.0f, 60.0f)));
            //TableauDebrique.Add(new Brique("./images/blue.bmp", new Vector2(120.0f, 60.0f), new Vector2(120.0f, 80.0f), new Vector2(170.0f, 80.0f), new Vector2(170.0f, 60.0f)));
            //TableauDebrique.Add(new Brique("./images/blue.bmp", new Vector2(180.0f, 60.0f), new Vector2(180.0f, 80.0f), new Vector2(230.0f, 80.0f), new Vector2(230.0f, 60.0f)));
            //TableauDebrique.Add(new Brique("./images/blue.bmp", new Vector2(240.0f, 60.0f), new Vector2(240.0f, 80.0f), new Vector2(290.0f, 80.0f), new Vector2(290.0f, 60.0f)));
            #endregion ancienne brique

            //instanciation de la raquette
            Vector2 pointE = new Vector2(-40.0f, -225.0f);
            Vector2 pointF = new Vector2(-40.0f,-215.0f);
            Vector2 pointG = new Vector2(32.0f, -215.0f);
            Vector2 pointH = new Vector2(32.0f, -225.0f);
            raquette = new Raquette(pointE, pointF, pointG, pointH);

            //instanciation de la balle
            Vector2 pointa = new Vector2(-20.0f, -210.0f);
            Vector2 pointb = new Vector2(-20.0f, -200.0f);
            Vector2 pointc = new Vector2(0.0f, -200.0f);
            Vector2 pointd = new Vector2(0.0f, -210.0f);
            balle = new Balle("./images/balle.bmp",pointa, pointb, pointc, pointd);


            // instanciation du  texte points de vie
            int largeurZoneTexte2 = 200;
            int hauteurZoneTexte2 = 25;
            Color couleurFond;
            couleurFond = Color.Black;
            Color couleurTexte;
            couleurTexte = Color.Cyan;
            Vector2 coinInferieurGauche2 = new Vector2(-260.0f, 210.0f);
            cptrBalle = new Texte(coinInferieurGauche2, largeurZoneTexte2, hauteurZoneTexte2);
            cptrBalle.setTexte(getTxtCompletBalle(texteBalle, nbBalle));
            cptrBalle.setCouleurFond(couleurFond);
            cptrBalle.setCouleurTexte(couleurTexte);

            // instanciation du  texte qte doritos, qte salsa
            int largeurZoneTexte3 = 180;
            int hauteurZoneTexte3 = 25;
            Vector2 coinInferieurGauche3 = new Vector2(-60.0f, 210.0f);
            cptrPoints = new Texte(coinInferieurGauche3, largeurZoneTexte3, hauteurZoneTexte3);
            cptrPoints.setTexte(getTxtCompletPoints(textePoints, nbPoints));
            cptrPoints.setCouleurFond(couleurFond);
            cptrPoints.setCouleurTexte(couleurTexte);

            // instanciation du  texte  qte salsa
            int largeurZoneTexte4 = 160;
            int hauteurZoneTexte4 = 25;
            Vector2 coinInferieurGauche4 = new Vector2(130.0f, 210.0f);
            cptrTableau = new Texte(coinInferieurGauche4, largeurZoneTexte4, hauteurZoneTexte4);
            cptrTableau.setTexte(getTxtCompletTableau(texteTableau, nbTableau));
            cptrTableau.setCouleurFond(couleurFond);
            cptrTableau.setCouleurTexte(couleurTexte);

        }

        private void update(object sender, EventArgs arg)
        {
            balle.update(); 
            detectionCollision();

            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Key.A) || keyboardState.IsKeyDown(Key.D) || keyboardState.IsKeyDown(Key.Right) || keyboardState.IsKeyDown(Key.Left) )
            {
                raquette.update();
                
            }



            if (balle.Fail)
            {
                balleHorsEcran();
            }

            //brique.update();
           
        }

        private void balleHorsEcran()
        {
            
            

           
        }

        #endregion //ConstructeurInitialisation

       

        #region GestionAffichage
        private void rendu(object sender, EventArgs arg)
        {
            
            GL.Clear(ClearBufferMask.ColorBufferBit);

            raquette.dessiner();
            balle.dessiner();
            foreach (Brique brique in TableauDebrique)
            {
                brique.dessiner();
            }
            cptrBalle.dessiner();
            cptrPoints.dessiner();
            cptrTableau.dessiner();

            window.SwapBuffers();

          
        }
        #endregion

        #region Action clavier

        private void Window_KeyPress(object sender, KeyboardKeyEventArgs e)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            
            if ((keyboardState.IsKeyDown(Key.A)) || (keyboardState.IsKeyDown(Key.Left)))  //? A est à gauche mais tu as écrit right // mon erreur 
            {
                raquette.Direction = false;
                Console.WriteLine(e.Key.ToString());
                //raquetteEnMvmt = true;
                
            }

            if ((keyboardState.IsKeyDown(Key.D)) || (keyboardState.IsKeyDown(Key.Right)))  //? D est à droit mais tu as écrit left
            {
                
                //raquetteEnMvmt = true;
                raquette.Direction = true;
                Console.WriteLine(e.Key.ToString());

            }

        }
        private void Window_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Key.Space))
            {
                balle.BalleLancee = true;
                Console.WriteLine("TEste lance balle");
                //jeuLance = true;
            }
        }

        #endregion clavier

        #region gestionCollisions
        private void detectionCollision()
        {
            Dictionary<CoteObjets, Vector2[]> listeDroitesBalle = balle.getDroitesCotes();
            Dictionary<CoteObjets, Vector2[]> listeDroitesRaquette = raquette.getDroitesCotes(); ;
            

            if(balle != null)
            {
                bool SiCollisionBalle = false;
                CoteObjets coteCollision = CoteObjets.NULL;

                foreach (KeyValuePair<CoteObjets, Vector2[]> droiteRaquette in listeDroitesRaquette)
                {
                    foreach (KeyValuePair<CoteObjets, Vector2[]> droiteBalle in listeDroitesBalle)
                    {
                        if (intersection(droiteRaquette.Value, droiteBalle.Value))
                        {
                            SiCollisionBalle = true;
                            coteCollision = droiteBalle.Key;
                        }
                    }
                }
                if (SiCollisionBalle)
                {
                    Console.WriteLine(" Il y  a eu collision sur le cote : " + coteCollision.ToString());
                    balle.changerDirectionRaquette();
                    
                }


            }

            //List<Brique> listeBriques = new List<Brique>(brique);
            //Dictionary<CoteObjets, Vector2[]> listeDroitesBriques;

            
            foreach (Brique brique in TableauDebrique)
            {
                Dictionary<CoteObjets, Vector2[]> listeDroitesBriques = brique.getDroitesCotes();
                bool siCollisionBalleBrique = false;

                foreach (KeyValuePair<CoteObjets, Vector2[]> droiteBalle in listeDroitesBalle)
                {
                 
                    foreach (KeyValuePair<CoteObjets, Vector2[]> droiteBriques in listeDroitesBriques)
                    {
                        if (intersection(droiteBalle.Value, droiteBriques.Value))
                        {
                            siCollisionBalleBrique = true;
                            balle.changerDirectionRaquette();
                            break;
                        }    
                    }    
                }
                if (siCollisionBalleBrique)
                {

                    //audio.jouerDestruct();
                    TableauDebrique.Remove(brique);
                    audio.jouerDestruct();
                    balle.inverserDirection();

                    break;


                }


            }

        }

        #region methodesWeb
        private bool intersection(Vector2[] droiteBalle, Vector2[] droiteRaquette)
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
            float a_Triangle = (droiteBalle[1].Y - droiteBalle[0].Y) / (droiteBalle[1].X - droiteBalle[0].X);
            float a_Carre = (droiteRaquette[1].Y - droiteRaquette[0].Y) / (droiteRaquette[1].X - droiteRaquette[0].X);

            // Calculer les valeur "b" pour chacune de deux droites
            float b_Triangle = droiteBalle[1].Y - a_Triangle * droiteBalle[1].X;
            float b_Carre = droiteRaquette[1].Y - a_Carre * droiteRaquette[1].X;

            // Calculer les valeurs "x" et "y" pour le point d'intersection des deux lignes
            float x = (b_Carre - b_Triangle) / (a_Triangle - a_Carre);
            float y = a_Triangle * x + b_Triangle;

            // **************
            // Début des test
            if (float.IsInfinity(a_Triangle) && float.IsInfinity(a_Carre))
            {
                // Si les deux valeurs "a" sont l'INFINI, alors on a deux droites verticales.
                // Si les deux droites partagent le même "x", alors on vérifie alors la valeur "y".
                siIntersection = (droiteBalle[0].X == droiteRaquette[0].X) && (
                                    (droiteRaquette[0].Y <= droiteBalle[0].Y && droiteBalle[0].Y <= droiteRaquette[1].Y)
                                    || (droiteRaquette[0].Y <= droiteBalle[1].Y && droiteBalle[1].Y <= droiteRaquette[1].Y)
                                    );
            }
            else if (float.IsInfinity(a_Triangle) && !float.IsInfinity(a_Carre))
            {
                // La droite de la balle EST vertical et celle de la raquette NE L'EST PAS
                x = droiteBalle[0].X;
                y = b_Carre * x + b_Carre;

                siIntersection = (
                    ((droiteBalle[0].Y <= droiteBalle[1].Y && LTE(droiteBalle[0].Y, y) && GTE(droiteBalle[1].Y, y)) || (droiteBalle[0].Y >= droiteBalle[1].Y && GTE(droiteBalle[0].Y, y) && LTE(droiteBalle[1].Y, y))) &&
                    ((droiteRaquette[0].X <= droiteRaquette[1].X && LTE(droiteRaquette[0].X, x) && GTE(droiteRaquette[1].X, x)) || (droiteRaquette[0].X >= droiteRaquette[1].X && GTE(droiteRaquette[0].X, x) && LTE(droiteRaquette[1].X, x))) &&
                    ((droiteRaquette[0].Y <= droiteRaquette[1].Y && LTE(droiteRaquette[0].Y, y) && GTE(droiteRaquette[1].Y, y)) || (droiteRaquette[0].Y >= droiteRaquette[1].Y && GTE(droiteRaquette[0].Y, y) && LTE(droiteRaquette[1].Y, y)))
                    );
            }
            else if (!float.IsInfinity(a_Triangle) && float.IsInfinity(a_Carre))
            {
                // La droite de la balle N'EST PAS vertical et celle de la raquette L'EST
                x = droiteRaquette[0].X;
                y = a_Triangle * x + b_Triangle;

                siIntersection = (
                    ((droiteBalle[0].X <= droiteBalle[1].X && LTE(droiteBalle[0].X, x) && GTE(droiteBalle[1].X, x)) || (droiteBalle[0].X >= droiteBalle[1].X && GTE(droiteBalle[0].X, x) && LTE(droiteBalle[1].X, x))) &&
                    ((droiteBalle[0].Y <= droiteBalle[1].Y && LTE(droiteBalle[0].Y, y) && GTE(droiteBalle[1].Y, y)) || (droiteBalle[0].Y >= droiteBalle[1].Y && GTE(droiteBalle[0].Y, y) && LTE(droiteBalle[1].Y, y))) &&
                    ((droiteRaquette[0].Y <= droiteRaquette[1].Y && LTE(droiteRaquette[0].Y, y) && GTE(droiteRaquette[1].Y, y)) || (droiteRaquette[0].Y >= droiteRaquette[1].Y && GTE(droiteRaquette[0].Y, y) && LTE(droiteRaquette[1].Y, y)))
                    );
            }

            // Finalement, vérifier si le point d'interception est à l'intérieur de tous les points
            if (!siIntersection)
            {
                siIntersection = (
                    ((droiteBalle[0].X <= droiteBalle[1].X && LTE(droiteBalle[0].X, x) && GTE(droiteBalle[1].X, x)) || (droiteBalle[0].X >= droiteBalle[1].X && GTE(droiteBalle[0].X, x) && LTE(droiteBalle[1].X, x))) &&
                    ((droiteBalle[0].Y <= droiteBalle[1].Y && LTE(droiteBalle[0].Y, y) && GTE(droiteBalle[1].Y, y)) || (droiteBalle[0].Y >= droiteBalle[1].Y && GTE(droiteBalle[0].Y, y) && LTE(droiteBalle[1].Y, y))) &&
                    ((droiteRaquette[0].X <= droiteRaquette[1].X && LTE(droiteRaquette[0].X, x) && GTE(droiteRaquette[1].X, x)) || (droiteRaquette[0].X >= droiteRaquette[1].X && GTE(droiteRaquette[0].X, x) && LTE(droiteRaquette[1].X, x))) &&
                    ((droiteRaquette[0].Y <= droiteRaquette[1].Y && LTE(droiteRaquette[0].Y, y) && GTE(droiteRaquette[1].Y, y)) || (droiteRaquette[0].Y >= droiteRaquette[1].Y && GTE(droiteRaquette[0].Y, y) && LTE(droiteRaquette[1].Y, y))));
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
