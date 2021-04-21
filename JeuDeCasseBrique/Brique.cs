using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

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

        public Brique(string nomTexture, Vector2 a, Vector2 b, Vector2 c, Vector2 d) : base(nomTexture, a, b, c, d)
        {
            
        }


    }
}
