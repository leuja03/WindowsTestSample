using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MiscTest;
using Check_Linq;
using AnotherLayer;

namespace WindowsTestSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           m_richTextBox1.Clear();

           AnotherLayer.AnotherLayer.DoTest();

           Check_Regex.DoTest();

           Test_StaticClass_AltWay.DoTest();

           Factory_CreateOneByOne.TestFactory();

           // test bits
           Check_Bits.DoTest();

           Check_Inheritance.DoTest();

           Check_Unicode.DoTest();

           Check_ListCast.DoTest();

           CheckDefaultTest.DoTest();

           GetChildListToParentList.DoTest();

           Check_Ping.DoTest();

           Check_Enum.DoTest();
        }

    }
}
