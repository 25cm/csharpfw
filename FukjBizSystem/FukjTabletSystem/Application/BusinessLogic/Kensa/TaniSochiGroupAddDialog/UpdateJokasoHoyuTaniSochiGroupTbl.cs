using System.Reflection;
using FukjTabletSystem.Application.DataAccess.SQLCE.JokasoHoyuTaniSochiGroupTbl;
using FukjTabletSystem.Application.DataSet.SQLCE;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.BusinessLogic.Kensa.TaniSochiGroupAddDialog
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateJokasoHoyuTaniSochiGroupTblBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateJokasoHoyuTaniSochiGroupTblBLInput : IUpdateJokasoHoyuTaniSochiGroupTblDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateJokasoHoyuTaniSochiGroupTblBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateJokasoHoyuTaniSochiGroupTblBLInput : IUpdateJokasoHoyuTaniSochiGroupTblBLInput
    {
        /// <summary>
        /// JokasoHoyuTaniSochiGroupTbl
        /// </summary>
        public JokasoHoyuTaniSochiGroupTblDataSet.JokasoHoyuTaniSochiGroupTblDataTable JokasoHoyuTaniSochiGroupTbl { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateJokasoHoyuTaniSochiGroupTblBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateJokasoHoyuTaniSochiGroupTblBLOutput : IUpdateJokasoHoyuTaniSochiGroupTblDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateJokasoHoyuTaniSochiGroupTblBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateJokasoHoyuTaniSochiGroupTblBLOutput : IUpdateJokasoHoyuTaniSochiGroupTblBLOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateJokasoHoyuTaniSochiGroupTblBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateJokasoHoyuTaniSochiGroupTblBusinessLogic : BaseBusinessLogic<IUpdateJokasoHoyuTaniSochiGroupTblBLInput, IUpdateJokasoHoyuTaniSochiGroupTblBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： UpdateJokasoHoyuTaniSochiGroupTblBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public UpdateJokasoHoyuTaniSochiGroupTblBusinessLogic()
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
        /// 2014/11/17　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IUpdateJokasoHoyuTaniSochiGroupTblBLOutput Execute(IUpdateJokasoHoyuTaniSochiGroupTblBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdateJokasoHoyuTaniSochiGroupTblBLOutput output = new UpdateJokasoHoyuTaniSochiGroupTblBLOutput();

            try
            {
                new UpdateJokasoHoyuTaniSochiGroupTblDataAccess().Execute(input);
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
