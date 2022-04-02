using System.Windows.Input;
using MahApps.Metro.Controls;
using System.IO;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System;

namespace ManagedInjector.GUI.UI.MainWindow
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : MetroWindow
	{
		public string reportsPath = Path.Combine(@"C:\windows\temp\", "channel-guide");
		public string currentSelectedFileName;
		public MainWindow()
		{
			InitializeComponent();
			CreateReportDirectory();
			DataContext = new MainWindowVM(this);


		}






		public void CreateReportDirectory()
		{
			if (!Directory.Exists(reportsPath))
				Directory.CreateDirectory(reportsPath);


		}



		private void ReportsGrid_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{


			RefreshReports();
	



		}

		public void RefreshReports()
		{

			DirectoryInfo dirInfo = new DirectoryInfo(this.reportsPath);

			FileInfo[] info = dirInfo.GetFiles("*.txt");            //Get FileInfo and Save it a FileInfo[] Array

			List<ReportFiles> _items = new List<ReportFiles>();          // Define a List with Two coloums

			foreach (FileInfo file in info) //Loop the FileInfo[] Array
				_items.Add(new ReportFiles { Name = file.Name, FullName = file.FullName, LastWriteTime = file.LastWriteTime.ToString("MM/dd/yyyy") });


			ReportsGrid.ItemsSource = _items; //Assign the DataSource to DataGrid

		}

	


		public class ReportFiles
		{
			public string Name { get; set; }
			public string FullName { get; set; }
			public string LastWriteTime { get; set; }
		}

		private void ReportsGrid_MouseEnter(object sender, MouseEventArgs e)
		{
			RefreshReports();
		}



	}
}
