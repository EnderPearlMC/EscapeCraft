using CodeEasier.Scene;
using CodeEasierAdventure;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeCraft.Scenes.Objects
{
    class ObjectChest : ICEASceneObject
    {

        public CEImageElement Image { get; set; }

        public bool ToRemove { get; set; }

        public ObjectChest(CEImageElement image)
        {
            Image = image;
        }

        public void Load()
        {
            
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Image.Draw(spriteBatch);
        }

    }
}
