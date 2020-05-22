using CodeEasier.Scene;
using CodeEasierAdventure.Inventory;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeCraft.Scenes.Items
{
    class ItemBook1 : CEAInventoryItem
    {

        public ItemBook1() : base("book_1", new CEImageElement(Assets.ItemBook, new Rectangle(0, 0, 0, 0)))
        {
        }

    }
}
