using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace JeuDeCasseBrique
{
    class Brique : BasePourObjets
    {

        #region Attributs
        //Rien a mettre ici
        public float incrementVertical = 1.5f;
        public float deplacementVertical = 0.0f;
        public float incrementHorizontale = 2.0f;
        public float deplacementHorizontale = 0.0f;
        int valDomage;
        #endregion //Attributs

        #region ConstructeurInitialisation

        public Brique(string nomTexture, Vector2 a, Vector2 b, Vector2 c, Vector2 d) : base(nomTexture, a, b, c, d)
        {
            
        }

        #endregion //ConstructeurInitialisation

        #region MethodesClasseParent
        override public void update()
        {

            if (deplacementVertical + incrementVertical >= 120.0f - listePoints[3].Y || deplacementVertical + incrementVertical <= -150.0f - listePoints[0].Y)
            {
                incrementVertical *= -1.0f;
            }
            deplacementVertical += incrementVertical;

            if (deplacementHorizontale + incrementHorizontale >= 300.0f - listePoints[2].X || deplacementHorizontale + incrementHorizontale <= -300.0f - listePoints[0].X)
            {
                incrementHorizontale *= -1.0f;
            }
            deplacementHorizontale += incrementHorizontale;
        }

        public int getDomage()
        {
            return valDomage;
        }

        public void dessiner()
        {
            GL.PushMatrix();

            GL.Translate(deplacementHorizontale, deplacementVertical, 0.0f);

            base.dessiner(PrimitiveType.Quads);

            GL.PopMatrix();
        }

        public void changerDirection(CoteObjets coteCollision)
        {
            incrementVertical *= -1.0f;
            incrementHorizontale *= -1.0f;
        }

        override public Dictionary<CoteObjets, Vector2[]> getDroitesCotes()
        {
            Dictionary<CoteObjets, Vector2[]> listeDroites = new Dictionary<CoteObjets, Vector2[]>();

            // Calculer les nouvelles positions des points, selon les valeurs de déplacement
            Vector2 reelPointA = new Vector2(listePoints[0].X + deplacementHorizontale, listePoints[0].Y + deplacementVertical);
            Vector2 reelPointB = new Vector2(listePoints[1].X + deplacementHorizontale, listePoints[1].Y + deplacementVertical);
            Vector2 reelPointC = new Vector2(listePoints[2].X + deplacementHorizontale, listePoints[2].Y + deplacementVertical);
            Vector2 reelPointD = new Vector2(listePoints[3].X + deplacementHorizontale, listePoints[3].Y + deplacementVertical);

            // Regarder ces points par pair pour créer des droites, puis les ajouter au Dictionary
            listeDroites[CoteObjets.SUD] = new Vector2[] { reelPointA, reelPointB };
            listeDroites[CoteObjets.EST] = new Vector2[] { reelPointB, reelPointC };
            listeDroites[CoteObjets.NORD] = new Vector2[] { reelPointC, reelPointD };
            listeDroites[CoteObjets.OUEST] = new Vector2[] { reelPointD, reelPointA };



            return listeDroites;
        }

        public Vector2[] getPointsReels()
        {
            Vector2[] pointsReels = new Vector2[4];


            // Calculer les nouvelles positions des points, selon les valeurs de déplacement
            Vector2 reelPointA = new Vector2(listePoints[0].X + deplacementHorizontale, listePoints[0].Y + deplacementVertical);
            Vector2 reelPointB = new Vector2(listePoints[1].X + deplacementHorizontale, listePoints[1].Y + deplacementVertical);
            Vector2 reelPointC = new Vector2(listePoints[2].X + deplacementHorizontale, listePoints[2].Y + deplacementVertical);
            Vector2 reelPointD = new Vector2(listePoints[3].X + deplacementHorizontale, listePoints[3].Y + deplacementVertical);

            pointsReels[0] = reelPointA;
            pointsReels[1] = reelPointB;
            pointsReels[2] = reelPointC;
            pointsReels[3] = reelPointD;


            return pointsReels;


        }

        public Vector2[][] getPointsPourPetitesCaisses()
        {
            Vector2[][] newPoints = new Vector2[4][];
            Vector2[] pointsReels = getPointsReels();
            float demieLongueur = (pointsReels[1].X - pointsReels[0].X) / 2f;

            newPoints[0] = new Vector2[4];
            newPoints[0][0] = new Vector2(pointsReels[0].X - 3, pointsReels[0].Y - 3);
            newPoints[0][1] = new Vector2(pointsReels[0].X - 3 + demieLongueur, pointsReels[0].Y - 3);
            newPoints[0][2] = new Vector2(pointsReels[0].X - 3 + demieLongueur, pointsReels[0].Y - 3 + demieLongueur);
            newPoints[0][3] = new Vector2(pointsReels[0].X - 3, pointsReels[0].Y - 3 + demieLongueur);

            newPoints[1] = new Vector2[4];
            newPoints[1][0] = new Vector2(pointsReels[1].X + 3 - demieLongueur, pointsReels[1].Y - 3);
            newPoints[1][1] = new Vector2(pointsReels[1].X + 3, pointsReels[1].Y - 3);
            newPoints[1][2] = new Vector2(pointsReels[1].X + 3, pointsReels[1].Y - 3 + demieLongueur);
            newPoints[1][3] = new Vector2(pointsReels[1].X + 3 - demieLongueur, pointsReels[1].Y - 3 + demieLongueur);

            newPoints[2] = new Vector2[4];
            newPoints[2][0] = new Vector2(pointsReels[2].X + 3 - demieLongueur, pointsReels[2].Y + 3 - demieLongueur);
            newPoints[2][1] = new Vector2(pointsReels[2].X + 3, pointsReels[2].Y + 3 - demieLongueur);
            newPoints[2][2] = new Vector2(pointsReels[2].X + 3, pointsReels[2].Y + 3);
            newPoints[2][3] = new Vector2(pointsReels[2].X + 3 - demieLongueur, pointsReels[2].Y + 3);

            newPoints[3] = new Vector2[4];
            newPoints[3][0] = new Vector2(pointsReels[3].X - 3, pointsReels[3].Y + 3 - demieLongueur);
            newPoints[3][1] = new Vector2(pointsReels[3].X - 3 + demieLongueur, pointsReels[3].Y + 3 - demieLongueur);
            newPoints[3][2] = new Vector2(pointsReels[3].X - 3 + demieLongueur, pointsReels[3].Y + 3);
            newPoints[3][3] = new Vector2(pointsReels[3].X - 3, pointsReels[3].Y + 3);

            return newPoints;

        }

    }
}
