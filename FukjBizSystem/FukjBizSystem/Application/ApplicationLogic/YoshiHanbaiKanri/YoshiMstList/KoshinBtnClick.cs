using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.Boundary.YoshiHanbaiKanri;
using FukjBizSystem.Application.BusinessLogic.YoshiHanbaiKanri.YoshiMstList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.YoshiHanbaiKanri.YoshiMstList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKoshinBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/23  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKoshinBtnClickALInput : IBseALInput, IInsertYoshiMstBLInput
    {
        /// <summary>
        /// YoshiMstUpdateDataTable
        /// </summary>
        YoshiMstUpdateDataSet.YoshiMstUpdateDataTable YoshiMstUpdateDT { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KoshinBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/23  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KoshinBtnClickALInput : IKoshinBtnClickALInput
    {
        /// <summary>
        /// YoshiMstUpdateDataTable
        /// </summary>
        public YoshiMstUpdateDataSet.YoshiMstUpdateDataTable YoshiMstUpdateDT { get; set; }

        /// <summary>
        /// YoshiMst Insert DataTable
        /// </summary>
        public YoshiMstDataSet.YoshiMstDataTable YoshiMstInsertDT { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("YoshiMstUpdateDataTable[{0}]", YoshiMstUpdateDT[0].YoshiCd);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKoshinBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/23  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKoshinBtnClickALOutput
    {
        /// <summary>
        /// List YoshiCd for duplication check
        /// </summary>
        List<string> ListKey { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KoshinBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/23  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KoshinBtnClickALOutput : IKoshinBtnClickALOutput
    {
        /// <summary>
        /// List YoshiCd for duplication check
        /// </summary>
        public List<string> ListKey { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KoshinBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/23  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KoshinBtnClickApplicationLogic : BaseApplicationLogic<IKoshinBtnClickALInput, IKoshinBtnClickALOutput>
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
        private const string FunctionName = "YoshiMstList：KoshinBtnClickApplicationLogic";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KoshinBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/23  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KoshinBtnClickApplicationLogic()
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
        /// 2014/07/23  DatNT　  新規作成
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
        /// 2014/07/23  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IKoshinBtnClickALOutput Execute(IKoshinBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKoshinBtnClickALOutput output = new KoshinBtnClickALOutput();

            try
            {
                StartTransaction();

                // list YoshiCd was existed
                List<string> lstStr = new List<string>();

                DateTime now = Boundary.Common.Common.GetCurrentTimestamp();
                string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                string pcUpdate = Dns.GetHostName();

                // update
                if (input.YoshiMstUpdateDT != null && input.YoshiMstUpdateDT.Count > 0)
                {
                    // Check duplicate
                    foreach (YoshiMstUpdateDataSet.YoshiMstUpdateRow row in input.YoshiMstUpdateDT)
                    {
                        // Get YoshiMst by key
                        IGetYoshiMstByKeyBLInput blInput = new GetYoshiMstByKeyBLInput();
                        blInput.YoshiCd = row.YoshiCd;
                        IGetYoshiMstByKeyBLOutput blOutput = new GetYoshiMstByKeyBusinessLogic().Execute(blInput);

                        if (blOutput.YoshiMstDT != null && blOutput.YoshiMstDT.Count > 0 && row.YoshiCd != row.YoshiCdOriginal )
                        {
                            lstStr.Add(row.YoshiCd);
                        }
                        else
                        {
                            // 更新日が違うか？
                            if (row.UpdateDt != blOutput.YoshiMstDT[0].UpdateDt)
                            {
                                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                            }

                            row.UpdateDt = now;
                            row.UpdateUser = loginUser;
                            row.UpdateTarm = pcUpdate;

                            IUpdateYoshiMstByKeyBLInput updateInput = new UpdateYoshiMstByKeyBLInput();
                            updateInput.YoshiMstUpdateRow = row;
                            IUpdateYoshiMstByKeyBLOutput updateOutput = new UpdateYoshiMstByKeyBusinessLogic().Execute(updateInput);
                        }
                    }
                }

                // insert
                if (input.YoshiMstInsertDT != null && input.YoshiMstInsertDT.Count > 0)
                {
                    YoshiMstDataSet.YoshiMstDataTable insertDT = new YoshiMstDataSet.YoshiMstDataTable();

                    foreach (YoshiMstDataSet.YoshiMstRow row in input.YoshiMstInsertDT)
                    {
                        // Get YoshiMst by key
                        IGetYoshiMstByKeyBLInput blInput = new GetYoshiMstByKeyBLInput();
                        blInput.YoshiCd = row.YoshiCd;
                        IGetYoshiMstByKeyBLOutput blOutput = new GetYoshiMstByKeyBusinessLogic().Execute(blInput);

                        if (blOutput.YoshiMstDT != null && blOutput.YoshiMstDT.Count > 0)
                        {
                            lstStr.Add(row.YoshiCd);
                        }
                        else
                        {
                            insertDT.ImportRow(row);
                        }
                    }

                    if (insertDT != null && insertDT.Count > 0)
                    {
                        IInsertYoshiMstBLInput insertInput = new InsertYoshiMstBLInput();
                        insertInput.YoshiMstInsertDT = insertDT;
                        IInsertYoshiMstBLOutput insertOutput = new InsertYoshiMstBusinessLogic().Execute(insertInput);
                    }
                }

                output.ListKey = lstStr;

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
