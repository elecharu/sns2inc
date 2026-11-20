using System;
using System.Collections.Generic;
using System.Data;
using DevExpress.XtraPrinting;
using ITSLIB;

namespace TMLPRINT
{
    /// <summary>
    /// // 2026-11-19 [생산실적등록] 일반 (소)라벨지 100 x 60 mm. TML2010_R01 공정이동표 발행 팝업의 라벨출력·라벨발행
    /// 출력 기준: 생산품 MSTITEM.PARTNO, MSTITEM.INITCD 가 둘 다 있음 (MAGNA 대상이 아닐 때)
    /// head = TML2010_R01 PRINT_LABEL 결과 (PARTNO, ITEMNM, CUSTADDR, LOTQTY, PRDDATE, LABELKEY)
    /// (자료: 생산관리팀 "(소)라벨지 출력 기준 & 데이터 매핑정보.pptx")
    /// </summary>
    public partial class PRD_3 : ITSLIB.ItsReport
    {
        public PRD_3()
        {
            InitializeComponent();
        }

        public PRD_3(DataTable head)
        {
            InitializeComponent();

            SET_DATA(head);
        }

        public void SET_DATA(DataTable head)
        {
            this.C_PARTNO.Text = ItsData.GetText(head, 0, "PARTNO");
            this.C_BAR_PARTNO.Text = ItsData.GetText(head, 0, "PARTNO");
            this.C_ITEMNM.Text = ItsData.GetText(head, 0, "ITEMNM");
            this.C_CUSTADDR.Text = ItsData.GetText(head, 0, "CUSTADDR");
            this.C_QTY.Text = ItsData.GetText(head, 0, "LOTQTY");
            this.C_BAR_QTY.Text = ItsData.GetText(head, 0, "LOTQTY");
            this.C_LABELKEY.Text = ItsData.GetText(head, 0, "LABELKEY");
            this.C_BAR_LABELKEY.Text = ItsData.GetText(head, 0, "LABELKEY");
            this.C_PRDDATE.Text = ItsData.GetText(head, 0, "PRDDATE");
        }

        // 소라벨 여러 장(MAGNA PRD_2·일반 PRD_3 섞여도 됨)을 문서 하나로 합쳐 한 번에 인쇄 (인쇄작업 1개)
        public static void PrintDirect(List<ItsReport> reports, string printerName)
        {
            if (reports == null || reports.Count == 0)
            {
                return;
            }

            ItsReport first = reports[0];
            first.ShowPrintMarginsWarning = false;
            first.ShowPrintStatusDialog = false;
            first.CreateDocument();
            for (int i = 1; i < reports.Count; i++)
            {
                reports[i].CreateDocument();
                first.Pages.AddRange(reports[i].Pages);
            }

            PrintToolBase tool = new PrintToolBase(first.PrintingSystem);
            tool.Print(printerName);
        }
    }
}
