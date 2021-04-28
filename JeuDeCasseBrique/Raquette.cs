﻿using OpenTK;
using OpenTK.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using System.Drawing.Imaging;
using System.Drawing;

namespace JeuDeCasseBrique
{
    class Raquette : BasePourObjets
    {
        #region Attributs
        bool direction;

        public bool Direction { get => direction; set => direction = value; }

        #endregion //Attributs

        #region ConstructeurInitialisation
        public Raquette(Vector2 pointE, Vector2 pointF, Vector2 pointG, Vector2 pointH)
            : base("images/CaisseBoisBMP.bmp", pointE, pointF, pointG, pointH)
        {
            deplacementHorizontal = 0;
            incrementHorizontal = 2.0f;
            direction = false;
        }
        #endregion //ConstructeurInitialisation
        public override void update()
        {
            if (direction == false)
            {
                if (deplacementHorizontal + incrementHorizontal <= -250.0f - listePoints[3].X)
                {
                    incrementHorizontal = 0.0f;//stop a la bordure
                }
                else
                    incrementHorizontal = -2.0f;

            }
            else
            {
                if (deplacementHorizontal + incrementHorizontal >= 250.0f - listePoints[0].X)
                {
                    incrementHorizontal = 0.0f;//stop a la bordure

                }
                else
                    incrementHorizontal = 2.0f;
            }

            deplacementHorizontal += incrementHorizontal;
        }

        public void dessiner()
        {
            GL.PushMatrix();

            GL.Translate(deplacementHorizontal, 0.0f, 0.0f);
            base.dessiner(PrimitiveType.Quads);

            GL.PopMatrix();
        }

        /*public override Dictionary<CoteObjets, Vector2[]> getDroitesCotes()
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
        */

    }
}
