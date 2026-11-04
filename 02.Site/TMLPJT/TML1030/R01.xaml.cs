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

namespace TML1030
{
    /// <summary>
    /// // 2026-10-27 [생산팀 소모품 입출고] 현장터미널 소모품 재고조회 및 발주연동 입고·출고·이력관리
    /// </summary>
    public partial class R01 : ITSLIB.ItsPageTml
    {
        ItsModelPanel MODEL_S1 = new ItsModelPanel();

        ItsModelPanel MODEL_ODR_S = new ItsModelPanel();
        ItsModelPanel MODEL_IN_INFO = new ItsModelPanel();
        ItsModelPanel MODEL_A2 = new ItsModelPanel();
        ItsModelPanel MODEL_A3 = new ItsModelPanel();
        ItsModelPanel MODEL_A1 = new ItsModelPanel();
        ItsModelGrid MODEL_G1 = new ItsModelGrid();
        ItsModelGrid MODEL_G2 = new ItsModelGrid();
        ItsModelGrid MODEL_ODR = new ItsModelGrid();

        public R01()
        {
            InitializeComponent();

            ResourceDictionary gridStyle = (ResourceDictionary)Application.LoadComponent(new Uri("/ITSLIB;component/00_Style/StyleGrid.xaml", UriKind.Relative));
            Style btnStyle = (Style)gridStyle["gridbuttonstyle"];
            btnStyle.Setters.Clear();

            foreach (SetterBase setter in ((Style)Resources["GRID_BUTTON"]).Setters)
            {
                btnStyle.Setters.Add(setter);
            }

            MODEL_S1.Binding(PANEL_S1);
            MODEL_S1.InitData();

            Resources.MergedDictionaries.Add(gridStyle);

            MODEL_ODR_S.Binding(PANEL_ODR);
            MODEL_ODR_S.InitData();

            MODEL_IN_INFO.Binding(PANEL_IN_INFO);
            MODEL_IN_INFO.InitData();

            MODEL_A2.Binding(PANEL_A2);
            MODEL_A2.FieldType("ITEMID", ItsEnums.FieldTypes.String);
            MODEL_A2.FieldType("MTRODRKEY", ItsEnums.FieldTypes.String);
            MODEL_A2.FieldType("MTRODRSEQ", ItsEnums.FieldTypes.String);
            MODEL_A2.InitData();

            MODEL_A3.Binding(PANEL_A3);
            MODEL_A3.FieldType("ITEMCD", ItsEnums.FieldTypes.String);
            MODEL_A3.FieldType("ITEMID", ItsEnums.FieldTypes.String);
            MODEL_A3.FieldType("LOTQTY", ItsEnums.FieldTypes.Decimal);
            MODEL_A3.InitData();

            MODEL_A1.Binding(PANEL_A1);
            MODEL_A1.FieldType("ITEMID", ItsEnums.FieldTypes.String);
            MODEL_A1.InitData();

            MODEL_G1.Binding(GRID_G1);
            MODEL_G2.Binding(GRID_G2);
            MODEL_ODR.Binding(GRID_ODR);
        }

        public override void EventPageLoaded()
        {
            base.EventPageLoaded();

            PANEL_A2.Close();
            PANEL_A3.Close();
            PANEL_A1.Close();

            MODEL_ODR_S.SetValue("SDATE", DateTime.Now.ToString("yyyy-MM-01"));
            MODEL_ODR_S.SetValue("EDATE", DateTime.Now.ToString("yyyy-MM-dd"));
            MODEL_A1.SetValue("SDATE", DateTime.Now.ToString("yyyy-MM-dd"));
            MODEL_A1.SetValue("EDATE", DateTime.Now.ToString("yyyy-MM-dd"));

            MODEL_S1.SetValue("FACTORYCD", "07");

            try
            {
                EventCommand("SEARCH_PRDCONSUM");
            }
            catch
            {
                // 화면 확인용 안전 처리
            }
        }

        // 2026-10-27 [입출고 팝업] 공통 팝업 동작을 유지 및 컬럼 헤더 배경색 적용
        private void SetPopColor(UserControl pop)
        {
            pop.ApplyTemplate();
            DockPanel title = (DockPanel)pop.Template.FindName("TML_POP_TITLEBAR", pop);
            if (title.Background == Brushes.SteelBlue) return;

            title.Background = Brushes.SteelBlue;
            Canvas close = ItsElement.FindChild<Canvas>(title)[0];
            Style style = new Style(typeof(Canvas), close.Style);
            style.Setters.Add(new Setter(Panel.BackgroundProperty, Brushes.Transparent));
            close.Style = style;
            ItsElement.FindParent<Border>(title).BorderBrush = Brushes.SteelBlue;
        }

