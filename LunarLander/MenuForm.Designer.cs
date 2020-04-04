namespace LunarLander
{
    partial class MenuForm
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
            this.btnStart = new System.Windows.Forms.Button();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.directionLbl = new System.Windows.Forms.Label();
            this.directionLbl2 = new System.Windows.Forms.Label();
            this.directionLbl3 = new System.Windows.Forms.Label();
            this.exitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("MS Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnStart.Location = new System.Drawing.Point(249, 352);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(133, 36);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruction.Location = new System.Drawing.Point(223, 326);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(185, 12);
            this.lblInstruction.TabIndex = 1;
            this.lblInstruction.Text = "Click Below To Start The Game!";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("MS Gothic", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(107, 46);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(424, 64);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "LUNAR LANDER";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(223, 120);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(185, 12);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "By Gary Mejia and Ji Hwan Park";
            // 
            // directionLbl
            // 
            this.directionLbl.AutoSize = true;
            this.directionLbl.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.directionLbl.Location = new System.Drawing.Point(170, 182);
            this.directionLbl.Name = "directionLbl";
            this.directionLbl.Size = new System.Drawing.Size(264, 12);
            this.directionLbl.TabIndex = 4;
            this.directionLbl.Text = "Control the ship with the arrow keys!";
            // 
            // directionLbl2
            // 
            this.directionLbl2.AutoSize = true;
            this.directionLbl2.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.directionLbl2.Location = new System.Drawing.Point(79, 211);
            this.directionLbl2.Name = "directionLbl2";
            this.directionLbl2.Size = new System.Drawing.Size(474, 12);
            this.directionLbl2.TabIndex = 5;
            this.directionLbl2.Text = "Successfully land upright onto a highlighted section on the ground.";
            // 
            // directionLbl3
            // 
            this.directionLbl3.AutoSize = true;
            this.directionLbl3.Font = new System.Drawing.Font("MS Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.directionLbl3.Location = new System.Drawing.Point(47, 237);
            this.directionLbl3.Name = "directionLbl3";
            this.directionLbl3.Size = new System.Drawing.Size(530, 12);
            this.directionLbl3.TabIndex = 6;
            this.directionLbl3.Text = "But be careful. Land the ship going too fast and you will destroy the ship!";
            // 
            // exitBtn
            // 
            this.exitBtn.Font = new System.Drawing.Font("MS Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.exitBtn.Location = new System.Drawing.Point(279, 394);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(70, 36);
            this.exitBtn.TabIndex = 7;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(642, 482);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.directionLbl3);
            this.Controls.Add(this.directionLbl2);
            this.Controls.Add(this.directionLbl);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblInstruction);
            this.Controls.Add(this.btnStart);
            this.Font = new System.Drawing.Font("Symbol", 8.25F);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Name = "MenuForm";
            this.Text = "Main Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label directionLbl;
        private System.Windows.Forms.Label directionLbl2;
        private System.Windows.Forms.Label directionLbl3;
        private System.Windows.Forms.Button exitBtn;
    }
}


