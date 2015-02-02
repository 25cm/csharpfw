using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FukjBizSystem.Application.DataSet.YoshiHanbaiKanri
{

    #region 定義(public)
    /// <summary>
    /// モード
    /// </summary>
    public enum AkibanMode
    {
        Add,
        Edit,
        Display
    }
    #endregion

    #region HoshoTorokuAkibanSearchCond
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： HoshoTorokuAkibanSearchCond
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/26　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class HoshoTorokuAkibanSearchCond
    {
        /// <summary>
        /// 保証登録注文番号
        /// </summary>
        public string HoshoTorokuChumonNo { get; set; }

        /// <summary>
        /// 保証登録検査機関
        /// </summary>
        public string HoshoTorokuKensakikan { get; set; }

        /// <summary>
        /// 保証登録年度
        /// </summary>
        public string HoshoTorokuNendo { get; set; }

        /// <summary>
        /// 保証登録連番
        /// </summary>
        public string HoshoTorokuRenban { get; set; }

        /// <summary>
        /// モード
        /// </summary>
        public AkibanMode AkibanMode { get; set; }
    }
    #endregion

    public partial class TyumonShosaiDataSet {
        
    }
}

namespace FukjBizSystem.Application.DataSet.YoshiHanbaiKanri.TyumonShosaiDataSetTableAdapters
{
    #region HoshoTorokuKaishiNoCheckTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： HoshoTorokuKaishiNoCheckTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/27　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class HoshoTorokuKaishiNoCheckTableAdapter
    {
        #region CommandTimeout
        // コマンドタイムアウト設定（単位は秒）
        public int CommandTimeout
        {
            get { return CommandCollection[0].CommandTimeout; }
            set
            {
                for (int i = 0; i < this.CommandCollection.Length; ++i)
                {
                    if (CommandCollection[i] != null)
                    {
                        ((System.Data.SqlClient.SqlCommand)(this.CommandCollection[i])).CommandTimeout = value;
                    }
                }
            }
        }
        #endregion

        #region GetDataByCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataByCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchCond"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/27　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal TyumonShosaiDataSet.HoshoTorokuKaishiNoCheckDataTable GetDataByCond(HoshoTorokuAkibanSearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommand(searchCond);

            // コマンドタイムアウトセット
            command.CommandTimeout = CommandTimeout;

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            TyumonShosaiDataSet.HoshoTorokuKaishiNoCheckDataTable dataTable = new TyumonShosaiDataSet.HoshoTorokuKaishiNoCheckDataTable();
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
        /// <param name="searchCond"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/27　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(HoshoTorokuAkibanSearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            sqlContent.AppendLine(" select                                                                                                                  ");
            sqlContent.AppendLine("     count(*) as HoshoRow                                                                                                ");
            sqlContent.AppendLine(" from HoshoTorokuTbl                                                                                                     ");
            sqlContent.AppendLine(" where                                                                                                                   ");
            sqlContent.AppendLine("     HoshoTorokuDeleteFlg = '0'                                                                                          ");
            sqlContent.AppendLine("     and HoshoTorokuKensakikan = @HoshoTorokuKensakikan                                                                  ");
            sqlContent.AppendLine("     and HoshoTorokuNendo = @HoshoTorokuNendo                                                                            ");
            sqlContent.AppendLine("     and HoshoTorokuRenban = @HoshoTorokuRenban                                                                          ");
            commandParams.Add("@HoshoTorokuKensakikan", SqlDbType.NVarChar).Value = (string)searchCond.HoshoTorokuKensakikan;
            commandParams.Add("@HoshoTorokuNendo", SqlDbType.NVarChar).Value = (string)searchCond.HoshoTorokuNendo;
            commandParams.Add("@HoshoTorokuRenban", SqlDbType.NVarChar).Value = (string)searchCond.HoshoTorokuRenban;

            // Display mode
            if (searchCond.AkibanMode == AkibanMode.Add)
            {
                sqlContent.AppendLine(" and isnull(HoshoTorokuChumonNo, '') = ''");
            }

            // Edit mode
            if (searchCond.AkibanMode == AkibanMode.Edit)
            {
                sqlContent.AppendLine(" and (isnull(HoshoTorokuChumonNo, '') = '' or HoshoTorokuChumonNo = @HoshoTorokuChumonNo) ");
                commandParams.Add("@HoshoTorokuChumonNo", SqlDbType.NVarChar).Value = (string)searchCond.HoshoTorokuChumonNo;
            }

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region HoshoTorokuAkibanTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： HoshoTorokuAkibanTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/26　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    partial class HoshoTorokuAkibanTableAdapter
    {
        #region CommandTimeout
        // コマンドタイムアウト設定（単位は秒）
        public int CommandTimeout
        {
            get { return CommandCollection[0].CommandTimeout; }
            set
            {
                for (int i = 0; i < this.CommandCollection.Length; ++i)
                {
                    if (CommandCollection[i] != null)
                    {
                        ((System.Data.SqlClient.SqlCommand)(this.CommandCollection[i])).CommandTimeout = value;
                    }
                }
            }
        }
        #endregion

        #region GetDataByCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataByCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchCond"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/26　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal TyumonShosaiDataSet.HoshoTorokuAkibanDataTable GetDataByCond(HoshoTorokuAkibanSearchCond searchCond)
        {
            SqlCommand command = CreateSqlCommand(searchCond);

            // コマンドタイムアウトセット
            command.CommandTimeout = CommandTimeout;

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            TyumonShosaiDataSet.HoshoTorokuAkibanDataTable dataTable = new TyumonShosaiDataSet.HoshoTorokuAkibanDataTable();
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
        /// <param name="searchCond"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/26　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(HoshoTorokuAkibanSearchCond searchCond)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            sqlContent.AppendLine(" select                                                                                                                  ");
            sqlContent.AppendLine("     htt.HoshoTorokuShishoKbn,                                                                                           ");
            sqlContent.AppendLine("     case                                                                                                                ");
            sqlContent.AppendLine("         when isdate(htt.HoshoTorokuUriageDt) = 0 then ''                                                                ");
            sqlContent.AppendLine("         else convert(varchar(10), convert(datetime, htt.HoshoTorokuUriageDt), 111)                                      ");
            sqlContent.AppendLine("     end as HoshoTorokuUriageDt,                                                                                         ");
            sqlContent.AppendLine("     htt.HoshoTorokuHanbaisakiCd,                                                                                        ");
            sqlContent.AppendLine("     htt.HoshoTorokuChumonNo,                                                                                            ");
            sqlContent.AppendLine("     htt.HoshoTorokuKensakikan,                                                                                          ");
            sqlContent.AppendLine("     htt.HoshoTorokuNendo,                                                                                               ");
            sqlContent.AppendLine("     htt.HoshoTorokuRenban,                                                                                              ");
            sqlContent.AppendLine("     concat(concat(htt.HoshoTorokuKensakikan, [dbo].[FuncConvertIraiNedoToWareki](htt.HoshoTorokuNendo)),                ");
            sqlContent.AppendLine("         htt.HoshoTorokuRenban) as HoshoTorokuNo                                                                         ");
            sqlContent.AppendLine(" from HoshoTorokuTbl htt                                                                                                 ");
            sqlContent.AppendLine(" where                                                                                                                   ");
            sqlContent.AppendLine("     htt.HoshoTorokuDeleteFlg = '0'                                                                                      ");

            if (!string.IsNullOrEmpty(searchCond.HoshoTorokuKensakikan)
                && !string.IsNullOrEmpty(searchCond.HoshoTorokuNendo)
                && !string.IsNullOrEmpty(searchCond.HoshoTorokuRenban))
            {
                sqlContent.AppendLine(" and htt.HoshoTorokuKensakikan = @HoshoTorokuKensakikan");
                sqlContent.AppendLine(" and htt.HoshoTorokuNendo = @HoshoTorokuNendo");
                sqlContent.AppendLine(" and htt.HoshoTorokuRenban >= @HoshoTorokuRenban");
                commandParams.Add("@HoshoTorokuKensakikan", SqlDbType.NVarChar).Value = (string)searchCond.HoshoTorokuKensakikan;
                commandParams.Add("@HoshoTorokuNendo", SqlDbType.NVarChar).Value = (string)searchCond.HoshoTorokuNendo;
                commandParams.Add("@HoshoTorokuRenban", SqlDbType.NVarChar).Value = (string)searchCond.HoshoTorokuRenban;
            }

            // Add mode
            if (searchCond.AkibanMode == AkibanMode.Add)
            {
                sqlContent.AppendLine(" and isnull(HoshoTorokuChumonNo, '') = ''");
            }

            // Update mode
            if (searchCond.AkibanMode == AkibanMode.Edit)
            {
                sqlContent.AppendLine(" and (isnull(HoshoTorokuChumonNo, '') = '' or HoshoTorokuChumonNo = @HoshoTorokuChumonNo) ");
                commandParams.Add("@HoshoTorokuChumonNo", SqlDbType.NVarChar).Value = (string)searchCond.HoshoTorokuChumonNo;
            }

            // Display mode
            if (searchCond.AkibanMode == AkibanMode.Display)
            {
                sqlContent.AppendLine(" and htt.HoshoTorokuChumonNo = @HoshoTorokuChumonNo");
                commandParams.Add("@HoshoTorokuChumonNo", SqlDbType.NVarChar).Value = (string)searchCond.HoshoTorokuChumonNo;
            }

            // Order
            sqlContent.AppendLine(" order by                                                                                                                ");
            sqlContent.AppendLine("     htt.HoshoTorokuKensakikan,                                                                                          ");
            sqlContent.AppendLine("     htt.HoshoTorokuNendo,                                                                                               ");
            sqlContent.AppendLine("     htt.HoshoTorokuRenban                                                                                               ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

    #region YoshiDetailTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： YoshiDetailTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/26　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class YoshiDetailTableAdapter
    {
        #region CommandTimeout
        // コマンドタイムアウト設定（単位は秒）
        public int CommandTimeout
        {
            get { return CommandCollection[0].CommandTimeout; }
            set
            {
                for (int i = 0; i < this.CommandCollection.Length; ++i)
                {
                    if (CommandCollection[i] != null)
                    {
                        ((System.Data.SqlClient.SqlCommand)(this.CommandCollection[i])).CommandTimeout = value;
                    }
                }
            }
        }
        #endregion

        #region GetDataByYoshiCdChumonNo
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataByYoshiCdChumonNo
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shishoCd"></param>
        /// <param name="chumonNo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/26　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal TyumonShosaiDataSet.YoshiDetailDataTable GetDataByYoshiCdChumonNo(string shishoCd, string chumonNo)
        {
            SqlCommand command = CreateSqlCommand(shishoCd, chumonNo);

            // コマンドタイムアウトセット
            command.CommandTimeout = CommandTimeout;

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            TyumonShosaiDataSet.YoshiDetailDataTable dataTable = new TyumonShosaiDataSet.YoshiDetailDataTable();
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
        /// <param name="shishoCd"></param>
        /// <param name="chumonNo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/26　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// 2015/01/28　kiyokuni　　 設計仕様バグを修正
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(string shishoCd, string chumonNo)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // ADD mode
            if (!string.IsNullOrEmpty(chumonNo))
            {
                sqlContent.AppendLine(" select                                                                                                                  ");
                sqlContent.AppendLine("     ym.YoshiCd,                                                                                                         ");
                sqlContent.AppendLine("     ym.YoshiNm,                                                                                                         ");
                sqlContent.AppendLine("     case                                                                                                                ");
                sqlContent.AppendLine("         when ym.YoshiKaiinSetKakaku > 0 then ym.YoshiKaiinSetKakaku                                                     ");
                sqlContent.AppendLine("         else ym.YoshiKaiinUp                                                                                            ");
                sqlContent.AppendLine("     end as KaiinTankaCol,                                                                                               ");
                sqlContent.AppendLine("     case                                                                                                                ");
                sqlContent.AppendLine("         when ym.YoshiHiKaiinSetKakaku > 0 then ym.YoshiHiKaiinSetKakaku                                                 ");
                sqlContent.AppendLine("         else ym.YoshiKaiinSetKakaku                                                                                     ");
                sqlContent.AppendLine("     end as HiKaiinTankaCol,                                                                                             ");
                sqlContent.AppendLine("     case                                                                                                                ");
                sqlContent.AppendLine("         when ym.YoshiSetBusu = 0 then null                                                                              ");
                sqlContent.AppendLine("         else ym.YoshiSetBusu                                                                                            ");
                sqlContent.AppendLine("     end as YoshiSetBusu,                                                                                                ");
                sqlContent.AppendLine("     case                                                                                                                ");
                sqlContent.AppendLine("         when ym.YoshiSetBusu > 0 then yhdt.YoshiHanbaiSetSuryo                                                          ");
                sqlContent.AppendLine("         when ym.YoshiSetBusu = 0 then yhdt.YoshiHanbaiSuryo                                                             ");
                sqlContent.AppendLine("     end as HanbaiCntCol,                                                                                                ");
                sqlContent.AppendLine("     case                                                                                                                ");
                sqlContent.AppendLine("         when ym.YoshiSetBusu > 0 then yhdt.YoshiHanbaiSetSuryo                                                          ");
                sqlContent.AppendLine("         when ym.YoshiSetBusu = 0 then yhdt.YoshiHanbaiSuryo                                                             ");
                sqlContent.AppendLine("     end as HanbaiCntHidenCol,                                                                                           ");
                sqlContent.AppendLine("     '0' as HoshoTorokuFlgHideCol,                                                                                       ");
                sqlContent.AppendLine("     isnull(yzt.YoshiZaikoSuryo,0) as ZaikoCntHideCol,                                                                   ");
                //sqlContent.AppendLine("     yzt.YoshiZaikoSuryo as ZaikoCntHideCol,                                                                           ");
                sqlContent.AppendLine("     null as HanbaiKakakuCol,                                                                                            ");
                sqlContent.AppendLine("     null as SyohizeiCol,                                                                                                ");
                sqlContent.AppendLine("     null as HanbaiKingakuCol                                                                                            ");
                sqlContent.AppendLine(" from YoshiMst ym                                                                                                        ");
                sqlContent.AppendLine(" left join YoshiZaikoTbl yzt                                                                                             ");
                //sqlContent.AppendLine(" inner join YoshiZaikoTbl yzt                                                                                          ");
                sqlContent.AppendLine("     on ym.YoshiCd = yzt.YoshiZaikoYoshiCd                                                                               ");
                sqlContent.AppendLine("     and yzt.YoshiZaikoShishoCd = @YoshiZaikoShishoCd                                                                    ");
                sqlContent.AppendLine(" left outer join YoshiHanbaiDtlTbl yhdt                                                                                  ");
                sqlContent.AppendLine("     on ym.YoshiCd = yhdt.YoshiHanbaiYoshiCd                                                                             ");
                sqlContent.AppendLine("     and yhdt.YoshiHanbaiChumonNo = @YoshiHanbaiChumonNo                                                                 ");
                sqlContent.AppendLine(" where                                                                                                                   ");
                sqlContent.AppendLine("     (ym.YoshiKaiinUp <> 0                                                                                               ");
                sqlContent.AppendLine("     or ym.YoshiHiKaiinUp <> 0                                                                                           ");
                sqlContent.AppendLine("     or ym.YoshiKaiinSetKakaku <> 0                                                                                      ");
                sqlContent.AppendLine("     or ym.YoshiHiKaiinSetKakaku <> 0)                                                                                   ");

                //sqlContent.AppendLine("     ym.YoshiKaiinUp <> 0                                                                                                ");
                //sqlContent.AppendLine("     and ym.YoshiHiKaiinUp <> 0                                                                                          ");
                //sqlContent.AppendLine("     and ym.YoshiKaiinSetKakaku <> 0                                                                                     ");
                //sqlContent.AppendLine("     and ym.YoshiHiKaiinSetKakaku <> 0                                                                                   ");


                commandParams.Add("@YoshiZaikoShishoCd", SqlDbType.NVarChar).Value = (string)shishoCd;
                commandParams.Add("@YoshiHanbaiChumonNo", SqlDbType.NVarChar).Value = (string)chumonNo;
            }
            else // ADD mode
            {
                sqlContent.AppendLine(" select                                                                                                                  ");
                sqlContent.AppendLine("     ym.YoshiCd,                                                                                                         ");
                sqlContent.AppendLine("     ym.YoshiNm,                                                                                                         ");
                sqlContent.AppendLine("     case                                                                                                                ");
                sqlContent.AppendLine("         when ym.YoshiKaiinSetKakaku > 0 then ym.YoshiKaiinSetKakaku                                                     ");
                sqlContent.AppendLine("         else ym.YoshiKaiinUp                                                                                            ");
                sqlContent.AppendLine("     end as KaiinTankaCol,                                                                                               ");
                sqlContent.AppendLine("     case                                                                                                                ");
                sqlContent.AppendLine("         when ym.YoshiHiKaiinSetKakaku > 0 then ym.YoshiHiKaiinSetKakaku                                                 ");
                sqlContent.AppendLine("         else ym.YoshiKaiinSetKakaku                                                                                     ");
                sqlContent.AppendLine("     end as HiKaiinTankaCol,                                                                                             ");
                sqlContent.AppendLine("     case                                                                                                                ");
                sqlContent.AppendLine("         when ym.YoshiSetBusu = 0 then null                                                                              ");
                sqlContent.AppendLine("         else ym.YoshiSetBusu                                                                                            ");
                sqlContent.AppendLine("     end as YoshiSetBusu,                                                                                                ");
                sqlContent.AppendLine("     null as HanbaiCntCol,                                                                                               ");
                sqlContent.AppendLine("     '0' as HanbaiCntHidenCol,                                                                                           ");
                sqlContent.AppendLine("     '0' as HoshoTorokuFlgHideCol,                                                                                       ");
                sqlContent.AppendLine("     '0' as ZaikoCntHideCol,                                                                                             ");
                sqlContent.AppendLine("     null as HanbaiKakakuCol,                                                                                            ");
                sqlContent.AppendLine("     null as SyohizeiCol,                                                                                                ");
                sqlContent.AppendLine("     null as HanbaiKingakuCol                                                                                            ");
                sqlContent.AppendLine(" from YoshiMst ym                                                                                                        ");
                sqlContent.AppendLine(" where                                                                                                                   ");
                sqlContent.AppendLine("     (ym.YoshiKaiinUp <> 0                                                                                               ");
                sqlContent.AppendLine("     or ym.YoshiHiKaiinUp <> 0                                                                                           ");
                sqlContent.AppendLine("     or ym.YoshiKaiinSetKakaku <> 0                                                                                      ");
                sqlContent.AppendLine("     or ym.YoshiHiKaiinSetKakaku <> 0)                                                                                   ");
                //sqlContent.AppendLine("     ym.YoshiKaiinUp <> 0                                                                                                ");
                //sqlContent.AppendLine("     and ym.YoshiHiKaiinUp <> 0                                                                                          ");
                //sqlContent.AppendLine("     and ym.YoshiKaiinSetKakaku <> 0                                                                                     ");
                //sqlContent.AppendLine("     and ym.YoshiHiKaiinSetKakaku <> 0                                                                                   ");
            }

            // Order
            sqlContent.AppendLine(" order by                                                                                                                    ");
            sqlContent.AppendLine("     ym.YoshiCd                                                                                                              ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion
}
