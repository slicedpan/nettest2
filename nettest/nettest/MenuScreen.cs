using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace nettest
{
    public class MenuScreen : TestScreen
    {
        Window window;
        public MenuScreen()
        {
            window = new Window();
            window.SetSize(400, 400);
            window.SetPosition(250, 250);
        }
        public override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(renderTarget);
            GraphicsDevice.Clear(Color.Black);
            SpriteBatch.Begin();
            window.Draw(SpriteBatch);
            SpriteBatch.End();
            base.Draw(gameTime);
        }
        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager Content)
        {
            window.LoadContent(Content);
            base.LoadContent(Content);
        }
    }
}
