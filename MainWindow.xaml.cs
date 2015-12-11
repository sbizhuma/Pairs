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
using System.Timers;
using System.Diagnostics;
using System.Threading;

namespace Pairs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Stopwatch stopWatch = new Stopwatch();
        int moveCounter = 0;
        List<Button> list = new List<Button>();
        int winCounter = 0;

        private void EmptyTextHandler(object sender, MouseEventArgs e)
        {
            if (searchBox.Text == "Введите никнейм")
                searchBox.Text = string.Empty;

        }

        private void ReturnTextHandler(object sender, MouseEventArgs e)
        {
            gamer.Text = "Игрок:" + Environment.NewLine + searchBox.Text;
            if (searchBox.Text == String.Empty)
            {
                searchBox.Text = "Введите никнейм";
            }
        }
        
        private void NewGameHandler(object sender, RoutedEventArgs e)
        {
            stopWatch.Start();
            time.Text = "Время пошло!";
            foreach (var item in list)
            {
                item.Visibility = Visibility.Visible;
                item.Style = this.FindResource("Closed") as Style;
                item.Content = "";
            }
            list.Clear();
            winCounter = 0;
            moveCounter = 0;

        }

        private void PauseHandler(object sender, RoutedEventArgs e)
        {
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
            time.Text = "Время:" + Environment.NewLine + elapsedTime;

        }
        
        private void MoveHandler(object sender, RoutedEventArgs e)
        {
            moveCounter = moveCounter + 1;
            move.Text = "Ход" + Environment.NewLine + moveCounter;
            Button button = sender as Button;
            Style style = this.FindResource("Opened") as Style;
            button.Style = style;
            button.Content = "J";
            
            list.Add(button);
            if (list.Count % 2 == 0)
            {
                winCounter = winCounter + 1;
                   foreach (var item in list)
                {
                    item.Visibility = Visibility.Hidden;
                    
                }
            }
            if(winCounter==4)
            {
                
                if (stopWatch.IsRunning) {
                    stopWatch.Stop();
                    TimeSpan timeSpan = stopWatch.Elapsed;
                    string elapsedTime = String.Format("{0:00}:{1:00}", timeSpan.Minutes, timeSpan.Seconds);
                    time.Text = "Время:" + Environment.NewLine + elapsedTime;
                    MessageBox.Show("Победа! Вы выиграли за " + moveCounter.ToString() + " ходов! Время: " + elapsedTime);
                }
                else { MessageBox.Show("Победа! Вы выиграли за " + moveCounter.ToString() + " ходов!"); }
            }



        }
    }
}