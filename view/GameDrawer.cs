using System;
using ConsoleApplication1.Model;

namespace ConsoleApplication1.view
{
    public static class GameDrawer
    {
        private static Map map;

        public static void setMap(Map map)
        {
            GameDrawer.map = map;
        }

        public static void drawGameFrame(Item position)
        {
            Console.Clear();
            Console.WriteLine("Number of foxes is " + map.getNumOfFoxes());
            Console.WriteLine("-----------");
            for (int i = 0; i < map.getSize(); i++)
            {
                for (int j = 0; j < map.getSize(); j++)
                {
                    string item = map.getMap()[i, j].getNumOfFoxes() + " ";
                    //TODO
                    if (map.getMap()[i, j].getCode().Equals(MapCode.player))
                    {
                        item = "p ";
                    }

    
                    if (i == position.getY() && j == position.getX())
                    {
                        item = position.getNumOfFoxes() + " ";
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    if (map.getMap()[i, j].getShooted())
                    {
                        item = "x ";
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    Console.Write(item);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                Console.WriteLine();
            }
        }
    }
}