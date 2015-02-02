using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.BusinessLogic.YoshiHanbaiKanri.ZaikoList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.YoshiHanbaiKanri.ZaikoList
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
    /// 2014/07/22　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKoshinBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// YoshiZaikoTblDTInsert
        /// </summary>
        YoshiZaikoTblDataSet.YoshiZaikoTblDataTable YoshiZaikoTblDTInsert { get; set; }

        /// <summary>
        /// YoshiZaikoTblDTUpdate
        /// </summary>
        YoshiZaikoTblDataSet.YoshiZaikoTblDataTable YoshiZaikoTblDTUpdate { get; set; }

        /// <summary>
        /// zikoListDataGridView
        /// </summary>
        DataGridView ZaikoListDataGridView { get; set; }

        /// <summary>
        /// ListKeyDelete
        /// </summary>
        List<string> ListKeyDelete { get; set; }


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
    /// 2014/07/22　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KoshinBtnClickALInput : IKoshinBtnClickALInput
    {
        /// <summary>
        /// YoshiZaikoTblDTInsert
        /// </summary>
        public YoshiZaikoTblDataSet.YoshiZaikoTblDataTable YoshiZaikoTblDTInsert { get; set; }

        /// <summary>
        /// YoshiZaikoTblDTUpdate
        /// </summary>
        public YoshiZaikoTblDataSet.YoshiZaikoTblDataTable YoshiZaikoTblDTUpdate { get; set; }

        /// <summary>
        /// ZaikoListDataGridView
        /// </summary>
        public DataGridView ZaikoListDataGridView { get; set; }

        /// <summary>
        /// ListKeyDelete
        /// </summary>
        public List<string> ListKeyDelete { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("支所コード[{0}], 用紙コード[{1}]",
                    ZaikoListDataGridView.Rows[0].Cells["ShishoCol"].Value.ToString(),
                    ZaikoListDataGridView.Rows[0].Cells["YoshiCol"].Value.ToString());
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
    /// 2014/07/22　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKoshinBtnClickALOutput
    {
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
    /// 2014/07/22　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KoshinBtnClickALOutput : IKoshinBtnClickALOutput
    {
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
    /// 2014/07/22　HuyTX　　    新規作成
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
        private const string FunctionName = "ZaikoList：KoshinBtnClick";

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
        /// 2014/07/22　HuyTX　　    新規作成
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
        /// 2014/07/22　HuyTX　　    新規作成
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
        /// 2014/07/22　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IKoshinBtnClickALOutput Execute(IKoshinBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKoshinBtnClickALOutput output = new KoshinBtnClickALOutput();

            try
            {
                // トランザクション開始
                StartTransaction();

                IUpdateYoshiZaikoTblBLInput blUpdateInput = new UpdateYoshiZaikoTblBLInput();

                DateTime currentDateTime = Boundary.Common.Common.GetCurrentTimestamp();
                string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                string tarmName = Dns.GetHostName();

                input.YoshiZaikoTblDTInsert = new YoshiZaikoTblDataSet.YoshiZaikoTblDataTable();
                input.YoshiZaikoTblDTUpdate = new YoshiZaikoTblDataSet.YoshiZaikoTblDataTable();
                input.ListKeyDelete = new List<string>();

                CreateYoshiZaikoData(input);

                //insert data
                if (input.YoshiZaikoTblDTInsert != null && input.YoshiZaikoTblDTInsert.Count > 0)
                {
                    blUpdateInput.YoshiZaikoTblDataTable = input.YoshiZaikoTblDTInsert;
                    new UpdateYoshiZaikoTblBusinessLogic().Execute(blUpdateInput);
                }

                //update data
                if (input.YoshiZaikoTblDTUpdate != null && input.YoshiZaikoTblDTUpdate.Count > 0)
                {
                    foreach (YoshiZaikoTblDataSet.YoshiZaikoTblRow row in input.YoshiZaikoTblDTUpdate)
                    {
                        IGetYoshiZaikoTblByKeyBLInput blInput = new GetYoshiZaikoTblByKeyBLInput();
                        blInput.YoshiZaikoShishoCd = row.YoshiZaikoShishoCd;
                        blInput.YoshiZaikoYoshiCd = row.YoshiZaikoYoshiCd;
                        IGetYoshiZaikoTblByKeyBLOutput blOutput = new GetYoshiZaikoTblByKeyBusinessLogic().Execute(blInput);

                        if (blOutput.YoshiZaikoTblDataTable.Count > 0)
                        {
                            if (row.UpdateDt != blOutput.YoshiZaikoTblDataTable[0].UpdateDt)
                            {
                                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                            }
                        }

                        blOutput.YoshiZaikoTblDataTable[0].YoshiZaikoSuryo = row.YoshiZaikoSuryo;
                        blOutput.YoshiZaikoTblDataTable[0].UpdateDt = currentDateTime;
                        blOutput.YoshiZaikoTblDataTable[0].UpdateUser = loginUser;
                        blOutput.YoshiZaikoTblDataTable[0].UpdateTarm = tarmName;

                        blUpdateInput.YoshiZaikoTblDataTable = blOutput.YoshiZaikoTblDataTable;

                        new UpdateYoshiZaikoTblBusinessLogic().Execute(blUpdateInput);

                    }
                }

                if (input.ListKeyDelete != null && input.ListKeyDelete.Count > 0)
                {
                    IDeleteYoshiZaikoTblByShishoCdAndYoshiCdBLInput deleteBLInput = new DeleteYoshiZaikoTblByShishoCdAndYoshiCdBLInput();
                    deleteBLInput.ListKey = input.ListKeyDelete;
                    new DeleteYoshiZaikoTblByShishoCdAndYoshiCdBusinessLogic().Execute(deleteBLInput);
                }

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

        #region CreateYoshiZaikoData
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateYoshiZaikoData
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/22  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CreateYoshiZaikoData(IKoshinBtnClickALInput input)
        {
            YoshiZaikoTblDataSet.YoshiZaikoTblDataTable yoshiZaikoDataTable = new YoshiZaikoTblDataSet.YoshiZaikoTblDataTable();

            DateTime currentDateTime = Boundary.Common.Common.GetCurrentTimestamp();
            string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            string tarmName = Dns.GetHostName();

            for (int i = 0; i < input.ZaikoListDataGridView.RowCount - 1; i++)
            {
                DataGridViewRow row = input.ZaikoListDataGridView.Rows[i];
                //YoshiZaikoTblDataSet.YoshiZaikoTblRow yoshiZaikoRow = yoshiZaikoDataTable.NewYoshiZaikoTblRow();

                if (row.Cells["DeleteFlgCol"].Value != null && row.Cells["DeleteFlgCol"].Value.ToString() == "1")
                {
                    string shishoCd = row.Cells["ShishoCol"].Value.ToString();
                    string yoshiCd = row.Cells["YoshiCol"].Value.ToString();

                    if (!input.ListKeyDelete.Contains(shishoCd + "-" + yoshiCd))
                    {
                        input.ListKeyDelete.Add(shishoCd + "-" + yoshiCd);
                    }
                }
                else
                {
                    if (row.Cells["SuryoOldCol"].Value == null)
                    {
                        YoshiZaikoTblDataSet.YoshiZaikoTblRow yoshiZaikoRow = input.YoshiZaikoTblDTInsert.NewYoshiZaikoTblRow();

                        //set data insert
                        yoshiZaikoRow.YoshiZaikoShishoCd = row.Cells["ShishoCol"].Value.ToString();
                        yoshiZaikoRow.YoshiZaikoYoshiCd = row.Cells["YoshiCol"].Value.ToString();
                        yoshiZaikoRow.YoshiZaikoSuryo = Convert.ToInt32(row.Cells["SuryoCdCol"].Value.ToString());

                        yoshiZaikoRow.InsertDt = currentDateTime;
                        yoshiZaikoRow.InsertUser = loginUser;
                        yoshiZaikoRow.InsertTarm = tarmName;
                        yoshiZaikoRow.UpdateDt = currentDateTime;
                        yoshiZaikoRow.UpdateUser = loginUser;
                        yoshiZaikoRow.UpdateTarm = tarmName;

                        input.YoshiZaikoTblDTInsert.AddYoshiZaikoTblRow(yoshiZaikoRow);
                        yoshiZaikoRow.AcceptChanges();
                        yoshiZaikoRow.SetAdded();
                    }
                    else if (row.Cells["SuryoOldCol"].Value.ToString() != row.Cells["SuryoCdCol"].Value.ToString())
                    {

                        YoshiZaikoTblDataSet.YoshiZaikoTblRow yoshiZaikoRow = input.YoshiZaikoTblDTUpdate.NewYoshiZaikoTblRow();

                        //set data update
                        yoshiZaikoRow.YoshiZaikoShishoCd = row.Cells["ShishoCol"].Value.ToString();
                        yoshiZaikoRow.YoshiZaikoYoshiCd = row.Cells["YoshiCol"].Value.ToString();
                        yoshiZaikoRow.YoshiZaikoSuryo = Convert.ToInt32(row.Cells["SuryoCdCol"].Value.ToString());

                        yoshiZaikoRow.InsertDt = (DateTime)row.Cells["InsertDt"].Value;
                        yoshiZaikoRow.InsertUser = row.Cells["InsertUser"].Value.ToString();
                        yoshiZaikoRow.InsertTarm = row.Cells["InsertTarm"].Value.ToString();
                        yoshiZaikoRow.UpdateDt = (DateTime)row.Cells["UpdateDt"].Value;
                        yoshiZaikoRow.UpdateUser = loginUser;
                        yoshiZaikoRow.UpdateTarm = tarmName;

                        input.YoshiZaikoTblDTUpdate.AddYoshiZaikoTblRow(yoshiZaikoRow);

                        yoshiZaikoRow.AcceptChanges();
                        yoshiZaikoRow.SetAdded();
                    }

                }

            }
        }
        #endregion

        #endregion
    }
    #endregion
}
