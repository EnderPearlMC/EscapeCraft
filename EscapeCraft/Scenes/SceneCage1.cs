﻿using CodeEasier.Scene;
using CodeEasierAdventure;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeCraft.Scenes
{
    class SceneCage1 : CEScene
    {

        CEASceneFileInterpreter fileScene;

        public SceneCage1(Main main) : base("cage_1", main)
        {
            fileScene = new CEASceneFileInterpreter(Path.Combine(References.SCENES_FOLDER, "scene_cage_1.scn"), Assets.MainFont, main);
        }

        public override void Load(Dictionary<string, object> parameters)
        {

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
