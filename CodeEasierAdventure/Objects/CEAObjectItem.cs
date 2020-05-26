using CodeEasier.Scene;
using CodeEasierAdventure.Inventory;
using EscapeCraft;
using EscapeCraft.Datas;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEasierAdventure.Objects
{

    class CEAObjectItem : ICEASceneObject
    {

        public string Id { get; set; }
        public CEImageElement Image { get; set; }
        public int AmountToGet { get; set; }
        public CEAInventory Inventory { get; set; }
        public Main BaseGame { get; set; }

        public bool IsVisible { get; set; }
        public bool IsTaken { get; set; }

        public MouseState oldMouseState;

        public CEAObjectItem(string id, Texture2D texture, int amountToGet, CEAInventory inventory, Main baseGame)
        {
            Id = id;
            IsVisible = true;
            Image = new CEImageElement(texture, new Rectangle(0, 0, 0, 0));
            AmountToGet = amountToGet;
            Inventory = inventory;
            BaseGame = baseGame;
        }

        public void Load()
        {
            oldMouseState = Mouse.GetState();
        }

        public void Update(GameTime gameTime)
        {
            if (IsTaken)
            {
                IsVisible = false;
            }
            if (IsVisible)
            {
                MouseState newMousteState = Mouse.GetState();

                if (Image.Rect.Contains(newMousteState.Position))
                {
                    BaseGame.game.ShowSpecialCursor = true;
                    BaseGame.game.CursorToShow = Assets.HandCursor;
                    if (newMousteState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
                    {
                        IsTaken = true;
                        Inventory.Items.Add(BaseGame.game.FindItemWithId(Id), AmountToGet);
                        BaseGame.game.Player.Inventory.Add(Id, AmountToGet);
                        DataManager.WriteFile("player.json", BaseGame.game.Player);
                    }
                }

                oldMouseState = newMousteState;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsVisible)
            {
                Image.Draw(spriteBatch);
            }
        }

    }

}
