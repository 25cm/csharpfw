using System;
using System.Reflection;
using FukjBizSystem.Application.DataAccess.ZenkaiKensaDataWrk;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.UketsukeKanri.JinendoGaikanKensaYoteiListOutput
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IInsertJinendoGaikenStep7BLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/04  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IInsertJinendoGaikenStep7BLInput : IInsertJinendoGaikenStep7DAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： InsertJinendoGaikenStep7BLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/04  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class InsertJinendoGaikenStep7BLInput : IInsertJinendoGaikenStep7BLInput
    {
        /// <summary>
        /// GyohsaCdFrom
        /// </summary>
        public string GyoshaCdFrom { get; set; }

        /// <summary>
        /// GyoshaCdTo
        /// </summary>
        public string GyoshaCdTo { get; set; }

        /// <summary>
        /// Nendo
        /// </summary>
        public string Nendo { get; set; }

        /// <summary>
        /// DateTime Now
        /// </summary>
        public DateTime Now { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IInsertJinendoGaikenStep7BLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/04  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IInsertJinendoGaikenStep7BLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： InsertJinendoGaikenStep7BLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/04  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class InsertJinendoGaikenStep7BLOutput : IInsertJinendoGaikenStep7BLOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： InsertJinendoGaikenStep7BusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/04  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class InsertJinendoGaikenStep7BusinessLogic : BaseBusinessLogic<IInsertJinendoGaikenStep7BLInput, IInsertJinendoGaikenStep7BLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： InsertJinendoGaikenStep7BusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public InsertJinendoGaikenStep7BusinessLogic()
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
        /// 2014/12/04  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IInsertJinendoGaikenStep7BLOutput Execute(IInsertJinendoGaikenStep7BLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IInsertJinendoGaikenStep7BLOutput output = new InsertJinendoGaikenStep7BLOutput();

            try
            {
                new InsertJinendoGaikenStep7DataAccess().Execute(input);
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
