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

        public Brique(string nomTexture, Vector2 a, Vector2 b, Vector2 c, Vector2 d) : base("./images/CaisseBoisBMP.bmp", a, b, c, d)
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

            base.dessiner(PrimitiveType.Quads);

            GL.PopMatrix();
        }

        #endregion

    }
}
