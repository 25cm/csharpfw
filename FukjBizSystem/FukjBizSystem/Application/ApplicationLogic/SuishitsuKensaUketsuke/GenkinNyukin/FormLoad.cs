using Zynas.Framework.Core.Base.ApplicationLogic;
using FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke.GenkinNyukin;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Utility;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaTorisageList;

namespace FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaUketsuke.GenkinNyukin
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IFormLoadALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALInput : IBseALInput
    {
        #region プロパティ

        /// <summary>
        /// KensaKbn
        /// </summary>
        string KensaKbn { get; set; }

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

        /// <summary>
        /// KeiryoShomeiIraiNendo 
        /// </summary>
        string KeiryoShomeiIraiNendo { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiSishoCd 
        /// </summary>
        string KeiryoShomeiIraiSishoCd { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiRenban 
        /// </summary>
        string KeiryoShomeiIraiRenban { get; set; }

        #endregion
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FormLoadALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALInput : IFormLoadALInput
    {
        #region プロパティ
        /// <summary>
        /// KensaKbn
        /// </summary>
        public string KensaKbn { get; set; }

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

        /// <summary>
        /// KeiryoShomeiIraiNendo 
        /// </summary>
        public string KeiryoShomeiIraiNendo { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiSishoCd 
        /// </summary>
        public string KeiryoShomeiIraiSishoCd { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiRenban 
        /// </summary>
        public string KeiryoShomeiIraiRenban { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                string dataString = string.Empty;
                if (KensaKbn.Equals("1"))
                {
                    dataString += string.Format("検査依頼法定区分[{0}], 検査依頼保健所コード[{1}], 検査依頼年度[{2}], 検査依頼連番[{3}]", 
                                                    KensaIraiHoteiKbn, KensaIraiHokenjoCd, KensaIraiNendo, KensaIraiRenban);
                }
                else
                {
                    dataString += string.Format("計量証明依頼年度[{0}], 計量証明支所コード[{1}], 計量証明依頼連番[{2}]", 
                                                    KeiryoShomeiIraiNendo, KeiryoShomeiIraiSishoCd, KeiryoShomeiIraiRenban);
                }
                return dataString;
            }
        }

        #endregion
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IFormLoadALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALOutput
    {
        NyukinTblDataSet.GenkinNyukinTblDataTable GenkinNyukinTblDataTable { get; set; }
        KensaIraiTblDataSet.KensaIraiTblDataTable KensaIraiTblDataTable { get; set; }
        KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable KeiryoShomeiIraiTblDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FormLoadALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALOutput : IFormLoadALOutput
    {
        /// <summary>
        /// GenkinNyukinTblDataTable
        /// </summary>
        public NyukinTblDataSet.GenkinNyukinTblDataTable GenkinNyukinTblDataTable { get; set; }
        /// <summary>
        /// KensaIraiTblDataTable
        /// </summary>
        public KensaIraiTblDataSet.KensaIraiTblDataTable KensaIraiTblDataTable { get; set; }
        /// <summary>
        /// KeiryoShomeiIraiTblDataTable
        /// </summary>
        public KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable KeiryoShomeiIraiTblDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FormLoadApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadApplicationLogic : BaseApplicationLogic<IFormLoadALInput, IFormLoadALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "GenkinNyukin：FormLoad";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： FormLoadApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public FormLoadApplicationLogic()
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
        /// 2014/11/19  ThanhVX　    新規作成
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
        /// 2014/11/19  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IFormLoadALOutput Execute(IFormLoadALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IFormLoadALOutput output = new FormLoadALOutput();
            try
            {
                if (input.KensaKbn.Equals("1"))
                {                    
                    IGetGenkinNyukinKbnOneByCondBLInput blInput = new GetGenkinNyukinKbnOneByCondBLInput();
                    blInput.KensaIraiHokenjoCd = input.KensaIraiHokenjoCd;
                    blInput.KensaIraiHoteiKbn = input.KensaIraiHoteiKbn;
                    blInput.KensaIraiNendo = input.KensaIraiNendo;
                    blInput.KensaIraiRenban = input.KensaIraiRenban;
                    output.GenkinNyukinTblDataTable = new GetGenkinNyukinKbnOneByCondBusinessLogic().Execute(blInput).GenkinNyukinTblDataTable;
                    
                    IGetKensaIraiTblByKeyBLInput blByKeyInput = new GetKensaIraiTblByKeyBLInput();
                    blByKeyInput.KensaIraiHokenjoCd = input.KensaIraiHokenjoCd;
                    blByKeyInput.KensaIraiHoteiKbn = input.KensaIraiHoteiKbn;
                    blByKeyInput.KensaIraiNendo = input.KensaIraiNendo;
                    blByKeyInput.KensaIraiRenban = input.KensaIraiRenban;
                    output.KensaIraiTblDataTable = new GetKensaIraiTblByKeyBusinessLogic().Execute(blByKeyInput).KensaIraiTblDataTable;
                }
                else
                {
                    IGetGenkinNyukinKbnTwoByCondBLInput blInput = new GetGenkinNyukinKbnTwoByCondBLInput();
                    blInput.KeiryoShomeiIraiNendo = input.KeiryoShomeiIraiNendo;
                    blInput.KeiryoShomeiIraiRenban = input.KeiryoShomeiIraiRenban;
                    blInput.KeiryoShomeiIraiSishoCd = input.KeiryoShomeiIraiSishoCd;
                    output.GenkinNyukinTblDataTable = new GetGenkinNyukinKbnTwoByCondBusinessLogic().Execute(blInput).GenkinNyukinTblDataTable;

                    IGetKeiryoShomeiIraiTblByKeyBLInput blByKeyInput = new GetKeiryoShomeiIraiTblByKeyBLInput();
                    blByKeyInput.KeiryoShomeiIraiNendo = input.KeiryoShomeiIraiNendo;
                    blByKeyInput.KeiryoShomeiIraiRenban = input.KeiryoShomeiIraiRenban;
                    blByKeyInput.KeiryoShomeiIraiSishoCd = input.KeiryoShomeiIraiSishoCd;
                    output.KeiryoShomeiIraiTblDataTable = new GetKeiryoShomeiIraiTblByKeyBusinessLogic().Execute(blByKeyInput).KeiryoShomeiIraiTblDT;
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