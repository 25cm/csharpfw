using System.Reflection;
using FukjTabletSystem.Application.DataAccess.ACCDB.Bitmaps;
using FukjTabletSystem.Application.DataAccess.ACCDB.Object;
using FukjTabletSystem.Application.DataSet.ACCDB;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.BusinessLogic.Sync
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IReflectMapOVLToMDBBLInput
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
    interface IReflectMapOVLToMDBBLInput
    {
        /// <summary>
        /// ビットマップオブジェクト
        /// </summary>
        DataSet.ACCDB.BitmapsDataSet.BitmapsDataTable Bitmaps { get; set; }

        /// <summary>
        /// オーバレイオブジェクト
        /// </summary>
        DataSet.ACCDB.ObjectDataSet.ObjectDataTable Object { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ReflectMapOVLToMDBBLInput
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
    class ReflectMapOVLToMDBBLInput : IReflectMapOVLToMDBBLInput
    {
        /// <summary>
        /// ビットマップオブジェクト
        /// </summary>
        public DataSet.ACCDB.BitmapsDataSet.BitmapsDataTable Bitmaps { get; set; }

        /// <summary>
        /// オーバレイオブジェクト
        /// </summary>
        public DataSet.ACCDB.ObjectDataSet.ObjectDataTable Object { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IReflectMapOVLToMDBBLOutput
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
    interface IReflectMapOVLToMDBBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ReflectMapOVLToMDBBLOutput
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
    class ReflectMapOVLToMDBBLOutput : IReflectMapOVLToMDBBLOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ReflectMapOVLToMDBBusinessLogic
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
    class ReflectMapOVLToMDBBusinessLogic : BaseBusinessLogic<IReflectMapOVLToMDBBLInput, IReflectMapOVLToMDBBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ReflectMapOVLToMDBBusinessLogic
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
        public ReflectMapOVLToMDBBusinessLogic()
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
        public override IReflectMapOVLToMDBBLOutput Execute(IReflectMapOVLToMDBBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IReflectMapOVLToMDBBLOutput output = new ReflectMapOVLToMDBBLOutput();

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
