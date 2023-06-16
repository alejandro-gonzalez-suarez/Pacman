using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace programandopacman
{
    public partial class Form1 : Form
    {

        // variables globales para dectectar el jugador va en una de las 4 direcciones y la velocidad a la que se desplaza
        bool goup;
        bool godown;
        bool goleft;
        bool goright;
        int speed = 8;
        // velocidad de los fantasmas y x,y el direccionamiento del fantasma rosa y score el seguimiento de la puntuacion del jugador


        int ghost1 = 8;        
        int ghost2 = 8;        
        int ghost3x = 8;        
        int ghost3y = 8;        
        int score = 0;        

        public Form1()
        {
            InitializeComponent();
            label2.Visible = false;
        }

        private void Keyisdown(object sender, KeyEventArgs e)
        {
            //configurando las teclas 
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
                pacman.Image = Properties.Resources.left;

            }

            if (e.KeyCode == Keys.Right)
            {
                goright = true;

                pacman.Image = Properties.Resources.right;
            }
            if (e.KeyCode == Keys.Up)
            {

                goup = true;
                pacman.Image = Properties.Resources.Up;
            }
            if (e.KeyCode == Keys.Down)
            {

                godown = true;
                pacman.Image = Properties.Resources.down;
            }

        }

        private void Keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goup = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "Score: " + score; 

            
            if (goleft)
            {
                pacman.Left -= speed;
                 
            }
            if (goright)
            {
                pacman.Left += speed;
              
            }
            if (goup)
            {
                pacman.Top -= speed;
              
            }

            if (godown)
            {
                pacman.Top += speed;
               
            }
            

           
            redGhost.Left += ghost1;
            yellowGhost.Left += ghost2;

           
            if (redGhost.Bounds.IntersectsWith(pictureBox4.Bounds))
            {
                ghost1 = -ghost1;
            }
            
            else if (redGhost.Bounds.IntersectsWith(pictureBox3.Bounds))
            {
                ghost1 = -ghost1;
            }
            
            if (yellowGhost.Bounds.IntersectsWith(pictureBox1.Bounds))
            {
                ghost2 = -ghost2;
            }
            
            else if (yellowGhost.Bounds.IntersectsWith(pictureBox2.Bounds))
            {
                ghost2 = -ghost2;
            }
            
            foreach (Control x in this.Controls)
            {
#pragma warning disable CS0252


                if (x is PictureBox && x.Tag == "wall" || x.Tag == "ghost")
#pragma warning restore CS0252
                {

                    if (((PictureBox)x).Bounds.IntersectsWith(pacman.Bounds) || score == 30)
                    {
                        pacman.Left = 0;
                        pacman.Top = 25;
                        label2.Text = "GAME OVER";
                        label2.Visible = true;
                        timer1.Stop();

                    }
                }
#pragma warning disable CS0252 
                if (x is PictureBox && x.Tag == "coin")
#pragma warning restore CS0252 
                {
                    
                    if (((PictureBox)x).Bounds.IntersectsWith(pacman.Bounds))
                    {
                        this.Controls.Remove(x); 
                        score++; 
                    }
                }
            }

          
            pinkGhost.Left += ghost3x;
            pinkGhost.Top += ghost3y;

            if (pinkGhost.Left < 1 ||
                pinkGhost.Left + pinkGhost.Width > ClientSize.Width - 2 ||
                (pinkGhost.Bounds.IntersectsWith(pictureBox4.Bounds)) ||
                (pinkGhost.Bounds.IntersectsWith(pictureBox3.Bounds)) ||
                (pinkGhost.Bounds.IntersectsWith(pictureBox1.Bounds)) ||
                (pinkGhost.Bounds.IntersectsWith(pictureBox2.Bounds))
                )
            {
                ghost3x = -ghost3x;
            }
            if (pinkGhost.Top < 1 || pinkGhost.Top + pinkGhost.Height > ClientSize.Height - 2)
            {
                ghost3y = -ghost3y;
            }
          
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
    
}
