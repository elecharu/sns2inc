using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ITSLIB;

namespace TML1010
{
    // 현장터미널 설비부품 출고등록
    public partial class R05 : ITSLIB.ItsPageTml
    {
        ItsModelPanel MODEL_A3 = new ItsModelPanel();
        ItsModelPanel MODEL_A1 = new ItsModelPanel();
        ItsModelGrid MODEL_G1 = new ItsModelGrid();
        ItsModelGrid MODEL_G2 = new ItsModelGrid();

        public R05()
        {
            InitializeComponent();

            ResourceDictionary gridStyle = (ResourceDictionary)Application.LoadComponent(new Uri("/ITSLIB;component/00_Style/StyleGrid.xaml", UriKind.Relative));
            Style btnStyle = (Style)gridStyle["gridbuttonstyle"];
            btnStyle.Setters.Clear();
            foreach (SetterBase setter in ((Style)Resources["GRID_BUTTON"]).Setters)
            {
                btnStyle.Setters.Add(setter);
            }
            Resources.MergedDictionaries.Add(gridStyle);

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
        }

        public override void EventPageLoaded()
        {
            base.EventPageLoaded();

            PANEL_A3.Close();
            PANEL_A1.Close();

            MODEL_A1.SetValue("SDATE", DateTime.Now.ToString("yyyy-MM-dd"));
            MODEL_A1.SetValue("EDATE", DateTime.Now.ToString("yyyy-MM-dd"));

            try
            {
                EventCommand("SEARCH_EQMPARTS");
            }
            catch
            {
                // 화면 확인용 안전 처리
            }
        }

        // 팝업 타이틀바 색상 설정
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

            // 설비부품 현재고 조회
            if (commandName == "SEARCH_EQMPARTS")
            {
                ItsMaria.Set("TML1010_R05", "LIST_EQMPARTS");

                try
                {
                    DataSet ds = ItsMaria.Call();
                    if (ItsMaria.IsError)
                    {
                        ShowMessageBox("", "설비부품 조회 오류: " + ItsMaria.ErrMessage);
                        return;
                    }

                    if (ds != null && ds.Tables.Count > 0)
                    {
                        MODEL_G1.SetData(ds.Tables[0]);
                    }
                    else
                    {
                        MODEL_G1.Clear();
                    }
                }
                catch (Exception ex)
                {
                    ShowMessageBox("", "조회 중 시스템 오류: " + ex.Message);
                }
            }
            // 설비부품 출고등록 팝업 오픈
            else if (commandName == "POP_OUT_EQMPARTS")
            {
                if (MODEL_G1.ModelCount <= 0 || MODEL_G1.CurrentIndex < 0)
                {
                    return;
                }

                int rowIdx = MODEL_G1.CurrentIndex;
                string itemCd = MODEL_G1.GetText(rowIdx, "ITEMCD");
                string itemNm = MODEL_G1.GetText(rowIdx, "ITEMNM");
                decimal lotQty = MODEL_G1.GetDecimal(rowIdx, "LOTQTY");

                MODEL_A3.InitData();
                MODEL_A3.SetValue("ITEMCD", itemCd);
                MODEL_A3.SetValue("ITEMID", MODEL_G1.GetText(rowIdx, "ITEMID"));
                MODEL_A3.SetValue("ITEMNM", itemNm);
                MODEL_A3.SetValue("LOTQTY", lotQty);
                MODEL_A3.SetValue("OUTDATE", DateTime.Now.ToString("yyyy-MM-dd"));
                MODEL_A3.SetValue("OUTTP", "OUT_01");
                MODEL_A3.SetValue("EMPCD", (ItsMemberShip.EMPCD ?? "").Trim());

                PANEL_A3.Show();
                SetPopColor(POP_OUT);
            }
            // 설비부품 출고등록 확인
            else if (commandName == "OUT_EQMPARTS")
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

