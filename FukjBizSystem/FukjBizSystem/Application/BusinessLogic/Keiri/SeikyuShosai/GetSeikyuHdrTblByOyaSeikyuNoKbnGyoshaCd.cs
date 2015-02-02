using System.Reflection;
using FukjBizSystem.Application.DataAccess.SeikyuHdrTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.SeikyuShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSeikyuHdrTblByOyaSeikyuNoKbnGyoshaCdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/24　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSeikyuHdrTblByOyaSeikyuNoKbnGyoshaCdBLInput : ISelectSeikyuHdrTblByOyaSeikyuNoKbnGyoshaCdDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSeikyuHdrTblByOyaSeikyuNoKbnGyoshaCdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/24　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSeikyuHdrTblByOyaSeikyuNoKbnGyoshaCdBLInput : IGetSeikyuHdrTblByOyaSeikyuNoKbnGyoshaCdBLInput
    {
        /// <summary>
        /// 親請求No
        /// </summary>
        public string OyaSeikyuNo { get; set; }

        /// <summary>
        /// 請求先区分
        /// </summary>
        public string SeikyusakiKbn { get; set; }

        /// <summary>
        /// 業者コード
        /// </summary>
        public string SeikyuGyosyaCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSeikyuHdrTblByOyaSeikyuNoKbnGyoshaCdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/24　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSeikyuHdrTblByOyaSeikyuNoKbnGyoshaCdBLOutput : ISelectSeikyuHdrTblByOyaSeikyuNoKbnGyoshaCdDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSeikyuHdrTblByOyaSeikyuNoKbnGyoshaCdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/24　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSeikyuHdrTblByOyaSeikyuNoKbnGyoshaCdBLOutput : IGetSeikyuHdrTblByOyaSeikyuNoKbnGyoshaCdBLOutput
    {
        /// <summary>
        /// SeikyuHdrTblDataTable
        /// </summary>
        public SeikyuHdrTblDataSet.SeikyuHdrTblDataTable SeikyuHdrTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSeikyuHdrTblByOyaSeikyuNoKbnGyoshaCdBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/24　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSeikyuHdrTblByOyaSeikyuNoKbnGyoshaCdBusinessLogic : BaseBusinessLogic<IGetSeikyuHdrTblByOyaSeikyuNoKbnGyoshaCdBLInput, IGetSeikyuHdrTblByOyaSeikyuNoKbnGyoshaCdBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetSeikyuHdrTblByOyaSeikyuNoKbnGyoshaCdBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/24　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetSeikyuHdrTblByOyaSeikyuNoKbnGyoshaCdBusinessLogic()
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
        /// 2014/12/24　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetSeikyuHdrTblByOyaSeikyuNoKbnGyoshaCdBLOutput Execute(IGetSeikyuHdrTblByOyaSeikyuNoKbnGyoshaCdBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetSeikyuHdrTblByOyaSeikyuNoKbnGyoshaCdBLOutput output = new GetSeikyuHdrTblByOyaSeikyuNoKbnGyoshaCdBLOutput();

            try
            {
                output.SeikyuHdrTblDT = new SelectSeikyuHdrTblByOyaSeikyuNoKbnGyoshaCdDataAccess().Execute(input).SeikyuHdrTblDT;
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
