using System.Reflection;
using FukjBizSystem.Application.DataAccess.KensaIraiTbl;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;
using FukjBizSystem.Application.DataSet;
using System.Collections.Generic;

namespace FukjBizSystem.Application.BusinessLogic.Others.KensaJokyoList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaJokyoListBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/18　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaJokyoListBySearchCondBLInput : ISelectKensaJokyoListBySearchCondDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaJokyoListBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/18　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaJokyoListBySearchCondBLInput : IGetKensaJokyoListBySearchCondBLInput
    {
        /// <summary>
        /// HoteiKbn 
        /// </summary>
        public List<string> HoteiKbn { get; set; }

        /// <summary>
        /// JokasoSetchishaNm 
        /// </summary>
        public string JokasoSetchishaNm { get; set; }

        /// <summary>
        /// JokasoShisetsuNm 
        /// </summary>
        public string JokasoShisetsuNm { get; set; }

        /// <summary>
        /// SettisyaCd 
        /// </summary>
        public string SettisyaCd { get; set; }

        /// <summary>
        /// KensaIraiDtFrom 
        /// </summary>
        public string KensaIraiDtFrom { get; set; }

        /// <summary>
        /// KensaIraiDtTo 
        /// </summary>
        public string KensaIraiDtTo { get; set; }

        /// <summary>
        /// KensaDtFrom 
        /// </summary>
        public string KensaDtFrom { get; set; }

        /// <summary>
        /// KensaDtTo 
        /// </summary>
        public string KensaDtTo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaJokyoListBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/18　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaJokyoListBySearchCondBLOutput : ISelectKensaJokyoListBySearchCondDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaJokyoListBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/18　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaJokyoListBySearchCondBLOutput : IGetKensaJokyoListBySearchCondBLOutput
    {
        /// <summary>
        /// KensaJokyoListDataTable
        /// </summary>
        public KensaIraiTblDataSet.KensaJokyoListDataTable KensaJokyoListDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaJokyoListBySearchCondBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/18　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaJokyoListBySearchCondBusinessLogic : BaseBusinessLogic<IGetKensaJokyoListBySearchCondBLInput, IGetKensaJokyoListBySearchCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKensaJokyoListBySearchCondBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/18　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKensaJokyoListBySearchCondBusinessLogic()
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
        /// 2014/08/18　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKensaJokyoListBySearchCondBLOutput Execute(IGetKensaJokyoListBySearchCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKensaJokyoListBySearchCondBLOutput output = new GetKensaJokyoListBySearchCondBLOutput();

            try
            {
                output.KensaJokyoListDataTable = new SelectKensaJokyoListBySearchCondDataAccess().Execute(input).KensaJokyoListDataTable;

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
