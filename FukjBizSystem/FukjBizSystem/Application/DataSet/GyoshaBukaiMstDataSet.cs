using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FukjBizSystem.Application.DataSet {
        
    public partial class GyoshaBukaiMstDataSet {
    }
}

namespace FukjBizSystem.Application.DataSet.GyoshaBukaiMstDataSetTableAdapters {


    #region KaiinListTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KaiinListTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/21  DatNT　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KaiinListTableAdapter
    {
        #region 定数

        //private const string SQL_APPEND_MIKANYUCHECK = "(ISNULL(Tbl.SeizoCol, '') = '' AND ISNULL(Tbl.KojiCol, '') = '' AND ISNULL(Tbl.HosyuCol, '') = '' AND ISNULL(Tbl.SeisoCol, '') = '' ) ";

        #endregion

        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gyosyaCdFrom"></param>
        /// <param name="gyosyaCdTo"></param>
        /// <param name="gyosyaNm"></param>
        /// <param name="seizo"></param>
        /// <param name="koji"></param>
        /// <param name="hosyu"></param>
        /// <param name="seiso"></param>
        /// <param name="mikanyu"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21　DatNT　　 新規作成
        /// 2015/01/30  DatNT       v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal GyoshaBukaiMstDataSet.KaiinListDataTable GetDataBySearchCond(
            string gyosyaCdFrom,
            string gyosyaCdTo,
            string gyosyaNm,
            // 2015/01/30 DatNT v1.04 DEL Start
            //bool nyukaiDtUse,
            //string nyukaiDtFrom,
            //string nyukaiDtTo,
            // 2015/01/30 DatNT v1.04 DEL End
            bool seizo,
            bool koji,
            bool hosyu,
            bool seiso,
            bool mikanyu)
        {
            SqlCommand command = CreateSqlCommand(gyosyaCdFrom,
                                                    gyosyaCdTo,
                                                    gyosyaNm,
                                                    // 2015/01/30 DatNT v1.04 DEL Start
                                                    //nyukaiDtUse,
                                                    //nyukaiDtFrom,
                                                    //nyukaiDtTo,
                                                    // 2015/01/30 DatNT v1.04 DEL End
                                                    seizo,
                                                    koji,
                                                    hosyu,
                                                    seiso,
                                                    mikanyu);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            GyoshaBukaiMstDataSet.KaiinListDataTable dataTable = new GyoshaBukaiMstDataSet.KaiinListDataTable();
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
        /// <param name="gyosyaCdFrom"></param>
        /// <param name="gyosyaCdTo"></param>
        /// <param name="gyosyaNm"></param>
        /// <param name="seizo"></param>
        /// <param name="koji"></param>
        /// <param name="hosyu"></param>
        /// <param name="seiso"></param>
        /// <param name="mikanyu"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21　DatNT　　新規作成
        /// 2014/12/25　kiyokuni　設計書に書いたSQLの使い方を間違っていたので全面的に修正
        /// 2015/01/30  DatNT       v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            string gyosyaCdFrom,
            string gyosyaCdTo,
            string gyosyaNm,
            // 2015/01/30 DatNT v1.04 DEL Start
            //bool nyukaiDtUse,
            //string nyukaiDtFrom,
            //string nyukaiDtTo,
            // 2015/01/30 DatNT v1.04 DEL End
            bool seizo,
            bool koji,
            bool hosyu,
            bool seiso,
            bool mikanyu)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            #region 2014/12/24 DatNT DEL
            //// SELECT
            //sqlContent.Append("SELECT                                                                                                                   ");
            //sqlContent.Append("     Tbl.GyoshaCd,                                                                                                       ");
            //sqlContent.Append("     Tbl.BukaiGyoshaCd,                                                                                                  ");
            //sqlContent.Append("     Tbl.GyoshaNm,                                                                                                       ");
            //sqlContent.Append("     CASE                                                                                                                ");
            //sqlContent.Append("         WHEN Tbl.SeizoCol <> 0                                                                                          ");
            //sqlContent.Append("             THEN CONCAT(SUBSTRING(CAST(Tbl.SeizoCol AS CHAR),0,5), '/',                                                 ");
            //sqlContent.Append("                         SUBSTRING(CAST(Tbl.SeizoCol AS CHAR),5,2), '/',                                                 ");
            //sqlContent.Append("                         SUBSTRING(CAST(Tbl.SeizoCol AS CHAR),7,2)) END AS SeizoCol,                                     ");
            //sqlContent.Append("     CASE                                                                                                                ");
            //sqlContent.Append("         WHEN Tbl.KojiCol <> 0                                                                                           ");
            //sqlContent.Append("             THEN CONCAT(SUBSTRING(CAST(Tbl.KojiCol AS CHAR),0,5), '/',                                                  ");
            //sqlContent.Append("                         SUBSTRING(CAST(Tbl.KojiCol AS CHAR),5,2), '/',                                                  ");
            //sqlContent.Append("                         SUBSTRING(CAST(Tbl.KojiCol AS CHAR),7,2)) END AS KojiCol,                                       ");
            //sqlContent.Append("     CASE                                                                                                                ");
            //sqlContent.Append("         WHEN Tbl.HosyuCol <> 0                                                                                          ");
            //sqlContent.Append("             THEN CONCAT(SUBSTRING(CAST(Tbl.HosyuCol AS CHAR),0,5), '/',                                                 ");
            //sqlContent.Append("                         SUBSTRING(CAST(Tbl.HosyuCol AS CHAR),5,2), '/',                                                 ");
            //sqlContent.Append("                         SUBSTRING(CAST(Tbl.HosyuCol AS CHAR),7,2)) END AS HosyuCol,                                     ");
            //sqlContent.Append("     CASE                                                                                                                ");
            //sqlContent.Append("         WHEN Tbl.SeisoCol <> 0                                                                                          ");
            //sqlContent.Append("             THEN CONCAT(SUBSTRING(CAST(Tbl.SeisoCol AS CHAR),0,5), '/',                                                 ");
            //sqlContent.Append("                         SUBSTRING(CAST(Tbl.SeisoCol AS CHAR),5,2), '/',                                                 ");
            //sqlContent.Append("                         SUBSTRING(CAST(Tbl.SeisoCol AS CHAR),7,2)) END AS SeisoCol                                      ");

            //// FROM
            //sqlContent.Append("FROM                                                                                                                     ");
            //sqlContent.Append("     (                                                                                                                   ");
            //sqlContent.Append("     SELECT                                                                                                              ");
            //sqlContent.Append("         GyoshaMst.GyoshaCd,                                                                                             ");
            //sqlContent.Append("         GyoshaBukaiMst.BukaiGyoshaCd,                                                                                   ");
            //sqlContent.Append("         GyoshaMst.GyoshaNm,                                                                                             ");
            //sqlContent.Append("         SUM (CASE                                                                                                       ");
            //sqlContent.Append("                 WHEN GyoshaBukaiMst.BukaiKbn = '1'                                                                      ");
            //sqlContent.Append("                      AND ISNULL(GyoshaBukaiMst.BukaiNyukaiDt, '') <> '' THEN CAST(GyoshaBukaiMst.BukaiNyukaiDt AS INT)  ");
            //sqlContent.Append("                 WHEN GyoshaBukaiMst.BukaiKbn = '1'                                                                      ");
            //sqlContent.Append("                      AND ISNULL(GyoshaBukaiMst.BukaiNyukaiDt, '') = ''  THEN 0                                          ");
            //sqlContent.Append("             END) AS SeizoCol,                                                                                           ");
            //sqlContent.Append("         SUM (CASE                                                                                                       ");
            //sqlContent.Append("                 WHEN GyoshaBukaiMst.BukaiKbn = '2'                                                                      ");
            //sqlContent.Append("                      AND ISNULL(GyoshaBukaiMst.BukaiNyukaiDt, '') <> '' THEN CAST(GyoshaBukaiMst.BukaiNyukaiDt AS INT)  ");
            //sqlContent.Append("                 WHEN GyoshaBukaiMst.BukaiKbn = '2'                                                                      ");
            //sqlContent.Append("                      AND ISNULL(GyoshaBukaiMst.BukaiNyukaiDt, '') = ''  THEN 0                                          ");
            //sqlContent.Append("             END) AS KojiCol,                                                                                            ");
            //sqlContent.Append("         SUM (CASE                                                                                                       ");
            //sqlContent.Append("                 WHEN GyoshaBukaiMst.BukaiKbn = '3'                                                                      ");
            //sqlContent.Append("                      AND ISNULL(GyoshaBukaiMst.BukaiNyukaiDt, '') <> '' THEN CAST(GyoshaBukaiMst.BukaiNyukaiDt AS INT)  ");
            //sqlContent.Append("                 WHEN GyoshaBukaiMst.BukaiKbn = '3'                                                                      ");
            //sqlContent.Append("                      AND ISNULL(GyoshaBukaiMst.BukaiNyukaiDt, '') = ''  THEN 0                                          ");
            //sqlContent.Append("             END) AS HosyuCol,                                                                                           ");
            //sqlContent.Append("         SUM (CASE                                                                                                       ");
            //sqlContent.Append("                 WHEN GyoshaBukaiMst.BukaiKbn = '4'                                                                      ");
            //sqlContent.Append("                      AND ISNULL(GyoshaBukaiMst.BukaiNyukaiDt, '') <> '' THEN CAST(GyoshaBukaiMst.BukaiNyukaiDt AS INT)  ");
            //sqlContent.Append("                 WHEN GyoshaBukaiMst.BukaiKbn = '4'                                                                      ");
            //sqlContent.Append("                      AND ISNULL(GyoshaBukaiMst.BukaiNyukaiDt, '') = ''  THEN 0                                          ");
            //sqlContent.Append("             END) AS SeisoCol                                                                                            ");
            //sqlContent.Append("     FROM                                                                                                                ");
            //sqlContent.Append("         GyoshaMst                                                                                                       ");
            //sqlContent.Append("             LEFT OUTER JOIN                                                                                             ");
            //sqlContent.Append("                 GyoshaBukaiMst                                                                                          ");
            //sqlContent.Append("                     ON GyoshaMst.GyoshaCd = GyoshaBukaiMst.BukaiGyoshaCd                                                ");
            //sqlContent.Append("     WHERE                                                                                                               ");
            //sqlContent.Append("         1 = 1                                                                                                           ");

