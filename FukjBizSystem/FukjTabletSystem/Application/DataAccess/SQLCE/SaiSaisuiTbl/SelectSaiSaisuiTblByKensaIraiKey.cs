using System;
using System.Reflection;
using FukjTabletSystem.Application.DataAccess.SQLCE.KensaKekkaTbl;
using FukjTabletSystem.Application.DataSet.SQLCE;
using FukjTabletSystem.Application.DataSet.SQLCE.SaiSaisuiTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.DataAccess.SQLCE.SaiSaisuiTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectSaiSaisuiTblByKensaIraiKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectSaiSaisuiTblByKensaIraiKeyDAInput
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
    //  クラス名 ： SelectSaiSaisuiTblByKensaIraiKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSaiSaisuiTblByKensaIraiKeyDAInput : ISelectSaiSaisuiTblByKensaIraiKeyDAInput
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
    //  インターフェイス名 ： ISelectSaiSaisuiTblByKensaIraiKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectSaiSaisuiTblByKensaIraiKeyDAOutput
    {
        /// <summary>
        /// SaiSaisuiTblByKensaIraiKeyDataTable
        /// </summary>
        SaiSaisuiTblDataSet.SaiSaisuiTblByKensaIraiKeyDataTable SaiSaisuiTbl { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSaiSaisuiTblByKensaIraiKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSaiSaisuiTblByKensaIraiKeyDAOutput : ISelectSaiSaisuiTblByKensaIraiKeyDAOutput
    {
        /// <summary>
        /// SaiSaisuiTblByKensaIraiKeyDataTable
        /// </summary>
        public SaiSaisuiTblDataSet.SaiSaisuiTblByKensaIraiKeyDataTable SaiSaisuiTbl { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSaiSaisuiTblByKensaIraiKeyDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSaiSaisuiTblByKensaIraiKeyDataAccess : BaseDataAccessCe<ISelectSaiSaisuiTblByKensaIraiKeyDAInput, ISelectSaiSaisuiTblByKensaIraiKeyDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private SaiSaisuiTblByKensaIraiKeyTableAdapter tableAdapter = new SaiSaisuiTblByKensaIraiKeyTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectSaiSaisuiTblByKensaIraiKeyDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/20　戸口　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectSaiSaisuiTblByKensaIraiKeyDataAccess()
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
        /// 2014/11/20　戸口　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectSaiSaisuiTblByKensaIraiKeyDAOutput Execute(ISelectSaiSaisuiTblByKensaIraiKeyDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectSaiSaisuiTblByKensaIraiKeyDAOutput output = new SelectSaiSaisuiTblByKensaIraiKeyDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.SaiSaisuiTbl = tableAdapter.GetDataByKensaIraiKey(input.IraiHoteiKbn, input.IraiHokenjoCd, input.IraiNendo, input.IraiRenban);

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
