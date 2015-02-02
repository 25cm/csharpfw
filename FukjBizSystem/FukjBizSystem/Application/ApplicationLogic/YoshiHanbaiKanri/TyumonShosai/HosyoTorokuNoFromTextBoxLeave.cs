﻿using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.YoshiHanbaiKanri.TyumonShosai;
using FukjBizSystem.Application.DataSet.YoshiHanbaiKanri;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.YoshiHanbaiKanri.TyumonShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IHosyoTorokuNoFromTextBoxLeaveALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/27　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IHosyoTorokuNoFromTextBoxLeaveALInput : IBseALInput
    {
        /// <summary>
        /// HoshoTorokuAkibanSearchCond
        /// </summary>
        HoshoTorokuAkibanSearchCond SearchCond { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： HosyoTorokuNoFromTextBoxLeaveALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/27　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class HosyoTorokuNoFromTextBoxLeaveALInput : IHosyoTorokuNoFromTextBoxLeaveALInput
    {
        /// <summary>
        /// HoshoTorokuAkibanSearchCond
        /// </summary>
        public HoshoTorokuAkibanSearchCond SearchCond { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("注文番号[{0}]", SearchCond.HoshoTorokuChumonNo);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IHosyoTorokuNoFromTextBoxLeaveALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/27　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IHosyoTorokuNoFromTextBoxLeaveALOutput
    {
        /// <summary>
        /// HoshoTorokuKaishiNoCheckDataTable
        /// </summary>
        TyumonShosaiDataSet.HoshoTorokuKaishiNoCheckDataTable HoshoTorokuKaishiNoCheckDataTable { get; set; }

        /// <summary>
        /// HoshoTorokuAkibanDataTable
        /// </summary>
        TyumonShosaiDataSet.HoshoTorokuAkibanDataTable HoshoTorokuAkibanDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： HosyoTorokuNoFromTextBoxLeaveALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/27　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class HosyoTorokuNoFromTextBoxLeaveALOutput : IHosyoTorokuNoFromTextBoxLeaveALOutput
    {
        /// <summary>
        /// HoshoTorokuKaishiNoCheckDataTable
        /// </summary>
        public TyumonShosaiDataSet.HoshoTorokuKaishiNoCheckDataTable HoshoTorokuKaishiNoCheckDataTable { get; set; }

        /// <summary>
        /// HoshoTorokuAkibanDataTable
        /// </summary>
        public TyumonShosaiDataSet.HoshoTorokuAkibanDataTable HoshoTorokuAkibanDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： HosyoTorokuNoFromTextBoxLeaveApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/27　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class HosyoTorokuNoFromTextBoxLeaveApplicationLogic : BaseApplicationLogic<IHosyoTorokuNoFromTextBoxLeaveALInput, IHosyoTorokuNoFromTextBoxLeaveALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "TyumonShosai：HosyoTorokuNoFromTextBoxLeave";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： HosyoTorokuNoFromTextBoxLeaveApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/27　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public HosyoTorokuNoFromTextBoxLeaveApplicationLogic()
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
        /// 2015/01/27　AnhNV　　    新規作成
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
        /// 2015/01/27　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IHosyoTorokuNoFromTextBoxLeaveALOutput Execute(IHosyoTorokuNoFromTextBoxLeaveALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IHosyoTorokuNoFromTextBoxLeaveALOutput output = new HosyoTorokuNoFromTextBoxLeaveALOutput();

            try
            {
                IGetHoshoTorokuKaishiNoCheckByCondBLInput tkcInput = new GetHoshoTorokuKaishiNoCheckByCondBLInput();
                tkcInput.SearchCond = input.SearchCond;
                IGetHoshoTorokuKaishiNoCheckByCondBLOutput tkcOutput = new GetHoshoTorokuKaishiNoCheckByCondBusinessLogic().Execute(tkcInput);
                output.HoshoTorokuKaishiNoCheckDataTable = tkcOutput.HoshoTorokuKaishiNoCheckDataTable;

                IGetHoshoTorokuAkibanByCondBLInput akibanInput = new GetHoshoTorokuAkibanByCondBLInput();
                akibanInput.SearchCond = input.SearchCond;
                IGetHoshoTorokuAkibanByCondBLOutput akibanOutput = new GetHoshoTorokuAkibanByCondBusinessLogic().Execute(akibanInput);
                output.HoshoTorokuAkibanDataTable = akibanOutput.HoshoTorokuAkibanDataTable;
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