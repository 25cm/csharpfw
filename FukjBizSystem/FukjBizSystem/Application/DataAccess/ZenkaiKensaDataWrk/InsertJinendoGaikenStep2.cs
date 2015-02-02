using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet.ZenkaiKensaDataWrkDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.ZenkaiKensaDataWrk
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IInsertJinendoGaikenStep2DAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IInsertJinendoGaikenStep2DAInput
    {
        /// <summary>
        /// 年度
        /// </summary>
        string Nendo { get; set; }

        /// <summary>
        /// 地区コード（開始）
        /// </summary>
        string ChikuCdFrom { get; set; }

        /// <summary>
        /// 地区コード（終了）
        /// </summary>
        string ChikuCdTo { get; set; }

        /// <summary>
        /// 作表区分１－１
        /// </summary>
        bool SakuhyoKbn11 { get; set; }

        /// <summary>
        /// 作表区分１－２
        /// </summary>
        bool SakuhyoKbn12 { get; set; }

        /// <summary>
        /// 作表区分１－３
        /// </summary>
        bool SakuhyoKbn13 { get; set; }

        /// <summary>
        /// 差分出力/出力差分
        /// </summary>
        bool SakuhyoKbn31 { get; set; }

        /// <summary>
        /// 差分出力/入力差分
        /// </summary>
        bool SakuhyoKbn32 { get; set; }

        /// <summary>
        /// 差分出力/すべて
        /// </summary>
        bool SakuhyoKbn33 { get; set; }

        /// <summary>
        /// DateTime Now
        /// </summary>
        DateTime Now { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： InsertJinendoGaikenStep2DAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class InsertJinendoGaikenStep2DAInput : IInsertJinendoGaikenStep2DAInput
    {
        /// <summary>
        /// 年度
        /// </summary>
        public string Nendo { get; set; }

        /// <summary>
        /// 地区コード（開始）
        /// </summary>
        public string ChikuCdFrom { get; set; }

        /// <summary>
        /// 地区コード（終了）
        /// </summary>
        public string ChikuCdTo { get; set; }

        /// <summary>
        /// 作表区分１－１
        /// </summary>
        public bool SakuhyoKbn11 { get; set; }

        /// <summary>
        /// 作表区分１－２
        /// </summary>
        public bool SakuhyoKbn12 { get; set; }

        /// <summary>
        /// 作表区分１－３
        /// </summary>
        public bool SakuhyoKbn13 { get; set; }

        /// <summary>
        /// 差分出力/出力差分
        /// </summary>
        public bool SakuhyoKbn31 { get; set; }

        /// <summary>
        /// 差分出力/入力差分
        /// </summary>
        public bool SakuhyoKbn32 { get; set; }

        /// <summary>
        /// 差分出力/すべて
        /// </summary>
        public bool SakuhyoKbn33 { get; set; }

        /// <summary>
        /// DateTime Now
        /// </summary>
        public DateTime Now { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IInsertJinendoGaikenStep2DAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IInsertJinendoGaikenStep2DAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： InsertJinendoGaikenStep2DAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class InsertJinendoGaikenStep2DAOutput : IInsertJinendoGaikenStep2DAOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： InsertJinendoGaikenStep2DataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class InsertJinendoGaikenStep2DataAccess : BaseDataAccess<IInsertJinendoGaikenStep2DAInput, IInsertJinendoGaikenStep2DAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private ZenkaiKensaDataWrkTableAdapter tableAdapter = new ZenkaiKensaDataWrkTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： InsertJinendoGaikenStep2DataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/03  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public InsertJinendoGaikenStep2DataAccess()
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
        /// 2014/12/03  DatNT　  新規作成
        /// 2015/01/22　小松　　　　コマンドタイムアウト設定
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IInsertJinendoGaikenStep2DAOutput Execute(IInsertJinendoGaikenStep2DAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IInsertJinendoGaikenStep2DAOutput output = new InsertJinendoGaikenStep2DAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                // タイムアウトを設定(単位：秒)
                tableAdapter.CommandTimeout = Properties.Settings.Default.DefaultCommandTimeoutSec;

                tableAdapter.JinendoGaikenStep2(input.Nendo,
                                                    input.ChikuCdFrom,
                                                    input.ChikuCdTo,
                                                    input.SakuhyoKbn11,
                                                    input.SakuhyoKbn12,
                                                    input.SakuhyoKbn13,
                                                    input.SakuhyoKbn31,
                                                    input.SakuhyoKbn32,
                                                    input.SakuhyoKbn33,
                                                    input.Now);
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
