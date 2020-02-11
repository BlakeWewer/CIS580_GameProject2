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
    class Maze
    {
        Game2 game;
        public List<Wall> walls = new List<Wall>();
        public List<Spike> spikes = new List<Spike>();
        public Vector2 startingPosition;

        public Maze(Game2 game)
        {
            this.game = game;
        }

        public void Initialize(List<Tuple<int, int>> wallPositions, List<Tuple<int, int>> spikePositions, Vector2 startingPosition)
        {
            for(int i = 0; i < wallPositions.Count(); i++)
            {
                Wall wall = new Wall(game);
                wall.Initialize(new Vector2(wallPositions[i].Item1 * 50,
                                                wallPositions[i].Item2 * 50),
                                    false);
                walls.Add(wall);
            }
            for (int i = 0; i < spikePositions.Count(); i++)
            {
                Spike spike = new Spike(game);
                spike.Initialize(new Vector2(spikePositions[i].Item1 * 50,
                                                spikePositions[i].Item2 * 50));
                spikes.Add(spike);
            }
            this.startingPosition = startingPosition;
        }

        public void LoadContent()
        {
            foreach(Wall wall in walls)
            {
                wall.LoadContent();
            }
            foreach(Spike spike in spikes)
            {
                spike.LoadContent();
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach(Spike spike in spikes)
            {
                spike.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Wall wall in walls)
            {
                wall.Draw(spriteBatch);
            }
            
            foreach(Spike spike in spikes)
            {
                spike.Draw(spriteBatch);
            }
        }

        public void MakeWallBombable(Tuple<int, int> location)
        {
            bool found = false;
            int i = 0;
            while(!found && i < walls.Count())
            {
                if(walls[i].Bounds.X == location.Item1 * 50 
                    && walls[i].Bounds.Y == location.Item2 * 50)
                {
                    walls[i].isBombable = true;
                    found = true;
                }
                i++;
            }
        }
    }
}
