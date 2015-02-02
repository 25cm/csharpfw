using System.Reflection;
using FukjBizSystem.Application.DataAccess.KensaIraiTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.UketsukeKanri.Jo7KensaIraiList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGet7JoKensaIraiListBySearchCondBLInput
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
    interface IGet7JoKensaIraiListBySearchCondBLInput : ISelect7JoKensaIraiListBySearchCondDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Get7JoKensaIraiListBySearchCondBLInput
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
    class Get7JoKensaIraiListBySearchCondBLInput : IGet7JoKensaIraiListBySearchCondBLInput
    {
        /// <summary>
        /// KensaIraiDtFrom 
        /// </summary>
        public string KensaIraiDtFrom { get; set; }

        /// <summary>
        /// KensaIraiDtTo 
        /// </summary>
        public string KensaIraiDtTo { get; set; }

        /// <summary>
        /// IsCheckKensaIraiSofuDt 
        /// </summary>
        public bool IsCheckKensaIraiSofuDt { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGet7JoKensaIraiListBySearchCondBLOutput
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
    interface IGet7JoKensaIraiListBySearchCondBLOutput : ISelect7JoKensaIraiListBySearchCondDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Get7JoKensaIraiListBySearchCondBLOutput
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
    class Get7JoKensaIraiListBySearchCondBLOutput : IGet7JoKensaIraiListBySearchCondBLOutput
    {
        /// <summary>
        /// KensaIraiListDataTable
        /// </summary>
        public KensaIraiTblDataSet.Jo7KensaIraiListDataTable Jo7KensaIraiListDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Get7JoKensaIraiListBySearchCondBusinessLogic
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
    class Get7JoKensaIraiListBySearchCondBusinessLogic : BaseBusinessLogic<IGet7JoKensaIraiListBySearchCondBLInput, IGet7JoKensaIraiListBySearchCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： Get7JoKensaIraiListBySearchCondBusinessLogic
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
        public Get7JoKensaIraiListBySearchCondBusinessLogic()
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
        /// 2014/09/05  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGet7JoKensaIraiListBySearchCondBLOutput Execute(IGet7JoKensaIraiListBySearchCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGet7JoKensaIraiListBySearchCondBLOutput output = new Get7JoKensaIraiListBySearchCondBLOutput();

            try
            {
                output.Jo7KensaIraiListDataTable = new Select7JoKensaIraiListBySearchCondDataAccess().Execute(input).Jo7KensaIraiListDataTable;

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
