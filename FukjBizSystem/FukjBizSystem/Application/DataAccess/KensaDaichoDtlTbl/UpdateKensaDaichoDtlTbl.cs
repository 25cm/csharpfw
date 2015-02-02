using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KensaDaichoDtlTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KensaDaichoDtlTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateKensaDaichoDtlTblDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateKensaDaichoDtlTblDAInput
    {
        /// <summary>
        /// KensaDaichoDtlTblDataTable
        /// </summary>
        KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable KensaDaichoDtlTblDT { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateKensaDaichoDtlTblDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateKensaDaichoDtlTblDAInput : IUpdateKensaDaichoDtlTblDAInput
    {
        /// <summary>
        /// KensaDaichoDtlTblDataTable
        /// </summary>
        public KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable KensaDaichoDtlTblDT { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateKensaDaichoDtlTblDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateKensaDaichoDtlTblDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateKensaDaichoDtlTblDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateKensaDaichoDtlTblDAOutput : IUpdateKensaDaichoDtlTblDAOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateKensaDaichoDtlTblDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateKensaDaichoDtlTblDataAccess : BaseDataAccess<IUpdateKensaDaichoDtlTblDAInput, IUpdateKensaDaichoDtlTblDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KensaDaichoDtlTblTableAdapter tableAdapter = new KensaDaichoDtlTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： UpdateKensaDaichoDtlTblDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public UpdateKensaDaichoDtlTblDataAccess()
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
        /// 2014/12/02  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IUpdateKensaDaichoDtlTblDAOutput Execute(IUpdateKensaDaichoDtlTblDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdateKensaDaichoDtlTblDAOutput output = new UpdateKensaDaichoDtlTblDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                tableAdapter.Update(input.KensaDaichoDtlTblDT);

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
