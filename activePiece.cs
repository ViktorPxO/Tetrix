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
    class activePiece
    {
        public Piece piece;
        public int br;
       

        public activePiece(myRandom rnd) {
            
            br = rnd.Next();

            //br = 0;

            if (br == 0) 
            {
                piece = new PieceI();
            }
            if (br == 1)
            {
                piece = new PieceJ();
            }
            if (br == 2)
            {
                piece = new PieceL();
            }
            if (br == 3)
            {
                piece = new PieceO();
            }
            if (br == 4)
            {
                piece = new PieceS();
            }
            if (br == 5)
            {
                piece = new PieceT();
            }
            if (br == 6)
            {
                piece = new PieceZ();
            }

        }
    }
}
