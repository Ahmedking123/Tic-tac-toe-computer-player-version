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

namespace Tic_Tac_Toe_Computer_Verson
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        string Player = "X";
        string Computer = "O";
        Button[,] buttons;
        public MainWindow()
        {
            InitializeComponent();
            buttons = new Button[3, 3]
            {
                {btn00,btn01,btn02 },
                {btn10,btn11,btn12 },
                { btn20,btn21,btn22 },
            };
                

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j].Content = null;
                }
            }
        }

        private void btn00_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;

            int column = random.Next(0, 3);
            int row = random.Next(0, 3);


            List<(int,int)> choosed = new List<(int, int)>();


        

            if (button.Content == null)
            {
                button.Content = Player;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (buttons[i, j].Content == null)
                        {
                            choosed.Add((i, j));
                        }
                    }

                }

                if (choosed.Count > 0 && !WinCondition(Player) && !WinCondition(Computer))
                {

                    {
                        (row, column) = choosed[random.Next(choosed.Count)];
                        buttons[row, column].Content = Computer;
                    }
                }
                if (WinCondition(Player))
                {
                    MessageBox.Show($"Player X wins!!");
                }
                else if (WinCondition(Computer))
                {
                    MessageBox.Show($"Player O wins!!");
                }
                else if (DrawCondition())
                {
                    MessageBox.Show("It's a tie");
                }


             



            }
        }
        private bool WinCondition(string currentPlayer)
        {
            for (int i = 0; i < 3;i++)
            {
               
                    if (buttons[i,0].Content?.ToString() == currentPlayer &&
                        buttons[i,1].Content?.ToString() == currentPlayer &&
                        buttons[i,2].Content?.ToString() == currentPlayer)
                    {
                        return true;
                    }
                    else if (buttons[0,i].Content?.ToString() == currentPlayer &&
                             buttons[1,i].Content?.ToString() == currentPlayer &&
                             buttons[2,i].Content?.ToString() == currentPlayer)
                    {
                    return true;
                    }
            }
            if (buttons[0, 0].Content?.ToString() == currentPlayer &&
                buttons[1, 1].Content?.ToString() == currentPlayer &&
                buttons[2, 2].Content?.ToString() == currentPlayer)
            {
                return true;
            }
            else if (buttons[0, 2].Content?.ToString() == currentPlayer &&
                buttons[1,1].Content?.ToString() == currentPlayer &&
                buttons[2, 0].Content?.ToString() == currentPlayer)
            {
                return true;
            } 
            return false;
        }
        private bool DrawCondition()
        {
            for (int i = 0;i < 3;i++)
            {
                for(int j = 0;j < 3;j++)
                {
                    if (buttons[i,j].Content?.ToString() == null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
