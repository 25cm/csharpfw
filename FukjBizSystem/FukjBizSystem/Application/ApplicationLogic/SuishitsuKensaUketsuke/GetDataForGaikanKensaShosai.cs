using System;
using System.Reflection;
using FukjBizSystem.Application.Boundary.SuishitsuKensaUketsuke;
using FukjBizSystem.Application.BusinessLogic.Common;
using FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.Utility;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaUketsuke
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetDataForGaikanKensaShosaiALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/08  　　  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetDataForGaikanKensaShosaiALInput : IBseALInput
    {
        /// <summary>
        /// KensaIraiHoteiKbn
        /// </summary>
        string KensaIraiHoteiKbn { get; set; }

        /// <summary>
        /// KensaIraiHokenjoCd
        /// </summary>
        string KensaIraiHokenjoCd { get; set; }

        /// <summary>
        /// KensaIraiNendo
        /// </summary>
        string KensaIraiNendo { get; set; }

        /// <summary>
        /// KensaIraiRenban
        /// </summary>
        string KensaIraiRenban { get; set; }

        /// <summary>
        /// 検査区分 
        /// </summary>
        string KensaKbn { get; set; }

        /// <summary>
        /// 依頼年度 
        /// </summary>
        string IraiNendo { get; set; }

        /// <summary>
        /// 支所コード 
        /// </summary>
        string Sisho { get; set; }

        /// <summary>
        /// 依頼番号 
        /// </summary>
        string IraiNo { get; set; }

        /// <summary>
        /// 取込結果一覧データ
        /// </summary>
        SuishitsuKensaIraiDataSet.UketsukeImportListRow ListRow { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetDataForGaikanKensaShosaiALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/08  　　  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetDataForGaikanKensaShosaiALInput : IGetDataForGaikanKensaShosaiALInput
    {
        /// <summary>
        /// KensaIraiHoteiKbn
        /// </summary>
        public string KensaIraiHoteiKbn { get; set; }

        /// <summary>
        /// KensaIraiHokenjoCd
        /// </summary>
        public string KensaIraiHokenjoCd { get; set; }

        /// <summary>
        /// KensaIraiNendo
        /// </summary>
        public string KensaIraiNendo { get; set; }

        /// <summary>
        /// KensaIraiRenban
        /// </summary>
        public string KensaIraiRenban { get; set; }

        /// <summary>
        /// 検査区分 
        /// </summary>
        public string KensaKbn { get; set; }

        /// <summary>
        /// 依頼年度 
        /// </summary>
        public string IraiNendo { get; set; }

        /// <summary>
        /// 支所コード 
        /// </summary>
        public string Sisho { get; set; }

        /// <summary>
        /// 依頼番号 
        /// </summary>
        public string IraiNo { get; set; }

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
    //  インターフェイス名 ： IGetDataForGaikanKensaShosaiALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/08  　　  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetDataForGaikanKensaShosaiALOutput : IGetSuishitsuIraiInfoByKensaIraiKeyBLOutput, IGetKensaDaichoDtlTblByKeyBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetDataForGaikanKensaShosaiALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/08  　　  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetDataForGaikanKensaShosaiALOutput : IGetDataForGaikanKensaShosaiALOutput
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
    //  クラス名 ： GetDataForGaikanKensaShosaiApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/08  　　  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetDataForGaikanKensaShosaiApplicationLogic : BaseApplicationLogic<IGetDataForGaikanKensaShosaiALInput, IGetDataForGaikanKensaShosaiALOutput>
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
        private const string FunctionName = "SuishitsuKensaIraiUketsukeGaikanKensaShosai：GetDataForGaikanKensaShosai";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetDataForGaikanKensaShosaiApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/08  　　  　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetDataForGaikanKensaShosaiApplicationLogic()
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
        /// 2014/12/08  　　  　    新規作成
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
        /// 2014/12/08  　　  　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetDataForGaikanKensaShosaiALOutput Execute(IGetDataForGaikanKensaShosaiALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetDataForGaikanKensaShosaiALOutput output = new GetDataForGaikanKensaShosaiALOutput();

            try
            {
                // 水質検査依頼情報取得
                {
                    IGetSuishitsuIraiInfoByKensaIraiKeyBLInput suishitsuInput = new GetSuishitsuIraiInfoByKensaIraiKeyBLInput();
                    // 外観検査（固定）
                    suishitsuInput.KensaIraiHoteiKbn = input.KensaIraiHoteiKbn;
                    suishitsuInput.KensaIraiHokenjoCd = input.KensaIraiHokenjoCd;
                    suishitsuInput.KensaIraiNendo = input.KensaIraiNendo;
                    suishitsuInput.KensaIraiRenban = input.KensaIraiRenban;

                    // 検索実行
                    output.SuishitsuIraiInfo = new GetSuishitsuIraiInfoByKensaIraiKeyBusinessLogic().Execute(suishitsuInput).SuishitsuIraiInfo;

                    if (output.SuishitsuIraiInfo.Count == 0)
                    {
                        throw new CustomException((int)ResultCode.OperationError, (int)OperationErr.NoDataFound, string.Empty);
                    }
                }

                // 検査台帳明細取得
                {
                    IGetKensaDaichoDtlTblByKeyBLInput daichoInput = new GetKensaDaichoDtlTblByKeyBLInput();
                    daichoInput.Kbn = input.KensaKbn;
                    daichoInput.IraiNendo = input.IraiNendo;
                    daichoInput.Sisho = input.Sisho;
                    daichoInput.IraiNo = input.IraiNo;
                    // Tr（透視度）（固定）
                    daichoInput.ShikenkoumokuCd = FukjBizSystem.Application.Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_048, Constants.ConstRenbanConstanst.CONST_RENBAN_002);
                    daichoInput.SaikensaKbn = "0";

                    // 検索実行
                    output.KensaDaichoDtlTblDT = new GetKensaDaichoDtlTblByKeyBusinessLogic().Execute(daichoInput).KensaDaichoDtlTblDT;

                    if (output.KensaDaichoDtlTblDT.Count == 0)
                    {
                        throw new CustomException((int)ResultCode.LockError, (int)OperationErr.NoDataFound, string.Empty);
                    }

                    // 編集対象項目
                    {
                        KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow row = output.KensaDaichoDtlTblDT[0];

                        // 透視度
                        row.KeiryoShomeiKekkaValue = input.ListRow.Toshido;
                    }
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