            ////sqlContent.Append("AND GyoshaMst.GyoshaCd " + DataAccessUtility.SetBetweenCommand(gyosyaCdFrom, gyosyaCdTo, 4));
            ////sqlContent.Append("AND GyoshaBukaiMst.BukaiGyoshaCd " + DataAccessUtility.SetBetweenCommand(gyosyaCdFrom, gyosyaCdTo, 4));

            //if (!string.IsNullOrEmpty(gyosyaCdFrom))
            //{
            //    sqlContent.Append("AND GyoshaMst.GyoshaCd >= @gyosyaCdFrom ");
            //    commandParams.Add("@gyosyaCdFrom", SqlDbType.NVarChar).Value = gyosyaCdFrom;
            //}
            
            //if (!string.IsNullOrEmpty(gyosyaCdTo))
            //{
            //    sqlContent.Append("AND GyoshaMst.GyoshaCd <= @gyosyaCdTo ");
            //    commandParams.Add("@gyosyaCdTo", SqlDbType.NVarChar).Value = gyosyaCdTo;
            //}
            
            //if (!string.IsNullOrEmpty(gyosyaNm))
            //{
            //    sqlContent.Append("AND GyoshaMst.GyoshaNm LIKE CONCAT('%', @gyosyaNm, '%') ");
            //    commandParams.Add("@gyosyaNm", SqlDbType.NVarChar).Value = gyosyaNm;
            //}

            //if (nyukaiDtUse)
            //{
            //    sqlContent.Append("AND GyoshaBukaiMst.BukaiNyukaiDt >= @nyukaiDtFrom ");
            //    sqlContent.Append("AND GyoshaBukaiMst.BukaiNyukaiDt <= @nyukaiDtTo ");
            //    commandParams.Add("@nyukaiDtFrom", SqlDbType.NVarChar).Value = nyukaiDtFrom;
            //    commandParams.Add("@nyukaiDtTo", SqlDbType.NVarChar).Value = nyukaiDtTo;
            //}

            //sqlContent.Append("AND (                                                                                                                    ");
            //sqlContent.Append("         ((ISNULL(GyoshaBukaiMst.BukaiTaikaiDt, '') = '' AND ISNULL(GyoshaBukaiMst.BukaiNyukaiDt, '') <> ''))            ");
            //sqlContent.Append("      OR                                                                                                                 ");
            //sqlContent.Append("         (ISNULL(BukaiNyukaiDt, '') <> '' AND ISNULL(BukaiTaikaiDt, '') <> '')                                           ");
            //sqlContent.Append("      OR                                                                                                                 ");
            //sqlContent.Append("         (ISNULL(BukaiNyukaiDt, '') = '' AND ISNULL(BukaiTaikaiDt, '') = '')                                             ");
            //sqlContent.Append("     )                                                                                                                   ");

            //#region del
            ////sqlContent.Append("     (   ISNULL(GyoshaBukaiMst.BukaiTaikaiDt, '') = '' AND ISNULL(GyoshaBukaiMst.BukaiNyukaiDt, '') <> ''    )           ");

            ////if (mikanyu)
            ////{
            ////    if (!seizo && !koji && !hosyu && !seizo)
            ////    {
            ////        //sqlContent.Append("     OR                                                                                                                  ");
            ////        //sqlContent.Append("     (   ISNULL(GyoshaBukaiMst.BukaiTaikaiDt, '') <> '' AND ISNULL(GyoshaBukaiMst.BukaiNyukaiDt, '') = ''    )           ");

            ////        sqlContent.Append("         GyoshaBukaiMst.BukaiGyoshaCd in (                                                                               ");
            ////        sqlContent.Append("                                         SELECT BukaiGyoshaCd                                                            ");
            ////        sqlContent.Append("                                         FROM GyoshaBukaiMst                                                             ");
            ////        sqlContent.Append("                                         WHERE ISNULL(BukaiNyukaiDt, '') = ''                                            ");
            ////        sqlContent.Append("                                         GROUP BY BukaiGyoshaCd HAVING COUNT(*)=4                                        ");
            ////        sqlContent.Append("                                         )                                                                               ");
            ////        sqlContent.Append("     AND                                                                                                                 ");
            ////        sqlContent.Append("         GyoshaBukaiMst.BukaiGyoshaCd in (                                                                               ");
            ////        sqlContent.Append("                                         SELECT BukaiGyoshaCd                                                            ");
            ////        sqlContent.Append("                                         FROM GyoshaBukaiMst                                                             ");
            ////        sqlContent.Append("                                         WHERE ISNULL(BukaiTaikaiDt, '') <> ''                                           ");
            ////        sqlContent.Append("                                         GROUP BY BukaiGyoshaCd HAVING COUNT(*)=4                                        ");
            ////        sqlContent.Append("                                         )                                                                               ");
            ////    }
            ////    else
            ////    {
            ////        //sqlContent.Append("     (   ISNULL(GyoshaBukaiMst.BukaiTaikaiDt, '') = '' AND ISNULL(GyoshaBukaiMst.BukaiNyukaiDt, '') <> ''    )           ");
            ////        //sqlContent.Append("     OR                                                                                                                  ");
            ////        //sqlContent.Append("     (   ISNULL(GyoshaBukaiMst.BukaiTaikaiDt, '') <> '' AND ISNULL(GyoshaBukaiMst.BukaiNyukaiDt, '') = ''    )           ");

            ////        sqlContent.Append("    (     GyoshaBukaiMst.BukaiGyoshaCd in (                                                                              ");
            ////        sqlContent.Append("                                         SELECT BukaiGyoshaCd                                                            ");
            ////        sqlContent.Append("                                         FROM GyoshaBukaiMst                                                             ");
            ////        sqlContent.Append("                                         WHERE ISNULL(BukaiNyukaiDt, '') = ''                                            ");
            ////        sqlContent.Append("                                         GROUP BY BukaiGyoshaCd HAVING COUNT(*)=4                                        ");
            ////        sqlContent.Append("                                         )                                                                               ");
            ////        sqlContent.Append("     AND                                                                                                                 ");
            ////        sqlContent.Append("         GyoshaBukaiMst.BukaiGyoshaCd in (                                                                               ");
            ////        sqlContent.Append("                                         SELECT BukaiGyoshaCd                                                            ");
            ////        sqlContent.Append("                                         FROM GyoshaBukaiMst                                                             ");
            ////        sqlContent.Append("                                         WHERE ISNULL(BukaiTaikaiDt, '') <> ''                                           ");
            ////        sqlContent.Append("                                         GROUP BY BukaiGyoshaCd HAVING COUNT(*)=4                                        ");
            ////        sqlContent.Append("                                         )                                                                               ");
            ////        sqlContent.Append("    )                                                                                                                    ");
            ////        sqlContent.Append("     OR                                                                                                                  ");
            ////        sqlContent.Append("     (   ISNULL(GyoshaBukaiMst.BukaiTaikaiDt, '') = '' AND ISNULL(GyoshaBukaiMst.BukaiNyukaiDt, '') <> ''    )           ");
            ////    }
            ////}
            ////else
            ////{
            ////    sqlContent.Append("     (   ISNULL(GyoshaBukaiMst.BukaiTaikaiDt, '') = '' AND ISNULL(GyoshaBukaiMst.BukaiNyukaiDt, '') <> ''    )           ");
            ////}

            ////sqlContent.Append("         GyoshaBukaiMst.BukaiGyoshaCd in (                                                                               ");
            ////sqlContent.Append("                                         SELECT BukaiGyoshaCd                                                            ");
            ////sqlContent.Append("                                         FROM GyoshaBukaiMst                                                             ");
            ////sqlContent.Append("                                         WHERE ISNULL(BukaiNyukaiDt, '') = ''                                            ");
            ////sqlContent.Append("                                         GROUP BY BukaiGyoshaCd HAVING COUNT(*)=4                                        ");
            ////sqlContent.Append("                                         )                                                                               ");
            ////sqlContent.Append("     OR                                                                                                                  ");
            ////sqlContent.Append("         GyoshaBukaiMst.BukaiGyoshaCd in (                                                                               ");
            ////sqlContent.Append("                                         SELECT BukaiGyoshaCd                                                            ");
            ////sqlContent.Append("                                         FROM GyoshaBukaiMst                                                             ");
            ////sqlContent.Append("                                         WHERE ISNULL(BukaiTaikaiDt, '') <> ''                                           ");
            ////sqlContent.Append("                                         GROUP BY BukaiGyoshaCd HAVING COUNT(*)=4                                        ");
            ////sqlContent.Append("                                         )                                                                               ");
            ////sqlContent.Append("     )                                                                                                                   ");
            //#endregion

