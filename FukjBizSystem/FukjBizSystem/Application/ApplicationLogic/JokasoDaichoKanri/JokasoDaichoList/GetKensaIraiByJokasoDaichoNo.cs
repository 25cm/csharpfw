using System;
using System.Reflection;
using FukjBizSystem.Application.Boundary.SuishitsuKensaUketsuke;
using FukjBizSystem.Application.BusinessLogic.Common;
using FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.Utility;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;
using FukjBizSystem.Application.DataAccess.KensaIraiTbl;

namespace FukjBizSystem.Application.ApplicationLogic.JokasoDaichoKanri.JokasoDaichoList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaIraiByJokasoDaichoNoALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/30  小松  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaIraiByJokasoDaichoNoALInput : IBseALInput
    {
        /// <summary>
        /// 浄化槽台帳保健所コード
        /// </summary>
        string KensaIraiJokasoHokenjoCd { get; set; }

        /// <summary>
        /// 浄化槽台帳年度 
        /// </summary>
        string KensaIraiJokasoTorokuNendo { get; set; }

        /// <summary>
        /// 浄化槽台帳連番 
        /// </summary>
        string KensaIraiJokasoRenban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaIraiByJokasoDaichoNoALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/30  小松  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaIraiByJokasoDaichoNoALInput : IGetKensaIraiByJokasoDaichoNoALInput
    {
        /// <summary>
        /// 浄化槽台帳保健所コード
        /// </summary>
        public string KensaIraiJokasoHokenjoCd { get; set; }

        /// <summary>
        /// 浄化槽台帳年度 
        /// </summary>
        public string KensaIraiJokasoTorokuNendo { get; set; }

        /// <summary>
        /// 浄化槽台帳連番 
        /// </summary>
        public string KensaIraiJokasoRenban { get; set; }

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
    //  インターフェイス名 ： IGetKensaIraiByJokasoDaichoNoALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/30  小松  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaIraiByJokasoDaichoNoALOutput
    {
        /// <summary>
        /// 検査依頼テーブル
        /// </summary>
        KensaIraiTblDataSet.KensaIraiTblDataTable KensaIraiTblDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaIraiByJokasoDaichoNoALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/30  小松  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaIraiByJokasoDaichoNoALOutput : IGetKensaIraiByJokasoDaichoNoALOutput
    {
        /// <summary>
        /// 検査依頼テーブル
        /// </summary>
        public KensaIraiTblDataSet.KensaIraiTblDataTable KensaIraiTblDT { get; set; }
    }
    #endregion


    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaIraiByJokasoDaichoNoApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/30  小松  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaIraiByJokasoDaichoNoApplicationLogic : BaseApplicationLogic<IGetKensaIraiByJokasoDaichoNoALInput, IGetKensaIraiByJokasoDaichoNoALOutput>
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
        private const string FunctionName = "JokasoDaichoList：GetKensaIraiByJokasoDaichoNoApplicationLogic";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKensaIraiByJokasoDaichoNoApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/30  小松  　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKensaIraiByJokasoDaichoNoApplicationLogic()
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
        /// 2015/01/30  小松  　    新規作成
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
        /// 2015/01/30  小松  　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKensaIraiByJokasoDaichoNoALOutput Execute(IGetKensaIraiByJokasoDaichoNoALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKensaIraiByJokasoDaichoNoALOutput output = new GetKensaIraiByJokasoDaichoNoALOutput();

            try
            {
                ISelectKensaIraiTblByJokasoDaichoNoDAInput selIn = new SelectKensaIraiTblByJokasoDaichoNoDAInput();
                selIn.KensaIraiJokasoHokenjoCd = input.KensaIraiJokasoHokenjoCd;
                selIn.KensaIraiJokasoTorokuNendo = input.KensaIraiJokasoTorokuNendo;
                selIn.KensaIraiJokasoRenban = input.KensaIraiJokasoRenban;
                output.KensaIraiTblDT = new SelectKensaIraiTblByJokasoDaichoNoDataAccess().Execute(selIn).KensaIraiTblDT;
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
