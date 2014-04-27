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
    class tetrixGame
    {
        public tetrixMatrix bg;
        public activePiece active;
        public Form1 mainScreen;

        public Boolean Tetrissing;

        public myRandom rnd;

        public Boolean goDown;

        public tetrixGame() {
            rnd = new myRandom();
            bg = new tetrixMatrix();
            active = new activePiece(rnd);
            goDown = true;
            this.Tetrissing = true;
        }

        public void tick()
        {
            if (Tetrissing) {
                this.update();
            }
            this.draw();
        }

        public void update() {
            if (!goDown && active.piece.okDown(this))
            {
                goDown = true;
                mainScreen.timer2.Stop();
                mainScreen.help = 0;
                return;
            }
            if (goDown)
            {
                active.piece.down(this);
                this.checkDone();
            }
            else {
                this.printMe();
            }

            
            this.killLine();
          
            

        }

        public void use2048(char where){

            if (where == 'l') {
                for (int j = 0; j < 20; j++) {
                    for (int i = 9; i > 0; i--) { 
                        if(bg.matrix[i,j]!='0' && bg.matrix[i,j]==bg.matrix[i-1,j]){
                            bg.matrix[i - 1, j] *= 2;
                            bg.matrix[i, j] = '0';
                        }
                    }
                }

                for (int j = 0; j < 20; j++) {

                    for (int i = 0; i < 10; i++) {
                        if (bg.matrix[i, j] != '0') {
                            for (int k = 0; k < i; k++) {
                                if (bg.matrix[k, j] == '0') {
                                    bg.matrix[k, j] = bg.matrix[i, j];
                                    bg.matrix[i, j] = '0';
                                }
                            }
                        }
                    }

                }

            }

            if (where == 'r') {
                for (int j = 0; j < 20; j++) {
                    for (int i = 0; i < 9; i++) {
                        if (bg.matrix[i, j] != '0' && bg.matrix[i, j] == bg.matrix[i + 1, j]) {
                            bg.matrix[i + 1, j] *= 2;
                            bg.matrix[i, j] = '0';
                        } 
                    }
                }

                for (int j = 0; j < 20; j++) {
                    for (int i = 9; i >= 0; i--) {
                            
                        if (bg.matrix[i, j] != '0') {
                            for (int k = 9; k >= i; k--) {
                                if (bg.matrix[k, j] == '0') {
                                    bg.matrix[k, j] = bg.matrix[i, j];
                                    bg.matrix[i, j] = '0';
                                }
                            }
                        }
                    }
                }

            }

            if (where == 'u') {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 19; j >= 1; j--)
                    {
                        if (bg.matrix[i, j] != '0' && bg.matrix[i, j] == bg.matrix[i, j - 1])
                        {
                            bg.matrix[i, j] *= 2;
                            /*for (int k = j - 1; k >= 1; k--)
                            {
                                bg.matrix[i, k] = bg.matrix[i, k - 1];
                            }*/
                            bg.matrix[i, 0] = '0';
                        }
                    }
                }

                for (int i = 0; i < 10; i++) {
                    for (int j = 0; j < 20; j++) {
                        if (bg.matrix[i, j] != '0') {

                            for (int k = 0; k <= j; k++) {
                                if (bg.matrix[i, k] == '0') {
                                    bg.matrix[i, k] = bg.matrix[i, j];
                                    bg.matrix[i, j] = '0';
                                }
                            }

                        }
                    }
                }

            }

            if (where == 'd') {
                for (int i = 0; i < 10; i++) {

                    for (int j = 0; j < 19; j++) {

                        if (bg.matrix[i,j]!='0' && bg.matrix[i, j] == bg.matrix[i, j + 1]) {

                            bg.matrix[i, j] = '0';
                            bg.matrix[i, j + 1] *= 2;

                        }

                    }

                }

                for (int i = 0; i < 10; i++)
                {

                    for (int j = 19; j >= 0; j--) {

                        if (bg.matrix[i, j] != '0') {
                            for (int k = 19; k >= j; k--) {
                                if (bg.matrix[i, k] == '0') {
                                    bg.matrix[i, k] = bg.matrix[i,j];
                                    bg.matrix[i, j] = '0';
                                }
                            }
                        }

                    }

                }

            }

        }

        public void killLine()
        {
            for (int j = 0; j < 20; j++) {
                Boolean killThisLine = true;

                for (int i = 0; i < 10; i++) {
                    if (bg.matrix[i, j] == '0') {
                        killThisLine = false;
                        break;
                    }
                }

                if (killThisLine) {
                    for (int i = 0; i < 10; i++) {
                        for (int h = j; h > 0; h--) {
                            bg.matrix[i, h] = bg.matrix[i, h - 1];
                        }
                        bg.matrix[i, 0] = '0';
                    }
                }

            }
        }

        public Boolean checkDone()
        {
            Boolean done = false;
            for (int i = 0; i < 4; i++) {
                Point block = active.piece.blocks[i].getLoc();
                if (block.Y == 19 || bg.matrix[block.X, block.Y+1] != '0') {
                    done = true;
                    break;
                }
            }

            if (done) {
                goDown = false;
                return true;
            }
            return false;
        }

        public void printMe() {
            mainScreen.timer2.Start();
        }

        public void print() {

            if (active != null) {
                if (active != null && active.piece.okDown(this))
                {
                    goDown = true;
                    mainScreen.timer2.Stop();
                    mainScreen.help = 0;
                    return;
                }

                for (int i = 0; i < 4; i++)
                {
                    Point block = active.piece.blocks[i].getLoc();
                    if (block.X >= 0 && block.X <= 9 && block.Y >= 0 && block.Y <= 19)
                        bg.matrix[block.X, block.Y] = active.piece.blocks[i].num;
                }

                this.active = new activePiece(rnd);
                this.goDown = true;
                mainScreen.timer2.Stop();

                mainScreen.ap[0].Location = new Point(-1, -1);
                mainScreen.ap[1].Location = new Point(-1, -1);
                mainScreen.ap[2].Location = new Point(-1, -1);
                mainScreen.ap[3].Location = new Point(-1, -1);
            }
            
        }

        private int getimg(int num)
        {
            switch (num)
            {
                case 1: return 0;
                case 2: return 1;
                case 4: return 2;
                case 8: return 3;
                case 16: return 4;
                case 32: return 5;
                case 64: return 6;
                case 128: return 7;
                case 256: return 8;
                case 512: return 9;
                case 1024: return 10;
                case 2048: return 11;
                case 4096: return 12;
            }
            return 0;
        }

        public void draw()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (bg.matrix[i, j] == '0')
                    {
                        mainScreen.web[i, j].Visible = false;
                    }
                    else
                    {
                        mainScreen.web[i, j].Image = mainScreen.pics[this.getimg(bg.matrix[i, j])];
                        mainScreen.web[i,j].Visible = true;
                    }
                }
            }


            if (active != null) {
                for (int i = 0; i < 4; i++)
                {
                    Point h = active.piece.blocks[i].getLoc();
                    if (h.X >= 0 && h.Y >= 0)
                    {


                        if (mainScreen.ap[i].Image != mainScreen.pics[this.getimg(active.piece.blocks[i].num)])
                        {
                            mainScreen.web[h.X, h.Y].Image = mainScreen.pics[this.getimg(active.piece.blocks[i].num)];
                        }
                        mainScreen.ap[i].Location = mainScreen.web[h.X, h.Y].Location;
                        mainScreen.web[h.X, h.Y].Visible = true;

                    }

                }
            }
            
   
        }
    }
}
