using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace JeuDeCasseBrique
{
    class Balle : BasePourObjets
    {
        #region Attributs
        float deplacementVertical;
        float deplacementHorizontal;
        float incrementVertical;
        float incrementHorizontal;

        bool direction;
        public bool Direction { get => direction; set => direction = value; }
        
        #endregion // Attributs;

        #region ConstructeurInitialisation
        public Balle(Vector2 pointA, Vector2 pointB, Vector2 pointC, Vector2 pointD) 
            : base("./images/CaisseBoisBMP.bmp", pointA, pointB, pointC, pointD)
        {
            this.deplacementVertical = 0.0f;
            this.deplacementHorizontal = 0.0f;

            this.incrementVertical = 2.0f;
            this.incrementHorizontal = 2.0f;
            //Carre2D(int dommage, Vector2 a, Vector2 b, Vector2 c, Vector2 d)
        }
        #endregion // ConstructeurInitialisation

        #region MethodesClasseParent
        public void update()
        {
            if (deplacementVertical + incrementVertical >= 245.0f - listePoints[3].Y || deplacementVertical + incrementVertical <= -300.0f - listePoints[0].Y)
            {
                incrementVertical *= -1.0f;
            }
            deplacementVertical += incrementVertical;

            if (deplacementHorizontal + incrementHorizontal >= 345.0f - listePoints[2].X || deplacementHorizontal + incrementHorizontal <= -345.0f - listePoints[0].X)
            {
                incrementHorizontal *= -1.0f;
            }
            deplacementHorizontal += incrementHorizontal;
        }
        public void dessiner()
        {
            GL.PushMatrix();
            GL.Translate(deplacementHorizontal, deplacementVertical, 0.0f);
            base.dessiner(PrimitiveType.Quads);
            GL.PopMatrix();
        }
        public void inverserDirection()
        {
            incrementVertical *= -1.0f;
            incrementHorizontal *= -1.0f;
        }

        public void changerDirectionRaquette()
        {
            incrementVertical *= -1.0f;
            if (direction && incrementHorizontal > 0)
            {
                incrementHorizontal += 1.0f;
            }
            else if (!direction && incrementHorizontal < 0)
            {
                incrementHorizontal -= 1.0f;
            }
            else if (direction && incrementHorizontal < 0)
            {
                incrementHorizontal -= 1.0f;
            }
            else if (!direction && incrementHorizontal > 0)
            {
                incrementHorizontal += 1.0f;
            }
        }

        #endregion // MethodesClasseParent


        #region Collisions 
        override public Dictionary<CoteObjets, Vector2[]> getDroitesCotes()
        {
            Dictionary<CoteObjets, Vector2[]> listeDroites = new Dictionary<CoteObjets, Vector2[]>();

            //Calculer les nouvelles positions des points, selon valeur de deplacement 
            Vector2 reelPointA = new Vector2(listePoints[0].X + deplacementHorizontal, listePoints[0].Y + deplacementVertical);
            Vector2 reelPointB = new Vector2(listePoints[1].X + deplacementHorizontal, listePoints[1].Y + deplacementVertical);
            Vector2 reelPointC = new Vector2(listePoints[2].X + deplacementHorizontal, listePoints[2].Y + deplacementVertical);
            Vector2 reelPointD = new Vector2(listePoints[3].X + deplacementHorizontal, listePoints[3].Y + deplacementVertical);

            //Regrouper ces points par pair pour créer des droites, puis les ajouter au dictionary
            listeDroites[CoteObjets.SUD] = new Vector2[] { reelPointA, reelPointB };
            listeDroites[CoteObjets.EST] = new Vector2[] { reelPointB, reelPointC };
            listeDroites[CoteObjets.NORD] = new Vector2[] { reelPointC, reelPointD };
            listeDroites[CoteObjets.OUEST] = new Vector2[] { reelPointD, reelPointA };

            return listeDroites;
            
        }

        #endregion
       
    }
}
