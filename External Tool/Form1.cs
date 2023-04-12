namespace Homework_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void createMapButton_Click(object sender, EventArgs e)
        {
            /*int width = 0;
            int height = 0;

            try 
            {
                width = Convert.ToInt32(widthTextBox.Text);
                height = Convert.ToInt32(heightTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Width and height must be integers");
                return;
            }

            if (width < 10 || height < 10)
            {
                MessageBox.Show("Width and height must be 10 or greater");
                return;
            }

            LevelEditor newEditor = new LevelEditor(width, height);
            */
            //LevelEditor newEditor = new LevelEditor(40, 27);
            LevelEditor newEditor = new LevelEditor(10, 10);
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