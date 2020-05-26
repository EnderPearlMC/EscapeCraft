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
    class SceneHall1 : CEScene
    {

        CEASceneFileInterpreter fileScene;

        public SceneHall1(Main main) : base("hall_1", main)
        {
            fileScene = new CEASceneFileInterpreter(Path.Combine(References.SCENES_FOLDER, "scene_hall_1.scn"), Assets.MainFont, main);

        }

        public override void Load(Dictionary<string, object> parameters)
        {

            State = parameters;

            fileScene.Load();

            base.Load(parameters);
        }

        public override void Update(GameTime gameTime)
        {

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
