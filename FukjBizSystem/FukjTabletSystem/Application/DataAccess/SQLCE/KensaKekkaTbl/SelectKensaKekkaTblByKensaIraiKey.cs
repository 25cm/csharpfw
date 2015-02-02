using System;
using System.Reflection;
using FukjTabletSystem.Application.DataSet.SQLCE;
using FukjTabletSystem.Application.DataSet.SQLCE.KensaKekkaTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.DataAccess.SQLCE.KensaKekkaTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaKekkaTblByKensaIraiKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/18　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaKekkaTblByKensaIraiKeyDAInput
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
    //  クラス名 ： SelectKensaKekkaTblByKensaIraiKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/18　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaKekkaTblByKensaIraiKeyDAInput : ISelectKensaKekkaTblByKensaIraiKeyDAInput
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
    //  インターフェイス名 ： ISelectKensaKekkaTblByKensaIraiKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/18　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaKekkaTblByKensaIraiKeyDAOutput
    {
        /// <summary>
        /// KensaKekkaTblByKensaIraiKeyDataTable
        /// </summary>
        KensaKekkaTblDataSet.KensaKekkaTblByKensaIraiKeyDataTable KensaKekkaTbl { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaKekkaTblByKensaIraiKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/18　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaKekkaTblByKensaIraiKeyDAOutput : ISelectKensaKekkaTblByKensaIraiKeyDAOutput
    {
        /// <summary>
        /// KensaKekkaTblDataTable
        /// </summary>
        public KensaKekkaTblDataSet.KensaKekkaTblByKensaIraiKeyDataTable KensaKekkaTbl { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaKekkaTblByKensaIraiKeyDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/18　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaKekkaTblByKensaIraiKeyDataAccess : BaseDataAccessCe<ISelectKensaKekkaTblByKensaIraiKeyDAInput, ISelectKensaKekkaTblByKensaIraiKeyDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KensaKekkaTblByKensaIraiKeyTableAdapter tableAdapter = new KensaKekkaTblByKensaIraiKeyTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKensaKekkaTblByKensaIraiKeyDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/18　戸口　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKensaKekkaTblByKensaIraiKeyDataAccess()
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
        /// 2014/11/18　戸口　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKensaKekkaTblByKensaIraiKeyDAOutput Execute(ISelectKensaKekkaTblByKensaIraiKeyDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKensaKekkaTblByKensaIraiKeyDAOutput output = new SelectKensaKekkaTblByKensaIraiKeyDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KensaKekkaTbl = tableAdapter.GetDataKensaKekkaByKensaIraiKey(input.IraiHoteiKbn, input.IraiHokenjoCd, input.IraiNendo, input.IraiRenban);

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
