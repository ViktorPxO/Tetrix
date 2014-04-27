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
    class PieceS : Piece
    {
        private int state;
        public PieceS(){
            blocks[0] = new Block(new Point(4,-1),rnd);
            blocks[1] = new Block(new Point(5, -1), rnd);
            blocks[2] = new Block(new Point(3, 0), rnd);
            blocks[3] = new Block(new Point(4, 0), rnd);
            state = 0;
        }

        public override void rotate(tetrixGame iCalled)
        {
            Point[] oldLoc = new Point[4];
            oldLoc[0] = new Point(blocks[0].X, blocks[0].Y);
            oldLoc[1] = new Point(blocks[1].X, blocks[1].Y);
            oldLoc[2] = new Point(blocks[2].X, blocks[2].Y);
            oldLoc[3] = new Point(blocks[3].X, blocks[3].Y);

            if (state == 0) {
                blocks[0].X++;
                blocks[0].Y++;

                blocks[1].Y += 2;

                blocks[2].X++;
                blocks[2].Y--;

                state = 1;

                if (!this.okLeft(iCalled))
                {
                    this.mr(iCalled);
                }

                if (!this.okRight(iCalled))
                {
                    this.ml(iCalled);
                }

                if (!this.okDown(iCalled))
                {
                    this.md(iCalled);
                }

                if (!this.check(iCalled))
                {
                    blocks[0].setLoc(oldLoc[0]);
                    blocks[1].setLoc(oldLoc[1]);
                    blocks[2].setLoc(oldLoc[2]);
                    blocks[3].setLoc(oldLoc[3]);
                    state = 0;
                }

                return;
            }

            if (state == 1) {
                blocks[0].X--;
                blocks[0].Y++;

                blocks[1].X -= 2;

                blocks[2].X++;
                blocks[2].Y++;

                state = 2;

                if (!this.okLeft(iCalled))
                {
                    this.mr(iCalled);
                }

                if (!this.okRight(iCalled))
                {
                    this.ml(iCalled);
                }

                if (!this.okDown(iCalled))
                {
                    this.md(iCalled);
                }

                if (!this.check(iCalled))
                {
                    blocks[0].setLoc(oldLoc[0]);
                    blocks[1].setLoc(oldLoc[1]);
                    blocks[2].setLoc(oldLoc[2]);
                    blocks[3].setLoc(oldLoc[3]);
                    state = 1;
                }

                return;
            }

            if (state == 2)
            {
                blocks[0].X--;
                blocks[0].Y--;

                blocks[1].Y -= 2;

                blocks[2].X--;
                blocks[2].Y++;

                state = 3;

                if (!this.okLeft(iCalled))
                {
                    this.mr(iCalled);
                }

                if (!this.okRight(iCalled))
                {
                    this.ml(iCalled);
                }

                if (!this.okDown(iCalled))
                {
                    this.md(iCalled);
                }

                if (!this.check(iCalled))
                {
                    blocks[0].setLoc(oldLoc[0]);
                    blocks[1].setLoc(oldLoc[1]);
                    blocks[2].setLoc(oldLoc[2]);
                    blocks[3].setLoc(oldLoc[3]);
                    state = 2;
                }

                return;
            }

            if (state == 3)
            {
                blocks[0].X++;
                blocks[0].Y--;

                blocks[1].X += 2;

                blocks[2].X--;
                blocks[2].Y--;

                state = 0;

                if (!this.okLeft(iCalled))
                {
                    this.mr(iCalled);
                }

                if (!this.okRight(iCalled))
                {
                    this.ml(iCalled);
                }

                if (!this.okDown(iCalled))
                {
                    this.md(iCalled);
                }

                if (!this.check(iCalled))
                {
                    blocks[0].setLoc(oldLoc[0]);
                    blocks[1].setLoc(oldLoc[1]);
                    blocks[2].setLoc(oldLoc[2]);
                    blocks[3].setLoc(oldLoc[3]);
                    state = 3;
                }

                return;
            }

        }

    }
}
