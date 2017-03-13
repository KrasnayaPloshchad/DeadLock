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
using System.Windows.Shapes;

namespace DeadLock.Windows
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow
    {
        #region Variables
        private readonly MainWindow _mw;
        #endregion

        public SettingsWindow(MainWindow mainWindow)
        {
            _mw = mainWindow;
            InitializeComponent();

            LoadSettings();
        }

        private void LoadSettings()
        {
            try
            {
                ChbAutoUpdate.IsChecked = Properties.Settings.Default.AutoUpdate;
                ChbAdminWarning.IsChecked = Properties.Settings.Default.AdminWarning;
                ChbStartMinimized.IsChecked = Properties.Settings.Default.StartMinimized;

                CboStyle.SelectedValue = Properties.Settings.Default.VisualStyle;
                CpMetroBrush.Color = Properties.Settings.Default.MetroColor;
                IntBorderThickness.Value = Properties.Settings.Default.BorderThickness;

                ChbAutoOwnership.IsChecked = Properties.Settings.Default.AutoOwnership;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DeadLock", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
