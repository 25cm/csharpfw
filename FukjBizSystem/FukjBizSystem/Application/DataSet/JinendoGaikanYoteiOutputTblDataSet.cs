using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using FukjBizSystem.Application.DataAccess;

namespace FukjBizSystem.Application.DataSet {
    
    
    public partial class JinendoGaikanYoteiOutputTblDataSet {
        partial class JinendoGaikanKensaYoteiNyuryokuDataTable
        {
        }
    }
}

namespace FukjBizSystem.Application.DataSet.JinendoGaikanYoteiOutputTblDataSetTableAdapters {


    #region JinendoGaikanKensaYoteiNyuryokuTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： JinendoGaikanKensaYoteiNyuryokuTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class JinendoGaikanKensaYoteiNyuryokuTableAdapter
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

        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bushoCdFrom"></param>
        /// <param name="bushoCdTo"></param>
        /// <param name="bushoNm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanKensaYoteiNyuryokuDataTable GetDataBySearchCond(string sakuseiNendo, string chikuCdFrom, string chikuCdTo,
            string gyoshaCdFrom, string gyoshaCdTo, string iraiNoFromHokenjo, string iraiNoFromNendo, string iraiNoFromRenban, string iraiNoToHokenjo, string iraiNoToNendo,
            string iraiNoToRenban, int ninsoKbn, int iraiMakeKbn)
        {
            SqlCommand command = CreateSqlCommand(sakuseiNendo, chikuCdFrom, chikuCdTo, gyoshaCdFrom, gyoshaCdTo, iraiNoFromHokenjo, iraiNoFromNendo,
                iraiNoFromRenban, iraiNoToHokenjo, iraiNoToNendo, iraiNoToRenban, ninsoKbn, iraiMakeKbn);

            // コマンドタイムアウトセット
            command.CommandTimeout = CommandTimeout;

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanKensaYoteiNyuryokuDataTable dataTable = new JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanKensaYoteiNyuryokuDataTable();
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
        /// <param name="bushoCdFrom"></param>
        /// <param name="bushoCdTo"></param>
        /// <param name="bushoNm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　HieuNH　　　新規作成
        /// 2014/12/28　habu 　　　 件数制限対応
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(string sakuseiNendo, string chikuCdFrom, string chikuCdTo,
            string gyoshaCdFrom, string gyoshaCdTo, string iraiNoFromHokenjo, string iraiNoFromNendo, string iraiNoFromRenban, string iraiNoToHokenjo, string iraiNoToNendo,
            string iraiNoToRenban, int ninsoKbn, int iraiMakeKbn)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();
            //SELECT
            // 20141228 habu → 仕様上戻す kiyokuni
            //sqlContent.Append(" SELECT TOP 2000 jgyot.JokasoHokenjoCd, jgyot.JokasoTorokuNendo, jgyot.JokasoRenban,                                                      ");
            sqlContent.Append(" SELECT jgyot.JokasoHokenjoCd, jgyot.JokasoTorokuNendo, jgyot.JokasoRenban,                                                      ");
            // 20141228 End
            sqlContent.Append(" { fn CONCAT({ fn CONCAT({ fn CONCAT({ fn CONCAT(jgyot.JokasoHokenjoCd, '-') },                                                  ");
            sqlContent.Append(" dbo.FuncConvertIraiNedoToWareki(jgyot.JokasoTorokuNendo)) }, '-') }, jgyot.JokasoRenban) } AS JokasoNo,                         ");
            sqlContent.Append(" SUBSTRING(jgyot.YoteiNengetsu, 5, 2) AS YoteiNengetsuDisp,                                                                           ");
            sqlContent.Append(" jgyot.YoteiNengetsu, jdm.JokasoSetchishaNm, jdm.JokasoShoriTaishoJinin, jdm.JokasoShoriHosikiKbn, jgyot.ZenkaiKensaDt,          ");

            sqlContent.Append(" CASE                                                                                                                            ");
            sqlContent.Append(" WHEN                                                                                                                            ");
            sqlContent.Append(" ISDATE(jgyot.ZenkaiKensaDt) = 1                                                                                                 ");
            sqlContent.Append("   THEN  CONVERT(varchar(10), CONVERT(date, jgyot.ZenkaiKensaDt), 111)                                                           ");
            sqlContent.Append(" ELSE ''                                                                                                                         ");
            sqlContent.Append(" END AS ZenkaiKensaDtDisp,                                                                                                       ");

            sqlContent.Append(" cm.ConstNm, jgyot.SeikyuGyoshaCd, gm.GyoshaNm,                                                         ");
            sqlContent.Append(" jgyot.UpdateTarm, jgyot.UpdateUser, jgyot.UpdateDt, jgyot.InsertTarm, jgyot.InsertUser, jgyot.InsertDt,                         ");

            sqlContent.Append(" CASE                                                                                                                            ");
            sqlContent.Append(" WHEN                                                                                                                            ");
            sqlContent.Append(" temp.NendonaiUmu >0                                                                                                             ");
            sqlContent.Append("   THEN '0'                                                                                                                      ");
            sqlContent.Append(" ELSE '1'                                                                                                                        ");
            sqlContent.Append(" END AS Sakusei,                                                                                                                 ");

            sqlContent.Append(" CASE                                                                                                                            ");
            sqlContent.Append(" WHEN                                                                                                                            ");
            sqlContent.Append(" temp.NendonaiUmu >0                                                                                                             ");
            sqlContent.Append("   THEN '有'                                                                                                                     ");
            sqlContent.Append(" ELSE ''                                                                                                                         ");
            sqlContent.Append(" END AS NendonaiUmu                                                                                                              ");
            //FROM
            sqlContent.Append(" FROM JinendoGaikanYoteiOutputTbl AS jgyot                                                                                       ");
            sqlContent.Append(" INNER JOIN JokasoDaichoMst AS jdm ON jgyot.JokasoHokenjoCd = jdm.JokasoHokenjoCd                                                ");
            sqlContent.Append(" AND jgyot.JokasoRenban = jdm.JokasoRenban                                                                                       ");
            sqlContent.Append(" AND jgyot.JokasoTorokuNendo = jdm.JokasoTorokuNendo                                                                             ");
            sqlContent.Append(" LEFT OUTER JOIN GyoshaMst AS gm ON jgyot.SeikyuGyoshaCd = gm.GyoshaCd                                                           ");
            sqlContent.Append(" AND jgyot.JokasoTorokuNendo = jdm.JokasoTorokuNendo                                                                             ");
            sqlContent.Append(" AND jgyot.JokasoRenban = jdm.JokasoRenban                                                                                       ");
            sqlContent.Append(" LEFT OUTER JOIN ConstMst AS cm ON cm.ConstValue = jdm.JokasoShoriHosikiKbn  AND cm.ConstKbn = '" + Utility.Constants.ConstKbnConstanst.CONST_KBN_022 + "'    ");

            sqlContent.Append(" LEFT OUTER JOIN (SELECT  COUNT(*) AS NendonaiUmu,                                                                               ");
            sqlContent.Append(" KensaIraiTbl.KensaIraiJokasoHokenjoCd, KensaIraiTbl.KensaIraiJokasoTorokuNendo, KensaIraiTbl.KensaIraiJokasoRenban              ");
            sqlContent.Append(" FROM KensaIraiTbl                                                                                                               ");
            sqlContent.Append(" WHERE KensaIraiTbl.KensaIraiNendo = @iraiNendo                                                                                  ");
            commandParams.Add("@iraiNendo", SqlDbType.NVarChar).Value = sakuseiNendo;
            sqlContent.Append(" GROUP BY  KensaIraiTbl.KensaIraiJokasoHokenjoCd, KensaIraiTbl.KensaIraiJokasoTorokuNendo, KensaIraiTbl.KensaIraiJokasoRenban    ");
            sqlContent.Append(" ) AS temp ON jgyot.JokasoHokenjoCd = temp.KensaIraiJokasoHokenjoCd                                                              ");
            sqlContent.Append(" AND jgyot.JokasoTorokuNendo = temp.KensaIraiJokasoTorokuNendo    ");
            sqlContent.Append(" AND jgyot.JokasoRenban = temp.KensaIraiJokasoRenban                                                                             ");

            //WHERE
            sqlContent.Append(" WHERE 1 = 1 ");

            sqlContent.Append(" AND jgyot.Nendo = @Nendo ");
            commandParams.Add("@Nendo", SqlDbType.NVarChar).Value = sakuseiNendo;

            if(!string.IsNullOrEmpty(chikuCdFrom) && string.IsNullOrEmpty(chikuCdTo))
            {
                sqlContent.Append(" AND jdm.JokasoGenChikuCd  >= @chikuCdFrom");
                commandParams.Add("@chikuCdFrom", SqlDbType.NVarChar).Value = chikuCdFrom;
            }
            else if (string.IsNullOrEmpty(chikuCdFrom) && !string.IsNullOrEmpty(chikuCdTo))
            {
                sqlContent.Append(" AND jdm.JokasoGenChikuCd  <= @chikuCdTo");
                commandParams.Add("@chikuCdTo", SqlDbType.NVarChar).Value = chikuCdTo;
            }
            else if (!string.IsNullOrEmpty(chikuCdFrom) && !string.IsNullOrEmpty(chikuCdTo))
            {
                sqlContent.Append(" AND jdm.JokasoGenChikuCd  >= @chikuCdFrom");
                sqlContent.Append(" AND jdm.JokasoGenChikuCd  <= @chikuCdTo");
                commandParams.Add("@chikuCdFrom", SqlDbType.NVarChar).Value = chikuCdFrom;
                commandParams.Add("@chikuCdTo", SqlDbType.NVarChar).Value = chikuCdTo;
            }

            if (!string.IsNullOrEmpty(gyoshaCdFrom) && string.IsNullOrEmpty(gyoshaCdTo))
            {
                sqlContent.Append(" AND jgyot.SeikyuGyoshaCd  >= @gyoshaCdFrom");
                commandParams.Add("@gyoshaCdFrom", SqlDbType.NVarChar).Value = gyoshaCdFrom;
            }
            else if (string.IsNullOrEmpty(gyoshaCdFrom) && !string.IsNullOrEmpty(gyoshaCdTo))
            {
                sqlContent.Append(" AND jgyot.SeikyuGyoshaCd  <= @gyoshaCdTo");
                commandParams.Add("@gyoshaCdTo", SqlDbType.NVarChar).Value = gyoshaCdTo;
            }
            else if (!string.IsNullOrEmpty(gyoshaCdFrom) && !string.IsNullOrEmpty(gyoshaCdTo))
            {
                sqlContent.Append(" AND jgyot.SeikyuGyoshaCd  >= @gyoshaCdFrom");
                sqlContent.Append(" AND jgyot.SeikyuGyoshaCd  <= @gyoshaCdTo");
                commandParams.Add("@gyoshaCdFrom", SqlDbType.NVarChar).Value = gyoshaCdFrom;
                commandParams.Add("@gyoshaCdTo", SqlDbType.NVarChar).Value = gyoshaCdTo;
            }

            if (!string.IsNullOrEmpty(iraiNoFromHokenjo) && string.IsNullOrEmpty(iraiNoToHokenjo))
            {
                sqlContent.Append(" AND jgyot.JokasoHokenjoCd  >= @iraiNoFromHokenjo");
                commandParams.Add("@iraiNoFromHokenjo", SqlDbType.NVarChar).Value = chikuCdFrom;
            }
            else if (string.IsNullOrEmpty(iraiNoFromHokenjo) && !string.IsNullOrEmpty(iraiNoToHokenjo))
            {
                sqlContent.Append(" AND jgyot.JokasoHokenjoCd  <= @iraiNoToHokenjo");
                commandParams.Add("@iraiNoToHokenjo", SqlDbType.NVarChar).Value = iraiNoToHokenjo;
            }
            else if (!string.IsNullOrEmpty(iraiNoFromHokenjo) && !string.IsNullOrEmpty(iraiNoToHokenjo))
            {
                sqlContent.Append(" AND jgyot.JokasoHokenjoCd  >= @iraiNoFromHokenjo");
                sqlContent.Append(" AND jgyot.JokasoHokenjoCd  <= @iraiNoToHokenjo");
                commandParams.Add("@iraiNoFromHokenjo", SqlDbType.NVarChar).Value = iraiNoFromHokenjo;
                commandParams.Add("@iraiNoToHokenjo", SqlDbType.NVarChar).Value = iraiNoToHokenjo;
            }


            if (!string.IsNullOrEmpty(iraiNoFromNendo) && string.IsNullOrEmpty(iraiNoToNendo))
            {
                sqlContent.Append(" AND jgyot.JokasoTorokuNendo >= @iraiNoFromNendo");
                commandParams.Add("@iraiNoFromNendo", SqlDbType.NVarChar).Value = iraiNoFromNendo;
            }
            else if (string.IsNullOrEmpty(iraiNoFromNendo) && !string.IsNullOrEmpty(iraiNoToNendo))
            {
                sqlContent.Append(" AND jgyot.JokasoTorokuNendo  <= @iraiNoToNendo");
                commandParams.Add("@iraiNoToNendo", SqlDbType.NVarChar).Value = iraiNoToNendo;
            }
            else if (!string.IsNullOrEmpty(iraiNoFromNendo) && !string.IsNullOrEmpty(iraiNoToNendo))
            {
                sqlContent.Append(" AND jgyot.JokasoTorokuNendo  >= @iraiNoFromNendo");
                sqlContent.Append(" AND jgyot.JokasoTorokuNendo  <= @iraiNoToNendo");
                commandParams.Add("@iraiNoFromNendo", SqlDbType.NVarChar).Value = iraiNoFromNendo;
                commandParams.Add("@iraiNoToNendo", SqlDbType.NVarChar).Value = iraiNoToNendo;
            }

            if (!string.IsNullOrEmpty(iraiNoFromRenban) && string.IsNullOrEmpty(iraiNoToRenban))
            {
                sqlContent.Append(" AND jgyot.JokasoRenban >= @iraiNoFromRenban");
                commandParams.Add("@iraiNoFromRenban", SqlDbType.NVarChar).Value = iraiNoFromRenban;
            }
            else if (string.IsNullOrEmpty(iraiNoFromRenban) && !string.IsNullOrEmpty(iraiNoToRenban))
            {
                sqlContent.Append(" AND jgyot.JokasoRenban  <= @iraiNoToRenban");
                commandParams.Add("@iraiNoToRenban", SqlDbType.NVarChar).Value = iraiNoToRenban;
            }
            else if (!string.IsNullOrEmpty(iraiNoFromRenban) && !string.IsNullOrEmpty(iraiNoToRenban))
            {
                sqlContent.Append(" AND jgyot.JokasoRenban  >= @iraiNoFromRenban");
                sqlContent.Append(" AND jgyot.JokasoRenban  <= @iraiNoToRenban");
                commandParams.Add("@iraiNoFromRenban", SqlDbType.NVarChar).Value = iraiNoFromRenban;
                commandParams.Add("@iraiNoToRenban", SqlDbType.NVarChar).Value = iraiNoToRenban;
            }

            if (ninsoKbn == 1)
            {
                sqlContent.Append(" AND jgyot.NinsoKbn = '1'    ");
            }
            else if (ninsoKbn == 2)
            {
                sqlContent.Append(" AND jgyot.NinsoKbn = '2'    ");
            }

            if (iraiMakeKbn == 0)
            {
                sqlContent.Append(" AND jgyot.IraiMakeKbn = '0'    ");
            }

            // ORDER BY
            sqlContent.Append(" ORDER BY jgyot.SeikyuGyoshaCd ASC, ");
            sqlContent.Append(" jgyot.JokasoHokenjoCd ASC, ");
            sqlContent.Append(" jgyot.JokasoTorokuNendo ASC, ");
            sqlContent.Append(" jgyot.JokasoRenban ASC ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion

    }
    #endregion

}
