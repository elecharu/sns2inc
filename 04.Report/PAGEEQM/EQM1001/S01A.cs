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
        public S01A(Dictionary<string, string> param)
        {
            InitializeComponent();

            // 2026-10-06 이력카드 출력에 현재 프로젝트 DB 연결 설정 적용
            ItsMaria maria = new ItsMaria("EQM1001_S01", "CALL_RPT");
            maria.DbServer = "211.43.15.98";
            maria.DbPort = "33061";
            maria.DbUser = "root";
            maria.DbPass = ItsSecurity.DecDES("f4jHrVI/NLGr48fLMegkWw==");
            maria.DbName = "MES_SNS2";
            var eqmcd = param.ContainsKey("EQMCD") ? param["EQMCD"] : (param.ContainsKey("FANO") ? param["FANO"] : "");
            if (string.IsNullOrEmpty(eqmcd))
            {
                throw new InvalidOperationException("설비를 선택해주세요.");
            }
            maria.AddParam("EQMCD", eqmcd);

            DataSet ds = maria.CallProc();
            if (maria.IsError)
            {
                throw new InvalidOperationException(maria.ErrMessage);
            }

            // 2026-10-06 설비 정보가 없는 이력카드는 빈 PDF 대신 오류 안내
            if (ds == null || ds.Tables.Count < 2 || ds.Tables[0].Rows.Count == 0)
            {
                throw new InvalidOperationException("출력할 설비 정보가 없습니다. 설비마스터를 확인해주세요.");
            }

            // 로고 이미지 로드
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string[] logoCandidates = new string[]
            {
                System.IO.Path.Combine(baseDir, "..", "..", "01.Office", "images", "menu", "logo.png"),
                System.IO.Path.Combine(baseDir, "..", "01.Office", "images", "menu", "logo.png"),
                System.IO.Path.Combine(baseDir, "images", "logo.png"),
                @"D:\ITS_MES_SNSINC_FAC2_VA.1.0\01.Office\images\menu\logo.png"
            };
            foreach (var lp in logoCandidates)
            {
                if (System.IO.File.Exists(lp))
                {
                    try
                    {
                        xrPictureBoxLogo.Image = System.Drawing.Image.FromFile(lp);
                        break;
                    }
                    catch { }
                }
            }

            // 상단 설비 마스터 정보 바인딩
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                cell_Val_EQMCD.Text = row["EQMCD"].ToString();
                cell_Val_EQMNM.Text = row["EQMNM"].ToString();
                cell_Val_EQMSPEC.Text = row["EQMSPEC"].ToString();
                cell_Val_SERNO.Text = row["SERNO"].ToString();
                cell_Val_MKCUST.Text = row["MKCUST"].ToString();
                cell_Val_MKDATE.Text = row["MKDATE"].ToString();
                cell_Val_EPOWER.Text = row["EPOWER"].ToString();
                cell_Val_VOLT.Text = row["VOLT"].ToString();
                cell_Val_EQMGRADE.Text = row["EQMGRADE"].ToString();
                cell_Val_BUYCUST.Text = row["BUYCUST"].ToString();
                cell_Val_SETDATE.Text = row["SETDATE"].ToString();
                cell_Val_BUYAMT.Text = row["BUYAMT"].ToString();
                cell_Val_OWN_DIV.Text = row["OWN_DIV"].ToString();
                cell_Val_USETYPE.Text = row["USETYPE"].ToString();
                cell_Val_EQMTP.Text = row["EQMTP"].ToString();
                cell_Val_EQMGROUP1.Text = row["EQMGROUP1"].ToString();
                cell_Val_EQMGROUP2.Text = row["EQMGROUP2"].ToString();
                cell_Val_EQMGROUP3.Text = row["EQMGROUP3"].ToString();

                string photoPath = row["FILEPATH"].ToString();
                if (!string.IsNullOrEmpty(photoPath) && System.IO.File.Exists(photoPath))
                {
                    try
                    {
                        xrPictureBoxPhoto.Image = System.Drawing.Image.FromFile(photoPath);
                    }
                    catch { }
                }
            }

            // 하단 검교정 및 수리현황 바인딩
            if (ds != null && ds.Tables.Count > 1)
            {
                this.DataSource = ds.Tables[1];
            }
        }
    }
}
