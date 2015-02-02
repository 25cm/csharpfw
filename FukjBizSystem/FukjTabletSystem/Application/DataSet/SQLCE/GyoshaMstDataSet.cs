using System.ComponentModel;
using System.Data.SqlServerCe;
using System.Text;
using FukjTabletSystem.Application.DataAccess;

namespace FukjTabletSystem.Application.DataSet.SQLCE {
    
    
    public partial class GyoshaMstDataSet
    {
        partial class GyoshaMstKensakuDataTable
        {
        }

        #region GyoshaMstSearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： GyoshaMstSearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/22　豊田   　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public class GyoshaMstSearchCond
        {
            /// <summary>
            /// 業者コード（開始）
            /// </summary>
            public string GyoshaCdFrom { get; set; }

            /// <summary>
            /// 業者コード（終了）
            /// </summary>
            public string GyoshaCdTo { get; set; }

            /// <summary>
            /// 業者名称
            /// </summary>
            public string GyoshaNm { get; set; }

            /// <summary>
            /// 業者カナ名
            /// </summary>
            public string GyoshaKana { get; set; }

            /// <summary>
            /// 製造業者区分
            /// </summary>
            public string SeizoGyoShaKbn { get; set; }

            /// <summary>
            /// 工事業者区分
            /// </summary>
            public string KojiGyoshaKbn { get; set; }

            /// <summary>
            /// 保守業者区分
            /// </summary>
            public string HoshuGyoshaKbn { get; set; }

            /// <summary>
            /// 清掃業者区分
            /// </summary>
            public string SeisoGyoshaKbn { get; set; }

            /// <summary>
            /// 取扱業者区分
            /// </summary>
            public string ToriatsukaiGyoshaKbn { get; set; }

            /// <summary>
            /// その他業者区分
            /// </summary>
            public string SonotaGyoshaKbn { get; set; }
        }
        #endregion
    }
}

