using System;
using System.Collections.Generic;
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
using System.Diagnostics;

namespace AppLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const String STR_APP_PATH = "C:\\Program Files\\chunmeng\\AppExample\\";
        const String STR_APP_NAME = "AppExample.exe";
        const String STR_CONFIG_PATH = STR_APP_PATH + "Xml\\";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void buttonLaunch_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder strArg = new StringBuilder();
            strArg.Append("\"" + STR_CONFIG_PATH); 
            if (radioX.IsChecked == true)
                strArg.Append("ConfigX.xml").Append("\"");
            else if (radioY.IsChecked == true)
                strArg.Append("ConfigY.xml").Append("\"");
            else
                strArg.Append("ConfigZ.xml").Append("\"");

            strArg.Append(" {IPNetAddress}=192.168.1 {UnitIPMin}=101 {UnitIPMax}=108 {UnitDisplayMin}=1 {UnitDisplayMax}=8");
            
            // Check the selection and launch the Park Simulator
            if (radioForA.IsChecked == true)
                strArg.Append(" {Transport}=udp");
            else
                strArg.Append(" {Transport}=tcp");

            // Format the arguments
#if _DEBUG
            MessageBox.Show(STR_APP_PATH + STR_APP_NAME + " " + strArg);
#endif
            
            Process process = new Process();
            // Configure the process using the StartInfo properties.
            process.StartInfo.FileName = STR_APP_PATH + STR_APP_NAME;
            process.StartInfo.Arguments = strArg.ToString();
            process.StartInfo.WorkingDirectory = STR_APP_PATH;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process.Start();
            
            this.Close();
        }
    }
}
