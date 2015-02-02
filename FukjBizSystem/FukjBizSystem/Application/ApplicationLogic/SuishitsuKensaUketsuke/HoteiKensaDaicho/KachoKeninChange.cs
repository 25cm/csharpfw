using Zynas.Framework.Core.Base.ApplicationLogic;
using FukjBizSystem.Application.BusinessLogic.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Utility;
using System.Reflection;

namespace FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaUketsuke.HoteiKensaDaicho
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKachoKeninChangeALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/28  宗    　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKachoKeninChangeALInput : IBseALInput
    {
        #region プロパティ

        /// <summary>
        /// 区分 
        /// </summary>
        string Kbn { get; set; }
        /// <summary>
        /// 依頼年度 
        /// </summary>
        string IraiNendo { get; set; }
        /// <summary>
        /// 支所コード 
        /// </summary>
        string Sisho { get; set; }
        /// <summary>
        /// 依頼番号 
        /// </summary>
        string IraiNo { get; set; }

        #endregion
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KachoKeninChangeALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/28  宗    　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KachoKeninChangeALInput : IKachoKeninChangeALInput
    {
        #region プロパティ
        /// <summary>
        /// 区分 
        /// </summary>
        public string Kbn { get; set; }
        /// <summary>
        /// 依頼年度 
        /// </summary>
        public string IraiNendo { get; set; }
        /// <summary>
        /// 支所コード 
        /// </summary>
        public string Sisho { get; set; }
        /// <summary>
        /// 依頼番号 
        /// </summary>
        public string IraiNo { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("区分[{0}], 依頼年度[{1}], 支所コード[{2}], 依頼番号[{3}]",
                    Kbn, IraiNendo, Sisho, IraiNo);
            }
        }

        #endregion
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKachoKeninChangeALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/28  宗    　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKachoKeninChangeALOutput
    {
        KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable KensaDaichoDtlTblDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KachoKeninChangeALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/28  宗    　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KachoKeninChangeALOutput : IKachoKeninChangeALOutput
    {
        /// <summary>
        /// HoteiKensaDaichoTblDataTable
        /// </summary>
        public KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable KensaDaichoDtlTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KachoKeninChangeApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/28  宗    　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KachoKeninChangeApplicationLogic : BaseApplicationLogic<IKachoKeninChangeALInput, IKachoKeninChangeALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "HoteiKensaDaicho：KachoKeninChange";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KachoKeninChangeApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/28  宗    　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KachoKeninChangeApplicationLogic()
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
        /// 2014/11/28  宗    　    新規作成
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
        /// 2014/11/28  宗    　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IKachoKeninChangeALOutput Execute(IKachoKeninChangeALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKachoKeninChangeALOutput output = new KachoKeninChangeALOutput();
            try
            {
                IGetKensaDaichoDtlTblByCondBLInput blInpt = new GetKensaDaichoDtlTblByCondBLInput();
                blInpt.Kbn = input.Kbn;
                blInpt.IraiNendo = input.IraiNendo;
                blInpt.Sisho = input.Sisho;
                blInpt.IraiNo = input.IraiNo;
                output.KensaDaichoDtlTblDT = new GetKensaDaichoDtlTblByCondBusinessLogic().Execute(blInpt).KensaDaichoDtlTblDT;
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