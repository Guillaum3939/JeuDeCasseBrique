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
        #endregion // Attributs;

        #region ConstructeurInitialisation
        public Balle(Vector2 pointA, Vector2 pointB, Vector2 pointC, Vector2 pointD) : base(".....", pointA, pointB, pointC, pointD)
        {
            this.deplacementVertical = 0.0f;
            this.deplacementHorizontal = 0.0f;
            this.incrementVertical = 0.0f;
            this.incrementHorizontal = 0.0f;
            //Carre2D(int dommage, Vector2 a, Vector2 b, Vector2 c, Vector2 d)
        }
        #endregion // ConstructeurInitialisation

        #region MethodesClasseParent
        override public void update()
        {
            if (deplacementVertical + incrementVertical >= 120.0f - listePoints[3].Y || deplacementVertical + incrementVertical <= -150.0f - listePoints[0].Y)
            {
                incrementVertical *= -1.0f;
            }
            deplacementVertical += incrementVertical;

            if (deplacementHorizontal + incrementHorizontal >= 300.0f - listePoints[2].X || deplacementHorizontal + incrementHorizontal <= -300.0f - listePoints[0].X)
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
        override public Dictionary<CoteObjets, Vector2[]> getDroitesCotes()
        {
            Dictionary<CoteObjets, Vector2[]> listeDroites = new Dictionary<CoteObjets, Vector2[]>();

            Vector2 reelPointA = new Vector2(listePoints[0].X + deplacementHorizontal, listePoints[0].Y + deplacementVertical);
            Vector2 reelPointB = new Vector2(listePoints[1].X + deplacementHorizontal, listePoints[1].Y + deplacementVertical);
            Vector2 reelPointC = new Vector2(listePoints[2].X + deplacementHorizontal, listePoints[2].Y + deplacementVertical);
            Vector2 reelPointD = new Vector2(listePoints[3].X + deplacementHorizontal, listePoints[3].Y + deplacementVertical);

            listeDroites[CoteObjets.SUD] = new Vector2[] { reelPointA, reelPointB };
            listeDroites[CoteObjets.EST] = new Vector2[] { reelPointB, reelPointC };
            listeDroites[CoteObjets.NORD] = new Vector2[] { reelPointC, reelPointD };
            listeDroites[CoteObjets.OUEST] = new Vector2[] { reelPointD, reelPointA };

            return listeDroites;
        }
        public void inverserDirection()
        {
            incrementVertical *= -1.0f;
            incrementHorizontal *= -1.0f;
        }
        #endregion // MethodesClasseParent
    }
}
