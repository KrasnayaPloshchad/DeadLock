using System.Windows;
using DeadLock.Classes;
using Syncfusion.Windows.Shared;

namespace DeadLock.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadTheme();
        }

        internal void LoadTheme()
        {
            StyleManager.ChangeStyle(this);
        }
    }
}
