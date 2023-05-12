using DisplayTimeOut;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;
// using System.Runtime.Remoting.Messaging;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
// using System.Windows.Forms;
using System.Windows.Threading;
// using MessageBox = System.Windows.Forms.MessageBox;

namespace DisplayTimeout
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer MyTimer = new DispatcherTimer();
        private int Countdown = 10;
        private int ShutdownDelay = 20;
        String currentDIrectory = Directory.GetCurrentDirectory();
        public MainWindow()
        {
            InitializeComponent();            
            if (File.Exists(currentDIrectory + @"\logo.png"))
            {
                // il y a une image qui s'appelle logo.png dans le répertoire de l'application
                Logo.Source = new BitmapImage(new Uri(currentDIrectory + @"\logo.png")); // on la charge à la place de celle d'origine
            }
            string[] args = Environment.GetCommandLineArgs();            
            if (args.Length>0)
                try
                {                    
                    Countdown = int.Parse(args[2]);
                    Message1.Content = "Cet ordinateur n'est plus utilisé depuis plus de "+ args[1]+ " minutes";
                    CountDownLabel.Content = "Arrêt de la machine dans " + Countdown + " secondes";                    
                }
                catch { }
            StartTimer();
        }

        public void StartTimer()
        {
            MyTimer.Interval = TimeSpan.FromSeconds(1.0); ;
            MyTimer.Tick += Timer_Tick;
            MyTimer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Countdown--;
            if (Countdown >= 0)
            {
                CountDownLabel.Content = "Arrêt de la machine dans " + Countdown + " secondes";
                
            }
            else
            {
                CountDownLabel.Content = "Arrêt en cours";
                Bouton_Annuler.Content = "Vous avez encore "+ ShutdownDelay.ToString()+" secondes pour annuler l'arrêt";
                MyTimer.Stop();                
                var processStartInfo = new ProcessStartInfo("ShutDown", "/s /t "+ ShutdownDelay.ToString());
                processStartInfo.UseShellExecute = true;
                processStartInfo.CreateNoWindow = false;
                processStartInfo.WindowStyle = ProcessWindowStyle.Normal;
                processStartInfo.WorkingDirectory = Environment.SystemDirectory;
                var start = Process.Start(processStartInfo);
                start.WaitForExit();
                DateTime thisDay = DateTime.Now;                
                var logLine = new string[] { thisDay.ToString("dddd, dd MMMM yyyy HH:mm:ss") + " : Commande shutdown lancée" };
                System.IO.File.AppendAllLines(Path.GetDirectoryName(currentDIrectory) + @"\log.txt", logLine);
                // App.Current.MainWindow.Close();  ne pas fermer la fenêtre, elle sera fermée par la commande shutdown
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyTimer.Stop();
            CancedShutdown();
            DateTime thisDay = DateTime.Now;
            var logLine = new string[] { thisDay.ToString("dddd, dd MMMM yyyy HH:mm:ss")+ " : Arret annulé " };
            System.IO.File.AppendAllLines(Path.GetDirectoryName(currentDIrectory) + @"\log.txt", logLine);
            RestartService("ShutDownService");            
            App.Current.MainWindow.Close();
        }

        private void RestartService(string serviceName)
        {            
            StopWindowsService(serviceName);
            StartWindowsService(serviceName);
        }

        public static void StopWindowsService(string serviceName)
        {
            try
            {
                var processStartInfo = new ProcessStartInfo("net.exe", "stop " + serviceName);
                processStartInfo.UseShellExecute = true;
                processStartInfo.CreateNoWindow = true;
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                processStartInfo.WorkingDirectory = Environment.SystemDirectory;
                var start = Process.Start(processStartInfo);
                start.WaitForExit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void StartWindowsService(string serviceName)
        {
            try
            {
                var processStartInfo = new ProcessStartInfo("net.exe", "start " + serviceName);
                processStartInfo.UseShellExecute = false;
                processStartInfo.CreateNoWindow = true;
                processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                processStartInfo.WorkingDirectory = Environment.SystemDirectory;
                var start = Process.Start(processStartInfo);
                // start.WaitForExit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void CancedShutdown()
        {
            try
            {
                var processStartInfo = new ProcessStartInfo("shutdown", " /a");
                processStartInfo.UseShellExecute = true;
                processStartInfo.CreateNoWindow = false;
                processStartInfo.WindowStyle = ProcessWindowStyle.Normal;
                processStartInfo.WorkingDirectory = Environment.SystemDirectory;
                var start = Process.Start(processStartInfo);
                start.WaitForExit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
