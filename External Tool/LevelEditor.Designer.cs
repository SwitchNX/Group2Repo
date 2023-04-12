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
            this.crateColorButton = new System.Windows.Forms.Button();
            this.obstacleColorButton = new System.Windows.Forms.Button();
            this.enemyColorButton = new System.Windows.Forms.Button();
            this.playerColorButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.backgroundColorButton = new System.Windows.Forms.Button();
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
            // crateColorButton
            // 
            this.crateColorButton.BackColor = System.Drawing.Color.LimeGreen;
            this.crateColorButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.crateColorButton.Location = new System.Drawing.Point(11, 109);
            this.crateColorButton.Name = "crateColorButton";
            this.crateColorButton.Size = new System.Drawing.Size(80, 80);
            this.crateColorButton.TabIndex = 0;
            this.crateColorButton.Text = "CRATE\r\n";
            this.crateColorButton.UseVisualStyleBackColor = false;
            this.crateColorButton.Click += new System.EventHandler(this.colorChangeButtonClicked);
            // 
            // obstacleColorButton
            // 
            this.obstacleColorButton.BackColor = System.Drawing.Color.Gray;
            this.obstacleColorButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.obstacleColorButton.ForeColor = System.Drawing.SystemColors.Control;
            this.obstacleColorButton.Location = new System.Drawing.Point(95, 109);
            this.obstacleColorButton.Name = "obstacleColorButton";
            this.obstacleColorButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.obstacleColorButton.Size = new System.Drawing.Size(80, 80);
            this.obstacleColorButton.TabIndex = 1;
            this.obstacleColorButton.Text = "OBSTACLE";
            this.obstacleColorButton.UseVisualStyleBackColor = false;
            this.obstacleColorButton.Click += new System.EventHandler(this.colorChangeButtonClicked);
            // 
            // enemyColorButton
            // 
            this.enemyColorButton.BackColor = System.Drawing.Color.DarkViolet;
            this.enemyColorButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.enemyColorButton.ForeColor = System.Drawing.SystemColors.Control;
            this.enemyColorButton.Location = new System.Drawing.Point(95, 23);
            this.enemyColorButton.Name = "enemyColorButton";
            this.enemyColorButton.Size = new System.Drawing.Size(80, 80);
            this.enemyColorButton.TabIndex = 2;
            this.enemyColorButton.Text = "ENEMY";
            this.enemyColorButton.UseVisualStyleBackColor = false;
            this.enemyColorButton.Click += new System.EventHandler(this.colorChangeButtonClicked);
            // 
            // playerColorButton
            // 
            this.playerColorButton.BackColor = System.Drawing.Color.LightGray;
            this.playerColorButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.playerColorButton.Location = new System.Drawing.Point(11, 23);
            this.playerColorButton.Name = "playerColorButton";
            this.playerColorButton.Size = new System.Drawing.Size(80, 80);
            this.playerColorButton.TabIndex = 5;
            this.playerColorButton.Text = "PLAYER";
            this.playerColorButton.UseVisualStyleBackColor = false;
            this.playerColorButton.Click += new System.EventHandler(this.colorChangeButtonClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.backgroundColorButton);
            this.groupBox1.Controls.Add(this.playerColorButton);
            this.groupBox1.Controls.Add(this.crateColorButton);
            this.groupBox1.Controls.Add(this.obstacleColorButton);
            this.groupBox1.Controls.Add(this.enemyColorButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 284);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Object Selector";
            // 
            // backgroundColorButton
            // 
            this.backgroundColorButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.backgroundColorButton.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.backgroundColorButton.ForeColor = System.Drawing.SystemColors.Control;
            this.backgroundColorButton.Location = new System.Drawing.Point(11, 195);
            this.backgroundColorButton.Name = "backgroundColorButton";
            this.backgroundColorButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.backgroundColorButton.Size = new System.Drawing.Size(164, 80);
            this.backgroundColorButton.TabIndex = 6;
            this.backgroundColorButton.Text = "BACKGROUND";
            this.backgroundColorButton.UseVisualStyleBackColor = false;
            this.backgroundColorButton.Click += new System.EventHandler(this.colorChangeButtonClicked);
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

        private Button crateColorButton;
        private Button obstacleColorButton;
        private Button enemyColorButton;
        private Button playerColorButton;
        private GroupBox groupBox1;
        private Button currentColorSelection;
        private GroupBox groupBox2;
        private Button saveButton;
        private Button loadButton;
        private GroupBox mapGroupBox;
        private PictureBox pictureBox1;
        private Button backgroundColorButton;
        private TextBox timeTextBox;
        private Label label1;
    }
}