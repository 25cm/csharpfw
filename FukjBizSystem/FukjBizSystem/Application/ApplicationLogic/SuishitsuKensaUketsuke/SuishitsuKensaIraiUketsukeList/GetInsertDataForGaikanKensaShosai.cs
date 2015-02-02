using System;
using System.Reflection;
using FukjBizSystem.Application.Boundary.SuishitsuKensaUketsuke;
using FukjBizSystem.Application.BusinessLogic.Common;
using FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.Utility;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaUketsuke.SuishitsuKensaIraiUketsukeList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetInsertDataForGaikanKensaShosaiALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10  小松  　    詳細画面の子画面化（詳細では更新しない。受付一覧で更新）
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetInsertDataForGaikanKensaShosaiALInput : IBseALInput
    {
        /// <summary>
        /// 依頼年度
        /// </summary>
        string IraiNendo { get; set; }
        /// <summary>
        /// 支所コード
        /// </summary>
        string ShishoCd { get; set; }
        /// <summary>
        /// 検査受付日付
        /// </summary>
        string SuishitsuUketsukeDt { get; set; }
        /// <summary>
        /// 取込結果一覧データ
        /// </summary>
        SuishitsuKensaIraiDataSet.UketsukeImportListRow ListRow { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetInsertDataForGaikanKensaShosaiALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/11  小松  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetInsertDataForGaikanKensaShosaiALInput : IGetInsertDataForGaikanKensaShosaiALInput
    {
        /// <summary>
        /// 依頼年度
        /// </summary>
        public string IraiNendo { get; set; }

        /// <summary>
        /// 支所コード
        /// </summary>
        public string ShishoCd { get; set; }
        /// <summary>
        /// 検査受付日付
        /// </summary>
        public string SuishitsuUketsukeDt { get; set; }
        /// <summary>
        /// 取込結果一覧データ
        /// </summary>
        public SuishitsuKensaIraiDataSet.UketsukeImportListRow ListRow { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return String.Empty;
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetInsertDataForGaikanKensaShosaiALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/11  小松  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetInsertDataForGaikanKensaShosaiALOutput : IGetSuishitsuIraiInfoByKensaIraiKeyBLOutput, IGetKensaDaichoDtlTblByKeyBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetInsertDataForGaikanKensaShosaiALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/11  小松  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetInsertDataForGaikanKensaShosaiALOutput : IGetInsertDataForGaikanKensaShosaiALOutput
    {
        /// <summary>
        /// SuishitsuIraiInfo
        /// </summary>
        public SuishitsuKensaUketsukeShosaiDataSet.SuishitsuIraiInfoDataTable SuishitsuIraiInfo { get; set; }

        /// <summary>
        /// KensaDaichoDtlTblDataTable
        /// </summary>
        public KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable KensaDaichoDtlTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetInsertDataForGaikanKensaShosaiApplicationLogic
    /// <summary>
    /// 詳細画面表示情報取得（依頼取込時の詳細画面表示用）
    /// 依頼取込時は、検査台帳、依頼、結果テーブルは存在しないので、ダミーのレコードを準備して変更項目や表示項目を受け渡す。
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/11  小松  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetInsertDataForGaikanKensaShosaiApplicationLogic : BaseApplicationLogic<IGetInsertDataForGaikanKensaShosaiALInput, IGetInsertDataForGaikanKensaShosaiALOutput>
    {
        #region 定義

        public enum OperationErr
        {
            NoDataFound,     // データ無し
        }

        #endregion

        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "SuishitsuKensaIraiUketsukeList：GetInsertDataForGaikanKensaShosai";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetInsertDataForGaikanKensaShosaiApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/11  小松  　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetInsertDataForGaikanKensaShosaiApplicationLogic()
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
        /// 2014/12/11  小松  　    新規作成
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
        /// 2014/12/11  小松  　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetInsertDataForGaikanKensaShosaiALOutput Execute(IGetInsertDataForGaikanKensaShosaiALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetInsertDataForGaikanKensaShosaiALOutput output = new GetInsertDataForGaikanKensaShosaiALOutput();

            try
            {
                // 現在日時
                DateTime _currentDateTime = Boundary.Common.Common.GetCurrentTimestamp();

                // 表示用
                {
                    // 水質検査依頼情報取得
                    IGetSuishitsuIraiInfoByKensaIraiKeyBLInput suishitsuInput = new GetSuishitsuIraiInfoByKensaIraiKeyBLInput();
                    // 外観検査（固定）
                    suishitsuInput.KensaIraiHoteiKbn = input.ListRow.KensaIraiHoteiKbn;
                    suishitsuInput.KensaIraiHokenjoCd = input.ListRow.KensaIraiHokenjoCd;
                    suishitsuInput.KensaIraiNendo = input.ListRow.KensaIraiNendo;
                    suishitsuInput.KensaIraiRenban = input.ListRow.KensaIraiRenban;

                    // 検索実行
                    output.SuishitsuIraiInfo = new GetSuishitsuIraiInfoByKensaIraiKeyBusinessLogic().Execute(suishitsuInput).SuishitsuIraiInfo;

                    if (output.SuishitsuIraiInfo.Count == 0)
                    {
                        throw new CustomException((int)ResultCode.OperationError, (int)OperationErr.NoDataFound, string.Empty);
                    }
                }
                // 更新用
                {
                    // 検査台帳明細
                    output.KensaDaichoDtlTblDT = new KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable();
                    KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow row = output.KensaDaichoDtlTblDT.NewKensaDaichoDtlTblRow();
                    // 編集対象項目
                    {
                        // 透視度
                        row.KeiryoShomeiKekkaValue = input.ListRow.Toshido;
                    }
                    row.KensaKbn = "2";
                    row.IraiNendo = input.IraiNendo;
                    row.ShishoCd = input.ShishoCd;
                    row.SuishitsuKensaIraiNo = input.ListRow.KentaiNo;
                    row.ShikenkoumokuCd = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_048, Constants.ConstRenbanConstanst.CONST_RENBAN_002);
                    row.SaikensaKbn = "0";
                    row.InsertDt = _currentDateTime;
                    row.InsertUser = string.Empty;
                    row.InsertTarm = string.Empty;
                    row.UpdateDt = _currentDateTime;
                    row.UpdateUser = string.Empty;
                    row.UpdateTarm = string.Empty;
                    output.KensaDaichoDtlTblDT.AddKensaDaichoDtlTblRow(row);
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
