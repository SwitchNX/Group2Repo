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
            this.crateButton = new System.Windows.Forms.Button();
            this.obstacleButton = new System.Windows.Forms.Button();
            this.enemySmallButton = new System.Windows.Forms.Button();
            this.playerButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.enemyFastButton = new System.Windows.Forms.Button();
            this.enemyLargeButton = new System.Windows.Forms.Button();
            this.crateTallButton = new System.Windows.Forms.Button();
            this.crateWideButton = new System.Windows.Forms.Button();
            this.backgroundButton = new System.Windows.Forms.Button();
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
            // crateButton
            // 
            this.crateButton.BackColor = System.Drawing.Color.LimeGreen;
            this.crateButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.crateButton.Location = new System.Drawing.Point(11, 79);
            this.crateButton.Name = "crateButton";
            this.crateButton.Size = new System.Drawing.Size(50, 50);
            this.crateButton.TabIndex = 0;
            this.crateButton.Text = "CR";
            this.crateButton.UseVisualStyleBackColor = false;
            this.crateButton.Click += new System.EventHandler(this.colorChangeButtonClicked);
            // 
            // obstacleButton
            // 
            this.obstacleButton.BackColor = System.Drawing.Color.Gray;
            this.obstacleButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.obstacleButton.ForeColor = System.Drawing.SystemColors.Control;
            this.obstacleButton.Location = new System.Drawing.Point(67, 22);
            this.obstacleButton.Name = "obstacleButton";
            this.obstacleButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.obstacleButton.Size = new System.Drawing.Size(50, 50);
            this.obstacleButton.TabIndex = 1;
            this.obstacleButton.Text = "OBS";
            this.obstacleButton.UseVisualStyleBackColor = false;
            this.obstacleButton.Click += new System.EventHandler(this.colorChangeButtonClicked);
            // 
            // enemySmallButton
            // 
            this.enemySmallButton.BackColor = System.Drawing.Color.DarkViolet;
            this.enemySmallButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.enemySmallButton.ForeColor = System.Drawing.SystemColors.Control;
            this.enemySmallButton.Location = new System.Drawing.Point(11, 135);
            this.enemySmallButton.Name = "enemySmallButton";
            this.enemySmallButton.Size = new System.Drawing.Size(50, 50);
            this.enemySmallButton.TabIndex = 2;
            this.enemySmallButton.Text = "E-SM";
            this.enemySmallButton.UseVisualStyleBackColor = false;
            this.enemySmallButton.Click += new System.EventHandler(this.colorChangeButtonClicked);
            // 
            // playerButton
            // 
            this.playerButton.BackColor = System.Drawing.Color.LightGray;
            this.playerButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.playerButton.Location = new System.Drawing.Point(11, 23);
            this.playerButton.Name = "playerButton";
            this.playerButton.Size = new System.Drawing.Size(50, 50);
            this.playerButton.TabIndex = 5;
            this.playerButton.Text = "PLA";
            this.playerButton.UseVisualStyleBackColor = false;
            this.playerButton.Click += new System.EventHandler(this.colorChangeButtonClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.enemyFastButton);
            this.groupBox1.Controls.Add(this.enemyLargeButton);
            this.groupBox1.Controls.Add(this.crateTallButton);
            this.groupBox1.Controls.Add(this.crateWideButton);
            this.groupBox1.Controls.Add(this.backgroundButton);
            this.groupBox1.Controls.Add(this.enemySmallButton);
            this.groupBox1.Controls.Add(this.playerButton);
            this.groupBox1.Controls.Add(this.crateButton);
            this.groupBox1.Controls.Add(this.obstacleButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 239);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Object Selector";
            // 
            // enemyFastButton
            // 
            this.enemyFastButton.BackColor = System.Drawing.Color.MediumPurple;
            this.enemyFastButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.enemyFastButton.ForeColor = System.Drawing.SystemColors.Control;
            this.enemyFastButton.Location = new System.Drawing.Point(125, 135);
            this.enemyFastButton.Name = "enemyFastButton";
            this.enemyFastButton.Size = new System.Drawing.Size(50, 50);
            this.enemyFastButton.TabIndex = 10;
            this.enemyFastButton.Text = "E-FS";
            this.enemyFastButton.UseVisualStyleBackColor = false;
            this.enemyFastButton.Click += new System.EventHandler(this.colorChangeButtonClicked);
            // 
            // enemyLargeButton
            // 
            this.enemyLargeButton.BackColor = System.Drawing.Color.Indigo;
            this.enemyLargeButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.enemyLargeButton.ForeColor = System.Drawing.SystemColors.Control;
            this.enemyLargeButton.Location = new System.Drawing.Point(67, 135);
            this.enemyLargeButton.Name = "enemyLargeButton";
            this.enemyLargeButton.Size = new System.Drawing.Size(50, 50);
            this.enemyLargeButton.TabIndex = 9;
            this.enemyLargeButton.Text = "E-LG";
            this.enemyLargeButton.UseVisualStyleBackColor = false;
            this.enemyLargeButton.Click += new System.EventHandler(this.colorChangeButtonClicked);
            // 
            // crateTallButton
            // 
            this.crateTallButton.BackColor = System.Drawing.Color.Lime;
            this.crateTallButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.crateTallButton.Location = new System.Drawing.Point(134, 79);
            this.crateTallButton.Name = "crateTallButton";
            this.crateTallButton.Size = new System.Drawing.Size(30, 50);
            this.crateTallButton.TabIndex = 8;
            this.crateTallButton.Text = "CR-T";
            this.crateTallButton.UseVisualStyleBackColor = false;
            this.crateTallButton.Click += new System.EventHandler(this.colorChangeButtonClicked);
            // 
            // crateWideButton
            // 
            this.crateWideButton.BackColor = System.Drawing.Color.GreenYellow;
            this.crateWideButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.crateWideButton.Location = new System.Drawing.Point(67, 89);
            this.crateWideButton.Name = "crateWideButton";
            this.crateWideButton.Size = new System.Drawing.Size(50, 30);
            this.crateWideButton.TabIndex = 7;
            this.crateWideButton.Text = "CR-W";
            this.crateWideButton.UseVisualStyleBackColor = false;
            this.crateWideButton.Click += new System.EventHandler(this.colorChangeButtonClicked);
            // 
            // backgroundButton
            // 
            this.backgroundButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.backgroundButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.backgroundButton.ForeColor = System.Drawing.SystemColors.Control;
            this.backgroundButton.Location = new System.Drawing.Point(125, 22);
            this.backgroundButton.Name = "backgroundButton";
            this.backgroundButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.backgroundButton.Size = new System.Drawing.Size(50, 50);
            this.backgroundButton.TabIndex = 6;
            this.backgroundButton.Text = "BCK";
            this.backgroundButton.UseVisualStyleBackColor = false;
            this.backgroundButton.Click += new System.EventHandler(this.colorChangeButtonClicked);
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
            this.groupBox2.Location = new System.Drawing.Point(32, 344);
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
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timeTextBox);
            this.Controls.Add(this.mapGroupBox);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
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

        private Button crateButton;
        private Button obstacleButton;
        private Button enemySmallButton;
        private Button playerButton;
        private GroupBox groupBox1;
        private Button currentColorSelection;
        private GroupBox groupBox2;
        private Button saveButton;
        private Button loadButton;
        private GroupBox mapGroupBox;
        private PictureBox pictureBox1;
        private Button backgroundButton;
        private TextBox timeTextBox;
        private Label label1;
        private Button crateTallButton;
        private Button crateWideButton;
        private Button enemyFastButton;
        private Button enemyLargeButton;
    }
}