using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.Boundary.Master;
using FukjBizSystem.Application.BusinessLogic.Master.NameMstEditList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Master.NameMstEditList
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
    /// 2014/06/27  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKoshinBtnClickALInput : IBseALInput, IInsertNameMstBLInput
    {
        /// <summary>
        /// NameMstUpdateDataTable
        /// </summary>
        NameMstUpdateDataSet.NameMstUpdateDataTable NameMstUpdateDT { get; set; }
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
    /// 2014/06/27  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KoshinBtnClickALInput : IKoshinBtnClickALInput
    {
        /// <summary>
        /// NameMstUpdateDataTable
        /// </summary>
        public NameMstUpdateDataSet.NameMstUpdateDataTable NameMstUpdateDT { get; set; }

        /// <summary>
        /// NameMstDataTable
        /// </summary>
        public NameMstDataSet.NameMstDataTable NameMstDT { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Empty;
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
    /// 2014/06/27  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKoshinBtnClickALOutput : IInsertNameMstBLOutput
    {
        /// <summary>
        /// List (NameKbn + NameCd) for duplication check
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
    /// 2014/06/27  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KoshinBtnClickALOutput : IKoshinBtnClickALOutput, IUpdateNameMstByKeyBLOutput
    {
        /// <summary>
        /// List (NameKbn + NameCd) for duplication check
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
    /// 2014/06/27  DatNT　　    新規作成
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
        private const string FunctionName = "NameMstEditList：KoshinBtnClickApplicationLogic";

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
        /// 2014/06/27  DatNT　　    新規作成
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
        /// 2014/06/27  DatNT　　    新規作成
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
        /// 2014/06/27  DatNT　　    新規作成
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

                // list (namekbn + namecd) was existed
                List<string> lstStr = new List<string>();

                DateTime now = Boundary.Common.Common.GetCurrentTimestamp();
                string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                string pcUpdate = Dns.GetHostName();

                // update
                if (input.NameMstUpdateDT != null && input.NameMstUpdateDT.Count > 0)
                {   
                    // Check duplicate
                    foreach (NameMstUpdateDataSet.NameMstUpdateRow row in input.NameMstUpdateDT)
                    {
                        // get NameMst by key
                        IGetNameMstByKeyBLInput blInput = new GetNameMstByKeyBLInput();
                        blInput.NameKbn = row.NameKbnNew;
                        blInput.NameCd = row.NameCdNew;
                        IGetNameMstByKeyBLOutput blOutput = new GetNameMstByKeyBusinessLogic().Execute(blInput);

                        if (blOutput.NameMstDT != null && blOutput.NameMstDT.Count > 0 && (row.NameKbnNew != row.NameKbnOld || row.NameCdNew != row.NameCdOld))
                        {
                            lstStr.Add(row.NameKbnNew + "-" + row.NameCdNew);
                        }
                        else 
                        {
                            //20150130 HuyTX Fix Start
                            if (lstStr.Contains(row.NameKbnOld + "-" + row.NameCdOld)) continue;

                            //Get NameMst original for Rakkan check
                            blInput = new GetNameMstByKeyBLInput();
                            blInput.NameKbn = row.NameKbnOld;
                            blInput.NameCd = row.NameCdOld;
                            blOutput = new GetNameMstByKeyBusinessLogic().Execute(blInput);

                            if (blOutput.NameMstDT == null || blOutput.NameMstDT.Count == 0) continue;
                            //20150130 HuyTX Fix End

                            // 更新日が違うか？
                            if (row.UpdateDt != blOutput.NameMstDT[0].UpdateDt)
                            {
                                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                            }

                            row.UpdateDt = now;
                            row.UpdateUser = loginUser;
                            row.UpdateTarm = pcUpdate;

                            IUpdateNameMstByKeyBLInput updateInput = new UpdateNameMstByKeyBLInput();
                            updateInput.NameMstUpdateRow = row;
                            IUpdateNameMstByKeyBLOutput updateOutput = new UpdateNameMstByKeyBusinessLogic().Execute(updateInput);   
                        }
                    }
                }

                // insert
                if (input.NameMstDT != null && input.NameMstDT.Count > 0)
                {
                    NameMstDataSet.NameMstDataTable insertDT = new NameMstDataSet.NameMstDataTable();

                    foreach (NameMstDataSet.NameMstRow row in input.NameMstDT)
                    {
                        // get NameMst by key
                        IGetNameMstByKeyBLInput blInput = new GetNameMstByKeyBLInput();
                        blInput.NameKbn = row.NameKbn;
                        blInput.NameCd = row.NameCd;
                        IGetNameMstByKeyBLOutput blOutput = new GetNameMstByKeyBusinessLogic().Execute(blInput);

                        if (blOutput.NameMstDT != null && blOutput.NameMstDT.Count > 0)
                        {
                            lstStr.Add(row.NameKbn + "-" + row.NameCd);
                        }
                        else
                        {
                            insertDT.ImportRow(row);
                        }
                    }

                    if (insertDT != null && insertDT.Count > 0)
                    {
                        IInsertNameMstBLInput insertInput = new InsertNameMstBLInput();
                        insertInput.NameMstDT = insertDT;
                        IInsertNameMstBLOutput insertOutput = new InsertNameMstBusinessLogic().Execute(insertInput);
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
