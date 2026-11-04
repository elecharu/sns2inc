using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITSIF_INTERFACE
{
    public class Workspace
    {
        static Workspace _this = new Workspace();

        public static Workspace This
        {
            get { return _this; }
        }

        private Task taskIF;

        public void MainStart()
        {
            taskIF = new Task(new Action(MainLoop.This.IFTask));
            taskIF.Start();
        }
    }
}
