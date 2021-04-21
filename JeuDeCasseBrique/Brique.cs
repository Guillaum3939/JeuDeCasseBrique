using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing.Imaging;
using System.Drawing;
using System.Threading.Tasks;
using System.Drawing.Imaging;

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
        #endregion //Attributs

        #region ConstructeurInitialisation

        public Brique(string nomTexture, Vector2 a, Vector2 b, Vector2 c, Vector2 d) : base(nomTexture, a, b, c, d)
        {
            
        }

        #endregion //ConstructeurInitialisation

        #region MethodesClasseParent
        override public void update()
        {

          
        }

       

        public void dessiner()
        {
            GL.PushMatrix();

            GL.Translate(deplacementHorizontale, deplacementVertical, 0.0f);

            base.dessiner(PrimitiveType.Quads);

            GL.PopMatrix();
        }

       

       

      

        #endregion // MethodesClasseParent

    }
}


