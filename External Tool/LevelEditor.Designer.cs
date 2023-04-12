namespace Homework_2
{
    partial class LevelEditor
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
            this.greenColorButton = new System.Windows.Forms.Button();
            this.blueColorButton = new System.Windows.Forms.Button();
            this.redColorButton = new System.Windows.Forms.Button();
            this.grayColorButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.blackColorButton = new System.Windows.Forms.Button();
            this.currentColorSelection = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.mapGroupBox = new System.Windows.Forms.GroupBox();
            this.timeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // greenColorButton
            // 
            this.greenColorButton.BackColor = System.Drawing.Color.LimeGreen;
            this.greenColorButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.greenColorButton.Location = new System.Drawing.Point(11, 109);
            this.greenColorButton.Name = "greenColorButton";
            this.greenColorButton.Size = new System.Drawing.Size(80, 80);
            this.greenColorButton.TabIndex = 0;
            this.greenColorButton.Text = "CRATE\r\n";
            this.greenColorButton.UseVisualStyleBackColor = false;
            this.greenColorButton.Click += new System.EventHandler(this.colorChangeButtonClicked);
            // 
            // blueColorButton
            // 
            this.blueColorButton.BackColor = System.Drawing.Color.Gray;
            this.blueColorButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.blueColorButton.ForeColor = System.Drawing.SystemColors.Control;
            this.blueColorButton.Location = new System.Drawing.Point(95, 109);
            this.blueColorButton.Name = "blueColorButton";
            this.blueColorButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.blueColorButton.Size = new System.Drawing.Size(80, 80);
            this.blueColorButton.TabIndex = 1;
            this.blueColorButton.Text = "OBSTACLE";
            this.blueColorButton.UseVisualStyleBackColor = false;
            this.blueColorButton.Click += new System.EventHandler(this.colorChangeButtonClicked);
            // 
            // redColorButton
            // 
            this.redColorButton.BackColor = System.Drawing.Color.DarkViolet;
            this.redColorButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.redColorButton.ForeColor = System.Drawing.SystemColors.Control;
            this.redColorButton.Location = new System.Drawing.Point(95, 23);
            this.redColorButton.Name = "redColorButton";
            this.redColorButton.Size = new System.Drawing.Size(80, 80);
            this.redColorButton.TabIndex = 2;
            this.redColorButton.Text = "ENEMY";
            this.redColorButton.UseVisualStyleBackColor = false;
            this.redColorButton.Click += new System.EventHandler(this.colorChangeButtonClicked);
            // 
            // grayColorButton
            // 
            this.grayColorButton.BackColor = System.Drawing.Color.LightGray;
            this.grayColorButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.grayColorButton.Location = new System.Drawing.Point(11, 23);
            this.grayColorButton.Name = "grayColorButton";
            this.grayColorButton.Size = new System.Drawing.Size(80, 80);
            this.grayColorButton.TabIndex = 5;
            this.grayColorButton.Text = "PLAYER";
            this.grayColorButton.UseVisualStyleBackColor = false;
            this.grayColorButton.Click += new System.EventHandler(this.colorChangeButtonClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.blackColorButton);
            this.groupBox1.Controls.Add(this.grayColorButton);
            this.groupBox1.Controls.Add(this.greenColorButton);
            this.groupBox1.Controls.Add(this.blueColorButton);
            this.groupBox1.Controls.Add(this.redColorButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 284);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Object Selector";
            // 
            // blackColorButton
            // 
            this.blackColorButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.blackColorButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.blackColorButton.ForeColor = System.Drawing.SystemColors.Control;
            this.blackColorButton.Location = new System.Drawing.Point(11, 195);
            this.blackColorButton.Name = "blackColorButton";
            this.blackColorButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.blackColorButton.Size = new System.Drawing.Size(164, 80);
            this.blackColorButton.TabIndex = 6;
            this.blackColorButton.Text = "BACKGROUND";
            this.blackColorButton.UseVisualStyleBackColor = false;
            // 
            // currentColorSelection
            // 
            this.currentColorSelection.BackColor = System.Drawing.Color.LightGray;
            this.currentColorSelection.Location = new System.Drawing.Point(22, 22);
            this.currentColorSelection.Name = "currentColorSelection";
            this.currentColorSelection.Size = new System.Drawing.Size(60, 60);
            this.currentColorSelection.TabIndex = 6;
            this.currentColorSelection.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.currentColorSelection);
            this.groupBox2.Location = new System.Drawing.Point(52, 362);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(108, 100);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Current Tile";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(12, 474);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(80, 80);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Save File";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(107, 474);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(80, 80);
            this.loadButton.TabIndex = 9;
            this.loadButton.Tag = "";
            this.loadButton.Text = "Load File";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // mapGroupBox
            // 
            this.mapGroupBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.mapGroupBox.Location = new System.Drawing.Point(205, 12);
            this.mapGroupBox.Name = "mapGroupBox";
            this.mapGroupBox.Size = new System.Drawing.Size(960, 540);
            this.mapGroupBox.TabIndex = 10;
            this.mapGroupBox.TabStop = false;
            this.mapGroupBox.Text = "Map";
            // 
            // timeTextBox
            // 
            this.timeTextBox.Location = new System.Drawing.Point(23, 30);
            this.timeTextBox.Name = "timeTextBox";
            this.timeTextBox.Size = new System.Drawing.Size(164, 23);
            this.timeTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Level Time (seconds)";
            // 
            // LevelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 566);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timeTextBox);
            this.Controls.Add(this.mapGroupBox);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "LevelEditor";
            this.Text = "LevelEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClose);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button greenColorButton;
        private Button blueColorButton;
        private Button redColorButton;
        private Button grayColorButton;
        private GroupBox groupBox1;
        private Button currentColorSelection;
        private GroupBox groupBox2;
        private Button saveButton;
        private Button loadButton;
        private GroupBox mapGroupBox;
        private PictureBox pictureBox1;
        private Button blackColorButton;
        private TextBox timeTextBox;
        private Label label1;
    }
}