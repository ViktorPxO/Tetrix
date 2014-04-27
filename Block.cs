using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tetrix
{
    class Block
    {
        public int X;
        public int Y;

        public int num;

        public Block(Point location, Random rnd) {
            this.X = location.X;
            this.Y = location.Y;
            if (rnd.Next() % 2 == 1)
            {
                this.num = 2;
            }
            else {
                this.num = 4;
            }
        }

        public void setLoc(Point location)
        {

            this.X = location.X;
            this.Y = location.Y;
        }

        public Point getLoc() {
            return new Point(X, Y);
        }

    }
}
