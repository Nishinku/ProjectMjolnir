using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMjolnir
{
    class Box
    {
        Vector2 Position;
        SpriteBatch spriteBatch;
        Texture2D Skin;

        public Box(Vector2 position,SpriteBatch SPB,Texture2D skin)
        {
            Position = position;
            spriteBatch = SPB;
            Skin = skin;
        }

        public void AssignSkin(Texture2D NewSkin)
        {
            Skin = NewSkin;
        }

        public void Draw()
        {
            spriteBatch.Draw(Skin,Position,Color.White);
        }

    }
}
