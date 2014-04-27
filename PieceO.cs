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
    class PieceO : Piece
    {

        public PieceO() {
            blocks[0] = new Block(new Point(4,-1),rnd);
            blocks[1] = new Block(new Point(5, -1),rnd);
            blocks[2] = new Block(new Point(4, 0),rnd);
            blocks[3] = new Block(new Point(5, 0),rnd);
        }

        public override void rotate(tetrixGame iCalled)
        {

        }

    }
}
