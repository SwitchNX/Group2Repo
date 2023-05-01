namespace Homework_2
{
    // Ryan Fogarty
    // Lets the user either create or load a level and begins the level editor

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void createMapButton_Click(object sender, EventArgs e)
        {
            LevelEditor newEditor = new LevelEditor(40, 27);
            newEditor.ShowDialog();
        }

        private void mapLoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Level Files|*.level";
            if (DialogResult.OK == openFileDialog.ShowDialog())
            {
                LevelEditor newEditor = new LevelEditor(openFileDialog.FileName);
                newEditor.ShowDialog();
            }
            
        }
    }
}