using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaNippoList;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.GaikanKensa.KensaNippoList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// 検査日
        /// </summary>
        string NippoKensaDt { get; set; }

        /// <summary>
        /// 検査員コード
        /// </summary>
        string NippoKensainCd { get; set; }

        /// <summary>
        /// IsDeleteCheck
        /// </summary>
        bool IsDeleteCheck { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteBtnClickALInput : IDeleteBtnClickALInput
    {
        /// <summary>
        /// 検査日
        /// </summary>
        public string NippoKensaDt { get; set; }

        /// <summary>
        /// 検査員コード
        /// </summary>
        public string NippoKensainCd { get; set; }

        /// <summary>
        /// IsDeleteCheck
        /// </summary>
        public bool IsDeleteCheck { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("検査日[{0}], 検査員コード[{1}], IsDeleteCheck[{2}]", new string[] { NippoKensaDt, NippoKensainCd, IsDeleteCheck.ToString() } );
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteBtnClickALOutput
    {
        /// <summary>
        /// DeleteCheckOutput
        /// </summary>
        bool DeleteCheckOutput { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteBtnClickALOutput : IDeleteBtnClickALOutput
    {
        /// <summary>
        /// DeleteCheckOutput
        /// </summary>
        public bool DeleteCheckOutput { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteBtnClickApplicationLogic : BaseApplicationLogic<IDeleteBtnClickALInput, IDeleteBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaNippoList：DeleteBtnClickApplicationLogic";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DeleteBtnClickApplicationLogic()
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
        /// 2014/10/21  DatNT　  新規作成
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
        /// 2014/10/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDeleteBtnClickALOutput Execute(IDeleteBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteBtnClickALOutput output = new DeleteBtnClickALOutput();

            try
            {
                StartTransaction();

                if (input.IsDeleteCheck)
                {
                    IGetCountKensaNippoListDeleteCheckBLInput checkInput = new GetCountKensaNippoListDeleteCheckBLInput();
                    checkInput.NippoDtlKensaDt = input.NippoKensaDt;
                    checkInput.NippoDtlKensainCd = input.NippoKensainCd;
                    IGetCountKensaNippoListDeleteCheckBLOutput checkOutput = new GetCountKensaNippoListDeleteCheckBusinessLogic().Execute(checkInput);

                    if (checkOutput.RecordCount == 0)
                    {
                        output.DeleteCheckOutput = true;
                    }
                    else
                    {
                        output.DeleteCheckOutput = false;
                    }
                }
                else
                {
                    IDeleteNippoHdrTblByKeyBLInput delHdrInput = new DeleteNippoHdrTblByKeyBLInput();
                    delHdrInput.NippoKensaDt = input.NippoKensaDt;
                    delHdrInput.NippoKensainCd = input.NippoKensainCd;
                    IDeleteNippoHdrTblByKeyBLOutput delHdrOutput = new DeleteNippoHdrTblByKeyBusinessLogic().Execute(delHdrInput);

                    IDeleteNippoDtlTblByKensaDtKensainCdBLInput delDtlInput = new DeleteNippoDtlTblByKensaDtKensainCdBLInput();
                    delDtlInput.NippoDtlKensaDt = input.NippoKensaDt;
                    delDtlInput.NippoDtlKensainCd = input.NippoKensainCd;
                    IDeleteNippoDtlTblByKensaDtKensainCdBLOutput delDtlOutput = new DeleteNippoDtlTblByKensaDtKensainCdBusinessLogic().Execute(delDtlInput);
                }

                CompleteTransaction();
            }
            catch
            {
                throw;
            }
            finally
            {
                EndTransaction();

                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }

            return output;
        }
        #endregion

        #endregion
    }
    #endregion
}
