using CodeEasier.Scene;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
   _____          _        ______          _           
  / ____|        | |      |  ____|        (_)          
 | |     ___   __| | ___  | |__   __ _ ___ _  ___ _ __ 
 | |    / _ \ / _` |/ _ \ |  __| / _` / __| |/ _ \ '__|
 | |___| (_) | (_| |  __/ | |___| (_| \__ \ |  __/ |   
  \_____\___/ \__,_|\___| |______\__,_|___/_|\___|_|   
                                                      

    Made by EnderPearl MC

     This framework allows you to create games very quickly.
     Made with monogame.

     You are free to use this framework in all your projects
     but you cannot REDISTRIBUTE it. 

 */

namespace CodeEasier.Polish
{

    /*

        ParticleEmitter class

        Usage : Instance it.

    */

    class CEParticleEmitter
    {

        public List<CEParticle> Particles { get; set; }
        public Vector2 Position { get; set; }

        public CEParticleEmitter()
        {
            Particles = new List<CEParticle>();
        }

        public void AddParticle(Texture2D texture, int w, int h, float timer, float vx, float vy)
        {
            CEParticle p = new CEParticle(texture, w, h, timer, vx, vy);
            p.Rect = new Rectangle((int)Position.X, (int)Position.Y, p.Rect.Width, p.Rect.Height);
            Particles.Add(p);
        }

        public void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            foreach (CEParticle p in Particles)
            {
                p.Rect = new Rectangle((int) Math.Round(p.Rect.X + (p.VX * dt)), (int) Math.Round(p.Rect.Y + (p.VY * dt)), p.Rect.Width, p.Rect.Height);
                p.Timer -= dt;
            }

            Particles.RemoveAll(item => item.Timer <= 0);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (CEParticle p in Particles)
            {
                spriteBatch.Draw(p.Texture, p.Rect, Color.White);
            }
        }

    }
}
