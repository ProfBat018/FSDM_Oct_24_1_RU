namespace DisconnectedApp
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
            panel1 = new Panel();
            cmdTextBox = new TextBox();
            panel3 = new Panel();
            execBtn = new Button();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(cmdTextBox);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 57);
            panel1.TabIndex = 0;
            // 
            // cmdTextBox
            // 
            cmdTextBox.Dock = DockStyle.Fill;
            cmdTextBox.Location = new Point(0, 0);
            cmdTextBox.Name = "cmdTextBox";
            cmdTextBox.Size = new Size(600, 23);
            cmdTextBox.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(execBtn);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(600, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(200, 57);
            panel3.TabIndex = 0;
            // 
            // execBtn
            // 
            execBtn.Anchor = AnchorStyles.None;
            execBtn.Location = new Point(50, 22);
            execBtn.Name = "execBtn";
            execBtn.Size = new Size(75, 23);
            execBtn.TabIndex = 0;
            execBtn.Text = "Execute";
            execBtn.UseVisualStyleBackColor = true;
            execBtn.Click += execBtn_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridView1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 57);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 393);
            panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(800, 393);
            dataGridView1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox cmdTextBox;
        private Panel panel3;
        private Button execBtn;
        private Panel panel2;
        private DataGridView dataGridView1;
    }
}