            //sqlContent.Append("     GROUP BY                                                                                                            ");
            //sqlContent.Append("         GyoshaMst.GyoshaCd,                                                                                             ");
            //sqlContent.Append("         GyoshaBukaiMst.BukaiGyoshaCd,                                                                                   ");
            //sqlContent.Append("         GyoshaMst.GyoshaNm                                                                                              ");
            //sqlContent.Append("     ) Tbl                                                                                                               ");

            //// WHERE 
            //sqlContent.Append("WHERE                                                                                                                    ");
            //sqlContent.Append("     1 = 1                                                                                                               ");
            
            //#region seizo - koji - hosyu - seizo - mikanyu

            //#region 1, 2, 3, 4
            //// 1
            //if (seizo && !koji && !hosyu && !seiso && mikanyu)
            //{
            //    //sqlContent.Append("AND (ISNULL(Tbl.SeizoCol, '') <> '' )                                        ");
            //    //sqlContent.Append("OR " + SQL_APPEND_MIKANYUCHECK);
            //    sqlContent.Append("AND Tbl.BukaiGyoshaCd IN (   SELECT  BukaiGyoshaCd                                                                   ");
            //    sqlContent.Append("                             FROM    GyoshaBukaiMst                                                                  ");
            //    sqlContent.Append("                             WHERE   ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> '' AND BukaiKbn IN ( '1' ) ");
            //    sqlContent.Append("                         )                                                                                           ");
            //    sqlContent.Append("OR Tbl.BukaiGyoshaCd NOT IN  (   SELECT  BukaiGyoshaCd                                                               ");
            //    sqlContent.Append("                                 FROM    GyoshaBukaiMst                                                              ");
            //    sqlContent.Append("                                 WHERE   (ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> '')        ");
            //    sqlContent.Append("                             )                                                                                       ");
            //}
            //else if (seizo && !koji && !hosyu && !seiso && !mikanyu)
            //{
            //    sqlContent.Append("AND ISNULL(Tbl.SeizoCol, '') <> ''                                                                                   ");
            //    sqlContent.Append("AND Tbl.BukaiGyoshaCd IN (   SELECT  BukaiGyoshaCd                                                                   ");
            //    sqlContent.Append("                             FROM    GyoshaBukaiMst                                                                  ");
            //    sqlContent.Append("                             WHERE   ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> ''              ");
            //    sqlContent.Append("                         )                                                                                           ");
            //}
            //// 2
            //else if (!seizo && koji && !hosyu && !seiso && mikanyu)
            //{
            //    //sqlContent.Append("AND (ISNULL(Tbl.KojiCol, '') <> '' )                                                                                 ");
            //    //sqlContent.Append("OR " + SQL_APPEND_MIKANYUCHECK);
            //    sqlContent.Append("AND Tbl.BukaiGyoshaCd IN (   SELECT  BukaiGyoshaCd                                                                   ");
            //    sqlContent.Append("                             FROM    GyoshaBukaiMst                                                                  ");
            //    sqlContent.Append("                             WHERE   ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> '' AND BukaiKbn IN ( '2' ) ");
            //    sqlContent.Append("                         )                                                                                           ");
            //    sqlContent.Append("OR Tbl.BukaiGyoshaCd NOT IN  (   SELECT  BukaiGyoshaCd                                                               ");
            //    sqlContent.Append("                                 FROM    GyoshaBukaiMst                                                              ");
            //    sqlContent.Append("                                 WHERE   (ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> '')        ");
            //    sqlContent.Append("                             )                                                                                       ");
            //}
            //else if (!seizo && koji && !hosyu && !seiso && !mikanyu)
            //{
            //    sqlContent.Append("AND ISNULL(Tbl.KojiCol, '') <> ''                                                                                    ");
            //    sqlContent.Append("AND Tbl.BukaiGyoshaCd IN (   SELECT  BukaiGyoshaCd                                                                   ");
            //    sqlContent.Append("                             FROM    GyoshaBukaiMst                                                                  ");
            //    sqlContent.Append("                             WHERE   ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> ''              ");
            //    sqlContent.Append("                         )                                                                                           ");
            //}
            //// 3
            //else if (!seizo && !koji && hosyu && !seiso && mikanyu)
            //{
            //    //sqlContent.Append("AND (ISNULL(Tbl.HosyuCol, '') <> '' )                                        ");
            //    //sqlContent.Append("OR " + SQL_APPEND_MIKANYUCHECK);
            //    sqlContent.Append("AND Tbl.BukaiGyoshaCd IN (   SELECT  BukaiGyoshaCd                                                                   ");
            //    sqlContent.Append("                             FROM    GyoshaBukaiMst                                                                  ");
            //    sqlContent.Append("                             WHERE   ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> '' AND BukaiKbn IN ( '3' ) ");
            //    sqlContent.Append("                         )                                                                                           ");
            //    sqlContent.Append("OR Tbl.BukaiGyoshaCd NOT IN  (   SELECT  BukaiGyoshaCd                                                               ");
            //    sqlContent.Append("                                 FROM    GyoshaBukaiMst                                                              ");
            //    sqlContent.Append("                                 WHERE   (ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> '')        ");
            //    sqlContent.Append("                             )                                                                                       ");
            //}
            //else if (!seizo && !koji && hosyu && !seiso && !mikanyu)
            //{
            //    sqlContent.Append("AND ISNULL(Tbl.HosyuCol, '') <> ''                                                                                   ");
            //    sqlContent.Append("AND Tbl.BukaiGyoshaCd IN (   SELECT  BukaiGyoshaCd                                                                   ");
            //    sqlContent.Append("                             FROM    GyoshaBukaiMst                                                                  ");
            //    sqlContent.Append("                             WHERE   ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> ''              ");
            //    sqlContent.Append("                         )                                                                                           ");
            //}
            //// 4
            //else if (!seizo && !koji && !hosyu && seiso && mikanyu)
            //{
            //    //sqlContent.Append("AND (ISNULL(Tbl.SeisoCol, '') <> '' )                                        ");
            //    //sqlContent.Append("OR " + SQL_APPEND_MIKANYUCHECK);
            //    sqlContent.Append("AND Tbl.BukaiGyoshaCd IN (   SELECT  BukaiGyoshaCd                                                                   ");
            //    sqlContent.Append("                             FROM    GyoshaBukaiMst                                                                  ");
            //    sqlContent.Append("                             WHERE   ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> '' AND BukaiKbn IN ( '4' ) ");
            //    sqlContent.Append("                         )                                                                                           ");
            //    sqlContent.Append("OR Tbl.BukaiGyoshaCd NOT IN  (   SELECT  BukaiGyoshaCd                                                               ");
            //    sqlContent.Append("                                 FROM    GyoshaBukaiMst                                                              ");
            //    sqlContent.Append("                                 WHERE   (ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> '')        ");
            //    sqlContent.Append("                             )                                                                                       ");
            //}
            //else if (!seizo && !koji && !hosyu && seiso && !mikanyu)
            //{
            //    sqlContent.Append("AND ISNULL(Tbl.SeisoCol, '') <> ''                                                                                   ");
            //    sqlContent.Append("AND Tbl.BukaiGyoshaCd IN (   SELECT  BukaiGyoshaCd                                                                   ");
            //    sqlContent.Append("                             FROM    GyoshaBukaiMst                                                                  ");
            //    sqlContent.Append("                             WHERE   ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> ''              ");
            //    sqlContent.Append("                         )                                                                                           ");
            //}
            //// 5
            //else if (!seizo && !koji && !hosyu && !seiso && mikanyu)
            //{
            //    //sqlContent.Append(SQL_APPEND_MIKANYUCHECK);
            //    sqlContent.Append("AND Tbl.BukaiGyoshaCd NOT IN (   SELECT  BukaiGyoshaCd                                                               ");
            //    sqlContent.Append("                                 FROM    GyoshaBukaiMst                                                              ");
            //    sqlContent.Append("                                 WHERE   ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> ''          ");
            //    sqlContent.Append("                             )                                                                                       ");
            //}
            //#endregion

