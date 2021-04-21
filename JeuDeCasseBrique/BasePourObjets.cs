using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using OpenTK;

namespace JeuDeCasseBrique
{
    class BasePourObjets
    {
        #region Attributs
        protected Vector2[] listePoints;
        protected Vector2[] coordonneesTextures;
        protected int textureID;
        protected string nomTexture;
        #endregion //Attributs

        public BasePourObjets(string nomTexture, Vector2 a, Vector2 b, Vector2 c, Vector2 d)
        {
            this.listePoints = new Vector2[4];
            this.listePoints[0] = a;
            this.listePoints[1] = b;
            this.listePoints[2] = c;
            this.listePoints[3] = d;
            setCoordonneeTextureBrique();
            init(nomTexture);
        }



    }
}
