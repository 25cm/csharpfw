using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaKanryoInputList;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaKekkaInputList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.GaikanKensa.KensaYoteiList
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
    /// 2014/09/03  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALInput : IBseALInput, IGetShokuinMstByKensainFlgTaishokuFlgBLInput
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
    /// 2014/09/03  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALInput : IFormLoadALInput
    {
        /// <summary>
        /// ShokuinKensainFlg
        /// </summary>
        public string ShokuinKensainFlg { get; set; }

        /// <summary>
        /// ShokuinTaishokuFlg
        /// </summary>
        public string ShokuinTaishokuFlg { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("ShokuinKensainFlg[{0}], ShokuinTaishokuFlg[{1}]",
                    new string[] {
                        ShokuinKensainFlg,
                        ShokuinTaishokuFlg
                    });
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
    /// 2014/09/03  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALOutput : IGetShokuinMstByKensainFlgTaishokuFlgBLOutput
    {
        /// <summary>
        /// ShikuchosonInfoDataTable
        /// </summary>
        ChikuMstDataSet.ShikuchosonInfoDataTable ShikuchosonInfoDataTable { get; set; }
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
    /// 2014/09/03  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALOutput : IFormLoadALOutput
    {
        /// <summary>
        /// ShokuinMstDataTable
        /// </summary>
        public ShokuinMstDataSet.ShokuinMstDataTable ShokuinMstDT { get; set; }

        /// <summary>
        /// ShikuchosonInfoDataTable
        /// </summary>
        public ChikuMstDataSet.ShikuchosonInfoDataTable ShikuchosonInfoDataTable { get; set; }
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
    /// 2014/09/03  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadApplicationLogic : BaseApplicationLogic<IFormLoadALInput, IFormLoadALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaYoteiList：FormLoadApplicationLogic";

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
        /// 2014/09/03  DatNT　  新規作成
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
        /// 2014/09/03  DatNT　  新規作成
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
        /// 2014/09/03  DatNT　  新規作成
        /// 2015/01/13  HuyTX　  Ver1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IFormLoadALOutput Execute(IFormLoadALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IFormLoadALOutput output = new FormLoadALOutput();

            try
            {
                output.ShokuinMstDT = new GetShokuinMstByKensainFlgTaishokuFlgBusinessLogic().Execute(input).ShokuinMstDT;

                //Ver1.04 start
                IGetShikuchosonInfoBLInput getShikuchosonInput = new GetShikuchosonInfoBLInput();
                IGetShikuchosonInfoBLOutput getShikuchosonOutput = new GetShikuchosonInfoBusinessLogic().Execute(getShikuchosonInput);
                output.ShikuchosonInfoDataTable = getShikuchosonOutput.ShikuchosonInfoDataTable;
                //End

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
