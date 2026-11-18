using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using ITSLIB;

namespace TML1010
{
    // 현장터미널 설비부품 출고등록
    public partial class R05 : ITSLIB.ItsPageTml
    {
        ItsModelPanel MODEL_S1 = new ItsModelPanel();
        ItsModelPanel MODEL_A3 = new ItsModelPanel();
        ItsModelPanel MODEL_A1 = new ItsModelPanel();
        ItsModelPanel MODEL_A4 = new ItsModelPanel();
        ItsModelGrid MODEL_G1 = new ItsModelGrid();
        ItsModelGrid MODEL_G2 = new ItsModelGrid();

        private bool filterLoading = false;

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

            MODEL_S1.Binding(PANEL_S1);
            MODEL_S1.InitData();
            MODEL_S1.EventValueChanged += MODEL_S1_EventValueChanged;

            MODEL_A3.Binding(PANEL_A3);
            MODEL_A3.FieldType("ITEMCD", ItsEnums.FieldTypes.String);
            MODEL_A3.FieldType("ITEMNM", ItsEnums.FieldTypes.String);
            MODEL_A3.FieldType("ITEMID", ItsEnums.FieldTypes.String);
            MODEL_A3.FieldType("LOTQTY", ItsEnums.FieldTypes.Decimal);
            MODEL_A3.InitData();
            MODEL_A3.EventValueChanged += MODEL_A3_EventValueChanged;

            MODEL_A1.Binding(PANEL_A1);
            MODEL_A1.FieldType("ITEMID", ItsEnums.FieldTypes.String);
            MODEL_A1.InitData();

            MODEL_A4.Binding(PANEL_A4);
            MODEL_A4.FieldType("ITEMID", ItsEnums.FieldTypes.String);
            MODEL_A4.FieldType("ITEMCD", ItsEnums.FieldTypes.String);
            MODEL_A4.FieldType("ITEMNM", ItsEnums.FieldTypes.String);
            MODEL_A4.FieldType("CURLOCACD", ItsEnums.FieldTypes.String);
            MODEL_A4.FieldType("CURLOCANM", ItsEnums.FieldTypes.String);
            MODEL_A4.InitData();

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
                LoadSearchFilter();
                EventCommand("SEARCH_EQMPARTS");
            }
            catch
            {
                // 화면 확인용 안전 처리
            }

