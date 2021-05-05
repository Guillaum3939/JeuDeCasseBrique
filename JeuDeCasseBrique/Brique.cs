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
        #endregion //Attributs

        #region ConstructeurInitialisation

        public Brique(string nomTexture, Vector2 a, Vector2 b, Vector2 c, Vector2 d) 
            : base("./images/CaisseBoisBMP.bmp", a, b, c, d)
        {
            
        }

        #endregion //ConstructeurInitialisation

        #region MethodesClasseParent
        public void update()
        {

        }


        public void dessiner()
        {
            GL.PushMatrix();
            GL.Translate(deplacementHorizontal, 0.0f, 0.0f);
            base.dessiner(PrimitiveType.Quads);

            GL.PopMatrix();
        }

        #endregion
        #region Collisions 
        public override Dictionary<CoteObjets, Vector2[]> getDroitesCotes()
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
