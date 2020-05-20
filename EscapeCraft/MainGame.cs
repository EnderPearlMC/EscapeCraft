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

namespace EscapeCraft
{
    class MainGame : CEGame
    {

        public Player Player { get; set; }

        public MainGame(Main main) : base(main, "Escape Craft (2020 All rights reserved) By EnderPearl MC", new CEWindowMode(CEWindowMode.Mode.Resizable, 1280, 720, 1920, 1080))
        {
        }

        public override void Load()
        {


            AddScene(new SceneCage1(BaseGame));
            AddScene(new SceneCage2(BaseGame));
            AddScene(new SceneCage3(BaseGame));

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

            ChangeScene(Player.Level);

            base.Load();
        }

    }
}
