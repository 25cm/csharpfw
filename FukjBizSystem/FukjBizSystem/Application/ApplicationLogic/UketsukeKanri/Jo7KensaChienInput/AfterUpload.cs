using System.Net;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.UketsukeKanri.Jo7KensaChienInput;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.UketsukeKanri.Jo7KensaChienInput
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IAfterUploadALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/30  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IAfterUploadALInput : IBseALInput
    {
        /// <summary>
        /// HoteiKbn
        /// </summary>
        string IraiHoteiKbn { get; set; }

        /// <summary>
        /// HokenjoCd
        /// </summary>
        string IraiHokenjoCd { get; set; }

        /// <summary>
        /// IraiNendo
        /// </summary>
        string IraiNendo { get; set; }

        /// <summary>
        /// Renban
        /// </summary>
        string IraiRenban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： AfterUploadALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/30  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class AfterUploadALInput : IAfterUploadALInput
    {
        /// <summary>
        /// HoteiKbn
        /// </summary>
        public string IraiHoteiKbn { get; set; }

        /// <summary>
        /// HokenjoCd
        /// </summary>
        public string IraiHokenjoCd { get; set; }

        /// <summary>
        /// IraiNendo
        /// </summary>
        public string IraiNendo { get; set; }

        /// <summary>
        /// Renban
        /// </summary>
        public string IraiRenban { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("IraiHoteiKbn[{0}], IraiHokenjoCd[{1}], IraiNendo[{2}], IraiRenban[{3}]",
                    IraiHoteiKbn, IraiHokenjoCd, IraiNendo, IraiRenban);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IAfterUploadALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/30  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IAfterUploadALOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： AfterUploadALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/30  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class AfterUploadALOutput : IAfterUploadALOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： AfterUploadApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/30  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class AfterUploadApplicationLogic : BaseApplicationLogic<IAfterUploadALInput, IAfterUploadALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "Jo7KensaChienInput：AfterUpload";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： AfterUploadApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/30  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public AfterUploadApplicationLogic()
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
        /// 2015/01/30  豊田　　    新規作成
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
        /// 2015/01/30  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IAfterUploadALOutput Execute(IAfterUploadALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IAfterUploadALOutput output = new AfterUploadALOutput();

            try
            {
                KensaIraiTblDataSet.KensaIraiTblForChienHokokuUpdateDataTable datatable = MakeUpdateData(input);

                // トランザクション開始
                StartTransaction();

                IUpdateKensaIraiTblForChienHokokuBLInput blInput = new UpdateKensaIraiTblForChienHokokuBLInput();

                blInput.ChienHokokuUpdateDataTable = datatable;

                new UpdateKensaIraiTblForChienHokokuBusinessLogic().Execute(blInput);

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

        #region MakeUpdateData
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeUpdateData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/30  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaIraiTblDataSet.KensaIraiTblForChienHokokuUpdateDataTable MakeUpdateData(IAfterUploadALInput input)
        {
            KensaIraiTblDataSet.KensaIraiTblForChienHokokuUpdateDataTable datatable = new KensaIraiTblDataSet.KensaIraiTblForChienHokokuUpdateDataTable();

            KensaIraiTblDataSet.KensaIraiTblForChienHokokuUpdateRow newRow = datatable.NewKensaIraiTblForChienHokokuUpdateRow();

            newRow.KensaIraiHoteiKbn = input.IraiHoteiKbn;

            newRow.KensaIraiHokenjoCd = input.IraiHokenjoCd;

            newRow.KensaIraiNendo = input.IraiNendo;

            newRow.KensaIraiRenban = input.IraiRenban;

            // 1:作成済み
            newRow.ChienHokokuMakeKbn = "1";

            // Current system date
            newRow.UpdateDt = Boundary.Common.Common.GetCurrentTimestamp();
            // Login name
            newRow.UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            // Machine name
            newRow.UpdateTarm = Dns.GetHostName();

            datatable.AddKensaIraiTblForChienHokokuUpdateRow(newRow);

            newRow.AcceptChanges();
            newRow.SetModified();

            return datatable;
        }
        #endregion
        
        #endregion
    }
    #endregion
}