namespace FukjTabletSystem.Application.DataSet.SQLCE.GyoshaMstDataSetTableAdapters
{
    #region GyoshaMstKensakuTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GyoshaMstKensakuTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/22　豊田   　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class GyoshaMstKensakuTableAdapter
    {

        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gyoshaMstSearchCond"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/22　豊田   　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal GyoshaMstDataSet.GyoshaMstKensakuDataTable GetDataBySearchCond(FukjTabletSystem.Application.DataSet.SQLCE.GyoshaMstDataSet.GyoshaMstSearchCond gyoshaMstSearchCond)
        {
            SqlCeCommand command = CreateSqlCommand(gyoshaMstSearchCond);

            SqlCeDataAdapter adpt = new SqlCeDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            GyoshaMstDataSet.GyoshaMstKensakuDataTable dataTable = new GyoshaMstDataSet.GyoshaMstKensakuDataTable();
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
        /// <param name="gyoshaMstSearchCond"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/22　豊田   　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCeCommand CreateSqlCommand(GyoshaMstDataSet.GyoshaMstSearchCond gyoshaMstSearchCond)
        {
            SqlCeCommand command = new System.Data.SqlServerCe.SqlCeCommand();
            SqlCeParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            //SELECT
            sqlContent.Append("SELECT                           ");

            sqlContent.Append("     	GyoshaCd,	            ");
            sqlContent.Append("     	GyoshaNm,	            ");
            sqlContent.Append("     	GyoshaKana,	            ");
            sqlContent.Append("     	GyoshaZipCd,	        ");
            sqlContent.Append("     	GyoshaAdr,	            ");
            sqlContent.Append("     	GyoshaTelNo,	        ");
            sqlContent.Append("     	GyoshaFaxNo,	        ");
            sqlContent.Append("     	DaihyoshaNm,	        ");
            sqlContent.Append("     	KoujiTorokuNo,	        ");
            sqlContent.Append("     	KyodoKumiaiCd,	        ");
            sqlContent.Append("     	KaiinKbn,	            ");
            sqlContent.Append("     	KanpukinShukeisakiCd,   ");
            sqlContent.Append("     	KojiGyoshaKbn,	        ");
            sqlContent.Append("     	HoshuGyoshaKbn,	        ");
            sqlContent.Append("     	SeisoGyoshaKbn,	        ");
            sqlContent.Append("     	SeizoGyoShaKbn,	        ");
            sqlContent.Append("     	ToriatsukaiGyoshaKbn,   ");
            sqlContent.Append("     	ToriatsukaiGyoshaCd,    ");
            sqlContent.Append("     	SonotaGyoshaKbn,	    ");
            sqlContent.Append("     	MakerNm,	            ");
            sqlContent.Append("     	KanpuUmuFlg,	        ");
            sqlContent.Append("     	[7JoKensaIraiIchiranHakkoFlg],	");
            sqlContent.Append("     	HaigyoFlg,	            ");
            sqlContent.Append("     	HaigyoDt,	            ");
            sqlContent.Append("     	HaigyoRiyu,	            ");
            sqlContent.Append("     	Sanjokaihi,	            ");
            sqlContent.Append("     	SofusakiTantoshaNm,	    ");
            sqlContent.Append("     	DataWatashiFlg,	        ");
            sqlContent.Append("     	[5JoDataFlg],	        ");
            sqlContent.Append("     	[7JoDataFlg],	        ");
            sqlContent.Append("     	[11JoSuishitsuDataFlg],	    ");
            sqlContent.Append("     	[11JoGaikanDataFlg],	    ");
            sqlContent.Append("     	KihonDataFlg,	        ");
            sqlContent.Append("     	SuishitsuDataFlg,	    ");
            sqlContent.Append("     	ShokenDataFlg,	        ");
            sqlContent.Append("     	GaikanDataFlg,	        ");
            sqlContent.Append("     	ShoruiDataFlg,	        ");
            sqlContent.Append("     	KenHoshuGyoShaTorokuNo,	");
            sqlContent.Append("     	FukuokashiGyoShaTorokuNo,	");
            sqlContent.Append("     	KurumeshiGyoShaTorokuNo,	");
            sqlContent.Append("     	ZenEigyoKuikiFlg,	    ");
            sqlContent.Append("     	BankCd,	                ");
            sqlContent.Append("     	BankNm,	                ");
            sqlContent.Append("     	BankShitenCd,	        ");
            sqlContent.Append("     	BankShitenNm,	        ");
            sqlContent.Append("     	BankKozaShubetsuNm,	    ");
            sqlContent.Append("     	BankKozaNo,	            ");
            sqlContent.Append("     	BankKozaMeigi,	        ");
            sqlContent.Append("     	SeikyuBunriFlg,	        ");
            sqlContent.Append("     	ShiharaiKbn,	        ");
            sqlContent.Append("     	IkkatsuSeikyuSakiCd,	");
            sqlContent.Append("     	HassoTantosha	        ");

            //FROM
            sqlContent.Append("FROM GyoshaMst ");

            //WHERE
            sqlContent.Append(" WHERE 1 = 1 ");

            sqlContent.Append("AND GyoshaCd " + DataAccessUtility.SetBetweenCommand(gyoshaMstSearchCond.GyoshaCdFrom, gyoshaMstSearchCond.GyoshaCdTo, 4));

            if (!string.IsNullOrEmpty(gyoshaMstSearchCond.GyoshaNm))
            {
                sqlContent.Append(string.Format("AND GyoshaNm LIKE '%{0}%' ", DataAccessUtility.EscapeSQLString(gyoshaMstSearchCond.GyoshaNm)));
            }

            if (!string.IsNullOrEmpty(gyoshaMstSearchCond.GyoshaKana))
            {
                sqlContent.Append(string.Format("AND GyoshaKana LIKE '%{0}%' ", DataAccessUtility.EscapeSQLString(gyoshaMstSearchCond.GyoshaKana)));
            }

            if (!string.IsNullOrEmpty(gyoshaMstSearchCond.SeizoGyoShaKbn))
            {
                sqlContent.Append("AND SeizoGyoShaKbn = '1'            ");
            }

            if (!string.IsNullOrEmpty(gyoshaMstSearchCond.KojiGyoshaKbn))
            {
                sqlContent.Append("AND KojiGyoshaKbn = '1'             ");
            }

            if (!string.IsNullOrEmpty(gyoshaMstSearchCond.HoshuGyoshaKbn))
            {
                sqlContent.Append("AND HoshuGyoshaKbn = '1'            ");
            }

            if (!string.IsNullOrEmpty(gyoshaMstSearchCond.SeisoGyoshaKbn))
            {
                sqlContent.Append("AND SeisoGyoshaKbn = '1'            ");
            }

            if (!string.IsNullOrEmpty(gyoshaMstSearchCond.ToriatsukaiGyoshaKbn))
            {
                sqlContent.Append("AND ToriatsukaiGyoshaKbn = '1'      ");
            }

            if (!string.IsNullOrEmpty(gyoshaMstSearchCond.SonotaGyoshaKbn))
            {
                sqlContent.Append("AND SonotaGyoshaKbn = '1'           ");
            }

            // ORDER BY
            sqlContent.Append("ORDER BY GyoshaCd                                                ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }

    #endregion
}