﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Homework_2
{
    public partial class LevelEditor : Form
    {
        PictureBox[,] map;
        private bool changesAreUnsaved;
        private bool playerPlaced;
        private PictureBox playerBox;
        private int time;

        public LevelEditor(int width, int height)
        {
            InitializeComponent();

            playerPlaced = false;
            generateMap(width, height);
        }

        public LevelEditor(string filename)
        {
            InitializeComponent();

            loadExistingMap(filename, false);
        }

        public void generateMap(int width, int height)
        {
            map = new PictureBox[width, height];

            int boxSize = mapGroupBox.Height / height;
            mapGroupBox.Width = boxSize * width;

            //Resizes the form
            int rightMargin = 43;
            Size newSize = new Size(mapGroupBox.Location.X + mapGroupBox.Width + rightMargin, this.Size.Height);
            this.Size = newSize;

            //Makes and places all of the picture boxes
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    PictureBox newBox = new PictureBox();
                    map[i, j] = newBox;
                    newBox.Width = boxSize;
                    newBox.Height = boxSize;
                    newBox.BackColor = mapGroupBox.BackColor;

                    mapGroupBox.Controls.Add(newBox);

                    Point location = newBox.Location;
                    location.Y += boxSize * j;
                    location.X += boxSize * i;
                    newBox.Location = location;

                    newBox.Click += pictureBoxClicked;

                    changesAreUnsaved = false;
                }
            }

            blackColorButton.BackColor = mapGroupBox.BackColor;
            currentColorSelection.BackColor = Color.LightGray;
        }

        /// <summary>
        /// Changes the color of the button who's color is used to change the 
        /// color of the picture boxes
        /// </summary>
        private void colorChangeButtonClicked(Object sender, EventArgs e)
        {
            Button senderButton = null;
            try
            {
                senderButton = (Button)sender;
            }
            catch
            {
                return;
            }
            currentColorSelection.BackColor = senderButton.BackColor;
        }

        /// <summary>
        /// Changes the color of the selected picture box
        /// </summary
        private void pictureBoxClicked(Object sender, EventArgs e)
        {
            PictureBox box = null;
            try
            {
                box = (PictureBox)sender;
            }
            catch
            {
                return;
            }

            box.BackColor = currentColorSelection.BackColor;

            // This makes sure there are never multiple players at once
            if (box.BackColor == Color.LightGray)
            {
                if (playerPlaced && box != playerBox)
                {
                    playerBox.BackColor = mapGroupBox.BackColor;
                }
                else
                {
                    playerPlaced = true;
                }
                playerBox = box;
               
            }
            else if (box == playerBox)
            {
                playerPlaced = false;
            }
            

            if (!changesAreUnsaved)
            {
                this.Text += " *";
                changesAreUnsaved = true;
            }
        }

        /// <summary>
        /// Saves the level to a .level file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                int time = int.Parse(timeTextBox.Text);
                if (time <= 0)
                {
                    throw new Exception();
                }
            }
            catch
            {
                MessageBox.Show("Time must be a positive integer");
                return;
            }
           
            //Gets the file to save from a user
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Level Files|*.level";
            saveFileDialog.Title = "Save level as";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream outputStream;
                BinaryWriter output = null;

                try
                {
                    outputStream = File.OpenWrite(saveFileDialog.FileName);
                    output = new BinaryWriter(outputStream);

                    //Saves the width, height, and colors
                    output.Write(map.GetLength(0));
                    output.Write(map.GetLength(1));

                    for (int i = 0; i < map.GetLength(0); i++)
                    {
                        for (int j = 0; j < map.GetLength(1); j++)
                        {
                            // File Format:
                            /*
                             * 0 is background
                             * 1 is player
                             * 2 is obstacle
                             * 10 is enemy
                             * 20 is crate
                             */
                        }
                    }

                    //Updates whether changes are saved
                    if (changesAreUnsaved)
                    {
                        this.Text = "Level Editor";
                    }
                    changesAreUnsaved = false;

                    MessageBox.Show("Save completed");
                }
                catch
                {
                    return;
                }
                finally
                {
                    if (output != null)
                    {
                        output.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Asks the user what file to load and loads that map
        /// </summary>
        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Level Files|*.level";

            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                loadExistingMap(openFileDialog.FileName, true);
            }
        }

        /// <summary>
        /// Loads an exisiting file map (doesn't work if there's a file map already loaded)
        /// </summary>
        public void loadExistingMap(string filename, bool mapCurrentlyLoaded)
        {
            FileStream inputStream;
            BinaryReader input = null;

            try
            {
                inputStream = File.OpenRead(filename);
                input = new BinaryReader(inputStream);

                //Makes map 
                int w = input.ReadInt32();
                int h = input.ReadInt32();

                //Clears the map group box if it's got preloaded pictureboxes
                if (mapCurrentlyLoaded)
                {
                    mapGroupBox.Controls.Clear();
                }

                playerPlaced = true;
                generateMap(w, h);

                //Iterate through map and change colors
                for (int i = 0; i < w; i++)
                {
                    for (int j = 0; j < h; j++)
                    {
                        Color thisButtonColor = Color.FromArgb(input.ReadInt32());
                        map[i, j].BackColor = thisButtonColor;
                    }
                }
            }
            catch
            {
                return;
            }
            finally
            {
                if (input != null)
                {
                    input.Close();
                }
            }

            MessageBox.Show("Map loaded successfully");
        }

        /// <summary>
        /// If there are unsaved changes, asks the user if they were sure they want to close
        /// </summary>
        public void OnClose(Object sender, FormClosingEventArgs e)
        {
            if (changesAreUnsaved)
            {
                DialogResult choice = MessageBox.Show("There are unsaved changes. Would you like to quit?", "Unsaved Changes", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (choice == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

    }
}
