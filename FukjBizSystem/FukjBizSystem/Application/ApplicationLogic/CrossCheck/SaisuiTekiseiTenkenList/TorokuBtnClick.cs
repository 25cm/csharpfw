using System;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.CrossCheck.SaisuiTekiseiTenkenList;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaTorisageList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.CrossCheck.SaisuiTekiseiTenkenList
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
    /// 2014/10/22　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ITorokuBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// システム日付
        /// </summary>
        DateTime SystemDt { get; set; }

        /// <summary>
        /// 更新日 - for checking optimistic lock
        /// </summary>
        DateTime KensaUpdateDt { get; set; }

        /// <summary>
        /// 更新日 - for checking optimistic lock
        /// </summary>
        DateTime CrossUpdateDt { get; set; }

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
        /// クロスチェック理由
        /// </summary>
        string CrossCheckRiyu { get; set; }

        /// <summary>
        /// 特記事項
        /// </summary>
        string TokkiJikou { get; set; }

        /// <summary>
        /// 前回清掃日
        /// </summary>
        string LastSeisouDt { get; set; }

        /// <summary>
        /// 建物用途
        /// </summary>
        string TatemonoYouto { get; set; }
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
    /// 2014/10/22　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class TorokuBtnClickALInput : ITorokuBtnClickALInput
    {
        /// <summary>
        /// システム日付
        /// </summary>
        public DateTime SystemDt { get; set; }

        /// <summary>
        /// 更新日 - for checking optimistic lock
        /// </summary>
        public DateTime KensaUpdateDt { get; set; }

        /// <summary>
        /// 更新日 - for checking optimistic lock
        /// </summary>
        public DateTime CrossUpdateDt { get; set; }

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
        /// クロスチェック理由
        /// </summary>
        public string CrossCheckRiyu { get; set; }

        /// <summary>
        /// 特記事項
        /// </summary>
        public string TokkiJikou { get; set; }

        /// <summary>
        /// 前回清掃日
        /// </summary>
        public string LastSeisouDt { get; set; }

        /// <summary>
        /// 建物用途
        /// </summary>
        public string TatemonoYouto { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("検査依頼法定区分[{0}], 検査依頼保健所コード[{1}], 検査依頼年度[{2}], 検査依頼連番[{3}]",
                    KensaIraiHoteiKbn, KensaIraiHokenjoCd, KensaIraiNendo, KensaIraiRenban);
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
    /// 2014/10/22　AnhNV　　    新規作成
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
    /// 2014/10/22　AnhNV　　    新規作成
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
    /// 2014/10/22　AnhNV　　    新規作成
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
        private const string FunctionName = "SaisuiTekiseiTenkenList：TorokuBtnClick";

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
        /// 2014/10/22　AnhNV　　    新規作成
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
        /// 2014/10/22　AnhNV　　    新規作成
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
        /// 2014/10/22　AnhNV　　    新規作成
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

                // 変更
                IUpdateKensaIraiTblBLInput blInput = new UpdateKensaIraiTblBLInput();
                blInput.KensaIraiTblDataTable = CreateKensaIraiTblUpdate(input);
                new UpdateKensaIraiTblBusinessLogic().Execute(blInput);

                //update CrossCheck
                IUpdateCrossCheckTblBLInput updateCrossCheck = new UpdateCrossCheckTblBLInput();
                updateCrossCheck.CrossCheckTblDataTable = CreateCrossCheckTblDataTableUpdate(input);
                new UpdateCrossCheckTblBusinessLogic().Execute(updateCrossCheck);

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

        #region メソッド(private)

        #region CreateKensaIraiTblUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateKensaIraiTblUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/22  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaIraiTblDataSet.KensaIraiTblDataTable CreateKensaIraiTblUpdate(ITorokuBtnClickALInput input)
        {
            // 更新者
            string user = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            // 更新端末
            string host = Dns.GetHostName();

            // Get KensaIraiTbl by key
            IGetKensaIraiTblByKeyBLInput blInput = new GetKensaIraiTblByKeyBLInput();
            blInput.KensaIraiHokenjoCd = input.KensaIraiHokenjoCd;
            blInput.KensaIraiHoteiKbn = input.KensaIraiHoteiKbn;
            blInput.KensaIraiNendo = input.KensaIraiNendo;
            blInput.KensaIraiRenban = input.KensaIraiRenban;
            IGetKensaIraiTblByKeyBLOutput blOutput = new GetKensaIraiTblByKeyBusinessLogic().Execute(blInput);

            // Update mode?
            if (blOutput.KensaIraiTblDataTable.Count > 0)
            {
                // 更新日が違うか？
                if (blOutput.KensaIraiTblDataTable[0].UpdateDt != input.KensaUpdateDt)
                {
                    throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                }

                // クロスチェック理由
                blOutput.KensaIraiTblDataTable[0].KensaIraiCrossCheckRiyu = input.CrossCheckRiyu;
                // 更新日
                blOutput.KensaIraiTblDataTable[0].UpdateDt = input.SystemDt;
                // 更新者
                blOutput.KensaIraiTblDataTable[0].UpdateUser = user;
                // 更新端末
                blOutput.KensaIraiTblDataTable[0].UpdateTarm = host;
            }
            else // insert
            {
                // Create a new row for insert
                KensaIraiTblDataSet.KensaIraiTblRow newRow = blOutput.KensaIraiTblDataTable.NewKensaIraiTblRow();

                // 検査依頼法定区分
                newRow.KensaIraiHoteiKbn = input.KensaIraiHoteiKbn;
                // 検査依頼保健所コード
                newRow.KensaIraiHokenjoCd = input.KensaIraiHokenjoCd;
                // 検査依頼年度
                newRow.KensaIraiNendo = input.KensaIraiNendo;
                // 検査依頼連番
                newRow.KensaIraiRenban = input.KensaIraiRenban;

                #region NOT NULL fields
                // 検査依頼受付支所
                newRow.KensaIraiUketsukeShishoKbn = string.Empty;
                // 浄化槽保健所コード
                newRow.KensaIraiJokasoHokenjoCd = string.Empty;
                // 浄化槽台帳登録年度
                newRow.KensaIraiJokasoTorokuNendo = string.Empty;
                // 浄化槽台帳連番
                newRow.KensaIraiJokasoRenban = string.Empty;
                #endregion

                // クロスチェック理由
                newRow.KensaIraiCrossCheckRiyu = input.CrossCheckRiyu;
                // 登録日時
                newRow.InsertDt = input.SystemDt;
                // 登録者
                newRow.InsertUser = user;
                // 登録端末
                newRow.InsertTarm = host;
                // 更新日時
                newRow.UpdateDt = input.SystemDt;
                // 更新者
                newRow.UpdateUser = user;
                // 更新端末
                newRow.UpdateTarm = host;

                // Adding a new row
                blOutput.KensaIraiTblDataTable.AddKensaIraiTblRow(newRow);
                newRow.AcceptChanges();
                newRow.SetAdded();
            }

            return blOutput.KensaIraiTblDataTable;
        }
        #endregion

        #region CreateCrossCheckTblDataTableUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateCrossCheckTblDataTableUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/27  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private CrossCheckTblDataSet.CrossCheckTblDataTable CreateCrossCheckTblDataTableUpdate(ITorokuBtnClickALInput input)
        {
            // 更新者
            string user = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            // 更新端末
            string host = Dns.GetHostName();

            // Get CrossCheckTbl by key
            IGetCrossCheckTblByKeyBLInput blInput = new GetCrossCheckTblByKeyBLInput();
            blInput.KensaIraiHokenjoCd = input.KensaIraiHokenjoCd;
            blInput.KensaIraiHoteiKbn = input.KensaIraiHoteiKbn;
            blInput.KensaIraiNendo = input.KensaIraiNendo;
            blInput.KensaIraiRenban = input.KensaIraiRenban;
            IGetCrossCheckTblByKeyBLOutput blOutput = new GetCrossCheckTblByKeyBusinessLogic().Execute(blInput);

            // Update mode?
            if (blOutput.CrossCheckTblDataTable.Count > 0)
            {
                // 更新日が違うか？
                if (blOutput.CrossCheckTblDataTable[0].UpdateDt != input.CrossUpdateDt)
                {
                    throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                }

                // 特記事項
                blOutput.CrossCheckTblDataTable[0].KikitoriTokkijiko = input.TokkiJikou;
                // 清掃日
                blOutput.CrossCheckTblDataTable[0].KikitoriSeisobi = input.LastSeisouDt;
                // 建築用途
                blOutput.CrossCheckTblDataTable[0].KenchikuYoto = input.TatemonoYouto;
                // 更新日
                blOutput.CrossCheckTblDataTable[0].UpdateDt = input.SystemDt;
                // 更新者
                blOutput.CrossCheckTblDataTable[0].UpdateUser = user;
                // 更新端末
                blOutput.CrossCheckTblDataTable[0].UpdateTarm = host;
            }
            else // insert
            {
                // Create a new row for insert
                CrossCheckTblDataSet.CrossCheckTblRow newRow = blOutput.CrossCheckTblDataTable.NewCrossCheckTblRow();

                // 検査依頼法定区分
                newRow.KensaIraiHoteiKbn = input.KensaIraiHoteiKbn;
                // 検査依頼保健所コード
                newRow.KensaIraiHokenjoCd = input.KensaIraiHokenjoCd;
                // 検査依頼年度
                newRow.KensaIraiNendo = input.KensaIraiNendo;
                // 検査依頼連番
                newRow.KensaIraiRenban = input.KensaIraiRenban;

                #region NOT NULL fields
                // 水質検査依頼番号
                newRow.KensaIraiSuishitsuNo = string.Empty;
                #endregion

                // 特記事項
                newRow.KikitoriTokkijiko = input.TokkiJikou;
                // 清掃日
                newRow.KikitoriSeisobi = input.LastSeisouDt;
                // 建築用途
                newRow.KenchikuYoto = input.TatemonoYouto;
                // 登録日時
                newRow.InsertDt = input.SystemDt;
                // 登録者
                newRow.InsertUser = user;
                // 登録端末
                newRow.InsertTarm = host;
                // 更新日時
                newRow.UpdateDt = input.SystemDt;
                // 更新者
                newRow.UpdateUser = user;
                // 更新端末
                newRow.UpdateTarm = host;

                // Adding a new row
                blOutput.CrossCheckTblDataTable.AddCrossCheckTblRow(newRow);
                newRow.AcceptChanges();
                newRow.SetAdded();
            }

            return blOutput.CrossCheckTblDataTable;
        }
        #endregion

        #endregion
    }
    #endregion
}
