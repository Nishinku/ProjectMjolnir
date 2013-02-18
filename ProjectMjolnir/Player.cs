using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMjolnir
{
    class Player
    {
        SpriteBatch spriteBatch;
        Vector2 Position;
        Texture2D Skin;
        ContentManager Content;
        //Jumping
        bool Jumping;
        int JumpCache;
        int JumpHeight;
        int JumpHDefault = -10;

        //General Options
        int Weight = 5; //Speed of wich he falls
        int Speed = 5;
        
        public Player(SpriteBatch SPB,Vector2 Start_Pos,ContentManager Cont)
        {
            spriteBatch = SPB;
            Position = Start_Pos;
            Content = Cont;

            Skin = Content.Load<Texture2D>("Player1");
        }

        public void update()
        {
            //Basic Movement
            if (GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed) { Position.X -= Speed; }
            if (GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed) { Position.X += Speed; }
            if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed && !Jumping) { Jumping = true; JumpCache = (int)Position.Y; JumpHeight = JumpHDefault; }

            //Gravity Emulator NOTE THE STATIC FAKE GROUND
            if (Position.Y < 640 - 16 - Skin.Height && !Jumping) {
                Position.Y += Weight;
            } else if (Position.Y >= 640 + 16 && !Jumping) {
                Position.Y = ((int)Position.Y / 16) * 16;
            }

            //Jumping
            if (Jumping) {
                System.Diagnostics.Debug.WriteLine(JumpCache);
                Position.Y += JumpHeight;
                JumpHeight++;
                if (Position.Y >= JumpCache)
                {
                    Jumping = false;
                    Position.Y = ((int)Position.Y / 16) * 16;
                }
            }
        }

        public void Draw()
        {
            spriteBatch.Draw(Skin,Position,Color.White);
        }

    }
    
}
