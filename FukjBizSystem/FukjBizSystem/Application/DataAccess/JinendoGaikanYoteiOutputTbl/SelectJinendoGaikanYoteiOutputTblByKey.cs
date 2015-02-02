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
    //  インターフェイス名 ： ISelectJinendoGaikanYoteiOutputTblByKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectJinendoGaikanYoteiOutputTblByKeyDAInput
    {
        /// <summary>
        /// 年度
        /// </summary>
        string Nendo { get; set; }

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
    //  クラス名 ： SelectJinendoGaikanYoteiOutputTblByKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJinendoGaikanYoteiOutputTblByKeyDAInput : ISelectJinendoGaikanYoteiOutputTblByKeyDAInput
    {
        /// <summary>
        /// 年度
        /// </summary>
        public string Nendo { get; set; }

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
    //  インターフェイス名 ： ISelectJinendoGaikanYoteiOutputTblByKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectJinendoGaikanYoteiOutputTblByKeyDAOutput
    {
        /// <summary>
        /// 次年度外観検査予定出力テーブル 
        /// </summary>
        JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanYoteiOutputTblDataTable JinendoGaikanYoteiOutputTblDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJinendoGaikanYoteiOutputTblByKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJinendoGaikanYoteiOutputTblByKeyDAOutput : ISelectJinendoGaikanYoteiOutputTblByKeyDAOutput
    {
        /// <summary>
        /// 次年度外観検査予定出力テーブル 
        /// </summary>
        public JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanYoteiOutputTblDataTable JinendoGaikanYoteiOutputTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJinendoGaikanYoteiOutputTblByKeyDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJinendoGaikanYoteiOutputTblByKeyDataAccess : BaseDataAccess<ISelectJinendoGaikanYoteiOutputTblByKeyDAInput, ISelectJinendoGaikanYoteiOutputTblByKeyDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private JinendoGaikanYoteiOutputTblTableAdapter tableAdapter = new JinendoGaikanYoteiOutputTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectJinendoGaikanYoteiOutputTblByKeyDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/20  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectJinendoGaikanYoteiOutputTblByKeyDataAccess()
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
        /// 2014/11/20  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectJinendoGaikanYoteiOutputTblByKeyDAOutput Execute(ISelectJinendoGaikanYoteiOutputTblByKeyDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectJinendoGaikanYoteiOutputTblByKeyDAOutput output = new SelectJinendoGaikanYoteiOutputTblByKeyDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.JinendoGaikanYoteiOutputTblDT = tableAdapter.GetDataByKey(   input.Nendo,
                                                                                    input.JokasoHokenjoCd,
                                                                                    input.JokasoTorokuNendo,
                                                                                    input.JokasoRenban  );

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
