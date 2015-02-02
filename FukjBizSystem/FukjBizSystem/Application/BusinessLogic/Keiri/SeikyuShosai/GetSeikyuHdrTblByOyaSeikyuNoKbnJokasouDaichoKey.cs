using System.Reflection;
using FukjBizSystem.Application.DataAccess.SeikyuHdrTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.SeikyuShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyBLInput
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
    interface IGetSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyBLInput : ISelectSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyBLInput
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
    class GetSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyBLInput : IGetSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyBLInput
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
        /// 浄化槽保健所コード
        /// </summary>
        public string JokasoHokenjoCd { get; set; }

        /// <summary>
        /// 浄化槽台帳登録年度
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
    //  インターフェイス名 ： IGetSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyBLOutput
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
    interface IGetSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyBLOutput : ISelectSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyBLOutput
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
    class GetSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyBLOutput : IGetSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyBLOutput
    {
        /// <summary>
        /// SeikyuHdrTblDataTable
        /// </summary>
        public SeikyuHdrTblDataSet.SeikyuHdrTblDataTable SeikyuHdrTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyBusinessLogic
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
    class GetSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyBusinessLogic : BaseBusinessLogic<IGetSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyBLInput, IGetSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyBusinessLogic
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
        public GetSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyBusinessLogic()
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
        public override IGetSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyBLOutput Execute(IGetSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyBLOutput output = new GetSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyBLOutput();

            try
            {
                output.SeikyuHdrTblDT = new SelectSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyDataAccess().Execute(input).SeikyuHdrTblDT;
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
