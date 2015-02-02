using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Text;

namespace FukjBizSystem.Application.DataSet
{

    #region RyoshushoPrintData
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： RyoshushoPrintData
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// Do not put this class into RyoshushoPrintForm's constructor
    /// when calling RyoshushoPrintForm from menu
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/26　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    //[Obsolete("Do not use this class, see FukjBizSystem.Application.Boundary.Keiri.RyoshushoPrintForm")]
    //public class RyoshushoPrintData
    //{
    //    /// <summary>
    //    /// 発行No
    //    /// </summary>
    //    public string HakkoNo { get; set; }

    //    /// <summary>
    //    /// 業者コード
    //    /// </summary>
    //    public string GyoshaCd { get; set; }

    //    /// <summary>
    //    /// 消費税区分
    //    /// </summary>
    //    public string ShouhizeiKbn { get; set; }

    //    /// <summary>
    //    /// 領収書種別
    //    /// </summary>
    //    public string ShushushoShubetsu { get; set; }

    //    #region 用紙販売画面

    //    /// <summary>
    //    /// 注文番号
    //    /// </summary>
    //    public string YoshiHanbaiChumonNo { get; set; }

    //    #endregion

    //    #region 会員会費入金入力画面
    //    //Parameters from KaiinNyukin screen

    //    /// <summary>
    //    /// RyushushoPrintDT 
    //    /// </summary>
    //    public YoshiHanbaiDtlTblDataSet.RyushushoPrintDataTable RyushushoPrintDT { get; set; }

    //    #endregion
    //}
    #endregion

    public partial class YoshiHanbaiDtlTblDataSet {
        partial class RyushushoPrintDataTable
        {
        }
    }
}

namespace FukjBizSystem.Application.DataSet.YoshiHanbaiDtlTblDataSetTableAdapters
{

    #region RyushushoPrintTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： RyushushoPrintTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <param
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/26　AnhNV　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class RyushushoPrintTableAdapter
    {
        #region GetDataByChumonNo
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataByChumonNo
        /// <summary>
        /// 
        /// </summary>
        /// <param name="yoshiHanbaiChumonNo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/13　AnhNV　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal YoshiHanbaiDtlTblDataSet.RyushushoPrintDataTable GetDataByChumonNo(/*RyoshushoPrintData searchCond*/string yoshiHanbaiChumonNo)
        {
            SqlCommand command = CreateSqlCommand(/*searchCond*/ yoshiHanbaiChumonNo);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            YoshiHanbaiDtlTblDataSet.RyushushoPrintDataTable table = new YoshiHanbaiDtlTblDataSet.RyushushoPrintDataTable();
            adpt.Fill(table);

            return table;
        }
        #endregion

        #region CreateSqlCommand
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSqlCommand
        /// <summary>
        /// 
        /// </summary>
        /// <param name="yoshiHanbaiChumonNo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/26  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(/*RyoshushoPrintData searchCond*/ string yoshiHanbaiChumonNo)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            sqlContent.AppendLine(" select top 5                                                                                                ");
            sqlContent.AppendLine("     yhdt.YoshiHanbaiYoshiCd as Hinban,                                                                      ");
            sqlContent.AppendLine("     ym.YoshiNm as HinNm,                                                                                    ");
            sqlContent.AppendLine("     '' as Tani,                                                                                             ");
            sqlContent.AppendLine("     case                                                                                                    ");
            sqlContent.AppendLine("         when yhdt.YoshiHanbaiSetSuryo > 0 then yhdt.YoshiHanbaiSetSuryo                                     ");
            sqlContent.AppendLine("         when yhdt.YoshiHanbaiSuryo > 0 then yhdt.YoshiHanbaiSuryo                                           ");
            sqlContent.AppendLine("     end as SuiRyo,                                                                                          ");
            sqlContent.AppendLine("     case                                                                                                    ");
            sqlContent.AppendLine("         when yhdt.YoshiHanbaiShohizei > 0 then '1'                                                          ");
            sqlContent.AppendLine("         when yhdt.YoshiHanbaiShohizei = 0 then '0'                                                          ");
            sqlContent.AppendLine("     end as ShouhizeiUmu,                                                                                    ");
            sqlContent.AppendLine("     case                                                                                                    ");
            sqlContent.AppendLine("         when yhdt.YoshiHanbaiSetSuryo > 0 then yhdt.YoshiHanbaiSetKakaku                                    ");
            sqlContent.AppendLine("         when yhdt.YoshiHanbaiSuryo > 0 then yhdt.YoshiHanbaiUp                                              ");
            sqlContent.AppendLine("     end as Tanka,                                                                                           ");
            sqlContent.AppendLine("     yhdt.YoshiHanbaiKakaku as Kingaku,                                                                      ");
            sqlContent.AppendLine("     '' as Bikou,                                                                                            ");
            sqlContent.AppendLine("     '' as TaniNm,                                                                                           ");
            sqlContent.AppendLine("     yhdt.YoshiHanbaiGaku as HanbaiGaku                                                                      ");
            sqlContent.AppendLine(" from YoshiHanbaiHdrTbl yhht                                                                                 ");
            sqlContent.AppendLine(" left outer join YoshiHanbaiDtlTbl yhdt                                                                      ");
            sqlContent.AppendLine("     on yhht.YoshiHanbaiChumonNo = yhdt.YoshiHanbaiChumonNo                                                  ");
            sqlContent.AppendLine(" left outer join YoshiMst ym                                                                                 ");
            sqlContent.AppendLine("     on yhdt.YoshiHanbaiYoshiCd = ym.YoshiCd                                                                 ");
            sqlContent.AppendLine(" left outer join GyoshaMst gm                                                                                ");
            sqlContent.AppendLine("     on yhht.YoshiHanbaisakiGyoshaCd = gm.GyoshaCd                                                           ");
            sqlContent.AppendLine(" where yhht.YoshiHanbaiChumonNo = @YoshiHanbaiChumonNo                                                       ");
            sqlContent.AppendLine(" order by yhdt.YoshiHanbaiYoshiCd                                                                            ");

            // Params
            commandParams.Add("@YoshiHanbaiChumonNo", System.Data.SqlDbType.NVarChar).Value = (string)yoshiHanbaiChumonNo;

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion
}
