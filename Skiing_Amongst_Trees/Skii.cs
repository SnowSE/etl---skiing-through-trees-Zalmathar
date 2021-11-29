using System.IO;
using System;
using System.Collections.Generic;

namespace Skiing_Amongst_Trees
{
    public class Skii
    {
        private GameMap map;
        private Cursor cursor;

        private Slope slope;

        public Skii()
        {
            this.map = new GameMap();
            this.cursor = new Cursor();
            Console.WriteLine("What is the Slope?");
            string entry = Console.ReadLine();
            string[] values = entry.Split(':');
            int over = int.Parse(values[0]);
            int down = int.Parse(values[1]);
            this.slope = new Slope(over, down);
        }

        public string CalcCollisions()
        {
            int collisions = 0;
            while (cursor.posY < map.map.Count)
            {
                char CurVal = map.map[cursor.posY].ToString()[cursor.posX];
                if (CurVal == '#')
                {
                    collisions += 1;
                }
                
                cursor.posX = (cursor.posX + slope.over) % (map.map[0].Length);
                cursor.posY += slope.down;
            }
            return ($"You collided with a tree {collisions} times");
        }

        private class Slope
        {
            public int over { get; set; }
            public int down { get; set; }

            public Slope(int over, int down)
            {
                this.over = over;
                this.down = down;
            }
        }

        private class Cursor
        {
            public int posX { get; set; }
            public int posY { get; set; }
            public Cursor()
            {
                posX = 0;
                posY = 0;
            }
        }

        private class GameMap
        {
            public List<String> map { get; private set; }

            public GameMap()
            {
                map = GameMap.ReadMap();
            }

            private static List<string> ReadMap()
            {
                List<string> nMap = new List<string>();
                try

                {
                    using (StreamReader sr = new StreamReader("./TreeMap.txt"))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            nMap.Add(line);
                        }
                    }
                    return nMap;
                }
                catch (Exception e)
                {
                    nMap.Add("The map could not be read:");
                    nMap.Add(e.Message);
                    return nMap;
                }
            }
        }
    }
}