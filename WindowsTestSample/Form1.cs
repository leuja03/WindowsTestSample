using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Web;

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
           
           
           //TestURL();
           //TestClasses();

            


            List<string> thisList = new List<string>();
            int count = thisList.Count;
            count = thisList.Capacity;
        }

        private void TestClasses()
        {
           A aa = Product.Give();
           string result = aa.MethodA();
           B bb = (B)Product.Give();
           result = bb.MethodA();
        }

        private void TestURL()
        {
           string destinationURL = "http://www.contoso.com/default.aspx?user=test";
           string testUrl = HttpContext.Current.Server.UrlEncode(destinationURL);
        }
    }

    public class Product
    {
        public static A Give()
        {
            return new A();
        }
    }
    public class A
    {
        public virtual string MethodA()
        {
            return "A";
        }

    }
    public class B : A
    {
        public override string MethodA()
        {
            return "B";
        }
    }
}
