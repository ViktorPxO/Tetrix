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
    public partial class Form1 : Form
    {
        public int score;

        public int help;

        public Boolean paused;

        tetrixGame tg;

        public PictureBox[,] web;

        public Bitmap[] pics;

        public PictureBox[] ap;

        public Bitmap win, lose;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            paused = false;

            score = 0;

            help = 0;

            win = new Bitmap("W.png");
            lose = new Bitmap("L.png");

            tg = new tetrixGame();
            tg.mainScreen = this;

            pics = new Bitmap[13];
            pics[1] = new Bitmap("numRes\\num2.png");
            pics[2] = new Bitmap("numRes\\num4.png");
            pics[3] = new Bitmap("numRes\\num8.png");
            pics[4] = new Bitmap("numRes\\num16.png");
            pics[5] = new Bitmap("numRes\\num32.png");
            pics[6] = new Bitmap("numRes\\num64.png");
            pics[7] = new Bitmap("numRes\\num128.png");
            pics[8] = new Bitmap("numRes\\num256.png");
            pics[9] = new Bitmap("numRes\\num512.png");
            pics[10] = new Bitmap("numRes\\num1024.png");
            pics[11] = new Bitmap("numRes\\num2048.png");
            //pics[12] = new Bitmap("numRes\\num4096.png");

            web=new PictureBox[10,20];
            for (int i = 0; i < 10; i++) {
                for (int j = 0; j < 20; j++) {
                    web[i, j] = new PictureBox();
                    tetrixPanel.Controls.Add(web[i, j]);
                    web[i, j].Size = new Size(30, 30);
                    web[i, j].Location = new Point(i * 30, j * 30);
                    web[i, j].Visible = false;
                }
            }

            ap = new PictureBox[4];

            for (int i = 0; i < 4; i++) {
                ap[i] = new PictureBox();
                tetrixPanel.Controls.Add(ap[i]);
                ap[i].Size = new Size(30, 30);
                ap[i].Location = new Point(-1, -1);
                ap[i].Visible = false;
            }
            
        }

        private void drawNext() {
            
            string next1 = "small"+ tg.rnd.getSecond()+".png";
            string next2 = "small" + tg.rnd.getThird() + ".png";
            string next3 = "small" + tg.rnd.getFourth() + ".png";

            pictureBox1.Image = new Bitmap(next1);
            pictureBox2.Image = new Bitmap(next2);
            pictureBox3.Image = new Bitmap(next3);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            label2.Text = score.ToString();

            tg.tick();
            this.drawNext();

            if (tg.finished == 1) {
                WINbtn.Size = new Size(680, 677);
                WINbtn.Text = "";
                WINbtn.BackgroundImage = win;
                WINbtn.Visible = true;
            }
            if (tg.finished == 2) {
                WINbtn.Size = new Size(680, 677);
                WINbtn.Text = "";
                WINbtn.BackgroundImage = lose;
                WINbtn.Visible = true;
            }

        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            tg = new tetrixGame();
            tg.mainScreen = this;
            timer1.Start();
            
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!paused && tg.Tetrissing) {
                if (keyData == Keys.Left)
                {
                    tg.active.piece.ml(tg);
                    return true;
                }

                if (keyData == Keys.Right)
                {
                    tg.active.piece.mr(tg);
                    return true;
                }

                if (keyData == Keys.Down)
                {
                    tg.active.piece.md(tg);
                    return true;
                }

                if (keyData == Keys.Up)
                {
                    tg.active.piece.rotate(tg);
                    return true;
                }               
            }

            if (!paused && !tg.Tetrissing) {
                if (keyData == Keys.Left)
                {
                    tg.use2048('l');
                    return true;
                }

                if (keyData == Keys.Right)
                {
                    tg.use2048('r');
                    return true;
                }

                if (keyData == Keys.Down)
                {
                    tg.use2048('d');
                    return true;
                }

                if (keyData == Keys.Up)
                {
                    tg.use2048('u');
                    return true;
                }   
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            help++;
            if (tg.goDown) {
                help = 0;
                tg.goDown = true;
                timer2.Stop();
                timer1.Start();
                return;
            }
            if (help == 11) {
                help = 0;
                tg.print();
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (!paused)
            {
                timer1.Stop();
                paused = true;
                btnPause.Text = "resume";
            }
            else
            {
                timer1.Start();
                paused = false;
                btnPause.Text = "pause";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tg.Tetrissing) {
                tg.Tetrissing = false;
                button1.Text = "Play Tetris";
                tg.active = null;
            }else{
                tg.bringDown();
                tg.active = new activePiece(tg.rnd);
                tg.Tetrissing = true;
                button1.Text = "Play 2048";
            }
        }

        private void WINbtn_Click(object sender, EventArgs e)
        {
            WINbtn.Visible = false;
            timer1.Stop();
            tg = new tetrixGame();
            tg.mainScreen = this;
            timer1.Start();
        }

             

    }
}
