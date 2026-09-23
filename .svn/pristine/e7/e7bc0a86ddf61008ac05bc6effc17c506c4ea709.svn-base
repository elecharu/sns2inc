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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Editors.Settings;
using DevExpress.Xpf.Printing;
using DevExpress.Xpf.DocumentViewer;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Printing.PreviewControl.Bars;

namespace ITSLIB
{
    public class ItsReportViewer : DocumentPreviewControl
    {
        public ItsReportViewer()
        {
            this.CommandBarStyle = CommandBarStyle.Bars;

            this.AutoShowDocumentMap = true;
            this.AutoShowParametersPanel = false;

            this.CommandProvider = new DocumentCommandProvider();
            RemoveAction ra;

            ra = new RemoveAction();
            ra.ElementName = DefaultPreviewBarItemNames.Save;
            this.CommandProvider.Actions.Add(ra);
            ra = new RemoveAction();
            ra.ElementName = DefaultPreviewBarItemNames.Open;
            this.CommandProvider.Actions.Add(ra);
            ra = new RemoveAction();
            ra.ElementName = DefaultPreviewBarItemNames.DocumentMap;
            this.CommandProvider.Actions.Add(ra);
            ra = new RemoveAction();
            ra.ElementName = DefaultPreviewBarItemNames.Parameters;
            this.CommandProvider.Actions.Add(ra);
            ra = new RemoveAction();
            ra.ElementName = DefaultPreviewBarItemNames.Find;
            this.CommandProvider.Actions.Add(ra);
            ra = new RemoveAction();
            ra.ElementName = DefaultPreviewBarItemNames.Send;
            this.CommandProvider.Actions.Add(ra);
            ra = new RemoveAction();
            ra.ElementName = DefaultPreviewBarItemNames.Scale;
            this.CommandProvider.Actions.Add(ra);
            ra = new RemoveAction();
            ra.ElementName = DefaultPreviewBarItemNames.PageSetup;
            this.CommandProvider.Actions.Add(ra);
            ra = new RemoveAction();
            ra.ElementName = DefaultPreviewBarItemNames.PrintDirect;
            this.CommandProvider.Actions.Add(ra);

            this.Loaded += ItsReportViewer_Loaded;
        }

        private void ItsReportViewer_Loaded(object sender, RoutedEventArgs e)
        {
            // this.CommandBarStyle = CommandBarStyle.Bars;

            //this.AutoShowDocumentMap = true;
            //this.AutoShowParametersPanel = false;
        }
    }
}
