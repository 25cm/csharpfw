using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Keiri.SeikyuList;
using FukjBizSystem.Application.BusinessLogic.Keiri.SeikyuShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Keiri.SeikyuShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IFormLoadALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/30  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALInput : IBseALInput, //IGetSeikyuShosaiFormLoadBySeikyuNoBLInput
                                 IGetSeikyuShosaiFormLoadHdrByOyaSeikyuNoBLInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FormLoadALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/13  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALInput : IFormLoadALInput
    {
        /// <summary>
        /// 親請求No
        /// </summary>
        public string OyaSeikyuNo { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("親請求No [{0}]", OyaSeikyuNo);
                
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IFormLoadALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/30  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALOutput : //IGetSeikyuShosaiFormLoadBySeikyuNoBLOutput
                                    IGetSeikyuShosaiFormLoadHdrByOyaSeikyuNoBLOutput,
                                    IGetSeikyuShosaiFormLoadDtlByOyaSeikyuNoBLOutput,
                                    IGetSeikyusyoKagamiHdrTblByKeyBLOutput,
                                    IGetSeikyuHdrTblByKeyBLOutput,
                                    IGetSeikyuHdrTblByOyaSeikyuNoBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FormLoadALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/30  DatNT　  新規作成
    /// 2014/11/05  DatNT   v1.02
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALOutput : IFormLoadALOutput
    {
        // 2014/11/05 DatNT v1.02 MOD Start
        ///// <summary>
        ///// SeikyuShosaiFormLoadDataTable
        ///// </summary>
        //public SeikyuDtlTblDataSet.SeikyuShosaiFormLoadDataTable SeikyuShosaiFormLoadDT { get; set; }

        /// <summary>
        /// SeikyuShosaiFormLoadHdrDataTable
        /// </summary>
        public SeikyusyoKagamiHdrTblDataSet.SeikyuShosaiFormLoadHdrDataTable SeikyuShosaiFormLoadHdrDT { get; set; }

        /// <summary>
        /// SeikyuShosaiFormLoadDtlDataTable
        /// </summary>
        public SeikyuDtlTblDataSet.SeikyuShosaiFormLoadDtlDataTable SeikyuShosaiFormLoadDtlDT { get; set; }

        /// <summary>
        /// 請求書鑑ヘッダテーブル
        /// </summary>
        public SeikyusyoKagamiHdrTblDataSet.SeikyusyoKagamiHdrTblDataTable SeikyusyoKagamiHdrTblDataTable { get; set; }

        /// <summary>
        /// 請求ヘッダテーブル
        /// </summary>
        public SeikyuHdrTblDataSet.SeikyuHdrTblDataTable SeikyuHdrTblDataTable { get; set; }

        /// <summary>
        /// SeikyuHdrTblDataTable
        /// </summary>
        public SeikyuHdrTblDataSet.SeikyuHdrTblDataTable SeikyuHdrTblDT { get; set; }

        // 2014/11/05 DatNT v1.02 MOD End
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FormLoadApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/30  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadApplicationLogic : BaseApplicationLogic<IFormLoadALInput, IFormLoadALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "SeikyuShosai：FormLoadApplicationLogic";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： FormLoadApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/30  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public FormLoadApplicationLogic()
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
        /// 2014/09/30  DatNT　  新規作成
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
        /// 2014/09/30  DatNT　  新規作成
        /// 2014/11/05  DatNT   v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IFormLoadALOutput Execute(IFormLoadALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IFormLoadALOutput output = new FormLoadALOutput();

            try
            {
                // 2014/11/05 DatNT v1.02 MOD Start
                //output.SeikyuShosaiFormLoadDT = new GetSeikyuShosaiFormLoadBySeikyuNoBusinessLogic().Execute(input).SeikyuShosaiFormLoadDT;

                // Get SeikyusyoKagamiHdrTbl by key
                IGetSeikyusyoKagamiHdrTblByKeyBLInput kagamiInput = new GetSeikyusyoKagamiHdrTblByKeyBLInput();
                kagamiInput.OyaSeikyuNo = input.OyaSeikyuNo;
                output.SeikyusyoKagamiHdrTblDataTable = new GetSeikyusyoKagamiHdrTblByKeyBusinessLogic().Execute(kagamiInput).SeikyusyoKagamiHdrTblDataTable;

                // Get SeikyuHdrTbl by OyaSeikyuNo
                IGetSeikyuHdrTblByOyaSeikyuNoBLInput hdrInput = new GetSeikyuHdrTblByOyaSeikyuNoBLInput();
                hdrInput.OyaSeikyuNo = input.OyaSeikyuNo;
                output.SeikyuHdrTblDT = new GetSeikyuHdrTblByOyaSeikyuNoBusinessLogic().Execute(hdrInput).SeikyuHdrTblDT;
                
                output.SeikyuShosaiFormLoadHdrDT = new GetSeikyuShosaiFormLoadHdrByOyaSeikyuNoBusinessLogic().Execute(input).SeikyuShosaiFormLoadHdrDT;

                IGetSeikyuShosaiFormLoadDtlByOyaSeikyuNoBLInput dtlInput = new GetSeikyuShosaiFormLoadDtlByOyaSeikyuNoBLInput();
                dtlInput.OyaSeikyuNo = input.OyaSeikyuNo;
                output.SeikyuShosaiFormLoadDtlDT = new GetSeikyuShosaiFormLoadDtlByOyaSeikyuNoBusinessLogic().Execute(dtlInput).SeikyuShosaiFormLoadDtlDT;

                // 2014/11/05 DatNT v1.02 MOD End
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
