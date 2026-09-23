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

public partial class Login : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ItsMaria maria = new ItsMaria();
        SetSession("SESSION_DBADDR", maria.DbServer);
        SetSession("SESSION_DBUSER", maria.DbUser);
        SetSession("SESSION_DBPORT", maria.DbPort);
        SetSession("SESSION_DBPASS", maria.DbPass);
        SetSession("SESSION_DBNAME", maria.DbName);

    }
}