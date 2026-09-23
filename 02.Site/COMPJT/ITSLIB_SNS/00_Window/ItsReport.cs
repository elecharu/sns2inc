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
using System.Data;
using DevExpress.Xpf.Core;
using DevExpress.XtraReports.UI;
using DevExpress.Xpf.Printing;
using System.IO;

namespace ITSLIB
{
    public partial class ItsReport : XtraReport
    {
        public ItsReport()
        {
            this.RequestParameters = false;
        }

        public virtual void EventPageLoaded()
        {

        }

        public bool AutoShowParametersPanel = false;

        public void ShowPop()
        {
            ItsWinRpt rpt = new ItsWinRpt(this, AutoShowParametersPanel);
            rpt.ShowDialog();
        }

        public void ShowPreview(DocumentPreviewControl dpc)
        {
            dpc.AutoShowParametersPanel = AutoShowParametersPanel;
            dpc.DocumentSource = this;
            this.EventPageLoaded();
            this.CreateDocument(false);
        }

        private TopMarginBand topMarginBand1;
        private DetailBand detailBand1;
        private Dictionary<string, MemoryStream> RptImage = new Dictionary<string, MemoryStream>();
        public void AddImage(string name, MemoryStream ms)
        {
            if (RptImage.Keys.Contains(name))
            {
                RptImage[name] = ms;
            }
            else
            {
                RptImage.Add(name, ms);
            }
        }

        public MemoryStream GetImage(string name)
        {
            if (RptImage.Keys.Contains(name))
            {
                return RptImage[name];
            }
            else
            {
                return null;
            }
        }

        private Dictionary<string, DataTable> RptTable = new Dictionary<string, DataTable>();
        public void AddTable(string name, DataTable dt)
        {
            if (RptTable.Keys.Contains(name))
            {
                RptTable[name] = dt;
            }
            else
            {
                RptTable.Add(name, dt);
            }
        }

        public DataTable GetTable(string name)
        {
            if (RptTable.Keys.Contains(name))
            {
                return RptTable[name];
            }
            else
            {
                return new DataTable();
            }
        }

        private Dictionary<string, string> RptParam = new Dictionary<string, string>();
        public void AddParam(string name, string value)
        {
            if (RptParam.Keys.Contains(name))
            {
                RptParam[name] = value;
            }
            else
            {
                RptParam.Add(name, value);
            }
        }

        public string GetParam(string name)
        {
            if (RptParam.Keys.Contains(name))
            {
                return RptParam[name].ToString();
            }
            else
            {
                return "";
            }
        }
        public int GetParamInt(string name)
        {
            return ItsString.ParseInt(GetParam(name));
        }
        public decimal GetDecimal(string name)
        {
            return ItsString.ParseDecimal(GetParam(name));
        }
        public DateTime GetParamDateTime(string name)
        {
            return ItsString.ParseDateTime(GetParam(name));
        }

        private void InitializeComponent()
        {
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.detailBand1 = new DevExpress.XtraReports.UI.DetailBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.Dpi = 100F;
            this.topMarginBand1.HeightF = 100F;
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // detailBand1
            // 
            this.detailBand1.Dpi = 100F;
            this.detailBand1.HeightF = 100F;
            this.detailBand1.Name = "detailBand1";
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.Dpi = 100F;
            this.bottomMarginBand1.HeightF = 100F;
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // ItsReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.topMarginBand1,
            this.detailBand1,
            this.bottomMarginBand1});
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        private BottomMarginBand bottomMarginBand1;
    }
}
