using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.ShokenKekkaTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.ShokenKekkaTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectShokenKekkaListWithBitmaskDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/23  小松  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectShokenKekkaListWithBitmaskDAInput
    {
        /// <summary>
        /// 検査依頼法定区分
        /// </summary>
        string KensaIraiHoteiKbn { get; set; }
        /// <summary>
        /// 検査依頼保健所コード
        /// </summary>
        string KensaIraiHokenjoCd { get; set; }
        /// <summary>
        /// 検査依頼年度
        /// </summary>
        string KensaIraiNendo { get; set; }
        /// <summary>
        /// 検査依頼連番
        /// </summary>
        string KensaIraiRenban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectShokenKekkaListWithBitmaskDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/23  小松  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectShokenKekkaListWithBitmaskDAInput : ISelectShokenKekkaListWithBitmaskDAInput
    {
        /// <summary>
        /// 検査依頼法定区分
        /// </summary>
        public string KensaIraiHoteiKbn { get; set; }
        /// <summary>
        /// 検査依頼保健所コード
        /// </summary>
        public string KensaIraiHokenjoCd { get; set; }
        /// <summary>
        /// 検査依頼年度
        /// </summary>
        public string KensaIraiNendo { get; set; }
        /// <summary>
        /// 検査依頼連番
        /// </summary>
        public string KensaIraiRenban { get; set; }
    }
    #endregion


    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectShokenKekkaListWithBitmaskDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/23  小松  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectShokenKekkaListWithBitmaskDAOutput
    {
        /// <summary>
        /// 所見結果＆所見結果補足（対象検査ビットマスク）データ
        /// </summary>
        ShokenKekkaTblDataSet.ShokenKekkaListWithBitmaskDataTable ShokenKekkaListDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectShokenKekkaListWithBitmaskDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/23  小松  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectShokenKekkaListWithBitmaskDAOutput : ISelectShokenKekkaListWithBitmaskDAOutput
    {
        /// <summary>
        /// 所見結果＆所見結果補足（対象検査ビットマスク）データ
        /// </summary>
        public ShokenKekkaTblDataSet.ShokenKekkaListWithBitmaskDataTable ShokenKekkaListDT { get; set; }
    }
    #endregion


    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectShokenKekkaListWithBitmaskDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/23  小松  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectShokenKekkaListWithBitmaskDataAccess : BaseDataAccess<ISelectShokenKekkaListWithBitmaskDAInput, ISelectShokenKekkaListWithBitmaskDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private ShokenKekkaListWithBitmaskTableAdapter tableAdapter = new ShokenKekkaListWithBitmaskTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectShokenKekkaListWithBitmaskDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/23  小松  　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectShokenKekkaListWithBitmaskDataAccess()
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
        /// 2015/01/23  小松  　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectShokenKekkaListWithBitmaskDAOutput Execute(ISelectShokenKekkaListWithBitmaskDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectShokenKekkaListWithBitmaskDAOutput output = new SelectShokenKekkaListWithBitmaskDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                // 取得
                output.ShokenKekkaListDT = tableAdapter.GetData(input.KensaIraiHoteiKbn,
                                                                input.KensaIraiHokenjoCd,
                                                                input.KensaIraiNendo,
                                                                input.KensaIraiRenban);


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
