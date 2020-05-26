using CodeEasier.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeEasierAdventure.Inventory
{
    abstract class CEAInventoryItem
    {

        public string Id { get; set; }
        public CEImageElement Image { get; set; }

        public CEAInventoryItem(string id, CEImageElement image)
        {
            Id = id;
            Image = image;
        }

    }
}
