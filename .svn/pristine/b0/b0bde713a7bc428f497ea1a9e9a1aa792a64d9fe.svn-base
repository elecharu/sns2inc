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
using System.IO;
using System.Xml;
using System.Data;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ITSLIB;
using System.IO.Ports;
using System.Windows.Threading;
using DevExpress.Xpf.Grid;
using System.Globalization;
using DevExpress.XtraReports.UI;

namespace TML5000
{
    /// <summary>
    /// R01.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class R02 : ITSLIB.ItsPageTml
    {
        ItsModelPanel MODEL_S1 = new ItsModelPanel();
        ItsModelPanel MODEL_A1 = new ItsModelPanel();
        ItsModelPanel MODEL_P1 = new ItsModelPanel();

        ItsModelGrid MODEL_G1 = new ItsModelGrid();
        ItsModelGrid MODEL_G2 = new ItsModelGrid();
        ItsModelGrid MODEL_G3 = new ItsModelGrid();
        ItsModelGrid MODEL_G4 = new ItsModelGrid();

        // 선택 수주리스트 값
        public struct Pruduct
        {
            public string odrkey;
            public string seq;
            public string custcd;
            public string itemid;
        }
        public List<Pruduct> _salodrlist = new List<Pruduct>();

        public R02()
        {
            InitializeComponent();

            MODEL_S1.Binding(PANEL_S1);
            MODEL_S1.DefaultValue("SDATE", DateTime.Now.ToString("yyyy-MM-01"));
            MODEL_S1.InitData();
            MODEL_S1.EventValueChanged += MODEL_S1_EventValueChanged;

            MODEL_A1.Binding(PANEL_A1);
            MODEL_A1.InitData();

            MODEL_P1.Binding(PANEL_P1);
            MODEL_P1.InitData();

            MODEL_G1.Binding(GRID_G1);
            MODEL_G2.Binding(GRID_G2);
            MODEL_G3.Binding(GRID_G3);
            MODEL_G3.EventRowChanged += MODEL_G3_EventRowChanged;
            MODEL_G4.Binding(GRID_G4);
        }

        // 출하처리자 선택, 지정시 스캔이력 모두 초기화하기
        private void MODEL_S1_EventValueChanged(string fieldName)
        {
            if (fieldName == "EMPCD")
            {
                _salodrlist.Clear();

                ItsMaria.Set("TML5000_R02", "RESET_SCANLIST");
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                for (int i = 0; i < MODEL_G1.Rows.Count; i++)
                {
                    if (MODEL_G1.GetValue(i, "BACKGROUND").ToString() == "YELLOW")
                    {
                        MODEL_G1.SetBackColor(i, "WHITE");
                    }
                }
            }
        }

        private void MODEL_G3_EventRowChanged(int rowIndex)
        {
            ItsMaria.Set("TML5000_R02", "LIST_SALOUTLOT_HISTORY");
            ItsMaria.AddOne("SALOUTGROUPKEY", MODEL_G3.GetText(rowIndex, "SALOUTGROUPKEY"));
            ItsMaria.AddOne("OUTTIME", MODEL_G3.GetText(rowIndex, "OUTTIME"));
            ItsMaria.AddOne("TMLCD", ItsLocalInfo.TMLCD);
            DataTable dt = ItsMaria.Call().Tables[0];
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }

            MODEL_G4.SetData(dt);
        }

        public override void EventPageLoaded()
        {
            base.EventPageLoaded();

            PANEL_P1.Close();
        }

        public override void EventCommand(string commandName)
        {
            base.EventCommand(commandName);

            if (commandName == "SEARCH")
            {
                MODEL_G2.Clear();
                MODEL_G1.Clear();
                MODEL_A1.InitData();

                _salodrlist.Clear();
                S1_COMBO_EMPCD.IsEnabled = true;

                ItsMaria.Set("TML5000_R02", "SEL_SALODR");
                ItsMaria.AddModel(MODEL_S1);
                ItsMaria.AddOne("TMLCD", ItsLocalInfo.TMLCD);
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                if (ds.Tables.Count > 2)
                {
                    MODEL_G2.SetData(ds.Tables[1]);

                    ShowMessageBox("", "담당자의 출하스캔이력이 존재 합니다. \r\n출하이력을 먼저 삭제하세요.");
                }
                else
                {
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        ShowMessageBox("", "조회되는 수주가 없습니다.");
                        return;
                    }

                    MODEL_G1.SetData(ds.Tables[0]);
                    (GRID_G1.View as TableView).BestFitColumns();
                }
            }

