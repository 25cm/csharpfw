using System.Reflection;
using FukjBizSystem.Application.DataAccess.Sync.KensaIraiTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.BusinessLogic.Sync
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IReflectKensaIraiStatusKbnToSqlsvBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/24  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IReflectKensaIraiStatusKbnToSqlsvBLInput
    {
        /// <summary>
        /// KensaIraiTbl
        /// </summary>
        KensaIraiTblDataSet.KensaIraiTblDataTable KensaIraiTbl { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ReflectKensaIraiStatusKbnToSqlsvBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/24  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ReflectKensaIraiStatusKbnToSqlsvBLInput : IReflectKensaIraiStatusKbnToSqlsvBLInput
    {
        /// <summary>
        /// KensaIraiTbl
        /// </summary>
        public KensaIraiTblDataSet.KensaIraiTblDataTable KensaIraiTbl { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IReflectKensaIraiStatusKbnToSqlsvBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/24  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IReflectKensaIraiStatusKbnToSqlsvBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ReflectKensaIraiStatusKbnToSqlsvBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/24  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ReflectKensaIraiStatusKbnToSqlsvBLOutput : IReflectKensaIraiStatusKbnToSqlsvBLOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ReflectKensaIraiStatusKbnToSqlsvBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/24  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ReflectKensaIraiStatusKbnToSqlsvBusinessLogic : BaseBusinessLogic<IReflectKensaIraiStatusKbnToSqlsvBLInput, IReflectKensaIraiStatusKbnToSqlsvBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ReflectKensaIraiStatusKbnToSqlsvBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/24  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public ReflectKensaIraiStatusKbnToSqlsvBusinessLogic()
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
        /// 2014/12/24  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IReflectKensaIraiStatusKbnToSqlsvBLOutput Execute(IReflectKensaIraiStatusKbnToSqlsvBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IReflectKensaIraiStatusKbnToSqlsvBLOutput output = new ReflectKensaIraiStatusKbnToSqlsvBLOutput();

            try
            {
                KensaIraiTblDataSet.KensaIraiTblDataTable kensaIrai = new KensaIraiTblDataSet.KensaIraiTblDataTable();

                // ステータスが持出し中(30)である場合に持出し可能(20)に戻す
                foreach (KensaIraiTblDataSet.KensaIraiTblRow row in input.KensaIraiTbl)
                {
                    ISelectKensaIraiTblByKeyDAInput iraiInput = new SelectKensaIraiTblByKeyDAInput();
                    iraiInput.KensaIraiHoteiKbn = row.KensaIraiHoteiKbn;
                    iraiInput.KensaIraiHokenjoCd = row.KensaIraiHokenjoCd;
                    iraiInput.KensaIraiNendo = row.KensaIraiNendo;
                    iraiInput.KensaIraiRenban = row.KensaIraiRenban;
                    ISelectKensaIraiTblByKeyDAOutput iraiOutput = new SelectKensaIraiTblByKeyDataAccess().Execute(iraiInput);

                    if (iraiOutput.KensaIraiTblDataTable.Count > 0 && !iraiOutput.KensaIraiTblDataTable[0].IsKensaIraiStatusKbnNull() && iraiOutput.KensaIraiTblDataTable[0].KensaIraiStatusKbn == "30")
                    {
                        // ステータスを戻す
                        row.KensaIraiStatusKbn = "20";

                        // 登録用データに追加
                        kensaIrai.ImportRow(row);

                        row.AcceptChanges();
                        row.SetModified();
                    }
                }

                // 更新データがある場合のみ
                if (kensaIrai.Count > 0)
                {
                    IUpdateKensaIraiTblDAInput updInput = new UpdateKensaIraiTblDAInput();

                    // 検査依頼
                    updInput.KensaIraiTbl = kensaIrai;

                    // Update
                    new UpdateKensaIraiTblDataAccess().Execute(updInput);
                }
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
