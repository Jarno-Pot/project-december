using System;
using System.Collections.Generic;
using System.IO.Ports;
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

namespace connect_to_arduino
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isConnected = false;
        String[] ports;
        SerialPort port;

        public MainWindow()
        {
            InitializeComponent();
            ports = SerialPort.GetPortNames();

            foreach (string port in ports)
            {
                combox.Items.Add(port);
                Console.WriteLine(port);
                if (ports[0] != null)
                {
                    combox.SelectedItem = ports[0];
                }
            }
        }

        private void bcom_Click(object sender, RoutedEventArgs e)
        {
            if (!isConnected)
            {
                isConnected = true;
                string selectedPort = combox.Text;
                port = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);
                port.Open();
                port.Write("#STAR\n");
            }
            else
            {
                isConnected = false;
                port.Write("#STOP\n");
                port.Close();
            }
        }

        private void bwrite_Click(object sender, RoutedEventArgs e)
        {
            if (isConnected)
            {
                port.Write("#TEXT" + box1.Text + "#\n");
            }
        }

        private void bcalc_Click(object sender, RoutedEventArgs e)
        {
            if (isConnected)
            {
                double _number = 0;
                string _tempnumber = "";
                string _digit = "0123456789,.";
                string _command = "/*-+";
                string _display = "";

                string _string = box1.Text;
                calculator reken = new calculator();

                if (_string.Length >= 1)
                {
                    foreach (char i in _string)
                    {
                        if (_digit.Contains(i))
                        {
                            if (i == '.')
                                _tempnumber += ',';
                            else
                                _tempnumber += i;
                        }
                        else if (_command.Contains(i))
                        {
                            reken.Calc(ref _number, ref _tempnumber, ref _display, i);
                        }
                        else if (i == '=')
                        {
                            reken.Calc(ref _number, ref _tempnumber, ref _display, i);
                            _display += "= " + _number.ToString("0.##");
                            break;
                        }
                    }
                    if (!_display.Contains('='))
                    {
                        reken.Calc(ref _number, ref _tempnumber, ref _display, '=');
                        _display += "= " + _number.ToString("0.##");
                    }

                    if (reken.Commandcase != 6)
                    {
                        port.Write("#TEXT" + _display + "#\n");
                    }
                    else
                    {
                        port.Write("#TEXTWrong input detected#\n");
                    }
                }
                else
                {
                    port.Write("#TEXTNo input detected#\n");
                }
            }
        }
    }
}
