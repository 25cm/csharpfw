using System;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.Utility;
using FukjTabletSystem.Application.ApplicationLogic.Kensa.TaniSochiGroupAddDialog;
using FukjTabletSystem.Application.ApplicationLogic.TaniSochiGroupAddDialog;
using FukjTabletSystem.Application.Boundary.Common;
using FukjTabletSystem.Application.DataSet.SQLCE;
using FukjTabletSystem.Application.Utility;
using Zynas.Framework.Utility;
using System.Data;

namespace FukjTabletSystem.Application.Boundary.Kensa.Dialog
{    
    /// <summary>
    /// 所見判定選択ダイアログ
    /// </summary>
    public partial class TaniSochiGroupAddDialog : FukjTabBaseDialog
    {
        #region フィールド（private）

        /// <summary>
        /// 選択モード（所見／補足文）
        /// </summary>
        private ShokenUtility.SelectMode MySelectMode = ShokenUtility.SelectMode.Shoken;

        /// <summary>
        /// 選択種別（書類検査／水質検査／外観検査）
        /// </summary>
        private ShokenUtility.SelectType MySelectType = ShokenUtility.SelectType.GaikanKensa;

        /// <summary>
        /// 所見テーブルのキー
        /// </summary>
        private ShokenKey MyShokenKey = new ShokenKey();

        /// <summary>
        /// 単位装置グループマスタ（取得データ）
        /// </summary>
        private TaniSochiGroupMstDataSet.TaniSochiGroupMstDataTable taniSochiGroupMst = new TaniSochiGroupMstDataSet.TaniSochiGroupMstDataTable();
        
        /// <summary>
        /// 浄化槽台帳のキー
        /// </summary>
        private string MyJokasoHokenjoCd = string.Empty;
        private string MyJokasoTorokuNendo = string.Empty;
        private string MyJokasoRenban = string.Empty;
        
        #endregion

        #region プロパティ
        
        #endregion
        
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TaniSochiGroupAddDialog(ShokenUtility.SelectMode selectMode, ShokenUtility.SelectType selectType, ShokenKey shokenKey)
        {
            InitializeComponent();

            MySelectMode = selectMode;

            MySelectType = selectType;

            MyShokenKey = shokenKey;
        }
        #endregion

        #region イベントハンドラ

        #region Form_Load(object sender, EventArgs e)
        /// <summary>
        /// [Form_Load]イベント 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                // 基本情報の取得
                DoSearch();

                // 追加できる装置がない場合
                if (taniSochiGroupMst.Count == 0)
                {
                    TabMessageBox.Show2(TabMessageBox.Type.Info, "追加できる単位装置グループはありません。");

                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    this.Close();

                    return;
                }

                // 取得データの表示
                SetControlData();
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                TabMessageBox.Show(TabMessageBox.Type.Error, MessageResouce.MSGID_E00001, ex.Message);

                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                this.Close();
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion
                
        #region closeButton_Click(object sender, EventArgs e)
        /// <summary>
        /// 閉じるボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

                this.Close();
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
        #endregion
        
        #region ketteiButton_Click(object sender, EventArgs e)
        /// <summary>
        /// 確定ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ketteiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                IKakuteiBtnClickALInput alInput = new KakuteiBtnClickALInput();

                alInput.JokasoHoyuTaniSochiGroupTbl = CreateJokasoHoyuTaniSochiGroupTbl();

                // 更新実行
                new KakuteiBtnClickApplicationLogic().Execute(alInput);

                TabMessageBox.Show2(TabMessageBox.Type.Info, "浄化槽保有単位装置グループ追加", "単位装置グループを追加しました。");

                this.DialogResult = DialogResult.OK;

                this.Close();
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
        #endregion
        
        #endregion

        #region メソッド(private)

        #region DoSearch
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoSearch
        /// <summary>
        /// 表示データの検索を行う
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/15  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            // 所得済データを初期化
            taniSochiGroupMst.Clear();

            IGetTaniSochiGroupMstByNotInJokasoALInput alInput = new GetTaniSochiGroupMstByNotInJokasoALInput();

            alInput.IraiHoteiKbn = MyShokenKey.KensaIraiHoteiKbn;
            alInput.IraiHokenjoCd = MyShokenKey.KensaIraiHokenjoCd;
            alInput.IraiNendo = MyShokenKey.KensaIraiNendo;
            alInput.IraiRenban = MyShokenKey.KensaIraiRenban;

