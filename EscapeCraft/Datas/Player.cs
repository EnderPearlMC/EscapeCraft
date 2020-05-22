using CodeEasierAdventure.Inventory;
using CodeEasierAdventure.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeCraft.Datas
{
    class Player
    {

        public string Name { get; set; }
        public string Level { get; set; }
        public Dictionary<string, Dictionary<string, Object>> ScenesState { get; set; }
        public List<string> Inventory { get; set; }

        public Player()
        {
            Name = "Player";
            Level = "cage_1";
            ScenesState = new Dictionary<string, Dictionary<string, object>>()
            {
                { "cage_1", new Dictionary<string, object>() { } },
                { "cage_2", new Dictionary<string, object>() { { "chest_open", false }, { "book_taken", false } } },
                { "cage_3", new Dictionary<string, object>() { } }
            };
            Inventory = new List<string>();
        }

    }
}
