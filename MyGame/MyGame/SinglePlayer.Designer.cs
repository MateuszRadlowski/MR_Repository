namespace MyGame
{
    partial class SinglePlayer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SinglePlayer));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.road = new System.Windows.Forms.Panel();
            this.stop = new System.Windows.Forms.PictureBox();
            this.score_lbl = new System.Windows.Forms.Label();
            this.Tree = new System.Windows.Forms.PictureBox();
            this.pause_label = new System.Windows.Forms.Label();
            this.LvlUp = new System.Windows.Forms.PictureBox();
            this.Wheel3 = new System.Windows.Forms.PictureBox();
            this.Wheel2 = new System.Windows.Forms.PictureBox();
            this.Wheel1 = new System.Windows.Forms.PictureBox();
            this.wall2 = new System.Windows.Forms.PictureBox();
            this.wall1 = new System.Windows.Forms.PictureBox();
            this.car = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.road.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LvlUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wheel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wheel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wheel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wall2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wall1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.car)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // road
            // 
            this.road.BackColor = System.Drawing.Color.DimGray;
            this.road.Controls.Add(this.stop);
            this.road.Controls.Add(this.score_lbl);
            this.road.Controls.Add(this.Tree);
            this.road.Controls.Add(this.pause_label);
            this.road.Controls.Add(this.LvlUp);
            this.road.Controls.Add(this.Wheel3);
            this.road.Controls.Add(this.Wheel2);
            this.road.Controls.Add(this.Wheel1);
            this.road.Controls.Add(this.wall2);
            this.road.Controls.Add(this.wall1);
            this.road.Controls.Add(this.car);
            this.road.Dock = System.Windows.Forms.DockStyle.Fill;
            this.road.ForeColor = System.Drawing.Color.Transparent;
            this.road.Location = new System.Drawing.Point(0, 0);
            this.road.Name = "road";
            this.road.Size = new System.Drawing.Size(494, 512);
            this.road.TabIndex = 0;
            // 
            // stop
            // 
            this.stop.BackColor = System.Drawing.Color.Transparent;
            this.stop.BackgroundImage = global::MyGame.Properties.Resources.Stop_it;
            this.stop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.stop.Location = new System.Drawing.Point(213, 85);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(27, 27);
            this.stop.TabIndex = 10;
            this.stop.TabStop = false;
            // 
            // score_lbl
            // 
            this.score_lbl.AutoSize = true;
            this.score_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.score_lbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.score_lbl.Location = new System.Drawing.Point(438, 9);
            this.score_lbl.Name = "score_lbl";
            this.score_lbl.Size = new System.Drawing.Size(0, 20);
            this.score_lbl.TabIndex = 9;
            // 
            // Tree
            // 
            this.Tree.BackColor = System.Drawing.Color.Transparent;
            this.Tree.BackgroundImage = global::MyGame.Properties.Resources.Tree_Image;
            this.Tree.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Tree.Location = new System.Drawing.Point(33, 354);
            this.Tree.Name = "Tree";
            this.Tree.Size = new System.Drawing.Size(100, 100);
            this.Tree.TabIndex = 8;
            this.Tree.TabStop = false;
            // 
            // pause_label
            // 
            this.pause_label.AutoSize = true;
            this.pause_label.BackColor = System.Drawing.Color.Transparent;
            this.pause_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pause_label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pause_label.Location = new System.Drawing.Point(149, 162);
            this.pause_label.Name = "pause_label";
            this.pause_label.Size = new System.Drawing.Size(181, 54);
            this.pause_label.TabIndex = 7;
            this.pause_label.Text = "PAUSE";
            // 
            // LvlUp
            // 
            this.LvlUp.BackColor = System.Drawing.Color.Transparent;
            this.LvlUp.Image = global::MyGame.Properties.Resources.LvlUp_Image;
            this.LvlUp.Location = new System.Drawing.Point(215, 219);
            this.LvlUp.Name = "LvlUp";
            this.LvlUp.Size = new System.Drawing.Size(50, 40);
            this.LvlUp.TabIndex = 6;
            this.LvlUp.TabStop = false;
            // 
            // Wheel3
            // 
            this.Wheel3.BackColor = System.Drawing.Color.Transparent;
            this.Wheel3.BackgroundImage = global::MyGame.Properties.Resources.Wheel_Image;
            this.Wheel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Wheel3.Location = new System.Drawing.Point(398, 101);
            this.Wheel3.Name = "Wheel3";
            this.Wheel3.Size = new System.Drawing.Size(55, 55);
            this.Wheel3.TabIndex = 5;
            this.Wheel3.TabStop = false;
            // 
            // Wheel2
            // 
            this.Wheel2.BackColor = System.Drawing.Color.Transparent;
            this.Wheel2.BackgroundImage = global::MyGame.Properties.Resources.Wheel_Image;
            this.Wheel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Wheel2.Location = new System.Drawing.Point(269, 277);
            this.Wheel2.Name = "Wheel2";
            this.Wheel2.Size = new System.Drawing.Size(55, 55);
            this.Wheel2.TabIndex = 4;
            this.Wheel2.TabStop = false;
            // 
            // Wheel1
            // 
            this.Wheel1.BackColor = System.Drawing.Color.Transparent;
            this.Wheel1.BackgroundImage = global::MyGame.Properties.Resources.Wheel_Image;
            this.Wheel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Wheel1.Location = new System.Drawing.Point(78, 173);
            this.Wheel1.Name = "Wheel1";
            this.Wheel1.Size = new System.Drawing.Size(55, 55);
            this.Wheel1.TabIndex = 3;
            this.Wheel1.TabStop = false;
            // 
            // wall2
            // 
            this.wall2.BackColor = System.Drawing.Color.Transparent;
            this.wall2.BackgroundImage = global::MyGame.Properties.Resources.Wall_Image;
            this.wall2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.wall2.InitialImage = global::MyGame.Properties.Resources.Wall_Image;
            this.wall2.Location = new System.Drawing.Point(269, 25);
            this.wall2.Name = "wall2";
            this.wall2.Size = new System.Drawing.Size(100, 50);
            this.wall2.TabIndex = 2;
            this.wall2.TabStop = false;
            // 
            // wall1
            // 
            this.wall1.BackColor = System.Drawing.Color.Transparent;
            this.wall1.BackgroundImage = global::MyGame.Properties.Resources.Wall_Image;
            this.wall1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.wall1.InitialImage = global::MyGame.Properties.Resources.Wall_Image;
            this.wall1.Location = new System.Drawing.Point(79, 25);
            this.wall1.Name = "wall1";
            this.wall1.Size = new System.Drawing.Size(100, 50);
            this.wall1.TabIndex = 1;
            this.wall1.TabStop = false;
            // 
            // car
            // 
            this.car.BackColor = System.Drawing.Color.Transparent;
            this.car.BackgroundImage = global::MyGame.Properties.Resources.Car_Image;
            this.car.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.car.Image = global::MyGame.Properties.Resources.Car_Image;
            this.car.InitialImage = global::MyGame.Properties.Resources.Car_Image;
            this.car.Location = new System.Drawing.Point(215, 450);
            this.car.Name = "car";
            this.car.Size = new System.Drawing.Size(25, 50);
            this.car.TabIndex = 0;
            this.car.TabStop = false;
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 512);
            this.Controls.Add(this.road);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(510, 550);
            this.MinimumSize = new System.Drawing.Size(510, 550);
            this.Name = "Form1";
            this.Text = "My Game";
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.road.ResumeLayout(false);
            this.road.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LvlUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wheel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wheel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Wheel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wall2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wall1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.car)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel road;
        private System.Windows.Forms.PictureBox car;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox wall2;
        private System.Windows.Forms.PictureBox wall1;
        private System.Windows.Forms.PictureBox Wheel3;
        private System.Windows.Forms.PictureBox Wheel2;
        private System.Windows.Forms.PictureBox Wheel1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.PictureBox LvlUp;
        private System.Windows.Forms.Label pause_label;
        private System.Windows.Forms.PictureBox Tree;
        private System.Windows.Forms.Label score_lbl;
        private System.Windows.Forms.PictureBox stop;
    }
}

