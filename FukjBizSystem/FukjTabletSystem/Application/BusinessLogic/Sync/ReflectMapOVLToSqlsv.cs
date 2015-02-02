using System.Reflection;
using FukjBizSystem.Application.DataAccess.MapWorks.Bitmaps;
using FukjBizSystem.Application.DataAccess.MapWorks.Object;
using FukjBizSystem.Application.DataSet.MapWorks;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.BusinessLogic.Sync
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IReflectMapOVLToSqlsvBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IReflectMapOVLToSqlsvBLInput
    {
        /// <summary>
        /// ビットマップオブジェクト
        /// </summary>
        BitmapsDataSet.BitmapsDataTable Bitmaps { get; set; }

        /// <summary>
        /// オーバレイオブジェクト
        /// </summary>
        ObjectDataSet.ObjectDataTable Object { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ReflectMapOVLToSqlsvBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ReflectMapOVLToSqlsvBLInput : IReflectMapOVLToSqlsvBLInput
    {
        /// <summary>
        /// ビットマップオブジェクト
        /// </summary>
        public BitmapsDataSet.BitmapsDataTable Bitmaps { get; set; }

        /// <summary>
        /// オーバレイオブジェクト
        /// </summary>
        public ObjectDataSet.ObjectDataTable Object { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IReflectMapOVLToSqlsvBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IReflectMapOVLToSqlsvBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ReflectMapOVLToSqlsvBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ReflectMapOVLToSqlsvBLOutput : IReflectMapOVLToSqlsvBLOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ReflectMapOVLToSqlsvBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ReflectMapOVLToSqlsvBusinessLogic : BaseBusinessLogic<IReflectMapOVLToSqlsvBLInput, IReflectMapOVLToSqlsvBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ReflectMapOVLToSqlsvBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/05　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public ReflectMapOVLToSqlsvBusinessLogic()
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
        /// 2014/09/05　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IReflectMapOVLToSqlsvBLOutput Execute(IReflectMapOVLToSqlsvBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IReflectMapOVLToSqlsvBLOutput output = new ReflectMapOVLToSqlsvBLOutput();

            try
            {
                ISelectBitmapsByMD5KeyDAInput selectBitmapInput = new SelectBitmapsByMD5KeyDAInput();

                foreach (BitmapsDataSet.BitmapsRow row in input.Bitmaps)
                {
                    selectBitmapInput.MD5Key = row.MD5Key;

                    if (new SelectBitmapsByMD5KeyDataAccess().Execute(selectBitmapInput).Bitmaps.Count == 0)
                    {
                        row.SetAdded();
                    }
                    else
                    {
                        row.SetModified();
                    }
                }

                ISelectObjectByObjectIDDAInput selectObjectInput = new SelectObjectByObjectIDDAInput();

                foreach (ObjectDataSet.ObjectRow row in input.Object)
                {
                    selectObjectInput.ObjectID = row.ObjectID;

                    if (new SelectObjectByObjectIDDataAccess().Execute(selectObjectInput).Object.Count == 0)
                    {
                        row.SetAdded();
                    }
                    else
                    {
                        row.SetModified();
                    }
                }

                IUpdateBitmapsDAInput bitmapInput = new UpdateBitmapsDAInput();

                bitmapInput.Bitmaps = input.Bitmaps;

                new UpdateBitmapsDataAccess().Execute(bitmapInput);


                IUpdateObjectDAInput objectInput = new UpdateObjectDAInput();

                objectInput.Object = input.Object;

                new UpdateObjectDataAccess().Execute(objectInput);
            }
            catch
            {
                throw;
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
