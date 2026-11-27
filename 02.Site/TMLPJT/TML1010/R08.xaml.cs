using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ITSLIB;
using DevExpress.Xpf.Grid;

namespace TML1010
{
    // 현장터미널 설비부품 입고등록 (태블릿용 탭: [입고등록] 발주 선택 후 품목별 입고수량 입력 / [입고취소] 입고 이력 취소·라벨 재발행)
    public partial class R08 : ITSLIB.ItsPageTml
    {
        ItsModelPanel MODEL_S1 = new ItsModelPanel();
        ItsModelPanel MODEL_A2 = new ItsModelPanel();
        ItsModelPanel MODEL_S2 = new ItsModelPanel();
        ItsModelGrid MODEL_G1 = new ItsModelGrid();
        ItsModelGrid MODEL_G2 = new ItsModelGrid();
        ItsModelGrid MODEL_G3 = new ItsModelGrid();

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

            MODEL_A2.Binding(PANEL_A2);
            MODEL_A2.FieldType("MTRODRKEY", ItsEnums.FieldTypes.String);
            MODEL_A2.InitData();

            MODEL_S2.Binding(PANEL_S2);
            MODEL_S2.InitData();

            MODEL_G1.Binding(GRID_G1);
            MODEL_G2.Binding(GRID_G2);
            MODEL_G3.Binding(GRID_G3);

            // 태블릿용 그리드 표시: 컬럼을 그리드 폭에 맞춤(가로 스크롤 없음), 행 머리 칸 숨김, 행 높이 키움
            foreach (TableView view in new TableView[] { GRID_G1.View as TableView, GRID_G2.View as TableView, GRID_G3.View as TableView })
            {
                view.AutoWidth = true;
                view.ShowIndicator = false;
                view.RowMinHeight = 40;
            }
        }

        public override void EventPageLoaded()
        {
            base.EventPageLoaded();

            MODEL_S1.SetValue("SDATE", DateTime.Now.ToString("yyyy-MM-01"));
            MODEL_S1.SetValue("EDATE", DateTime.Now.ToString("yyyy-MM-dd"));
            MODEL_S1.SetValue("FACTORYCD", "07");

            MODEL_A2.SetValue("INDATE", DateTime.Now.ToString("yyyy-MM-dd"));
            MODEL_A2.SetValue("INTP", "IN_01");

            // 입고자 기본값 = 로그인 사원. 공통 Pop 은 자기 Loaded 에서 필드명을 잡으므로 그 전에 값을 넣으면 'SetPopInfo GPCD is empty' 오류 → Pop 로드 뒤에 넣음
            if (pop_IN_EMP.FieldName != "")
            {
                SetDefaultInEmp(null, null);
            }
            else
            {
                pop_IN_EMP.Loaded += SetDefaultInEmp;
            }

            MODEL_S2.SetValue("SDATE", DateTime.Now.ToString("yyyy-MM-dd"));
            MODEL_S2.SetValue("EDATE", DateTime.Now.ToString("yyyy-MM-dd"));
            MODEL_S2.SetValue("FACTORYCD", "07");

            try
            {
                EventCommand("SEARCH_MTRODR");
                EventCommand("SEARCH_IN_EQMPARTS");
            }
            catch
            {
                // 화면 확인용 안전 처리
            }
        }

        // 입고자 기본값(로그인 사원) 넣기
        private void SetDefaultInEmp(object sender, RoutedEventArgs e)
        {
            pop_IN_EMP.Loaded -= SetDefaultInEmp;
            MODEL_A2.SetValue("EMPCD", (ItsMemberShip.EMPCD ?? "").Trim());
        }

        // 발주 목록 재조회 후 선택했던 발주가 남아 있으면 다시 선택
        private void ReloadMtrodr()
        {
            string odrKey = MODEL_A2.GetText("MTRODRKEY");
            EventCommand("SEARCH_MTRODR");
            if (ItsMaria.IsError || string.IsNullOrEmpty(odrKey)) return;

            for (int i = 0; i < MODEL_G1.ModelCount; i++)
            {
                if (MODEL_G1.GetText(i, "MTRODRKEY") == odrKey)
                {
                    MODEL_G1.SetBackColor(i, "YELLOW");
                    MODEL_A2.SetValue("MTRODRKEY", odrKey);
                    EventCommand("SEARCH_MTRODRD");
                    return;
                }
            }
        }

        // 입고 이력 체크 건수
        private int CheckedCount()
        {
            int cnt = 0;
            for (int i = 0; i < MODEL_G3.ModelCount; i++)
            {
                if (MODEL_G3.IsChecked(i)) cnt++;
            }
            return cnt;
        }

        // 체크한 입고 이력 키 목록 추가
        private void AddCheckedInoutKey()
        {
            for (int i = 0; i < MODEL_G3.ModelCount; i++)
            {
                if (!MODEL_G3.IsChecked(i)) continue;
                ItsMaria.AddList("INOUTKEY_LIST", MODEL_G3.GetText(i, "INOUTKEY"));
            }
        }

