using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Master.BushoMstList;
using FukjBizSystem.Application.BusinessLogic.Master.ShokenList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Master.ShokenList
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
    /// 2014/08/22　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALInput : IBseALInput
    {
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
    /// 2014/08/22　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALInput : IFormLoadALInput
    {

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
    //  インターフェイス名 ： IFormLoadALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/22　HuyTX　　    新規作成
    /// 2014/10/24  DatNT     v1.02
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALOutput
    {
        /// <summary>
        /// GaikankensaKomokuMstDataTable
        /// </summary>
        GaikankensaKomokuMstDataSet.GaikankensaKomokuMstDataTable GaikankensaKomokuMstDataTable { get; set; }

        // 2014/10/24 v1.02 DatNT MOD Start

        ///// <summary>
        ///// NameMst010DataTable 
        ///// </summary>
        //NameMstDataSet.NameMstShokenDataTable NameMst010DataTable { get; set; }

        ///// <summary>
        ///// NameMst011DataTable 
        ///// </summary>
        //NameMstDataSet.NameMstShokenDataTable NameMst011DataTable { get; set; }

        /// <summary>
        /// ConstMstKbn012DT
        /// </summary>
        ConstMstDataSet.ConstMstDataTable ConstMstKbn012DT { get; set; }

        /// <summary>
        /// ConstMstKbn013DT
        /// </summary>
        ConstMstDataSet.ConstMstDataTable ConstMstKbn013DT { get; set; }

        // 2014/10/24 v1.02 DatNT MOD End

        /// <summary>
        /// ShokenMstKensakuDataTable
        /// </summary>
        ShokenMstDataSet.ShokenMstKensakuDataTable ShokenMstKensakuDataTable { get; set; }
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
    /// 2014/08/22　HuyTX　　    新規作成
    /// 2014/10/24  DatNT     v1.02
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALOutput : IFormLoadALOutput
    {
        /// <summary>
        /// GaikankensaKomokuMstDataTable
        /// </summary>
        public GaikankensaKomokuMstDataSet.GaikankensaKomokuMstDataTable GaikankensaKomokuMstDataTable { get; set; }

        // 2014/10/24 v1.02 DatNT MOD Start

        ///// <summary>
        ///// NameMst010DataTable 
        ///// </summary>
        //public NameMstDataSet.NameMstShokenDataTable NameMst010DataTable { get; set; }

        ///// <summary>
        ///// NameMst011DataTable 
        ///// </summary>
        //public NameMstDataSet.NameMstShokenDataTable NameMst011DataTable { get; set; }

        /// <summary>
        /// ConstMstKbn012DT
        /// </summary>
        public ConstMstDataSet.ConstMstDataTable ConstMstKbn012DT { get; set; }

        /// <summary>
        /// ConstMstKbn013DT
        /// </summary>
        public ConstMstDataSet.ConstMstDataTable ConstMstKbn013DT { get; set; }

        // 2014/10/24 v1.02 DatNT MOD End

        /// <summary>
        /// ShokenMstKensakuDataTable
        /// </summary>
        public ShokenMstDataSet.ShokenMstKensakuDataTable ShokenMstKensakuDataTable { get; set; }
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
    /// 2014/08/22　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadApplicationLogic : BaseApplicationLogic<IFormLoadALInput, IFormLoadALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "ShokenList：FormLoad";

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
        /// 2014/08/22　HuyTX　　    新規作成
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
        /// 2014/08/22　HuyTX　　    新規作成
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
        /// 2014/08/22　HuyTX　　    新規作成
        /// 2014/10/24  DatNT     v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IFormLoadALOutput Execute(IFormLoadALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IFormLoadALOutput output = new FormLoadALOutput();

            try
            {
                //get GaikankensaKomokuMst
                IGetGaikankensaKomokuMstInfoBLInput getGaikankensaKomokuBLInput = new GetGaikankensaKomokuMstInfoBLInput();
                output.GaikankensaKomokuMstDataTable = new GetGaikankensaKomokuMstInfoBusinessLogic().Execute(getGaikankensaKomokuBLInput).GaikankensaKomokuMstDataTable;

                // 2014/10/24 v1.02 DatNT MOD Start
                ////get NameMst (NameKbn = 010)
                //IGetNameMstShokenByNameKbnBLInput getNameKbn010BLInput = new GetNameMstShokenByNameKbnBLInput();
                //getNameKbn010BLInput.NameKbn = Utility.Constants.NameKbnConstant.NAME_KBN_010;
                //output.NameMst010DataTable = new GetNameMstShokenByNameKbnBusinessLogic().Execute(getNameKbn010BLInput).NameMstShokenDataTable;

                ////get NameMst (NameKbn = 011)
                //IGetNameMstShokenByNameKbnBLInput getNameKbn011BLInput = new GetNameMstShokenByNameKbnBLInput();
                //getNameKbn011BLInput.NameKbn = Utility.Constants.NameKbnConstant.NAME_KBN_011;
                //output.NameMst011DataTable = new GetNameMstShokenByNameKbnBusinessLogic().Execute(getNameKbn011BLInput).NameMstShokenDataTable;

                IGetConstMstByKbnBLInput getConst012Input   = new GetConstMstByKbnBLInput();
                getConst012Input.ConstKbn                   = Utility.Constants.ConstKbnConstanst.CONST_KBN_012;
                IGetConstMstByKbnBLOutput getConst012Output = new GetConstMstByKbnBusinessLogic().Execute(getConst012Input);
                output.ConstMstKbn012DT                     = getConst012Output.DataTable;

                IGetConstMstByKbnBLInput getConst013Input   = new GetConstMstByKbnBLInput();
                getConst013Input.ConstKbn                   = Utility.Constants.ConstKbnConstanst.CONST_KBN_013;
                IGetConstMstByKbnBLOutput getConst013Output = new GetConstMstByKbnBusinessLogic().Execute(getConst013Input);
                output.ConstMstKbn013DT                     = getConst013Output.DataTable;

                // 2014/10/24 v1.02 DatNT MOD End

                //get ShokenMst
                IGetShokenMstBySearchCondBLInput getShokenMstBySearchCondBLInput = new GetShokenMstBySearchCondBLInput();
                output.ShokenMstKensakuDataTable = new GetShokenMstBySearchCondBusinessLogic().Execute(getShokenMstBySearchCondBLInput).ShokenMstKensakuDataTable;

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
