using System.Diagnostics.Eventing.Reader;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using System.Windows.Threading;

namespace FlappyBird
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private bool space = false;
        private double speed = -4.5;

        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(20);
            timer.Tick += Timer_Tick;
        }

        private void Normal()
        {
            cnv_menu.Visibility = Visibility.Hidden;
            cnv_normal.Visibility = Visibility.Visible;
            cnv_normal.Focus();
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            double y = Canvas.GetTop(bird);
            double szorzo = 1;
            if (!space)
            {
                if (speed < 0)
                {
                    Canvas.SetTop(bird, y - ((speed * szorzo) * (speed * szorzo)));
                    speed += 0.5;
                }
                else
                {
                    Canvas.SetTop(bird, y + ((speed * szorzo) * (speed * szorzo)));
                    speed += 0.3;
                }
            }
            else
            {
                timer.Stop();
                JumpReset();
            }
        }

        private void JumpReset()
        {
            speed = -4.5;
            space = false;
            timer.Start();
        }

        private void btn_normal_Click(object sender, RoutedEventArgs e)
        {
            Normal();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                space = true;
            }
        }
    }
}