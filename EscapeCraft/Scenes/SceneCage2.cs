using CodeEasier.Scene;
using CodeEasierAdventure;
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

        public SceneCage2(Main main) : base("cage_2", main)
        {
            fileScene = new CEASceneFileInterpreter(Path.Combine("D:/jeux/EscapeCraft/EscapeCraft/EscapeCraft/EscapeCraft/Scenes/", "scene_cage_2.scn"), Assets.MainFont, main);

            chest = new ObjectChest(new CEImageElement(Assets.Chest1, new Rectangle(0, 0, 0, 0)));

            fileScene.AddObject(chest);

        }

        public override void Load(Dictionary<string, object> parameters)
        {

            fileScene.Load();

            base.Load(parameters);
        }

        public override void Update(GameTime gameTime)
        {

            chest.Image.Rect = new Rectangle((int) Math.Round(BaseGame.game.ScreenWidth / 2.3), BaseGame.game.ScreenHeight / 2, BaseGame.game.ScreenWidth / 7, BaseGame.game.ScreenHeight / 4);

            fileScene.Update(gameTime);

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