        public override void EventCommand(string commandName)
        {
            base.EventCommand(commandName);

            // 소모품 현재고 조회
            if (commandName == "SEARCH_PRDCONSUM")
            {
                ItsMaria.Set("TML1030_R01", "LIST_PRDCONSUM");

                try
                {
                    ItsMaria.AddModel(MODEL_S1);
                    DataSet ds = ItsMaria.Call();
                    if (ItsMaria.IsError)
                    {
                        ShowMessageBox("", "소모품 조회 오류: " + ItsMaria.ErrMessage);
                        return;
                    }

                    MODEL_G1.SetData(ds.Tables[0]);
                }
                catch (Exception ex)
                {
                    ShowMessageBox("", "조회 중 시스템 오류: " + ex.Message);
                }
            }
            // 소모품 입고등록 팝업 오픈 (발주 목록 연동)
            else if (commandName == "POP_IN_PRDCONSUM")
            {
                if (MODEL_G1.ModelCount <= 0 || MODEL_G1.CurrentIndex < 0)
                {
                    return;
                }

                int rowIdx = MODEL_G1.CurrentIndex;

                MODEL_IN_INFO.SetValue("ITEMCD", MODEL_G1.GetText(rowIdx, "ITEMCD"));
                MODEL_IN_INFO.SetValue("ITEMNM", MODEL_G1.GetText(rowIdx, "ITEMNM"));
                MODEL_IN_INFO.SetValue("ITEMSPEC", MODEL_G1.GetText(rowIdx, "ITEMSPEC"));

                MODEL_A2.InitData();
                MODEL_A2.SetValue("ITEMID", MODEL_G1.GetText(rowIdx, "ITEMID"));
                MODEL_A2.SetValue("INDATE", DateTime.Now.ToString("yyyy-MM-dd"));
                MODEL_A2.SetValue("EMPCD", (ItsMemberShip.EMPCD ?? "").Trim());

                EventCommand("SEARCH_ODR_PRDCONSUM");

                PANEL_A2.Show();
                SetPopColor(POP_IN);
            }
            // 발주일자·거래처별 선택 소모품 발주 조회
            else if (commandName == "SEARCH_ODR_PRDCONSUM")
            {
                MODEL_A2.SetValue("MTRODRKEY", "");
                MODEL_A2.SetValue("MTRODRSEQ", "");
                MODEL_A2.SetValue("INQTY", 0);
                MODEL_ODR.Clear();

                ItsMaria.Set("TML1030_R01", "LIST_ODR_PRDCONSUM");
                ItsMaria.AddModel(MODEL_ODR_S);
                ItsMaria.AddOne("ITEMID", MODEL_A2.GetValue("ITEMID"));

                DataSet dsOdr = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }
                MODEL_ODR.SetData(dsOdr.Tables[0]);
                for (int i = 0; i < MODEL_ODR.ModelCount; i++)
                {
                    MODEL_ODR.SetBackColor(i, "WHITE");
                }
            }
            // 입고 발주 단일 선택은 노란색, 선택 해제는 흰색
            else if (commandName == "SEL_ODR")
            {
                if (MODEL_ODR.ModelCount <= 0 || MODEL_ODR.CurrentIndex < 0)
                {
                    return;
                }

                int odrIdx = MODEL_ODR.CurrentIndex;
                if (MODEL_ODR.GetText(odrIdx, "BACKGROUND") == "WHITE")
                {
                    for (int i = 0; i < MODEL_ODR.ModelCount; i++)
                    {
                        if (MODEL_ODR.GetText(i, "BACKGROUND") == "YELLOW")
                        {
                            MODEL_ODR.SetBackColor(i, "WHITE");
                        }
                    }
                    MODEL_ODR.SetBackColor(odrIdx, "YELLOW");
                    MODEL_A2.SetValue("MTRODRKEY", MODEL_ODR.GetText(odrIdx, "MTRODRKEY"));
                    MODEL_A2.SetValue("MTRODRSEQ", MODEL_ODR.GetText(odrIdx, "MTRODRSEQ"));
                    MODEL_A2.SetValue("INQTY", MODEL_ODR.GetDecimal(odrIdx, "REMAINQTY"));
                }
                else
                {
                    MODEL_ODR.SetBackColor(odrIdx, "WHITE");
                    MODEL_A2.SetValue("MTRODRKEY", "");
                    MODEL_A2.SetValue("MTRODRSEQ", "");
                    MODEL_A2.SetValue("INQTY", 0);
                }
            }
            else if (commandName == "IN_PRDCONSUM")
            {
                string odrKey = (MODEL_A2.GetValue("MTRODRKEY") ?? "").ToString();
                if (string.IsNullOrEmpty(odrKey))
                {
                    ShowMessageBox("", "입고할 발주를 선택해주세요.");
                    return;
                }

                decimal inQty = MODEL_A2.GetDecimal("INQTY");
                if (inQty <= 0)
                {
                    ShowMessageBox("", "입고수량을 0보다 크게 입력해주십시오.");
                    return;
                }

                string inDate = (MODEL_A2.GetValue("INDATE") ?? "").ToString();
                if (string.IsNullOrEmpty(inDate))
                {
                    ShowMessageBox("", "입고일자를 입력해주십시오.");
                    return;
                }

                ShowMessageBox("IN_PRDCONSUM", "소모품을 입고하시겠습니까?");
            }
            // 출고 팝업: 로그인 사원 기본값 및 출고자 선택
            else if (commandName == "POP_OUT_PRDCONSUM")
            {
                if (MODEL_G1.ModelCount <= 0 || MODEL_G1.CurrentIndex < 0)
                {
                    return;
                }

                int rowIdx = MODEL_G1.CurrentIndex;

                MODEL_A3.InitData();
                MODEL_A3.SetValue("ITEMCD", MODEL_G1.GetText(rowIdx, "ITEMCD"));
                MODEL_A3.SetValue("ITEMID", MODEL_G1.GetText(rowIdx, "ITEMID"));
                MODEL_A3.SetValue("ITEMNM", MODEL_G1.GetText(rowIdx, "ITEMNM"));
                MODEL_A3.SetValue("LOTQTY", MODEL_G1.GetDecimal(rowIdx, "LOTQTY"));
                MODEL_A3.SetValue("OUTDATE", DateTime.Now.ToString("yyyy-MM-dd"));
                MODEL_A3.SetValue("OUTTP", "OUT_01");
                MODEL_A3.SetValue("EMPCD", ItsMemberShip.EMPCD);

                PANEL_A3.Show();
                SetPopColor(POP_OUT);
            }
            else if (commandName == "OUT_PRDCONSUM")
            {
                decimal outQty = MODEL_A3.GetDecimal("OUTQTY");
                decimal curQty = MODEL_A3.GetDecimal("LOTQTY");
                string outDate = (MODEL_A3.GetValue("OUTDATE") ?? "").ToString();

                if (outQty <= 0)
                {
                    ShowMessageBox("", "출고수량을 0보다 크게 입력해주십시오.");
                    return;
                }

                if (outQty > curQty)
                {
                    ShowMessageBox("", "출고수량이 현재고량(" + curQty.ToString("N0") + ")을 초과할 수 없습니다.");
                    return;
                }

                if (string.IsNullOrEmpty(outDate))
                {
                    ShowMessageBox("", "출고일자를 입력해주십시오.");
                    return;
                }

                ShowMessageBox("OUT_PRDCONSUM", "소모품을 출고하시겠습니까?");
            }
            // 소모품 입출고이력 팝업 오픈
            else if (commandName == "POP_PRDCONSUM_INOUT")
            {
                if (MODEL_G1.ModelCount <= 0 || MODEL_G1.CurrentIndex < 0)
                {
                    return;
                }

                MODEL_A1.SetValue("ITEMID", MODEL_G1.GetText(MODEL_G1.CurrentIndex, "ITEMID"));

                EventCommand("SEARCH_INOUT_PRDCONSUM");

                PANEL_A1.Show();
                SetPopColor(POP_INOUT);
            }
            // 소모품 입출고이력 조회
            else if (commandName == "SEARCH_INOUT_PRDCONSUM")
            {
                ItsMaria.Set("TML1030_R01", "LIST_INOUT_PRDCONSUM");
                ItsMaria.AddModel(MODEL_A1);

                try
                {
                    DataSet ds = ItsMaria.Call();
                    if (ItsMaria.IsError)
                    {
                        ShowMessageBox("", ItsMaria.ErrMessage);
                        return;
                    }
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        MODEL_G2.SetData(ds.Tables[0]);
                    }
                    else
                    {
                        MODEL_G2.Clear();
                    }
                }
                catch (Exception ex)
                {
                    ShowMessageBox("", "이력 조회 중 오류: " + ex.Message);
                }
            }
        }

        // Yes/No 확인창 - Yes 응답 처리
        public override void EventMessageResult(string commandName)
        {
            base.EventMessageResult(commandName);

            // 입고 저장: 선택 발주로 입고이력 등록
            if (commandName == "IN_PRDCONSUM")
            {
                if (MODEL_A2.GetText("MTRODRKEY") == "" || MODEL_A2.GetText("MTRODRSEQ") == "")
                {
                    ShowMessageBox("", "입고할 발주를 선택해주세요.");
                    return;
                }

                ItsMaria.Set("TML1030_R01", "IN_PRDCONSUM");
                ItsMaria.AddModel(MODEL_A2);

                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                PANEL_A2.Close();
                EventCommand("SEARCH_PRDCONSUM");
            }
            // 출고 저장: 선택한 출고자를 입출고 이력에 전달
            else if (commandName == "OUT_PRDCONSUM")
            {
                ItsMaria.Set("TML1030_R01", "OUT_PRDCONSUM");
                ItsMaria.AddOne("FACTORYCD", MODEL_G1.GetValue(MODEL_G1.CurrentIndex, "FACTORYCD"));
                ItsMaria.AddModel(MODEL_A3);

                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                PANEL_A3.Close();
                EventCommand("SEARCH_PRDCONSUM");
            }
        }
    }
}
