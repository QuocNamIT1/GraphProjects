namespace Drawing_vs1
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
            this.ptbArea = new System.Windows.Forms.PictureBox();
            this.btnInput = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnBFS = new System.Windows.Forms.Button();
            this.btnFloyd = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.dijkstra_btn = new System.Windows.Forms.Button();
            this.btnFB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.verIDStart = new System.Windows.Forms.NumericUpDown();
            this.verIDEnd = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.ptbArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.verIDStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.verIDEnd)).BeginInit();
            this.SuspendLayout();
            // 
            // ptbArea
            // 
            this.ptbArea.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ptbArea.Location = new System.Drawing.Point(13, 87);
            this.ptbArea.Name = "ptbArea";
            this.ptbArea.Size = new System.Drawing.Size(450, 350);
            this.ptbArea.TabIndex = 0;
            this.ptbArea.TabStop = false;
            this.ptbArea.Paint += new System.Windows.Forms.PaintEventHandler(this.ptbArea_Paint);
            this.ptbArea.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ptbArea_MouseClick);
            this.ptbArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ptbArea_MouseMove);
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(486, 87);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(75, 23);
            this.btnInput.TabIndex = 1;
            this.btnInput.Text = "Input";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(486, 159);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "DFS";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBFS
            // 
            this.btnBFS.Location = new System.Drawing.Point(486, 199);
            this.btnBFS.Name = "btnBFS";
            this.btnBFS.Size = new System.Drawing.Size(75, 23);
            this.btnBFS.TabIndex = 3;
            this.btnBFS.Text = "BFS";
            this.btnBFS.UseVisualStyleBackColor = true;
            this.btnBFS.Click += new System.EventHandler(this.btnBFS_Click);
            // 
            // btnFloyd
            // 
            this.btnFloyd.Location = new System.Drawing.Point(486, 242);
            this.btnFloyd.Name = "btnFloyd";
            this.btnFloyd.Size = new System.Drawing.Size(75, 23);
            this.btnFloyd.TabIndex = 4;
            this.btnFloyd.Text = "Floyd";
            this.btnFloyd.UseVisualStyleBackColor = true;
            this.btnFloyd.Click += new System.EventHandler(this.btnFloyd_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(486, 124);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dijkstra_btn
            // 
            this.dijkstra_btn.Location = new System.Drawing.Point(486, 285);
            this.dijkstra_btn.Name = "dijkstra_btn";
            this.dijkstra_btn.Size = new System.Drawing.Size(75, 23);
            this.dijkstra_btn.TabIndex = 6;
            this.dijkstra_btn.Text = "Dijkstra";
            this.dijkstra_btn.UseVisualStyleBackColor = true;
            this.dijkstra_btn.Click += new System.EventHandler(this.dijkstra_btn_Click);
            // 
            // btnFB
            // 
            this.btnFB.Location = new System.Drawing.Point(486, 332);
            this.btnFB.Name = "btnFB";
            this.btnFB.Size = new System.Drawing.Size(75, 23);
            this.btnFB.TabIndex = 7;
            this.btnFB.Text = "Ford-Bellman";
            this.btnFB.UseVisualStyleBackColor = true;
            this.btnFB.Click += new System.EventHandler(this.btnFB_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(285, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Đỉnh kết thúc";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Đỉnh bắt đầu";
            // 
            // verIDStart
            // 
            this.verIDStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verIDStart.Location = new System.Drawing.Point(102, 26);
            this.verIDStart.Name = "verIDStart";
            this.verIDStart.Size = new System.Drawing.Size(120, 26);
            this.verIDStart.TabIndex = 12;
            this.verIDStart.ValueChanged += new System.EventHandler(this.verIDStart_ValueChanged);
            // 
            // verIDEnd
            // 
            this.verIDEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verIDEnd.Location = new System.Drawing.Point(373, 26);
            this.verIDEnd.Name = "verIDEnd";
            this.verIDEnd.Size = new System.Drawing.Size(120, 26);
            this.verIDEnd.TabIndex = 13;
            this.verIDEnd.ValueChanged += new System.EventHandler(this.verIDEnd_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 501);
            this.Controls.Add(this.verIDEnd);
            this.Controls.Add(this.verIDStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFB);
            this.Controls.Add(this.dijkstra_btn);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnFloyd);
            this.Controls.Add(this.btnBFS);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.ptbArea);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ptbArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.verIDStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.verIDEnd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbArea;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnBFS;
        private System.Windows.Forms.Button btnFloyd;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button dijkstra_btn;
        private System.Windows.Forms.Button btnFB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown verIDStart;
        private System.Windows.Forms.NumericUpDown verIDEnd;
    }
}

