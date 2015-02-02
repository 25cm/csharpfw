using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.JinendoGaikanYoteiOutputTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.JinendoGaikanYoteiOutputTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectJinendoGaikanKensaYoteiNyuryokuByCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectJinendoGaikanKensaYoteiNyuryokuByCondDAInput
    {
        /// <summary>
        /// 作成年度
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
        /// 業者コード（開始）
        /// </summary>
        string GyoshaCdFrom { get; set; }

        /// <summary>
        /// 業者コード（終了）
        /// </summary>
        string GyoshaCdTo { get; set; }

        /// <summary>
        /// 浄化槽番号（開始）保健所
        /// </summary>
        string IraiNoFromHokenjo { get; set; }

        /// <summary>
        /// 浄化槽番号（開始）年度
        /// </summary>
        string IraiNoFromNendo { get; set; }

        /// <summary>
        /// 浄化槽番号（開始）連番
        /// </summary>
        string IraiNoFromRenban { get; set; }

        /// <summary>
        /// 浄化槽番号（終了）保健所
        /// </summary>
        string IraiNoToHokenjo { get; set; }

        /// <summary>
        /// 浄化槽番号（終了）年度
        /// </summary>
        string IraiNoToNendo { get; set; }

        /// <summary>
        /// 浄化槽番号（終了）連番
        /// </summary>
        string IraiNoToRenban { get; set; }

        /// <summary>
        /// 人槽区分
        /// </summary>
        int NinsoKbn { get; set; }

        /// <summary>
        /// 差分出力
        /// </summary>
        int IraiMakeKbn { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJinendoGaikanKensaYoteiNyuryokuByCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJinendoGaikanKensaYoteiNyuryokuByCondDAInput : ISelectJinendoGaikanKensaYoteiNyuryokuByCondDAInput
    {
        /// <summary>
        /// 作成年度
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
        /// 業者コード（開始）
        /// </summary>
        public string GyoshaCdFrom { get; set; }

        /// <summary>
        /// 業者コード（終了）
        /// </summary>
        public string GyoshaCdTo { get; set; }

        /// <summary>
        /// 浄化槽番号（開始）保健所
        /// </summary>
        public string IraiNoFromHokenjo { get; set; }

        /// <summary>
        /// 浄化槽番号（開始）年度
        /// </summary>
        public string IraiNoFromNendo { get; set; }

        /// <summary>
        /// 浄化槽番号（開始）連番
        /// </summary>
        public string IraiNoFromRenban { get; set; }

        /// <summary>
        /// 浄化槽番号（終了）保健所
        /// </summary>
        public string IraiNoToHokenjo { get; set; }

        /// <summary>
        /// 浄化槽番号（終了）年度
        /// </summary>
        public string IraiNoToNendo { get; set; }

        /// <summary>
        /// 浄化槽番号（終了）連番
        /// </summary>
        public string IraiNoToRenban { get; set; }

        /// <summary>
        /// 人槽区分
        /// </summary>
        public int NinsoKbn { get; set; }

        /// <summary>
        /// 差分出力
        /// </summary>
        public int IraiMakeKbn { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectJinendoGaikanKensaYoteiNyuryokuByCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectJinendoGaikanKensaYoteiNyuryokuByCondDAOutput
    {
        /// <summary>
        /// JinendoGaikanKensaYoteiNyuryokuDataTable
        /// </summary>
        JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanKensaYoteiNyuryokuDataTable JinendoGaikanKensaYoteiNyuryokuDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJinendoGaikanKensaYoteiNyuryokuByCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJinendoGaikanKensaYoteiNyuryokuByCondDAOutput : ISelectJinendoGaikanKensaYoteiNyuryokuByCondDAOutput
    {
        /// <summary>
        /// JinendoGaikanKensaYoteiNyuryokuDataTable
        /// </summary>
        public JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanKensaYoteiNyuryokuDataTable JinendoGaikanKensaYoteiNyuryokuDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJinendoGaikanKensaYoteiNyuryokuByCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJinendoGaikanKensaYoteiNyuryokuByCondDataAccess : BaseDataAccess<ISelectJinendoGaikanKensaYoteiNyuryokuByCondDAInput, ISelectJinendoGaikanKensaYoteiNyuryokuByCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private JinendoGaikanKensaYoteiNyuryokuTableAdapter tableAdapter
            = new JinendoGaikanKensaYoteiNyuryokuTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectJinendoGaikanKensaYoteiNyuryokuByCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectJinendoGaikanKensaYoteiNyuryokuByCondDataAccess()
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
        /// 2014/11/17　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectJinendoGaikanKensaYoteiNyuryokuByCondDAOutput Execute(ISelectJinendoGaikanKensaYoteiNyuryokuByCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectJinendoGaikanKensaYoteiNyuryokuByCondDAOutput output = new SelectJinendoGaikanKensaYoteiNyuryokuByCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                tableAdapter.CommandTimeout = Properties.Settings.Default.DefaultCommandTimeoutSec;

                output.JinendoGaikanKensaYoteiNyuryokuDataTable = tableAdapter.GetDataBySearchCond(input.Nendo, input.ChikuCdFrom, input.ChikuCdTo, input.GyoshaCdFrom, input.GyoshaCdTo,
                    input.IraiNoFromHokenjo, input.IraiNoFromNendo, input.IraiNoFromRenban, input.IraiNoToHokenjo, input.IraiNoToNendo, input.IraiNoToRenban, input.NinsoKbn, input.IraiMakeKbn);

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
