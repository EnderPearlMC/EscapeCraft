using CodeEasier.Scene;
using CodeEasierAdventure.Objects;
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

namespace CodeEasierAdventure.Inventory
{
    class CEAInventory
    {

        public int NbrCases { get; set; }
        public Vector2 Position { get; set; }
        public int WidthCases { get; set; }
        public int HeightCases { get; set; }
        public Texture2D TextureCases { get; set; }
        public Texture2D TextureSelectedCase { get; set; }
        public Dictionary<CEAInventoryItem, int> Items { get; set; }
        public Main BaseGame { get; set; }

        public int SelectedBlock { get; set; }
        public bool IsHovered { get; set; }

        private MouseState oldMouseState;

        public CEAInventory(int nbrCases, Texture2D textureCases, Texture2D textureSelectedCase, Main baseGame)
        {
            NbrCases = nbrCases;
            TextureCases = textureCases;
            TextureSelectedCase = textureSelectedCase;
            BaseGame = baseGame;

            Items = new Dictionary<CEAInventoryItem, int>();

            SelectedBlock = 0;

        }

        public void Update()
        {

            MouseState newMouseState = Mouse.GetState();

            if (new Rectangle((int) Position.X, (int) Position.Y, WidthCases * NbrCases, HeightCases).Contains(newMouseState.Position))
            {
                IsHovered = true;
            }
            else
            {
                IsHovered = false;
            }

            int i = 0;
            // Update items
            foreach (KeyValuePair<CEAInventoryItem, int> item in Items)
            {
                if (item.Key != null)

                    item.Key.Image.Rect = new Rectangle((int)Math.Round(i * WidthCases + Position.X + WidthCases / 14), (int)Position.Y + HeightCases / 8, (int) Math.Round(WidthCases / 1.1), (int)Math.Round(HeightCases / 1.2));
                i++;
            }

            // select block with mouse wheel
            if (newMouseState.ScrollWheelValue > oldMouseState.ScrollWheelValue)
            {
                SelectedBlock++;
                if (SelectedBlock >= NbrCases)
                {
                    SelectedBlock = 0;
                }
            }
            if (newMouseState.ScrollWheelValue < oldMouseState.ScrollWheelValue)
            {
                SelectedBlock--;
                if (SelectedBlock < 0)
                {
                    SelectedBlock = NbrCases - 1;
                }
            }

            // verify if a item has the amount of 0
            for (int j = 0; j < Items.Count; j++)
            {
                if (Items[Items.ElementAt(j).Key] <= 0)
                {
                    // modifier la key de "Items"
                    Items.Remove(Items.ElementAt(j).Key);
                    BaseGame.game.Player.Inventory.Remove(BaseGame.game.Player.Inventory.ElementAt(j).Key);
                    DataManager.WriteFile("player.json", BaseGame.game.Player);
                }
            }

            oldMouseState = newMouseState;

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            // Draw cases
            for (int i = 0; i < NbrCases; i++)
            {

                if (SelectedBlock == i)
                {
                    spriteBatch.Draw(TextureSelectedCase, new Rectangle((int)Math.Round(i * WidthCases + Position.X), (int)Position.Y, WidthCases, HeightCases), Color.White);
                }
                else
                {
                    spriteBatch.Draw(TextureCases, new Rectangle((int)Math.Round(i * WidthCases + Position.X), (int)Position.Y, WidthCases, HeightCases), Color.White);
                }
            }

            // Draw items
            foreach (KeyValuePair<CEAInventoryItem, int> item in Items)
            {
                if (item.Key != null)
                {
                    item.Key.Image.Draw(spriteBatch);
                    CETextElement amountText = new CETextElement(item.Value + "", Assets.MainFont, Color.White, new Rectangle(item.Key.Image.Rect.X + item.Key.Image.Rect.Width / 2, item.Key.Image.Rect.Y + item.Key.Image.Rect.Height / 2, (int) Math.Round(item.Key.Image.Rect.Width / 2.5), (int) Math.Round(item.Key.Image.Rect.Height / 2.3)));
                    amountText.Draw(spriteBatch);
                }
            }
        }

        public void AddItem(string itemId, int amount)
        {
            if (BaseGame.game.Player.Inventory.ContainsKey(itemId))
            {
                Items[Items.Where(z => z.Key.Id == itemId).FirstOrDefault().Key] += amount;
                BaseGame.game.Player.Inventory[itemId] += amount;
            }
            else
            {
                Items.Add(BaseGame.game.FindItemWithId(itemId), amount);
                BaseGame.game.Player.Inventory.Add(itemId, amount);
            }
            DataManager.WriteFile("player.json", BaseGame.game.Player);
        }

        public void RemoveItem(CEAInventoryItem item, int amount)
        {
            Items[item] -= amount;
            BaseGame.game.Player.Inventory[item.Id] -= amount;
            DataManager.WriteFile("player.json", BaseGame.game.Player);
        }

    }
}
