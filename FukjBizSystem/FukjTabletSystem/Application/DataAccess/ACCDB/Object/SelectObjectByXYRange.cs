using System;
using System.Reflection;
using FukjTabletSystem.Application.DataSet.ACCDB;
using FukjTabletSystem.Application.DataSet.ACCDB.ObjectDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.DataAccess.ACCDB.Object
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectObjectByXYRangeDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectObjectByXYRangeDAInput
    {
        /// <summary>
        /// maxX
        /// </summary>
        int maxX { get; set; }

        /// <summary>
        /// maxY
        /// </summary>
        int maxY { get; set; }

        /// <summary>
        /// minX
        /// </summary>
        int minX { get; set; }

        /// <summary>
        /// minY
        /// </summary>
        int minY { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectObjectByXYRangeDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectObjectByXYRangeDAInput : ISelectObjectByXYRangeDAInput
    {
        /// <summary>
        /// maxX
        /// </summary>
        public int maxX { get; set; }

        /// <summary>
        /// maxY
        /// </summary>
        public int maxY { get; set; }

        /// <summary>
        /// minX
        /// </summary>
        public int minX { get; set; }

        /// <summary>
        /// minY
        /// </summary>
        public int minY { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectObjectByXYRangeDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectObjectByXYRangeDAOutput
    {
        /// <summary>
        /// オーバレイオブジェクト
        /// </summary>
        ObjectDataSet.ObjectDataTable Object { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectObjectByXYRangeDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectObjectByXYRangeDAOutput : ISelectObjectByXYRangeDAOutput
    {
        /// <summary>
        /// オーバレイオブジェクト
        /// </summary>
        public ObjectDataSet.ObjectDataTable Object { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectObjectByXYRangeDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectObjectByXYRangeDataAccess : BaseDataAccessMdb<ISelectObjectByXYRangeDAInput, ISelectObjectByXYRangeDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private ObjectTableAdapter tableAdapter = new ObjectTableAdapter();
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectObjectByXYRangeDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/05　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectObjectByXYRangeDataAccess()
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
        /// 2014/08/05　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectObjectByXYRangeDAOutput Execute(ISelectObjectByXYRangeDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectObjectByXYRangeDAOutput output = new SelectObjectByXYRangeDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.Object = tableAdapter.GetDataByXYRange(input.minX, input.maxX, input.minX, input.maxX, input.minY, input.maxY, input.minY, input.maxY);

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
