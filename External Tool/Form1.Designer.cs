namespace Homework_2
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
            this.mapLoadButton = new System.Windows.Forms.Button();
            this.createMapButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mapLoadButton
            // 
            this.mapLoadButton.Location = new System.Drawing.Point(12, 12);
            this.mapLoadButton.Name = "mapLoadButton";
            this.mapLoadButton.Size = new System.Drawing.Size(237, 73);
            this.mapLoadButton.TabIndex = 0;
            this.mapLoadButton.Text = "Load Map";
            this.mapLoadButton.UseVisualStyleBackColor = true;
            this.mapLoadButton.Click += new System.EventHandler(this.mapLoadButton_Click);
            // 
            // createMapButton
            // 
            this.createMapButton.Location = new System.Drawing.Point(12, 126);
            this.createMapButton.Name = "createMapButton";
            this.createMapButton.Size = new System.Drawing.Size(237, 73);
            this.createMapButton.TabIndex = 2;
            this.createMapButton.Text = "Create Map";
            this.createMapButton.UseVisualStyleBackColor = true;
            this.createMapButton.Click += new System.EventHandler(this.createMapButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 222);
            this.Controls.Add(this.createMapButton);
            this.Controls.Add(this.mapLoadButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button mapLoadButton;
        private Button createMapButton;
    }
}