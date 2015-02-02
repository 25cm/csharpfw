using System.Reflection;
using FukjBizSystem.Application.DataAccess.BushoMst;
using FukjBizSystem.Application.DataAccess.ShishoMst;
using FukjBizSystem.Application.DataAccess.ShokuinMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaHoryuShosai
{
    #region ComboBoxSources
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ComboBoxSources
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/08　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class ComboBoxSources
    {
        ///// <summary>
        ///// HoryuRiyuDataTable
        ///// </summary>
        //public KensaIraiTblDataSet.HoryuRiyuDataTable HoryuRiyuDataTable { get; set; }

        /// <summary>
        /// 職員マスタ
        /// </summary>
        public ShokuinMstDataSet.ShokuinMstDataTable TantoKensainDataTable { get; set; }

        ///// <summary>
        ///// UketsukeShisyoDataTable
        ///// </summary>
        //public KensaIraiTblDataSet.UketsukeShisyoDataTable UketsukeShisyoDataTable { get; set; }

        /// <summary>
        /// 支所マスタ
        /// </summary>
        public ShishoMstDataSet.ShishoMstDataTable ShishoMstDataTable { get; set; }

        /// <summary>
        /// 部署マスタ
        /// </summary>
        public BushoMstDataSet.BushoMstDataTable BushoMstDataTable { get; set; }

        /// <summary>
        /// 職員マスタ
        /// </summary>
        public ShokuinMstDataSet.ShokuinMstDataTable ShokuinMstDataTable { get; set; }
    }
    #endregion

    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetListComboBoxesBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/08　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetListComboBoxesBLInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetListComboBoxesBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/08　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetListComboBoxesBLInput : IGetListComboBoxesBLInput
    {
        
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetListComboBoxesBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/08　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetListComboBoxesBLOutput
    {
        /// <summary>
        /// ComboBoxSources
        /// </summary>
        ComboBoxSources ComboBoxSources { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetListComboBoxesBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/08　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetListComboBoxesBLOutput : IGetListComboBoxesBLOutput
    {
        /// <summary>
        /// ComboBoxSources
        /// </summary>
        public ComboBoxSources ComboBoxSources { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetListComboBoxesBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/08　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetListComboBoxesBusinessLogic : BaseBusinessLogic<IGetListComboBoxesBLInput, IGetListComboBoxesBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetListComboBoxesBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/08　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetListComboBoxesBusinessLogic()
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
        /// 2014/09/08　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetListComboBoxesBLOutput Execute(IGetListComboBoxesBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetListComboBoxesBLOutput output = new GetListComboBoxesBLOutput();

            try
            {
                output.ComboBoxSources = new ComboBoxSources();

                // Select ShishoMst info
                ISelectShishoMstInfoDAOutput shishoOutp = new SelectShishoMstInfoDataAccess().Execute(new SelectShishoMstInfoDAInput());
                output.ComboBoxSources.ShishoMstDataTable = shishoOutp.ShishoMstDT;

                // Select BushoMst info
                ISelectBushoMstInfoDAOutput bushoOutp = new SelectBushoMstInfoDataAccess().Execute(new SelectBushoMstInfoDAInput());
                output.ComboBoxSources.BushoMstDataTable = bushoOutp.BushoMstDT;

                // 2015/01/29 YSCHEW MOD Start
                //// Select ShokuinMst info
                //ISelectShokuinMstInfoDAOutput shokuinOutp = new SelectShokuinMstInfoDataAccess().Execute(new SelectShokuinMstInfoDAInput());
                //output.ComboBoxSources.ShokuinMstDataTable = shokuinOutp.ShokuinMstDataTable;
                SelectShokuinMstByShokuinTaishokuFlgDAInput taishokuFlgInput = new SelectShokuinMstByShokuinTaishokuFlgDAInput();
                taishokuFlgInput.ShokuinTaishokuFlg = "0";
                output.ComboBoxSources.ShokuinMstDataTable = new SelectShokuinMstByShokuinTaishokuFlgDataAccess().Execute(taishokuFlgInput).ShokuinMstDT;
                // 2015/01/29 YSCHEW MOD End

                // 2015/01/28 DatNT MOD Start
                // Select ShokuinMst by ShokuinKensainFlg & ShokuinTaishokuFlg
                ISelectShokuinMstByKensainFlgTaishokuFlgDAInput flgInput = new SelectShokuinMstByKensainFlgTaishokuFlgDAInput();
                flgInput.ShokuinKensainFlg = "1";
                flgInput.ShokuinTaishokuFlg = "0";
                output.ComboBoxSources.TantoKensainDataTable = new SelectShokuinMstByKensainFlgTaishokuFlgDataAccess().Execute(flgInput).ShokuinMstDT;
                //// Select ShokuinMst by ShokuinKensainFlg
                //ISelectShokuinMstByShokuinKensainFlgDAInput flgInput = new SelectShokuinMstByShokuinKensainFlgDAInput();
                //flgInput.ShokuinKensainFlg = "1";
                //ISelectShokuinMstByShokuinKensainFlgDAOutput flgOutput = new SelectShokuinMstByShokuinKensainFlgDataAccess().Execute(flgInput);
                //output.ComboBoxSources.TantoKensainDataTable = flgOutput.ShokuinMstDataTable;
                // 2015/01/28 DatNT MOD End

                //// Select KensaIrai
                //ISelectUketsukeShisyoDAOutput uketsukeOutp = new SelectUketsukeShisyoDataAccess().Execute(new SelectUketsukeShisyoDAInput());
                //ISelectHoryuRiyuDAOutput horiyuOutp = new SelectHoryuRiyuDataAccess().Execute(new SelectHoryuRiyuDAInput());

                //// KensaIrai Output
                //output.ComboBoxSources.UketsukeShisyoDataTable = uketsukeOutp.UketsukeShisyoDataTable;
                //output.ComboBoxSources.HoryuRiyuDataTable = horiyuOutp.HoryuRiyuDataTable;
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
