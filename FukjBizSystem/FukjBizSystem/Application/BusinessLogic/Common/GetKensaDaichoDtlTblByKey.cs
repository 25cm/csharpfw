using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FukjBizSystem.Application.DataAccess.KensaDaichoDtlTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;
using System.Reflection;

namespace FukjBizSystem.Application.BusinessLogic.Common
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaDaichoDtlTblByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  宗    　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaDaichoDtlTblByKeyBLInput : ISelectKensaDaichoDtlTblByKeyDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaDaichoDtlTblByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  宗    　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaDaichoDtlTblByKeyBLInput : IGetKensaDaichoDtlTblByKeyBLInput
    {
        /// <summary>
        /// 区分 
        /// </summary>
        public string Kbn { get; set; }
        /// <summary>
        /// 依頼年度 
        /// </summary>
        public string IraiNendo { get; set; }
        /// <summary>
        /// 支所コード 
        /// </summary>
        public string Sisho { get; set; }
        /// <summary>
        /// 依頼番号 
        /// </summary>
        public string IraiNo { get; set; }
        /// <summary>
        /// 試験項目コード
        /// </summary>
        public string ShikenkoumokuCd { get; set; }
        /// <summary>
        /// 再検査回数 
        /// </summary>
        public string SaikensaKbn { get; set; }
    }

    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaDaichoDtlTblByKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  宗    　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaDaichoDtlTblByKeyBLOutput : ISelectKensaDaichoDtlTblByKeyDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaDaichoDtlTblByKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  宗    　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaDaichoDtlTblByKeyBLOutput : IGetKensaDaichoDtlTblByKeyBLOutput
    {
        /// <summary>
        /// KensaDaichoDtlTblDataTable
        /// </summary>
        public KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable KensaDaichoDtlTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaDaichoDtlTblByKeyBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  宗    　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaDaichoDtlTblByKeyBusinessLogic : BaseBusinessLogic<IGetKensaDaichoDtlTblByKeyBLInput, IGetKensaDaichoDtlTblByKeyBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKensaDaichoDtlTblByKeyBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02  宗    　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKensaDaichoDtlTblByKeyBusinessLogic()
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
        /// 2014/12/02  宗    　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKensaDaichoDtlTblByKeyBLOutput Execute(IGetKensaDaichoDtlTblByKeyBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKensaDaichoDtlTblByKeyBLOutput output = new GetKensaDaichoDtlTblByKeyBLOutput();

            try
            {
                output.KensaDaichoDtlTblDT = new SelectKensaDaichoDtlTblByKeyDataAccess().Execute(input).KensaDaichoDtlTblDT;
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
