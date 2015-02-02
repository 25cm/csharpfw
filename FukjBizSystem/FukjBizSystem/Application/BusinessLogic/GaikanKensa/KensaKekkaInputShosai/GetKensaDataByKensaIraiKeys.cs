using System.Reflection;
using FukjBizSystem.Application.DataAccess.GaikanKensaKekkaTbl;
using FukjBizSystem.Application.DataAccess.JokasoMemoTbl;
using FukjBizSystem.Application.DataAccess.KensaIraiTbl;
using FukjBizSystem.Application.DataAccess.KensaKekkaTbl;
using FukjBizSystem.Application.DataAccess.MaeukekinTbl;
using FukjBizSystem.Application.DataAccess.SaiSaisuiTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;
using FukjBizSystem.Application.DataAccess.KensaIraiKanrenFileTbl;

namespace FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaKekkaInputShosai
{
    #region KensaOutputTable
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaOutputTable
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/30　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensaOutputTable
    {
        /// <summary>
        /// CheckList75DataTable
        /// </summary>
        public GaikanKensaKekkaTblDataSet.CheckList75DataTable CheckList75DataTable { get; set; }

        /// <summary>
        /// MemoInputDataTable
        /// </summary>
        public GaikanKensaKekkaTblDataSet.MemoInputDataTable MemoInputDataTable { get; set; }

        /// <summary>
        /// KensaKekkaFooterDataTable
        /// </summary>
        public GaikanKensaKekkaTblDataSet.KensaKekkaFooterDataTable KensaKekkaFooterDataTable { get; set; }

        /// <summary>
        /// KensaFukaListDataTable
        /// </summary>
        public KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable KensaIraiKanrenFileTblDT { get; set; }

        /// <summary>
        /// KensaKekkaInputShosaiDataTable
        /// </summary>
        public GaikanKensaKekkaTblDataSet.KensaKekkaInputShosaiDataTable KensaKekkaInputShosaiDataTable { get; set; }

        ///// <summary>
        ///// 前受金テーブル
        ///// </summary>
        //public MaeukekinTblDataSet.MaeukekinTblDataTable MaeukekinTblDataTable { get; set; }

        /// <summary>
        /// MaeukekinNyukinDataTable
        /// </summary>
        public MaeukekinTblDataSet.MaeukekinNyukinDataTable MaeukekinNyukinDataTable { get; set; }

        /// <summary>
        /// KakoKensaJohoDataTable
        /// </summary>
        public GaikanKensaKekkaTblDataSet.KakoKensaJohoDataTable KakoKensaJohoDataTable { get; set; }

        #region Update tables
        /// <summary>
        /// 検査依頼テーブル
        /// </summary>
        public KensaIraiTblDataSet.KensaIraiTblDataTable KensaIraiTblDataTable { get; set; }

        /// <summary>
        /// 検査結果テーブル
        /// </summary>
        public KensaKekkaTblDataSet.KensaKekkaTblDataTable KensaKekkaTblDataTable { get; set; }

        /// <summary>
        /// 外観検査結果テーブル
        /// </summary>
        public GaikanKensaKekkaTblDataSet.GaikanKensaKekkaTblDataTable GaikanKensaKekkaTblDataTable { get; set; }

        /// <summary>
        /// 再採水テーブル
        /// </summary>
        public SaiSaisuiTblDataSet.SaiSaisuiTblDataTable SaiSaisuiTblDataTable { get; set; }

        /// <summary>
        /// 浄化槽定型メモテーブル
        /// </summary>
        public JokasoMemoTblDataSet.JokasoMemoTblDataTable JokasoMemoTblDataTable { get; set; }

        /// <summary>
        /// 所見結果テーブル
        /// </summary>
        public GaikanKensaKekkaTblDataSet.ShokenKekkaListDataTable ShokenKekkaList { get; set; }

        /// <summary>
        /// 所見結果補足テーブル
        /// </summary>
        public GaikanKensaKekkaTblDataSet.ShokenKekkaHosokuListDataTable ShokenKekkaHosokuList { get; set; }

        #endregion
    }
    #endregion

    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaDataByKensaIraiKeysBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/23　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaDataByKensaIraiKeysBLInput
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

