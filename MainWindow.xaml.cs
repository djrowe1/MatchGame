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
    using System.Windows.Threading;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //timer
        DispatcherTimer timer = new DispatcherTimer();
        int tenthsOfSecondsElasped;
        int matchesFound;

        public MainWindow()
        {
            InitializeComponent();
            //create time interval tick
            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;
            SetUpGame();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tenthsOfSecondsElasped++;
            timeTextBlock.Text = (tenthsOfSecondsElasped / 10F).ToString("0.0s");
            //stop time and option to reset game
            if (matchesFound == 8)
            {
                timer.Stop();
                timeTextBlock.Text = timeTextBlock.Text + " - Play again?";
            }
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
                
                if (textBlock.Name != "timeTextBlock")
                {
                    //set all text blocks to visible
                    textBlock.Visibility = Visibility.Visible;
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
            //start time and reset time and matches
            timer.Start();
            tenthsOfSecondsElasped = 0;
            matchesFound = 0;

        }

        //class fields
        TextBlock lastTextBlockClicked;
        bool findingMatch = false;

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //object assignmnet
            TextBlock textBlock = sender as TextBlock;
            //play game
            //check to see if this is the first click for emoji textblock
            if(findingMatch == false)       //if so then
            {
                textBlock.Visibility = Visibility.Hidden;       //hide the emoji
                lastTextBlockClicked = textBlock;               //track previous emoji that was clicked on
                findingMatch = true;                            //next click will be finding match
            }
            //if the second click is on a match
            else if (textBlock.Text == lastTextBlockClicked.Text)
            {
                textBlock.Visibility = Visibility.Hidden;       //matching pair, hide current emoji selected
                findingMatch = false;                           //reset toggle for next pair
                matchesFound++;                                 //add match to count
            }
            //otherwise non-matching pair selected - reset
            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;   //make last selection visible
                findingMatch = false;                                   //reset toggle for next attempt
            }
        }

        private void TimeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //reset game
            if (matchesFound == 8)
            {
                SetUpGame();
            }
        }
    }
}
