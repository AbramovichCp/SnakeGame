using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake : Figure
    {
        public int count = 0;
        Direction direction;
        public Snake(Point tail, int lenght, Direction direction)
        {
            this.direction = direction;
            pList = new List<Point>();
            for (int i = 0; i < lenght; i++)
            {
                Point p = new Point(tail);
                p.Move(i, direction);
                pList.Add( p );
                
            }
        }
        public void Move()
        {
            Point tail = pList.First();
            pList.Remove(tail);
            Point head = GetNextPoint();
            pList.Add(head);

            tail.Clear();
            head.Draw();
        }

        public Point GetNextPoint()
        {
            Point head = pList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direction);
            return nextPoint;
        }
        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
            {
                direction = Direction.LEFT;
            }
            else if (key == ConsoleKey.RightArrow)
            {
                direction = Direction.RIGHT;
            }
            else if (key == ConsoleKey.UpArrow)
            {
                direction = Direction.UP;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                direction = Direction.DOWN;
            }

        }
        internal bool Eat(Point food)
        {
            Point head = GetNextPoint();

            if( head.IsHit(food))
            {
                food.sym = head.sym;
                food.Draw();

                pList.Add(food);
                return true;

            }
            else
            {
                return false;
            }
        }
        //public int Count(bool Eat)
        //{
            
        //    if(Eat == true)
        //    {
        //        count++;
        //    }
        //    return count;
        //}
        //public void WriteCount(Point score, int count)
        //{

        //}
       
    }
}
