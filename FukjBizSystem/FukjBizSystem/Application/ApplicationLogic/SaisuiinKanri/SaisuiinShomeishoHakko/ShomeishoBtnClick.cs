using System;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Master.SaisuiinMstShosai;
using FukjBizSystem.Application.BusinessLogic.SaisuiinKanri.SaisuiinShomeishoHakko;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.SaisuiinKanri.SaisuiinShomeishoHakko
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IShomeishoBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/05　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IShomeishoBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// 発行日
        /// </summary>
        DateTime HakkoDt { get; set; }

        /// <summary>
        /// SaisuiinShomeishoHakkoKensakuDataTable
        /// </summary>
        SaisuiinMstDataSet.SaisuiinShomeishoHakkoKensakuDataTable SaisuiinShomeishoHakkoKensakuDataTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ShomeishoBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/05　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ShomeishoBtnClickALInput : IShomeishoBtnClickALInput
    {
        /// <summary>
        /// 発行日
        /// </summary>
        public DateTime HakkoDt { get; set; }

        /// <summary>
        /// SaisuiinShomeishoHakkoKensakuDataTable
        /// </summary>
        public SaisuiinMstDataSet.SaisuiinShomeishoHakkoKensakuDataTable SaisuiinShomeishoHakkoKensakuDataTable { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("発行日[{0}]", HakkoDt);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IShomeishoBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/05　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IShomeishoBtnClickALOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ShomeishoBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/05　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ShomeishoBtnClickALOutput : IShomeishoBtnClickALOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ShomeishoBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/05　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ShomeishoBtnClickApplicationLogic : BaseApplicationLogic<IShomeishoBtnClickALInput, IShomeishoBtnClickALOutput>
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
        private const string FunctionName = "SaisuiinShomeishoHakko：ShomeishoBtnClick";

        /// <summary>
        /// Part of 採水員有効期限
        /// </summary>
        private const string DATEPART = "0331";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ShomeishoBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/05　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public ShomeishoBtnClickApplicationLogic()
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
        /// 2014/08/05　AnhNV　　    新規作成
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
        /// 2014/08/05　AnhNV　　    新規作成
        /// 2014/10/08　AnhNV　　    基本設計書_004_004_画面_SaisuiinShomeishoHakko_V1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IShomeishoBtnClickALOutput Execute(IShomeishoBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IShomeishoBtnClickALOutput output = new ShomeishoBtnClickALOutput();

            try
            {
                // EXCEL output
                IPrintSaisuiinShomeishoBLInput blInput = new PrintSaisuiinShomeishoBLInput();
                //blInput.AfterDispFlg = true;
                blInput.AfterPrintFlg = true;
                //blInput.PrinterName = ;
                blInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.SaisuiinShomeishoFormatFile;
                blInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                blInput.SaisuiinShomeishoHakkoKensakuDataTable = input.SaisuiinShomeishoHakkoKensakuDataTable;
                blInput.HakkoDt = input.HakkoDt;
                new PrintSaisuiinShomeishoBusinessLogic().Execute(blInput);

                //// トランザクション開始
                //StartTransaction();

                //// DB update
                //IUpdateSaisuiinMstBLInput updateInput = new UpdateSaisuiinMstBLInput();
                //updateInput.SaisuiinMstDataTable = CreateSaisuiinMstUpdate(input);
                //new UpdateSaisuiinMstBusinessLogic().Execute(updateInput);

                //// コミット
                //CompleteTransaction();
            }
            catch
            {
                throw;
            }
            finally
            {
                // トランザクション終了
                //EndTransaction();

                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }

            return output;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region CreateSaisuiinMstUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSaisuiinMstUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/07　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SaisuiinMstDataSet.SaisuiinMstDataTable CreateSaisuiinMstUpdate(IShomeishoBtnClickALInput input)
        {
            // System date
            DateTime now = Boundary.Common.Common.GetCurrentTimestamp();
            // Login user
            string user = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            // Host name
            string host = Dns.GetHostName();
            // 受講日(MMdd)
            string jukoDt = string.Empty;
            // 受講日(yyyy)
            string jukoYear = string.Empty;

            // 採水員マスタ
            SaisuiinMstDataSet.SaisuiinMstDataTable table = new SaisuiinMstDataSet.SaisuiinMstDataTable();

            // Get saisuiinMst by key
            IGetSaisuiinMstByKeyBLInput blInput = new GetSaisuiinMstByKeyBLInput();

            foreach (SaisuiinMstDataSet.SaisuiinShomeishoHakkoKensakuRow row in input.SaisuiinShomeishoHakkoKensakuDataTable)
            {
                blInput.SaisuiinCd = row.SaisuiinCd;
                IGetSaisuiinMstByKeyBLOutput blOutput = new GetSaisuiinMstByKeyBusinessLogic().Execute(blInput);

                // No record was found
                if (blOutput.SaisuiinMstDataTable.Count == 0) continue;

                // 更新日が違うか？
                if (blOutput.SaisuiinMstDataTable[0].UpdateDt != row.UpdateDt)
                {
                    throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                }

                if (!string.IsNullOrEmpty(row.JukoDt.Trim()))
                {
                    // 受講日(MMdd)
                    jukoDt = Convert.ToDateTime(row.JukoDt).ToString("MMdd");
                    // 受講日(yyyy)
                    jukoYear = Convert.ToDateTime(row.JukoDt).ToString("yyyy");
                }

                // 採水員有効期限
                blOutput.SaisuiinMstDataTable[0].SaisuiinYukokigenDt = string.IsNullOrEmpty(jukoDt)
                    ? string.Empty : (Convert.ToInt32(jukoDt) > 331 ? Convert.ToInt32(jukoYear) + 4 + DATEPART : Convert.ToInt32(jukoYear) + 3 + DATEPART);

                // 更新日
                blOutput.SaisuiinMstDataTable[0].UpdateDt = now;

                // 更新者
                blOutput.SaisuiinMstDataTable[0].UpdateUser = user;

                // 更新端末
                blOutput.SaisuiinMstDataTable[0].UpdateTarm = host;

                // Merge to result table
                table.Merge(blOutput.SaisuiinMstDataTable);
            }

            return table;
        }
        #endregion

        #endregion
    }
    #endregion
}
