using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Master.ShokenList;
using FukjBizSystem.Application.BusinessLogic.Master.ShokenMstShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Master.ShokenMstShosai
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
    /// 2014/08/25　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALInput : IBseALInput, IGetShokenMstByKeyBLInput
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
    /// 2014/08/25　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALInput : IFormLoadALInput
    {
        /// <summary>
        /// ShokenKbn
        /// </summary>
        public string ShokenKbn { get; set; }

        /// <summary>
        /// ShokenCd
        /// </summary>
        public string ShokenCd { get; set; }

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
    /// 2014/08/25　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALOutput
    {
        /// <summary>
        /// GaikankensaKomokuMstDataTable
        /// </summary>
        GaikankensaKomokuMstDataSet.GaikankensaKomokuMstDataTable GaikankensaKomokuMstDataTable { get; set; }

        /// <summary>
        /// NameMst010DataTable
        /// </summary>
        NameMstDataSet.NameMstShokenDataTable NameMst010DataTable { get; set; }

        /// <summary>
        /// NameMst011DataTable
        /// </summary>
        NameMstDataSet.NameMstShokenDataTable NameMst011DataTable { get; set; }

        /// <summary>
        /// NameMst012DataTable
        /// </summary>
        NameMstDataSet.NameMstShokenDataTable NameMst012DataTable { get; set; }
        /// <summary>
        /// NameMst013DataTable
        /// </summary>
        NameMstDataSet.NameMstShokenDataTable NameMst013DataTable { get; set; }

        /// <summary>
        /// NameMst014DataTable
        /// </summary>
        NameMstDataSet.NameMstShokenDataTable NameMst014DataTable { get; set; }

        /// <summary>
        /// NameMst015DataTable
        /// </summary>
        NameMstDataSet.NameMstShokenDataTable NameMst015DataTable { get; set; }

        /// <summary>
        /// ShokenMstDataTable
        /// </summary>
        ShokenMstDataSet.ShokenMstDataTable ShokenMstDataTable { get; set; }

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
    /// 2014/08/25　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALOutput : IFormLoadALOutput
    {
        /// <summary>
        /// GaikankensaKomokuMstDataTable
        /// </summary>
        public GaikankensaKomokuMstDataSet.GaikankensaKomokuMstDataTable GaikankensaKomokuMstDataTable { get; set; }

        /// <summary>
        /// NameMst010DataTable
        /// </summary>
        public NameMstDataSet.NameMstShokenDataTable NameMst010DataTable { get; set; }

        /// <summary>
        /// NameMst011DataTable
        /// </summary>
        public NameMstDataSet.NameMstShokenDataTable NameMst011DataTable { get; set; }

        /// <summary>
        /// NameMst012DataTable
        /// </summary>
        public NameMstDataSet.NameMstShokenDataTable NameMst012DataTable { get; set; }
        /// <summary>
        /// NameMst013DataTable
        /// </summary>
        public NameMstDataSet.NameMstShokenDataTable NameMst013DataTable { get; set; }

        /// <summary>
        /// NameMst014DataTable
        /// </summary>
        public NameMstDataSet.NameMstShokenDataTable NameMst014DataTable { get; set; }

        /// <summary>
        /// NameMst015DataTable
        /// </summary>
        public NameMstDataSet.NameMstShokenDataTable NameMst015DataTable { get; set; }

        /// <summary>
        /// ShokenMstDataTable
        /// </summary>
        public ShokenMstDataSet.ShokenMstDataTable ShokenMstDataTable { get; set; }
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
    /// 2014/08/25　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadApplicationLogic : BaseApplicationLogic<IFormLoadALInput, IFormLoadALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "ShokenMstShosai：FormLoad";

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
        /// 2014/08/25　HuyTX　　    新規作成
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
        /// 2014/08/25　HuyTX　　    新規作成
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
        /// 2014/08/25　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IFormLoadALOutput Execute(IFormLoadALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IFormLoadALOutput output = new FormLoadALOutput();

            try
            {
                //get ShokenMst
                output.ShokenMstDataTable = new GetShokenMstByKeyBusinessLogic().Execute(input).ShokenMstDataTable;

                //get GaikankensaKomokuMst
                IGetGaikankensaKomokuMstInfoBLInput getGaikankensaKomokuBLInput = new GetGaikankensaKomokuMstInfoBLInput();
                output.GaikankensaKomokuMstDataTable = new GetGaikankensaKomokuMstInfoBusinessLogic().Execute(getGaikankensaKomokuBLInput).GaikankensaKomokuMstDataTable;

                IGetNameMstShokenByNameKbnBLInput getNameKbnBLInput;

                //get NameMst (NameKbn = 010)
                getNameKbnBLInput = new GetNameMstShokenByNameKbnBLInput();
                getNameKbnBLInput.NameKbn = Utility.Constants.NameKbnConstant.NAME_KBN_010;
                output.NameMst010DataTable = new GetNameMstShokenByNameKbnBusinessLogic().Execute(getNameKbnBLInput).NameMstShokenDataTable;

                //get NameMst (NameKbn = 011)
                getNameKbnBLInput = new GetNameMstShokenByNameKbnBLInput();
                getNameKbnBLInput.NameKbn = Utility.Constants.NameKbnConstant.NAME_KBN_011;
                output.NameMst011DataTable = new GetNameMstShokenByNameKbnBusinessLogic().Execute(getNameKbnBLInput).NameMstShokenDataTable;

                //get NameMst (NameKbn = 012)
                getNameKbnBLInput = new GetNameMstShokenByNameKbnBLInput();
                getNameKbnBLInput.NameKbn = Utility.Constants.NameKbnConstant.NAME_KBN_012;
                output.NameMst012DataTable = new GetNameMstShokenByNameKbnBusinessLogic().Execute(getNameKbnBLInput).NameMstShokenDataTable;

                //get NameMst (NameKbn = 013)
                getNameKbnBLInput = new GetNameMstShokenByNameKbnBLInput();
                getNameKbnBLInput.NameKbn = Utility.Constants.NameKbnConstant.NAME_KBN_013;
                output.NameMst013DataTable = new GetNameMstShokenByNameKbnBusinessLogic().Execute(getNameKbnBLInput).NameMstShokenDataTable;

                //get NameMst (NameKbn = 014)
                getNameKbnBLInput = new GetNameMstShokenByNameKbnBLInput();
                getNameKbnBLInput.NameKbn = Utility.Constants.NameKbnConstant.NAME_KBN_014;
                output.NameMst014DataTable = new GetNameMstShokenByNameKbnBusinessLogic().Execute(getNameKbnBLInput).NameMstShokenDataTable;

                //get NameMst (NameKbn = 015)
                getNameKbnBLInput = new GetNameMstShokenByNameKbnBLInput();
                getNameKbnBLInput.NameKbn = Utility.Constants.NameKbnConstant.NAME_KBN_015;
                output.NameMst015DataTable = new GetNameMstShokenByNameKbnBusinessLogic().Execute(getNameKbnBLInput).NameMstShokenDataTable;

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
