using System;
using System.Reflection;
using FukjBizSystem.Application.DataAccess.KatashikiBetsuTaniSochiMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Master.KatashikiMstShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKatashikiBetsuTaniSochiMstByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/11  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKatashikiBetsuTaniSochiMstByKeyBLInput : ISelectKatashikiBetsuTaniSochiMstByKeyDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKatashikiBetsuTaniSochiMstByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/11  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKatashikiBetsuTaniSochiMstByKeyBLInput : IGetKatashikiBetsuTaniSochiMstByKeyBLInput
    {
        /// <summary>
        /// メーカー業者コード
        /// </summary>
        public String KatashikiMakerCd { get; set; }

        /// <summary>
        /// 型式コード
        /// </summary>
        public String KatashikiCd { get; set; }

        // DEL 20140731 START ZynasSou
        ///// <summary>
        ///// 単位装置コード
        ///// </summary>
        //public String TaniSochiCd { get; set; }
        // DEL 20140731 END ZynasSou

        // ADD 20140731 START ZynasSou
        /// <summary>
        /// 単位装置グループコード
        /// </summary>
        public String TaniSochiGroupCd { get; set; }
        // ADD 20140731 END ZynasSou

        // ADD 20140731 START ZynasSou
        /// <summary>
        /// 単位装置名
        /// </summary>
        public String TaniSochiNm { get; set; }
        // ADD 20140731 END ZynasSou
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKatashikiBetsuTaniSochiMstByKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/11  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKatashikiBetsuTaniSochiMstByKeyBLOutput : ISelectKatashikiBetsuTaniSochiMstByKeyDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKatashikiBetsuTaniSochiMstByKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/11  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKatashikiBetsuTaniSochiMstByKeyBLOutput : IGetKatashikiBetsuTaniSochiMstByKeyBLOutput
    {
        /// <summary>
        /// KatashikiBetsuTaniSochiMstDataTable
        /// </summary>
        public KatashikiBetsuTaniSochiMstDataSet.KatashikiBetsuTaniSochiMstDataTable KatashikiBetsuTaniSochiMstDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKatashikiBetsuTaniSochiMstByKeyBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/11  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKatashikiBetsuTaniSochiMstByKeyBusinessLogic : BaseBusinessLogic<IGetKatashikiBetsuTaniSochiMstByKeyBLInput, IGetKatashikiBetsuTaniSochiMstByKeyBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKatashikiBetsuTaniSochiMstByKeyBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/11  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKatashikiBetsuTaniSochiMstByKeyBusinessLogic()
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
        /// 2014/07/11  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKatashikiBetsuTaniSochiMstByKeyBLOutput Execute(IGetKatashikiBetsuTaniSochiMstByKeyBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKatashikiBetsuTaniSochiMstByKeyBLOutput output = new GetKatashikiBetsuTaniSochiMstByKeyBLOutput();

            try
            {
                output.KatashikiBetsuTaniSochiMstDT = new SelectKatashikiBetsuTaniSochiMstByKeyDataAccess().Execute(input).KatashikiBetsuTaniSochiMstDT;
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
