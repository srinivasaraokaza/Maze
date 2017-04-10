using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace Maze
{
    public partial class Form1 : Form
    {
        string[] input;
        char[][] board;
        int inc = 0;
        int startx = 0, starty = 0;
        int curposx = 0, curposy = 0;
        int endx = 0, endy = 0;
        int startxy = 0, endxy = 0;
        int countwalls = 0, countspaces = 0;
        int counttotal = 0;   
        int mazesize = 0;
        Rectangle[,] rect;
        Image newImagejerry = Image.FromFile(@"jerry.jpg");
        Graphics gobject;
        Brush bblack = new SolidBrush(Color.Black);
        int[,] path;
        Stack mystack = new Stack();
        int pathlength = 0;
        int cellsize = 0;
        bool gameover = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public string[] Readfile(string finpath)
        {
            string[] lines = null;
            try
            {
                lines = System.IO.File.ReadAllLines(finpath);
                return lines;
            }
            catch (Exception)
            {
                throw new FileLoadException("Loading fle issue");
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(gameover == true)
            {
                MessageBox.Show("Game Finished");
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (ismoveallowed(curposx - 1, curposy))
                {
                    moveitem(curposx, curposy,curposx - 1, curposy);
                    curposx = curposx - 1;
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (ismoveallowed(curposx + 1, curposy))
                {
                    moveitem(curposx, curposy, curposx + 1, curposy);
                    curposx = curposx + 1;
                }
            }
            else if (e.KeyCode == Keys.Right)
            {                
                if (ismoveallowed(curposx, curposy + 1))
                {
                    moveitem(curposx, curposy, curposx, curposy+1);
                    curposy = curposy + 1;
                }
            }
            else if (e.KeyCode == Keys.Left)
            {
                if (ismoveallowed(curposx, curposy - 1))
                {
                    moveitem(curposx, curposy, curposx, curposy - 1);
                    curposy = curposy - 1;
                }
            }
        }

        public bool ismoveallowed(int x,int y)
        {
           
            if (board[x][y] == ' ')
            {
                capturepath(x, y);
                return true;
            }
            else if (board[x][y] == 'S')
            {
                MessageBox.Show("You moved to starting point");
                capturepath(x, y);
                return true;
            }
            else if (board[x][y] == 'F')
            {
                MessageBox.Show("You have reached exit");
                capturepath(x, y);
                for (int ite = mystack.Count; ite > 0; ite--)
                { 
                    int[,] sitem = new int[1, 2];  
                    sitem=(int[,])mystack.Pop();
                    path[ite, 0] = sitem[0, 0];
                    path[ite, 1] = sitem[0, 1];
                    pathlength++;
                }
                gameover = true;            
                return true;
            }
            
             return false;
        }

        public void capturepath(int xcor,int ycor)
        {
            int[,] sitem = new int[1, 2];
            int[,] fsitem = new int[1, 2];
            sitem[0, 0] = xcor;
            sitem[0, 1] = ycor;
            fsitem=(int[,])mystack.Peek();
            if(fsitem[0,0]==sitem[0,0] && fsitem[0,1]==sitem[0,1] )
            {
                fsitem = (int[,])mystack.Pop();
            }
            else
            {                
                mystack.Push(sitem);
            }
        }

        public void moveitem(int fromx,int fromy,int tox, int toy)
        {
            gobject.FillRectangle(new SolidBrush(Color.White), (fromy * cellsize) + 1, (fromx * cellsize) + 1, cellsize-1, cellsize-1);
            if (startx == fromx && starty == fromy)
            {                
                gobject.FillRectangle(new SolidBrush(Color.Blue), (starty * cellsize) + 1, (startx * cellsize) + 1, cellsize-1, cellsize-1);
            }
            gobject.DrawImage(newImagejerry, (toy * cellsize) + 1, ((tox) * cellsize) + 1, cellsize-1, cellsize-1);           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtinputfilepath.Text.Length == 0)
                {
                    MessageBox.Show("Please Enter the Inout File Path");
                    return;
                }
                if (!File.Exists(txtinputfilepath.Text))
                {
                    MessageBox.Show("No file found in specific path");
                    return;
                }
                input = Readfile(txtinputfilepath.Text);
                board = new char[input.Length][];
                path = new int[input.Length * input.Length, 2];
                inc = 0;
                startx = 0;
                starty = 0;
                endx = 0;
                endy = 0;
                startxy = 0;
                endxy = 0;
                countwalls = 0;
                countspaces = 0;
                counttotal = 0;
                foreach (string inp in input)
                {
                    board[inc++] = inp.ToArray();
                }
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i].ToUpper().IndexOf('S') != -1)
                    {
                        startx = i;
                        starty = input[i].ToUpper().IndexOf('S');
                        startxy = startxy + input[i].Count(c => c == 'S');

                    }

                    if (input[i].ToUpper().IndexOf('F') != -1)
                    {
                        endx = i;
                        endy = input[i].ToUpper().IndexOf('F');
                        endxy = input[i].Count(c => c == 'F');

                    }
                    countwalls = countwalls + input[i].Count(c => c == 'X');
                    countspaces = countspaces + input[i].Count(c => c == ' ');
                    counttotal = counttotal + input[i].Length;
                }
                if (startxy == 0)
                {
                    MessageBox.Show("Please mention starting point S input File", "Starting point 'S' is mandetory");
                    return;
                }
                else if (startxy > 1)
                {
                    MessageBox.Show("Only one Start point 'S' is allowed in input File", "Multiple Starts");
                    return;
                }
                if (endxy == 0)
                {
                    MessageBox.Show("Please mention Exit F in input File", "Exit 'F' is mandetory");
                    return;
                }
                else if (endxy > 1)
                {
                    MessageBox.Show("Only one exit 'F' is allowed in input File", "Multiple exits");
                    return;
                }
                double result = Math.Sqrt(counttotal);
                mazesize = (int)result;
                if (mazesize > 50)
                {
                    MessageBox.Show("Maximum Maze size is 50X50", "Exceeds maximum Maze size");
                    return;
                }
                cellsize = 500 / mazesize;
                if ((result % 1) == 0)
                {
                    if (counttotal != countwalls + countspaces + 2)
                    {
                        MessageBox.Show("Some invalid characters in Input file", "Wrong Input file");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Number of characters provided in input file not forming perfect square", "Not perfect Square");
                    return;
                }
                lblwalls.Text = lblwalls.Text + countwalls;
                lblspaces.Text = lblspaces.Text + countspaces;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception caught:" + ex.Message);
            }



            gobject = panelmaze.CreateGraphics();
            Brush bblack = new SolidBrush(Color.Black);
            Pen pblack = new Pen(bblack);
            rect = new Rectangle[mazesize, mazesize];
            for (int i = 0; i < mazesize; i++)
            {
                for (int j = 0; j < mazesize; j++)
                {
                    rect[i, j] = new Rectangle(i * cellsize, j * cellsize, cellsize, cellsize);

                    gobject.DrawRectangle(pblack, rect[i, j]);
                    if (board[i][j] == 'X')
                    {
                        gobject.FillRectangle(new SolidBrush(Color.Red), (j * cellsize) + 1, (i * cellsize) + 1, cellsize - 1, cellsize - 1);
                    }
                }
            }
            gobject.FillRectangle(new SolidBrush(Color.Blue), (starty * cellsize) + 1, (startx * cellsize) + 1, cellsize - 1, cellsize - 1);
            gobject.DrawImage(newImagejerry, (starty * cellsize) + 1, (startx * cellsize) + 1, cellsize - 1, cellsize - 1);
            gobject.FillRectangle(new SolidBrush(Color.Green), (endy * cellsize) + 1, (endx * cellsize) + 1, cellsize - 1, cellsize - 1);
            panelmaze.TabIndex = 7;
            txtinputfilepath.Enabled = false;
            curposx = startx;
            curposy = starty;
            int[,] sitem1 = new int[1, 2];
            sitem1[0, 0] = curposx;
            sitem1[0, 1] = curposy;
            mystack.Push(sitem1);
            button1.Enabled = false;
        }
    }
}
