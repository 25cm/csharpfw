using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.GaikanKensaKekkaTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.GaikanKensaKekkaTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectShokenKekkaHosokuListByKensaIraiDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/15　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectShokenKekkaHosokuListByKensaIraiDAInput
    {
        /// <summary>
        /// IraiHoteiKbn
        /// </summary>
        string IraiHoteiKbn { get; set; }

        /// <summary>
        /// IraiHokenjoCd
        /// </summary>
        string IraiHokenjoCd { get; set; }

        /// <summary>
        /// IraiNendo
        /// </summary>
        string IraiNendo { get; set; }

        /// <summary>
        /// IraiRenban
        /// </summary>
        string IraiRenban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectShokenKekkaHosokuListByKensaIraiDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/15　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectShokenKekkaHosokuListByKensaIraiDAInput : ISelectShokenKekkaHosokuListByKensaIraiDAInput
    {
        /// <summary>
        /// IraiHoteiKbn
        /// </summary>
        public string IraiHoteiKbn { get; set; }

        /// <summary>
        /// IraiHokenjoCd
        /// </summary>
        public string IraiHokenjoCd { get; set; }

        /// <summary>
        /// IraiNendo
        /// </summary>
        public string IraiNendo { get; set; }

        /// <summary>
        /// IraiRenban
        /// </summary>
        public string IraiRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectShokenKekkaHosokuListByKensaIraiDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/15　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectShokenKekkaHosokuListByKensaIraiDAOutput
    {
        /// <summary>
        /// ShokenKekkaHosokuListDataTable
        /// </summary>
        GaikanKensaKekkaTblDataSet.ShokenKekkaHosokuListDataTable ShokenKekkaHosokuList { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectShokenKekkaHosokuListByKensaIraiDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/15　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectShokenKekkaHosokuListByKensaIraiDAOutput : ISelectShokenKekkaHosokuListByKensaIraiDAOutput
    {
        /// <summary>
        /// ShokenKekkaHosokuListDataTable
        /// </summary>
        public GaikanKensaKekkaTblDataSet.ShokenKekkaHosokuListDataTable ShokenKekkaHosokuList { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectShokenKekkaHosokuListByKensaIraiDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/15　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectShokenKekkaHosokuListByKensaIraiDataAccess : BaseDataAccess<ISelectShokenKekkaHosokuListByKensaIraiDAInput, ISelectShokenKekkaHosokuListByKensaIraiDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private ShokenKekkaHosokuListTableAdapter tableAdapter = new ShokenKekkaHosokuListTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectShokenKekkaHosokuListByKensaIraiDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/15　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectShokenKekkaHosokuListByKensaIraiDataAccess()
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
        /// 2014/12/15　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectShokenKekkaHosokuListByKensaIraiDAOutput Execute(ISelectShokenKekkaHosokuListByKensaIraiDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectShokenKekkaHosokuListByKensaIraiDAOutput output = new SelectShokenKekkaHosokuListByKensaIraiDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.ShokenKekkaHosokuList = tableAdapter.GetData(input.IraiHoteiKbn, input.IraiHokenjoCd, input.IraiNendo, input.IraiRenban);

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
