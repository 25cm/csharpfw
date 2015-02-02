using System;
using System.Reflection;
using FukjTabletSystem.Application.DataSet.SQLCE;
using FukjTabletSystem.Application.DataSet.SQLCE.KatashikiBetsuTaniSochiMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.DataAccess.SQLCE.KatashikiBetsuTaniSochiMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKatashikiBetsuTaniSochiMstByShokenBitMaskAndKensaIraiKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/30　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKatashikiBetsuTaniSochiMstByShokenBitMaskAndKensaIraiKeyDAInput
    {
        /// <summary>
        /// ShokenTaishoKensaBitMask
        /// </summary>
        int ShokenTaishoKensaBitMask { get; set; }

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
    //  クラス名 ： SelectKatashikiBetsuTaniSochiMstByShokenBitMaskAndKensaIraiKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/30　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKatashikiBetsuTaniSochiMstByShokenBitMaskAndKensaIraiKeyDAInput : ISelectKatashikiBetsuTaniSochiMstByShokenBitMaskAndKensaIraiKeyDAInput
    {
        /// <summary>
        /// ShokenTaishoKensaBitMask
        /// </summary>
        public int ShokenTaishoKensaBitMask { get; set; }

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
    //  インターフェイス名 ： ISelectKatashikiBetsuTaniSochiMstByShokenBitMaskAndKensaIraiKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/30　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKatashikiBetsuTaniSochiMstByShokenBitMaskAndKensaIraiKeyDAOutput
    {
        /// <summary>
        /// KatashikiBetsuTaniSochiMstDataTable
        /// </summary>
        KatashikiBetsuTaniSochiMstDataSet.KatashikiBetsuTaniSochiMstDataTable KatashikiBetsuTaniSochiMst { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKatashikiBetsuTaniSochiMstByShokenBitMaskAndKensaIraiKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/30　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKatashikiBetsuTaniSochiMstByShokenBitMaskAndKensaIraiKeyDAOutput : ISelectKatashikiBetsuTaniSochiMstByShokenBitMaskAndKensaIraiKeyDAOutput
    {
        /// <summary>
        /// KatashikiBetsuTaniSochiMstDataTable
        /// </summary>
        public KatashikiBetsuTaniSochiMstDataSet.KatashikiBetsuTaniSochiMstDataTable KatashikiBetsuTaniSochiMst { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKatashikiBetsuTaniSochiMstByShokenBitMaskAndKensaIraiKeyDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/30　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKatashikiBetsuTaniSochiMstByShokenBitMaskAndKensaIraiKeyDataAccess : BaseDataAccessCe<ISelectKatashikiBetsuTaniSochiMstByShokenBitMaskAndKensaIraiKeyDAInput, ISelectKatashikiBetsuTaniSochiMstByShokenBitMaskAndKensaIraiKeyDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KatashikiBetsuTaniSochiMstTableAdapter tableAdapter = new KatashikiBetsuTaniSochiMstTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKatashikiBetsuTaniSochiMstByShokenBitMaskAndKensaIraiKeyDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/30　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKatashikiBetsuTaniSochiMstByShokenBitMaskAndKensaIraiKeyDataAccess()
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
        /// 2014/12/30　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKatashikiBetsuTaniSochiMstByShokenBitMaskAndKensaIraiKeyDAOutput Execute(ISelectKatashikiBetsuTaniSochiMstByShokenBitMaskAndKensaIraiKeyDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKatashikiBetsuTaniSochiMstByShokenBitMaskAndKensaIraiKeyDAOutput output = new SelectKatashikiBetsuTaniSochiMstByShokenBitMaskAndKensaIraiKeyDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KatashikiBetsuTaniSochiMst = tableAdapter.GetDataByShokenBitMaskAndKensaIraiKey(input.IraiHoteiKbn, input.IraiHokenjoCd, input.IraiNendo, input.IraiRenban, input.ShokenTaishoKensaBitMask);

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
