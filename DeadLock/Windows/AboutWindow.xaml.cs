using System;
using System.Diagnostics;
using System.Windows;
using DeadLock.Classes;

namespace DeadLock.Windows
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow
    {
        public AboutWindow()
        {
            InitializeComponent();
            LoadTheme();
        }

        private void LoadTheme()
        {
            StyleManager.ChangeStyle(this);
        }

        private void BtnClose_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnLicense_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(AppDomain.CurrentDomain.BaseDirectory + "\\gpl.pdf");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DeadLock", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnCodeDead_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("http://codedead.com/");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DeadLock", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
