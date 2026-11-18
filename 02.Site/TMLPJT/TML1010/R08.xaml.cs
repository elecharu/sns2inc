using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ITSLIB;

namespace TML1010
{
    // 현장터미널 설비부품 입고등록
    public partial class R08 : ITSLIB.ItsPageTml
    {
        ItsModelPanel MODEL_S1 = new ItsModelPanel();
        ItsModelPanel MODEL_ODR_S = new ItsModelPanel();
        ItsModelPanel MODEL_IN_INFO = new ItsModelPanel();
        ItsModelPanel MODEL_A2 = new ItsModelPanel();
        ItsModelPanel MODEL_A1 = new ItsModelPanel();
        ItsModelGrid MODEL_G1 = new ItsModelGrid();
        ItsModelGrid MODEL_G2 = new ItsModelGrid();
        ItsModelGrid MODEL_ODR = new ItsModelGrid();

        private bool filterLoading = false;

        public R08()
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

            MODEL_S1.Binding(PANEL_S1);
            MODEL_S1.InitData();
            MODEL_S1.EventValueChanged += MODEL_S1_EventValueChanged;

            MODEL_ODR_S.Binding(PANEL_ODR);
            MODEL_ODR_S.InitData();

            MODEL_IN_INFO.Binding(PANEL_IN_INFO);
            MODEL_IN_INFO.InitData();

            MODEL_A2.Binding(PANEL_A2);
            MODEL_A2.FieldType("ITEMID", ItsEnums.FieldTypes.String);
            MODEL_A2.FieldType("MTRODRKEY", ItsEnums.FieldTypes.String);
            MODEL_A2.FieldType("MTRODRSEQ", ItsEnums.FieldTypes.String);
            MODEL_A2.InitData();

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
            PANEL_A1.Close();

            MODEL_ODR_S.SetValue("SDATE", DateTime.Now.ToString("yyyy-MM-01"));
            MODEL_ODR_S.SetValue("EDATE", DateTime.Now.ToString("yyyy-MM-dd"));
            MODEL_A1.SetValue("SDATE", DateTime.Now.ToString("yyyy-MM-dd"));
            MODEL_A1.SetValue("EDATE", DateTime.Now.ToString("yyyy-MM-dd"));

            try
            {
                LoadSearchFilter();
                EventCommand("SEARCH_EQMPARTS");
            }
            catch
            {
                // 화면 확인용 안전 처리
            }
        }

        // 조회 조건 중요도등급·로케이션 목록
        private void LoadSearchFilter()
        {
            filterLoading = true;

            ItsMaria.Set("TML1010_R08", "LIST_GRADE");
            DataSet dsGrade = ItsMaria.Call();
            if (!ItsMaria.IsError)
            {
                cmb_S_GRADE.ItemClear();
                cmb_S_GRADE.AddItem(dsGrade.Tables[0], "전체");
            }

            ItsMaria.Set("TML1010_R08", "LIST_LOCA");
            DataSet dsLoca = ItsMaria.Call();
            if (!ItsMaria.IsError)
            {
                cmb_S_LOCACD.ItemClear();
                cmb_S_LOCACD.AddItem(dsLoca.Tables[0], "전체");
            }

            MODEL_S1.SetValue("GRADE", "");
            MODEL_S1.SetValue("LOCACD", "");
            filterLoading = false;
        }

