namespace PC1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            TimerLabel = new Label();
            ScoreLabel = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(TimerLabel);
            groupBox1.Controls.Add(ScoreLabel);
            groupBox1.ForeColor = SystemColors.ControlLightLight;
            groupBox1.Location = new System.Drawing.Point(12, 315);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(300, 45);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Stats";
            // 
            // TimerLabel
            // 
            TimerLabel.AutoSize = true;
            TimerLabel.ForeColor = SystemColors.ControlLightLight;
            TimerLabel.Location = new System.Drawing.Point(229, 19);
            TimerLabel.Name = "TimerLabel";
            TimerLabel.Size = new Size(65, 15);
            TimerLabel.TabIndex = 1;
            TimerLabel.Text = "TimerLabel";
            TimerLabel.Click += TimerLabel_Click;
            // 
            // ScoreLabel
            // 
            ScoreLabel.AutoSize = true;
            ScoreLabel.ForeColor = SystemColors.ControlLightLight;
            ScoreLabel.Location = new System.Drawing.Point(6, 19);
            ScoreLabel.Name = "ScoreLabel";
            ScoreLabel.Size = new Size(38, 15);
            ScoreLabel.TabIndex = 0;
            ScoreLabel.Text = "label1";
            ScoreLabel.Click += ScoreLabel_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(324, 364);
            Controls.Add(groupBox1);
            Name = "Form1";
            Paint += Form_Draw;
            KeyDown += Key_Down;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label ScoreLabel;
        private Label TimerLabel;
    }
}