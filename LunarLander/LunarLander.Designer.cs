﻿namespace LunarLander
{
    partial class LunarLander
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LunarLander));
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.gameScreen = new System.Windows.Forms.PictureBox();
            this.picInstructions = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gameScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInstructions)).BeginInit();
            this.SuspendLayout();
            // 
            // updateTimer
            // 
            this.updateTimer.Enabled = true;
            this.updateTimer.Interval = 50;
            this.updateTimer.Tick += new System.EventHandler(this.timer);
            // 
            // gameScreen
            // 
            this.gameScreen.Location = new System.Drawing.Point(0, 0);
            this.gameScreen.Name = "gameScreen";
            this.gameScreen.Size = new System.Drawing.Size(1619, 725);
            this.gameScreen.TabIndex = 0;
            this.gameScreen.TabStop = false;
            // 
            // picInstructions
            // 
            this.picInstructions.Image = ((System.Drawing.Image)(resources.GetObject("picInstructions.Image")));
            this.picInstructions.Location = new System.Drawing.Point(1542, 12);
            this.picInstructions.Name = "picInstructions";
            this.picInstructions.Size = new System.Drawing.Size(35, 42);
            this.picInstructions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picInstructions.TabIndex = 1;
            this.picInstructions.TabStop = false;
            this.picInstructions.Click += new System.EventHandler(this.instructions_Click);
            // 
            // LunarLander
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1617, 722);
            this.Controls.Add(this.picInstructions);
            this.Controls.Add(this.gameScreen);
            this.Name = "LunarLander";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyUp);
            ((System.ComponentModel.ISupportInitialize)(this.gameScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInstructions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.PictureBox gameScreen;
        private System.Windows.Forms.PictureBox picInstructions;
    }
}

