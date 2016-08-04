using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LB.WinFunction
{
    public class LoginInfo
    {
        private static string _LoginName="";
        public static string LoginName
        {
            get
            {
                return _LoginName;
            }
            set
            {
                _LoginName = value;
            }
        }

        private static int _UserID=0;
        public static int UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }

        private static DateTime _LoginTime = DateTime.Now;
        public static DateTime LoginTime
        {
            get
            {
                return _LoginTime;
            }
            set
            {
                _LoginTime = value;
            }
        }

        private static bool _IsVerifySuccess = false;
        /// <summary>
        /// 是否校验用户密码成功
        /// </summary>
        public static bool IsVerifySuccess
        {
            get
            {
                return _IsVerifySuccess;
            }
            set
            {
                _IsVerifySuccess = value;
            }
        }

        /// <summary>
        /// 加密密码
        /// </summary>
        /// <param name="strPassword"></param>
        /// <returns></returns>
        public static string EncryptPassword(string strPassword)
        {
            return LBEncrypt.DESEncrypt(strPassword, "linrubin");
        }

        /// <summary>
        /// 校验登录密码
        /// </summary>
        /// <param name="strLoginName"></param>
        /// <param name="strPassword"></param>
        /// <returns></returns>
        public static bool VerifyLogin(string strLoginName,string strPassword)
        {
            _IsVerifySuccess = false;
            bool bolIsLogin = false;
            DataTable dtUser = GetUserInfo(strLoginName);
            if (dtUser.Rows.Count == 0)
            {
                throw new Exception("该用户名称不存在！");
            }
            else
            {
                string strUserPassword = dtUser.Rows[0]["UserPassword"].ToString().TrimEnd();
                int iUserID = Convert.ToInt32(dtUser.Rows[0]["UserID"]);
                if (LBEncrypt.DESEncrypt(strPassword, "linrubin") == strUserPassword)
                {
                    bolIsLogin = true;
                    _UserID = iUserID;
                    _IsVerifySuccess = true;
                    _LoginName = strLoginName;
                    _LoginTime = DateTime.Now;
                    _IsVerifySuccess = true;
                }
                else
                {
                   
                    throw new Exception("密码不正确，请重新输入！");
                }
            }

            return bolIsLogin;
        }

        /// <summary>
        /// 校验密码是否正确
        /// </summary>
        /// <param name="strLoginName"></param>
        /// <param name="strPassword"></param>
        /// <returns></returns>
        public static bool VerifyPassword(int iUserID, string strPassword)
        {
            bool bolIsVerify = false;
            DataTable dtUser = GetUserInfo(iUserID);
            if (dtUser.Rows.Count == 0)
            {
                throw new Exception("该用户名称不存在！");
            }
            string strUserPassword = dtUser.Rows[0]["UserPassword"].ToString().TrimEnd();

            if (LBEncrypt.DESEncrypt(strPassword, "linrubin") == strUserPassword)
            {
                bolIsVerify = true;
            }
            return bolIsVerify;
        }


        private static DataTable GetUserInfo(string strLoginName)
        {
            DataTable dtUser = ExecuteSQL.CallView(100, "UserID,UserPassword", "LoginName='" + strLoginName + "'", "");
            return dtUser;
        }

        private static DataTable GetUserInfo(int iUserID)
        {
            DataTable dtUser = ExecuteSQL.CallView(100, "UserID,UserPassword", "UserID=" + iUserID, "");
            return dtUser;
        }
    }
}
