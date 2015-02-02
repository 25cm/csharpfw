using System;
using System.Data;
using System.Reflection;
using FukjBizSystem.Application.DataAccess.KensaIraiTbl;
using FukjBizSystem.Application.DataAccess.ShokuinMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.WorkList.CenterKeikoku
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetCenterKeikokuBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23  豊田　　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetCenterKeikokuBLInput
    {
        /// <summary>
        /// ShishoCd 
        /// </summary>
        string ShishoCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetCenterKeikokuBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23  豊田　　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetCenterKeikokuBLInput : IGetCenterKeikokuBLInput
    {
        /// <summary>
        /// ShishoCd 
        /// </summary>
        public string ShishoCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetCenterKeikokuBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23  豊田　　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetCenterKeikokuBLOutput
    {
        /// <summary>
        /// CenterKeikokuListDataTable 
        /// </summary>
        CenterKeikokuDataSet.CenterKeikokuListDataTable CenterKeikokuListDataTable { get; set; }

        /// <summary>
        /// Miwariate11JoListDataTable
        /// </summary>
        CenterKeikokuDataSet.Miwariate11JoListDataTable Miwariate11JoListDataTable { get; set; }

        /// <summary>
        /// Miwariate7JoListDataTable
        /// </summary>
        CenterKeikokuDataSet.Miwariate7JoListDataTable Miwariate7JoListDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetCenterKeikokuBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23  豊田　　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetCenterKeikokuBLOutput : IGetCenterKeikokuBLOutput
    {
        /// <summary>
        /// CenterKeikokuListDataTable 
        /// </summary>
        public CenterKeikokuDataSet.CenterKeikokuListDataTable CenterKeikokuListDataTable { get; set; }

        /// <summary>
        /// Miwariate11JoListDataTable
        /// </summary>
        public CenterKeikokuDataSet.Miwariate11JoListDataTable Miwariate11JoListDataTable { get; set; }

        /// <summary>
        /// Miwariate7JoListDataTable
        /// </summary>
        public CenterKeikokuDataSet.Miwariate7JoListDataTable Miwariate7JoListDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetCenterKeikokuBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23  豊田　　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetCenterKeikokuBusinessLogic : BaseBusinessLogic<IGetCenterKeikokuBLInput, IGetCenterKeikokuBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetCenterKeikokuBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/23  豊田　　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetCenterKeikokuBusinessLogic()
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
        /// 2014/12/23  豊田　　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetCenterKeikokuBLOutput Execute(IGetCenterKeikokuBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetCenterKeikokuBLOutput output = new GetCenterKeikokuBLOutput();

            try
            {
                output.Miwariate11JoListDataTable = new CenterKeikokuDataSet.Miwariate11JoListDataTable();
                output.Miwariate7JoListDataTable = new CenterKeikokuDataSet.Miwariate7JoListDataTable();
                output.CenterKeikokuListDataTable = new CenterKeikokuDataSet.CenterKeikokuListDataTable();

                // 作業日取得
                DateTime today = Boundary.Common.Common.GetCurrentTimestamp().Date;

                // 所属検査員を取得
                ISelectShokuinMstByKensainShishoCdDAInput kensainInput = new SelectShokuinMstByKensainShishoCdDAInput();
                kensainInput.ShishoCd = input.ShishoCd;
                ShokuinMstDataSet.ShokuinMstDataTable kensainList = new SelectShokuinMstByKensainShishoCdDataAccess().Execute(kensainInput).ShokuinMstDataTable;

                // センター警告を取得
                ISelectCenterKeikokuListByShishoCdDAInput centerkeikokuInput = new SelectCenterKeikokuListByShishoCdDAInput();
                centerkeikokuInput.ShishoCd = input.ShishoCd;
                centerkeikokuInput.KensaDateBefore = today.AddDays(-10).ToString("yyyyMMdd");
                centerkeikokuInput.ShiyoKaishiDateBefore = today.AddDays(-90).ToString("yyyyMMdd");
                KensaIraiTblDataSet.CenterKeikokuListDataTable centerKeikoku = new SelectCenterKeikokuListByShishoCdDataAccess().Execute(centerkeikokuInput).CenterKeikokuListDataTable;

                // 担当者未設定11条検査取得
                ISelectMiwariate11JoListByShishoCdDAInput miwariate11JoInput = new SelectMiwariate11JoListByShishoCdDAInput();
                miwariate11JoInput.ShishoCd = input.ShishoCd;

                output.Miwariate11JoListDataTable.Merge(new SelectMiwariate11JoListByShishoCdDataAccess().Execute(miwariate11JoInput).Miwariate11JoListDataTable);

                // 担当者未設定7条検査取得
                ISelectMiwariate7JoListByShishoCdDAInput miwariate7JoInput = new SelectMiwariate7JoListByShishoCdDAInput();
                miwariate7JoInput.ShishoCd = input.ShishoCd;

                output.Miwariate7JoListDataTable.Merge(new SelectMiwariate7JoListByShishoCdDataAccess().Execute(miwariate7JoInput).Miwariate7JoListDataTable);
                
                // センター警告を担当者別に集計
                foreach (ShokuinMstDataSet.ShokuinMstRow kensain in kensainList)
                {
                    CenterKeikokuDataSet.CenterKeikokuListRow newRow = output.CenterKeikokuListDataTable.NewCenterKeikokuListRow();
                    
                    // 担当者コード
                    newRow.TantoshaCd = kensain.ShokuinCd;
                    // 担当者名
                    newRow.TantoshaName = kensain.ShokuinNm;

                    // 10日以上経過未完了件数
                    DataRow[]　mikanryou = centerKeikoku.Select(string.Format("KensaIraiKensaTantoshaCd='{0}' AND KensaIraiStatusKbn < 65 AND KensaDateYYYYMMDD <= '{1}'", kensain.ShokuinCd, today.AddDays(-10).ToString("yyyyMMdd")), string.Empty);
                    newRow.Mikanryo = mikanryou.Length;

                    // 3～4ヶ月経過7条検査未実施件数
                    DataRow[] mijisshi3_4 = centerKeikoku.Select(string.Format("KensaIraiKensaTantoshaCd='{0}' AND KensaIraiStatusKbn < 50 AND ShiyoKaishiDateYYYYMMDD <= '{1}' AND ShiyoKaishiDateYYYYMMDD >= '{2}'", kensain.ShokuinCd, today.AddDays(-90).ToString("yyyyMMdd"), today.AddDays(-150).ToString("yyyyMMdd")), string.Empty);
                    newRow.Mijisshi7Jo3_4 = mijisshi3_4.Length;

                    // 5～6ヶ月経過7条検査未実施件数
                    DataRow[] mijisshi5_6 = centerKeikoku.Select(string.Format("KensaIraiKensaTantoshaCd='{0}' AND KensaIraiStatusKbn < 50 AND ShiyoKaishiDateYYYYMMDD < '{1}' AND ShiyoKaishiDateYYYYMMDD >= '{2}'", kensain.ShokuinCd, today.AddDays(-150).ToString("yyyyMMdd"), today.AddDays(-210).ToString("yyyyMMdd")), string.Empty);
                    newRow.Mijisshi7Jo5_6 = mijisshi5_6.Length;

                    // 7ヶ月以上経過7条検査未実施件数
                    DataRow[] mijisshi7Ijo = centerKeikoku.Select(string.Format("KensaIraiKensaTantoshaCd='{0}' AND KensaIraiStatusKbn < 50 AND ShiyoKaishiDateYYYYMMDD < '{1}'", kensain.ShokuinCd, today.AddDays(-210).ToString("yyyyMMdd")), string.Empty);
                    newRow.Mijisshi7Jo7Ijo = mijisshi7Ijo.Length;

                    // 7条検査未実施合計
                    newRow.Mijisshi = mijisshi3_4.Length + mijisshi5_6.Length + mijisshi7Ijo.Length;

                    // 7条検査保留件数
                    DataRow[] horyu = centerKeikoku.Select(string.Format("KensaIraiKensaTantoshaCd='{0}' AND KensaIraiStatusKbn < 50 AND KensaIraiHoryuKbn = '1'", kensain.ShokuinCd), string.Empty);
                    newRow.Horyu7Jo = horyu.Length;
                    
                    output.CenterKeikokuListDataTable.AddCenterKeikokuListRow(newRow);
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
