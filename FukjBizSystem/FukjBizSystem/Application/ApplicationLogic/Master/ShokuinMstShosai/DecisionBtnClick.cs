using System.Reflection;
using System.Text;
using FukjBizSystem.Application.Boundary.Master;
using FukjBizSystem.Application.BusinessLogic.Master.ShokuinMstShosai;
using FukjBizSystem.Application.BusinessLogic.Master.ShozokuMstShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Master.ShokuinMstShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDecisionBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/07　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDecisionBtnClickALInput : IBseALInput, IUpdateShokuinMstBLInput, IUpdateShozokuMstBLInput
    {
        /// <summary>
        /// DisplayMode
        /// </summary>
        ShokuinMstShosaiForm.DispMode DisplayMode { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DecisionBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/07　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DecisionBtnClickALInput : IDecisionBtnClickALInput
    {
        /// <summary>
        /// ShokuinMstDT
        /// </summary>
        public ShokuinMstDataSet.ShokuinMstDataTable ShokuinMstDT { get; set; }

        /// <summary>
        /// ShozokuMstDT
        /// </summary>
        public ShozokuMstDataSet.ShozokuMstDataTable ShozokuMstDT { get; set; }

        /// <summary>
        /// DisplayMode
        /// </summary>
        public ShokuinMstShosaiForm.DispMode DisplayMode { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("職員コード[{0}]", ShokuinMstDT[0].ShokuinCd);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDecisionBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/07　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDecisionBtnClickALOutput
    {
        /// <summary>
        /// ErrMessage
        /// </summary>
        string ErrMessage { get; set; }

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DecisionBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/07　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DecisionBtnClickALOutput : IDecisionBtnClickALOutput
    {
        /// <summary>
        /// ErrMessage
        /// </summary>
        public string ErrMessage { get; set; }

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DecisionBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/07　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DecisionBtnClickApplicationLogic : BaseApplicationLogic<IDecisionBtnClickALInput, IDecisionBtnClickALOutput>
    {
        #region 定義

        public enum OperationErr
        {
            RakkanLock,     // 楽観ロックエラー
        }

        #endregion

        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "ShokuinMstShosai：DecisionBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DecisionBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DecisionBtnClickApplicationLogic()
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
        /// 2014/07/07　HuyTX　　    新規作成
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
        /// 2014/07/07　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDecisionBtnClickALOutput Execute(IDecisionBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDecisionBtnClickALOutput output = new DecisionBtnClickALOutput();

            try
            {
                // トランザクション開始
                StartTransaction();

                bool isRegisted = isExistShokuin(input.ShokuinMstDT[0].ShokuinCd);

                IGetShozokuMstByShokuinCdBLInput getShozokuInput = new GetShozokuMstByShokuinCdBLInput();
                getShozokuInput.ShokuinCd = input.ShokuinMstDT[0].ShokuinCd;
                IGetShozokuMstByShokuinCdBLOutput getShozokuOutput = new GetShozokuMstByShokuinCdBusinessLogic().Execute(getShozokuInput);

                //throw error message if exist Shokuin, Shozoku
                string errExist = checkExistShozoku(getShozokuOutput.ShozokuMstDT, input.ShozokuMstDT);

                if (input.DisplayMode == ShokuinMstShosaiForm.DispMode.Add)
                {
                    //throw error message if exist Shokuin
                    if (isRegisted)
                    {
                        output.ErrMessage = string.Format("既に登録済みです。[職員コード：{0}]", input.ShokuinMstDT[0].ShokuinCd);
                        return output;
                    }

                    if (!string.IsNullOrEmpty(errExist))
                    {
                        output.ErrMessage = errExist;
                        return output;
                    }
                }

                if (input.DisplayMode == ShokuinMstShosaiForm.DispMode.Edit)
                {
                    if (!isRegisted)
                    {
                        output.ErrMessage = string.Format("該当するデータは登録されていません。[職員コード：{0}]", input.ShokuinMstDT[0].ShokuinCd);
                        return output;
                    }
                    else if (!string.IsNullOrEmpty(errExist.ToString()))
                    {
                        output.ErrMessage = errExist;
                        return output;
                    }
                    else
                    {
                        //RakkanCheck
                        RakkanCheck(input);

                        //更新日
                        input.ShokuinMstDT[0].UpdateDt = Boundary.Common.Common.GetCurrentTimestamp();
                    }

                }

                // insert/update ShokuinMst
                new UpdateShokuinMstBusinessLogic().Execute(input);

                // 2015/01/27 DatNT v1.04 MOD Start
                // delete by shokuinCd
                IDeleteShozokuMstByShokuinCdBLInput delInput = new DeleteShozokuMstByShokuinCdBLInput();
                delInput.ShokuinCd = input.ShokuinMstDT[0].ShokuinCd;
                new DeleteShozokuMstByShokuinCdBusinessLogic().Execute(delInput);

                // insert
                foreach (ShozokuMstDataSet.ShozokuMstRow shozokuRow in input.ShozokuMstDT)
                {
                    IInsertShozokuMstBLInput insertInput = new InsertShozokuMstBLInput();
                    insertInput.ShozokuMstRow = shozokuRow;
                    new InsertShozokuMstBusinessLogic().Execute(insertInput);
                }

                //// insert/update ShozokuMst
                //new UpdateShozokuMstBusinessLogic().Execute(input);
                // 2015/01/27 DatNT v1.04 MOD End

                // コミット
                CompleteTransaction();

            }
            catch
            {
                throw;
            }
            finally
            {
                // トランザクション終了
                EndTransaction();

                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }

            return output;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region isExistShokuin
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： isExistShokuin
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shokuinCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool isExistShokuin(string shokuinCd)
        {
            IGetShokuinMstByKeyBLInput blInput = new GetShokuinMstByKeyBLInput();
            blInput.ShokuinCd = shokuinCd;

            IGetShokuinMstByKeyBLOutput blOutput = new GetShokuinMstByKeyBusinessLogic().Execute(blInput);

            if (blOutput.ShokuinMstDT.Count != 0)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region checkExistShozoku
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： checkExistShozoku
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shokuinCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/10  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string checkExistShozoku(ShozokuMstDataSet.ShozokuMstDataTable shozokuMst, ShozokuMstDataSet.ShozokuMstDataTable shozokuMstNew)
        {
            StringBuilder errMsg = new StringBuilder();

            //if (shozokuMst.Count == 0) return string.Empty;
            bool isExist = false;
            bool isNewErr = true;

            for (int i = 0; i < shozokuMstNew.Count; i++)
            {
                for (int j = 0; j < shozokuMst.Count; j++)
                {
                    //check exist data 
                    if (shozokuMstNew[i].ShozokuBushoCd == shozokuMst[j].ShozokuBushoCd
                        && shozokuMstNew[i].ShozokuYakushokuCd == shozokuMst[j].ShozokuYakushokuCd)
                    {
                        isExist = true;
                        break;
                    }

                }

                //throw error message if data registed 
                if (isExist && shozokuMstNew[i]["IsUpdate"].ToString() != "1")
                {
                    if (isNewErr)
                    {
                        errMsg.AppendLine("既に登録済みです。");
                        isNewErr = false;
                    }

                    errMsg.AppendLine(string.Format("[職員コード：{0}] [部署コード：{1}, 部署名：{2}] [役職コード：{3}, 役職名：{4}] ",
                            new string[] { shozokuMstNew[i].ShozokuShokuinCd, 
                                            shozokuMstNew[i].ShozokuBushoCd.ToString(),     
                                            shozokuMstNew[i]["BushoNm"].ToString(), 
                                            shozokuMstNew[i].ShozokuYakushokuCd.ToString(),     
                                            shozokuMstNew[i]["YakushokuNm"].ToString(),
                                        }));
                }

                isExist = false;
            }

            return errMsg.ToString();
        }
        #endregion

        #region RakkanCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： RakkanCheck
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RakkanCheck(IDecisionBtnClickALInput input)
        {
            IGetShokuinMstByKeyBLInput blInput = new GetShokuinMstByKeyBLInput();
            blInput.ShokuinCd = input.ShokuinMstDT[0].ShokuinCd;

            IGetShokuinMstByKeyBLOutput blOutput = new GetShokuinMstByKeyBusinessLogic().Execute(blInput);

            if (input.ShokuinMstDT[0].UpdateDt != blOutput.ShokuinMstDT[0].UpdateDt)
            {
                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
            }

        }
        #endregion

        #endregion
    }
    #endregion
}
