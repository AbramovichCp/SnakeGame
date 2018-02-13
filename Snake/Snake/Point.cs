using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Point
    {
        public int x;
        public int y;
        public char sym;

        public Point(int x,int y,char sym)
        {
            this.x = x;
            this.y = y;
            this.sym = sym;
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }

        public Point(Point p)
        {
            x = p.x;
            y = p.y;
            sym = p.sym; 
        }

        public bool IsHit(Point p )
        {
            return p.x == this.x && p.y == this.y;
        }

        public void Move(int offset, Direction direction)
        {
            if(direction == Direction.LEFT)
            {
                x -= offset;
            }
            else if(direction == Direction.RIGHT)
            {
                x += offset;
            }
            else if (direction == Direction.DOWN)
            {
                y += offset;
            }
            else if (direction == Direction.UP)
            {
                y -= offset;
            }

        }

        public override string ToString()
        {
            return x + ", " + y + ", " + sym;
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }

        public void Clear()
        {
            sym = ' ';
            Draw();
        }
    }
}
