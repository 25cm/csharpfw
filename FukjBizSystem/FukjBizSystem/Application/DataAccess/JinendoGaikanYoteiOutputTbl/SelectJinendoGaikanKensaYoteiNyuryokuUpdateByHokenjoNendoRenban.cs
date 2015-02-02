using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.JinendoGaikanYoteiOutputTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.JinendoGaikanYoteiOutputTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanDAInput
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
    interface ISelectJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanDAInput
    {
        /// <summary>
        /// 浄化槽台帳保健所コード
        /// </summary>
        string JokasoHokenjoCd { get; set; }

        /// <summary>
        /// 浄化槽台帳年度
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
    //  クラス名 ： SelectJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanDAInput
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
    class SelectJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanDAInput : ISelectJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanDAInput
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
    //  インターフェイス名 ： ISelectJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanDAOutput
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
    interface ISelectJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanDAOutput
    {
        /// <summary>
        /// JinendoGaikanKensaYoteiNyuryokuUpdateDataTable
        /// </summary>
        JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanKensaYoteiNyuryokuUpdateDataTable JinendoGaikanKensaYoteiNyuryokuUpdateDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanDAOutput
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
    class SelectJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanDAOutput : ISelectJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanDAOutput
    {
        /// <summary>
        /// JinendoGaikanKensaYoteiNyuryokuUpdateDataTable
        /// </summary>
        public JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanKensaYoteiNyuryokuUpdateDataTable JinendoGaikanKensaYoteiNyuryokuUpdateDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanDataAccess
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
    class SelectJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanDataAccess : BaseDataAccess<ISelectJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanDAInput, ISelectJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private JinendoGaikanKensaYoteiNyuryokuUpdateTableAdapter tableAdapter
            = new JinendoGaikanKensaYoteiNyuryokuUpdateTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanDataAccess
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
        public SelectJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanDataAccess()
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
        public override ISelectJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanDAOutput Execute(ISelectJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanDAOutput output = new SelectJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.JinendoGaikanKensaYoteiNyuryokuUpdateDataTable = tableAdapter.GetDataByHokenjoNendoRenban(input.JokasoHokenjoCd, input.JokasoTorokuNendo, input.JokasoRenban);

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
