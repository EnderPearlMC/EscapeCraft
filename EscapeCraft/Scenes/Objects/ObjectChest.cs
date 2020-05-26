using CodeEasier.Scene;
using CodeEasierAdventure;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeCraft.Scenes.Objects
{
    class ObjectChest : ICEASceneObject
    {

        public CEImageElement Image { get; set; }
        public Texture2D TNormal { get; set; }
        public Texture2D TOpen { get; set; }
        public Main BaseGame { get; set; }

        public bool IsOpen { get; set; }

        public MouseState oldMouseState;

        public ObjectChest(Texture2D normal, Texture2D open, Main baseGame)
        {
            TNormal = normal;
            TOpen = open;
            Image = new CEImageElement(TNormal, new Rectangle(0, 0, 0, 0));
            BaseGame = baseGame;
        }

        public void Load()
        {
            oldMouseState = Mouse.GetState();
        }

        public void Update(GameTime gameTime)
        {
            MouseState newMousteState = Mouse.GetState();

            if (!IsOpen)
            {
                Image.Texture = TNormal;
            }
            else
            {
                Image.Texture = TOpen;
            }

            if (Image.Rect.Contains(newMousteState.Position))
            {
                BaseGame.game.ShowSpecialCursor = true;
                BaseGame.game.CursorToShow = Assets.HandCursor;
                if (newMousteState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
                {
                    IsOpen = true;
                }
            }

            oldMouseState = newMousteState;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Image.Draw(spriteBatch);
        }

    }
}
