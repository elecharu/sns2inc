using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SYS1001_R02_PASSWORD : BasePage
{
    public string PATH = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string filePath = "M:\\WEBTAXAGENT\\NPKI\\" + Request["COMPREGNO"].Replace("-", "");
        string password = Request["PASSWORD"];
        MAKE_PASS(filePath, password);

    }

    public void MAKE_PASS(string filePath, string password)
    {
        try
        {
            if (!System.IO.Directory.Exists(filePath))
            {
                System.IO.Directory.CreateDirectory(filePath);
            }
            filePath = filePath + "\\password.txt";
            System.IO.File.Delete(filePath);
            System.IO.File.WriteAllText(filePath, password);
            PATH = filePath;
        }
        catch (Exception)
        {
            PATH = "n";
        }

    }
}