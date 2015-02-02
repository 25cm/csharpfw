using System.Net;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaTorisageList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.UketsukeKanri.SofuDtInput
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
    /// 2014/09/05  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ITorokuBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// Jo7KensaIraiListDataTable
        /// </summary>
        KensaIraiTblDataSet.Jo7KensaIraiListDataTable Jo7KensaIraiListDataTable { get; set; }

        /// <summary>
        /// KensaIraiSofuDt
        /// </summary>
        string KensaIraiSofuDt { get; set; }
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
    /// 2014/09/05  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class TorokuBtnClickALInput : ITorokuBtnClickALInput
    {
        /// <summary>
        /// Jo7KensaIraiListDataTable
        /// </summary>
        public KensaIraiTblDataSet.Jo7KensaIraiListDataTable Jo7KensaIraiListDataTable { get; set; }

        /// <summary>
        /// KensaIraiSofuDt
        /// </summary>
        public string KensaIraiSofuDt { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("検査依頼法定区分[{0}], 検査依頼保健所コード[{1}], 検査依頼年度[{2}], 検査依頼連番[{3}]",
                    new string[] { Jo7KensaIraiListDataTable[0].KensaIraiHoteiKbn, Jo7KensaIraiListDataTable[0].KensaIraiHokenjoCd, Jo7KensaIraiListDataTable[0].KensaIraiNendo, Jo7KensaIraiListDataTable[0].KensaIraiRenban });
            }
        }
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
    /// 2014/09/05  HuyTX　　    新規作成
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
    /// 2014/09/05  HuyTX　　    新規作成
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
    /// 2014/09/05  HuyTX　　    新規作成
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
        private const string FunctionName = "SofuDtInput：TorokuBtnClick";

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
        /// 2014/09/05  HuyTX　　    新規作成
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
        /// 2014/09/05  HuyTX　　    新規作成
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
        /// 2014/09/05  HuyTX　　    新規作成
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

                KensaIraiTblDataSet.KensaIraiTblDataTable kensaIraiDTUpdate = new KensaIraiTblDataSet.KensaIraiTblDataTable();
                IGetKensaIraiTblByKeyBLInput getKensaIraiBLInput = new GetKensaIraiTblByKeyBLInput();

                foreach (KensaIraiTblDataSet.Jo7KensaIraiListRow row in input.Jo7KensaIraiListDataTable)
                {
                    getKensaIraiBLInput.KensaIraiHoteiKbn = row.KensaIraiHoteiKbn;
                    getKensaIraiBLInput.KensaIraiHokenjoCd = row.KensaIraiHokenjoCd;
                    getKensaIraiBLInput.KensaIraiNendo = row.KensaIraiNendo;
                    getKensaIraiBLInput.KensaIraiRenban = row.KensaIraiRenban;

                    IGetKensaIraiTblByKeyBLOutput getKensaIraiBLOutput = new GetKensaIraiTblByKeyBusinessLogic().Execute(getKensaIraiBLInput);

                    if (getKensaIraiBLOutput.KensaIraiTblDataTable.Count == 0) continue;

                    if (row.UpdateDt != getKensaIraiBLOutput.KensaIraiTblDataTable[0].UpdateDt)
                    {
                        throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                    }

                    //送付日
                    getKensaIraiBLOutput.KensaIraiTblDataTable[0].KensaIraiSofuDt = input.KensaIraiSofuDt;

                    //更新日
                    getKensaIraiBLOutput.KensaIraiTblDataTable[0].UpdateDt = Boundary.Common.Common.GetCurrentTimestamp();

                    //更新者
                    getKensaIraiBLOutput.KensaIraiTblDataTable[0].UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

                    //更新端末
                    getKensaIraiBLOutput.KensaIraiTblDataTable[0].UpdateTarm = Dns.GetHostName();

                    kensaIraiDTUpdate.Merge(getKensaIraiBLOutput.KensaIraiTblDataTable);
                }

                //update KensaIraiTbl
                IUpdateKensaIraiTblBLInput updateBLInput = new UpdateKensaIraiTblBLInput();
                updateBLInput.KensaIraiTblDataTable = kensaIraiDTUpdate;
                new UpdateKensaIraiTblBusinessLogic().Execute(updateBLInput);

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
