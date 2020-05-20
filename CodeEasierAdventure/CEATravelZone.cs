using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeCraft;
using Microsoft.Xna.Framework.Graphics;
using CodeEasier.Scene;
using EscapeCraft.Datas;

namespace CodeEasierAdventure
{
    class CEATravelZone
    {

        public Rectangle Rect { get; set; }
        public string IdToGo { get; set; }
        public CETextElement Text { get; private set; }
        public string CursorPath { get; set; }
        public bool IsHovered { get; set; }
        public Main BaseGame { get; set; }

        private Texture2D cursorStep;

        public CEATravelZone(Rectangle rect, string idToGo, string text, SpriteFont font, Color color, string cursorPath, Main baseGame)
        {
            Rect = rect;
            IdToGo = idToGo;
            Text = new CETextElement(text, font, color, new Rectangle(0, 0, 0, 0));
            CursorPath = cursorPath;
            BaseGame = baseGame;

            cursorStep = BaseGame.Content.Load<Texture2D>(CursorPath);
        }

        public void Update(MouseState newMouseState, MouseState oldMouseState)
        {

            if (Rect.Contains(newMouseState.X, newMouseState.Y))
            {
                IsHovered = true;
                BaseGame.game.ShowSpecialCursor = true;
                BaseGame.game.CursorToShow = cursorStep;
                Text.Rect = new Rectangle(newMouseState.X, newMouseState.Y + 60, 200, 50);

                if (newMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
                {
                    BaseGame.game.Player.Level = IdToGo;
                    DataManager.WriteFile("player.json", BaseGame.game.Player);
                    BaseGame.game.ChangeScene(IdToGo);
                    BaseGame.game.ShowSpecialCursor = false;
                }
            }
            else
            {
                IsHovered = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Rect.Contains(Mouse.GetState().X, Mouse.GetState().Y))
            {

                Text.Draw(spriteBatch);

            }
        }

    }
}