            //#region 12, 13, 14, 23, 24, 34
            //// 12
            //else if (seizo && koji && !hosyu && !seiso && mikanyu)
            //{
            //    //sqlContent.Append("AND (        ISNULL(Tbl.SeizoCol, '') <> ''                                  ");
            //    //sqlContent.Append("        OR   ISNULL(Tbl.KojiCol, '') <> ''                                   ");
            //    //sqlContent.Append("     )                                                                       ");
            //    //sqlContent.Append("OR " + SQL_APPEND_MIKANYUCHECK);
            //    sqlContent.Append("AND Tbl.BukaiGyoshaCd IN (   SELECT  BukaiGyoshaCd                                                                   ");
            //    sqlContent.Append("                             FROM    GyoshaBukaiMst                                                                  ");
            //    sqlContent.Append("                             WHERE   ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> '' AND BukaiKbn IN ( '1', '2' ) ");
            //    sqlContent.Append("                         )                                                                                           ");
            //    sqlContent.Append("OR Tbl.BukaiGyoshaCd NOT IN  (   SELECT  BukaiGyoshaCd                                                               ");
            //    sqlContent.Append("                                 FROM    GyoshaBukaiMst                                                              ");
            //    sqlContent.Append("                                 WHERE   (ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> '')        ");
            //    sqlContent.Append("                             )                                                                                       ");
            //}
            //else if (seizo && koji && !hosyu && !seiso && !mikanyu)
            //{
            //    sqlContent.Append("AND (        ISNULL(Tbl.SeizoCol, '') <> ''                                  ");
            //    sqlContent.Append("        OR   ISNULL(Tbl.KojiCol, '') <> ''                                   ");
            //    sqlContent.Append("     )                                                                       ");
            //    sqlContent.Append("AND Tbl.BukaiGyoshaCd IN (   SELECT  BukaiGyoshaCd                                                                   ");
            //    sqlContent.Append("                             FROM    GyoshaBukaiMst                                                                  ");
            //    sqlContent.Append("                             WHERE   ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> ''              ");
            //    sqlContent.Append("                         )                                                                                           ");
            //}
            //// 13
            //else if (seizo && !koji && hosyu && !seiso && mikanyu)
            //{
            //    //sqlContent.Append("AND (        ISNULL(Tbl.SeizoCol, '') <> ''                                  ");
            //    //sqlContent.Append("        OR   ISNULL(Tbl.HosyuCol, '') <> ''                                  ");
            //    //sqlContent.Append("     )                                                                       ");
            //    //sqlContent.Append("OR " + SQL_APPEND_MIKANYUCHECK);
            //    sqlContent.Append("AND Tbl.BukaiGyoshaCd IN (   SELECT  BukaiGyoshaCd                                                                   ");
            //    sqlContent.Append("                             FROM    GyoshaBukaiMst                                                                  ");
            //    sqlContent.Append("                             WHERE   ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> '' AND BukaiKbn IN ( '1', '3' ) ");
            //    sqlContent.Append("                         )                                                                                           ");
            //    sqlContent.Append("OR Tbl.BukaiGyoshaCd NOT IN  (   SELECT  BukaiGyoshaCd                                                               ");
            //    sqlContent.Append("                                 FROM    GyoshaBukaiMst                                                              ");
            //    sqlContent.Append("                                 WHERE   (ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> '')        ");
            //    sqlContent.Append("                             )                                                                                       ");
            //}
            //else if (seizo && !koji && hosyu && !seiso && !mikanyu)
            //{
            //    sqlContent.Append("AND (        ISNULL(Tbl.SeizoCol, '') <> ''                                  ");
            //    sqlContent.Append("        OR   ISNULL(Tbl.HosyuCol, '') <> ''                                  ");
            //    sqlContent.Append("     )                                                                       ");
            //    sqlContent.Append("AND Tbl.BukaiGyoshaCd IN (   SELECT  BukaiGyoshaCd                                                                   ");
            //    sqlContent.Append("                             FROM    GyoshaBukaiMst                                                                  ");
            //    sqlContent.Append("                             WHERE   ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> ''              ");
            //    sqlContent.Append("                         )                                                                                           ");
            //}
            //// 14
            //else if (seizo && !koji && !hosyu && seiso && mikanyu)
            //{
            //    //sqlContent.Append("AND (        ISNULL(Tbl.SeizoCol, '') <> ''                                  ");
            //    //sqlContent.Append("        OR   ISNULL(Tbl.SeisoCol, '') <> ''                                  ");
            //    //sqlContent.Append("     )                                                                       ");
            //    //sqlContent.Append("OR " + SQL_APPEND_MIKANYUCHECK);
            //    sqlContent.Append("AND Tbl.BukaiGyoshaCd IN (   SELECT  BukaiGyoshaCd                                                                   ");
            //    sqlContent.Append("                             FROM    GyoshaBukaiMst                                                                  ");
            //    sqlContent.Append("                             WHERE   ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> '' AND BukaiKbn IN ( '1', '4' ) ");
            //    sqlContent.Append("                         )                                                                                           ");
            //    sqlContent.Append("OR Tbl.BukaiGyoshaCd NOT IN  (   SELECT  BukaiGyoshaCd                                                               ");
            //    sqlContent.Append("                                 FROM    GyoshaBukaiMst                                                              ");
            //    sqlContent.Append("                                 WHERE   (ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> '')        ");
            //    sqlContent.Append("                             )                                                                                       ");
            //}
            //else if (seizo && !koji && !hosyu && seiso && !mikanyu)
            //{
            //    sqlContent.Append("AND (        ISNULL(Tbl.SeizoCol, '') <> ''                                  ");
            //    sqlContent.Append("        OR   ISNULL(Tbl.SeisoCol, '') <> ''                                  ");
            //    sqlContent.Append("     )                                                                       ");
            //    sqlContent.Append("AND Tbl.BukaiGyoshaCd IN (   SELECT  BukaiGyoshaCd                                                                   ");
            //    sqlContent.Append("                             FROM    GyoshaBukaiMst                                                                  ");
            //    sqlContent.Append("                             WHERE   ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> ''              ");
            //    sqlContent.Append("                         )                                                                                           ");
            //}
            //// 23
            //else if (!seizo && koji && hosyu && !seiso && mikanyu)
            //{
            //    //sqlContent.Append("AND (        ISNULL(Tbl.KojiCol, '') <> ''                                   ");
            //    //sqlContent.Append("        OR   ISNULL(Tbl.HosyuCol, '') <> ''                                  ");
            //    //sqlContent.Append("     )                                                                       ");
            //    //sqlContent.Append("OR " + SQL_APPEND_MIKANYUCHECK);
            //    sqlContent.Append("AND Tbl.BukaiGyoshaCd IN (   SELECT  BukaiGyoshaCd                                                                   ");
            //    sqlContent.Append("                             FROM    GyoshaBukaiMst                                                                  ");
            //    sqlContent.Append("                             WHERE   ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> '' AND BukaiKbn IN ( '2', '3' ) ");
            //    sqlContent.Append("                         )                                                                                           ");
            //    sqlContent.Append("OR Tbl.BukaiGyoshaCd NOT IN  (   SELECT  BukaiGyoshaCd                                                               ");
            //    sqlContent.Append("                                 FROM    GyoshaBukaiMst                                                              ");
            //    sqlContent.Append("                                 WHERE   (ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> '')        ");
            //    sqlContent.Append("                             )                                                                                       ");
            //}
            //else if (!seizo && koji && hosyu && !seiso && !mikanyu)
            //{
            //    sqlContent.Append("AND (        ISNULL(Tbl.KojiCol, '') <> ''                                   ");
            //    sqlContent.Append("        OR   ISNULL(Tbl.HosyuCol, '') <> ''                                  ");
            //    sqlContent.Append("     )                                                                       ");
            //    sqlContent.Append("AND Tbl.BukaiGyoshaCd IN (   SELECT  BukaiGyoshaCd                                                                   ");
            //    sqlContent.Append("                             FROM    GyoshaBukaiMst                                                                  ");
            //    sqlContent.Append("                             WHERE   ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> ''              ");
            //    sqlContent.Append("                         )                                                                                           ");
            //}
            //// 24
            //else if (!seizo && koji && !hosyu && seiso && mikanyu)
            //{
            //    //sqlContent.Append("AND (        ISNULL(Tbl.KojiCol, '') <> ''                                   ");
            //    //sqlContent.Append("        OR   ISNULL(Tbl.SeisoCol, '') <> ''                                  ");
            //    //sqlContent.Append("     )                                                                       ");
            //    //sqlContent.Append("OR " + SQL_APPEND_MIKANYUCHECK);
            //    sqlContent.Append("AND Tbl.BukaiGyoshaCd IN (   SELECT  BukaiGyoshaCd                                                                   ");
            //    sqlContent.Append("                             FROM    GyoshaBukaiMst                                                                  ");
            //    sqlContent.Append("                             WHERE   ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> '' AND BukaiKbn IN ( '2', '4' ) ");
            //    sqlContent.Append("                         )                                                                                           ");
            //    sqlContent.Append("OR Tbl.BukaiGyoshaCd NOT IN  (   SELECT  BukaiGyoshaCd                                                               ");
            //    sqlContent.Append("                                 FROM    GyoshaBukaiMst                                                              ");
            //    sqlContent.Append("                                 WHERE   (ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> '')        ");
            //    sqlContent.Append("                             )                                                                                       ");
            //}
            //else if (!seizo && koji && !hosyu && seiso && !mikanyu)
            //{
            //    sqlContent.Append("AND (        ISNULL(Tbl.KojiCol, '') <> ''                                   ");
            //    sqlContent.Append("        OR   ISNULL(Tbl.SeisoCol, '') <> ''                                  ");
            //    sqlContent.Append("     )                                                                       ");
            //    sqlContent.Append("AND Tbl.BukaiGyoshaCd IN (   SELECT  BukaiGyoshaCd                                                                   ");
            //    sqlContent.Append("                             FROM    GyoshaBukaiMst                                                                  ");
            //    sqlContent.Append("                             WHERE   ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> ''              ");
            //    sqlContent.Append("                         )                                                                                           ");
            //}
            //// 34
            //else if (!seizo && !koji && hosyu && seiso && mikanyu)
            //{
            //    //sqlContent.Append("AND (        ISNULL(Tbl.HosyuCol, '') <> ''                                  ");
            //    //sqlContent.Append("        OR   ISNULL(Tbl.SeisoCol, '') <> ''                                  ");
            //    //sqlContent.Append("     )                                                                       ");
            //    //sqlContent.Append("OR " + SQL_APPEND_MIKANYUCHECK);
            //    sqlContent.Append("AND Tbl.BukaiGyoshaCd IN (   SELECT  BukaiGyoshaCd                                                                   ");
            //    sqlContent.Append("                             FROM    GyoshaBukaiMst                                                                  ");
            //    sqlContent.Append("                             WHERE   ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> '' AND BukaiKbn IN ( '3', '4' ) ");
            //    sqlContent.Append("                         )                                                                                           ");
            //    sqlContent.Append("OR Tbl.BukaiGyoshaCd NOT IN  (   SELECT  BukaiGyoshaCd                                                               ");
            //    sqlContent.Append("                                 FROM    GyoshaBukaiMst                                                              ");
            //    sqlContent.Append("                                 WHERE   (ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> '')        ");
            //    sqlContent.Append("                             )                                                                                       ");
            //}
            //else if (!seizo && !koji && hosyu && seiso && !mikanyu)
            //{
            //    sqlContent.Append("AND (        ISNULL(Tbl.HosyuCol, '') <> ''                                  ");
            //    sqlContent.Append("        OR   ISNULL(Tbl.SeisoCol, '') <> ''                                  ");
            //    sqlContent.Append("     )                                                                       ");
            //    sqlContent.Append("AND Tbl.BukaiGyoshaCd IN (   SELECT  BukaiGyoshaCd                                                                   ");
            //    sqlContent.Append("                             FROM    GyoshaBukaiMst                                                                  ");
            //    sqlContent.Append("                             WHERE   ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> ''              ");
            //    sqlContent.Append("                         )                                                                                           ");
            //}
            //#endregion