            alInput.ShokenTaishoKensaBitMask = ShokenUtility.GetBitMask(MySelectMode, MySelectType);

            IGetTaniSochiGroupMstByNotInJokasoALOutput alOutput = new GetTaniSochiGroupMstByNotInJokasoApplicationLogic().Execute(alInput);
            
            // 取得データを画面に保持
            taniSochiGroupMst.Merge(alOutput.TaniSochiGroupMst);

            // 浄化槽台帳のキーを保存
            MyJokasoHokenjoCd = alOutput.JokasoHokenjoCd;
            MyJokasoTorokuNendo = alOutput.JokasoTorokuNendo;
            MyJokasoRenban = alOutput.JokasoRenban;
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
        /// 2014/11/15  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlData()
        {
            try
            {
                // 描画を停止
                this.SuspendLayout();

                // リストボックス
                shokenHanteiDataSet.TaniSochiGroupMst.Clear();

                if (taniSochiGroupMst.Count > 0)
                {
                    int index = 0;

                    // 単位装置グループをリストに出力
                    foreach (TaniSochiGroupMstDataSet.TaniSochiGroupMstRow row in taniSochiGroupMst)
                    {
                        index++;

                        ShokenHanteiDataSet.TaniSochiGroupMstRow newRow = shokenHanteiDataSet.TaniSochiGroupMst.NewTaniSochiGroupMstRow();

                        foreach (DataColumn col in shokenHanteiDataSet.TaniSochiGroupMst.Columns)
                        {
                            if (col.ColumnName == "RowIndex")
                            {
                                newRow.RowIndex = index;
                            }
                            // 2015.01.13 toyoda Add Start
                            else if (col.ColumnName == "TaniSochiGroupDisplayNm")
                            {
                                newRow[col.ColumnName] = string.IsNullOrEmpty(row["TaniSochiGroupNm"].ToString()) ? "（文章なし）" : row["TaniSochiGroupNm"].ToString();
                            }
                            // 2015.01.13 toyoda Add End
                            else
                            {
                                newRow[col.ColumnName] = row[col.ColumnName];
                            }
                        }

                        shokenHanteiDataSet.TaniSochiGroupMst.AddTaniSochiGroupMstRow(newRow);
                    }

                    // 未選択とする
                    groupListBox.SelectedIndex = -1;
                }
            }
            finally
            {
                // 描画再開
                this.ResumeLayout();
            }
        }
        #endregion

        #region CreateJokasoHoyuTaniSochiGroupTbl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateJokasoHoyuTaniSochiGroupTbl
        /// <summary>
        /// 画面データを返却用用データに設定する
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/15  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private JokasoHoyuTaniSochiGroupTblDataSet.JokasoHoyuTaniSochiGroupTblDataTable CreateJokasoHoyuTaniSochiGroupTbl()
        {
            JokasoHoyuTaniSochiGroupTblDataSet.JokasoHoyuTaniSochiGroupTblDataTable datatable = new JokasoHoyuTaniSochiGroupTblDataSet.JokasoHoyuTaniSochiGroupTblDataTable();

            // 選択された所見を返却用のプロパティに設定する
            foreach (object item in groupListBox.SelectedItems)
            {
                JokasoHoyuTaniSochiGroupTblDataSet.JokasoHoyuTaniSochiGroupTblRow newRow = datatable.NewJokasoHoyuTaniSochiGroupTblRow();

                newRow.JokasoHokenjoCd = MyJokasoHokenjoCd;

                newRow.JokasoTorokuNendo = MyJokasoTorokuNendo;

                newRow.JokasoRenban = MyJokasoRenban;

                newRow.TaniSochiGroupCd = ((System.Data.DataRowView)(item))["TaniSochiGroupCd"].ToString();

                newRow.InsertDt = DateTime.Now;
                newRow.InsertTarm = Dns.GetHostName();
                newRow.InsertUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                newRow.UpdateDt = DateTime.Now;
                newRow.UpdateTarm = Dns.GetHostName();
                newRow.UpdateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

                datatable.AddJokasoHoyuTaniSochiGroupTblRow(newRow);
            }

            return datatable;
        }
        #endregion
        
        #endregion
    }
}