                ShowMessageBox("OUT_EQMPARTS", "설비부품을 출고하시겠습니까?");
            }
            // 설비부품 출고이력 팝업 오픈
            else if (commandName == "POP_EQM_OUT")
            {
                if (MODEL_G1.ModelCount <= 0 || MODEL_G1.CurrentIndex < 0)
                {
                    return;
                }

                int rowIdx = MODEL_G1.CurrentIndex;
                MODEL_A1.SetValue("ITEMID", MODEL_G1.GetText(rowIdx, "ITEMID"));

                EventCommand("SEARCH_OUT_EQMPARTS");
                if (ItsMaria.IsError) return;
                PANEL_A1.Show();
                SetPopColor(POP_OUT_HIS);
            }
            // 설비부품 출고이력 조회
            else if (commandName == "SEARCH_OUT_EQMPARTS")
            {
                ItsMaria.Set("TML1010_R05", "LIST_OUT_EQMPARTS");
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
            // 설비부품 출고취소 확인
            else if (commandName == "CANCEL_OUT_EQMPARTS")
            {
                if (MODEL_G2.ModelCount <= 0 || MODEL_G2.CurrentIndex < 0)
                {
                    return;
                }

                ShowMessageBox("CANCEL_OUT_EQMPARTS", "출고를 취소하시겠습니까?");
            }
            // 라벨출력 버튼 클릭
            else if (commandName == "POP_PRINT_LABEL")
            {
                if (MODEL_G1.ModelCount <= 0 || MODEL_G1.CurrentIndex < 0)
                {
                    return;
                }

                try
                {
                    ItsMaria.Set("TML1010_R05", "LABEL_REPRINT");
                    ItsMaria.AddOne("ITEMID", MODEL_G1.GetText(MODEL_G1.CurrentIndex, "ITEMID"));
                    DataSet ds = ItsMaria.Call();
                    if (ItsMaria.IsError)
                    {
                        ShowMessageBox("", ItsMaria.ErrMessage);
                        return;
                    }
                    PrintLabel(ds);
                }
                catch
                {
                    ShowMessageBox("", "라벨 출력에 실패했습니다. 프린터를 확인해주세요.");
                }
            }
        }

        // 설비부품 바코드 라벨 출력
        private void PrintLabel(DataSet ds)
        {
            if (ds == null || ds.Tables.Count < 2 || ds.Tables[0].Rows.Count == 0 || ds.Tables[1].Rows.Count == 0)
            {
                throw new InvalidOperationException("출력할 라벨 데이터가 없습니다.");
            }

            using (ItsBarcode barcode = new ItsBarcode(ItsData.GetText(ds.Tables[0], 0, "LABELCD")))
            {
                if (!string.IsNullOrEmpty(barcode._ERRMSG))
                {
                    throw new InvalidOperationException(barcode._ERRMSG);
                }
                barcode.SetDataTable(ds.Tables[1]);
                barcode.Print(false);
            }
        }

        // 확인창 응답 처리
        public override void EventMessageResult(string commandName)
        {
            base.EventMessageResult(commandName);

            // 설비부품 출고 저장
            if (commandName == "OUT_EQMPARTS")
            {
                ItsMaria.Set("TML1010_R05", "OUT_EQMPARTS");
                ItsMaria.AddModel(MODEL_A3);

                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                PANEL_A3.Close();
                EventCommand("SEARCH_EQMPARTS");
            }
            // 설비부품 출고취소 저장
            else if (commandName == "CANCEL_OUT_EQMPARTS")
            {
                ItsMaria.Set("TML1010_R05", "CANCEL_OUT_EQMPARTS");
                ItsMaria.AddOne("INOUTKEY", MODEL_G2.GetText(MODEL_G2.CurrentIndex, "INOUTKEY"));

                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                EventCommand("SEARCH_EQMPARTS");
                EventCommand("SEARCH_OUT_EQMPARTS");
            }
        }
    }
}
