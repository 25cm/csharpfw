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
    //  インターフェイス名 ： ISelectLastKensaKekkaTblByKensaIraiKeyDAInput
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
    interface ISelectLastKensaKekkaTblByKensaIraiKeyDAInput
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
    //  クラス名 ： SelectLastKensaKekkaTblByKensaIraiKeyDAInput
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
    class SelectLastKensaKekkaTblByKensaIraiKeyDAInput : ISelectLastKensaKekkaTblByKensaIraiKeyDAInput
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
    //  インターフェイス名 ： ISelectLastKensaKekkaTblByKensaIraiKeyDAOutput
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
    interface ISelectLastKensaKekkaTblByKensaIraiKeyDAOutput
    {
        /// <summary>
        /// KensaKekkaTblByKensaIraiKeyDataTable
        /// </summary>
        KensaKekkaTblDataSet.KensaKekkaTblByKensaIraiKeyDataTable LastKensaKekkaTbl { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectLastKensaKekkaTblByKensaIraiKeyDAOutput
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
    class SelectLastKensaKekkaTblByKensaIraiKeyDAOutput : ISelectLastKensaKekkaTblByKensaIraiKeyDAOutput
    {
        /// <summary>
        /// KensaKekkaTblDataTable
        /// </summary>
        public KensaKekkaTblDataSet.KensaKekkaTblByKensaIraiKeyDataTable LastKensaKekkaTbl { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectLastKensaKekkaTblByKensaIraiKeyDataAccess
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
    class SelectLastKensaKekkaTblByKensaIraiKeyDataAccess : BaseDataAccessCe<ISelectLastKensaKekkaTblByKensaIraiKeyDAInput, ISelectLastKensaKekkaTblByKensaIraiKeyDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KensaKekkaTblByKensaIraiKeyTableAdapter tableAdapter = new KensaKekkaTblByKensaIraiKeyTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectLastKensaKekkaTblByKensaIraiKeyDataAccess
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
        public SelectLastKensaKekkaTblByKensaIraiKeyDataAccess()
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
        public override ISelectLastKensaKekkaTblByKensaIraiKeyDAOutput Execute(ISelectLastKensaKekkaTblByKensaIraiKeyDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectLastKensaKekkaTblByKensaIraiKeyDAOutput output = new SelectLastKensaKekkaTblByKensaIraiKeyDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                // 履歴に紐づく検査結果データが、依頼年、月、日の降順で取得される。（１行目が履歴上で直近の検査結果となる）
                output.LastKensaKekkaTbl = tableAdapter.GetLastKensaKekkaDataByKensaIraiKey(input.IraiHoteiKbn, input.IraiHokenjoCd, input.IraiNendo, input.IraiRenban);

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