            //#region 123, 124, 134, 234
            //// 123
            //else if (seizo && koji && hosyu && !seiso && mikanyu)
            //{
            //    //sqlContent.Append("AND (        ISNULL(Tbl.SeizoCol, '') <> ''                                  ");
            //    //sqlContent.Append("        OR   ISNULL(Tbl.KojiCol, '') <> ''                                   ");
            //    //sqlContent.Append("        OR   ISNULL(Tbl.HosyuCol, '') <> ''                                  ");
            //    //sqlContent.Append("     )                                                                       ");
            //    //sqlContent.Append("OR " + SQL_APPEND_MIKANYUCHECK);
            //    sqlContent.Append("AND Tbl.BukaiGyoshaCd IN (   SELECT  BukaiGyoshaCd                                                                   ");
            //    sqlContent.Append("                             FROM    GyoshaBukaiMst                                                                  ");
            //    sqlContent.Append("                             WHERE   ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> '' AND BukaiKbn IN ( '1', '2', '3' ) ");
            //    sqlContent.Append("                         )                                                                                           ");
            //    sqlContent.Append("OR Tbl.BukaiGyoshaCd NOT IN  (   SELECT  BukaiGyoshaCd                                                               ");
            //    sqlContent.Append("                                 FROM    GyoshaBukaiMst                                                              ");
            //    sqlContent.Append("                                 WHERE   (ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> '')        ");
            //    sqlContent.Append("                             )                                                                                       ");
            //}
            //else if (seizo && koji && hosyu && !seiso && !mikanyu)
            //{
            //    sqlContent.Append("AND (        ISNULL(Tbl.SeizoCol, '') <> ''                                  ");
            //    sqlContent.Append("        OR   ISNULL(Tbl.KojiCol, '') <> ''                                   ");
            //    sqlContent.Append("        OR   ISNULL(Tbl.HosyuCol, '') <> ''                                  ");
            //    sqlContent.Append("     )                                                                       ");
            //    sqlContent.Append("AND Tbl.BukaiGyoshaCd IN (   SELECT  BukaiGyoshaCd                                                                   ");
            //    sqlContent.Append("                             FROM    GyoshaBukaiMst                                                                  ");
            //    sqlContent.Append("                             WHERE   ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> ''              ");
            //    sqlContent.Append("                         )                                                                                           ");
            //}
            //// 124
            //else if (seizo && koji && !hosyu && seiso && mikanyu)
            //{
            //    //sqlContent.Append("AND (        ISNULL(Tbl.SeizoCol, '') <> ''                                  ");
            //    //sqlContent.Append("        OR   ISNULL(Tbl.KojiCol, '') <> ''                                   ");
            //    //sqlContent.Append("        OR   ISNULL(Tbl.SeisoCol, '') <> ''                                  ");
            //    //sqlContent.Append("     )                                                                       ");
            //    //sqlContent.Append("OR " + SQL_APPEND_MIKANYUCHECK);
            //    sqlContent.Append("AND Tbl.BukaiGyoshaCd IN (   SELECT  BukaiGyoshaCd                                                                   ");
            //    sqlContent.Append("                             FROM    GyoshaBukaiMst                                                                  ");
            //    sqlContent.Append("                             WHERE   ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> '' AND BukaiKbn IN ( '1', '2', '4' ) ");
            //    sqlContent.Append("                         )                                                                                           ");
            //    sqlContent.Append("OR Tbl.BukaiGyoshaCd NOT IN  (   SELECT  BukaiGyoshaCd                                                               ");
            //    sqlContent.Append("                                 FROM    GyoshaBukaiMst                                                              ");
            //    sqlContent.Append("                                 WHERE   (ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> '')        ");
            //    sqlContent.Append("                             )                                                                                       ");
            //}
            //else if (seizo && koji && !hosyu && seiso && !mikanyu)
            //{
            //    sqlContent.Append("AND (        ISNULL(Tbl.SeizoCol, '') <> ''                                  ");
            //    sqlContent.Append("        OR   ISNULL(Tbl.KojiCol, '') <> ''                                   ");
            //    sqlContent.Append("        OR   ISNULL(Tbl.SeisoCol, '') <> ''                                  ");
            //    sqlContent.Append("     )                                                                       ");
            //    sqlContent.Append("AND Tbl.BukaiGyoshaCd IN (   SELECT  BukaiGyoshaCd                                                                   ");
            //    sqlContent.Append("                             FROM    GyoshaBukaiMst                                                                  ");
            //    sqlContent.Append("                             WHERE   ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> ''              ");
            //    sqlContent.Append("                         )                                                                                           ");
            //}
            //// 134
            //else if (seizo && !koji && hosyu && seiso && mikanyu)
            //{
            //    //sqlContent.Append("AND (        ISNULL(Tbl.SeizoCol, '') <> ''                                  ");
            //    //sqlContent.Append("        OR   ISNULL(Tbl.HosyuCol, '') <> ''                                  ");
            //    //sqlContent.Append("        OR   ISNULL(Tbl.SeisoCol, '') <> ''                                  ");
            //    //sqlContent.Append("     )                                                                       ");
            //    //sqlContent.Append("OR " + SQL_APPEND_MIKANYUCHECK);
            //    sqlContent.Append("AND Tbl.BukaiGyoshaCd IN (   SELECT  BukaiGyoshaCd                                                                   ");
            //    sqlContent.Append("                             FROM    GyoshaBukaiMst                                                                  ");
            //    sqlContent.Append("                             WHERE   ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> '' AND BukaiKbn IN ( '1', '3', '4' ) ");
            //    sqlContent.Append("                         )                                                                                           ");
            //    sqlContent.Append("OR Tbl.BukaiGyoshaCd NOT IN  (   SELECT  BukaiGyoshaCd                                                               ");
            //    sqlContent.Append("                                 FROM    GyoshaBukaiMst                                                              ");
            //    sqlContent.Append("                                 WHERE   (ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> '')        ");
            //    sqlContent.Append("                             )                                                                                       ");
            //}
            //else if (seizo && !koji && hosyu && seiso && !mikanyu)
            //{
            //    sqlContent.Append("AND (        ISNULL(Tbl.SeizoCol, '') <> ''                                  ");
            //    sqlContent.Append("        OR   ISNULL(Tbl.HosyuCol, '') <> ''                                  ");
            //    sqlContent.Append("        OR   ISNULL(Tbl.SeisoCol, '') <> ''                                  ");
            //    sqlContent.Append("     )                                                                       ");
            //    sqlContent.Append("AND Tbl.BukaiGyoshaCd IN (   SELECT  BukaiGyoshaCd                                                                   ");
            //    sqlContent.Append("                             FROM    GyoshaBukaiMst                                                                  ");
            //    sqlContent.Append("                             WHERE   ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> ''              ");
            //    sqlContent.Append("                         )                                                                                           ");
            //}
            //// 234
            //else if (!seizo && koji && hosyu && seiso && mikanyu)
            //{
            //    //sqlContent.Append("AND (        ISNULL(Tbl.KojiCol, '') <> ''                                   ");
            //    //sqlContent.Append("        OR   ISNULL(Tbl.HosyuCol, '') <> ''                                  ");
            //    //sqlContent.Append("        OR   ISNULL(Tbl.SeisoCol, '') <> ''                                  ");
            //    //sqlContent.Append("     )                                                                       ");
            //    //sqlContent.Append("OR " + SQL_APPEND_MIKANYUCHECK);
            //    sqlContent.Append("AND Tbl.BukaiGyoshaCd IN (   SELECT  BukaiGyoshaCd                                                                   ");
            //    sqlContent.Append("                             FROM    GyoshaBukaiMst                                                                  ");
            //    sqlContent.Append("                             WHERE   ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> '' AND BukaiKbn IN ( '2', '3', '4' ) ");
            //    sqlContent.Append("                         )                                                                                           ");
            //    sqlContent.Append("OR Tbl.BukaiGyoshaCd NOT IN  (   SELECT  BukaiGyoshaCd                                                               ");
            //    sqlContent.Append("                                 FROM    GyoshaBukaiMst                                                              ");
            //    sqlContent.Append("                                 WHERE   (ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> '')        ");
            //    sqlContent.Append("                             )                                                                                       ");
            //}
            //else if (!seizo && koji && hosyu && seiso && !mikanyu)
            //{
            //    sqlContent.Append("AND (        ISNULL(Tbl.KojiCol, '') <> ''                                   ");
            //    sqlContent.Append("        OR   ISNULL(Tbl.HosyuCol, '') <> ''                                  ");
            //    sqlContent.Append("        OR   ISNULL(Tbl.SeisoCol, '') <> ''                                  ");
            //    sqlContent.Append("     )                                                                       ");
            //    sqlContent.Append("AND Tbl.BukaiGyoshaCd IN (   SELECT  BukaiGyoshaCd                                                                   ");
            //    sqlContent.Append("                             FROM    GyoshaBukaiMst                                                                  ");
            //    sqlContent.Append("                             WHERE   ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> ''              ");
            //    sqlContent.Append("                         )                                                                                           ");
            //}
            //#endregion

