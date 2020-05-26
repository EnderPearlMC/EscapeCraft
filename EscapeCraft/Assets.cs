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
        public static Texture2D AddCursor { get; set; }
        public static Texture2D RemoveCursor { get; set; }

        public static Texture2D InventoryCase { get; set; }
        public static Texture2D SelectedInventoryCase { get; set; }

        public static Texture2D Chest1 { get; set; }
        public static Texture2D Chest1Open { get; set; }
        public static Texture2D Crate { get; set; }
        public static Texture2D CrateOpen { get; set; }

        public static Texture2D Book1 { get; set; }
        public static Texture2D GoldBlock { get; set; }
        public static Texture2D GoldBlockTop { get; set; }

        public static Texture2D ItemBook { get; set; }

        public static void Load(ContentManager content)
        {

            MainFont = content.Load<SpriteFont>("main_font");

            HandCursor = content.Load<Texture2D>("cursor_hand");
            AddCursor = content.Load<Texture2D>("cursor_add");
            RemoveCursor = content.Load<Texture2D>("cursor_remove");

            InventoryCase = content.Load<Texture2D>("inventory_case");
            SelectedInventoryCase = content.Load<Texture2D>("inventory_case_selected");

            Chest1 = content.Load<Texture2D>("chest_1");
            Chest1Open = content.Load<Texture2D>("chest_1_open");
            Crate = content.Load<Texture2D>("crate");
            CrateOpen = content.Load<Texture2D>("crate_open");

            Book1 = content.Load<Texture2D>("book_1");
            GoldBlock = content.Load<Texture2D>("gold_block");
            GoldBlockTop = content.Load<Texture2D>("gold_block_top");

            ItemBook = content.Load<Texture2D>("item_book");

        }

    }
}