            else if (commandName == "SEL_SALOUT")
            {
                if (MODEL_G1.GetValue(MODEL_G1.CurrentIndex, "BACKGROUND").ToString() == "WHITE" || MODEL_G1.GetValue(MODEL_G1.CurrentIndex, "BACKGROUND").ToString() == "SKYBLUE")
                {
                    MODEL_G1.SetBackColor(MODEL_G1.CurrentIndex, "YELLOW");
                    _salodrlist.Add(new Pruduct
                    {
                        odrkey = MODEL_G1.GetText(MODEL_G1.CurrentIndex, "SALODRKEY"),
                        seq = MODEL_G1.GetText(MODEL_G1.CurrentIndex, "ODRSEQ"),
                        custcd = MODEL_G1.GetText(MODEL_G1.CurrentIndex, "CUSTCD"),
                        itemid = MODEL_G1.GetText(MODEL_G1.CurrentIndex, "ITEMID")
                    });

                    if (cb_WARECD.Value == string.Empty)
                    {
                        string itemid = MODEL_G1.GetText(MODEL_G1.CurrentIndex, "ITEMID");

                        DataSet ds = ItsMaria.Query("SELECT ITEMCG FROM MSTITEM WHERE ITEMID = '" + itemid + "';");

                        string itemcg = ds.Tables[0].Rows[0]["ITEMCG"].ToString();
                        string warecd = string.Empty;

                        switch (itemcg)
                        {
                            case "DM100100": // 제품
                                warecd = "04S200_N"; // 제품창고
                                break;
                            case "DM100150": // 반제품
                                warecd = "04S111_N"; // 자재투입창고
                                break;
                            case "DM100200": // 상품
                                warecd = "04S140_N"; // 상품출하창고(유상사급)
                                break;
                            case "DM100300": // 원자재
                                warecd = "04S100_N"; // 자재창고(원자재)
                                break;
                        }

                        cb_WARECD.Value = warecd;
                        cb_WARECD.IsEnabled = false;
                    }

                    S1_COMBO_EMPCD.IsEnabled = false;
                    
                }
                else
                {
                    if (MODEL_G2.Rows.Count != 0)
                    {
                        ShowMessageBox("", "스캔이력이 있는 경우는 수주 선택 해제가 불가능 합니다.");
                        return;
                    }

                    if (MODEL_G1.GetInt(MODEL_G1.CurrentIndex, "SALQTY") < Convert.ToInt32(MODEL_G1.GetValue(MODEL_G1.CurrentIndex, "OUTQTY")))
                    {
                        MODEL_G1.SetBackColor(MODEL_G1.CurrentIndex, "SKYBLUE");
                    }
                    else
                    {
                        MODEL_G1.SetBackColor(MODEL_G1.CurrentIndex, "WHITE");
                    }

                    // 선택리스트 제거
                    for (int i = 0; i < _salodrlist.Count; i++)
                    {
                        if (_salodrlist[i].odrkey == MODEL_G1.GetText(MODEL_G1.CurrentIndex, "SALODRKEY") &&
                            _salodrlist[i].seq == MODEL_G1.GetText(MODEL_G1.CurrentIndex, "ODRSEQ"))
                        {
                            _salodrlist.RemoveAt(i);
                            break;
                        }
                    }

                    if (_salodrlist.Count == 0)
                    {
                        S1_COMBO_EMPCD.IsEnabled = true;
                        cb_WARECD.Value = string.Empty;
                        cb_WARECD.IsEnabled = true;
                    }
                }
            }

            // 스캔이력 취소
            else if (commandName == "DEL_SCANLOT")
            {
                ItsMaria.Set("TML5000_R02", "DEL_SCANLOT");
                ItsMaria.AddOne("LOTKEY", MODEL_G2.GetText(MODEL_G2.CurrentIndex, "LOTKEY"));
                ItsMaria.AddOne("EMPCD", MODEL_S1.GetText("EMPCD"));
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_G2.SetData(ds.Tables[0]);

                int SUMSCANQTY = 0;

                for (int i = 0; i < MODEL_G2.Rows.Count; i++)
                {
                    SUMSCANQTY += Convert.ToInt32(MODEL_G2.GetValue(i, "SCANQTY"));
                }

                MODEL_A1.SetValue("SUMQTY", SUMSCANQTY);
            }
            // 출고확정
            else if (commandName == "OUTCONFIRM")
            {
                ShowMessageBox(commandName, "선택한 출하이력을 처리합니다.");
                return;
            }

            // 이력조회
            else if (commandName == "VIEW_LOG")
            {
                MODEL_P1.InitData();
                GRID_G3.Clear();
                GRID_G4.Clear();
                PANEL_P1.Show();
            }

