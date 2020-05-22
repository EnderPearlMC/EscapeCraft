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

        public static Texture2D HandCursor { get; set; }
        public static Texture2D InventoryCase { get; set; }

        public static Texture2D Chest1 { get; set; }
        public static Texture2D Chest1Open { get; set; }

        public static Texture2D Book1 { get; set; }

        public static Texture2D ItemBook { get; set; }

        public static void Load(ContentManager content)
        {

            MainFont = content.Load<SpriteFont>("main_font");

            HandCursor = content.Load<Texture2D>("cursor_hand");
            InventoryCase = content.Load<Texture2D>("inventory_case");

            Chest1 = content.Load<Texture2D>("chest_1");
            Chest1Open = content.Load<Texture2D>("chest_1_open");

            Book1 = content.Load<Texture2D>("book_1");

            ItemBook = content.Load<Texture2D>("item_book");

        }

    }
}
