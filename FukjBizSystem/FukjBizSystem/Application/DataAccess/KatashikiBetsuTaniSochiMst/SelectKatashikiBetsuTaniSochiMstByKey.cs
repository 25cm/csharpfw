using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KatashikiBetsuTaniSochiMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KatashikiBetsuTaniSochiMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKatashikiBetsuTaniSochiMstByKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/11  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKatashikiBetsuTaniSochiMstByKeyDAInput
    {
        /// <summary>
        /// メーカー業者コード
        /// </summary>
        String KatashikiMakerCd { get; set; }

        /// <summary>
        /// 型式コード
        /// </summary>
        String KatashikiCd { get; set; }

        // DEL 20140731 START ZynasSou
        ///// <summary>
        ///// 単位装置コード
        ///// </summary>
        //String TaniSochiCd { get; set; }
        // DEL 20140731 END ZynasSou

        // ADD 20140731 START ZynasSou
        /// <summary>
        /// 単位装置グループコード
        /// </summary>
        String TaniSochiGroupCd { get; set; }
        // ADD 20140731 END ZynasSou

        // ADD 20140731 START ZynasSou
        /// <summary>
        /// 単位装置名
        /// </summary>
        String TaniSochiNm { get; set; }
        // ADD 20140731 END ZynasSou
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKatashikiBetsuTaniSochiMstByKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/11  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKatashikiBetsuTaniSochiMstByKeyDAInput : ISelectKatashikiBetsuTaniSochiMstByKeyDAInput
    {
        /// <summary>
        /// メーカー業者コード
        /// </summary>
        public String KatashikiMakerCd { get; set; }

        /// <summary>
        /// 型式コード
        /// </summary>
        public String KatashikiCd { get; set; }

        // DEL 20140731 START ZynasSou
        ///// <summary>
        ///// 単位装置コード
        ///// </summary>
        //public String TaniSochiCd { get; set; }
        // DEL 20140731 END ZynasSou

        // ADD 20140731 START ZynasSou
        /// <summary>
        /// 単位装置グループコード
        /// </summary>
        public String TaniSochiGroupCd { get; set; }
        // ADD 20140731 END ZynasSou

        // ADD 20140731 START ZynasSou
        /// <summary>
        /// 単位装置名
        /// </summary>
        public String TaniSochiNm { get; set; }
        // ADD 20140731 END ZynasSou
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKatashikiBetsuTaniSochiMstByKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/11  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKatashikiBetsuTaniSochiMstByKeyDAOutput
    {
        /// <summary>
        /// KatashikiBetsuTaniSochiMstDataTable
        /// </summary>
        KatashikiBetsuTaniSochiMstDataSet.KatashikiBetsuTaniSochiMstDataTable KatashikiBetsuTaniSochiMstDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKatashikiBetsuTaniSochiMstByKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/11  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKatashikiBetsuTaniSochiMstByKeyDAOutput : ISelectKatashikiBetsuTaniSochiMstByKeyDAOutput
    {
        /// <summary>
        /// KatashikiBetsuTaniSochiMstDataTable
        /// </summary>
        public KatashikiBetsuTaniSochiMstDataSet.KatashikiBetsuTaniSochiMstDataTable KatashikiBetsuTaniSochiMstDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKatashikiBetsuTaniSochiMstByKeyDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/11  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKatashikiBetsuTaniSochiMstByKeyDataAccess : BaseDataAccess<ISelectKatashikiBetsuTaniSochiMstByKeyDAInput, ISelectKatashikiBetsuTaniSochiMstByKeyDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KatashikiBetsuTaniSochiMstTableAdapter tableAdapter = new KatashikiBetsuTaniSochiMstTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKatashikiBetsuTaniSochiMstByKeyDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/11  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKatashikiBetsuTaniSochiMstByKeyDataAccess()
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
        /// 2014/07/11  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKatashikiBetsuTaniSochiMstByKeyDAOutput Execute(ISelectKatashikiBetsuTaniSochiMstByKeyDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKatashikiBetsuTaniSochiMstByKeyDAOutput output = new SelectKatashikiBetsuTaniSochiMstByKeyDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                // UPD 20140731 START ZynasSou
                //output.KatashikiBetsuTaniSochiMstDT = tableAdapter.GetDataByKey(input.KatashikiMakerCd, input.KatashikiCd, input.TaniSochiCd);
                output.KatashikiBetsuTaniSochiMstDT = tableAdapter.GetDataByKey(input.KatashikiMakerCd, input.KatashikiCd, input.TaniSochiGroupCd, input.TaniSochiNm);
                // UPD 20140731 END ZynasSou

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
