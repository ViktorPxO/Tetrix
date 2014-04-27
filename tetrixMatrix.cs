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
    class tetrixMatrix
    {
        public int[,] matrix;

        public tetrixMatrix() { 
            matrix=new int[10,20];

            for(int i=0;i<10;i++){
                for (int j = 0; j < 20; j++) {
                    matrix[i, j] = '0';
                }
            }

        }
    }
}
