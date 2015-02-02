using System;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Master.KatashikiMstShosai;
using FukjBizSystem.Application.BusinessLogic.Master.ShoriHoshikiMstShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Master.KatashikiMstShosai
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
    /// 2014/07/07  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALInput : IBseALInput,
                                    IGetGyoshaMstBySeizoGyoShaKbnBLInput,
                                    IGetShoriHoshikiMstInfoBLInput,
                                    IGetKatashikiMstByKeyBLInput,
                                    IGetTaniSochiGroupMstInfoBLInput
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
    /// 2014/07/07  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALInput : IFormLoadALInput
    {
        /// <summary>
        /// メーカー業者コード
        /// </summary>
        public String KatashikiMakerCd { get; set; }

        /// <summary>
        /// 型式コード
        /// </summary>
        public String KatashikiCd { get; set; }

        /// <summary>
        /// 製造業者区分
        /// </summary>
        public string SeizoGyoShaKbn { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("メーカー業者コード[{0}], 型式コード[{1}], 製造業者区分[{2}]",
                    new string[] { 
                        KatashikiMakerCd, 
                        KatashikiCd,
                        SeizoGyoShaKbn
                    });
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
    /// 2014/07/07  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALOutput : IGetGyoshaMstBySeizoGyoShaKbnBLOutput,
                                    IGetShoriHoshikiMstInfoBLOutput,
                                    IGetKatashikiMstByKeyBLOutput,
                                    IGetKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLOutput,
                                    IGetTaniSochiGroupMstInfoBLOutput,
                                    IGetTaniSochiListByMakerCdKatashikiCdBLOutput,
                                    IGetBetsuTaniSochiByMakerCdKatashikiCdBLOutput
    {

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
    /// 2014/07/07  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALOutput : IFormLoadALOutput
    {
        /// <summary>
        /// GyoshaMstDataTable
        /// </summary>
        public GyoshaMstDataSet.GyoshaMstDataTable GyoshaMstDT { get; set; }

        /// <summary>
        /// ShoriHoshikiMstDataTable
        /// </summary>
        public ShoriHoshikiMstDataSet.ShoriHoshikiMstDataTable ShoriHoshikiMstDT { get; set; }

        /// <summary>
        /// KatashikiMstDataTable
        /// </summary>
        public KatashikiMstDataSet.KatashikiMstDataTable KatashikiMstDT { get; set; }

        /// <summary>
        /// KatashikiBurowaMstDataTable
        /// </summary>
        public KatashikiBurowaMstDataSet.KatashikiBurowaMstDataTable KatashikiBurowaMstDT { get; set; }

        /// <summary>
        /// TaniSochiGroupMstDataTable
        /// </summary>
        public TaniSochiGroupMstDataSet.TaniSochiGroupMstDataTable TaniSochiGroupMstDT { get; set; }

        /// <summary>
        /// TaniSochiListDataTable
        /// </summary>
        public TaniSochiMstDataSet.TaniSochiListDataTable TaniSochiListDT { get; set; }

        /// <summary>
        /// KatashikiBetsuTaniSochiListDataTable
        /// </summary>
        public KatashikiBetsuTaniSochiMstDataSet.KatashikiBetsuTaniSochiListDataTable KatashikiBetsuTaniSochiListDT { get; set; }
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
    /// 2014/07/07  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadApplicationLogic : BaseApplicationLogic<IFormLoadALInput, IFormLoadALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KatashikiMstShosai：FormLoadApplicationLogic";

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
        /// 2014/07/07  DatNT　　    新規作成
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
        /// 2014/07/07  DatNT　　    新規作成
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
        /// 2014/07/07  DatNT　　    新規作成
        /// 2014/11/04  DatNT       v1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IFormLoadALOutput Execute(IFormLoadALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IFormLoadALOutput output = new FormLoadALOutput();

            try
            {
                // 2014/11/04 DatNT v1.05 DEL Start
                //// gyoshaMst info
                //output.GyoshaMstDT = new GetGyoshaMstBySeizoGyoShaKbnBusinessLogic().Execute(input).GyoshaMstDT;
                // 2014/11/04 DatNT v1.05 DEL End

                // shorihoshikiMst info
                output.ShoriHoshikiMstDT = new GetShoriHoshikiMstInfoBusinessLogic().Execute(input).ShoriHoshikiMstDT;

                // TanisochiGroupMst info
                output.TaniSochiGroupMstDT = new GetTaniSochiGroupMstInfoBusinessLogic().Execute(input).TaniSochiGroupMstDT;

                if (!string.IsNullOrEmpty(input.KatashikiMakerCd) && !string.IsNullOrEmpty(input.KatashikiCd))
                {
                    // katashikiMst by key
                    output.KatashikiMstDT = new GetKatashikiMstByKeyBusinessLogic().Execute(input).KatashikiMstDT;

                    // KatashikiBurowaMst by BurowaKatashikiMakerCd & BurowaKatashikiCd
                    IGetKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLInput buroInput = new GetKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLInput();
                    buroInput.BurowaKatashikiMakerCd = input.KatashikiMakerCd;
                    buroInput.BurowaKatashikiCd = input.KatashikiCd;
                    IGetKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLOutput buroOutput = new GetKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBusinessLogic().Execute(buroInput);

                    output.KatashikiBurowaMstDT = buroOutput.KatashikiBurowaMstDT;

                    // Get data for display taniSouchiListDataGridView
                    IGetBetsuTaniSochiByMakerCdKatashikiCdBLInput sochiInput = new GetBetsuTaniSochiByMakerCdKatashikiCdBLInput();
                    sochiInput.KatashikiMakerCd = input.KatashikiMakerCd;
                    sochiInput.KatashikiCd = input.KatashikiCd;
                    IGetBetsuTaniSochiByMakerCdKatashikiCdBLOutput sochiOutput = new GetBetsuTaniSochiByMakerCdKatashikiCdBusinessLogic().Execute(sochiInput);

                    output.KatashikiBetsuTaniSochiListDT = sochiOutput.KatashikiBetsuTaniSochiListDT;
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
