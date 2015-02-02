using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;
using FukjBizSystem.Application.Utility;
using FukjBizSystem.Application.BusinessLogic.Common;
using FukjBizSystem.Application.DataSet;

namespace FukjBizSystem.Application.ApplicationLogic.Common
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetYubinNoAdrMstByTodofukenAdrALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// yyyy/mm/dd　××　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetYubinNoAdrMstByTodofukenAdrALInput : IBseALInput,IGetYubinNoAdrMstByTodofukenAdrBLInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetYubinNoAdrMstByTodofukenAdrALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// yyyy/mm/dd　××　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetYubinNoAdrMstByTodofukenAdrALInput : IGetYubinNoAdrMstByTodofukenAdrALInput
    {
        /// <summary>
        /// 都道府県名
        /// </summary>
        public String TodofukenNm { get; set; }

        /// <summary>
        /// 住所
        /// </summary>
        public String AdrNm { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                // TODO ログ出力用データ文字列を作成してください
                return string.Empty;
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetYubinNoAdrMstByTodofukenAdrALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// yyyy/mm/dd　××　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetYubinNoAdrMstByTodofukenAdrALOutput : IGetYubinNoAdrMstByTodofukenAdrBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetYubinNoAdrMstByTodofukenAdrALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// yyyy/mm/dd　××　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetYubinNoAdrMstByTodofukenAdrALOutput : IGetYubinNoAdrMstByTodofukenAdrALOutput
    {
        /// <summary>
        /// YubinNoAdrMstDataTable
        /// </summary>
        public YubinNoAdrMstKensakuDataSet.YubinNoAdrMstDataTable YubinNoAdrMstDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetYubinNoAdrMstByTodofukenAdrApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// yyyy/mm/dd　××　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetYubinNoAdrMstByTodofukenAdrApplicationLogic : BaseApplicationLogic<IGetYubinNoAdrMstByTodofukenAdrALInput, IGetYubinNoAdrMstByTodofukenAdrALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "YubinNoKensaku：kensakuButton_Click";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetYubinNoAdrMstByTodofukenAdrApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// yyyy/mm/dd　××　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetYubinNoAdrMstByTodofukenAdrApplicationLogic()
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
        /// yyyy/mm/dd　××　　    新規作成
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
        /// yyyy/mm/dd　××　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetYubinNoAdrMstByTodofukenAdrALOutput Execute(IGetYubinNoAdrMstByTodofukenAdrALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetYubinNoAdrMstByTodofukenAdrALOutput output = new GetYubinNoAdrMstByTodofukenAdrALOutput();

            try
            {
                IGetYubinNoAdrMstByTodofukenAdrBLOutput blOutput = new GetYubinNoAdrMstByTodofukenAdrBusinessLogic().Execute(input);

                output.YubinNoAdrMstDT = blOutput.YubinNoAdrMstDT;

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
