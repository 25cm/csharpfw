using System;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Master.KatashikiMstList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Master.KatashikiMstList
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
    /// 2014/07/03  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKensakuBtnClickALInput : IBseALInput, IGetKatashikiMstBySearchCondBLInput
    {
        
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
    /// 2014/07/03  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickALInput : IKensakuBtnClickALInput
    {
        /// <summary>
        /// メーカー業者コード（開始）
        /// </summary>
        public String KatashikiMakerCdFrom { get; set; }

        /// <summary>
        /// メーカー業者コード（終了）
        /// </summary>
        public String KatashikiMakerCdTo { get; set; }

        /// <summary>
        /// メーカー業者名称
        /// </summary>
        public String GyoshaNm { get; set; }

        /// <summary>
        /// 型式コード（開始）
        /// </summary>
        public String KatashikiCdFrom { get; set; }

        /// <summary>
        /// 型式コード（終了）
        /// </summary>
        public String KatashikiCdTo { get; set; }

        /// <summary>
        /// 型式名称
        /// </summary>
        public String KatashikiNm { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("メーカー業者コード（開始）[{0}], メーカー業者コード（終了）[{1}], メーカー業者名称[{2}], 型式コード（開始）[{3}], 型式コード（終了）[{4}], 型式名称[{5}]",
                    new string[]{
                        KatashikiMakerCdFrom,
                        KatashikiMakerCdTo,
                        GyoshaNm,
                        KatashikiCdFrom,
                        KatashikiCdTo,
                        KatashikiNm
                    });
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
    /// 2014/07/03  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKensakuBtnClickALOutput : IGetKatashikiMstBySearchCondBLOutput
    {
        
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
    /// 2014/07/03  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickALOutput : IKensakuBtnClickALOutput
    {
        /// <summary>
        /// KatashikiMstKensakuDataTable
        /// </summary>
        public KatashikiMstDataSet.KatashikiMstKensakuDataTable KatashikiMstKensakuDT { get; set; }
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
    /// 2014/07/03  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickApplicationLogic : BaseApplicationLogic<IKensakuBtnClickALInput, IKensakuBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KatashikiMstList：KensakuBtnClickApplicationLogic";

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
        /// 2014/07/03  DatNT　　    新規作成
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
        /// 2014/07/03  DatNT　　    新規作成
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
        /// 2014/07/03  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IKensakuBtnClickALOutput Execute(IKensakuBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKensakuBtnClickALOutput output = new KensakuBtnClickALOutput();

            try
            {
                output.KatashikiMstKensakuDT = new GetKatashikiMstBySearchCondBusinessLogic().Execute(input).KatashikiMstKensakuDT;
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
