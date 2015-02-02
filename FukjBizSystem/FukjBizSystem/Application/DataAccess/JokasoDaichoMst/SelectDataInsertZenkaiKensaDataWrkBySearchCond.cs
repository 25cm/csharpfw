using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.JokasoDaichoMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.JokasoDaichoMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectDataInsertZenkaiKensaDataWrkBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectDataInsertZenkaiKensaDataWrkBySearchCondDAInput
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
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectDataInsertZenkaiKensaDataWrkBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectDataInsertZenkaiKensaDataWrkBySearchCondDAInput : ISelectDataInsertZenkaiKensaDataWrkBySearchCondDAInput
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
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectDataInsertZenkaiKensaDataWrkBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectDataInsertZenkaiKensaDataWrkBySearchCondDAOutput
    {
        /// <summary>
        /// DataInsertZenkaiKensaDataWrkDataTable
        /// </summary>
        JokasoDaichoMstDataSet.DataInsertZenkaiKensaDataWrkDataTable DataInsertZenkaiKensaDataWrkDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectDataInsertZenkaiKensaDataWrkBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectDataInsertZenkaiKensaDataWrkBySearchCondDAOutput : ISelectDataInsertZenkaiKensaDataWrkBySearchCondDAOutput
    {
        /// <summary>
        /// DataInsertZenkaiKensaDataWrkDataTable
        /// </summary>
        public JokasoDaichoMstDataSet.DataInsertZenkaiKensaDataWrkDataTable DataInsertZenkaiKensaDataWrkDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectDataInsertZenkaiKensaDataWrkBySearchCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectDataInsertZenkaiKensaDataWrkBySearchCondDataAccess : BaseDataAccess<ISelectDataInsertZenkaiKensaDataWrkBySearchCondDAInput, ISelectDataInsertZenkaiKensaDataWrkBySearchCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private DataInsertZenkaiKensaDataWrkTableAdapter tableAdapter = new DataInsertZenkaiKensaDataWrkTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectDataInsertZenkaiKensaDataWrkBySearchCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectDataInsertZenkaiKensaDataWrkBySearchCondDataAccess()
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
        /// 2014/11/19  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectDataInsertZenkaiKensaDataWrkBySearchCondDAOutput Execute(ISelectDataInsertZenkaiKensaDataWrkBySearchCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectDataInsertZenkaiKensaDataWrkBySearchCondDAOutput output = new SelectDataInsertZenkaiKensaDataWrkBySearchCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.DataInsertZenkaiKensaDataWrkDT = tableAdapter.GetDataBySearchCond(   input.Nendo,
                                                                                            input.ChikuCdFrom,
                                                                                            input.ChikuCdTo,
                                                                                            input.SakuhyoKbn11,
                                                                                            input.SakuhyoKbn12,
                                                                                            input.SakuhyoKbn13,
                                                                                            input.SakuhyoKbn31,
                                                                                            input.SakuhyoKbn32,
                                                                                            input.SakuhyoKbn33  );

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
