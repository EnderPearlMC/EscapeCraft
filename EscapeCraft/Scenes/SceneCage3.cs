using CodeEasier.Scene;
using CodeEasierAdventure;
using CodeEasierAdventure.Inventory;
using EscapeCraft.Datas;
using EscapeCraft.Scenes.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeCraft.Scenes
{
    class SceneCage3 : CEScene
    {

        CEASceneFileInterpreter fileScene;

        int[,] grid;
        int blockWidth;
        int blockHeight;
        int gridOffX;
        int gridOffY;

        MouseState oldMouseState;

        bool objCompleted;

        public SceneCage3(Main main) : base("cage_3", main)
        {
            fileScene = new CEASceneFileInterpreter(Path.Combine(References.SCENES_FOLDER, "scene_cage_3.scn"), Assets.MainFont, main);

        }

        public override void Load(Dictionary<string, object> parameters)
        {

            oldMouseState = Mouse.GetState();

            State = parameters;

            grid = ((JArray)State["grid"]).ToObject<int[,]>();

            fileScene.Load();

            base.Load(parameters);
        }

        public override void Update(GameTime gameTime)
        {

            MouseState newMouseState = Mouse.GetState();

            State["grid"] = JArray.FromObject(grid);

            fileScene.Update(gameTime);

            // update the blocks size
            blockWidth = BaseGame.game.ScreenWidth / 8;
            blockHeight = (int) Math.Round(BaseGame.game.ScreenHeight / 4.5);

            // update the grid offset
            gridOffX = (int) Math.Round(BaseGame.game.ScreenWidth / 3.5);
            gridOffY = (int) Math.Round(BaseGame.game.ScreenHeight / 5.7);

            // edit grid
            int mouseRow = (int) Math.Floor((float) (newMouseState.Y - gridOffY) / blockHeight);
            int mouseCol = (int) Math.Floor((float) (newMouseState.X - gridOffX) / blockWidth);
            if (mouseRow >= 0 && mouseRow < grid.GetLength(0))
            {
                if (mouseCol >= 0 && mouseCol < grid.GetLength(1))
                {
                    int tile = grid[mouseRow, mouseCol];
                    BaseGame.game.ShowSpecialCursor = true;
                    if (tile == 0)
                        BaseGame.game.CursorToShow = Assets.AddCursor;
                    else if (tile == 1)
                        BaseGame.game.CursorToShow = Assets.RemoveCursor;

                    if (newMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
                    {
                        if (tile == 0)
                        {
                            if (BaseGame.game.Inventory.SelectedBlock >= 0 && BaseGame.game.Inventory.SelectedBlock < BaseGame.game.Inventory.Items.Count)
                            {
                                if (BaseGame.game.Inventory.Items.ElementAt(BaseGame.game.Inventory.SelectedBlock).Key.Id == "gold_block")
                                {
                                    if (BaseGame.game.Inventory.Items.ElementAt(BaseGame.game.Inventory.SelectedBlock).Value >= 1)
                                    {
                                        grid[mouseRow, mouseCol] = 1;
                                        BaseGame.game.Inventory.RemoveItem(BaseGame.game.Inventory.Items.ElementAt(BaseGame.game.Inventory.SelectedBlock).Key, 1);
                                    }
                                }
                            }
                        } 
                        else if (tile == 1)
                        {
                            grid[mouseRow, mouseCol] = 0;
                            BaseGame.game.Inventory.AddItem( "gold_block", 1);
                        }
                    }
                }
            }

            // verify if the grid is filled correctly
            if (grid[0, 0] == 1 && grid[1, 0] == 1 && grid[2, 0] == 1 && grid[2, 1] == 1 && grid[0, 2] == 1 && grid[1, 2] == 1 && grid[2, 2] == 1)
            {
                objCompleted = true;
                BaseGame.game.Player.ScenesState[BaseGame.game.Player.Level] = BaseGame.game.Scenes.Find(item => item.Identifier == BaseGame.game.Player.Level).State;
                BaseGame.game.Player.Level = "cage_4";
                BaseGame.game.ChangeScene("cage_4");
                DataManager.WriteFile("player.json", BaseGame.game.Player);
                BaseGame.game.ShowSpecialCursor = false;
            }

            oldMouseState = newMouseState;

            base.Update(gameTime);
        }

        public override void Draw()
        {

            fileScene.Draw();

            // draw the grid
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    int tile = grid[row, col];
                    if (tile == 1)
                    {
                        BaseGame.spriteBatch.Draw(Assets.GoldBlockTop, new Rectangle((col * blockWidth) + gridOffX, (row * blockHeight) + gridOffY, blockWidth, blockHeight), Color.White);
                    }
                }
            }

            State["grid"] = JArray.FromObject(grid);

            base.Draw();

            fileScene.DrawTransitions();

        }

        public override void OnQuit()
        {

            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    if (grid[row, col] == 1 && !objCompleted)
                    {
                        BaseGame.game.Inventory.AddItem("gold_block", 1);
                    }
                    grid[row, col] = 0;
                }
            }

            State["grid"] = JArray.FromObject(grid);

            base.OnQuit();
        }

    }
}
