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
using MahApps.Metro.Controls;
using System.IO;
using System.Windows.Shapes;
using static ManagedInjector.GUI.UI.MainWindow.MainWindow;

namespace ManagedInjector.GUI.UI.Report
{
    /// <summary>
    /// Interaction logic for ReportDialog.xaml
    /// </summary>
    public partial class ReportDialog : MetroWindow
	{
        public ReportDialog()
        {
            InitializeComponent();





			try
			{

				foreach (Window window in Application.Current.Windows)
				{
					if (window.GetType() == typeof(MainWindow.MainWindow))
					{
						ReportFiles file = (window as MainWindow.MainWindow).ReportsGrid.SelectedItem as ReportFiles;


						this.Title= "Report (" + file.Name + ")";
						ReportResult.Text = File.ReadAllText(file.FullName);

					}
				}

			}
			catch (Exception e)
			{

				MessageBox.Show(e.Message);
			}




		}
	}
}
