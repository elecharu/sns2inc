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

namespace TML1010
{
    /// <summary>
    /// // 2026-10-16 [설비부품 입출고] 현장터미널 설비부품 재고조회 및 발주연동 입고·출고·이력관리
    /// </summary>
    public partial class R05 : ITSLIB.ItsPageTml
    {
        ItsModelPanel MODEL_ODR_S = new ItsModelPanel();
        ItsModelPanel MODEL_IN_INFO = new ItsModelPanel();
        ItsModelPanel MODEL_A2 = new ItsModelPanel();
        ItsModelPanel MODEL_A3 = new ItsModelPanel();
        ItsModelPanel MODEL_A1 = new ItsModelPanel();
        ItsModelGrid MODEL_G1 = new ItsModelGrid();
        ItsModelGrid MODEL_G2 = new ItsModelGrid();
        ItsModelGrid MODEL_ODR = new ItsModelGrid();

        
        // 2026-10-16 [설비부품 화면] 공통 버튼 동작을 유지하고 회색 외형 적용
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

            MODEL_ODR_S.Binding(PANEL_ODR);
            MODEL_ODR_S.InitData();

            MODEL_IN_INFO.Binding(PANEL_IN_INFO);
            MODEL_IN_INFO.InitData();

            MODEL_A2.Binding(PANEL_A2);
            MODEL_A2.FieldType("ITEMID", ItsEnums.FieldTypes.String);
            MODEL_A2.FieldType("MTRODRKEY", ItsEnums.FieldTypes.String);
            MODEL_A2.FieldType("MTRODRSEQ", ItsEnums.FieldTypes.String);
            MODEL_A2.FieldType("LOCACD", ItsEnums.FieldTypes.String);
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

            try
            {
                EventCommand("SEARCH_EQMPARTS");
            }
            catch
            {
                // 화면 확인용 안전 처리
            }
        }

        // 2026-10-16 [입출고 팝업] 공통 팝업 동작을 유지하고 참고 화면의 제목줄 색상 적용
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

