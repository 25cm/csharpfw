using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.SeikyuHdrTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.SeikyuHdrTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyDAInput
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
    interface ISelectSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyDAInput
    {
        /// <summary>
        /// 親請求No
        /// </summary>
        string OyaSeikyuNo { get; set; }

        /// <summary>
        /// 請求先区分
        /// </summary>
        string SeikyusakiKbn { get; set; }

        /// <summary>
        /// 浄化槽保健所コード
        /// </summary>
        string JokasoHokenjoCd { get; set; }

        /// <summary>
        /// 浄化槽台帳登録年度
        /// </summary>
        string JokasoTorokuNendo { get; set; }

        /// <summary>
        /// 浄化槽台帳連番
        /// </summary>
        string JokasoRenban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyDAInput
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
    class SelectSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyDAInput : ISelectSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyDAInput
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
    //  インターフェイス名 ： ISelectSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyDAOutput
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
    interface ISelectSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyDAOutput
    {
        /// <summary>
        /// SeikyuHdrTblDataTable
        /// </summary>
        SeikyuHdrTblDataSet.SeikyuHdrTblDataTable SeikyuHdrTblDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyDAOutput
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
    class SelectSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyDAOutput : ISelectSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyDAOutput
    {
        /// <summary>
        /// SeikyuHdrTblDataTable
        /// </summary>
        public SeikyuHdrTblDataSet.SeikyuHdrTblDataTable SeikyuHdrTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyDataAccess
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
    class SelectSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyDataAccess : BaseDataAccess<ISelectSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyDAInput, ISelectSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private SeikyuHdrTblTableAdapter tableAdapter = new SeikyuHdrTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyDataAccess
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
        public SelectSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyDataAccess()
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
        public override ISelectSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyDAOutput Execute(ISelectSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyDAOutput output = new SelectSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.SeikyuHdrTblDT = tableAdapter.GetDataByOyaSeikyuNoKbnJokasoDaichoKey(input.OyaSeikyuNo, input.SeikyusakiKbn, input.JokasoHokenjoCd, input.JokasoTorokuNendo, input.JokasoRenban);

            }
            catch (Exception e)
            {
                // トレースログ出力
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("エラー内容:{0}", e.Message));

                // ＤＢエラー
                throw new CustomException(ResultCode.DBError, string.Format("エラー内容:{0}", e.Message));
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
