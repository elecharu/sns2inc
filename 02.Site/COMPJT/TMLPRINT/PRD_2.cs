using System;
using System.Data;
using System.Globalization;
using ITSLIB;

namespace TMLPRINT
{
    /// <summary>
    /// // 2026-11-19 [생산실적등록] MAGNA (소)라벨지 100 x 60 mm. TML2010_R01 공정이동표 발행 팝업의 라벨출력·라벨발행
    /// 출력 기준: 출력하는 달 생산품의 수주 거래처가 MAGNA(9054740899)
    /// head = TML2010_R01 PRINT_LABEL 결과 (LOTKEY, PRDRSTKEY, PRDDATE yyyy-MM-dd)
    /// 고정값(발송·수신주소, Description, P1100175, Q300, 600612, SeAH Besteel, PO 5400006680)은 양식에 그려 둠
    /// (자료: 생산관리팀 "(소)라벨지 출력 기준 & 데이터 매핑정보.pptx")
    /// </summary>
    public partial class PRD_2 : ITSLIB.ItsReport
    {
        public PRD_2()
        {
            InitializeComponent();
        }

        public PRD_2(DataTable head)
        {
            InitializeComponent();

            SET_DATA(head);
        }

        public void SET_DATA(DataTable head)
        {
            string lotKey = ItsData.GetText(head, 0, "LOTKEY");

            // 바코드(3) License Plate: 1J + 공급자번호 600612 + 00 + MES 생산실적번호 + 1
            string licensePlate = "1J60061200" + ItsData.GetText(head, 0, "PRDRSTKEY") + "1";

            this.C_COILTAG.Text = lotKey;
            this.C_LOTKEY.Text = lotKey;
            this.C_BAR1J.Text = licensePlate;

            // 바코드(4) 2D: 자료의 문자열 그대로 ('=' 포함)
            this.C_BAR2D.Text = "[)>=06=P1100175=Q300=" + licensePlate + "=K5400006680=R00=T" + lotKey + "=7Q376LB";

            // 생산일자 DD + 영문월 + YY (예: 20Apr26)
            DateTime prdDate;
            if (DateTime.TryParseExact(ItsData.GetText(head, 0, "PRDDATE"), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out prdDate))
            {
                this.C_MFGDATE.Text = prdDate.ToString("ddMMMyy", CultureInfo.InvariantCulture);
            }
            else
            {
                this.C_MFGDATE.Text = ItsData.GetText(head, 0, "PRDDATE");
            }
        }
    }
}
