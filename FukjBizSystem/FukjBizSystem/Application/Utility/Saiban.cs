using System;
using FukjBizSystem.Application.BusinessLogic.Common;
using Zynas.Framework.Core.Base.Common;

namespace FukjBizSystem.Application.Utility
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Saiban
    /// <summary>
    /// 採番を行います
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/03　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class Saiban
    {
        #region 採番テーブル採番

        #region GetSaibanRenban
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： GetSaibanRenban
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SaibanNendo">採番年度(yyyy)</param>
        /// <param name="SaibanKbn">採番区分</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/18  宗　　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static string GetSaibanRenban(string SaibanNendo, string SaibanKbn)
        {
            string SaibanRenban = "";

            try
            {
                TransactionManager.CreateTran();

                // 採番
                IGetSaibanTblByKeyBLInput blInput = new GetSaibanTblByKeyBLInput();
                blInput.SaibanNendo = SaibanNendo;
                blInput.SaibanKbn = SaibanKbn;
                blInput.SaibanCnt = 1;
                IGetSaibanTblByKeyBLOutput blOutput = new GetSaibanTblByKeyBusinessLogic().Execute(blInput);
                
                // 0埋め
                if (blOutput.SaibanTblDT.Rows.Count > 0)
                {
                    SaibanRenban = blOutput.SaibanTblDT[0].SaibanRenban.Trim().PadLeft(blOutput.SaibanTblDT[0].SaibanKetasu, '0');
                }

                TransactionManager.CompleteTran();
            }
            catch
            {
                throw;
            }
            finally
            {
                TransactionManager.ReleaseTran();
            }

            return SaibanRenban;
        }
        #endregion

        #region GetSaibanRenban
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="SaibanKbn"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02  habu　　    新規作成
        /// </history>
        public static string GetSaibanRenban(DateTime dt, string SaibanKbn)
        {
            int nendo = DateUtility.GetNendo(dt);

            return GetSaibanRenban(nendo.ToString(), SaibanKbn);
        }
        #endregion

        #region GetSaibanRenban
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： GetSaibanRenban
        /// <summary>
        /// 
        /// </summary>
        /// <input>採番年度</input>
        /// <input>採番区分</input>
        /// <returns>採番連番</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/07  宗　　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static string GetSaibanRenban(string SaibanNendo, string SaibanKbn, int SaibanCnt)
        {
            string SaibanRenban = "";

            try
            {
                TransactionManager.CreateTran();

                // 採番
                IGetSaibanTblByKeyBLInput blInput = new GetSaibanTblByKeyBLInput();
                blInput.SaibanNendo = SaibanNendo;
                blInput.SaibanKbn = SaibanKbn;
                blInput.SaibanCnt = SaibanCnt;
                IGetSaibanTblByKeyBLOutput blOutput = new GetSaibanTblByKeyBusinessLogic().Execute(blInput);

                // 0埋め
                if (blOutput.SaibanTblDT.Rows.Count > 0)
                {
                    SaibanRenban = blOutput.SaibanTblDT[0].SaibanRenban.Trim().PadLeft(blOutput.SaibanTblDT[0].SaibanKetasu, '0');
                }

                TransactionManager.CompleteTran();
            }
            catch
            {
                throw;
            }
            finally
            {
                TransactionManager.ReleaseTran();
            }

            return SaibanRenban;
        }
        #endregion

        #region GetSaibanRenban
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="SaibanKbn"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/07  habu　　    新規作成
        /// </history>
        public static string GetSaibanRenban(DateTime dt, string SaibanKbn, int SaibanCnt)
        {
            int nendo = DateUtility.GetNendo(dt);

            return GetSaibanRenban(nendo.ToString(), SaibanKbn, SaibanCnt);
        }
        #endregion

        #region GetSaibanKbn
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="SaibanKbn"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/07  habu　　    新規作成
        /// </history>
        public static string GetSaibanKbn(string saibanKbnPrefix, string shishoCd)
        {
            string saibanKbn = string.Empty;

            saibanKbn = saibanKbnPrefix + shishoCd;

            return saibanKbn;
        }
        #endregion

        #region GetShishoSaibanKbn
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="SaibanKbn"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/07  habu　　    新規作成
        /// 2014/12/24  habu　　    支所コードを指定できるオーバーライドを追加
        /// </history>
        public static string GetShishoSaibanKbn(string saibanKbnPrefix)
        {
            // ログインユーザの所属支所をデフォルトとする
            return GetShishoSaibanKbn(saibanKbnPrefix, ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="saibanKbnPrefix"></param>
        /// <param name="shishoCd"></param>
        /// <returns></returns>
        public static string GetShishoSaibanKbn(string saibanKbnPrefix , string shishoCd)
        {
            // ログインユーザの所属支所をデフォルトとする
            return GetSaibanKbn(saibanKbnPrefix, shishoCd);
        }
        #endregion

        #region GetSaibanNendo
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： GetSaibanNendo
        /// <summary>
        /// 
        /// </summary>
        /// <input>採番年月日</input>
        /// <input>採番区分</input>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/07  宗　　　    新規作成
        /// 2014/10/14  小松　　    DateUtilityクラスを使用して、年度取得
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static string GetSaibanNendo(string SaibanDt, string SaibanKbn)
        {
            DateTime dt;
            string Nendo = "";
            string Saiban = "";

            // 年度取得
            if (DateTime.TryParseExact(SaibanDt, "yyyyMMdd",
                System.Globalization.DateTimeFormatInfo.InvariantInfo,
                System.Globalization.DateTimeStyles.None, out dt))
            {
                // DateUtilityクラスを使用して、年度取得
                Nendo = DateUtility.GetNendo(dt).ToString();
            }

            // 採番
            if (Nendo != "")
            {
                Saiban = GetSaibanRenban(Nendo, SaibanKbn);
                if (Saiban != "")
                {
                    Saiban = Nendo + Saiban;
                }
            }

            return Saiban;
        }
        #endregion

        #endregion

        #region マスタキー採番

        #region GetKeyRenban
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： GetKeyRenban
        /// <summary>
        /// 
        /// </summary>
        /// <input>マスタ物理名称</input>
        /// <input>キー項目値１</input>
        /// <input>キー項目値２</input>
        /// <input>キー項目値３</input>
        /// <returns>キー連番</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24  宗　　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static string GetKeyRenban(string MstNm, string MstKey1, string MstKey2, string MstKey3)
        {
            string KeyRenban = "";

            try
            {
                TransactionManager.CreateTran();

                // 採番
                IGetMstKeySaibanTblByKeyBLInput blInput = new GetMstKeySaibanTblByKeyBLInput();
                blInput.MstButsuriNm = MstNm;
                blInput.MstKeyValue1 = MstKey1;
                blInput.MstKeyValue2 = MstKey2;
                blInput.MstKeyValue3 = MstKey3;
                IGetMstKeySaibanTblByKeyBLOutput blOutput = new GetMstKeySaibanTblByKeyBusinessLogic().Execute(blInput);

                // 採番結果取得
                if (blOutput.MstKeySaibanTblDT.Rows.Count > 0)
                {
                    KeyRenban = blOutput.MstKeySaibanTblDT[0].MstKeyRenban.ToString();
                }

                TransactionManager.CompleteTran();
            }
            catch
            {
                throw;
            }
            finally
            {
                TransactionManager.ReleaseTran();
            }

            return KeyRenban;
        }
        #endregion

        #endregion
    }
    #endregion
}
