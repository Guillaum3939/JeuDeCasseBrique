using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;
using OpenTK.Graphics.OpenGL;
using System.Drawing.Imaging;
using OpenTK;

namespace JeuDeCasseBrique
{
    abstract class BasePourObjets
    {
        #region Attributs
        protected Vector2[] listePoints;
        protected Vector2[] coordonneesTextures;
        protected int textureID;
        protected string nomTexture;
        protected float deplacementHorizontal, deplacementVertical, incrementHorizontal, incrementVertical;
        #endregion //Attributs

        #region ConstructeurInitialisation
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

        private void init(string nomTexture)
        {
            this.nomTexture = nomTexture;
            chargerTexture();
        }


        #endregion //Constructeur & Initialisation

        #region Gestion Texture
        private void chargerTexture()
        {
            GL.GenTextures(1, out textureID);
            GL.BindTexture(TextureTarget.Texture2D, textureID);
            BitmapData textureData = chargerImage();
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, textureData.Width, textureData.Height, 0,
                                        OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, textureData.Scan0);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
        }

        private BitmapData chargerImage()
        {
            Bitmap bmpImage = new Bitmap(nomTexture);
            Rectangle rectangle = new Rectangle(0, 0, bmpImage.Width, bmpImage.Height);
            BitmapData bmpData = bmpImage.LockBits(rectangle, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            bmpImage.UnlockBits(bmpData);
            return bmpData;
        }


        public void setCoordonneeTextureBrique()
        {
            coordonneesTextures = new Vector2[4];
            coordonneesTextures[0] = new Vector2(0.0f, 1.0f);
            coordonneesTextures[1] = new Vector2(1.0f, 1.0f);
            coordonneesTextures[2] = new Vector2(1.0f, 0.0f);
            coordonneesTextures[3] = new Vector2(0.0f, 0.0f);
        }

        #endregion //Gestion Texture

        #region Methode

        abstract public void update();

        //abstract public Dictionary<CoteObjets, Vector2[]> getDroitesCotes();

        public void dessiner(PrimitiveType typeDessin)
        {
            GL.BindTexture(TextureTarget.Texture2D, textureID);
            GL.Begin(typeDessin);
            for (int i = 0; i < listePoints.Length; i++)
            {
                GL.TexCoord2(coordonneesTextures[i]);
                GL.Vertex2(listePoints[i].X, listePoints[i].Y);

            }
            GL.End();
        }

        #endregion // methode
    }
}
