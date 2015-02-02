using System.Reflection;
using FukjBizSystem.Application.DataAccess.KensaIraiTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Others.EnkabutsuIonNodoHikakuList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetEnkabutsuIonNodoHikakuListBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetEnkabutsuIonNodoHikakuListBySearchCondBLInput : ISelectEnkabutsuIonNodoHikakuListBySearchCondDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetEnkabutsuIonNodoHikakuListBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetEnkabutsuIonNodoHikakuListBySearchCondBLInput : IGetEnkabutsuIonNodoHikakuListBySearchCondBLInput
    {
        /// <summary>
        /// 採水日（開始）
        /// </summary>
        public string SaisuiDtFrom { get; set; }

        /// <summary>
        /// 採水日（終了）
        /// </summary>
        public string SaisuiDtTo { get; set; }

        /// <summary>
        /// 採水員名
        /// </summary>
        public string SaisuiinNm { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetEnkabutsuIonNodoHikakuListBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetEnkabutsuIonNodoHikakuListBySearchCondBLOutput : ISelectEnkabutsuIonNodoHikakuListBySearchCondDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetEnkabutsuIonNodoHikakuListBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetEnkabutsuIonNodoHikakuListBySearchCondBLOutput : IGetEnkabutsuIonNodoHikakuListBySearchCondBLOutput
    {
        /// <summary>
        /// EnkabutsuIonNodoHikakuListDataTable
        /// </summary>
        public KensaIraiTblDataSet.EnkabutsuIonNodoHikakuListDataTable EnkabutsuIonNodoHikakuListDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetEnkabutsuIonNodoHikakuListBySearchCondBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetEnkabutsuIonNodoHikakuListBySearchCondBusinessLogic : BaseBusinessLogic<IGetEnkabutsuIonNodoHikakuListBySearchCondBLInput, IGetEnkabutsuIonNodoHikakuListBySearchCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetEnkabutsuIonNodoHikakuListBySearchCondBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetEnkabutsuIonNodoHikakuListBySearchCondBusinessLogic()
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
        /// 2014/08/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetEnkabutsuIonNodoHikakuListBySearchCondBLOutput Execute(IGetEnkabutsuIonNodoHikakuListBySearchCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetEnkabutsuIonNodoHikakuListBySearchCondBLOutput output = new GetEnkabutsuIonNodoHikakuListBySearchCondBLOutput();

            try
            {
                output.EnkabutsuIonNodoHikakuListDT = new SelectEnkabutsuIonNodoHikakuListBySearchCondDataAccess().Execute(input).EnkabutsuIonNodoHikakuListDT;
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
