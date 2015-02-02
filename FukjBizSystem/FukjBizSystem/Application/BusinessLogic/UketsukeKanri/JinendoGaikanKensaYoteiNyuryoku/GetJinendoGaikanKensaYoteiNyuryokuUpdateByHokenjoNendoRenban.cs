using System.Reflection;
using FukjBizSystem.Application.DataAccess.JinendoGaikanYoteiOutputTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.UketsukeKanri.JinendoGaikanKensaYoteiNyuryoku
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/25　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanBLInput : ISelectJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/25　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanBLInput : IGetJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanBLInput
    {
        /// <summary>
        /// 浄化槽台帳保健所コード
        /// </summary>
        public string JokasoHokenjoCd { get; set; }

        /// <summary>
        /// 浄化槽台帳年度
        /// </summary>
        public string JokasoTorokuNendo { get; set; }

        /// <summary>
        /// 浄化槽台帳連番
        /// </summary>
        public string JokasoRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/25　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanBLOutput : ISelectJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/25　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanBLOutput : IGetJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanBLOutput
    {
        /// <summary>
        /// JinendoGaikanKensaYoteiNyuryokuUpdateDataTable
        /// </summary>
        public JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanKensaYoteiNyuryokuUpdateDataTable JinendoGaikanKensaYoteiNyuryokuUpdateDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/25　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanBusinessLogic : BaseBusinessLogic<IGetJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanBLInput, IGetJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/25　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanBusinessLogic()
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
        /// 2014/11/25　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanBLOutput Execute(IGetJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanBLOutput output = new GetJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanBLOutput();

            try
            {
                output.JinendoGaikanKensaYoteiNyuryokuUpdateDataTable = new SelectJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanDataAccess().Execute(input).JinendoGaikanKensaYoteiNyuryokuUpdateDataTable;
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
