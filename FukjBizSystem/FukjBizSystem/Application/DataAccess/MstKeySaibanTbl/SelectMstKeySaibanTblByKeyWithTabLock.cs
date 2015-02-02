using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.MstKeySaibanTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.MstKeySaibanTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectMstKeySaibanTblByKeyWithTabLockDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/03　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectMstKeySaibanTblByKeyWithTabLockDAInput
    {
        /// <summary>
        /// マスタ物理名称
        /// </summary>
        String MstButsuriNm { get; set; }

        /// <summary>
        /// キー項目値１
        /// </summary>
        String MstKeyValue1 { get; set; }

        /// <summary>
        /// キー項目値２
        /// </summary>
        String MstKeyValue2 { get; set; }

        /// <summary>
        /// キー項目値３
        /// </summary>
        String MstKeyValue3 { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectMstKeySaibanTblByKeyWithTabLockDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/03　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectMstKeySaibanTblByKeyWithTabLockDAInput : ISelectMstKeySaibanTblByKeyWithTabLockDAInput
    {
        /// <summary>
        /// マスタ物理名称
        /// </summary>
        public String MstButsuriNm { get; set; }

        /// <summary>
        /// キー項目値１
        /// </summary>
        public String MstKeyValue1 { get; set; }

        /// <summary>
        /// キー項目値２
        /// </summary>
        public String MstKeyValue2 { get; set; }

        /// <summary>
        /// キー項目値３
        /// </summary>
        public String MstKeyValue3 { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("マスタ物理名称[{0}], キー項目値１[{1}], キー項目値２[{2}], キー項目値３[{3}]",
                    new string[]{
                        MstButsuriNm,
                        MstKeyValue1,
                        MstKeyValue2,
                        MstKeyValue3
                    });
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectMstKeySaibanTblByKeyWithTabLockDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/03　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectMstKeySaibanTblByKeyWithTabLockDAOutput
    {
        /// <summary>
        /// MstKeySaibanTblDataTable
        /// </summary>
        MstKeySaibanTblDataSet.MstKeySaibanTblDataTable MstKeySaibanTblDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectMstKeySaibanTblByKeyWithTabLockDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/03　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectMstKeySaibanTblByKeyWithTabLockDAOutput : ISelectMstKeySaibanTblByKeyWithTabLockDAOutput
    {
        /// <summary>
        /// MstKeySaibanTblDataTable
        /// </summary>
        public MstKeySaibanTblDataSet.MstKeySaibanTblDataTable MstKeySaibanTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectMstKeySaibanTblByKeyWithTabLockDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/03　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectMstKeySaibanTblByKeyWithTabLockDataAccess : BaseDataAccess<ISelectMstKeySaibanTblByKeyWithTabLockDAInput, ISelectMstKeySaibanTblByKeyWithTabLockDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private MstKeySaibanTblTableAdapter tableAdapter = new MstKeySaibanTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectMstKeySaibanTblByKeyWithTabLockDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/03　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectMstKeySaibanTblByKeyWithTabLockDataAccess()
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
        /// 2014/10/03　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectMstKeySaibanTblByKeyWithTabLockDAOutput Execute(ISelectMstKeySaibanTblByKeyWithTabLockDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectMstKeySaibanTblByKeyWithTabLockDAOutput output = new SelectMstKeySaibanTblByKeyWithTabLockDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.MstKeySaibanTblDT = tableAdapter.GetDataByKeyWithTabLock(input.MstButsuriNm, input.MstKeyValue1, input.MstKeyValue2, input.MstKeyValue3);

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
