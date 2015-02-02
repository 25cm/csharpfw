using System;
using System.Reflection;
using FukjTabletSystem.Application.DataAccess.ACCDB.Bitmaps;
using FukjTabletSystem.Application.DataAccess.ACCDB.Object;
using FukjTabletSystem.Application.DataSet.ACCDB;
using FukjTabletSystem.Application.Utility;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.BusinessLogic.Sync
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetMapOVLFromMDBBLInput
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
    interface IGetMapOVLFromMDBBLInput
    {
        /// <summary>
        /// LastUpdateFrom
        /// </summary>
        DateTime LastUpdateFrom { get; set; }

        /// <summary>
        /// LastUpdateTo
        /// </summary>
        DateTime LastUpdateTo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetMapOVLFromMDBBLInput
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
    class GetMapOVLFromMDBBLInput : IGetMapOVLFromMDBBLInput
    {
        /// <summary>
        /// LastUpdateFrom
        /// </summary>
        public DateTime LastUpdateFrom { get; set; }

        /// <summary>
        /// LastUpdateTo
        /// </summary>
        public DateTime LastUpdateTo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetMapOVLFromMDBBLOutput
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
    interface IGetMapOVLFromMDBBLOutput
    {
        /// <summary>
        /// ビットマップオブジェクト
        /// </summary>
        FukjBizSystem.Application.DataSet.MapWorks.BitmapsDataSet.BitmapsDataTable Bitmaps { get; set; }

        /// <summary>
        /// オーバレイオブジェクト
        /// </summary>
        FukjBizSystem.Application.DataSet.MapWorks.ObjectDataSet.ObjectDataTable Object { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetMapOVLFromMDBBLOutput
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
    class GetMapOVLFromMDBBLOutput : IGetMapOVLFromMDBBLOutput
    {
        /// <summary>
        /// ビットマップオブジェクト
        /// </summary>
        public FukjBizSystem.Application.DataSet.MapWorks.BitmapsDataSet.BitmapsDataTable Bitmaps { get; set; }

        /// <summary>
        /// オーバレイオブジェクト
        /// </summary>
        public FukjBizSystem.Application.DataSet.MapWorks.ObjectDataSet.ObjectDataTable Object { get; set; }

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetMapOVLFromMDBBusinessLogic
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
    class GetMapOVLFromMDBBusinessLogic : BaseBusinessLogic<IGetMapOVLFromMDBBLInput, IGetMapOVLFromMDBBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetMapOVLFromMDBBusinessLogic
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
        public GetMapOVLFromMDBBusinessLogic()
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
        public override IGetMapOVLFromMDBBLOutput Execute(IGetMapOVLFromMDBBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetMapOVLFromMDBBLOutput output = new GetMapOVLFromMDBBLOutput();

            // Bitmap（差分）
            output.Bitmaps = new FukjBizSystem.Application.DataSet.MapWorks.BitmapsDataSet.BitmapsDataTable();

            // Object（差分）
            output.Object = new FukjBizSystem.Application.DataSet.MapWorks.ObjectDataSet.ObjectDataTable();

            try
            {
                // Object取得
                ISelectObjectFromLastUpdateDAInput objectInput = new SelectObjectFromLastUpdateDAInput();

                objectInput.LastUpdateFrom = input.LastUpdateFrom;

                objectInput.LastUpdateTo = input.LastUpdateTo;

                ISelectObjectFromLastUpdateDAOutput objectOutput = new SelectObjectFromLastUpdateDataAccess().Execute(objectInput);

                foreach (ObjectDataSet.ObjectRow obj in objectOutput.Object)
                {
                    // Bitmapレコード有り
                    if (obj.ObjectType == 6)
                    {
                        byte[] md5Key = new byte[16];

                        Array.Copy(obj.Body, 24, md5Key, 0, 16);

                        // Bitmaps取得
                        ISelectBitmapsByMD5KeyDAInput bitmapsInput = new SelectBitmapsByMD5KeyDAInput();

                        bitmapsInput.MD5Key = BytesConvert.ToHexString(md5Key);

                        ISelectBitmapsByMD5KeyDAOutput bitmapsOutput = new SelectBitmapsByMD5KeyDataAccess().Execute(bitmapsInput);

                        // outputに追加
                        if (bitmapsOutput.Bitmaps.Count > 0 && output.Bitmaps.FindByMD5Key(BytesConvert.ToHexString(md5Key)) == null)
                        {
                            output.Bitmaps.ImportRow(bitmapsOutput.Bitmaps[0]);
                        }
                    }

                    // outputに追加
                    output.Object.ImportRow(obj);
                }
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
