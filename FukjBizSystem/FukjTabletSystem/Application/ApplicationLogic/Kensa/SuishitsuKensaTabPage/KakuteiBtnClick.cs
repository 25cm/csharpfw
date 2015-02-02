using System.Data;
using System.Reflection;
using FukjTabletSystem.Application.BusinessLogic.Kensa;
using FukjTabletSystem.Application.BusinessLogic.Kensa.SuishitsuKensaTabPage;
using FukjTabletSystem.Application.DataSet.SQLCE;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.ApplicationLogic.Kensa.SuishitsuKensaTabPage
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKakuteiBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/18　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKakuteiBtnClickALInput : IBseALInput, IUpdateShokenKekkaTblBLInput, IUpdateShokenKekkaHosokuTblBLInput, IUpdateSaiSaisuiTblForSuishitsuUpdateBLInput, IUpdateKensaKekkaForSuishitsuUpdateBLInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KakuteiBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/18　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KakuteiBtnClickALInput : IKakuteiBtnClickALInput
    {
        /// <summary>
        /// ShokenKekkaTbl
        /// </summary>
        public ShokenKekkaTblDataSet.ShokenKekkaTblDataTable ShokenKekkaTbl { get; set; }

        /// <summary>
        /// ShokenKekkaHosokuTbl
        /// </summary>
        public ShokenKekkaHosokuTblDataSet.ShokenKekkaHosokuTblDataTable ShokenKekkaHosokuTbl { get; set; }

        /// <summary>
        /// SaiSaisuiTblForSuishitsuUpdate
        /// </summary>
        public SaiSaisuiTblDataSet.SaiSaisuiTblForSuishitsuUpdateDataTable SaiSaisuiTblForSuishitsuUpdate { get; set; }

        /// <summary>
        /// KensaKekkaForSuishitsuUpdate
        /// </summary>
        public KensaKekkaTblDataSet.KensaKekkaForSuishitsuUpdateDataTable KensaKekkaForSuishitsuUpdate { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Empty;
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKakuteiBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/18　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKakuteiBtnClickALOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KakuteiBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/18　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KakuteiBtnClickALOutput : IKakuteiBtnClickALOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KakuteiBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/18　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KakuteiBtnClickApplicationLogic : BaseApplicationLogic<IKakuteiBtnClickALInput, IKakuteiBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "SuishitsuKensaTabPage：KakuteiBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KakuteiBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/18　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KakuteiBtnClickApplicationLogic()
        {
        }
        #endregion

        #region メソッド(protected)

        #region GetFunctionName
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetFunctionName
        /// <summary>
        /// 機能名取得
        /// </summary>
        /// <returns>機能名</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/18　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override string GetFunctionName()
        {
            return FunctionName;
        }
        #endregion

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
        /// 2014/11/18　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IKakuteiBtnClickALOutput Execute(IKakuteiBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKakuteiBtnClickALOutput output = new KakuteiBtnClickALOutput();

            try
            {
                try
                {
                    // トランザクション開始
                    StartTransactionCe();

                    // 所見変更なしの場合（画面で制御する予定。Rowへのアクセスがあるので念のため）
                    if (input.ShokenKekkaTbl.Count > 0)
                    {
                        // 現在の連番最大値を取得
                        IGetMaxShokenRenbanByKensaIraiKeyBLInput maxShokenInput = new GetMaxShokenRenbanByKensaIraiKeyBLInput();

                        maxShokenInput.IraiHoteiKbn = input.ShokenKekkaTbl[0].RowState == System.Data.DataRowState.Deleted
                                                                                        ? input.ShokenKekkaTbl.Rows[0]["KensaIraiShokanIraiHoteiKbn", System.Data.DataRowVersion.Original].ToString()
                                                                                        : input.ShokenKekkaTbl[0].KensaIraiShokanIraiHoteiKbn;

                        maxShokenInput.IraiHokenjoCd = input.ShokenKekkaTbl[0].RowState == System.Data.DataRowState.Deleted
                                                                                        ? input.ShokenKekkaTbl.Rows[0]["KensaIraiShokenIraiHokenjoCd", System.Data.DataRowVersion.Original].ToString()
                                                                                        : input.ShokenKekkaTbl[0].KensaIraiShokenIraiHokenjoCd;

                        maxShokenInput.IraiNendo = input.ShokenKekkaTbl[0].RowState == System.Data.DataRowState.Deleted
                                                                                        ? input.ShokenKekkaTbl.Rows[0]["KensaIraiShokenIraiNendo", System.Data.DataRowVersion.Original].ToString()
                                                                                        : input.ShokenKekkaTbl[0].KensaIraiShokenIraiNendo;

                        maxShokenInput.IraiRenban = input.ShokenKekkaTbl[0].RowState == System.Data.DataRowState.Deleted
                                                                                        ? input.ShokenKekkaTbl.Rows[0]["KensaIraiShokenIraiRenban", System.Data.DataRowVersion.Original].ToString()
                                                                                        : input.ShokenKekkaTbl[0].KensaIraiShokenIraiRenban;

                        IGetMaxShokenRenbanByKensaIraiKeyBLOutput maxShokenOutput = new GetMaxShokenRenbanByKensaIraiKeyBusinessLogic().Execute(maxShokenInput);

                        int maxRenban = maxShokenOutput.MaxShokenRenban == null ? 0 : int.Parse(maxShokenOutput.MaxShokenRenban);

                        // 追加分の連番を振りなおす
                        foreach (ShokenKekkaTblDataSet.ShokenKekkaTblRow row in input.ShokenKekkaTbl)
                        {
                            if (row.RowState == System.Data.DataRowState.Added)
                            {
                                maxRenban++;

                                // 補足文を合わせて変更する
                                DataRow[] hosokuRows = input.ShokenKekkaHosokuTbl.Select(string.Format("KensaIraiShokenRenban = '{0}'", row.KensaIraiShokenRenban));

                                foreach (DataRow hosokuRow in hosokuRows)
                                {
                                    hosokuRow["KensaIraiShokenRenban"] = string.Format("{0:00}", maxRenban);
                                }

                                row.KensaIraiShokenRenban = string.Format("{0:00}", maxRenban);
                            }
                        }

                        // 更新処理
                        if (input.ShokenKekkaTbl.Count > 0)
                        {
                            new UpdateShokenKekkaTblBusinessLogic().Execute(input);
                        }

                        if (input.ShokenKekkaHosokuTbl.Count > 0)
                        {
                            new UpdateShokenKekkaHosokuTblBusinessLogic().Execute(input);
                        }

                        if (input.ShokenKekkaTbl.Count > 0)
                        {
                            // 表示位置の調整
                            IUpdateShokenHyojiichiBLInput hyojiichiInput = new UpdateShokenHyojiichiBLInput();
                            hyojiichiInput.IraiHoteiKbn = input.ShokenKekkaTbl[0].KensaIraiShokanIraiHoteiKbn;
                            hyojiichiInput.IraiHokenjoCd = input.ShokenKekkaTbl[0].KensaIraiShokenIraiHokenjoCd;
                            hyojiichiInput.IraiNendo = input.ShokenKekkaTbl[0].KensaIraiShokenIraiNendo;
                            hyojiichiInput.IraiRenban = input.ShokenKekkaTbl[0].KensaIraiShokenIraiRenban;

                            new UpdateShokenHyojiichiBusinessLogic().Execute(hyojiichiInput);
                        }
                    }
                    
                    // 検査結果
                    if (input.KensaKekkaForSuishitsuUpdate.Count > 0)
                    {
                        new UpdateKensaKekkaForSuishitsuUpdateBusinessLogic().Execute(input);
                    }

                    // 再採水
                    if (input.SaiSaisuiTblForSuishitsuUpdate.Count > 0)
                    {
                        new UpdateSaiSaisuiTblForSuishitsuUpdateBusinessLogic().Execute(input);
                    }

                    // コミット
                    CompleteTransactionCe();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    // トランザクション終了
                    EndTransactionCe();
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