            //#region 1234
            //else if (seizo && koji && hosyu && seiso && mikanyu)
            //{
            //    //sqlContent.Append("AND (        ISNULL(Tbl.SeizoCol, '') <> ''                                  ");
            //    //sqlContent.Append("        OR   ISNULL(Tbl.KojiCol, '') <> ''                                   ");
            //    //sqlContent.Append("        OR   ISNULL(Tbl.HosyuCol, '') <> ''                                  ");
            //    //sqlContent.Append("        OR   ISNULL(Tbl.SeisoCol, '') <> ''                                  ");
            //    //sqlContent.Append("     )                                                                       ");
            //    //sqlContent.Append("OR " + SQL_APPEND_MIKANYUCHECK);
            //    sqlContent.Append("AND Tbl.BukaiGyoshaCd IN (   SELECT  BukaiGyoshaCd                                                                   ");
            //    sqlContent.Append("                             FROM    GyoshaBukaiMst                                                                  ");
            //    sqlContent.Append("                             WHERE   ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> '' AND BukaiKbn IN ( '1', '2', '3', '4' ) ");
            //    sqlContent.Append("                         )                                                                                           ");
            //    sqlContent.Append("OR Tbl.BukaiGyoshaCd NOT IN  (   SELECT  BukaiGyoshaCd                                                               ");
            //    sqlContent.Append("                                 FROM    GyoshaBukaiMst                                                              ");
            //    sqlContent.Append("                                 WHERE   (ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> '')        ");
            //    sqlContent.Append("                             )                                                                                       ");
            //}
            //else if (seizo && koji && hosyu && seiso && !mikanyu)
            //{
            //    sqlContent.Append("AND (        ISNULL(Tbl.SeizoCol, '') <> ''                                  ");
            //    sqlContent.Append("        OR   ISNULL(Tbl.KojiCol, '') <> ''                                   ");
            //    sqlContent.Append("        OR   ISNULL(Tbl.HosyuCol, '') <> ''                                  ");
            //    sqlContent.Append("        OR   ISNULL(Tbl.SeisoCol, '') <> ''                                  ");
            //    sqlContent.Append("     )                                                                       ");
            //    sqlContent.Append("AND Tbl.BukaiGyoshaCd IN (   SELECT  BukaiGyoshaCd                                                                   ");
            //    sqlContent.Append("                             FROM    GyoshaBukaiMst                                                                  ");
            //    sqlContent.Append("                             WHERE   ISNULL(BukaiTaikaiDt, '') = '' AND ISNULL(BukaiNyukaiDt, '') <> ''              ");
            //    sqlContent.Append("                         )                                                                                           ");
            //}
            //#endregion

            //#endregion

            //// ORDER BY
            //sqlContent.Append("ORDER BY                                                                                                                 ");
            //sqlContent.Append("     Tbl.GyoshaCd                                                                                                        ");
            #endregion

            string SEIZO = " (max(gbm.BukaiNyukaiDt1) <> '' and max(gbm.BukaiTaikaiDt1) = '') ";
            string KOJI = " (max(gbm.BukaiNyukaiDt2) <> '' and max(gbm.BukaiTaikaiDt2) = '') ";
            string HOSYU = " (max(gbm.BukaiNyukaiDt3) <> '' and max(gbm.BukaiTaikaiDt3) = '') ";
            string SEISO = " (max(gbm.BukaiNyukaiDt4) <> '' and max(gbm.BukaiTaikaiDt4) = '') ";
            string MIKANYU  = "         (                                                                   "
                                + "             (max(gbm.BukaiNyukaiDt1) = '' or max(gbm.BukaiTaikaiDt1) <> '')     "
                                + "             and                                                         "
                                + "             (max(gbm.BukaiNyukaiDt2) = '' or max(gbm.BukaiTaikaiDt2) <> '')     "
                                + "             and                                                         "
                                + "             (max(gbm.BukaiNyukaiDt3) = '' or max(gbm.BukaiTaikaiDt3) <> '')     "
                                + "             and                                                         "
                                + "             (max(gbm.BukaiNyukaiDt4) = '' or max(gbm.BukaiTaikaiDt4) <> '')     "
                                + "     )                                                                   ";

            // SELECT
            // 2015/01/30 DatNT v1.04 ADD Start
            sqlContent.Append("select                                                                                                                   ");
            sqlContent.Append(" Tbl.GyoshaCd,                                                                                                           ");
            sqlContent.Append(" Tbl.GyoshaNm,                                                                                                           ");
            sqlContent.Append(" Tbl.BukaiNyukaiDt1,                                                                                                     ");
            sqlContent.Append(" Tbl.BukaiTaikaiDt1,                                                                                                     ");
            sqlContent.Append(" Tbl.BukaiNyukaiDt2,                                                                                                     ");
            sqlContent.Append(" Tbl.BukaiTaikaiDt2,                                                                                                     ");
            sqlContent.Append(" Tbl.BukaiNyukaiDt3,                                                                                                     ");
            sqlContent.Append(" Tbl.BukaiTaikaiDt3,                                                                                                     ");
            sqlContent.Append(" Tbl.BukaiNyukaiDt4,                                                                                                     ");
            sqlContent.Append(" Tbl.BukaiTaikaiDt4,                                                                                                     ");
            sqlContent.Append(" GyoshaMst.GyoshaZipCd,                                                                                                  ");
            sqlContent.Append(" GyoshaMst.GyoshaAdr,                                                                                                    ");
            sqlContent.Append(" GyoshaMst.GyoshaTelNo,                                                                                                  ");
            sqlContent.Append(" GyoshaMst.GyoshaFaxNo,                                                                                                  ");
            sqlContent.Append(" GyoshaMst.DaihyoshaNm                                                                                                  ");

            sqlContent.Append("from                                                                                                                       ");
            sqlContent.Append(" (                                                                                                                       ");
            // 2015/01/30 DatNT v1.04 ADD End

            sqlContent.Append("select                                                                                                                   ");
            sqlContent.Append("     gm.GyoshaCd                                                                                                         ");
            sqlContent.Append("     , max(gm.GyoshaNm)			as GyoshaNm                                                                             ");

            sqlContent.Append("     , case when isnull(max(gbm.BukaiNyukaiDt1), '') <> '' and isnull(max(gbm.BukaiTaikaiDt1), '') = ''                                                         ");
            sqlContent.Append("            then concat(substring(max(gbm.BukaiNyukaiDt1), 0, 5) , '/',                                                  ");
            sqlContent.Append("                         substring(max(gbm.BukaiNyukaiDt1), 5, 2), '/',                                                  ");
            sqlContent.Append("                         substring(max(gbm.BukaiNyukaiDt1), 7, 2))                                                       ");
            sqlContent.Append("            else ''                                                                                        ");
            sqlContent.Append("            end as BukaiNyukaiDt1                                                                                        ");

            //sqlContent.Append("     , case when isnull(max(gbm.BukaiNyukaiDt1), '') = '' then ''                                                        ");
            //sqlContent.Append("            else concat(substring(max(gbm.BukaiNyukaiDt1), 0, 5) , '/',                                                  ");
            //sqlContent.Append("                         substring(max(gbm.BukaiNyukaiDt1), 5, 2), '/',                                                  ");
            //sqlContent.Append("                         substring(max(gbm.BukaiNyukaiDt1), 7, 2))                                                       ");
            //sqlContent.Append("            end as BukaiNyukaiDt1                                                                                        ");


