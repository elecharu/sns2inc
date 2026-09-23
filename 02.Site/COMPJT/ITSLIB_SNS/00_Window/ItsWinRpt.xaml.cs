using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ITSLIB
{
    /// <summary>
    /// Interaction logic for ItsWinRpt.xaml
    /// </summary>
    public partial class ItsWinRpt : Window
    {
        // public ItsReport Report = null;

        public ItsWinRpt(ItsReport report, bool AutoShowParametersPanel)
        {
            InitializeComponent();
            this.Title = "::: REPORT VIEWER ::";
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.WindowState = WindowState.Maximized;

            this.ITS_REPORT_VIEWER.AutoShowParametersPanel = AutoShowParametersPanel;
            this.ITS_REPORT_VIEWER.DocumentSource = report;

            report.EventPageLoaded();
            report.CreateDocument();
        }
    }
}
