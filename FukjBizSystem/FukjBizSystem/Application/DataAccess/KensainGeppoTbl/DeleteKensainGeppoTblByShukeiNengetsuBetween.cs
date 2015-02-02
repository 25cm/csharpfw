using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet.KensainGeppoTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KensainGeppoTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteKensainGeppoTblByShukeiNengetsuBetweenDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/28  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteKensainGeppoTblByShukeiNengetsuBetweenDAInput
    {
        /// <summary>
        /// 集計年月FROM
        /// </summary>
        string ShukeiNengetsuFrom { get; set; }

        /// <summary>
        /// 集計年月TO
        /// </summary>
        string ShukeiNengetsuTo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteKensainGeppoTblByShukeiNengetsuBetweenDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/28  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteKensainGeppoTblByShukeiNengetsuBetweenDAInput : IDeleteKensainGeppoTblByShukeiNengetsuBetweenDAInput
    {
        /// <summary>
        /// 集計年月FROM
        /// </summary>
        public string ShukeiNengetsuFrom { get; set; }

        /// <summary>
        /// 集計年月TO
        /// </summary>
        public string ShukeiNengetsuTo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteKensainGeppoTblByShukeiNengetsuBetweenDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/28  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteKensainGeppoTblByShukeiNengetsuBetweenDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteKensainGeppoTblByShukeiNengetsuBetweenDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/28  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteKensainGeppoTblByShukeiNengetsuBetweenDAOutput : IDeleteKensainGeppoTblByShukeiNengetsuBetweenDAOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteKensainGeppoTblByShukeiNengetsuBetweenDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/28  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteKensainGeppoTblByShukeiNengetsuBetweenDataAccess : BaseDataAccess<IDeleteKensainGeppoTblByShukeiNengetsuBetweenDAInput, IDeleteKensainGeppoTblByShukeiNengetsuBetweenDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KensainGeppoTblTableAdapter tableAdapter = new KensainGeppoTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteKensainGeppoTblByShukeiNengetsuBetweenDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/28  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DeleteKensainGeppoTblByShukeiNengetsuBetweenDataAccess()
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
        /// 2014/08/28  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDeleteKensainGeppoTblByShukeiNengetsuBetweenDAOutput Execute(IDeleteKensainGeppoTblByShukeiNengetsuBetweenDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteKensainGeppoTblByShukeiNengetsuBetweenDAOutput output = new DeleteKensainGeppoTblByShukeiNengetsuBetweenDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                tableAdapter.DeleteByShukeiNengetsuBetween(input.ShukeiNengetsuFrom, input.ShukeiNengetsuTo);

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