        /// <summary>
        /// 水質検査持込日付
        /// </summary>
        string KensaKekkaMochikomiDt { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaDataByKensaIraiKeysBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/23　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaDataByKensaIraiKeysBLInput : IGetKensaDataByKensaIraiKeysBLInput
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

        /// <summary>
        /// 水質検査持込日付
        /// </summary>
        public string KensaKekkaMochikomiDt { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaDataByKensaIraiKeysBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/23　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaDataByKensaIraiKeysBLOutput
    {
        /// <summary>
        /// KensaOutputTable
        /// </summary>
        KensaOutputTable KensaOutputTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaDataByKensaIraiKeysBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/23　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaDataByKensaIraiKeysBLOutput : IGetKensaDataByKensaIraiKeysBLOutput
    {
        /// <summary>
        /// KensaOutputTable
        /// </summary>
        public KensaOutputTable KensaOutputTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaDataByKensaIraiKeysBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/23　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaDataByKensaIraiKeysBusinessLogic : BaseBusinessLogic<IGetKensaDataByKensaIraiKeysBLInput, IGetKensaDataByKensaIraiKeysBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKensaDataByKensaIraiKeysBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/23　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKensaDataByKensaIraiKeysBusinessLogic()
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
        /// 2014/10/23　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKensaDataByKensaIraiKeysBLOutput Execute(IGetKensaDataByKensaIraiKeysBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKensaDataByKensaIraiKeysBLOutput output = new GetKensaDataByKensaIraiKeysBLOutput();

            try
            {
                output.KensaOutputTable = new KensaOutputTable();

                // 外観検査項目データ取得
                ISelectCheckList75DAInput cl75Input = new SelectCheckList75DAInput();
                cl75Input.KensaIraiHoteiKbn = input.KensaIraiHoteiKbn;
                cl75Input.KensaIraiHokenjoCd = input.KensaIraiHokenjoCd;
                cl75Input.KensaIraiNendo = input.KensaIraiNendo;
                cl75Input.KensaIraiRenban = input.KensaIraiRenban;
                ISelectCheckList75DAOutput cl75Output = new SelectCheckList75DataAccess().Execute(cl75Input);
                output.KensaOutputTable.CheckList75DataTable = cl75Output.CheckList75DataTable;

                // 所見結果データ取得
                ISelectKensaKekkaFooterByCondDAInput footerInput = new SelectKensaKekkaFooterByCondDAInput();
                footerInput.KensaIraiHoteiKbn = input.KensaIraiHoteiKbn;
                footerInput.KensaIraiHokenjoCd = input.KensaIraiHokenjoCd;
                footerInput.KensaIraiNendo = input.KensaIraiNendo;
                footerInput.KensaIraiRenban = input.KensaIraiRenban;
                ISelectKensaKekkaFooterByCondDAOutput footerOutput = new SelectKensaKekkaFooterByCondDataAccess().Execute(footerInput);
                output.KensaOutputTable.KensaKekkaFooterDataTable = footerOutput.KensaKekkaFooterDataTable;

                // メモデータ取得
                ISelectMemoInputByCondDAInput memoInput = new SelectMemoInputByCondDAInput();
                memoInput.KensaIraiHoteiKbn = input.KensaIraiHoteiKbn;
                memoInput.KensaIraiHokenjoCd = input.KensaIraiHokenjoCd;
                memoInput.KensaIraiNendo = input.KensaIraiNendo;
                memoInput.KensaIraiRenban = input.KensaIraiRenban;
                ISelectMemoInputByCondDAOutput memoOutput = new SelectMemoInputByCondDataAccess().Execute(memoInput);
                output.KensaOutputTable.MemoInputDataTable = memoOutput.MemoInputDataTable;

                // 検査付加情報データ取得
                ISelectKensaIraiKanrenFileTblByKensaIraiNoDAInput fukaInput = new SelectKensaIraiKanrenFileTblByKensaIraiNoDAInput();
                fukaInput.KensaIraiHoteiKbn = input.KensaIraiHoteiKbn;
                fukaInput.KensaIraiHokenjoCd = input.KensaIraiHokenjoCd;
                fukaInput.KensaIraiNendo = input.KensaIraiNendo;
                fukaInput.KensaIraiRenban = input.KensaIraiRenban;
                ISelectKensaIraiKanrenFileTblByKensaIraiNoDAOutput fukaOutput = new SelectKensaIraiKanrenFileTblByKensaIraiNoDataAccess().Execute(fukaInput);
                output.KensaOutputTable.KensaIraiKanrenFileTblDT = fukaOutput.KensaIraiKanrenFileTblDT;

                // Get 前受金テーブル
                ISelectMaeukekinNyukinByKensaIraiKeyDAInput maeInput = new SelectMaeukekinNyukinByKensaIraiKeyDAInput();
                maeInput.KensaIraiHoteiKbn = input.KensaIraiHoteiKbn;
                maeInput.KensaIraiHokenjoCd = input.KensaIraiHokenjoCd;
                maeInput.KensaIraiNendo = input.KensaIraiNendo;
                maeInput.KensaIraiRenban = input.KensaIraiRenban;
                ISelectMaeukekinNyukinByKensaIraiKeyDAOutput maeOutput = new SelectMaeukekinNyukinByKensaIraiKeyDataAccess().Execute(maeInput);
                output.KensaOutputTable.MaeukekinNyukinDataTable = maeOutput.MaeukekinNyukinDataTable;

                // Display table
                ISelectKensaKekkaInputShosaiByKeyDAInput kekkaInput = new SelectKensaKekkaInputShosaiByKeyDAInput();
                kekkaInput.KensaIraiHoteiKbn = input.KensaIraiHoteiKbn;
                kekkaInput.KensaIraiHokenjoCd = input.KensaIraiHokenjoCd;
                kekkaInput.KensaIraiNendo = input.KensaIraiNendo;
                kekkaInput.KensaIraiRenban = input.KensaIraiRenban;
                ISelectKensaKekkaInputShosaiByKeyDAOutput kekkaOutput = new SelectKensaKekkaInputShosaiByKeyDataAccess().Execute(kekkaInput);
                output.KensaOutputTable.KensaKekkaInputShosaiDataTable = kekkaOutput.KensaKekkaInputShosaiDataTable;

                // 過去の検査情報
                #region 過去の検査情報
                if (output.KensaOutputTable.KensaKekkaInputShosaiDataTable.Rows.Count > 0)
                {
                    ISelectKakoKensaJohoByJokasoKeyMochikomiDtDAInput kakoInput = new SelectKakoKensaJohoByJokasoKeyMochikomiDtDAInput();
                    kakoInput.KensaIraiJokasoHokenjoCd = output.KensaOutputTable.KensaKekkaInputShosaiDataTable[0].KensaIraiJokasoHokenjoCd;
                    kakoInput.KensaIraiJokasoTorokuNendo = output.KensaOutputTable.KensaKekkaInputShosaiDataTable[0].KensaIraiJokasoTorokuNendo;
                    kakoInput.KensaIraiJokasoRenban = output.KensaOutputTable.KensaKekkaInputShosaiDataTable[0].KensaIraiJokasoRenban;
                    kakoInput.KensaKekkaMochikomiDt = input.KensaKekkaMochikomiDt;
                    ISelectKakoKensaJohoByJokasoKeyMochikomiDtDAOutput kakoOutput = new SelectKakoKensaJohoByJokasoKeyMochikomiDtDataAccess().Execute(kakoInput);
                    output.KensaOutputTable.KakoKensaJohoDataTable = kakoOutput.KakoKensaJohoDataTable;
                }
                #endregion

                #region Get update tables
                // Select 検査依頼テーブル by key
                ISelectKensaIraiTblByKeyDAInput kitInput = new SelectKensaIraiTblByKeyDAInput();
                kitInput.KensaIraiHoteiKbn = input.KensaIraiHoteiKbn;
                kitInput.KensaIraiHokenjoCd = input.KensaIraiHokenjoCd;
                kitInput.KensaIraiNendo = input.KensaIraiNendo;
                kitInput.KensaIraiRenban = input.KensaIraiRenban;
                ISelectKensaIraiTblByKeyDAOutput kitOutput = new SelectKensaIraiTblByKeyDataAccess().Execute(kitInput);
                output.KensaOutputTable.KensaIraiTblDataTable = kitOutput.KensaIraiTblDataTable;

                // Select 検査結果テーブル by key
                ISelectKensaKekkaTblByKeyDAInput kktInput = new SelectKensaKekkaTblByKeyDAInput();
                kktInput.KensaKekkaIraiHokenjoCd = input.KensaIraiHokenjoCd;
                kktInput.KensaKekkaIraiHoteiKbn = input.KensaIraiHoteiKbn;
                kktInput.KensaKekkaIraiNendo = input.KensaIraiNendo;
                kktInput.KensaKekkaIraiRenban = input.KensaIraiRenban;
                ISelectKensaKekkaTblByKeyDAOutput kktOutput = new SelectKensaKekkaTblByKeyDataAccess().Execute(kktInput);
                output.KensaOutputTable.KensaKekkaTblDataTable = kktOutput.KensaKekkaTblDataTable;

                // Select by 外観検査結果テーブル by KensaIrai key
                ISelectGaikanKensaKekkaTblByKensaIraiKeyDAInput gkktInput = new SelectGaikanKensaKekkaTblByKensaIraiKeyDAInput();
                gkktInput.KensaIraiHokenjoCd = input.KensaIraiHokenjoCd;
                gkktInput.KensaIraiHoteiKbn = input.KensaIraiHoteiKbn;
                gkktInput.KensaIraiNendo = input.KensaIraiNendo;
                gkktInput.KensaIraiRenban = input.KensaIraiRenban;
                ISelectGaikanKensaKekkaTblByKensaIraiKeyDAOutput gkktOutput = new SelectGaikanKensaKekkaTblByKensaIraiKeyDataAccess().Execute(gkktInput);
                output.KensaOutputTable.GaikanKensaKekkaTblDataTable = gkktOutput.GaikanKensaKekkaTblDataTable;

                // Select 再採水テーブル by KensaIrai key
                ISelectSaiSaisuiTblByKeyDAInput sstInput = new SelectSaiSaisuiTblByKeyDAInput();
                sstInput.SaiSaisuiIraiHokenjoCd = input.KensaIraiHokenjoCd;
                sstInput.SaiSaisuiIraiHoteiKbn = input.KensaIraiHoteiKbn;
                sstInput.SaiSaisuiIraiNendo = input.KensaIraiNendo;
                sstInput.SaiSaisuiIraiRrenban = input.KensaIraiRenban;
                ISelectSaiSaisuiTblByKeyDAOutput sstOutput = new SelectSaiSaisuiTblByKeyDataAccess().Execute(sstInput);
                output.KensaOutputTable.SaiSaisuiTblDataTable = sstOutput.SaiSaisuiTblDataTable;

                // Select 浄化槽定型メモテーブル info
                ISelectJokasoMemoTblInfoDAOutput jmOutput = new SelectJokasoMemoTblInfoDataAccess().Execute(new SelectJokasoMemoTblInfoDAInput());
                output.KensaOutputTable.JokasoMemoTblDataTable = jmOutput.JokasoMemoTblDataTable;
                #endregion

                #region 所見関連取得
                // 所見情報を取得
                ISelectShokenKekkaListByKensaIraiDAInput shokenInput = new SelectShokenKekkaListByKensaIraiDAInput();
                shokenInput.IraiHoteiKbn = input.KensaIraiHoteiKbn;
                shokenInput.IraiHokenjoCd = input.KensaIraiHokenjoCd;
                shokenInput.IraiNendo = input.KensaIraiNendo;
                shokenInput.IraiRenban = input.KensaIraiRenban;
                ISelectShokenKekkaListByKensaIraiDAOutput shokenOutput = new SelectShokenKekkaListByKensaIraiDataAccess().Execute(shokenInput);
                output.KensaOutputTable.ShokenKekkaList = shokenOutput.ShokenKekkaList;

                // 所見補足情報を取得
                ISelectShokenKekkaHosokuListByKensaIraiDAInput shokenHosokuInput = new SelectShokenKekkaHosokuListByKensaIraiDAInput();
                shokenHosokuInput.IraiHoteiKbn = input.KensaIraiHoteiKbn;
                shokenHosokuInput.IraiHokenjoCd = input.KensaIraiHokenjoCd;
                shokenHosokuInput.IraiNendo = input.KensaIraiNendo;
                shokenHosokuInput.IraiRenban = input.KensaIraiRenban;
                ISelectShokenKekkaHosokuListByKensaIraiDAOutput shokenHosokuOutput = new SelectShokenKekkaHosokuListByKensaIraiDataAccess().Execute(shokenHosokuInput);
                output.KensaOutputTable.ShokenKekkaHosokuList = shokenHosokuOutput.ShokenKekkaHosokuList;
                #endregion
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
