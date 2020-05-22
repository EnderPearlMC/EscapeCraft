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
        public Main BaseGame { get; set; }

        public bool IsOpen { get; set; }

        public MouseState oldMouseState;

        public ObjectChest(Main baseGame)
        {
            Image = new CEImageElement(Assets.Chest1, new Rectangle(0, 0, 0, 0));
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
                Image.Texture = Assets.Chest1;
            }
            else
            {
                Image.Texture = Assets.Chest1Open;
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
