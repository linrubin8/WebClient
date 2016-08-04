using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LB.WinFunction
{
    public class LBCommonHelper
    {
        public static void DealWithErrorMessage(Exception ex)
        {
            MessageBox.Show(ex.Message, "错误");
        }

        public static void ShowCommonMessage(Exception ex)
        {
            MessageBox.Show(ex.Message, "提示信息");
        }

        public static void ShowCommonMessage(string text)
        {
            MessageBox.Show(text, "提示信息");
        }

        public static DialogResult ConfirmMessage(Exception ex, string caption, MessageBoxButtons buttons)
        {
            return MessageBox.Show(ex.Message, caption, buttons);
        }
    }
}
