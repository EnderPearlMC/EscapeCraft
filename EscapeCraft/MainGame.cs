using CodeEasier.GameSystems;
using CodeEasier.Window;
using EscapeCraft.Scenes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeCraft.Datas;
using CodeEasierAdventure.Inventory;
using Microsoft.Xna.Framework;
using CodeEasierAdventure.Objects;
using EscapeCraft.Scenes.Items;

namespace EscapeCraft
{
    class MainGame : CEGame
    {

        public Player Player { get; set; }
        public CEAInventory Inventory { get; set; }

        public MainGame(Main main) : base(main, "Escape Craft (2020 All rights reserved) By EnderPearl MC", new CEWindowMode(CEWindowMode.Mode.Resizable, 1280, 720, 1920, 1080))
        {

        }

        public override void Load()
        {

            // Inventory
            Inventory = new CEAInventory(8, Assets.InventoryCase, Assets.SelectedInventoryCase, BaseGame);

            // Add scenes
            AddScene(new SceneCage1(BaseGame));
            AddScene(new SceneCage2(BaseGame));
            AddScene(new SceneCage3(BaseGame));
            AddScene(new SceneCage4(BaseGame));

            AddScene(new SceneHall1(BaseGame));

            // File

            if (!File.Exists(Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), References.DATAS_FOLDER), "player.json")))
            {
                Player = new Player();
                DataManager.WriteFile("player.json", Player);
            }
            else
            {
                Player = DataManager.ReadFile<Player>("player.json");
            }

            foreach (KeyValuePair<string, int> item in Player.Inventory)
            {
                Inventory.Items.Add(FindItemWithId(item.Key), item.Value);
            }

            ChangeScene(Player.Level, Player.ScenesState[Player.Level]);

            base.Load();
        }

        public override void Update(GameTime gameTime)
        {

            Inventory.Position = new Vector2(ScreenWidth / 2 - (Inventory.NbrCases * Inventory.WidthCases / 2), ScreenHeight - Inventory.HeightCases);
            Inventory.WidthCases = ScreenWidth / 19;
            Inventory.HeightCases = ScreenHeight / 13;
            Inventory.Update();

            base.Update(gameTime);
        }

        public override void Draw()
        {
            base.Draw();

            Inventory.Draw(BaseGame.spriteBatch);

        }

        public CEAInventoryItem FindItemWithId(string id)
        {

            CEAInventoryItem item = null;

            switch (id)
            {
                case "book_1":
                    item = new ItemBook1();
                    break;

                case "gold_block":
                    item = new ItemGoldBlock();
                    break;

                default:
                    break;
            }

            return item;

        }

    }

}
