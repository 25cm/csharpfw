using System.Net;
using System.Reflection;
using FukjBizSystem.Application.DataAccess.SaibanTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Common
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSaibanTblByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/18  宗　　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSaibanTblByKeyBLInput : ISelectSaibanTblByKeyWithTabLockDAInput
    {
        /// <summary>
        /// 採番数
        /// </summary>
        int SaibanCnt { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSaibanTblByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/18  宗　　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSaibanTblByKeyBLInput : IGetSaibanTblByKeyBLInput
    {
        /// <summary>
        /// 採番年度
        /// </summary>
        public string SaibanNendo { get; set; }
        /// <summary>
        /// 採番区分
        /// </summary>
        public string SaibanKbn { get; set; }
        /// <summary>
        /// 採番数
        /// </summary>
        public int SaibanCnt { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSaibanTblByKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/18  宗　　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSaibanTblByKeyBLOutput : ISelectSaibanTblByKeyWithTabLockDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSaibanTblByKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/18  宗　　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSaibanTblByKeyBLOutput : IGetSaibanTblByKeyBLOutput
    {
        /// <summary>
        /// SaibanTblDataTable
        /// </summary>
        public SaibanTblDataSet.SaibanTblDataTable SaibanTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSaibanTblByKeyBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/18  宗　　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSaibanTblByKeyBusinessLogic : BaseBusinessLogic<IGetSaibanTblByKeyBLInput, IGetSaibanTblByKeyBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetSaibanTblByKeyBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/18  宗　　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetSaibanTblByKeyBusinessLogic()
        {

        }
        #endregion

        #region メソッド(public)

        #region Execute
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： Execute
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/18  宗　　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetSaibanTblByKeyBLOutput Execute(IGetSaibanTblByKeyBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            GetSaibanTblByKeyBLOutput output = new GetSaibanTblByKeyBLOutput();

            try
            {
                System.DateTime TimeStamp = Boundary.Common.Common.GetCurrentTimestamp();
                string UserNm = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                string HostNm = Dns.GetHostName();

                string saiban = "";

                // 検索
                ISelectSaibanTblByKeyWithTabLockDAInput SelectInput = new SelectSaibanTblByKeyWithTabLockDAInput();
                SelectInput.SaibanNendo = input.SaibanNendo;
                SelectInput.SaibanKbn = input.SaibanKbn;
                ISelectSaibanTblByKeyWithTabLockDAOutput daOutput = new SelectSaibanTblByKeyWithTabLockDataAccess().Execute(input);
                if (daOutput.SaibanTblDT.Rows.Count > 0)
                {
                    // 採番1件目を退避
                    saiban = (int.Parse(daOutput.SaibanTblDT[0].SaibanRenban) + 1).ToString();

                    // 編集
                    daOutput.SaibanTblDT[0].SaibanRenban = (int.Parse(daOutput.SaibanTblDT[0].SaibanRenban.Trim()) + input.SaibanCnt).ToString(); ;
                    daOutput.SaibanTblDT[0].UpdateDt = Boundary.Common.Common.GetCurrentTimestamp();
                    daOutput.SaibanTblDT[0].UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                    daOutput.SaibanTblDT[0].UpdateTarm = Dns.GetHostName();

                    // 更新
                    UpdateSaibanTblDAInput UpdateInput = new UpdateSaibanTblDAInput();
                    UpdateInput.SaibanTblDataTable = daOutput.SaibanTblDT;
                    new UpdateSaibanTblDataAccess().Execute(UpdateInput);
                }
                else
                {
                    // 対象レコードが存在しない場合に自動追加

                    // 該当区分の桁数取得
                    ISelectSaibanTblBySaibanKbnDAInput searchInput = new SelectSaibanTblBySaibanKbnDAInput();
                    searchInput.SaibanKbn = input.SaibanKbn;
                    ISelectSaibanTblBySaibanKbnDAOutput SaibanKetasuSearchOutput = new SelectSaibanTblBySaibanKbnDataAccess().Execute(searchInput);

                    if (SaibanKetasuSearchOutput.SaibanTblDT.Rows.Count > 0)
                    {
                        // 採番1件目を退避
                        saiban = "1";

                        // 編集
                        SaibanTblDataSet.SaibanTblRow daOutputRow = daOutput.SaibanTblDT.NewSaibanTblRow();
                        daOutputRow.SaibanNendo = input.SaibanNendo;
                        daOutputRow.SaibanKbn = input.SaibanKbn;
                        daOutputRow.SaibanNm = SaibanKetasuSearchOutput.SaibanTblDT[0].SaibanNm;
                        daOutputRow.SaibanKetasu = SaibanKetasuSearchOutput.SaibanTblDT[0].SaibanKetasu;
                        daOutputRow.SaibanRenban = input.SaibanCnt.ToString();
                        daOutputRow.InsertDt = TimeStamp;
                        daOutputRow.InsertUser = UserNm;
                        daOutputRow.InsertTarm = HostNm;
                        daOutputRow.UpdateDt = TimeStamp;
                        daOutputRow.UpdateUser = UserNm;
                        daOutputRow.UpdateTarm = HostNm;
                        // 行の挿入
                        daOutput.SaibanTblDT.AddSaibanTblRow(daOutputRow);
                        // 行の状態を設定
                        daOutputRow.AcceptChanges();
                        // 行の状態を設定（新規）
                        daOutputRow.SetAdded();

                        // 新規登録
                        InsertSaibanTblDAInput InsertInput = new InsertSaibanTblDAInput();
                        InsertInput.SaibanTblDT = daOutput.SaibanTblDT;
                        new InsertSaibanTblDataAccess().Execute(InsertInput);
                    }
                }
                if (daOutput.SaibanTblDT.Count > 0)
                {
                    //採番1件目を設定
                    daOutput.SaibanTblDT[0].SaibanRenban = saiban;
                }

                // 戻り値
                output.SaibanTblDT = daOutput.SaibanTblDT;
            }
            catch
            {
                throw;
            }
            finally
            {
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }

            return output;
        }
        #endregion

        #region GetSaibanRenban
        /////////////////////////////////////////////////////////////////
        ////メソッド名 ： GetSaibanRenban
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <input>採番年度</input>
        ///// <input>採番区分</input>
        ///// <returns>採番連番</returns>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/07/18  宗　　　    新規作成
        ///// </history>
        /////////////////////////////////////////////////////////////////
        //public static string GetSaibanRenban(string SaibanNendo, string SaibanKbn)
        //{
        //    string SaibanRenban = "";

        //    try
        //    {
        //        // 採番
        //        IGetSaibanTblByKeyBLInput blInput = new GetSaibanTblByKeyBLInput();
        //        blInput.SaibanNendo = SaibanNendo;
        //        blInput.SaibanKbn = SaibanKbn;
        //        IGetSaibanTblByKeyBLOutput blOutput = new GetSaibanTblByKeyBusinessLogic().Execute(blInput);

        //        // 0埋め
        //        if (blOutput.SaibanTblDT.Rows.Count > 0)
        //        {
        //            SaibanRenban = blOutput.SaibanTblDT[0].SaibanRenban.Trim().PadLeft(blOutput.SaibanTblDT[0].SaibanKetasu, '0');
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //    }

        //    return SaibanRenban;
        //}
        #endregion

        #endregion

    }
    #endregion
}
