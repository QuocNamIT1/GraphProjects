namespace Drawing_vs1
{
    partial class Input
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.ptbArea = new System.Windows.Forms.PictureBox();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnhd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ptbArea)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(13, 461);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ptbArea
            // 
            this.ptbArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbArea.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ptbArea.Location = new System.Drawing.Point(13, 81);
            this.ptbArea.Name = "ptbArea";
            this.ptbArea.Size = new System.Drawing.Size(450, 350);
            this.ptbArea.TabIndex = 1;
            this.ptbArea.TabStop = false;
            this.ptbArea.Paint += new System.Windows.Forms.PaintEventHandler(this.ptbArea_Paint);
            this.ptbArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ptbArea_MouseDown);
            this.ptbArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ptbArea_MouseMove);
            this.ptbArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ptbArea_MouseUp);
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(121, 460);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 2;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnDone_MouseClick);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(229, 461);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnhd
            // 
            this.btnhd.Location = new System.Drawing.Point(334, 459);
            this.btnhd.Name = "btnhd";
            this.btnhd.Size = new System.Drawing.Size(75, 23);
            this.btnhd.TabIndex = 4;
            this.btnhd.Text = "Hướng dẫn";
            this.btnhd.UseVisualStyleBackColor = true;
            this.btnhd.Click += new System.EventHandler(this.btnhd_Click);
            // 
            // Input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 496);
            this.Controls.Add(this.btnhd);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.ptbArea);
            this.Controls.Add(this.btnCancel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Input";
            this.Text = "Input";
            ((System.ComponentModel.ISupportInitialize)(this.ptbArea)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox ptbArea;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnhd;
    }
}