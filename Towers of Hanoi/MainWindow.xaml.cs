using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Towers_of_Hanoi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int DiscX;
        public static int Moves = 0;

        public MainWindow()
        {
            InitializeComponent();
        }
        //GetDisc
        public Button GetDisc()
        {
            Button Disc = (Button)Towers_of_Hanoi.FindName("Disc_" + DiscX);
            return Disc;
        }
        //EnableTowerButtons
        public void EnableTowerButtons()
        {
            Tower_A_Button.Visibility = Visibility.Visible;
            Tower_B_Button.Visibility = Visibility.Visible;
            Tower_C_Button.Visibility = Visibility.Visible;
        }
        //DisableTowerButtons
        public void DisableTowerButtons()
        {
            Tower_A_Button.Visibility = Visibility.Hidden;
            Tower_B_Button.Visibility = Visibility.Hidden;
            Tower_C_Button.Visibility = Visibility.Hidden;
        }
        //Unparent All
        public void UnparentAll()
        {
            TowerAStackPanel.Children.Remove(GetDisc());
            TowerBStackPanel.Children.Remove(GetDisc());
            TowerCStackPanel.Children.Remove(GetDisc());
            TowerAHover.Children.Remove(GetDisc());
            TowerBHover.Children.Remove(GetDisc());
            TowerCHover.Children.Remove(GetDisc());
        }
        //Tower Buttons
        private void Tower_A_Button_Click(object sender, RoutedEventArgs e)
        {
            if (CanPlace(0))
            {
                UnparentAll();
                TowerAStackPanel.Children.Add(GetDisc());
                Moves++;
                MoveCounterLabel.Content = "Moves: " + Moves;
                DisableTowerButtons();
            }
        }

        private void Tower_B_Button_Click(object sender, RoutedEventArgs e)
        {
            if (CanPlace(1))
            {
                UnparentAll();
                TowerBStackPanel.Children.Add(GetDisc());
                Moves++;
                MoveCounterLabel.Content = "Moves: " + Moves;
                DisableTowerButtons();
                if (TowerBStackPanel.Children.Count == 8)
                {
                    Finish();
                }
            }
        }

        private void Tower_C_Button_Click(object sender, RoutedEventArgs e)
        {
            if (CanPlace(2))
            {
                UnparentAll();
                TowerCStackPanel.Children.Add(GetDisc());
                Moves++;
                MoveCounterLabel.Content = "Moves: " + Moves;
                DisableTowerButtons();
                if (TowerCStackPanel.Children.Count == 8)
                {
                    Finish();
                }
            }
        }

        private void Tower_A_Button_MouseEnter(object sender, MouseEventArgs e)
        {
            UnparentAll();
            TowerAHover.Children.Add(GetDisc());
        }

        private void Tower_B_Button_MouseEnter(object sender, MouseEventArgs e)
        {
            UnparentAll();
            TowerBHover.Children.Add(GetDisc());
        }

        private void Tower_C_Button_MouseEnter(object sender, MouseEventArgs e)
        {
            UnparentAll();
            TowerCHover.Children.Add(GetDisc());
        }

        //Disc Buttons
        private void Disc_0_Click(object sender, RoutedEventArgs e)
        {
            if (CheckNoHover())
            {
                DiscAction(0, sender);
            }
        }

        private void Disc_1_Click(object sender, RoutedEventArgs e)
        {
            if (CheckNoHover())
            {
                DiscAction(1, sender);
            }
        }

        private void Disc_2_Click(object sender, RoutedEventArgs e)
        {
            if (CheckNoHover())
            {
                DiscAction(2, sender);
            }
        }

        private void Disc_3_Click(object sender, RoutedEventArgs e)
        {
            if (CheckNoHover())
            {
                DiscAction(3, sender);
            }
        }

        private void Disc_4_Click(object sender, RoutedEventArgs e)
        {
            if (CheckNoHover())
            {
                DiscAction(4, sender);
            }
        }

        private void Disc_5_Click(object sender, RoutedEventArgs e)
        {
            if (CheckNoHover())
            {
                DiscAction(5, sender);
            }
        }

        private void Disc_6_Click(object sender, RoutedEventArgs e)
        {
            if (CheckNoHover())
            {
                DiscAction(6, sender);
            }
        }

        private void Disc_7_Click(object sender, RoutedEventArgs e)
        {
            if (CheckNoHover())
            {
                DiscAction(7, sender);
            }
        }
        //Disc Action
        public void DiscAction(int _DiscX, object sender)
        {
            FrameworkElement parent = (FrameworkElement)((Button)sender).Parent;
            StackPanel TowerStackPanel = (StackPanel)Towers_of_Hanoi.FindName(parent.Name);
            Button DiscIndex = (Button)Towers_of_Hanoi.FindName(string.Format("Disc_{0}", _DiscX));
            if (TowerStackPanel.Children.IndexOf(DiscIndex) == TowerStackPanel.Children.Count - 1)
            {
                DiscX = _DiscX;
                UnparentAll();
                EnableTowerButtons();
            }
        }
        //Check No Hover
        public bool CheckNoHover()
        {
            bool CheckNoHover;
            if (TowerAHover.Children.Count > 0)
            {
                CheckNoHover = false;
            }
            else if (TowerBHover.Children.Count > 0)
            {
                CheckNoHover = false;
            }
            else if (TowerCHover.Children.Count > 0)
            {
                CheckNoHover = false;
            }
            else
            {
                CheckNoHover = true;
            }
            return CheckNoHover;
        }
        //Can Place
        public bool CanPlace(int Tower)
        {
            bool CanPlace = true;
            if (Tower == 0)
            {
                for (int i = 1; i < DiscX + 1; i++)
                {
                    if (TowerAStackPanel.Children.Contains((Button)FindName(string.Format("Disc_{0}", int.Parse((string)GetDisc().Tag) + i))))
                    {
                        CanPlace = false;
                    }
                }
                if (TowerAStackPanel.Children.Count == 0)
                {
                    CanPlace = true;
                }
            }
            else if (Tower == 1)
            {
                for (int i = 0; i < DiscX; i++)
                {
                    if (TowerBStackPanel.Children.Contains((Button)FindName(string.Format("Disc_{0}", int.Parse((string)GetDisc().Tag) + i))))
                    {
                        CanPlace = false;
                    }
                }
                if (TowerBStackPanel.Children.Count == 0)
                {
                    CanPlace = true;
                }
            }
            else if (Tower == 2)
            {
                for (int i = 0; i < DiscX; i++)
                {
                    if (TowerCStackPanel.Children.Contains((Button)FindName(string.Format("Disc_{0}", int.Parse((string)GetDisc().Tag) + i))))
                    {
                        CanPlace = false;
                    }
                }
                if (TowerCStackPanel.Children.Count == 0)
                {
                    CanPlace = true;
                }
            }
            else
            {
                CanPlace = true;
            }

            return CanPlace;
        }

        public void Finish()
        {
            MovesLabel.Content = string.Format("You Completed it in {0} Moves", Moves);
            FinishScreenBlur.Visibility = Visibility.Visible;
        }

        public void Restart()
        {
            FinishScreenBlur.Visibility = Visibility.Hidden;
            ResetDiscs();
            Moves = 0;
            MoveCounterLabel.Content = "Moves: 0";
        }
        public void ResetDiscs()
        {
            TowerAStackPanel.Children.Remove(Disc_0);
            TowerAStackPanel.Children.Remove(Disc_1);
            TowerAStackPanel.Children.Remove(Disc_2);
            TowerAStackPanel.Children.Remove(Disc_3);
            TowerAStackPanel.Children.Remove(Disc_4);
            TowerAStackPanel.Children.Remove(Disc_5);
            TowerAStackPanel.Children.Remove(Disc_6);
            TowerAStackPanel.Children.Remove(Disc_7);
            TowerBStackPanel.Children.Remove(Disc_0);
            TowerBStackPanel.Children.Remove(Disc_1);
            TowerBStackPanel.Children.Remove(Disc_2);
            TowerBStackPanel.Children.Remove(Disc_3);
            TowerBStackPanel.Children.Remove(Disc_4);
            TowerBStackPanel.Children.Remove(Disc_5);
            TowerBStackPanel.Children.Remove(Disc_6);
            TowerBStackPanel.Children.Remove(Disc_7);
            TowerCStackPanel.Children.Remove(Disc_0);
            TowerCStackPanel.Children.Remove(Disc_1);
            TowerCStackPanel.Children.Remove(Disc_2);
            TowerCStackPanel.Children.Remove(Disc_3);
            TowerCStackPanel.Children.Remove(Disc_4);
            TowerCStackPanel.Children.Remove(Disc_5);
            TowerCStackPanel.Children.Remove(Disc_6);
            TowerCStackPanel.Children.Remove(Disc_7);
            TowerAStackPanel.Children.Add(Disc_0);
            TowerAStackPanel.Children.Add(Disc_1);
            TowerAStackPanel.Children.Add(Disc_2);
            TowerAStackPanel.Children.Add(Disc_3);
            TowerAStackPanel.Children.Add(Disc_4);
            TowerAStackPanel.Children.Add(Disc_5);
            TowerAStackPanel.Children.Add(Disc_6);
            TowerAStackPanel.Children.Add(Disc_7);
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            Restart();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TryAgainButton_Click(object sender, RoutedEventArgs e)
        {
            Restart();
        }
    }
}
