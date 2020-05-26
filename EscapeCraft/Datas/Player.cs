using CodeEasierAdventure.Inventory;
using CodeEasierAdventure.Objects;
using Newtonsoft.Json.Linq;
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
        public Dictionary<string, int> Inventory { get; set; }

        public Player()
        {
            Name = "Player";
            Level = "cage_1";

            int[,] gridForCage3 = new int[,] {
                    { 0, 0, 0 },
                    { 0, 0, 0 },
                    { 0, 0, 0 }
            };

        ScenesState = new Dictionary<string, Dictionary<string, object>>()
            {
                { "cage_1", new Dictionary<string, object>() { } },
                { "cage_2", new Dictionary<string, object>() { { "chest_open", false }, { "book_taken", false }, { "crate_open", false }, { "gold_blocks_taken", false } } },
                { "cage_3", new Dictionary<string, object>() { { "grid", JArray.FromObject(gridForCage3) } } },
                { "cage_4", new Dictionary<string, object>() { } },

                { "hall_1", new Dictionary<string, object>() { } } };
            Inventory = new Dictionary<string, int>();
        }

    }
}
