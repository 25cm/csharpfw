using System.Reflection;
using FukjBizSystem.Application.DataAccess.KensaIraiTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaNippoInput
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaIraiEditCheckByYoteiDtTantoshaCdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/12　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaIraiEditCheckByYoteiDtTantoshaCdBLInput : ISelectKensaIraiEditCheckByYoteiDtTantoshaCdDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaIraiEditCheckByYoteiDtTantoshaCdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/12　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaIraiEditCheckByYoteiDtTantoshaCdBLInput : IGetKensaIraiEditCheckByYoteiDtTantoshaCdBLInput
    {
        /// <summary>
        /// 検査予定年/検査予定月/検査予定日
        /// </summary>
        public string YoteiDt { get; set; }

        /// <summary>
        /// 外観検査担当者コード
        /// </summary>
        public string KensaIraiKensaTantoshaCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaIraiEditCheckByYoteiDtTantoshaCdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/12　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaIraiEditCheckByYoteiDtTantoshaCdBLOutput : ISelectKensaIraiEditCheckByYoteiDtTantoshaCdDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaIraiEditCheckByYoteiDtTantoshaCdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/12　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaIraiEditCheckByYoteiDtTantoshaCdBLOutput : IGetKensaIraiEditCheckByYoteiDtTantoshaCdBLOutput
    {
        /// <summary>
        /// KensaIraiEditCheckDataTable
        /// </summary>
        public KensaIraiTblDataSet.KensaIraiEditCheckDataTable KensaIraiEditCheckDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaIraiEditCheckByYoteiDtTantoshaCdBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/12　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaIraiEditCheckByYoteiDtTantoshaCdBusinessLogic : BaseBusinessLogic<IGetKensaIraiEditCheckByYoteiDtTantoshaCdBLInput, IGetKensaIraiEditCheckByYoteiDtTantoshaCdBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKensaIraiEditCheckByYoteiDtTantoshaCdBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/12　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKensaIraiEditCheckByYoteiDtTantoshaCdBusinessLogic()
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
        /// 2014/11/12　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKensaIraiEditCheckByYoteiDtTantoshaCdBLOutput Execute(IGetKensaIraiEditCheckByYoteiDtTantoshaCdBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKensaIraiEditCheckByYoteiDtTantoshaCdBLOutput output = new GetKensaIraiEditCheckByYoteiDtTantoshaCdBLOutput();

            try
            {
                ISelectKensaIraiEditCheckByYoteiDtTantoshaCdDAOutput daOutput = new SelectKensaIraiEditCheckByYoteiDtTantoshaCdDataAccess().Execute(input);
                output.KensaIraiEditCheckDataTable = daOutput.KensaIraiEditCheckDataTable;
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
