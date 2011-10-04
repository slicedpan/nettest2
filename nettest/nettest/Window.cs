using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace nettest
{
    public class Window
    {
        int _width, _height, _x, _y;
        Rectangle left, right, bottom, top, bg, tlcorner, brcorner, trcorner, blcorner;
        Texture2D borderBottom, borderTop, cornerBottom, cornerTop, borderLeft, background;
        public Window()
        {
            _width = 100;
            _height = 100;
            _x = 100;
            _y = 100;
            CalculateBorderPositions();
        }
        public void LoadContent(ContentManager Content)
        {
            borderBottom = Content.Load<Texture2D>("window/borderbot");
            borderTop = Content.Load<Texture2D>("window/bordertop");
            borderLeft = Content.Load<Texture2D>("window/borderleft");
            cornerBottom = Content.Load<Texture2D>("window/cornerbot");
            cornerTop = Content.Load<Texture2D>("window/cornertop");
            background = Content.Load<Texture2D>("window/bg");
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(background, bg, Color.White);
            sb.Draw(borderBottom, bottom, Color.White);
            sb.Draw(borderTop, top, Color.White);
            sb.Draw(borderLeft, left, Color.White);
            sb.Draw(borderLeft, right, Color.White);
            sb.Draw(cornerBottom, blcorner, Color.White);
            sb.Draw(cornerTop, tlcorner, Color.White);
            sb.Draw(cornerBottom, brcorner, null, Color.White, 0.0f, Vector2.Zero, SpriteEffects.FlipHorizontally, 0.0f);
            sb.Draw(cornerTop, trcorner, null, Color.White, 0.0f, Vector2.Zero, SpriteEffects.FlipHorizontally, 0.0f);
        }
        public void SetPosition(int x, int y)
        {
            _x = x;
            _y = y;
            CalculateBorderPositions();
        }
        public void SetSize(int width, int height)
        {
            _width = width;
            _height = height;
            CalculateBorderPositions();
        }
        void CalculateBorderPositions()
        {
            int halfHeight = _height / 2;
            int halfWidth = _width / 2;

            left.Height = _height - 12;
            left.Width = 6;
            left.X = _x - halfWidth;
            left.Y = _y - halfHeight + 6;

            right.Height = _height - 12;
            right.Width = 6;
            right.X = _x + halfWidth - 6;
            right.Y = _y - halfHeight + 6;

            top.Height = 6;
            top.Width = _width - 12;
            top.X = _x - halfWidth + 6;
            top.Y = _y - halfHeight;

            bottom.Height = 6;
            bottom.Width = _width - 12;
            bottom.X = _x - halfWidth + 6;
            bottom.Y = _y + halfHeight - 6;

            tlcorner.Height = 6;
            tlcorner.Width = 6;
            tlcorner.X = _x - halfWidth;
            tlcorner.Y = _y - halfHeight;

            trcorner.Height = 6;
            trcorner.Width = 6;
            trcorner.X = _x + halfWidth - 6;
            trcorner.Y = _y - halfHeight;

            blcorner.Height = 6;
            blcorner.Width = 6;
            blcorner.X = _x - halfWidth;
            blcorner.Y = _y + halfHeight - 6;

            brcorner.Height = 6;
            brcorner.Width = 6;
            brcorner.X = _x + halfWidth - 6;
            brcorner.Y = _y + halfHeight - 6;

            bg.Height = _height - 12;
            bg.Width = _width - 12;
            bg.X = _x - halfWidth + 6;
            bg.Y = _y - halfHeight + 6;

        }
    }
}
