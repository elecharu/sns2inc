using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Text;
using System.Web.Script.Serialization;
using System.Drawing;

public partial class FolderExists : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string folderpath = "";
        string isfolder = "N";

        try
        {
            folderpath = Request["folderpath"];
        }
        catch
        {
            Response.Write("ERROR:folder path empty!!");
            Response.End();
        }
        if (System.IO.Directory.Exists(folderpath))
        {
            isfolder = "Y";
        }

        Response.Write(isfolder);
    }
}