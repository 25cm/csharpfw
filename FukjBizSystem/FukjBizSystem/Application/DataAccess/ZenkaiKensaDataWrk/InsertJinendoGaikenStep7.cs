using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet.ZenkaiKensaDataWrkDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.ZenkaiKensaDataWrk
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IInsertJinendoGaikenStep7DAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/04  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IInsertJinendoGaikenStep7DAInput
    {
        /// <summary>
        /// GyohsaCdFrom
        /// </summary>
        string GyoshaCdFrom { get; set; }

        /// <summary>
        /// GyoshaCdTo
        /// </summary>
        string GyoshaCdTo { get; set; }

        /// <summary>
        /// Nendo
        /// </summary>
        string Nendo { get; set; }

        /// <summary>
        /// DateTime Now
        /// </summary>
        DateTime Now { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： InsertJinendoGaikenStep7DAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/04  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class InsertJinendoGaikenStep7DAInput : IInsertJinendoGaikenStep7DAInput
    {
        /// <summary>
        /// GyohsaCdFrom
        /// </summary>
        public string GyoshaCdFrom { get; set; }

        /// <summary>
        /// GyoshaCdTo
        /// </summary>
        public string GyoshaCdTo { get; set; }

        /// <summary>
        /// Nendo
        /// </summary>
        public string Nendo { get; set; }

        /// <summary>
        /// DateTime Now
        /// </summary>
        public DateTime Now { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IInsertJinendoGaikenStep7DAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/04  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IInsertJinendoGaikenStep7DAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： InsertJinendoGaikenStep7DAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/04  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class InsertJinendoGaikenStep7DAOutput : IInsertJinendoGaikenStep7DAOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： InsertJinendoGaikenStep7DataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/04  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class InsertJinendoGaikenStep7DataAccess : BaseDataAccess<IInsertJinendoGaikenStep7DAInput, IInsertJinendoGaikenStep7DAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private ZenkaiKensaDataWrkTableAdapter tableAdapter = new ZenkaiKensaDataWrkTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： InsertJinendoGaikenStep7DataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public InsertJinendoGaikenStep7DataAccess()
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
        /// 2014/12/04  DatNT　  新規作成
        /// 2015/01/22　小松　　　　コマンドタイムアウト設定
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IInsertJinendoGaikenStep7DAOutput Execute(IInsertJinendoGaikenStep7DAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IInsertJinendoGaikenStep7DAOutput output = new InsertJinendoGaikenStep7DAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                // タイムアウトを設定(単位：秒)
                tableAdapter.CommandTimeout = Properties.Settings.Default.DefaultCommandTimeoutSec;

                tableAdapter.JinendoGaikenStep7(input.GyoshaCdFrom, input.GyoshaCdTo, input.Nendo, input.Now);

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
