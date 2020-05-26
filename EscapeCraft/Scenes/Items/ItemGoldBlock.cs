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
    class ItemGoldBlock : CEAInventoryItem
    {

        public ItemGoldBlock() : base("gold_block", new CEImageElement(Assets.GoldBlock, new Rectangle(0, 0, 0, 0)))
        {
        }

    }
}
