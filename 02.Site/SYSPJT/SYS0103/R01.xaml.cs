using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ITSLIB;
using System.Data;

namespace SYS0103
{
    /// <summary>
    /// R01.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class R01 : ITSLIB.ItsPageOffice
    {
        //테이블 상세 항목
        ItsModelPanel MODEL_S1 = new ItsModelPanel();
        ItsModelPanel MODEL_A1 = new ItsModelPanel();
        ItsModelGrid MODEL_G1 = new ItsModelGrid();

        public R01()
        {
            InitializeComponent();
        }
    }
}
