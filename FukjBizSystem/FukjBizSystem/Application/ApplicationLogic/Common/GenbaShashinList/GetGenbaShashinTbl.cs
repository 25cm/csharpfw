using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Common.GenbaShashinList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;
using FukjBizSystem.Application.BusinessLogic.Common;
using System;

namespace FukjBizSystem.Application.ApplicationLogic.Common.GenbaShashinList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetGenbaShashinTblALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/15　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetGenbaShashinTblALInput : IBseALInput, IGetGenbaShashinTblByKensaIraiKeyBLInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetGenbaShashinTblALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/15　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetGenbaShashinTblALInput : IGetGenbaShashinTblALInput
    {
        /// <summary>
        /// IraiHoteiKbn
        /// </summary>
        public string IraiHoteiKbn { get; set; }

        /// <summary>
        /// IraiHokenjoCd
        /// </summary>
        public string IraiHokenjoCd { get; set; }

        /// <summary>
        /// IraiNendo
        /// </summary>
        public string IraiNendo { get; set; }

        /// <summary>
        /// IraiRenban
        /// </summary>
        public string IraiRenban { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get {return string.Empty;}
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetGenbaShashinTblALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/15　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetGenbaShashinTblALOutput : IGetGenbaShashinTblByKensaIraiKeyBLOutput
    {
        /// <summary>
        /// StartDate
        /// </summary>
        DateTime? StartDate { get; set; }

        /// <summary>
        /// EndDate
        /// </summary>
        DateTime? EndDate { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetGenbaShashinTblALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/15　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetGenbaShashinTblALOutput : IGetGenbaShashinTblALOutput
    {
        /// <summary>
        /// GenbaShashinTblDataTable
        /// </summary>
        public GenbaShashinTblDataSet.GenbaShashinTblDataTable GenbaShashinTbl { get; set; }

        /// <summary>
        /// StartDate
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// EndDate
        /// </summary>
        public DateTime? EndDate { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetGenbaShashinTblApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/15　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetGenbaShashinTblApplicationLogic : BaseApplicationLogic<IGetGenbaShashinTblALInput, IGetGenbaShashinTblALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "GenbaShashinList：GetGenbaShashinTbl";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetGenbaShashinTblApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/15　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetGenbaShashinTblApplicationLogic()
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
        /// 2014/12/15　豊田　　    新規作成
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
        /// 2014/12/15　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetGenbaShashinTblALOutput Execute(IGetGenbaShashinTblALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetGenbaShashinTblALOutput output = new GetGenbaShashinTblALOutput();

            try
            {
                IGetGenbaShashinTblByKensaIraiKeyBLOutput blOutput = new GetGenbaShashinTblByKensaIraiKeyBusinessLogic().Execute(input);
                output.GenbaShashinTbl = blOutput.GenbaShashinTbl;

                IGetKensaKekkaTblByKeyBLInput kekkaInput = new GetKensaKekkaTblByKeyBLInput();
                kekkaInput.KensaKekkaIraiHoteiKbn = input.IraiHoteiKbn;
                kekkaInput.KensaKekkaIraiHokenjoCd = input.IraiHokenjoCd;
                kekkaInput.KensaKekkaIraiNendo = input.IraiNendo;
                kekkaInput.KensaKekkaIraiRenban = input.IraiRenban;

                IGetKensaKekkaTblByKeyBLOutput kekkaOutput = new GetKensaKekkaTblByKeyBusinessLogic().Execute(kekkaInput);

                output.StartDate = kekkaOutput.KensaKekkaTblDataTable[0].IsKensaKekkaKensaStartDtNull() ? (DateTime?)null : kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaKensaStartDt;
                output.EndDate = kekkaOutput.KensaKekkaTblDataTable[0].IsKensaKekkakensaEndDtNull() ? (DateTime?)null : kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkakensaEndDt;
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
