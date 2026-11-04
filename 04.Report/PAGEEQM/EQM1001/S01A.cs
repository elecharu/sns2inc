using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Drawing.Printing;
using System.Data;
using System.Collections.Generic;
using ItsLibRpt;

namespace XtraRpt
{
    public partial class S01A : DevExpress.XtraReports.UI.XtraReport
    {
        // 2026-11-04 [설비이력카드] Visual Studio Report Designer 호환을 위한 기본 생성자
        public S01A()
        {
            InitializeComponent();
        }

        // 2026-11-04 [설비이력카드] S01A 파라미터 수신 및 데이터 조회 바인딩 (DB 접속정보 하드코딩 제거, ITS_CONFIG_MARIA.xml 사용)
        public S01A(Dictionary<string, string> param) : this()
        {
            string eqmCode = param.ContainsKey("EQMCD") ? param["EQMCD"] : (param.ContainsKey("FANO") ? param["FANO"] : "");
            if (string.IsNullOrEmpty(eqmCode))
            {
                throw new InvalidOperationException("설비를 선택해주세요.");
            }

            ItsMaria maria = new ItsMaria("EQM1001_S01", "CALL_RPT");
            maria.AddParam("EQMCD", eqmCode);
            DataSet dataSet = maria.CallProc();
            if (maria.IsError)
            {
                throw new InvalidOperationException(maria.ErrMessage);
            }

            // 2026-10-06 설비 정보가 없는 이력카드는 빈 PDF 대신 오류 안내
            if (dataSet == null || dataSet.Tables.Count < 2 || dataSet.Tables[0].Rows.Count == 0)
            {
                throw new InvalidOperationException("출력할 설비 정보가 없습니다. 설비마스터를 확인해주세요.");
            }

            DataRow eqmHeader = dataSet.Tables[0].Rows[0];
            DataTable maintItems = dataSet.Tables[1];

            BindReportData(eqmHeader, maintItems);
        }

        // 2026-11-04 [설비이력카드] 로고·설비 마스터·설비사진 및 하단 검교정/수리현황 바인딩
        private void BindReportData(DataRow eqmHeader, DataTable maintItems)
        {
            LoadLogo();

            // 상단 설비 마스터 정보 바인딩
            cell_Val_EQMCD.Text = Value(eqmHeader, "EQMCD");
            cell_Val_EQMNM.Text = Value(eqmHeader, "EQMNM");
            cell_Val_EQMSPEC.Text = Value(eqmHeader, "EQMSPEC");
            cell_Val_SERNO.Text = Value(eqmHeader, "SERNO");
            cell_Val_MKCUST.Text = Value(eqmHeader, "MKCUST");
            cell_Val_MKDATE.Text = Value(eqmHeader, "MKDATE");
            cell_Val_EPOWER.Text = Value(eqmHeader, "EPOWER");
            cell_Val_VOLT.Text = Value(eqmHeader, "VOLT");
            cell_Val_EQMGRADE.Text = Value(eqmHeader, "EQMGRADE");
            cell_Val_BUYCUST.Text = Value(eqmHeader, "BUYCUST");
            cell_Val_SETDATE.Text = Value(eqmHeader, "SETDATE");
            cell_Val_BUYAMT.Text = Value(eqmHeader, "BUYAMT");
            cell_Val_OWN_DIV.Text = Value(eqmHeader, "OWN_DIV");
            cell_Val_USETYPE.Text = Value(eqmHeader, "USETYPE");
            cell_Val_EQMTP.Text = Value(eqmHeader, "EQMTP");
            cell_Val_EQMGROUP1.Text = Value(eqmHeader, "EQMGROUP1");
            cell_Val_EQMGROUP2.Text = Value(eqmHeader, "EQMGROUP2");
            cell_Val_EQMGROUP3.Text = Value(eqmHeader, "EQMGROUP3");

            // 설비 사진
            LoadImage(xrPictureBoxPhoto, Value(eqmHeader, "FILEPATH"));

            // 하단 검교정 및 수리현황 바인딩
            this.DataSource = maintItems;
        }

        // 2026-11-04 [설비이력카드] 실행 위치(01.Office/Reports, 04.Report/bin)별 회사 로고 경로 탐색
        private void LoadLogo()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string[] logoCandidates = new string[]
            {
                System.IO.Path.Combine(baseDir, "..", "..", "01.Office", "images", "menu", "logo.png"),
                System.IO.Path.Combine(baseDir, "..", "01.Office", "images", "menu", "logo.png"),
                System.IO.Path.Combine(baseDir, "images", "logo.png"),
                @"D:\ITS_MES_SNSINC_FAC2_VA.1.0\01.Office\images\menu\logo.png"
            };
            foreach (string logoPath in logoCandidates)
            {
                if (LoadImage(xrPictureBoxLogo, logoPath))
                {
                    break;
                }
            }
        }

        private static bool LoadImage(XRPictureBox pictureBox, string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath) || !System.IO.File.Exists(imagePath))
            {
                return false;
            }

            try
            {
                pictureBox.Image = System.Drawing.Image.FromFile(imagePath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static string Value(DataRow row, string fieldName)
        {
            return row.Table.Columns.Contains(fieldName) && row[fieldName] != DBNull.Value ? row[fieldName].ToString() : "";
        }

        public class MODEL_S1
        {
        }
    }
}
