namespace Maze
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelreader = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.lblspaces = new System.Windows.Forms.Label();
            this.lblwalls = new System.Windows.Forms.Label();
            this.lblinputpath = new System.Windows.Forms.Label();
            this.txtinputfilepath = new System.Windows.Forms.TextBox();
            this.panelmaze = new System.Windows.Forms.Panel();
            this.panelreader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelreader
            // 
            this.panelreader.Controls.Add(this.button1);
            this.panelreader.Controls.Add(this.lblspaces);
            this.panelreader.Controls.Add(this.lblwalls);
            this.panelreader.Controls.Add(this.lblinputpath);
            this.panelreader.Controls.Add(this.txtinputfilepath);
            this.panelreader.Location = new System.Drawing.Point(12, 12);
            this.panelreader.Name = "panelreader";
            this.panelreader.Size = new System.Drawing.Size(549, 78);
            this.panelreader.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(401, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Generate Maze";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblspaces
            // 
            this.lblspaces.AutoSize = true;
            this.lblspaces.Location = new System.Drawing.Point(235, 44);
            this.lblspaces.Name = "lblspaces";
            this.lblspaces.Size = new System.Drawing.Size(133, 13);
            this.lblspaces.TabIndex = 0;
            this.lblspaces.Text = "Number of Empty Spaces :";
            // 
            // lblwalls
            // 
            this.lblwalls.AutoSize = true;
            this.lblwalls.Location = new System.Drawing.Point(15, 44);
            this.lblwalls.Name = "lblwalls";
            this.lblwalls.Size = new System.Drawing.Size(91, 13);
            this.lblwalls.TabIndex = 1;
            this.lblwalls.Text = "Number of Walls :";
            // 
            // lblinputpath
            // 
            this.lblinputpath.AutoSize = true;
            this.lblinputpath.Location = new System.Drawing.Point(15, 17);
            this.lblinputpath.Name = "lblinputpath";
            this.lblinputpath.Size = new System.Drawing.Size(103, 13);
            this.lblinputpath.TabIndex = 4;
            this.lblinputpath.Text = "Enter Input File Path";
            // 
            // txtinputfilepath
            // 
            this.txtinputfilepath.Location = new System.Drawing.Point(134, 14);
            this.txtinputfilepath.Name = "txtinputfilepath";
            this.txtinputfilepath.Size = new System.Drawing.Size(234, 20);
            this.txtinputfilepath.TabIndex = 6;
            this.txtinputfilepath.Text = "D:\\srini\\mazefiles\\input\\sample3.txt";
            // 
            // panelmaze
            // 
            this.panelmaze.Location = new System.Drawing.Point(12, 96);
            this.panelmaze.Name = "panelmaze";
            this.panelmaze.Size = new System.Drawing.Size(549, 545);
            this.panelmaze.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 653);
            this.Controls.Add(this.panelmaze);
            this.Controls.Add(this.panelreader);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Maze";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.panelreader.ResumeLayout(false);
            this.panelreader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelreader;
        private System.Windows.Forms.Label lblspaces;
        private System.Windows.Forms.Label lblwalls;
        private System.Windows.Forms.Label lblinputpath;
        private System.Windows.Forms.TextBox txtinputfilepath;
        private System.Windows.Forms.Panel panelmaze;
        private System.Windows.Forms.Button button1;
    }
}

