using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeCraft
{
    class Assets
    {

        public static SpriteFont MainFont { get; set; }

        public static Texture2D Chest1 { get; set; }

        public static void Load(ContentManager content)
        {

            MainFont = content.Load<SpriteFont>("main_font");

            Chest1 = content.Load<Texture2D>("chest_1");

        }

    }
}
