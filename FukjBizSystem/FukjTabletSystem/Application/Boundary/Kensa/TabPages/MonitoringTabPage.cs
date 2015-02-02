using System;
using System.Data;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using FukjTabletSystem.Application.ApplicationLogic.Kensa.MonitoringTabPage;
using FukjTabletSystem.Application.DataSet.SQLCE;
using FukjTabletSystem.Application.Utility;
using FukjTabletSystem.Controls;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.Boundary.Kensa.TabPages
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： MonitoringTabPage
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17  戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class MonitoringTabPage : BaseKensaTabPage
    {

        #region フィールド(private)

        /// <summary>
        /// 表示データ設定中フラグ
        /// </summary>
        private bool isInSetData = false;

        /// <summary>
        /// 取得データ（情報：グループ＋詳細）
        /// </summary>
        private MonitoringGroupMstDataSet.MonitoringInfoDataTable myMonitoringInfo = new MonitoringGroupMstDataSet.MonitoringInfoDataTable();

        /// <summary>
        /// 取得データ（モニタリングテーブル）
        /// </summary>
        private MonitoringTblDataSet.MonitoringTblDataTable myMonitoringTbl = new MonitoringTblDataSet.MonitoringTblDataTable();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： MonitoringTabPage
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17  戸口　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public MonitoringTabPage()
        {
            InitializeComponent();
        }
        #endregion

        #region イベントハンドラ

        #region MonitoringTabPage_Load
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MonitoringTabPage_Load(object sender, System.EventArgs e)
        {
            #region リストビューアイテムの設定

            monitorItemsView.SuspendLayout();

            // モニタリング情報取得（グループと詳細を結合したもの）
            DoSearchInfo();

            // モニタリングテーブル取得
            DoSearchTbl();

            // 取得データの表示
            SetControlData();

            // 選択件数の表示
            monitorItemsView.SetCount();

            monitorItemsView.ResumeLayout();

            #endregion
        }
        #endregion

        /// <summary>
        /// 確定登録ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kakuteiButton_Click(object sender, EventArgs e) 
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                // ツリービューでチェックＯＮのデータを収集する
                IKakuteiBtnClickALInput alInput = new KakuteiBtnClickALInput();
                alInput.MonitoringTbl = CreateMonitoringTbl();

                // 検査依頼のキー情報をセット
                alInput.IraiHoteiKbn = ((KensaMenuForm)this.TopLevelControl).IraiHoteiKbn;
                alInput.IraiHokenjoCd = ((KensaMenuForm)this.TopLevelControl).IraiHokenjoCd;
                alInput.IraiNendo = ((KensaMenuForm)this.TopLevelControl).IraiNendo;
                alInput.IraiRenban = ((KensaMenuForm)this.TopLevelControl).IraiRenban;

                // 更新実行
                new KakuteiBtnClickApplicationLogic().Execute(alInput);

                TabMessageBox.Show2(TabMessageBox.Type.Info, "モニタリング", "モニタリング結果を登録ました。");

                // モニタリングテーブルを再取得
                DoSearchTbl();

                // 編集無し(初期化)
                this.IsEdited = false;

            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                TabMessageBox.Show(TabMessageBox.Type.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }

        }

        /// <summary>
        /// ツリーノードのチェックボックスをオン／オフした場合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void monitorItemsView_AfterCheck(object sender, TreeViewEventArgs e) 
        {
            // 画面の初期表示時以外
            if(!isInSetData)
            {
                this.IsEdited = true;   // 画面編集済みフラグをＯＮ
            }
        }

        #endregion

        #region メソッド(private)

        #region DoSearchInfo
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoSearchInfo
        /// <summary>
        /// 表示データの検索を行う（モニタリンググループと詳細を結合して取得）
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/14　戸口　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearchInfo() 
        {
            try
            {

                myMonitoringInfo.Clear();

                IGetMonitoringInfoALInput alInput = new GetMonitoringInfoALInput();

                IGetMonitoringInfoALOutput alOutput = new GetMonitoringInfoApplicationLogic().Execute(alInput);

                if (alOutput.MonitoringInfo.Count == 0)
                {
                    // データなしは想定外
                    throw new CustomException(0, "モニタリング情報が取得できませんでした。");
                }

                // 取得データを画面に保持
                myMonitoringInfo.Merge(alOutput.MonitoringInfo);
            }
            finally
            {
            }
        }
        #endregion

        #region DoSearchTbl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoSearchTbl
        /// <summary>
        /// 表示データの検索を行う（モニタリングテーブルを検査依頼のキーで検索）
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/14　戸口　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearchTbl()
        {
            try
            {

                myMonitoringTbl.Clear();

                IGetMonitoringTblALInput alInput = new GetMonitoringTblALInput();

                alInput.IraiHoteiKbn = ((KensaMenuForm)this.TopLevelControl).IraiHoteiKbn;
                alInput.IraiHokenjoCd = ((KensaMenuForm)this.TopLevelControl).IraiHokenjoCd;
                alInput.IraiNendo = ((KensaMenuForm)this.TopLevelControl).IraiNendo;
                alInput.IraiRenban = ((KensaMenuForm)this.TopLevelControl).IraiRenban;

                IGetMonitoringTblALOutput alOutput = new GetMonitoringTblApplicationLogic().Execute(alInput);

                // 取得データを画面に保持
                myMonitoringTbl.Merge(alOutput.MonitoringTbl);
            }
            finally
            {
            }
        }
        #endregion

        #region SetControlData
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetControlData
        /// <summary>
        /// 取得データを画面コントロールにマッピングする
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17  戸口　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlData()
        {
            try
            {
                // マッピング中オン
                isInSetData = true;

                // 描画を停止
                this.SuspendLayout();


                TriStateTreeNode rootNode;

                string last_MonitoringGroupCd = String.Empty;
                string last_MonitoringKbn = String.Empty;
                string wk_MonitoringKbn = String.Empty;
                TriStateTreeNode last_RootNode = null;
                TriStateTreeNode last_SubNode = null;

                //グループ単位で詳細を表示
                foreach (MonitoringGroupMstDataSet.MonitoringInfoRow infoRow in myMonitoringInfo)
                {
                    #region ルートノード
                    if (!last_MonitoringGroupCd.Equals(infoRow.MonitoringGroupCd))
                    {
                        //グループが変わったらノードにグループを追加
                        rootNode = new TriStateTreeNode(infoRow.MonitoringGroupNm);
                        rootNode.CheckboxVisible = false;
                        rootNode.IsContainer = true;
                        monitorItemsView.Nodes.Add(rootNode);

                        last_MonitoringKbn = String.Empty;  //上位が切り替わったので、下位も初期化
                        last_RootNode = rootNode;
                    }

                    last_MonitoringGroupCd = infoRow.MonitoringGroupCd;

                    #endregion

                    #region サブノード
                    if (!last_MonitoringKbn.Equals(infoRow.MonitoringKbn))
                    {
                        TriStateTreeNode subNode;
                        if (infoRow.MonitoringKbn.Equals("1"))
                        {
                            wk_MonitoringKbn = "質問";
                        }
                        else if (infoRow.MonitoringKbn.Equals("2"))
                        {
                            wk_MonitoringKbn = "不満";
                        }
                        else
                        {
                            wk_MonitoringKbn = String.Empty;
                        }
                        subNode = new TriStateTreeNode(wk_MonitoringKbn);
                        subNode.CheckboxVisible = false;
                        subNode.IsContainer = true;
                        if (last_RootNode != null)
                        {
                            last_RootNode.Nodes.Add(subNode);
                        }

                        last_MonitoringKbn = infoRow.MonitoringKbn;
                        last_SubNode = subNode;
                    }

                    #endregion

                    #region アイテムノード

                    TriStateTreeNode itemNode;

                    itemNode = new TriStateTreeNode(infoRow.MonitoringShosaiNm, 2, 2);

                    // アイテムノードがモニタリングテーブルに既存の場合、チェックをＯＮにする
                    DataRow[] wkList = myMonitoringTbl.Select(
                        "MonitoringGroupCd = '" + infoRow.MonitoringGroupCd + 
                        "' AND MonitoringKbn = '" + infoRow.MonitoringKbn + 
                        "' AND MonitoringShosaiCd = '" + infoRow.MonitoringShosaiCd + "'"
                    );

                    if (wkList.Length > 0)
                    {
                        itemNode.Checked = true;
                    }
                    else
                    {
                        itemNode.Checked = false;
                    }

                    // モニタリングテーブルの登録用キーを設定
                    itemNode.PK1_KensaIraiHoteiKbn = ((KensaMenuForm)this.TopLevelControl).IraiHoteiKbn;
                    itemNode.PK2_KensaIraiHokenjoCd = ((KensaMenuForm)this.TopLevelControl).IraiHokenjoCd;
                    itemNode.PK3_KensaIraiNendo = ((KensaMenuForm)this.TopLevelControl).IraiNendo;
                    itemNode.PK4_KensaIraiRenban = ((KensaMenuForm)this.TopLevelControl).IraiRenban;
                    itemNode.PK5_MonitoringGroupCd = infoRow.MonitoringGroupCd;
                    itemNode.PK6_MonitoringKbn = infoRow.MonitoringKbn;
                    itemNode.PK7_MonitoringShosaiCd = infoRow.MonitoringShosaiCd;

                    itemNode.CheckboxVisible = true;

                    if (last_SubNode != null)
                    {
                        last_SubNode.Nodes.Add(itemNode);
                    }

                    #endregion

                }

            }
            finally
            {
                // 描画再開
                this.ResumeLayout();

                // マッピング中オフ
                isInSetData = false;
            }
        }
        #endregion

        #region CreateMonitoringTbl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateJMonitoringTbl
        /// <summary>
        /// 画面データを更新用データに設定する
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17  戸口　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private MonitoringTblDataSet.MonitoringTblDataTable CreateMonitoringTbl()
        {
            MonitoringTblDataSet.MonitoringTblDataTable datatable = new MonitoringTblDataSet.MonitoringTblDataTable();

            //ツリービューの全件を処理
            foreach (TriStateTreeNode node_lv1 in monitorItemsView.Nodes)
            {
                foreach (TriStateTreeNode node_lv2 in node_lv1.Nodes)
                {
                    foreach (TriStateTreeNode node_lv3 in node_lv2.Nodes)
                    {
                        //チェックが付いている末端ノードを登録
                        if (node_lv3.Checked)
                        {
                            MonitoringTblDataSet.MonitoringTblRow newRow = datatable.NewMonitoringTblRow();

                            // モニタリングテーブル登録内容の設定
                            newRow.KensaIraiHoteiKbn = node_lv3.PK1_KensaIraiHoteiKbn;
                            newRow.KensaIraiHokenjoCd = node_lv3.PK2_KensaIraiHokenjoCd;
                            newRow.KensaIraiNendo = node_lv3.PK3_KensaIraiNendo;
                            newRow.KensaIraiRenban = node_lv3.PK4_KensaIraiRenban;
                            newRow.MonitoringGroupCd = node_lv3.PK5_MonitoringGroupCd;
                            newRow.MonitoringKbn = node_lv3.PK6_MonitoringKbn;
                            newRow.MonitoringShosaiCd = node_lv3.PK7_MonitoringShosaiCd;
                            newRow.InsertDt = DateTime.Now;
                            newRow.InsertUser = FukjBizSystem.Application.Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                            newRow.InsertTarm = Dns.GetHostName();
                            newRow.UpdateDt = DateTime.Now;
                            newRow.UpdateUser = FukjBizSystem.Application.Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                            newRow.UpdateTarm = Dns.GetHostName();

                            datatable.AddMonitoringTblRow(newRow);

                            datatable[datatable.Count - 1].AcceptChanges();
                            datatable[datatable.Count - 1].SetAdded();

                        }
                    }
                }
            }

            return datatable;
        }
        #endregion

        #endregion

    }

    #endregion
}
