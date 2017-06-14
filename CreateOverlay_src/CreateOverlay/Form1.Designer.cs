namespace CreateOverlay
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
            this.open = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.about = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(12, 12);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(102, 23);
            this.open.TabIndex = 0;
            this.open.Text = "Open .cs file";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.button1_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(122, 12);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(102, 23);
            this.save.TabIndex = 1;
            this.save.Text = "Save overlay";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.button2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "C# files (.cs)|*.cs";
            this.openFileDialog1.InitialDirectory = ".\\";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Title = "Save (give a name without extension)";
            // 
            // about
            // 
            this.about.Location = new System.Drawing.Point(12, 41);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(102, 23);
            this.about.TabIndex = 2;
            this.about.Text = "Help";
            this.about.UseVisualStyleBackColor = true;
            this.about.Click += new System.EventHandler(this.button3_Click);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(122, 41);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(102, 23);
            this.exit.TabIndex = 3;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 78);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.about);
            this.Controls.Add(this.save);
            this.Controls.Add(this.open);
            this.Name = "Form1";
            this.Text = "Create overlay";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button open;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button about;
        private System.Windows.Forms.Button exit;

    }
}

