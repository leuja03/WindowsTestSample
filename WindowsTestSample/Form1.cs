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
using System.Text.RegularExpressions;

namespace WindowsTestSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public enum BitType
        {
           None = 0,
           One = 1 << 0,
           Two = 1 << 1,
           Three = 1 << 2,
           Four = 1 << 3,
           Five = 1 << 4,
           Six = 1 << 5,
           Seven = 1 << 6,
           Eight = 1 << 7,
           Nine = 1 << 8,
           Ten = 1 << 9,
        }

        private void button1_Click(object sender, EventArgs e)
        {
           TestRegex();

           string result = Test_StaticClass_AltWay.WhatToGet();

           Factory_CreateOneByOne.TestFactory();

           // Test bits
           int value = 3;
           TestAndValue(value);
           value = 4;
           TestAndValue(value);
           value = 10;
           TestAndValue(value);
           value = 32;
           TestAndValue(value);
           value = 59;
           TestAndValue(value);
           value = value << 2;


            List<string> thisList = new List<string>();
            int count = thisList.Count;
            count = thisList.Capacity;
        }

        private void TestRegex()
        {
           string req = @"^(1|2)$";

           // country
           bool 
           regexResult = Regex.IsMatch("1", req, RegexOptions.IgnoreCase);
           regexResult = Regex.IsMatch("2", req, RegexOptions.IgnoreCase);
           regexResult = Regex.IsMatch("3", req, RegexOptions.IgnoreCase);
           regexResult = Regex.IsMatch("A", req, RegexOptions.IgnoreCase);
           regexResult = Regex.IsMatch("", req, RegexOptions.IgnoreCase);

           // client id
           req = @"^[0-9]{10}$";
           regexResult = Regex.IsMatch("1", req, RegexOptions.IgnoreCase);
           regexResult = Regex.IsMatch("A", req, RegexOptions.IgnoreCase);
           regexResult = Regex.IsMatch("BCD dsfasf", req, RegexOptions.IgnoreCase);
           regexResult = Regex.IsMatch("1234567890", req, RegexOptions.IgnoreCase);
           regexResult = Regex.IsMatch("12345678901", req, RegexOptions.IgnoreCase);
           regexResult = Regex.IsMatch("123456789A", req, RegexOptions.IgnoreCase);
           regexResult = Regex.IsMatch("", req, RegexOptions.IgnoreCase);

           // date
           req = @"^[0-9]{6}$";
           regexResult = Regex.IsMatch("", req, RegexOptions.IgnoreCase);
           regexResult = Regex.IsMatch("1", req, RegexOptions.IgnoreCase);
           regexResult = Regex.IsMatch("1234567", req, RegexOptions.IgnoreCase);
           regexResult = Regex.IsMatch("1 4 52", req, RegexOptions.IgnoreCase);
           regexResult = Regex.IsMatch("123456", req, RegexOptions.IgnoreCase);
           regexResult = Regex.IsMatch("1AB567", req, RegexOptions.IgnoreCase);

           // version
           req = @"^[0-9]{6}$";
           regexResult = Regex.IsMatch("", req, RegexOptions.IgnoreCase);
        }

        private void TestAndValue(int value)
        {
           int testvalue = value & (int)BitType.One;
           testvalue = value & (int)BitType.Two;
           testvalue = value & (int)BitType.Three;
           testvalue = value & (int)BitType.Four;
           testvalue = value & (int)BitType.Five;
           testvalue = value & (int)BitType.Six;
           testvalue = value & (int)BitType.Seven;
           testvalue = value & (int)BitType.Eight;
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
