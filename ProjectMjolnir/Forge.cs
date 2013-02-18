using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMjolnir
{
    class Forge
    {
        //arbitery must haves
        ContentManager Content;
        SpriteBatch spriteBatch;
        Box[,] _Box;
        Texture2D[] Skin;
        string[] SkinName;

        //Options
        /*Size of each Box*/
        int GridSizeX = 16;
        int GridSizeY = 16;
        /*Ammount of Fields on Screen*/
        int FieldsX = 60;
        int FieldsY = 40;

        public Forge(ContentManager content, SpriteBatch SPB)
        {
            Content = content;
            spriteBatch = SPB;
            _Box = new Box[FieldsX,FieldsY];
            Skin = new Texture2D[2];
            SkinName = new string[2];

            //Skin Management
            /*Set names of skins*/
            SkinName[0] = "Void";
            SkinName[1] = "Grass_01";
            /*Loop Through Skins and Load them as Textures*/
            for (int i = 0; i < Skin.Length;i ++ )
            {
                Skin[i] = Content.Load<Texture2D>("Box/" + SkinName[i]);
            }

            //Initiate Boxes

            /*Loops Y Rows*/
            for (int y = 0; y < FieldsY; y++)
            {
                /*Creates X Rows*/
                for (int i = 0; i < FieldsX; i++)
                {
                    _Box[i, y] = new Box(new Vector2(i * GridSizeX, y * GridSizeY), spriteBatch, Skin[0]);
                }
            }
    
            //Creates Grass line for testing purposes
            for (int i = 0; i < FieldsX;i++)
            {
                _Box[i, FieldsY - 1].AssignSkin(Skin[1]);
            }
        }

        public void Draw()
        {
            //Draw Boxes
            /*Loops Y Rows*/
            for (int y = 0; y < FieldsY; y++)
            {
                /*Creates X Rows*/
                for (int i = 0; i < FieldsX; i++)
                {
                    _Box[i, y].Draw();
                }
            }
        }
    }
}
