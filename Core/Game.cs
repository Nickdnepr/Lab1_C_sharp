using System;
using ConsoleApplication1.Model;
using ConsoleApplication1.view;

namespace ConsoleApplication1
{
    public static class Game
    {
        private static bool gameIsRuning;
        private static int size;
        private static int numOfFoxes;
        private static Map map;
        private static Item position;

        public static void start()
        {
            init();
            while (gameIsRuning)
            {
                drawMap();
                checkKontrol();
            }

            Console.Clear();
            Console.WriteLine("Thanks for playing");
        }

        private static void checkKontrol()
        {
            ConsoleKeyInfo pressedKey = Console.ReadKey();
            switch (pressedKey.Key)
            {
                case ConsoleKey.LeftArrow:
                {
                    if (position.getX() > 0)
                    {
                        position.setX(position.getX() - 1);
                    }

                    break;
                }
                case ConsoleKey.UpArrow:
                {
                    if (position.getY() > 0)
                    {
                        position.setY(position.getY() - 1);
                    }

                    break;
                }
                case ConsoleKey.DownArrow:
                {
                    if (position.getY() < size - 1)
                    {
                        position.setY(position.getY() + 1);
                    }

                    break;
                }
                case ConsoleKey.RightArrow:
                {
                    if (position.getX() < size - 1)
                    {
                        position.setX(position.getX() + 1);
                    }

                    break;
                }
                case ConsoleKey.Q:
                {
                    gameIsRuning = false;
                    break;
                }
                case ConsoleKey.S:
                    position.shoot();
                    map.getMap()[position.getY(), position.getX()].shoot();
                    break;
            }

            int foxes = 0;

            if (position.getX()!=0)
            {
                foxes += map.getMap()[position.getY(), position.getX()-1].getNumOfFoxes();
            }
            if (position.getY()!=0)
            {
                foxes += map.getMap()[position.getY()-1, position.getX()].getNumOfFoxes();
            }
            if (position.getX()!=size-1)
            {
                foxes += map.getMap()[position.getY(), position.getX()+1].getNumOfFoxes();
            }
            if (position.getY()!=size-1)
            {
                foxes += map.getMap()[position.getY()+1, position.getX()].getNumOfFoxes();
            }
            
            position.setNumOfFoxes(foxes);
        }

        private static void drawMap()
        {
            GameDrawer.drawGameFrame(position);
            
//            Console.WriteLine(position.getX()+" "+position.getY());
        }

        private static void init()
        {
            gameIsRuning = true;
            size = initInt("Map Size");
            numOfFoxes = initInt("Number Of Foxes");
            map = new Map(size, numOfFoxes);
            GameDrawer.setMap(map);
            position = new Item(0, 0);
        }

        private static int initInt(string varName)
        {
            bool valid = false;
            int i = 0;

            Console.WriteLine("Input " + varName);
            while (!valid)
            {
                try
                {
                    i = Convert.ToInt32(Console.ReadLine());
                    valid = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Input");
                }
            }

            return i;
        }
    }
}