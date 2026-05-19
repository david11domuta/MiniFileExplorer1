namespace MiniFileExplorer1
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
            components = new System.ComponentModel.Container();
            btnBrowse = new Button();
            btnRefresh = new Button();
            treeView1 = new TreeView();
            txtFileContent = new TextBox();
            pictureBox1 = new PictureBox();
            lblStatus = new Label();
            errorProvider1 = new ErrorProvider(components);
            splitContainer1 = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(2, 12);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(94, 29);
            btnBrowse.TabIndex = 0;
            btnBrowse.Text = "btnBrowse";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(102, 12);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(94, 29);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "btnRefresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // treeView1
            // 
            treeView1.Dock = DockStyle.Fill;
            treeView1.Location = new Point(0, 0);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(266, 450);
            treeView1.TabIndex = 2;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 
            // txtFileContent
            // 
            txtFileContent.Dock = DockStyle.Fill;
            txtFileContent.Location = new Point(0, 0);
            txtFileContent.Multiline = true;
            txtFileContent.Name = "txtFileContent";
            txtFileContent.Size = new Size(530, 450);
            txtFileContent.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(530, 450);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Dock = DockStyle.Bottom;
            lblStatus.Location = new Point(0, 430);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(66, 20);
            lblStatus.TabIndex = 5;
            lblStatus.Text = "lblStatus";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(treeView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnRefresh);
            splitContainer1.Panel2.Controls.Add(lblStatus);
            splitContainer1.Panel2.Controls.Add(btnBrowse);
            splitContainer1.Panel2.Controls.Add(txtFileContent);
            splitContainer1.Panel2.Controls.Add(pictureBox1);
            splitContainer1.Panel2.Paint += splitContainer1_Panel2_Paint;
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 266;
            splitContainer1.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnBrowse;
        private Button btnRefresh;
        private TreeView treeView1;
        private TextBox txtFileContent;
        private PictureBox pictureBox1;
        private Label lblStatus;
        private ErrorProvider errorProvider1;
        private SplitContainer splitContainer1;
    }
}
