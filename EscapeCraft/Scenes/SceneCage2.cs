using CodeEasier.Scene;
using CodeEasierAdventure;
using CodeEasierAdventure.Objects;
using EscapeCraft.Scenes.Objects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeCraft.Scenes
{
    class SceneCage2 : CEScene
    {

        CEASceneFileInterpreter fileScene;

        // objects
        ObjectChest chest;
        CEAObjectItem itemBook;

        ObjectChest crate;
        CEAObjectItem itemGoldBlocks;

        public SceneCage2(Main main) : base("cage_2", main)
        {
            fileScene = new CEASceneFileInterpreter(Path.Combine(References.SCENES_FOLDER, "scene_cage_2.scn"), Assets.MainFont, main);

            chest = new ObjectChest(Assets.Chest1, Assets.Chest1Open, BaseGame);
            itemBook = new CEAObjectItem("book_1", Assets.Book1, 1, BaseGame.game.Inventory, BaseGame);

            crate = new ObjectChest(Assets.Crate, Assets.CrateOpen, BaseGame);
            itemGoldBlocks = new CEAObjectItem("gold_block", Assets.GoldBlock, 7, BaseGame.game.Inventory, BaseGame);

            fileScene.AddObject(chest);
            fileScene.AddObject(itemBook);
            fileScene.AddObject(crate);
            fileScene.AddObject(itemGoldBlocks);

        }

        public override void Load(Dictionary<string, object> parameters)
        {

            State = parameters;

            chest.IsOpen = (bool) State["chest_open"];
            itemBook.IsTaken = (bool)State["book_taken"];

            crate.IsOpen = (bool)State["crate_open"];
            itemGoldBlocks.IsTaken = (bool)State["gold_blocks_taken"];

            fileScene.Load();

            base.Load(parameters);
        }

        public override void Update(GameTime gameTime)
        {

            chest.Image.Rect = new Rectangle((int) Math.Round(BaseGame.game.ScreenWidth / 2.4), BaseGame.game.ScreenHeight / 2, BaseGame.game.ScreenWidth / 6, BaseGame.game.ScreenHeight / 3);
            itemBook.Image.Rect = new Rectangle((int) Math.Round(BaseGame.game.ScreenWidth / 2.2), (int) Math.Round(BaseGame.game.ScreenHeight / 1.8), BaseGame.game.ScreenWidth / 13, BaseGame.game.ScreenHeight / 9);
            if (!itemBook.IsTaken)
                itemBook.IsVisible = chest.IsOpen;

            crate.Image.Rect = new Rectangle((int)Math.Round(BaseGame.game.ScreenWidth / 1.6), (int) Math.Round(BaseGame.game.ScreenHeight / 2.2), BaseGame.game.ScreenWidth / 7, BaseGame.game.ScreenHeight / 4);
            itemGoldBlocks.Image.Rect = new Rectangle((int)Math.Round(BaseGame.game.ScreenWidth / 1.5), (int)Math.Round(BaseGame.game.ScreenHeight / 1.7), BaseGame.game.ScreenWidth / 13, BaseGame.game.ScreenHeight / 9);
            if (!itemGoldBlocks.IsTaken)
                itemGoldBlocks.IsVisible = crate.IsOpen;

            fileScene.Update(gameTime);

            State["chest_open"] = chest.IsOpen;
            State["book_taken"] = itemBook.IsTaken;

            State["crate_open"] = crate.IsOpen;
            State["gold_blocks_taken"] = itemGoldBlocks.IsTaken;

            base.Update(gameTime);
        }

        public override void Draw()
        {

            fileScene.Draw();

            base.Draw();

            fileScene.DrawTransitions();

        }

    }
}
