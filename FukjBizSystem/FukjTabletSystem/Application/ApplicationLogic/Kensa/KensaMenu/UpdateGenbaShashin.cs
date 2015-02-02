using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.Utility;
using FukjTabletSystem.Application.BusinessLogic.Kensa.KensaMenu;
using FukjTabletSystem.Application.DataSet.SQLCE;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.ApplicationLogic.Kensa.KensaMenu
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateGenbaShashinALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/26　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateGenbaShashinALInput : IBseALInput
    {
        /// <summary>
        /// IraiHoteiKbn
        /// </summary>
        string IraiHoteiKbn { get; set; }

        /// <summary>
        /// IraiHokenjoCd
        /// </summary>
        string IraiHokenjoCd { get; set; }

        /// <summary>
        /// IraiNendo
        /// </summary>
        string IraiNendo { get; set; }

        /// <summary>
        /// IraiRenban
        /// </summary>
        string IraiRenban { get; set; }

        /// <summary>
        /// FilePathList
        /// </summary>
        List<string> FilePathList { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateGenbaShashinALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/26　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateGenbaShashinALInput : IUpdateGenbaShashinALInput
    {
        /// <summary>
        /// IraiHoteiKbn
        /// </summary>
        public string IraiHoteiKbn { get; set; }

        /// <summary>
        /// IraiHokenjoCd
        /// </summary>
        public string IraiHokenjoCd { get; set; }

        /// <summary>
        /// IraiNendo
        /// </summary>
        public string IraiNendo { get; set; }

        /// <summary>
        /// IraiRenban
        /// </summary>
        public string IraiRenban { get; set; }

        /// <summary>
        /// FilePathList
        /// </summary>
        public List<string> FilePathList { get; set; }

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
    //  インターフェイス名 ： IUpdateGenbaShashinALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/26　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateGenbaShashinALOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateGenbaShashinALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/26　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateGenbaShashinALOutput : IUpdateGenbaShashinALOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateGenbaShashinApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/26　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateGenbaShashinApplicationLogic : BaseApplicationLogic<IUpdateGenbaShashinALInput, IUpdateGenbaShashinALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaMenu：UpdateGenbaShashin";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： UpdateGenbaShashinApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/26　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public UpdateGenbaShashinApplicationLogic()
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
        /// 2014/11/26　豊田　　    新規作成
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
        /// 2014/11/26　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IUpdateGenbaShashinALOutput Execute(IUpdateGenbaShashinALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdateGenbaShashinALOutput output = new UpdateGenbaShashinALOutput();

            try
            {
                try
                {
                    // トランザクション開始
                    StartTransactionCe();

                    // 既存の連番最大値を取得
                    IGetMaxGenbaShashinCdByKensaIraiKeyBLInput getInput = new GetMaxGenbaShashinCdByKensaIraiKeyBLInput();
                    getInput.IraiHokenjoCd = input.IraiHokenjoCd;
                    getInput.IraiHoteiKbn = input.IraiHoteiKbn;
                    getInput.IraiNendo = input.IraiNendo;
                    getInput.IraiRenban = input.IraiRenban;

                    IGetMaxGenbaShashinCdByKensaIraiKeyBLOutput getOutput = new GetMaxGenbaShashinCdByKensaIraiKeyBusinessLogic().Execute(getInput);

                    // 登録する連番
                    int myRenban = string.IsNullOrEmpty(getOutput.MaxGenbaShashinCd) ? 0 : int.Parse(getOutput.MaxGenbaShashinCd);

                    // 登録データの作成
                    GenbaShashinTblDataSet.GenbaShashinTblDataTable datatable = new GenbaShashinTblDataSet.GenbaShashinTblDataTable();

                    foreach (string filePath in input.FilePathList)
                    {
                        // 連番をカウントアップ
                        myRenban++;

                        GenbaShashinTblDataSet.GenbaShashinTblRow newRow = datatable.NewGenbaShashinTblRow();

                        newRow.GenbaShashinKensaHoteiKbn = input.IraiHoteiKbn;
                        newRow.GenbaShashinKensaHokenjoCd = input.IraiHokenjoCd;
                        newRow.GenbaShashinKensaNendo = input.IraiNendo;
                        newRow.GenbaShashinKensaRenban = input.IraiRenban;
                        newRow.GenbaShashinCd = string.Format("{0:000}", myRenban);
                        newRow.GenbaShashinFilePath = filePath;

                        newRow.InsertDt = DateTime.Now;
                        newRow.InsertTarm = Dns.GetHostName();
                        newRow.InsertUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                        newRow.UpdateDt = DateTime.Now;
                        newRow.UpdateTarm = Dns.GetHostName();
                        newRow.UpdateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

                        datatable.AddGenbaShashinTblRow(newRow);

                        newRow.AcceptChanges();
                        newRow.SetAdded();
                    }

                    // 登録実行
                    IUpdateGenbaShashinTblBLInput updInput = new UpdateGenbaShashinTblBLInput();
                    updInput.GenbaShashinTbl = datatable;
                    new UpdateGenbaShashinTblBusinessLogic().Execute(updInput);

                    // コミット
                    CompleteTransactionCe();
                }
                catch
                {
                    throw;
                }
                finally
                {
                    // トランザクション終了
                    EndTransactionCe();
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