            sqlContent.Append("     , case when isnull(max(gbm.BukaiTaikaiDt1), '') = '' then ''                                                        ");
            sqlContent.Append("            else concat(substring(max(gbm.BukaiTaikaiDt1), 0, 5) , '/',                                                  ");
            sqlContent.Append("                         substring(max(gbm.BukaiTaikaiDt1), 5, 2), '/',                                                  ");
            sqlContent.Append("                         substring(max(gbm.BukaiTaikaiDt1), 7, 2))                                                       ");
            sqlContent.Append("            end as BukaiTaikaiDt1                                                                                        ");

            sqlContent.Append("     , case when isnull(max(gbm.BukaiNyukaiDt2), '') <> '' and isnull(max(gbm.BukaiTaikaiDt2), '') = ''                                                         ");
            sqlContent.Append("            then concat(substring(max(gbm.BukaiNyukaiDt2), 0, 5) , '/',                                                  ");
            sqlContent.Append("                         substring(max(gbm.BukaiNyukaiDt2), 5, 2), '/',                                                  ");
            sqlContent.Append("                         substring(max(gbm.BukaiNyukaiDt2), 7, 2))                                                       ");
            sqlContent.Append("            else ''                                                                                        ");
            sqlContent.Append("            end as BukaiNyukaiDt2                                                                                        ");
            
            //sqlContent.Append("     , case when isnull(max(gbm.BukaiNyukaiDt2), '') = '' then ''                                                        ");
            //sqlContent.Append("            else concat(substring(max(gbm.BukaiNyukaiDt2), 0, 5) , '/',                                                  ");
            //sqlContent.Append("                         substring(max(gbm.BukaiNyukaiDt2), 5, 2), '/',                                                  ");
            //sqlContent.Append("                         substring(max(gbm.BukaiNyukaiDt2), 7, 2))                                                       ");
            //sqlContent.Append("            end as BukaiNyukaiDt2                                                                                        ");

            sqlContent.Append("     , case when isnull(max(gbm.BukaiTaikaiDt2), '') = '' then ''                                                        ");
            sqlContent.Append("            else concat(substring(max(gbm.BukaiTaikaiDt2), 0, 5) , '/',                                                  ");
            sqlContent.Append("                         substring(max(gbm.BukaiTaikaiDt2), 5, 2), '/',                                                  ");
            sqlContent.Append("                         substring(max(gbm.BukaiTaikaiDt2), 7, 2))                                                       ");
            sqlContent.Append("            end as BukaiTaikaiDt2                                                                                        ");


            sqlContent.Append("     , case when isnull(max(gbm.BukaiNyukaiDt3), '') <> '' and isnull(max(gbm.BukaiTaikaiDt3), '') = ''                                                         ");
            sqlContent.Append("            then concat(substring(max(gbm.BukaiNyukaiDt3), 0, 5) , '/',                                                  ");
            sqlContent.Append("                         substring(max(gbm.BukaiNyukaiDt3), 5, 2), '/',                                                  ");
            sqlContent.Append("                         substring(max(gbm.BukaiNyukaiDt3), 7, 2))                                                       ");
            sqlContent.Append("            else ''                                                                                        ");
            sqlContent.Append("            end as BukaiNyukaiDt3                                                                                        ");
            
            
            //sqlContent.Append("     , case when isnull(max(gbm.BukaiNyukaiDt3), '') = '' then ''                                                        ");
            //sqlContent.Append("            else concat(substring(max(gbm.BukaiNyukaiDt3), 0, 5) , '/',                                                  ");
            //sqlContent.Append("                         substring(max(gbm.BukaiNyukaiDt3), 5, 2), '/',                                                  ");
            //sqlContent.Append("                         substring(max(gbm.BukaiNyukaiDt3), 7, 2))                                                       ");
            //sqlContent.Append("            end as BukaiNyukaiDt3                                                                                        ");

            sqlContent.Append("     , case when isnull(max(gbm.BukaiTaikaiDt3), '') = '' then ''                                                        ");
            sqlContent.Append("            else concat(substring(max(gbm.BukaiTaikaiDt3), 0, 5) , '/',                                                  ");
            sqlContent.Append("                         substring(max(gbm.BukaiTaikaiDt3), 5, 2), '/',                                                  ");
            sqlContent.Append("                         substring(max(gbm.BukaiTaikaiDt3), 7, 2))                                                       ");
            sqlContent.Append("            end as BukaiTaikaiDt3                                                                                        ");

            sqlContent.Append("     , case when isnull(max(gbm.BukaiNyukaiDt4), '') <> '' and isnull(max(gbm.BukaiTaikaiDt4), '') = ''                                                         ");
            sqlContent.Append("            then concat(substring(max(gbm.BukaiNyukaiDt4), 0, 5) , '/',                                                  ");
            sqlContent.Append("                         substring(max(gbm.BukaiNyukaiDt4), 5, 2), '/',                                                  ");
            sqlContent.Append("                         substring(max(gbm.BukaiNyukaiDt4), 7, 2))                                                       ");
            sqlContent.Append("            else ''                                                                                        ");
            sqlContent.Append("            end as BukaiNyukaiDt4                                                                                        ");

            //sqlContent.Append("     , case when isnull(max(gbm.BukaiNyukaiDt4), '') = '' then ''                                                        ");
            //sqlContent.Append("            else concat(substring(max(gbm.BukaiNyukaiDt4), 0, 5) , '/',                                                  ");
            //sqlContent.Append("                         substring(max(gbm.BukaiNyukaiDt4), 5, 2), '/',                                                  ");
            //sqlContent.Append("                         substring(max(gbm.BukaiNyukaiDt4), 7, 2))                                                       ");
            //sqlContent.Append("            end as BukaiNyukaiDt4                                                                                        ");

            sqlContent.Append("     , case when isnull(max(gbm.BukaiTaikaiDt4), '') = '' then ''                                                        ");
            sqlContent.Append("            else concat(substring(max(gbm.BukaiTaikaiDt4), 0, 5) , '/',                                                  ");
            sqlContent.Append("                         substring(max(gbm.BukaiTaikaiDt4), 5, 2), '/',                                                  ");
            sqlContent.Append("                         substring(max(gbm.BukaiTaikaiDt4), 7, 2))                                                       ");
            sqlContent.Append("            end as BukaiTaikaiDt4                                                                                        ");

            //sqlContent.Append("     , max(gbm.BukaiNyukaiDt1)	as BukaiNyukaiDt1                                                                       ");
            //sqlContent.Append("     , max(gbm.BukaiTaikaiDt1)	as BukaiTaikaiDt1                                                                       ");
            //sqlContent.Append("     , max(gbm.BukaiNyukaiDt2)	as BukaiNyukaiDt2                                                                       ");
            //sqlContent.Append("     , max(gbm.BukaiTaikaiDt2)	as BukaiTaikaiDt2                                                                       ");
            //sqlContent.Append("     , max(gbm.BukaiNyukaiDt3)	as BukaiNyukaiDt3                                                                       ");
            //sqlContent.Append("     , max(gbm.BukaiTaikaiDt3)	as BukaiTaikaiDt3                                                                       ");
            //sqlContent.Append("     , max(gbm.BukaiNyukaiDt4)	as BukaiNyukaiDt4                                                                       ");
            //sqlContent.Append("     , max(gbm.BukaiTaikaiDt4)	as BukaiTaikaiDt4                                                                       ");

            // FROM
            sqlContent.Append("from                                                                                                                     ");
            sqlContent.Append("     GyoshaMst gm                                                                                                        ");
            sqlContent.Append("         join                                                                                                            ");
            sqlContent.Append("             (select BukaiGyoshaCd                                                                                       ");
            sqlContent.Append("                     , case BukaiKbn when 1 then BukaiNyukaiDt else '' end BukaiNyukaiDt1                                ");
            sqlContent.Append("                     , case BukaiKbn when 1 then BukaiTaikaiDt else '' end BukaiTaikaiDt1	                            ");
            sqlContent.Append("                     , case BukaiKbn when 2 then BukaiNyukaiDt else '' end BukaiNyukaiDt2                                ");
            sqlContent.Append("                     , case BukaiKbn when 2 then BukaiTaikaiDt else '' end BukaiTaikaiDt2                                ");
            sqlContent.Append("                     , case BukaiKbn when 3 then BukaiNyukaiDt else '' end BukaiNyukaiDt3                                ");
            sqlContent.Append("                     , case BukaiKbn when 3 then BukaiTaikaiDt else '' end BukaiTaikaiDt3                                ");
            sqlContent.Append("                     , case BukaiKbn when 4 then BukaiNyukaiDt else '' end BukaiNyukaiDt4                                ");
            sqlContent.Append("                     , case BukaiKbn when 4 then BukaiTaikaiDt else '' end BukaiTaikaiDt4                                ");
            sqlContent.Append("             from GyoshaBukaiMst                                                                                         ");
            sqlContent.Append("             ) gbm                                                                                                       ");
            sqlContent.Append("                 on gm.GyoshaCd = gbm.BukaiGyoshaCd                                                                      ");

            // WHERE 
            sqlContent.Append("where 1 = 1                                                                                                              ");
            
