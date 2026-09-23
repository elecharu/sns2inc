using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;
using System.Security;
using System.Security.Cryptography;

public partial class SetCookie : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string TMLUID = ""; 
        TMLUID = Guid.NewGuid().ToString().Replace("-", "").ToUpper();
        Response.Write(TMLUID);
        Response.End();
    }
}