            else if (commandName == "SEARCH_HISTORY")
            {
                GRID_G4.Clear();

                ItsMaria.Set("TML5000_R02", "LIST_SALOUT_HISTORY");
                ItsMaria.AddModel(MODEL_P1);
                ItsMaria.AddOne("TMLCD", ItsLocalInfo.TMLCD);
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                MODEL_G3.SetData(ds.Tables[0]);
            }

            // 거래명세서 발행
            else if (commandName == "REPRINT")
            {
                ItsMaria.Set("TML5000_R02", "PRINT");
                ItsMaria.AddOne("SALOUTGROUPKEY", MODEL_G3.GetText(MODEL_G3.CurrentIndex, "SALOUTGROUPKEY"));
                ItsMaria.AddOne("OUTTIME", MODEL_G3.GetText(MODEL_G3.CurrentIndex, "OUTTIME"));
                ItsMaria.AddOne("OUTLIST", "NO");
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }
                
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ItsMaria.Set("TML5000_R02", "PRINT");
                        ItsMaria.AddOne("OUTLIST", ItsData.GetText(ds.Tables[0], i, "OUTLIST"));
                        DataSet ds2 = ItsMaria.Call();
                        if (ItsMaria.IsError)
                        {
                            ShowMessageBox("", ItsMaria.ErrMessage);
                            return;
                        }
                        //R04B1 rpt = new R04B1(ds2);
                        //rpt.ShowPrintMarginsWarning = false;
                        //rpt.Print(ItsPrinter.BarcodePrintName);
                    }
                }
            }

            else if (commandName == "DEL_SALOUT")
            {
                ShowMessageBox(commandName, "선택한 일자의 출하이력을 삭제합니다.");
                return;
            }
        }

        public override void EventMessageResult(string commandName)
        {
            base.EventMessageResult(commandName);

            if (commandName == "OUTCONFIRM")
            {
                // 출하이력 생성
                ItsMaria.Set("TML5000_R02", "MAKE_SALOUT");
                ItsMaria.AddModel(MODEL_A1);
                if (_salodrlist.Count > 0)
                {
                    for (int i = 0; i < _salodrlist.Count; i++)
                    {
                        ItsMaria.AddList("SALODRLIST", _salodrlist[i].odrkey);
                        ItsMaria.AddList("ODRSEQLIST", _salodrlist[i].seq);
                    }
                }
                else
                {
                    ShowMessageBox("", "선택한 수주가 없습니다.");
                    return;
                }

                if (MODEL_G2.Rows.Count == 0)
                {
                    ShowMessageBox("", "스캔한 재고가 없습니다.");
                    return;
                }

                ItsMaria.AddOne("EMPCD", MODEL_S1.GetValue("EMPCD"));
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                string salGroupkey = ds.Tables[0].Rows[0]["SALOUTGROUPKEY"].ToString();

                _salodrlist.Clear();
                EventCommand("SEARCH");

                MODEL_P1.SetValue("SALOUTGROUPKEY", salGroupkey);
                PANEL_P1.Show();

                EventCommand("SEARCH_HISTORY");
            }

            else if (commandName == "DEL_SALOUT")
            {
                ItsMaria.Set("TML5000_R02", "DEL_SALOUT");
                ItsMaria.AddOne("SALOUTGROUPKEY", MODEL_G3.GetText(MODEL_G3.CurrentIndex, "SALOUTGROUPKEY"));
                ItsMaria.AddOne("OUTTIME", MODEL_G3.GetText(MODEL_G3.CurrentIndex, "OUTTIME"));
                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                EventCommand("SEARCH_HISTORY");
            }
        }

        private void S_LOT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ItsMaria.Set("TML5000_R02", "SCAN_LOT");
                ItsMaria.AddModel(MODEL_S1);
                ItsMaria.AddModel(MODEL_A1);
                if (_salodrlist.Count > 0)
                {
                    for (int i = 0; i < _salodrlist.Count; i++)
                    {
                        ItsMaria.AddList("SALODRLIST", _salodrlist[i].odrkey);
                        ItsMaria.AddList("ODRSEQLIST", _salodrlist[i].seq);
                    }
                }
                else
                {
                    ShowMessageBox("", "선택한 수주가 없습니다.");
                    return;
                }

                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    S_LOT.Value = "";
                    S_LOT.SetFocus();
                    return;
                }

                MODEL_G2.SetData(ds.Tables[0]);

                int SUMSCANQTY = 0;

                for (int i = 0; i < MODEL_G2.Rows.Count; i++)
                {
                    SUMSCANQTY += Convert.ToInt32(MODEL_G2.GetValue(i, "SCANQTY"));
                }

                MODEL_A1.SetValue("SUMQTY", SUMSCANQTY);

                S_LOT.Value = "";
                S_LOT.SetFocus();
            }
        }
    }
}