using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestWebService
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtSP = new DataTable("asfd");
                dtSP.Columns.Add("UserID", typeof(long));
                dtSP.Columns.Add("UserAccount", typeof(string));
                dtSP.Columns.Add("UserPassword", typeof(string));
                dtSP.Columns.Add("UserName", typeof(string));

                DataRow drNew = dtSP.NewRow();
                drNew["UserAccount"] = "lin";
                drNew["UserPassword"] = "lin";
                drNew["UserName"] = "lin";
                dtSP.Rows.Add(drNew);
                drNew = dtSP.NewRow();
                drNew["UserAccount"] = "lin1";
                drNew["UserPassword"] = "lin1";
                drNew["UserName"] = "lin1";
                dtSP.Rows.Add(drNew);
                drNew = dtSP.NewRow();
                drNew["UserAccount"] = "lin2";
                drNew["UserPassword"] = "lin3";
                drNew["UserName"] = "lin3";
                dtSP.Rows.Add(drNew);

                DataSet dsReturn;
                DataTable dtOut;
                LB.WinFunction.ExecuteSQL.CallSP(10000, dtSP, out dsReturn, out dtOut);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
