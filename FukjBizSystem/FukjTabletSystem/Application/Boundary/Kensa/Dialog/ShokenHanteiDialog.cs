using System;
using System.Data;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.Utility;
using FukjTabletSystem.Application.ApplicationLogic.Kensa.ShokenHanteiDialog;
using FukjTabletSystem.Application.Boundary.Common;
using FukjTabletSystem.Application.DataSet.SQLCE;
using FukjTabletSystem.Application.Utility;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.Boundary.Kensa.Dialog
{    
    /// <summary>
    /// 所見判定選択ダイアログ
    /// </summary>
    public partial class ShokenHanteiDialog : FukjTabBaseDialog
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
        /// 型式別単位装置マスタ（取得データ）
        /// </summary>
        private KatashikiBetsuTaniSochiMstDataSet.KatashikiBetsuTaniSochiMstDataTable katashikiBetsuTaniSochiMst = new KatashikiBetsuTaniSochiMstDataSet.KatashikiBetsuTaniSochiMstDataTable();

        /// <summary>
        /// 単位装置グループマスタ（取得データ）
        /// </summary>
        private TaniSochiGroupMstDataSet.TaniSochiGroupMstDataTable taniSochiGroupMst = new TaniSochiGroupMstDataSet.TaniSochiGroupMstDataTable();

        /// <summary>
        /// 単位装置検査項目マスタ（取得データ）
        /// </summary>
        private TaniSochiKensaKomokuMstDataSet.TaniSochiKensaKomokuMstDataTable taniSochiKensaKomokuMst = new TaniSochiKensaKomokuMstDataSet.TaniSochiKensaKomokuMstDataTable();
        
        /// <summary>
        /// 単位装置検査状況マスタ（取得データ）
        /// </summary>
        private TaniSochiKensaJokyoMstDataSet.TaniSochiKensaJokyoMstDataTable taniSochiKensaJokyoMst = new TaniSochiKensaJokyoMstDataSet.TaniSochiKensaJokyoMstDataTable();

        /// <summary>
        /// 単位装置検査状況程度マスタ（取得データ）
        /// </summary>
        private TaniSochiKensaJokyoTeidoMstDataSet.TaniSochiKensaJokyoTeidoMstDataTable taniSochiKensaJokyoTeidoMst = new TaniSochiKensaJokyoTeidoMstDataSet.TaniSochiKensaJokyoTeidoMstDataTable();

        /// <summary>
        /// 所見マスタ（取得データ）
        /// </summary>
        private ShokenMstDataSet.ShokenMstDataTable shokenMst = new ShokenMstDataSet.ShokenMstDataTable();

        /// <summary>
        /// 所見結果（返却データ）
        /// </summary>
        private ShokenKekkaTblDataSet.ShokenKekkaTblDataTable shokenkekkaTbl = new ShokenKekkaTblDataSet.ShokenKekkaTblDataTable();

        /// <summary>
        /// 所見結果補足（返却データ）
        /// </summary>
        private ShokenKekkaHosokuTblDataSet.ShokenKekkaHosokuListDataTable shokenkekkaHosokuList = new ShokenKekkaHosokuTblDataSet.ShokenKekkaHosokuListDataTable();
                
        #endregion

        #region プロパティ

        /// <summary>
        /// 選択された所見結果(Row)
        /// </summary>
        /// <returns></returns>
        public ShokenKekkaTblDataSet.ShokenKekkaTblRow SelectedShokenKekkaRow
        {
            get { return shokenkekkaTbl.Count > 0 ? shokenkekkaTbl[0] : null; }
        }

        /// <summary>
        /// 選択された所見(Row)
        /// </summary>
        /// <returns></returns>
        public ShokenHanteiDataSet.ShokenMstRow SelectedShokenMstRow
        {
            get { return shokenHanteiDataSet.ShokenMst.Count > 0 ? shokenHanteiDataSet.ShokenMst[0] : null; }
        }

        /// <summary>
        /// 選択された所見補足(Table)
        /// </summary>
        /// <returns></returns>
        public ShokenKekkaHosokuTblDataSet.ShokenKekkaHosokuListDataTable SelectedShokenKekkaHosku
        {
            get { return shokenkekkaHosokuList; }
        }

        #endregion
        
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ShokenHanteiDialog(ShokenUtility.SelectMode selectMode, ShokenUtility.SelectType selectType, ShokenKey shokenKey)
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

                #region コントロール活性化制御

                // 画面モード切替
                if (MySelectMode == ShokenUtility.SelectMode.Hosokubun)
                {
                    this.Height -= 145;

                    this.titleLabel.Text = "補足文自動判定";

                    this.label6.Text = "選択された補足文";

                    this.checkPanel.Visible = false;

                    this.hosokuBunButton.Visible = false;
                }

                // 業者への連絡
                if (MySelectType == ShokenUtility.SelectType.GaikanKensa)
                {
                    renrakuSecchishaCheckBox.Enabled = true;
                    renrakuTenkenGyoushaCheckBox.Enabled = true;
                    renrakuSeisouGyoushaCheckBox.Enabled = true;
                    renrakuKoujiGyoushaCheckBox.Enabled = true;
                    renrakuMakerCheckBox.Enabled = true;
                    renrakuHokenjoCheckBox.Enabled = true;
                }
                else if (MySelectType == ShokenUtility.SelectType.ShoruiKensa)
                {
                    renrakuHoshuKeiyakuCheckBox.Enabled = true;
                    renrakuTenkenKaisuuCheckBox.Enabled = true;
                    renrakuSeisouKaisuuCheckBox.Enabled = true;
                }

                #endregion

                // 基本情報の取得
                DoSearch();

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

        #region hosokuBunButton_Click(object sender, EventArgs e)
        /// <summary>
        /// 補足文ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hosokuBunButton_Click(object sender, EventArgs e)
        {
            using (ShokenHanteiDialog frm = new ShokenHanteiDialog(ShokenUtility.SelectMode.Hosokubun, MySelectType, MyShokenKey))
            {
                frm.ShowDialog();

                if (frm.DialogResult != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }

                // 選択された所見を補足文として保存する
                ShokenKekkaHosokuTblDataSet.ShokenKekkaHosokuListRow newRow = shokenkekkaHosokuList.NewShokenKekkaHosokuListRow();

                // 所見内容をコピー
                foreach (System.Data.DataColumn col in shokenkekkaHosokuList.Columns)
                {
                    // 補足連番はデータ件数＋1
                    if (col.ColumnName == "KensaIraiShokenHosokuRenban")
                    {
                        newRow[col.ColumnName] = string.Format("{0:00}", (shokenkekkaHosokuList.Count + 1));
                    }
                    // 所見文字列は所見マスタより取得
                    else if (col.ColumnName == "ShokenWd")
                    {
                        newRow[col.ColumnName] = frm.SelectedShokenMstRow[col.ColumnName];
                    }
                    // 所見結果は所見結果行より取得
                    else
                    {
                        newRow[col.ColumnName] = frm.SelectedShokenKekkaRow[col.ColumnName];
                    }
                }

                // 行の追加
                shokenkekkaHosokuList.AddShokenKekkaHosokuListRow(newRow);

                newRow.AcceptChanges();
                newRow.SetAdded();

                // 所見文字の更新
                SetShokenText(shokenHanteiDataSet.ShokenMst.Count > 0 ? shokenHanteiDataSet.ShokenMst[0].ShokenWd : string.Empty);
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

                if (shokenHanteiDataSet.ShokenMst.Count == 0)
                {
                    TabMessageBox.Show2(TabMessageBox.Type.Warn, "所見が選択されていません。");

                    return;
                }

                // 返却用データの作成
                shokenkekkaTbl = CreateShokenKekkaTbl();

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

        #region groupListBox_SelectedValueChanged(object sender, EventArgs e)
        /// <summary>
        /// 所見グループ選択変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                shokenHanteiDataSet.ShokenMst.Clear();
                shokenHanteiDataSet.TaniSochiKensaJokyoTeidoMst.Clear();
                shokenHanteiDataSet.TaniSochiKensaJokyoMst.Clear();
                shokenHanteiDataSet.TaniSochiKensaKomokuMst.Clear();
                SetShokenText(string.Empty);

                // 未選択の場合
                if (groupListBox.SelectedIndex == -1)
                {
                    return;
                }

                // 対象の項目を抽出
                DataRow[] rows = taniSochiKensaKomokuMst.Select(string.Format("KensaTaniSochiGroupCd='{0}'", groupListBox.SelectedValue.ToString()));

                // 検査項目をリストに設定
                foreach(DataRow row in rows)
                {
                    shokenHanteiDataSet.TaniSochiKensaKomokuMst.ImportRow(row);
                }

                // 未選択
                koumokuListBox.SelectedIndex = -1;
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

        #region koumokuListBox_SelectedValueChanged(object sender, EventArgs e)
        /// <summary>
        /// 所見項目選択変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void koumokuListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                shokenHanteiDataSet.ShokenMst.Clear();
                shokenHanteiDataSet.TaniSochiKensaJokyoTeidoMst.Clear();
                shokenHanteiDataSet.TaniSochiKensaJokyoMst.Clear();
                SetShokenText(string.Empty);

                // 未選択の場合
                if (koumokuListBox.SelectedIndex == -1)
                {
                    return;
                }

                // 対象の項目を抽出
                DataRow[] rows = taniSochiKensaJokyoMst.Select(string.Format("KensaTaniSochiGroupCd='{0}' AND TaniSochiKensaKomokuCd = '{1}'",
                    groupListBox.SelectedValue.ToString(),
                    koumokuListBox.SelectedValue.ToString()));

                // 検査状況をリストに設定
                foreach (DataRow row in rows)
                {
                    shokenHanteiDataSet.TaniSochiKensaJokyoMst.ImportRow(row);
                }
                
                // 未選択
                joukyouListBox.SelectedIndex = -1;
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

        #region joukyouListBox_SelectedValueChanged(object sender, EventArgs e)
        /// <summary>
        /// 所見状況選択変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void joukyouListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                shokenHanteiDataSet.ShokenMst.Clear();
                shokenHanteiDataSet.TaniSochiKensaJokyoTeidoMst.Clear();
                SetShokenText(string.Empty);

                // 未選択の場合
                if (joukyouListBox.SelectedIndex == -1)
                {
                    return;
                }

                // 対象の項目を抽出
                DataRow[] rows = taniSochiKensaJokyoTeidoMst.Select(string.Format("KensaTaniSochiGroupCd='{0}' AND TaniSochiKensaKomokuCd = '{1}' AND TaniSochiKensaJokyoCd = '{2}'",
                    groupListBox.SelectedValue.ToString(),
                    koumokuListBox.SelectedValue.ToString(),
                    joukyouListBox.SelectedValue.ToString()));

                // 検査状況程度をリストに設定
                foreach (DataRow row in rows)
                {
                    shokenHanteiDataSet.TaniSochiKensaJokyoTeidoMst.ImportRow(row);
                }

                // 未選択
                teidoListBox.SelectedIndex = -1;
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

        #region teidoListBox_SelectedValueChanged(object sender, EventArgs e)
        /// <summary>
        /// 所見程度選択変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void teidoListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                shokenHanteiDataSet.ShokenMst.Clear();
                SetShokenText(string.Empty);

                // 未選択の場合
                if (teidoListBox.SelectedIndex == -1)
                {
                    return;
                }

                // 対象の項目を抽出
                DataRow[] rows = taniSochiKensaJokyoTeidoMst.Select(string.Format("KensaTaniSochiGroupCd='{0}' AND TaniSochiKensaKomokuCd = '{1}' AND TaniSochiKensaJokyoCd = '{2}' AND TaniSochiKensaJokyoTeidoCd = '{3}'",
                    groupListBox.SelectedValue.ToString(),
                    koumokuListBox.SelectedValue.ToString(),
                    joukyouListBox.SelectedValue.ToString(),
                    teidoListBox.SelectedValue.ToString()));

                // 所見を保存
                shokenHanteiDataSet.ShokenMst.ImportRow(shokenMst.FindByShokenKbnShokenCd(rows[0]["SentakuShokenKbn"].ToString(), rows[0]["SentakuShokenCd"].ToString()));

                // 選択された所見
                SetShokenText(shokenHanteiDataSet.ShokenMst[0].ShokenWd);

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
            katashikiBetsuTaniSochiMst.Clear();
            taniSochiGroupMst.Clear();
            taniSochiKensaKomokuMst.Clear();
            taniSochiKensaJokyoMst.Clear();
            taniSochiKensaJokyoTeidoMst.Clear();
            shokenMst.Clear();

            IGetShokenInfoALInput alInput = new GetShokenInfoALInput();

            alInput.IraiHoteiKbn = MyShokenKey.KensaIraiHoteiKbn;
            alInput.IraiHokenjoCd = MyShokenKey.KensaIraiHokenjoCd;
            alInput.IraiNendo = MyShokenKey.KensaIraiNendo;
            alInput.IraiRenban = MyShokenKey.KensaIraiRenban;

            alInput.ShokenTaishoKensaBitMask = ShokenUtility.GetBitMask(MySelectMode, MySelectType);

            IGetShokenInfoALOutput alOutput = new GetShokenInfoApplicationLogic().Execute(alInput);

            //// 想定外だが・・・
            //if (alOutput.TaniSochiGroupMst.Count == 0)
            //{
            //    throw new CustomException(0, "所見情報が取得できませんでした。");
            //}
            
            katashikiBetsuTaniSochiMst.Merge(alOutput.KatashikiBetsuTaniSochiMst);
            taniSochiGroupMst.Merge(alOutput.TaniSochiGroupMst);
            taniSochiKensaKomokuMst.Merge(alOutput.TaniSochiKensaKomokuMst);
            taniSochiKensaJokyoMst.Merge(alOutput.TaniSochiKensaJokyoMst);
            taniSochiKensaJokyoTeidoMst.Merge(alOutput.TaniSochiKensaJokyoTeidoMst);
            shokenMst.Merge(alOutput.ShokenMst);

            // 2015.01.13 toyoda Add Start
            // 名称なし時に表示する文字列
            const string NOT_NAMED = "（文章なし）";

            foreach (KatashikiBetsuTaniSochiMstDataSet.KatashikiBetsuTaniSochiMstRow row in katashikiBetsuTaniSochiMst)
            {
                if (string.IsNullOrEmpty(row.TaniSochiNm))
                {
                    row.TaniSochiNm = NOT_NAMED;
                }
            }

            foreach (TaniSochiGroupMstDataSet.TaniSochiGroupMstRow row in taniSochiGroupMst)
            {
                if (string.IsNullOrEmpty(row.TaniSochiGroupNm))
                {
                    row.TaniSochiGroupNm = NOT_NAMED;
                }
            }

            foreach (TaniSochiKensaKomokuMstDataSet.TaniSochiKensaKomokuMstRow row in taniSochiKensaKomokuMst)
            {
                if (string.IsNullOrEmpty(row.TaniSochiKensaKomokuNm))
                {
                    row.TaniSochiKensaKomokuNm = NOT_NAMED;
                }
            }

            foreach (TaniSochiKensaJokyoMstDataSet.TaniSochiKensaJokyoMstRow row in taniSochiKensaJokyoMst)
            {
                if (string.IsNullOrEmpty(row.TaniSochiKensaJokyoNm))
                {
                    row.TaniSochiKensaJokyoNm = NOT_NAMED;
                }
            }

            foreach (TaniSochiKensaJokyoTeidoMstDataSet.TaniSochiKensaJokyoTeidoMstRow row in taniSochiKensaJokyoTeidoMst)
            {
                if(string.IsNullOrEmpty(row.TaniSochiKensaJokyoTeidoNm))
                {
                    row.TaniSochiKensaJokyoTeidoNm = NOT_NAMED;
                }
            }
            // 2015.01.13 toyoda Add End

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
                shokenHanteiDataSet.TaniSochiKensaJokyoTeidoMst.Clear();
                shokenHanteiDataSet.TaniSochiKensaJokyoMst.Clear();
                shokenHanteiDataSet.TaniSochiKensaKomokuMst.Clear();
                shokenHanteiDataSet.TaniSochiGroupMst.Clear();

                int index = 0;

                // 単位装置グループをリストに出力
                if (katashikiBetsuTaniSochiMst.Count > 0)
                {
                    foreach (KatashikiBetsuTaniSochiMstDataSet.KatashikiBetsuTaniSochiMstRow row in katashikiBetsuTaniSochiMst)
                    {
                        index++;

                        ShokenHanteiDataSet.TaniSochiGroupMstRow newRow = shokenHanteiDataSet.TaniSochiGroupMst.NewTaniSochiGroupMstRow();

                        foreach (DataColumn col in shokenHanteiDataSet.TaniSochiGroupMst.Columns)
                        {
                            if (col.ColumnName == "RowIndex")
                            {
                                newRow.RowIndex = index;
                            }
                            else if (col.ColumnName == "TaniSochiGroupNm")
                            {
                                newRow[col.ColumnName] = row["TaniSochiNm"];
                            }
                            else
                            {
                                newRow[col.ColumnName] = row[col.ColumnName];
                            }
                        }

                        shokenHanteiDataSet.TaniSochiGroupMst.AddTaniSochiGroupMstRow(newRow);
                    }
                }

                // 単位装置グループをリストに出力
                if (taniSochiGroupMst.Count > 0)
                {
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
                            else
                            {
                                newRow[col.ColumnName] = row[col.ColumnName];
                            }
                        }

                        shokenHanteiDataSet.TaniSochiGroupMst.AddTaniSochiGroupMstRow(newRow);
                    }
                }

                // 未選択とする
                groupListBox.SelectedIndex = -1;

                // 選択された所見
                shokenkekkaTbl.Clear();

                SetShokenText(string.Empty);

                // 関係者への連絡事項
                renrakuHokenjoCheckBox.Checked = false;
                renrakuHoshuKeiyakuCheckBox.Checked = false;
                renrakuKoujiGyoushaCheckBox.Checked = false;
                renrakuMakerCheckBox.Checked = false;
                renrakuSecchishaCheckBox.Checked = false;
                renrakuSeisouGyoushaCheckBox.Checked = false;
                renrakuSeisouKaisuuCheckBox.Checked = false;
                renrakuTenkenGyoushaCheckBox.Checked = false;
                renrakuTenkenKaisuuCheckBox.Checked = false;

            }
            finally
            {
                // 描画再開
                this.ResumeLayout();
            }
        }
        #endregion

        #region CreateShokenKekkaTbl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateShokenKekkaTbl
        /// <summary>
        /// 画面データを返却用用データに設定する
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/15  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private ShokenKekkaTblDataSet.ShokenKekkaTblDataTable CreateShokenKekkaTbl()
        {
            ShokenKekkaTblDataSet.ShokenKekkaTblDataTable datatable = new ShokenKekkaTblDataSet.ShokenKekkaTblDataTable();

            // 選択された所見を返却用のプロパティに設定する
            ShokenKekkaTblDataSet.ShokenKekkaTblRow newRow = datatable.NewShokenKekkaTblRow();

            // キー情報
            newRow.KensaIraiShokanIraiHoteiKbn = MyShokenKey.KensaIraiHoteiKbn;
            newRow.KensaIraiShokenIraiHokenjoCd = MyShokenKey.KensaIraiHokenjoCd;
            newRow.KensaIraiShokenIraiNendo = MyShokenKey.KensaIraiNendo;
            newRow.KensaIraiShokenIraiRenban = MyShokenKey.KensaIraiRenban;
            newRow.KensaIraiShokenRenban = MyShokenKey.ShokenRenban;

            // 選択された所見
            newRow.ShokenKbn = shokenHanteiDataSet.ShokenMst[0].ShokenKbn;
            newRow.ShokenCd = shokenHanteiDataSet.ShokenMst[0].ShokenCd;
            newRow.ShokenCheckHantei = shokenHanteiDataSet.ShokenMst[0].ShokenHandan;

            // 2015.1.23 toyoda Add Start 所見内の特定文字列を単位装置グループ名に置き換える
            ConstMstDataSet.ConstMstRow targetStringConst = ConstMstList.GetRow(
                FukjBizSystem.Application.Utility.Constants.ConstKbnConstanst.CONST_KBN_077,
                FukjBizSystem.Application.Utility.Constants.ConstKbnConstanst.CONST_KBN_001);

            if (targetStringConst != null && shokenHanteiDataSet.ShokenMst[0].ShokenWd.IndexOf(targetStringConst.ConstValue.ToString()) >= 0)
            {
                newRow.TaniSochiNm = groupListBox.Text;
            }
            else
            {
                newRow.TaniSochiNm = string.Empty;
            }
            // 2015.1.23 toyoda Add End

            // 初期値(から文字、ゼロ)
            newRow.ShokenHyojiichi = 0;
            newRow.ShokenTegaki = string.Empty;
            newRow.ShokenCheckKomoku = string.Empty;
            newRow.ShokenShitekiKashoNo = string.Empty;

            // 連絡事項
            newRow.ShokenSetchishaRenrakuFlg = renrakuSecchishaCheckBox.Checked ? "1" : "0";
            newRow.ShokenHoshuGyoshaRenrakuFlg = renrakuTenkenGyoushaCheckBox.Checked ? "1" : "0";
            newRow.ShokenSeisoGyoshaRenrakuFlg = renrakuSeisouGyoushaCheckBox.Checked ? "1" : "0";
            newRow.ShokenKojiGyoshaRenrakuFlg = renrakuKoujiGyoushaCheckBox.Checked ? "1" : "0";
            newRow.ShokenMakerRenrakuFlg = renrakuMakerCheckBox.Checked ? "1" : "0";
            newRow.ShokenHokenjoRenrakuFlg = renrakuHokenjoCheckBox.Checked ? "1" : "0";
            newRow.ShokenHoshuKeiyakuKakuninFlg = renrakuHoshuKeiyakuCheckBox.Checked ? "1" : "0";
            newRow.ShokenTenkenKaisuuKakuninFlg = renrakuTenkenKaisuuCheckBox.Checked ? "1" : "0";
            newRow.ShokenSeisouKaisuuKakuninFlg = renrakuSeisouKaisuuCheckBox.Checked ? "1" : "0";

            newRow.InsertDt = DateTime.Now;
            newRow.InsertTarm = Dns.GetHostName();
            newRow.InsertUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            newRow.UpdateDt = DateTime.Now;
            newRow.UpdateTarm = Dns.GetHostName();
            newRow.UpdateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

            datatable.AddShokenKekkaTblRow(newRow);

            return datatable;
        }
        #endregion

        #region SetShokenText(string shokenText)
        /// <summary>
        /// 選択された所見テキスト＋補足文を出力する
        /// </summary>
        /// <param name="shokenText"></param>
        private void SetShokenText(string shokenText)
        {
            shokenTextBox.Text = shokenText;

            foreach (ShokenKekkaHosokuTblDataSet.ShokenKekkaHosokuListRow hosoku in shokenkekkaHosokuList)
            {
                shokenTextBox.Text += string.Format("\r\n{0}{1}", "（補足）", hosoku.ShokenWd);
            }
        }
        #endregion

        #endregion
    }
}