        public override void EventCommand(string commandName)
        {
            base.EventCommand(commandName);

            // [입고등록] 발주 조회 (발주일자·공장·거래처)
            if (commandName == "SEARCH_MTRODR")
            {
                MODEL_A2.SetValue("MTRODRKEY", "");
                MODEL_G1.Clear();
                MODEL_G2.Clear();

                ItsMaria.Set("TML1010_R08", "LIST_MTRODR");
                ItsMaria.AddModel(MODEL_S1);

                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", "발주 조회 오류: " + ItsMaria.ErrMessage);
                    return;
                }
                MODEL_G1.SetData(ds.Tables[0]);
                for (int i = 0; i < MODEL_G1.ModelCount; i++)
                {
                    MODEL_G1.SetBackColor(i, "WHITE");
                }
            }
            // [입고등록] 입고할 발주 선택·해제
            else if (commandName == "SEL_ODR")
            {
                if (MODEL_G1.ModelCount <= 0 || MODEL_G1.CurrentIndex < 0)
                {
                    return;
                }

                int odrIdx = MODEL_G1.CurrentIndex;
                if (MODEL_G1.GetText(odrIdx, "BACKGROUND") == "WHITE")
                {
                    for (int i = 0; i < MODEL_G1.ModelCount; i++)
                    {
                        if (MODEL_G1.GetText(i, "BACKGROUND") == "YELLOW")
                        {
                            MODEL_G1.SetBackColor(i, "WHITE");
                        }
                    }
                    MODEL_G1.SetBackColor(odrIdx, "YELLOW");
                    MODEL_A2.SetValue("MTRODRKEY", MODEL_G1.GetText(odrIdx, "MTRODRKEY"));
                    EventCommand("SEARCH_MTRODRD");
                }
                else
                {
                    MODEL_G1.SetBackColor(odrIdx, "WHITE");
                    MODEL_A2.SetValue("MTRODRKEY", "");
                    MODEL_G2.Clear();
                }
            }
            // [입고등록] 선택 발주 품목 조회 (입고수량 기본값 = 미입고량)
            else if (commandName == "SEARCH_MTRODRD")
            {
                ItsMaria.Set("TML1010_R08", "LIST_MTRODRD");
                ItsMaria.AddOne("MTRODRKEY", MODEL_A2.GetText("MTRODRKEY"));

                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }
                MODEL_G2.SetData(ds.Tables[0]);
            }
            // [입고등록] 설비부품 입고등록 확인
            else if (commandName == "IN_EQMPARTS")
            {
                if (MODEL_G2.ModelCount <= 0)
                {
                    ShowMessageBox("", "입고할 발주를 선택해주세요.");
                    return;
                }

                ShowMessageBox("IN_EQMPARTS", "설비부품을 입고하시겠습니까?");
            }
            // [입고취소] 입고 이력 조회 (입고일자·공장·거래처)
            else if (commandName == "SEARCH_IN_EQMPARTS")
            {
                ItsMaria.Set("TML1010_R08", "LIST_IN_EQMPARTS");
                ItsMaria.AddModel(MODEL_S2);

                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", "이력 조회 오류: " + ItsMaria.ErrMessage);
                    return;
                }
                MODEL_G3.SetData(ds.Tables[0]);
            }
            // [입고취소] 체크한 입고 이력 입고취소 확인
            else if (commandName == "CANCEL_IN_EQMPARTS")
            {
                int cnt = CheckedCount();
                if (cnt == 0)
                {
                    ShowMessageBox("", "입고 취소할 이력을 체크해주세요.");
                    return;
                }

                ShowMessageBox("CANCEL_IN_EQMPARTS", "체크한 입고 이력 " + cnt + "건의 입고를 취소하시겠습니까?");
            }
            // [입고취소] 체크한 입고 이력 라벨 재발행
            else if (commandName == "LABEL_REPRINT")
            {
                if (CheckedCount() == 0)
                {
                    ShowMessageBox("", "라벨을 재발행할 이력을 체크해주세요.");
                    return;
                }

                try
                {
                    ItsMaria.Set("TML1010_R08", "LABEL_REPRINT");
                    AddCheckedInoutKey();
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

            // 선택 발주 품목별 입고수량 저장 및 라벨 출력
            if (commandName == "IN_EQMPARTS")
            {
                ItsMaria.Set("TML1010_R08", "IN_EQMPARTS");
                ItsMaria.AddModel(MODEL_A2);
                for (int i = 0; i < MODEL_G2.ModelCount; i++)
                {
                    ItsMaria.AddList("MTRODRSEQ_LIST", MODEL_G2.GetText(i, "MTRODRSEQ"));
                    ItsMaria.AddList("INQTY_LIST", MODEL_G2.GetDecimal(i, "INQTY"));
                }

                DataSet ds = ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                ReloadMtrodr();
                EventCommand("SEARCH_IN_EQMPARTS");

                try
                {
                    PrintLabel(ds);
                }
                catch
                {
                    ShowMessageBox("", "입고는 완료되었습니다. 라벨 출력을 확인해주세요.");
                }
            }
            // 체크한 입고 이력 입고취소 저장
            else if (commandName == "CANCEL_IN_EQMPARTS")
            {
                ItsMaria.Set("TML1010_R08", "CANCEL_IN_EQMPARTS");
                AddCheckedInoutKey();

                ItsMaria.Call();
                if (ItsMaria.IsError)
                {
                    ShowMessageBox("", ItsMaria.ErrMessage);
                    return;
                }

                EventCommand("SEARCH_IN_EQMPARTS");
                ReloadMtrodr();
            }
        }
    }
}
