using System;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Master.KatashikiMstShosai;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Master.KatashikiMstShosai
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
    /// 2014/07/08  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteBtnClickALInput : IBseALInput, 
                                        IDeleteKatashikiMstByKeyBLInput
    {
        
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
    /// 2014/07/08  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteBtnClickALInput : IDeleteBtnClickALInput
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
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("メーカー業者コード[{0}], 型式コード[{1}]", 
                    new string[]{
                        KatashikiMakerCd,
                        KatashikiCd
                    });
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
    /// 2014/07/08  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteBtnClickALOutput : IDeleteKatashikiMstByKeyBLOutput
    {
        /// <summary>
        /// ErrorMessage
        /// </summary>
        string ErrorMessage { get; set; }
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
    /// 2014/07/08  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteBtnClickALOutput : IDeleteBtnClickALOutput
    {
        /// <summary>
        /// ErrorMessage
        /// </summary>
        public string ErrorMessage { get; set; }
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
    /// 2014/07/08  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteBtnClickApplicationLogic : BaseApplicationLogic<IDeleteBtnClickALInput, IDeleteBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KatashikiMstShosai：DeleteBtnClickApplicationLogic";

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
        /// 2014/07/08  DatNT　　    新規作成
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
        /// 2014/07/08  DatNT　　    新規作成
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
        /// 2014/07/08  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDeleteBtnClickALOutput Execute(IDeleteBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteBtnClickALOutput output = new DeleteBtnClickALOutput();

            try
            {
                string errMess = string.Empty;

                StartTransaction();

                // Delete KatashikiMst
                IGetKatashikiMstByKeyBLInput blInput    = new GetKatashikiMstByKeyBLInput();
                blInput.KatashikiMakerCd                = input.KatashikiMakerCd;
                blInput.KatashikiCd                     = input.KatashikiCd;
                IGetKatashikiMstByKeyBLOutput blOutput  = new GetKatashikiMstByKeyBusinessLogic().Execute(blInput);

                if (blOutput.KatashikiMstDT != null && blOutput.KatashikiMstDT.Count > 0)
                {
                    new DeleteKatashikiMstByKeyBusinessLogic().Execute(input);
                }
                else
                {
                    errMess += string.Format("該当するデータは登録されていません。[型式マスタ][メーカー業者コード：{0}、型式コード：{1}]\r\n", 
                        new string[] { input.KatashikiMakerCd, input.KatashikiCd });
                }

                // Delete KatashikiBurowaMst
                IGetKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLInput buroBlInput = new GetKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLInput();
                buroBlInput.BurowaKatashikiMakerCd = input.KatashikiMakerCd;
                buroBlInput.BurowaKatashikiCd = input.KatashikiCd;
                IGetKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLOutput buroBlOutput = new GetKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBusinessLogic().Execute(buroBlInput);

                if (buroBlOutput.KatashikiBurowaMstDT != null && buroBlOutput.KatashikiBurowaMstDT.Count > 0)
                {
                    IDeleteKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLInput delBuroInput = new DeleteKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLInput();
                    delBuroInput.BurowaKatashikiMakerCd = input.KatashikiMakerCd;
                    delBuroInput.BurowaKatashikiCd = input.KatashikiCd;
                    IDeleteKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLOutput delBuroOutput = new DeleteKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBusinessLogic().Execute(delBuroInput);
                }
                else
                {
                    errMess += string.Format("該当するデータは登録されていません。[型式ブロワマスタ][メーカー業者コード：{0}、型式コード：{1}]\r\n",
                        new string[] { input.KatashikiMakerCd, input.KatashikiCd });
                }

                // Delete KatashikiBetsuTaniShochiMst
                IGetKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdBLInput sochiInput = new GetKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdBLInput();
                sochiInput.KatashikiMakerCd = input.KatashikiMakerCd;
                sochiInput.KatashikiCd = input.KatashikiCd;
                IGetKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdBLOutput sochiOutput = new GetKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdBusinessLogic().Execute(sochiInput);

                if (sochiOutput.KatashikiBetsuTaniSochiMstDT != null && sochiOutput.KatashikiBetsuTaniSochiMstDT.Count > 0)
                {
                    IDeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdBLInput delSochiInput = new DeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdBLInput();
                    delSochiInput.KatashikiMakerCd = input.KatashikiMakerCd;
                    delSochiInput.KatashikiCd = input.KatashikiCd;
                    IDeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdBLOutput delSochiOutput = new DeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdBusinessLogic().Execute(delSochiInput);
                }
                else
                {
                    errMess += string.Format("該当するデータは登録されていません。[型式別単位装置マスタ][メーカー業者コード：{0}、型式コード：{1}]\r\n",
                        new string[] { input.KatashikiMakerCd, input.KatashikiCd });
                }

                if (!string.IsNullOrEmpty(errMess))
                {
                    output.ErrorMessage = errMess;

                    return output;
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
