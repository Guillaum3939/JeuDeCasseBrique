using OpenTK;
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
       
        #endregion //Attributs

        #region ConstructeurInitialisation
        public Raquette(Vector2 pointE, Vector2 pointF, Vector2 pointG, Vector2 pointH)
            : base("./images/CaisseBoisBMP.bmp", pointE, pointF, pointG, pointH)
        {

        }
        #endregion //ConstructeurInitialisation
        public override void update()
        {
            throw new NotImplementedException();
        }

        public void dessiner()
        {
            GL.PushMatrix();
            
            base.dessiner(PrimitiveType.Quads);

            GL.PopMatrix();
        }

        
    }
}