            if (!string.IsNullOrEmpty(gyosyaCdFrom))
            {
                sqlContent.Append(" and gm.GyoshaCd >= @gyosyaCdFrom ");
                commandParams.Add("@gyosyaCdFrom", SqlDbType.NVarChar).Value = gyosyaCdFrom;
            }

            if (!string.IsNullOrEmpty(gyosyaCdTo))
            {
                sqlContent.Append(" and gm.GyoshaCd <= @gyosyaCdTo ");
                commandParams.Add("@gyosyaCdTo", SqlDbType.NVarChar).Value = gyosyaCdTo;
            }

            if (!string.IsNullOrEmpty(gyosyaNm))
            {
                sqlContent.Append(" and gm.GyoshaNm like CONCAT('%', @gyosyaNm, '%') ");
                commandParams.Add("@gyosyaNm", SqlDbType.NVarChar).Value = gyosyaNm;
            }

            string joinor = string.Empty;
            // seizo
            if (seizo)
            {
                joinor = SEIZO;
            }
            // koji
            if (koji)
            {
                if (joinor != string.Empty) { joinor = joinor + " OR "; }
                joinor = joinor + KOJI;
            }

            // hosyu
            if (hosyu)
            {
                if (joinor != string.Empty) { joinor = joinor + " OR "; }
                joinor = joinor + HOSYU;
            }

            // seiso 
            if (seiso)
            {
                if (joinor != string.Empty) { joinor = joinor + " OR "; }
                joinor = joinor + SEISO;
            }

            // mikanyu
            if (mikanyu)
            {
                if (joinor != string.Empty) { joinor = joinor + " OR "; }
                joinor = joinor + MIKANYU;

            }
            //sqlContent.Append(" and ( " + joinor + " ) ");
            
            
            
            //#region 1,2,3,4,5

            //// seizo
            //if (seizo && !koji && !hosyu && !seiso && !mikanyu)
            //{
            //    sqlContent.Append(" and ( " + SEIZO + " ) ");
            //}

            //// koji
            //if (!seizo && koji && !hosyu && !seiso && !mikanyu)
            //{
            //    sqlContent.Append(" and ( " + KOJI + " ) ");
            //}

            //// hosyu
            //if (!seizo && !koji && hosyu && !seiso && !mikanyu)
            //{
            //    sqlContent.Append(" and ( " + HOSYU + " ) ");
            //}

            //// seiso 
            //if (!seizo && !koji && !hosyu && seiso && !mikanyu)
            //{
            //    sqlContent.Append(" and ( " + SEISO + " ) ");
            //}

            //// mikanyu
            //if (!seizo && !koji && !hosyu && !seiso && mikanyu)
            //{
            //    sqlContent.Append(" and ( " + MIKANYU + " ) ");
            //}
            //#endregion

            //#region 12, 13, 14, 15, 23, 24, 25, 34, 35

            //// seizo && koji
            //if (seizo && koji && !hosyu && !seiso && !mikanyu)
            //{
            //    sqlContent.Append(" and ( " + SEIZO + " or " + KOJI + " ) ");
            //}

            //// seizo && hosyu
            //if (seizo && !koji && hosyu && !seiso && !mikanyu)
            //{
            //    sqlContent.Append(" and ( " + SEIZO + " or " + HOSYU + " ) ");
            //}

            //// seizo && seiso
            //if (seizo && !koji && !hosyu && seiso && !mikanyu)
            //{
            //    sqlContent.Append(" and ( " + SEIZO + " or " + SEISO + " ) ");
            //}

            //// seizo && mikanyu
            //if (seizo && !koji && !hosyu && !seiso && mikanyu)
            //{
            //    sqlContent.Append(" and ( " + SEIZO + " or " + MIKANYU + " ) ");
            //}

            //// koji && hosyu
            //if (!seizo && koji && hosyu && !seiso && !mikanyu)
            //{
            //    sqlContent.Append(" and ( " + KOJI + " or " + HOSYU + " ) ");
            //}

            //// koji && seiso
            //if (!seizo && koji && !hosyu && seiso && !mikanyu)
            //{
            //    sqlContent.Append(" and ( " + KOJI + " or " + SEISO + " ) ");
            //}

            //// koji && mikanyu
            //if (!seizo && koji && !hosyu && !seiso && mikanyu)
            //{
            //    sqlContent.Append(" and ( " + KOJI + " or " + MIKANYU + " ) ");
            //}

            //// hosyu && seiso
            //if (!seizo && !koji && hosyu && seiso && !mikanyu)
            //{
            //    sqlContent.Append(" and ( " + HOSYU + " or " + SEISO + " ) ");
            //}

            //// hosyu && mikanyu
            //if (!seizo && !koji && hosyu && !seiso && mikanyu)
            //{
            //    sqlContent.Append(" and ( " + HOSYU + " or " + MIKANYU + " ) ");
            //}
            //#endregion

            //#region 123, 124, 125, 234, 235, 345

            //// seizo && koji && hosyu 
            //if (seizo && koji && hosyu && !seiso && !mikanyu)
            //{
            //    sqlContent.Append(" and ( " + SEIZO + " or " + KOJI + " or " + HOSYU + " ) ");
            //}

            //// seizo && koji && seiso
            //if (seizo && koji && !hosyu && seiso && !mikanyu)
            //{
            //    sqlContent.Append(" and ( " + SEIZO + " or " + KOJI + " or " + SEISO + " ) ");
            //}

            //// seizo && koji && mikanyu
            //if (seizo && koji && !hosyu && !seiso && mikanyu)
            //{
            //    sqlContent.Append(" and ( " + SEIZO + " or " + KOJI + " or " + MIKANYU + " ) ");
            //}

            //// koji && hosyu && seiso
            //if (!seizo && koji && hosyu && seiso && !mikanyu)
            //{
            //    sqlContent.Append(" and ( " + KOJI + " or " + HOSYU + " or " + SEISO + " ) ");
            //}

            //// koji && hosyu && mikanyu
            //if (!seizo && koji && hosyu && !seiso && mikanyu)
            //{
            //    sqlContent.Append(" and ( " + KOJI + " or " + HOSYU + " or " + MIKANYU + " ) ");
            //}

            //// hosyu && seiso && mikanyu
            //if (!seizo && !koji && hosyu && seiso && mikanyu)
            //{
            //    sqlContent.Append(" and ( " + HOSYU + " or " + SEISO + " or " + MIKANYU + " ) ");
            //}
            //#endregion

            //#region 1234, 1235, 2345

            //// seizo && koji && hosyu && seiso
            //if (seizo && koji && hosyu && seiso && !mikanyu)
            //{
            //    sqlContent.Append(" and ( " + SEIZO + " or " + KOJI + " or " + HOSYU + " or " + SEISO + " ) ");
            //}

            //// seizo && koji && hosyu && mikanyu
            //if (seizo && koji && hosyu && !seiso && !mikanyu)
            //{
            //    sqlContent.Append(" and ( " + SEIZO + " or " + KOJI + " or " + HOSYU + " or " + MIKANYU + " ) ");
            //}

            //// koji && hosyu && seiso && mikanyu
            //if (!seizo && koji && hosyu && seiso && mikanyu)
            //{
            //    sqlContent.Append(" and ( " + KOJI + " or " + HOSYU + " or " + SEISO + " or " + MIKANYU + " ) ");
            //}
            //#endregion

            //#region 12345

            //// seizo && koji && hosyu && seiso && mikanyu
            //if (seizo && koji && hosyu && seiso && mikanyu)
            //{
            //    sqlContent.Append(" and ( " + SEIZO + " or " + KOJI + " or " + HOSYU + " or " + SEISO + " or " + MIKANYU + " ) ");
            //}
            //#endregion

            // 2015/01/30 DatNT v1.04 DEL Start
            //if (nyukaiDtUse)
            //{
            //    sqlContent.Append(" and exists (select *                                                                                                ");
            //    sqlContent.Append("             from GyoshaBukaiMst ext                                                                                 ");
            //    sqlContent.Append("             where ext.BukaiGyoshaCd = gm.GyoshaCd                                                                   ");
            //    sqlContent.Append("             and ext.BukaiTaikaiDt = ''                                                                   ");
            //    sqlContent.Append("                     and ext.BukaiNyukaiDt >= @nyukaiDtFrom                                                          ");
            //    sqlContent.Append("                     and ext.BukaiNyukaiDt <= @nyukaiDtTo                                                            ");
            //    sqlContent.Append("             )                                                                                                       ");

            //    commandParams.Add("@nyukaiDtFrom", SqlDbType.NVarChar).Value = nyukaiDtFrom;
            //    commandParams.Add("@nyukaiDtTo", SqlDbType.NVarChar).Value = nyukaiDtTo;
            //}
            // 2015/01/30 DatNT v1.04 DEL End

            // GROUP BY
            sqlContent.Append(" group by gm.GyoshaCd                                                                                                    ");
            sqlContent.Append(" having ( " + joinor + " ) ");

            // 2015/01/30 DatNT v1.04 ADD Start
            sqlContent.Append("  ) AS Tbl                                                                                                               ");
            sqlContent.Append("  INNER JOIN GyoshaMst                                                                                                   ");
            sqlContent.Append("         ON GyoshaMst.GyoshaCd = Tbl.GyoshaCd                                                                                                                  ");
            // 2015/01/30 DatNT v1.04 ADD End

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion
}