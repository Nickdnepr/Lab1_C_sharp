using System;

namespace ConsoleApplication1.Model
{
    public class Map
    {
        private Item[,] map;
        private int size;
        private int numOfFoxes;

        public Map(int size, int numOfFoxes)
        {
            this.size = size;
            this.numOfFoxes = numOfFoxes;
            map = generateMap(size, numOfFoxes);
        }

        private static Item[,] generateMap(int size, int numOfFoxes)
        {
            Random random = new Random();
            Item[,] map = new Item[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {   
                    map[i, j] = new Item(i, j, MapCode.mist);
                }
            }

            map[0, 0] = new Item(0, 0, MapCode.player);
            int unsignedFoxes = numOfFoxes;
            while (unsignedFoxes > 0)
            {
                int x = random.Next(size - 1);
                int y = random.Next(size - 1);
                if (x != 0 && y != 0)
                {
                    if (map[x, y].getNumOfFoxes() < 3)
                    {
                        map[x, y].addFox();
                        unsignedFoxes--;
                    }
                }
            }

            return map;
        }

        public int getNumOfFoxes()
        {
            return numOfFoxes;
        }

        public Item[,] getMap()
        {
            return map;
        }

        public int getSize()
        {
            return size;
        }
    }
}