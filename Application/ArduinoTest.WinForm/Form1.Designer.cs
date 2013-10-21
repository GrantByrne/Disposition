namespace ArduinoTest.WinForm
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
            this.RedTextBox = new System.Windows.Forms.TextBox();
            this.BlueTextBox = new System.Windows.Forms.TextBox();
            this.GreenTextBox = new System.Windows.Forms.TextBox();
            this.SetColorButton = new System.Windows.Forms.Button();
            this.RedLabel = new System.Windows.Forms.Label();
            this.BlueLabel = new System.Windows.Forms.Label();
            this.GreenLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RedTextBox
            // 
            this.RedTextBox.Location = new System.Drawing.Point(98, 12);
            this.RedTextBox.Name = "RedTextBox";
            this.RedTextBox.Size = new System.Drawing.Size(100, 20);
            this.RedTextBox.TabIndex = 0;
            this.RedTextBox.Text = "255";
            // 
            // BlueTextBox
            // 
            this.BlueTextBox.Location = new System.Drawing.Point(98, 64);
            this.BlueTextBox.Name = "BlueTextBox";
            this.BlueTextBox.Size = new System.Drawing.Size(100, 20);
            this.BlueTextBox.TabIndex = 1;
            this.BlueTextBox.Text = "255";
            // 
            // GreenTextBox
            // 
            this.GreenTextBox.Location = new System.Drawing.Point(98, 38);
            this.GreenTextBox.Name = "GreenTextBox";
            this.GreenTextBox.Size = new System.Drawing.Size(100, 20);
            this.GreenTextBox.TabIndex = 2;
            this.GreenTextBox.Text = "255";
            // 
            // SetColorButton
            // 
            this.SetColorButton.Location = new System.Drawing.Point(12, 102);
            this.SetColorButton.Name = "SetColorButton";
            this.SetColorButton.Size = new System.Drawing.Size(75, 23);
            this.SetColorButton.TabIndex = 3;
            this.SetColorButton.Text = "Set Color";
            this.SetColorButton.UseVisualStyleBackColor = true;
            this.SetColorButton.Click += new System.EventHandler(this.SetColorButton_Click);
            // 
            // RedLabel
            // 
            this.RedLabel.AutoSize = true;
            this.RedLabel.Location = new System.Drawing.Point(12, 15);
            this.RedLabel.Name = "RedLabel";
            this.RedLabel.Size = new System.Drawing.Size(27, 13);
            this.RedLabel.TabIndex = 4;
            this.RedLabel.Text = "Red";
            // 
            // BlueLabel
            // 
            this.BlueLabel.AutoSize = true;
            this.BlueLabel.Location = new System.Drawing.Point(12, 67);
            this.BlueLabel.Name = "BlueLabel";
            this.BlueLabel.Size = new System.Drawing.Size(28, 13);
            this.BlueLabel.TabIndex = 5;
            this.BlueLabel.Text = "Blue";
            // 
            // GreenLabel
            // 
            this.GreenLabel.AutoSize = true;
            this.GreenLabel.Location = new System.Drawing.Point(12, 41);
            this.GreenLabel.Name = "GreenLabel";
            this.GreenLabel.Size = new System.Drawing.Size(36, 13);
            this.GreenLabel.TabIndex = 6;
            this.GreenLabel.Text = "Green";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 140);
            this.Controls.Add(this.GreenLabel);
            this.Controls.Add(this.BlueLabel);
            this.Controls.Add(this.RedLabel);
            this.Controls.Add(this.SetColorButton);
            this.Controls.Add(this.GreenTextBox);
            this.Controls.Add(this.BlueTextBox);
            this.Controls.Add(this.RedTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox RedTextBox;
        private System.Windows.Forms.TextBox BlueTextBox;
        private System.Windows.Forms.TextBox GreenTextBox;
        private System.Windows.Forms.Button SetColorButton;
        private System.Windows.Forms.Label RedLabel;
        private System.Windows.Forms.Label BlueLabel;
        private System.Windows.Forms.Label GreenLabel;
    }
}

