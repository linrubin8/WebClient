using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LB.WinFunction
{
    public class ExecuteSQL
    {
        /// <summary>
        /// 调用存储过程
        /// </summary>
        /// <param name="iSPType">存储过程号</param>
        /// <param name="dtInput">参数数据</param>
        /// <param name="dsReturn">返回的查询数据</param>
        /// <param name="dtOut">返回的参数值</param>
        public static void CallSP(int iSPType,DataTable dtInput,out DataSet dsReturn,out DataTable dtOut)
        {
            if (string.IsNullOrEmpty(dtInput.TableName))
            {
                dtInput.TableName = "SPIN";
            }
            LBWebService.LBWebService webservice = new LBWebService.LBWebService();
            string strErrorMsg;
            bool bolIsError;
            dsReturn = webservice.RunProcedure(iSPType, LoginInfo.LoginName, dtInput, out dtOut, out strErrorMsg, out bolIsError);
            if (bolIsError)
            {
                throw new Exception(strErrorMsg);
            }
        }

        /// <summary>
        /// 查询视图
        /// </summary>
        /// <param name="iViewType">视图号</param>
        /// <param name="strFieldNames">查询字段</param>
        /// <param name="strWhere">查询条件</param>
        /// <param name="strOrderBy">排序</param>
        /// <returns></returns>
        public static DataTable CallView(int iViewType,string strFieldNames,string strWhere ,string strOrderBy)
        {
            DataTable dtResult = null;
            LBWebService.LBWebService webservice = new LBWebService.LBWebService();
            string strErrorMsg;
            bool bolIsError;
            dtResult = webservice.RunView(iViewType, LoginInfo.LoginName, strFieldNames, strWhere,strOrderBy, out strErrorMsg, out bolIsError);
            if (bolIsError)
            {
                throw new Exception(strErrorMsg);
            }
            return dtResult;
        }

        /// <summary>
        /// 无条件查询视图
        /// </summary>
        /// <param name="iViewType">视图号</param>
        /// <returns></returns>
        public static DataTable CallView(int iViewType)
        {
            return CallView(iViewType, "", "", "");
        }
    }
}
