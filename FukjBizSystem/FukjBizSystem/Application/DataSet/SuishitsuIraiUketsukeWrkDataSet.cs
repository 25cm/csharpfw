using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Text;
namespace FukjBizSystem.Application.DataSet {
    
    
    public partial class SuishitsuIraiUketsukeWrkDataSet {
    }
}

namespace FukjBizSystem.Application.DataSet.SuishitsuIraiUketsukeWrkDataSetTableAdapters
{
    #region KensaIraiUketsukeListDataTableTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaIraiUketsukeListDataTableTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者     内容
    /// 2014/10/06　豊田       新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaIraiUketsukeListTableAdapter
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kensaKbn"></param>
        /// <param name="shishoCd"></param>
        /// <param name="uketsukeNoFrom"></param>
        /// <param name="uketsukeNoTo"></param>
        /// <param name="uketsukeDateFrom"></param>
        /// <param name="uketsukeDateTo"></param>
        /// <param name="includeOutput"></param>
        /// <param name="outputDateFrom"></param>
        /// <param name="outputDateTo"></param>
        /// <history>
        /// 日付　　　　担当者     内容
        /// 2014/10/06　豊田       新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal SuishitsuIraiUketsukeWrkDataSet.KensaIraiUketsukeListDataTable GetDataBySearchCond(
            string kensaKbn,
            string shishoCd,
            string uketsukeNoFrom,
            string uketsukeNoTo,
            DateTime? uketsukeDateFrom,
            DateTime? uketsukeDateTo,
            bool includeOutput,
            DateTime? outputDateFrom,
            DateTime? outputDateTo)
        {
            SqlCommand command = CreateSqlCommand(kensaKbn, shishoCd, uketsukeNoFrom, uketsukeNoTo, uketsukeDateFrom, uketsukeDateTo, includeOutput, outputDateFrom, outputDateTo);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            SuishitsuIraiUketsukeWrkDataSet.KensaIraiUketsukeListDataTable dataTable = new SuishitsuIraiUketsukeWrkDataSet.KensaIraiUketsukeListDataTable();
            adpt.Fill(dataTable);

            return dataTable;
        }
        #endregion

        #region CreateSqlCommand
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSqlCommand
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kensaKbn"></param>
        /// <param name="shishoCd"></param>
        /// <param name="uketsukeNoFrom"></param>
        /// <param name="uketsukeNoTo"></param>
        /// <param name="uketsukeDateFrom"></param>
        /// <param name="uketsukeDateTo"></param>
        /// <param name="includeOutput"></param>
        /// <param name="outputDateFrom"></param>
        /// <param name="outputDateTo"></param>
        /// <history>
        /// 日付　　　　担当者     内容
        /// 2014/10/06　豊田       新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            string kensaKbn,
            string shishoCd,
            string uketsukeNoFrom,
            string uketsukeNoTo,
            DateTime? uketsukeDateFrom,
            DateTime? uketsukeDateTo,
            bool includeOutput,
            DateTime? outputDateFrom,
            DateTime? outputDateTo)
        {
            SqlCommand command = new SqlCommand();

            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            //SELECT
            sqlContent.Append(" SELECT  ");
            sqlContent.Append("     SuishitsuIraiUketsukeWrk.IraiUketsukeKensaKbn,  ");
            sqlContent.Append("  ConstMst.ConstNm,  ");
            sqlContent.Append("     SuishitsuIraiUketsukeWrk.IraiUketsukeShishoCd,  ");
            sqlContent.Append("  ShishoMst.ShishoNm,  ");
            sqlContent.Append("     SuishitsuIraiUketsukeWrk.IraiUketsukeNendo,  ");
            sqlContent.Append("     SuishitsuIraiUketsukeWrk.IraiUketsukeNo,  ");
            sqlContent.Append("     SuishitsuIraiUketsukeWrk.IraiUketsukeBarCd,  ");
            sqlContent.Append("     SuishitsuIraiUketsukeWrk.InsertDt,  ");
            sqlContent.Append("  SuishitsuIraiUketsukeWrk.IraiUketsukeCsvOutputDt  ");

            //FROM
            sqlContent.Append(" FROM  ");
            sqlContent.Append("     SuishitsuIraiUketsukeWrk  ");
            sqlContent.Append("  INNER JOIN ConstMst ON  ");
            sqlContent.Append("   ConstMst.ConstKbn = '041' AND  ");
            sqlContent.Append("   ConstMst.ConstValue = SuishitsuIraiUketsukeWrk.IraiUketsukeKensaKbn  ");
            sqlContent.Append("  INNER JOIN ShishoMst ON  ");
            sqlContent.Append("   ShishoMst.ShishoCd = SuishitsuIraiUketsukeWrk.IraiUketsukeShishoCd  ");

            //WHERE
            sqlContent.Append(" WHERE ");

            // 支所コード
            sqlContent.Append(string.Format(" SuishitsuIraiUketsukeWrk.IraiUketsukeShishoCd = '{0}' ", shishoCd));

            // 検査区分
            if (!string.IsNullOrEmpty(kensaKbn))
            {
                sqlContent.Append(string.Format(" AND SuishitsuIraiUketsukeWrk.IraiUketsukeKensaKbn = '{0}' ", kensaKbn));
            }

            // 受付番号(From)
            if(!string.IsNullOrEmpty(uketsukeNoFrom))
            {
                sqlContent.Append(string.Format(" AND SuishitsuIraiUketsukeWrk.IraiUketsukeNo >= '{0}' ", uketsukeNoFrom));
            }

            // 受付番号(To)
            if (!string.IsNullOrEmpty(uketsukeNoTo))
            {
                sqlContent.Append(string.Format(" AND SuishitsuIraiUketsukeWrk.IraiUketsukeNo <= '{0}' ", uketsukeNoTo));
            }

            // 受付日(From)
            if (uketsukeDateFrom.HasValue)
            {
                sqlContent.Append(string.Format(" AND SuishitsuIraiUketsukeWrk.InsertDt >= '{0}' ", uketsukeDateFrom.Value));
            }

            // 受付日(To)
            if (uketsukeDateTo.HasValue)
            {
                sqlContent.Append(string.Format(" AND SuishitsuIraiUketsukeWrk.InsertDt < '{0}' ", uketsukeDateTo.Value.AddDays(1)));
            }

            // 出力済みを含めない
            if (!includeOutput)
            {
                // 出力済みを含めない
                sqlContent.Append(" AND SuishitsuIraiUketsukeWrk.IraiUketsukeCsvOutputDt IS NULL ");
            }

            // 出力日(From)
            if (outputDateFrom.HasValue)
            {
                sqlContent.Append(string.Format(" AND SuishitsuIraiUketsukeWrk.IraiUketsukeCsvOutputDt >= '{0}' ", outputDateFrom.Value));
            }

            // 出力日(To)
            if (outputDateTo.HasValue)
            {
                sqlContent.Append(string.Format(" AND SuishitsuIraiUketsukeWrk.IraiUketsukeCsvOutputDt < '{0}' ", outputDateTo.Value.AddDays(1)));
            }
            
            // ORDER BY
            sqlContent.Append(" ORDER BY   ");
            sqlContent.Append("     SuishitsuIraiUketsukeWrk.IraiUketsukeKensaKbn,  ");
            sqlContent.Append("     SuishitsuIraiUketsukeWrk.IraiUketsukeShishoCd,  ");
            sqlContent.Append("     SuishitsuIraiUketsukeWrk.IraiUketsukeNendo,  ");
            sqlContent.Append("     SuishitsuIraiUketsukeWrk.IraiUketsukeNo  ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion

    }
    #endregion
}