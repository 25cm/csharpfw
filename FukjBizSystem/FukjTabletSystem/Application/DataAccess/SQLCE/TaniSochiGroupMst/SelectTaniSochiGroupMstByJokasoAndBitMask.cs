using System;
using System.Reflection;
using FukjTabletSystem.Application.DataSet.SQLCE;
using FukjTabletSystem.Application.DataSet.SQLCE.TaniSochiGroupMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.DataAccess.SQLCE.TaniSochiGroupMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectTaniSochiGroupMstByJokasoAndBitMaskDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/15　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectTaniSochiGroupMstByJokasoAndBitMaskDAInput
    {
        /// <summary>
        /// ShokenTaishoKensaBitMask
        /// </summary>
        int ShokenTaishoKensaBitMask { get; set; }

        /// <summary>
        /// JokasoHokenjoCd
        /// </summary>
        string JokasoHokenjoCd { get; set; }

        /// <summary>
        /// JokasoTorokuNendo
        /// </summary>
        string JokasoTorokuNendo { get; set; }

        /// <summary>
        /// JokasoRenban
        /// </summary>
        string JokasoRenban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectTaniSochiGroupMstByJokasoAndBitMaskDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/15　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectTaniSochiGroupMstByJokasoAndBitMaskDAInput : ISelectTaniSochiGroupMstByJokasoAndBitMaskDAInput
    {
        /// <summary>
        /// ShokenTaishoKensaBitMask
        /// </summary>
        public int ShokenTaishoKensaBitMask { get; set; }

        /// <summary>
        /// JokasoHokenjoCd
        /// </summary>
        public string JokasoHokenjoCd { get; set; }

        /// <summary>
        /// JokasoTorokuNendo
        /// </summary>
        public string JokasoTorokuNendo { get; set; }

        /// <summary>
        /// JokasoRenban
        /// </summary>
        public string JokasoRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectTaniSochiGroupMstByJokasoAndBitMaskDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/15　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectTaniSochiGroupMstByJokasoAndBitMaskDAOutput
    {
        /// <summary>
        /// TaniSochiGroupMstDataTable
        /// </summary>
        TaniSochiGroupMstDataSet.TaniSochiGroupMstDataTable TaniSochiGroupMst { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectTaniSochiGroupMstByJokasoAndBitMaskDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/15　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectTaniSochiGroupMstByJokasoAndBitMaskDAOutput : ISelectTaniSochiGroupMstByJokasoAndBitMaskDAOutput
    {
        /// <summary>
        /// TaniSochiGroupMstDataTable
        /// </summary>
        public TaniSochiGroupMstDataSet.TaniSochiGroupMstDataTable TaniSochiGroupMst { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectTaniSochiGroupMstByJokasoAndBitMaskDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/15　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectTaniSochiGroupMstByJokasoAndBitMaskDataAccess : BaseDataAccessCe<ISelectTaniSochiGroupMstByJokasoAndBitMaskDAInput, ISelectTaniSochiGroupMstByJokasoAndBitMaskDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private TaniSochiGroupMstTableAdapter tableAdapter = new TaniSochiGroupMstTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectTaniSochiGroupMstByJokasoAndBitMaskDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/15　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectTaniSochiGroupMstByJokasoAndBitMaskDataAccess()
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
        /// 2014/11/15　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectTaniSochiGroupMstByJokasoAndBitMaskDAOutput Execute(ISelectTaniSochiGroupMstByJokasoAndBitMaskDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectTaniSochiGroupMstByJokasoAndBitMaskDAOutput output = new SelectTaniSochiGroupMstByJokasoAndBitMaskDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.TaniSochiGroupMst = tableAdapter.GetDataByJokasoAndBitMask(input.JokasoHokenjoCd, input.JokasoTorokuNendo, input.JokasoRenban, input.ShokenTaishoKensaBitMask);

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
