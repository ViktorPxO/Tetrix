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
    abstract class Piece
    {
        public Block[] blocks;

        public Random rnd;

        public Piece() {
            this.blocks = new Block[4];
            this.rnd = new Random();
        }

        public void down(tetrixGame iCalled) {
            Point[] oldLoc = new Point[4];
            oldLoc[0] = new Point(blocks[0].X, blocks[0].Y);
            oldLoc[1] = new Point(blocks[1].X, blocks[1].Y);
            oldLoc[2] = new Point(blocks[2].X, blocks[2].Y);
            oldLoc[3] = new Point(blocks[3].X, blocks[3].Y);

            for (int i = 0; i < 4; i++) {
                blocks[i].Y++;
            }

            if (!this.check(iCalled)) {
                blocks[0].setLoc(oldLoc[0]);
                blocks[1].setLoc(oldLoc[1]);
                blocks[2].setLoc(oldLoc[2]);
                blocks[3].setLoc(oldLoc[3]);
            }
        }

        public void ml(tetrixGame iCalled)
        {
            Point[] oldLoc = new Point[4];
            oldLoc[0] = new Point(blocks[0].X, blocks[0].Y);
            oldLoc[1] = new Point(blocks[1].X, blocks[1].Y);
            oldLoc[2] = new Point(blocks[2].X, blocks[2].Y);
            oldLoc[3] = new Point(blocks[3].X, blocks[3].Y);

            for (int i = 0; i < 4; i++)
            {
                blocks[i].X--;
            }

            if (!this.check(iCalled))
            {
                blocks[0].setLoc(oldLoc[0]);
                blocks[1].setLoc(oldLoc[1]);
                blocks[2].setLoc(oldLoc[2]);
                blocks[3].setLoc(oldLoc[3]);
            }
        }

        public void mr(tetrixGame iCalled)
        {
            Point[] oldLoc = new Point[4];
            oldLoc[0] = new Point(blocks[0].X, blocks[0].Y);
            oldLoc[1] = new Point(blocks[1].X, blocks[1].Y);
            oldLoc[2] = new Point(blocks[2].X, blocks[2].Y);
            oldLoc[3] = new Point(blocks[3].X, blocks[3].Y);

            for (int i = 0; i < 4; i++)
            {
                blocks[i].X++;
            }

            if (!this.check(iCalled))
            {
                blocks[0].setLoc(oldLoc[0]);
                blocks[1].setLoc(oldLoc[1]);
                blocks[2].setLoc(oldLoc[2]);
                blocks[3].setLoc(oldLoc[3]);
            }
        }

        public void md(tetrixGame iCalled)
        {
            Point[] oldLoc = new Point[4];
            oldLoc[0] = new Point(blocks[0].X, blocks[0].Y);
            oldLoc[1] = new Point(blocks[1].X, blocks[1].Y);
            oldLoc[2] = new Point(blocks[2].X, blocks[2].Y);
            oldLoc[3] = new Point(blocks[3].X, blocks[3].Y);

            for (int i = 0; i < 4; i++)
            {
                blocks[i].Y++;
            }

            if (!this.check(iCalled))
            {
                blocks[0].setLoc(oldLoc[0]);
                blocks[1].setLoc(oldLoc[1]);
                blocks[2].setLoc(oldLoc[2]);
                blocks[3].setLoc(oldLoc[3]);
            }
        }

        public abstract void rotate(tetrixGame iCalled);

        public Boolean okLeft(tetrixGame iCalled)
        {
            Boolean retMe = true;

            for (int i = 0; i < 4; i++) {
                if (blocks[i].X < 0) {
                    return false;
                }
            }

            return retMe;
        }

        public Boolean okRight(tetrixGame iCalled)
        {
            Boolean retMe = true;

            for (int i = 0; i < 4; i++)
            {
                if (blocks[i].X > 9)
                {
                    return false;
                }
            }

            return retMe;
        }

        public Boolean okDown(tetrixGame iCalled)
        {
            Boolean retMe = true;

            

            for (int i = 0; i < 4; i++)
            {
                if (blocks[i].Y >= 19)
                {
                    return false;
                }
            }

            Boolean done = false;
            for (int i = 0; i < 4; i++)
            {
                Point block = iCalled.active.piece.blocks[i].getLoc();
                if (block.X>=0 && block.X<=9 && block.Y>=0 && block.Y<=19 && iCalled.bg.matrix[block.X, block.Y + 1] != '0')
                {
                    done = true;
                }
            }

            if (done)
            {
                return false;
            }

            return retMe;
        }

        public Boolean check(tetrixGame iCalled)
        {
            for (int i = 0; i < 4; i++)
            {
                if (blocks[i].X > 9 || blocks[i].Y > 19 || blocks[i].X<0 || blocks[i].Y<0)
                    return false;
                if (blocks[i].Y>=0 && iCalled.bg.matrix[blocks[i].X, blocks[i].Y] != '0') {
                    return false;
                }
            }
            return true;
        }

    }
}
