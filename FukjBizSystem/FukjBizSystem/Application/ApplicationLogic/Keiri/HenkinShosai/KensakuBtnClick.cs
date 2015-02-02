using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaTorisageList;
using FukjBizSystem.Application.BusinessLogic.Keiri.HenkinShosai;
using FukjBizSystem.Application.BusinessLogic.Keiri.NyukinShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Keiri.HenkinShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKensakuBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/05　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKensakuBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// 入金No
        /// </summary>
        string NyukinNo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensakuBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/05　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickALInput : IKensakuBtnClickALInput
    {
        /// <summary>
        /// 入金No
        /// </summary>
        public string NyukinNo { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("入金No[{0}]", NyukinNo);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKensakuBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/05　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKensakuBtnClickALOutput
    {
        /// <summary>
        /// HenkinShosaiDataTable
        /// </summary>
        HenkinTblDataSet.HenkinShosaiDataTable HenkinShosaiDataTable { get; set; }

        /// <summary>
        /// HekinShosaiHdrDataTable
        /// </summary>
        HenkinTblDataSet.HekinShosaiHdrDataTable HekinShosaiHdrDataTable { get; set; }
        
        // 2014.12.28 toyoda Delete Start
        ///// <summary>
        ///// 入金テーブル
        ///// </summary>
        //NyukinTblDataSet.NyukinTblDataTable NyukinTblDataTable { get; set; }

        ///// <summary>
        ///// 繰越金テーブル
        ///// </summary>
        //KurikoshiKinTblDataSet.KurikoshiKinTblDataTable KurikoshiKinTblDataTable { get; set; }

        ///// <summary>
        ///// 検査依頼テーブル
        ///// </summary>
        //KensaIraiTblDataSet.KensaIraiTblDataTable KensaIraiTblDataTable { get; set; }

        ///// <summary>
        ///// 前受金テーブル
        ///// </summary>
        //MaeukekinTblDataSet.MaeukekinTblDataTable MaeukekinTblDataTable { get; set; }
        // 2014.12.28 toyoda Delete End
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensakuBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/05　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickALOutput : IKensakuBtnClickALOutput
    {
        /// <summary>
        /// HenkinShosaiDataTable
        /// </summary>
        public HenkinTblDataSet.HenkinShosaiDataTable HenkinShosaiDataTable { get; set; }

        /// <summary>
        /// HekinShosaiHdrDataTable
        /// </summary>
        public HenkinTblDataSet.HekinShosaiHdrDataTable HekinShosaiHdrDataTable { get; set; }

        // 2014.12.28 toyoda Delete Start
        ///// <summary>
        ///// 入金テーブル
        ///// </summary>
        //public NyukinTblDataSet.NyukinTblDataTable NyukinTblDataTable { get; set; }

        ///// <summary>
        ///// 繰越金テーブル
        ///// </summary>
        //public KurikoshiKinTblDataSet.KurikoshiKinTblDataTable KurikoshiKinTblDataTable { get; set; }

        ///// <summary>
        ///// 検査依頼テーブル
        ///// </summary>
        //public KensaIraiTblDataSet.KensaIraiTblDataTable KensaIraiTblDataTable { get; set; }

        ///// <summary>
        ///// 前受金テーブル
        ///// </summary>
        //public MaeukekinTblDataSet.MaeukekinTblDataTable MaeukekinTblDataTable { get; set; }
        // 2014.12.28 toyoda Delete End
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensakuBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/05　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickApplicationLogic : BaseApplicationLogic<IKensakuBtnClickALInput, IKensakuBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "HenkinShosai：KensakuBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensakuBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/05　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensakuBtnClickApplicationLogic()
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
        /// 2014/11/05　AnhNV　　    新規作成
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
        /// 2014/11/05　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IKensakuBtnClickALOutput Execute(IKensakuBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKensakuBtnClickALOutput output = new KensakuBtnClickALOutput();

            try
            {
                // Header
                IGetHenkinShosaiHdrByNyukinNoBLInput hdrInput = new GetHenkinShosaiHdrByNyukinNoBLInput();
                hdrInput.NyukinNo = input.NyukinNo;
                IGetHenkinShosaiHdrByNyukinNoBLOutput hdrOutput = new GetHenkinShosaiHdrByNyukinNoBusinessLogic().Execute(hdrInput);
                output.HekinShosaiHdrDataTable = hdrOutput.HekinShosaiHdrDataTable;

                // GridView
                IGetHenkinShosaiByNyukinNoBLInput henkinInput = new GetHenkinShosaiByNyukinNoBLInput();
                henkinInput.NyukinNo = input.NyukinNo;
                IGetHenkinShosaiByNyukinNoBLOutput henkinOutput = new GetHenkinShosaiByNyukinNoBusinessLogic().Execute(henkinInput);
                output.HenkinShosaiDataTable = henkinOutput.HenkinShosaiDataTable;
                
                // 2014.12.28 toyoda Delete Start
                //// Get 入金テーブル info
                //IGetNyukinTblInfoBLOutput nyOutput = new GetNyukinTblInfoBusinessLogic().Execute(new GetNyukinTblInfoBLInput());
                //output.NyukinTblDataTable = nyOutput.NyukinTblDataTable;
                //// Get 繰越金テーブル info
                //IGetKurikoshiKinTblInfoBLOutput kuOutput = new GetKurikoshiKinTblInfoBusinessLogic().Execute(new GetKurikoshiKinTblInfoBLInput());
                //output.KurikoshiKinTblDataTable = kuOutput.KurikoshiKinTblDataTable;
                //// Get 検査依頼テーブル info
                //IGetKensaIraiTblInfoBLOutput kitOutput = new GetKensaIraiTblInfoBusinessLogic().Execute(new GetKensaIraiTblInfoBLInput());
                //output.KensaIraiTblDataTable = kitOutput.KensaIraiTblDataTable;
                //// Get 前受金テーブル info
                //IGetMaeukekinTblInfoBLOutput maOutput = new GetMaeukekinTblInfoBusinessLogic().Execute(new GetMaeukekinTblInfoBLInput());
                //output.MaeukekinTblDataTable = maOutput.MaeukekinTblDataTable;
                // 2014.12.28 toyoda Delete End
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