        // 조회 조건 중요도등급·로케이션 변경 시 바로 재조회
        private void MODEL_S1_EventValueChanged(string fieldName)
        {
            if (filterLoading) return;
            if (fieldName != "GRADE" && fieldName != "LOCACD") return;

            EventCommand("SEARCH_EQMPARTS");
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
                ItsMaria.Set("TML1010_R08", "LIST_EQMPARTS");
                ItsMaria.AddOne("GRADE", MODEL_S1.GetText("GRADE"));
                ItsMaria.AddOne("LOCACD", MODEL_S1.GetText("LOCACD"));

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
            // 설비부품 입고등록 팝업 오픈
            else if (commandName == "POP_IN_EQMPARTS")
            {
                if (MODEL_G1.ModelCount <= 0 || MODEL_G1.CurrentIndex < 0)
                {
                    return;
                }

                int rowIdx = MODEL_G1.CurrentIndex;
                string itemCd = MODEL_G1.GetText(rowIdx, "ITEMCD");
                string itemNm = MODEL_G1.GetText(rowIdx, "ITEMNM");
                string itemId = MODEL_G1.GetText(rowIdx, "ITEMID");

                MODEL_IN_INFO.SetValue("ITEMCD", itemCd);
                MODEL_IN_INFO.SetValue("ITEMNM", itemNm);
                MODEL_IN_INFO.SetValue("ITEMSPEC", MODEL_G1.GetText(rowIdx, "ITEMSPEC"));

                MODEL_A2.InitData();
                MODEL_A2.SetValue("ITEMID", itemId);
                MODEL_A2.SetValue("INDATE", DateTime.Now.ToString("yyyy-MM-dd"));
                MODEL_A2.SetValue("INTP", "IN_01");
                MODEL_A2.SetValue("EMPCD", (ItsMemberShip.EMPCD ?? "").Trim());

                EventCommand("SEARCH_ODR_EQMPARTS");
                if (ItsMaria.IsError) return;
                PANEL_A2.Show();
                SetPopColor(POP_IN);
            }
            // 발주일자·거래처별 선택 부품 발주 조회
            else if (commandName == "SEARCH_ODR_EQMPARTS")
            {
                MODEL_A2.SetValue("MTRODRKEY", "");
                MODEL_A2.SetValue("MTRODRSEQ", "");
                MODEL_A2.SetValue("INQTY", 0);
                MODEL_ODR.Clear();

                ItsMaria.Set("TML1010_R08", "LIST_ODR_EQMPARTS");
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
            // 입고 대상 발주 행 선택·해제
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
            // 설비부품 입고등록 확인
            else if (commandName == "IN_EQMPARTS")
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

                ShowMessageBox("IN_EQMPARTS", "설비부품을 입고하시겠습니까?");
            }
            // 설비부품 입고이력 팝업 오픈
            else if (commandName == "POP_EQM_IN")
            {
                if (MODEL_G1.ModelCount <= 0 || MODEL_G1.CurrentIndex < 0)
                {
                    return;
                }

                int rowIdx = MODEL_G1.CurrentIndex;
                MODEL_A1.SetValue("ITEMID", MODEL_G1.GetText(rowIdx, "ITEMID"));

                EventCommand("SEARCH_IN_EQMPARTS");
                if (ItsMaria.IsError) return;
                PANEL_A1.Show();
                SetPopColor(POP_IN_HIS);
            }
            // 설비부품 입고이력 조회
            else if (commandName == "SEARCH_IN_EQMPARTS")
            {
                ItsMaria.Set("TML1010_R08", "LIST_IN_EQMPARTS");
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
            // 설비부품 입고취소 확인
            else if (commandName == "CANCEL_IN_EQMPARTS")
            {
                if (MODEL_G2.ModelCount <= 0 || MODEL_G2.CurrentIndex < 0)
                {
                    return;
                }

                ShowMessageBox("CANCEL_IN_EQMPARTS", "입고를 취소하시겠습니까?");
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
                    ItsMaria.Set("TML1010_R08", "LABEL_REPRINT");
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

            // 설비부품 입고 저장 및 라벨 출력
            if (commandName == "IN_EQMPARTS")
            {
                ItsMaria.Set("TML1010_R08", "IN_EQMPARTS");
                ItsMaria.AddModel(MODEL_A2);

                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                PANEL_A2.Close();
                EventCommand("SEARCH_EQMPARTS");

                try
                {
                    PrintLabel(ds);
                }
                catch
                {
                    ShowMessageBox("", "입고는 완료되었습니다. 라벨 출력을 확인해주세요.");
                }
            }
            // 설비부품 입고취소 저장
            else if (commandName == "CANCEL_IN_EQMPARTS")
            {
                ItsMaria.Set("TML1010_R08", "CANCEL_IN_EQMPARTS");
                ItsMaria.AddOne("INOUTKEY", MODEL_G2.GetText(MODEL_G2.CurrentIndex, "INOUTKEY"));

                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                EventCommand("SEARCH_EQMPARTS");
                EventCommand("SEARCH_IN_EQMPARTS");
            }
        }
    }
}
