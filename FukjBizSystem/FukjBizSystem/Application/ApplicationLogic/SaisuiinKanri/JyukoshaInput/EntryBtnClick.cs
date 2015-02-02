using System;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.BusinessLogic.Master.SaisuiinMstShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.SaisuiinKanri.JyukoshaInput
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IEntryBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/25　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IEntryBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// Kaisaibi
        /// </summary>
        string Kaisaibi { get; set; }

        /// <summary>
        /// JyukoshaListDataGridView
        /// </summary>
        DataGridView JyukoshaListDataGridView { get; set; }

        /// <summary>
        /// YukokigenDt 
        /// </summary>
        string YukokigenDt { get; set; }

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： EntryBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/25　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class EntryBtnClickALInput : IEntryBtnClickALInput
    {
        /// <summary>
        /// Kaisaibi
        /// </summary>
        public string Kaisaibi { get; set; }

        /// <summary>
        /// JyukoshaListDataGridView
        /// </summary>
        public DataGridView JyukoshaListDataGridView { get; set; }

        /// <summary>
        /// YukokigenDt 
        /// </summary>
        public string YukokigenDt { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("採水員コード[{0}]", JyukoshaListDataGridView.Rows[0].Cells["SaisuiinCdCol"].Value.ToString());
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IEntryBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/25　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IEntryBtnClickALOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： EntryBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/25　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class EntryBtnClickALOutput : IEntryBtnClickALOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： EntryBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/25　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class EntryBtnClickApplicationLogic : BaseApplicationLogic<IEntryBtnClickALInput, IEntryBtnClickALOutput>
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
        private const string FunctionName = "JyukoshaInput：EntryBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： EntryBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/25　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public EntryBtnClickApplicationLogic()
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
        /// 2014/07/25　HuyTX　　    新規作成
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
        /// 2014/07/25　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IEntryBtnClickALOutput Execute(IEntryBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IEntryBtnClickALOutput output = new EntryBtnClickALOutput();

            try
            {
                // トランザクション開始
                StartTransaction();

                IUpdateSaisuiinMstBLInput blInput = new UpdateSaisuiinMstBLInput();
                blInput.SaisuiinMstDataTable = CreateSaisuiinData(input);
                new UpdateSaisuiinMstBusinessLogic().Execute(blInput);

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

        #region CreateSaisuiinData
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSaisuiinData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/25  HuyTX　　    新規作成
        /// 2014/10/07  HuyTX　　    Ver1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SaisuiinMstDataSet.SaisuiinMstDataTable CreateSaisuiinData(IEntryBtnClickALInput input)
        {
            SaisuiinMstDataSet.SaisuiinMstDataTable SaisuiinMstDT = new SaisuiinMstDataSet.SaisuiinMstDataTable();

            DateTime currentDateTime = Boundary.Common.Common.GetCurrentTimestamp();
            string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            string tarmName = Dns.GetHostName();
            string saisuiinCd = string.Empty;

            IGetSaisuiinMstByKeyBLInput blInput = new GetSaisuiinMstByKeyBLInput();

            for (int i = 0; i < input.JyukoshaListDataGridView.RowCount - 1; i++)
            {
                DataGridViewRow row = input.JyukoshaListDataGridView.Rows[i];

                blInput.SaisuiinCd = row.Cells["SaisuiinCdCol"].Value != null ? row.Cells["SaisuiinCdCol"].Value.ToString() : string.Empty;

                IGetSaisuiinMstByKeyBLOutput blOutput = new GetSaisuiinMstByKeyBusinessLogic().Execute(blInput);

                if (blOutput.SaisuiinMstDataTable.Count == 0) { continue; }

                if ((DateTime)row.Cells["UpdateDtCol"].Value != blOutput.SaisuiinMstDataTable[0].UpdateDt)
                {
                    throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                }

                blOutput.SaisuiinMstDataTable[0].JukoDt = input.Kaisaibi;
                blOutput.SaisuiinMstDataTable[0].ZenkaiJukoDt = input.Kaisaibi;
                blOutput.SaisuiinMstDataTable[0].SaisuiinYukokigenDt = input.YukokigenDt;
                blOutput.SaisuiinMstDataTable[0].UpdateDt = currentDateTime;
                blOutput.SaisuiinMstDataTable[0].UpdateUser = loginUser;
                blOutput.SaisuiinMstDataTable[0].UpdateTarm = tarmName;

                SaisuiinMstDT.Merge(blOutput.SaisuiinMstDataTable);
            }

            return SaisuiinMstDT;
        }
        #endregion

        #endregion
    }
    #endregion
}