            txt_SCAN.Focus();
        }

        // 조회 조건 중요도등급·로케이션 목록
        private void LoadSearchFilter()
        {
            filterLoading = true;

            ItsMaria.Set("TML1010_R05", "LIST_GRADE");
            DataSet dsGrade = ItsMaria.Call();
            if (!ItsMaria.IsError)
            {
                cmb_S_GRADE.ItemClear();
                cmb_S_GRADE.AddItem(dsGrade.Tables[0], "전체");
            }

            ItsMaria.Set("TML1010_R05", "LIST_LOCA");
            DataSet dsLoca = ItsMaria.Call();
            if (!ItsMaria.IsError)
            {
                cmb_S_LOCACD.ItemClear();
                cmb_S_LOCACD.AddItem("전체", "");
                foreach (DataRow row in dsLoca.Tables[0].Rows)
                {
                    cmb_S_LOCACD.AddItem(row["LOCANM"].ToString(), row["Value"].ToString());
                }
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

        // 출고 팝업 라인 선택 시 해당 라인 설비 목록으로 변경
        private void MODEL_A3_EventValueChanged(string fieldName)
        {
            if (fieldName != "EQMGROUP1") return;

            LoadEqmList(MODEL_A3.GetText("EQMGROUP1"));
        }

        // 라인별 INC 2공장 사용 설비 목록 조회
        private void LoadEqmList(string eqmGroup1)
        {
            cmb_EQMCD.ItemClear();
            MODEL_A3.SetValue("EQMCD", "");
            if (eqmGroup1 == "") return;

            ItsMaria.Set("TML1010_R05", "LIST_EQMCD");
            ItsMaria.AddOne("EQMGROUP1", eqmGroup1);
            DataSet ds = ItsMaria.Call();
            if (ItsMaria.IsError)
            {
                ShowMessageBox("", ItsMaria.ErrMessage);
                return;
            }

            cmb_EQMCD.AddItem(ds.Tables[0], " ");
        }

        // 설비부품 출고등록 팝업 오픈
        private void OpenOutPop(int rowIdx)
        {
            MODEL_A3.InitData();
            MODEL_A3.SetValue("ITEMCD", MODEL_G1.GetText(rowIdx, "ITEMCD"));
            MODEL_A3.SetValue("ITEMID", MODEL_G1.GetText(rowIdx, "ITEMID"));
            MODEL_A3.SetValue("ITEMNM", MODEL_G1.GetText(rowIdx, "ITEMNM"));
            MODEL_A3.SetValue("LOTQTY", MODEL_G1.GetDecimal(rowIdx, "LOTQTY"));
            MODEL_A3.SetValue("OUTDATE", DateTime.Now.ToString("yyyy-MM-dd"));
            MODEL_A3.SetValue("OUTTP", "OUT_01");
            MODEL_A3.SetValue("EMPCD", (ItsMemberShip.EMPCD ?? "").Trim());
            LoadEqmList("");

            PANEL_A3.Show();
            SetPopColor(POP_OUT);
        }

        // 설비부품 바코드 스캔 (스캐너가 Enter 를 붙여 보냄, 라벨 바코드는 품목ID)
        private void Text_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;

            string scanCd = MODEL_S1.GetText("SCANCD").Trim();
            if (scanCd == "") return;

            int rowIdx = FindEqmPartsRow(scanCd);
            if (rowIdx < 0)
            {
                // 조회 조건에 걸려 목록에 없을 수 있으므로 조건을 전체로 풀고 다시 조회
                filterLoading = true;
                MODEL_S1.SetValue("GRADE", "");
                MODEL_S1.SetValue("LOCACD", "");
                filterLoading = false;

                EventCommand("SEARCH_EQMPARTS");
                rowIdx = FindEqmPartsRow(scanCd);
            }

            if (rowIdx < 0)
            {
                MODEL_S1.SetValue("SCANCD", "");
                ShowMessageBox("", "등록되지 않은 설비부품입니다. (" + scanCd + ")");
                txt_SCAN.Focus();
                return;
            }

            MODEL_S1.SetValue("SCANCD", MODEL_G1.GetText(rowIdx, "ITEMCD"));
            MODEL_G1.SelectRow(rowIdx);
            OpenOutPop(rowIdx);
        }

        // 스캔값(품목ID 또는 설비부품코드)과 일치하는 재고 행 찾기
        private int FindEqmPartsRow(string scanCd)
        {
            for (int i = 0; i < MODEL_G1.ModelCount; i++)
            {
                if (MODEL_G1.GetText(i, "ITEMID") == scanCd
                    || string.Equals(MODEL_G1.GetText(i, "ITEMCD"), scanCd, StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }
            return -1;
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
            // 설비부품 출고등록 팝업 오픈
            else if (commandName == "POP_OUT_EQMPARTS")
            {
                if (MODEL_G1.ModelCount <= 0 || MODEL_G1.CurrentIndex < 0)
                {
                    return;
                }

                OpenOutPop(MODEL_G1.CurrentIndex);
            }
            // 설비부품 출고등록 팝업 닫기
            else if (commandName == "CLOSE_POP_OUT")
            {
                PANEL_A3.Close();
                txt_SCAN.Focus();
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
            // 로케이션 지정·해제 팝업 오픈
            else if (commandName == "POP_LOCA")
            {
                if (MODEL_G1.ModelCount <= 0 || MODEL_G1.CurrentIndex < 0)
                {
                    ShowMessageBox("", "로케이션을 지정할 설비부품을 선택해주세요.");
                    return;
                }

                int rowIdx = MODEL_G1.CurrentIndex;

                ItsMaria.Set("TML1010_R05", "LIST_LOCA");
                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                cmb_LOCACD.ItemClear();
                cmb_LOCACD.AddItem(ds.Tables[0], " ");

                MODEL_A4.InitData();
                MODEL_A4.SetValue("ITEMID", MODEL_G1.GetText(rowIdx, "ITEMID"));
                MODEL_A4.SetValue("ITEMCD", MODEL_G1.GetText(rowIdx, "ITEMCD"));
                MODEL_A4.SetValue("ITEMNM", MODEL_G1.GetText(rowIdx, "ITEMNM"));
                MODEL_A4.SetValue("CURLOCACD", MODEL_G1.GetText(rowIdx, "LOCACD"));
                MODEL_A4.SetValue("CURLOCANM", MODEL_G1.GetText(rowIdx, "LOCACD") == "" ? "미지정" : MODEL_G1.GetText(rowIdx, "LOCANM"));
                MODEL_A4.SetValue("LOCACD", MODEL_G1.GetText(rowIdx, "LOCACD"));

                PANEL_A4.Show();
                SetPopColor(POP_LOCA);
            }
            // 로케이션 지정 확인
            else if (commandName == "SET_LOCA")
            {
                if (MODEL_A4.GetText("LOCACD").Trim() == "")
                {
                    ShowMessageBox("", "지정할 로케이션을 선택해주세요.");
                    return;
                }

                ShowMessageBox("SET_LOCA", "로케이션을 지정하시겠습니까?");
            }
            // 로케이션 해제 확인
            else if (commandName == "CLEAR_LOCA")
            {
                if (MODEL_A4.GetText("CURLOCACD") == "")
                {
                    ShowMessageBox("", "지정된 로케이션이 없습니다.");
                    return;
                }

                ShowMessageBox("CLEAR_LOCA", "로케이션을 해제하시겠습니까?");
            }
            // 로케이션 팝업 닫기
            else if (commandName == "CLOSE_POP_LOCA")
            {
                PANEL_A4.Close();
                txt_SCAN.Focus();
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
                txt_SCAN.Focus();
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
            // 설비부품 로케이션 지정·해제 저장
            else if (commandName == "SET_LOCA" || commandName == "CLEAR_LOCA")
            {
                string itemId = MODEL_A4.GetText("ITEMID");

                ItsMaria.Set("TML1010_R05", commandName);
                ItsMaria.AddOne("ITEMID", itemId);
                ItsMaria.AddOne("LOCACD", MODEL_A4.GetText("LOCACD"));

                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                PANEL_A4.Close();
                EventCommand("SEARCH_EQMPARTS");

                int rowIdx = FindEqmPartsRow(itemId);
                if (rowIdx >= 0) MODEL_G1.SelectRow(rowIdx);
                txt_SCAN.Focus();
            }
        }
    }
}
