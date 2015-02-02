using System;
using System.Reflection;
using FukjBizSystem.Application.Boundary.GaikanKensa;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaFukaJohoAdd;
using FukjBizSystem.Application.BusinessLogic.UketsukeKanri.Jo7KensaChienInput;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.GaikanKensa.KensaFukaJohoAdd
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ITorokuBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ITorokuBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// 検査依頼法定区分
        /// </summary>
        string KensaIraiHoteiKbn { get; set; }

        /// <summary>
        /// 検査依頼保健所コード
        /// </summary>
        string KensaIraiHokenjoCd { get; set; }

        /// <summary>
        /// 検査依頼年度
        /// </summary>
        string KensaIraiNendo { get; set; }

        /// <summary>
        /// 検査依頼連番
        /// </summary>
        string KensaIraiRenban { get; set; }

        /// <summary>
        /// 関連ファイル種別
        /// </summary>
        string KensaIraiFileShubetsuCd { get; set; }

        /// <summary>
        /// システム日付
        /// </summary>
        DateTime SystemDt { get; set; }

        /// <summary>
        /// Screen mode
        /// </summary>
        KensaFukaJohoAddForm.DispMode DispMode { get; set; }

        /// <summary>
        /// 検査依頼関連ファイルテーブル
        /// </summary>
        KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable KensaIraiKanrenFileTblDataTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： TorokuBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class TorokuBtnClickALInput : ITorokuBtnClickALInput
    {
        /// <summary>
        /// 検査依頼法定区分
        /// </summary>
        public string KensaIraiHoteiKbn { get; set; }

        /// <summary>
        /// 検査依頼保健所コード
        /// </summary>
        public string KensaIraiHokenjoCd { get; set; }

        /// <summary>
        /// 検査依頼年度
        /// </summary>
        public string KensaIraiNendo { get; set; }

        /// <summary>
        /// 検査依頼連番
        /// </summary>
        public string KensaIraiRenban { get; set; }

        /// <summary>
        /// 関連ファイル種別
        /// </summary>
        public string KensaIraiFileShubetsuCd { get; set; }

        /// <summary>
        /// システム日付
        /// </summary>
        public DateTime SystemDt { get; set; }

        /// <summary>
        /// Screen mode
        /// </summary>
        public KensaFukaJohoAddForm.DispMode DispMode { get; set; }

        /// <summary>
        /// 検査依頼関連ファイルテーブル
        /// </summary>
        public KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable KensaIraiKanrenFileTblDataTable { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return GetDataString();
            }
        }

        #region GetDataString
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetDataString
        /// <summary>
        /// 
        /// </summary>
        /// <return>
        /// 
        /// </return>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GetDataString()
        {
            string dataStr = string.Empty;

            if (DispMode == KensaFukaJohoAddForm.DispMode.Delete)
            {
                dataStr = string.Format("検査依頼法定区分[{0}], 検査依頼保健所コード[{1}], 検査依頼年度[{2}], 検査依頼連番[{3}], 関連ファイル種別[{4}]",
                    KensaIraiKanrenFileTblDataTable[0].KensaIraiHoteiKbn,
                    KensaIraiKanrenFileTblDataTable[0].KensaIraiHokenjoCd,
                    KensaIraiKanrenFileTblDataTable[0].KensaIraiNendo,
                    KensaIraiKanrenFileTblDataTable[0].KensaIraiRenban,
                    KensaIraiKanrenFileTblDataTable[0].KensaIraiFileShubetsuCd);
            }
            else
            {
                dataStr = string.Format("検査依頼法定区分[{0}], 検査依頼保健所コード[{1}], 検査依頼年度[{2}], 検査依頼連番[{3}], 関連ファイル種別[{4}]",
                    KensaIraiHoteiKbn,
                    KensaIraiHokenjoCd,
                    KensaIraiNendo,
                    KensaIraiRenban,
                    KensaIraiFileShubetsuCd);
            }

            return dataStr;
        }
        #endregion
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ITorokuBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ITorokuBtnClickALOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： TorokuBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class TorokuBtnClickALOutput : ITorokuBtnClickALOutput
    {

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： TorokuBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class TorokuBtnClickApplicationLogic : BaseApplicationLogic<ITorokuBtnClickALInput, ITorokuBtnClickALOutput>
    {
        #region 定義

        public enum OperationErr
        {
            RakkanLock,     // 楽観ロックエラー
        }

        #endregion

        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaFukaJohoAdd：TorokuBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： TorokuBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public TorokuBtnClickApplicationLogic()
        {

        }
        #endregion

        #region メソッド(protected)

        #region GetFunctionName
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetFunctionName
        /// <summary>
        /// 機能名取得
        /// </summary>
        /// <returns>機能名</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override string GetFunctionName()
        {
            return FunctionName;
        }
        #endregion

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
        /// 2014/11/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ITorokuBtnClickALOutput Execute(ITorokuBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ITorokuBtnClickALOutput output = new TorokuBtnClickALOutput();

            try
            {
                // トランザクション開始
                StartTransaction();

                // Insert mode
                if (input.DispMode == KensaFukaJohoAddForm.DispMode.Insert)
                {
                    IUpdateKensaIraiKanrenFileTblBLInput uInput = new UpdateKensaIraiKanrenFileTblBLInput();
                    uInput.KensaIraiKanrenFileTblDT = input.KensaIraiKanrenFileTblDataTable;
                    new UpdateKensaIraiKanrenFileTblBusinessLogic().Execute(uInput);
                }
                else if (input.DispMode == KensaFukaJohoAddForm.DispMode.Update) // Update mode
                {
                    // Get KensaIraiKanrenFileTbl by key
                    IGetKensaIraiKanrenFileTblByKeyBLInput keyInput = new GetKensaIraiKanrenFileTblByKeyBLInput();
                    keyInput.KensaIraiHoteiKbn = input.KensaIraiKanrenFileTblDataTable[0].KensaIraiHoteiKbn;
                    keyInput.KensaIraiHokenjoCd = input.KensaIraiKanrenFileTblDataTable[0].KensaIraiHokenjoCd;
                    keyInput.KensaIraiNendo = input.KensaIraiKanrenFileTblDataTable[0].KensaIraiNendo;
                    keyInput.KensaIraiRenban = input.KensaIraiKanrenFileTblDataTable[0].KensaIraiRenban;
                    keyInput.KensaIraiFileShubetsuCd = input.KensaIraiKanrenFileTblDataTable[0].KensaIraiFileShubetsuCd;
                    IGetKensaIraiKanrenFileTblByKeyBLOutput keyOutput = new GetKensaIraiKanrenFileTblByKeyBusinessLogic().Execute(keyInput);

                    if (keyOutput.KensaIraiKanrenFileTblDT.Count > 0)
                    {
                        // Optimistic lock
                        if (keyOutput.KensaIraiKanrenFileTblDT[0].UpdateDt != input.KensaIraiKanrenFileTblDataTable[0].UpdateDt)
                        {
                            throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                        }

                        // 更新日
                        input.KensaIraiKanrenFileTblDataTable[0].UpdateDt = input.SystemDt;
                    }

                    IUpdateKensaIraiKanrenFileTblBLInput uInput = new UpdateKensaIraiKanrenFileTblBLInput();
                    uInput.KensaIraiKanrenFileTblDT = input.KensaIraiKanrenFileTblDataTable;
                    new UpdateKensaIraiKanrenFileTblBusinessLogic().Execute(uInput);
                }
                else // Delete mode
                {
                    IDeleteKensaIraiKanrenFileTblByKeyBLInput dInput = new DeleteKensaIraiKanrenFileTblByKeyBLInput();
                    dInput.KensaIraiHoteiKbn = input.KensaIraiHoteiKbn;
                    dInput.KensaIraiHokenjoCd = input.KensaIraiHokenjoCd;
                    dInput.KensaIraiNendo = input.KensaIraiNendo;
                    dInput.KensaIraiRenban = input.KensaIraiRenban;
                    dInput.KensaIraiFileShubetsuCd = input.KensaIraiFileShubetsuCd;
                    new DeleteKensaIraiKanrenFileTblByKeyBusinessLogic().Execute(dInput);
                }
                // コミット
                CompleteTransaction();
            }
            catch
            {
                throw;
            }
            finally
            {
                // トランザクション終了
                EndTransaction();

                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }

            return output;
        }
        #endregion

        #endregion
    }
    #endregion
}