        // 2026-10-16 [입출고 확인] 공통 DM150 단위 콤보의 표시명 사용
        public override void EventCommand(string commandName)
        {
            base.EventCommand(commandName);

            // 설비부품 현재고 조회
            // 2026-10-19 [설비부품 조회] 미사용 잉여 파라미터(ITEMCD, KEYWORD) 전송 제거
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
            // 설비부품 입고등록 팝업 오픈 (발주 목록 연동)
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
                string itemUnit = MODEL_G1.GetText(rowIdx, "ITEMUNIT");
                string locaCd = MODEL_G1.GetText(rowIdx, "LOCACD");

                MODEL_IN_INFO.SetValue("ITEMCD", itemCd);
                MODEL_IN_INFO.SetValue("ITEMNM", itemNm);
                MODEL_IN_INFO.SetValue("ITEMUNIT", itemUnit);
                MODEL_IN_INFO.SetValue("ITEMSPEC", MODEL_G1.GetText(rowIdx, "ITEMSPEC"));

                // 2026-10-19 [입고 팝업] 미사용 패널 ITEMCD 세팅 제거 및 필수값 초기화
                MODEL_A2.InitData();
                MODEL_A2.SetValue("ITEMID", itemId);
                MODEL_A2.SetValue("INDATE", DateTime.Now.ToString("yyyy-MM-dd"));
                MODEL_A2.SetValue("LOCACD", locaCd);
                MODEL_A2.SetValue("INTP", "IN_01");
                // 2026-10-19 [입고자] 로그인 사원이 없으면 공백으로 초기화
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

                ItsMaria.Set("TML1010_R05", "LIST_ODR_EQMPARTS");
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
            // 2026-10-19 [입고 발주] 단일 선택은 노란색, 선택 해제는 흰색
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
            // 설비부품 입고 버튼 클릭 (확인창 호출)
            else if (commandName == "IN_EQMPARTS")
            {
                decimal inQty = MODEL_A2.GetDecimal("INQTY");
                string inDate = (MODEL_A2.GetValue("INDATE") ?? "").ToString();
                string itemCd = (MODEL_IN_INFO.GetValue("ITEMCD") ?? "").ToString();
                string itemNm = (MODEL_IN_INFO.GetValue("ITEMNM") ?? "").ToString();
                string itemUnit = cmb_IN_UNIT.SelectedLabel;
                string inTp = cmb_INTP.SelectedLabel;
                string odrKey = (MODEL_A2.GetValue("MTRODRKEY") ?? "").ToString();

                if (string.IsNullOrEmpty(odrKey))
                {
                    ShowMessageBox("", "입고할 발주를 선택해주세요.");
                    return;
                }

                if (inQty <= 0)
                {
                    ShowMessageBox("", "입고수량을 0보다 크게 입력해주십시오.");
                    return;
                }

                if (string.IsNullOrEmpty(inDate))
                {
                    ShowMessageBox("", "입고일자를 입력해주십시오.");
                    return;
                }

                string msg = "설비부품을 입고하시겠습니까?"
                    + "\n- 입고일자 : " + inDate
                    + "\n- 부품코드(명) : " + itemCd + " (" + itemNm + ")"
                    + "\n- 입고구분 : " + inTp
                    + "\n- 입고수량 : " + inQty.ToString("N0") + " " + itemUnit;

                if (!string.IsNullOrEmpty(odrKey))
                {
                    msg += "\n- 발주번호 : " + odrKey;
                }

                ShowMessageBox("IN_EQMPARTS", msg);
            }
            // 2026-10-19 [출고 팝업] 로그인 사원 기본값 및 출고자 선택
            else if (commandName == "POP_OUT_EQMPARTS")
            {
                if (MODEL_G1.ModelCount <= 0 || MODEL_G1.CurrentIndex < 0)
                {
                    return;
                }

                int rowIdx = MODEL_G1.CurrentIndex;
                string itemCd = MODEL_G1.GetText(rowIdx, "ITEMCD");
                string itemNm = MODEL_G1.GetText(rowIdx, "ITEMNM");
                string itemUnit = MODEL_G1.GetText(rowIdx, "ITEMUNIT");
                decimal lotQty = MODEL_G1.GetDecimal(rowIdx, "LOTQTY");

                MODEL_A3.InitData();
                MODEL_A3.SetValue("ITEMCD", itemCd);
                MODEL_A3.SetValue("ITEMID", MODEL_G1.GetText(rowIdx, "ITEMID"));
                MODEL_A3.SetValue("ITEMNM", itemNm);
                MODEL_A3.SetValue("ITEMUNIT", itemUnit);
                MODEL_A3.SetValue("LOTQTY", lotQty);
                MODEL_A3.SetValue("OUTDATE", DateTime.Now.ToString("yyyy-MM-dd"));
                MODEL_A3.SetValue("OUTTP", "OUT_01");
                MODEL_A3.SetValue("EMPCD", ItsMemberShip.EMPCD);

                PANEL_A3.Show();
                SetPopColor(POP_OUT);
            }
            // 설비부품 출고 버튼 클릭 (확인창 호출)
            else if (commandName == "OUT_EQMPARTS")
            {
                decimal outQty = MODEL_A3.GetDecimal("OUTQTY");
                decimal curQty = MODEL_A3.GetDecimal("LOTQTY");
                string outDate = (MODEL_A3.GetValue("OUTDATE") ?? "").ToString();
                string itemCd = (MODEL_A3.GetValue("ITEMCD") ?? "").ToString();
                string itemNm = (MODEL_A3.GetValue("ITEMNM") ?? "").ToString();
                string itemUnit = cmb_OUT_UNIT.SelectedLabel;
                string outTp = cmb_OUTTP.SelectedLabel;

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

                ShowMessageBox("OUT_EQMPARTS", "설비부품을 출고하시겠습니까?"
                    + "\n- 출고일자 : " + outDate
                    + "\n- 부품코드(명) : " + itemCd + " (" + itemNm + ")"
                    + "\n- 출고구분 : " + outTp
                    + "\n- 출고수량 : " + outQty.ToString("N0") + " " + itemUnit
                );
            }
            // 설비부품 입출고이력 팝업 오픈
            else if (commandName == "POP_EQM_INOUT")
            {
                if (MODEL_G1.ModelCount <= 0 || MODEL_G1.CurrentIndex < 0)
                {
                    return;
                }

                int rowIdx = MODEL_G1.CurrentIndex;
                MODEL_A1.SetValue("ITEMID", MODEL_G1.GetText(rowIdx, "ITEMID"));

                EventCommand("SEARCH_INOUT_EQMPARTS");
                if (ItsMaria.IsError) return;
                PANEL_A1.Show();
                SetPopColor(POP_INOUT);
            }
            // 설비부품 입출고이력 조회
            else if (commandName == "SEARCH_INOUT_EQMPARTS")
            {
                ItsMaria.Set("TML1010_R05", "LIST_INOUT_EQMPARTS");
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
                catch (Exception ex)
                {
                    ShowMessageBox("", "라벨 출력 실패: " + ex.Message);
                }
            }
        }

        // 2026-10-16 [설비부품 라벨] 공통 라벨 양식에 선택 부품과 수량 전달
        // 2026-10-19 [라벨 출력] 프로시저의 양식코드와 출력 데이터 사용
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

        // Yes/No 확인창 - Yes 응답 처리
        public override void EventMessageResult(string commandName)
        {
            base.EventMessageResult(commandName);

            // 2026-10-19 [입고 저장] 선택 발주 등록 후 응답 데이터로 라벨 출력
            if (commandName == "IN_EQMPARTS")
            {
                if (MODEL_A2.GetText("MTRODRKEY") == "" || MODEL_A2.GetText("MTRODRSEQ") == "")
                {
                    ShowMessageBox("", "입고할 발주를 선택해주세요.");
                    return;
                }

                ItsMaria.Set("TML1010_R05", "IN_EQMPARTS");
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
                catch (Exception ex)
                {
                    ShowMessageBox("", "입고 등록은 완료되었습니다. 라벨 출력에 실패했습니다."
                        + "\n출력 버튼으로 다시 출력해주세요.\n" + ex.Message);
                }
            }
            // 2026-10-19 [출고 저장] 선택한 출고자를 입출고 이력에 전달
            else if (commandName == "OUT_EQMPARTS")
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
        }
    }
}
