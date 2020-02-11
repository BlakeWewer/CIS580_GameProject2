using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MonoGameWindowsStarter
{
    class Wall
    {
        Game2 game;
        public BoundingRectangle Bounds;
        Texture2D texture;
        public bool isBombable;
        public bool destroyed;

        //Idea for next project: Invisible/Appearing Walls

        public Wall(Game2 game)
        {
            this.game = game;
        }

        public void Initialize(Vector2 position, bool bombable)
        {
            Bounds.Width = 50;
            Bounds.Height = 50;
            Bounds.X = position.X;
            Bounds.Y = position.Y;
            isBombable = bombable;
            destroyed = false;
        }

        public void LoadContent()
        {
            if (isBombable)
                texture = game.Content.Load<Texture2D>("cracked_wall");
            else
                texture = game.Content.Load<Texture2D>("wall");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(!destroyed)
                spriteBatch.Draw(texture, Bounds, Color.White);
        }
    }
}
