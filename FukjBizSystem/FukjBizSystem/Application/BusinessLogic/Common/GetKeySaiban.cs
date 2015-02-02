using System.Net;
using System.Reflection;
using FukjBizSystem.Application.DataAccess.MstKeySaibanTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Common
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetMstKeySaibanTblByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/24  宗　　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetMstKeySaibanTblByKeyBLInput : ISelectMstKeySaibanTblByKeyWithTabLockDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetMstKeySaibanTblByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/24  宗　　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetMstKeySaibanTblByKeyBLInput : IGetMstKeySaibanTblByKeyBLInput
    {
        /// <summary>
        /// マスタ物理名称
        /// </summary>
        public string MstButsuriNm { get; set; }
        /// <summary>
        /// キー項目値１
        /// </summary>
        public string MstKeyValue1 { get; set; }
        /// <summary>
        /// キー項目値２
        /// </summary>
        public string MstKeyValue2 { get; set; }
        /// <summary>
        /// キー項目値３
        /// </summary>
        public string MstKeyValue3 { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetMstKeySaibanTblByKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/24  宗　　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetMstKeySaibanTblByKeyBLOutput : ISelectMstKeySaibanTblByKeyWithTabLockDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetMstKeySaibanTblByKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/24  宗　　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetMstKeySaibanTblByKeyBLOutput : IGetMstKeySaibanTblByKeyBLOutput
    {
        /// <summary>
        /// MstKeySaibanTblDataTable
        /// </summary>
        public MstKeySaibanTblDataSet.MstKeySaibanTblDataTable MstKeySaibanTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetMstKeySaibanTblByKeyBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/24  宗　　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetMstKeySaibanTblByKeyBusinessLogic : BaseBusinessLogic<IGetMstKeySaibanTblByKeyBLInput, IGetMstKeySaibanTblByKeyBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetMstKeySaibanTblByKeyBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24  宗　　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetMstKeySaibanTblByKeyBusinessLogic()
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
        /// 2014/07/24  宗　　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetMstKeySaibanTblByKeyBLOutput Execute(IGetMstKeySaibanTblByKeyBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            GetMstKeySaibanTblByKeyBLOutput output = new GetMstKeySaibanTblByKeyBLOutput();

            try
            {
                System.DateTime TimeStamp = Boundary.Common.Common.GetCurrentTimestamp();
                string UserNm = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                string HostNm = Dns.GetHostName();

                // 検索
                ISelectMstKeySaibanTblByKeyWithTabLockDAOutput daOutput = new SelectMstKeySaibanTblByKeyWithTabLockDataAccess().Execute(input);
                if (daOutput.MstKeySaibanTblDT.Rows.Count > 0)
                {
                    // 編集
                    daOutput.MstKeySaibanTblDT[0].MstKeyRenban = daOutput.MstKeySaibanTblDT[0].MstKeyRenban + 1;
                    daOutput.MstKeySaibanTblDT[0].UpdateDt = TimeStamp;
                    daOutput.MstKeySaibanTblDT[0].UpdateUser = UserNm;
                    daOutput.MstKeySaibanTblDT[0].UpdateTarm = HostNm;

                    // 更新
                    UpdateMstKeySaibanTblDAInput UpdateInput = new UpdateMstKeySaibanTblDAInput();
                    UpdateInput.MstKeySaibanTblDataTable = daOutput.MstKeySaibanTblDT;
                    new UpdateMstKeySaibanTblDataAccess().Execute(UpdateInput);
                }
                else
                {

                    // 編集
                    MstKeySaibanTblDataSet.MstKeySaibanTblRow daOutputRow = daOutput.MstKeySaibanTblDT.NewMstKeySaibanTblRow();
                    daOutputRow.MstButsuriNm = input.MstButsuriNm;
                    daOutputRow.MstKeyValue1 = input.MstKeyValue1;
                    daOutputRow.MstKeyValue2 = input.MstKeyValue2;
                    daOutputRow.MstKeyValue3 = input.MstKeyValue3;
                    daOutputRow.MstKeyRenban = 1;
                    daOutputRow.InsertDt = TimeStamp;
                    daOutputRow.InsertUser = UserNm;
                    daOutputRow.InsertTarm = HostNm;
                    daOutputRow.UpdateDt = TimeStamp;
                    daOutputRow.UpdateUser = UserNm;
                    daOutputRow.UpdateTarm = HostNm;
                    // 行の挿入
                    daOutput.MstKeySaibanTblDT.AddMstKeySaibanTblRow(daOutputRow);
                    // 行の状態を設定
                    daOutputRow.AcceptChanges();
                    // 行の状態を設定（新規）
                    daOutputRow.SetAdded();

                    // 新規登録
                    InsertMstKeySaibanTblDAInput InsertInput = new InsertMstKeySaibanTblDAInput();
                    InsertInput.MstKeySaibanTblDataTable = daOutput.MstKeySaibanTblDT;
                    new InsertMstKeySaibanTblDataAccess().Execute(InsertInput);
                }
                // 戻り値
                output.MstKeySaibanTblDT = daOutput.MstKeySaibanTblDT;
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

        #endregion

    }
    #endregion
}
