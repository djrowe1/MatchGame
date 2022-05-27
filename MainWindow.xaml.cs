using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetUpGame();

        }

        private void SetUpGame()
        {
            //create list data structure to hold emojis
            List<string> animalEmoji = new List<string>()
            {
                "😊","😊",
                "💕","💕",
                "😍","😍",
                "🥰","🥰",
                "💖","💖",
                "🤷‍♂️","🤷‍♂️",
                "😎","😎",
                "🤣","🤣",
            };

            //create random vari
            Random random = new Random();
            //iterate textblocks to add emojis
            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                //set index to a random element in the list
                int index = random.Next(animalEmoji.Count);
                //assign emoji to string vari
                string nextEmoji = animalEmoji[index];
                //set textBlock value to string containing emoji value
                textBlock.Text = nextEmoji;
                //remove used emoji from current list
                animalEmoji.RemoveAt(index);
            }

        }
    }
}
