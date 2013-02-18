using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ProjectMjolnir
{
    public class Game1 : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        KeyboardState KS;
        Player Player1;
        Texture2D Line;
        Forge _Forge;

        public void Echo(string Text)
        {
            System.Diagnostics.Debug.WriteLine(Text);
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Echo("Test");
        }

        protected override void Initialize()
        {
            base.Initialize();
        }


        protected override void LoadContent()
        {

            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Player1 = new Player(_spriteBatch,new Vector2(100,100),Content);
            _Forge = new Forge(Content,_spriteBatch);
            Line = Content.Load<Texture2D>("Line");
        }

        protected override void UnloadContent()
        {
           
        }

        protected override void Update(GameTime gameTime)
        {

            if(GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) {
                this.Exit();
            }

            //Player1.update(GamePad.GetState(PlayerIndex.One);
            Player1.update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(Line,new Vector2(0,400),Color.White);

            _Forge.Draw();
            Player1.Draw();

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
