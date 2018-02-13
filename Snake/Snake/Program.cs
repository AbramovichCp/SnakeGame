 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            
            Console.SetBufferSize(120, 30);

            HorisontLine TopLine = new HorisontLine(1, 100, 0, '+');
            TopLine.Draw();

            HorisontLine BottomLine = new HorisontLine(1, 100, 25, '+');
            BottomLine.Draw();

            VerticalLine LeftLine = new VerticalLine(0, 25, 1, '+');
            LeftLine.Draw();

            VerticalLine RightLine = new VerticalLine(0, 25, 100, '+');
            RightLine.Draw();


            Point start = new Point(5, 5, '*');

            Snake snake = new Snake(start, 5, Direction.RIGHT);
            snake.Draw();


            FoodCreator foodCreator = new FoodCreator(100, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                    count++;
                    Console.SetCursorPosition(110, 5);
                    Console.Write($"Score:{count}");
                    
                }
                else
                {
                    snake.Move();
                }

                System.Threading.Thread.Sleep(50);



                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
                            


                
            }


            
            Console.ReadLine();
            
        }
    }
}
