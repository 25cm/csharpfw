using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.Utility;
using FukjTabletSystem.Application.ApplicationLogic.Kensa;
using FukjTabletSystem.Application.ApplicationLogic.Kensa.ShoruiKensaTabPage;
using FukjTabletSystem.Application.Boundary.Kensa.Dialog;
using FukjTabletSystem.Application.DataSet.SQLCE;
using FukjTabletSystem.Application.Utility;
using FukjTabletSystem.Properties;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.Boundary.Kensa.TabPages
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ShoruiKensaTabPage
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/22　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class ShoruiKensaTabPage : BaseKensaTabPage
    {
        #region フィールド(private)

        /// <summary>
        /// 表示データ設定中フラグ
        /// </summary>
        private bool isInSetData = false;

        /// <summary>
        /// 取得データ
        /// </summary>
        private KensaKekkaTblDataSet.KensaKekkaTblByKensaIraiKeyDataTable myKensaKekkaTbl = new KensaKekkaTblDataSet.KensaKekkaTblByKensaIraiKeyDataTable();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ShoruiKensaTabPage
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/22　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public ShoruiKensaTabPage()
        {
            InitializeComponent();
        }
        #endregion

        #region イベントハンドラ

        #region ShoruiKensaTabPage_Load
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShoruiKensaTabPage_Load(object sender, EventArgs e)
        {
            if (FukjTabletSystem.Application.Boundary.Common.Utility.IsInDesignMode)
            {
                return;
            }

            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 点検記録有無
                FukjTabletSystem.Application.Boundary.Common.Utility.SetComboBoxList(
                    tenkenKirokuUmuComboBox, ConstMstList.Get("063"), "ConstNm", "ConstValue", true, "　　　　　　", string.Empty);

                // 点検記録内容
                FukjTabletSystem.Application.Boundary.Common.Utility.SetComboBoxList(
                    tenkenKirokuNaiyouComboBox, ConstMstList.Get("063"), "ConstNm", "ConstValue", true, "　　　　　　", string.Empty);

                // 点検実施回数
                FukjTabletSystem.Application.Boundary.Common.Utility.SetComboBoxList(
                    tenkenJisshiKaisuuComboBox, ConstMstList.Get("063"), "ConstNm", "ConstValue", true, "　　　　　　", string.Empty);

                // 清掃記録有無
                FukjTabletSystem.Application.Boundary.Common.Utility.SetComboBoxList(
                    seisouKirokuUmuComboBox, ConstMstList.Get("063"), "ConstNm", "ConstValue", true, "　　　　　　", string.Empty);

                // 清掃記録内容
                FukjTabletSystem.Application.Boundary.Common.Utility.SetComboBoxList(
                    seisouKirokuNaiyouComboBox, ConstMstList.Get("063"), "ConstNm", "ConstValue", true, "　　　　　　", string.Empty);

                // 清掃実施回数
                FukjTabletSystem.Application.Boundary.Common.Utility.SetComboBoxList(
                    seisouJisshiKaisuuComboBox, ConstMstList.Get("063"), "ConstNm", "ConstValue", true, "　　　　　　", string.Empty);

                // 実施-保守点検回数
                FukjTabletSystem.Application.Boundary.Common.Utility.SetComboBoxList(
                    jisshiTenkenComboBox, ConstMstList.Get("067"), "ConstNm", "ConstValue", true);

                // 水質検査情報の取得
                DoSearch();

                // 取得データの表示
                SetControlData();

                // 編集無し(初期化)
                this.IsEdited = false;
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                TabMessageBox.Show(TabMessageBox.Type.Error, MessageResouce.MSGID_E00001, ex.Message);

                // 親画面の終了
                ((KensaMenuForm)this.TopLevelControl).DoClose();
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region tsuikaButton_Click(object sender, EventArgs e)
        /// <summary>
        /// 所見追加ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsuikaButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string renban = "00";

                // 表示中の最大所見連番を取得
                foreach (ShokenKekkaListDataSet.ShokenKekkaListRow row in shokenKekkaListDataSet.ShokenKekkaList)
                {
                    string tempRenban;
                    if (row.RowState == DataRowState.Deleted)
                    {
                        tempRenban = row["KensaIraiShokenRenban", DataRowVersion.Original].ToString();
                    }
                    else
                    {
                        tempRenban = row.KensaIraiShokenRenban;
                    }

                    renban = int.Parse(tempRenban) > int.Parse(renban) ? tempRenban : renban;
                }

                // 最大番号＋1　
                // ------------------------------------------------------------------------------------------
                //  ※これは登録用の番号ではなく、追加分はほか画面との関係もあり登録ＡＬで採番しなおしている
                // ------------------------------------------------------------------------------------------
                renban = string.Format("{0:00}", (int.Parse(renban) + 1));

                // 検査依頼のキーと、所見の連番（画面保持情報＋１）を渡す
                using (ShokenHanteiDialog frm = new ShokenHanteiDialog(ShokenUtility.SelectMode.Shoken, ShokenUtility.SelectType.ShoruiKensa,
                                                                        new ShokenKey(((KensaMenuForm)this.TopLevelControl).IraiHoteiKbn,
                                                                            ((KensaMenuForm)this.TopLevelControl).IraiHokenjoCd,
                                                                            ((KensaMenuForm)this.TopLevelControl).IraiNendo,
                                                                            ((KensaMenuForm)this.TopLevelControl).IraiRenban,
                                                                            renban)))
                {
                    frm.ShowDialog();

                    if (frm.DialogResult != System.Windows.Forms.DialogResult.OK)
                    {
                        return;
                    }

                    #region 所見

                    // 一覧表示用データに追加
                    ShokenKekkaListDataSet.ShokenKekkaListRow newRow = shokenKekkaListDataSet.ShokenKekkaList.NewShokenKekkaListRow();

                    foreach (System.Data.DataColumn col in shokenKekkaListDataSet.ShokenKekkaList.Columns)
                    {
                        // 所見文字列は所見マスタより取得
                        if (col.ColumnName == "ShokenWd")
                        {
                            newRow[col.ColumnName] = frm.SelectedShokenMstRow[col.ColumnName];
                        }
                        // 所見結果は所見結果行より取得
                        else
                        {
                            newRow[col.ColumnName] = frm.SelectedShokenKekkaRow[col.ColumnName];
                        }
                    }

                    shokenKekkaListDataSet.ShokenKekkaList.AddShokenKekkaListRow(newRow);

                    newRow.AcceptChanges();
                    newRow.SetAdded();

                    #endregion

                    #region 補足

                    // 一覧表示用データに追加
                    foreach (ShokenKekkaHosokuTblDataSet.ShokenKekkaHosokuListRow row in frm.SelectedShokenKekkaHosku)
                    {
                        ShokenKekkaListDataSet.ShokenKekkaHosokuListRow newHosoku = shokenKekkaListDataSet.ShokenKekkaHosokuList.NewShokenKekkaHosokuListRow();

                        // 所見文字列も返却用のテーブルに含まれている
                        foreach (System.Data.DataColumn col in shokenKekkaListDataSet.ShokenKekkaHosokuList.Columns)
                        {
                            newHosoku[col.ColumnName] = row[col.ColumnName];
                        }

                        shokenKekkaListDataSet.ShokenKekkaHosokuList.AddShokenKekkaHosokuListRow(newHosoku);

                        newHosoku.AcceptChanges();
                        newHosoku.SetAdded();
                    }

                    #endregion

                    // 編集あり
                    this.IsEdited = true;
                }
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

        #region kakuteiButton_Click(object sender, EventArgs e)
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

                IKakuteiBtnClickALInput alInput = new KakuteiBtnClickALInput();

                // 所見結果を作成
                alInput.ShokenKekkaTbl = CreateShokenKekkaTbl();

                // 所見結果補足を作成
                alInput.ShokenKekkaHosokuTbl = CreateShokenKekkaHosokuTbl();

                // 検査結果を作成
                alInput.KensaKekkaForShoruiUpdate = CreateKensaKekkaTbl();
                
                // 更新実行
                new KakuteiBtnClickApplicationLogic().Execute(alInput);

                TabMessageBox.Show2(TabMessageBox.Type.Info, "書類検査", "書類検査結果を更新しました。");

                // 自画面の更新
                DoSearch();

                // 取得データの表示
                SetControlData();

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
        #endregion

        #region shokenListDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        /// <summary>
        /// セルの書式変換
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shokenListDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == shokenHokenjoRenrakuFlgDataGridViewTextBoxColumn.Index
                || e.ColumnIndex == shokenHoshuGyoshaRenrakuFlgDataGridViewTextBoxColumn.Index
                || e.ColumnIndex == shokenKojiGyoshaRenrakuFlgDataGridViewTextBoxColumn.Index
                || e.ColumnIndex == shokenMakerRenrakuFlgDataGridViewTextBoxColumn.Index
                || e.ColumnIndex == shokenSeisoGyoshaRenrakuFlgDataGridViewTextBoxColumn.Index
                || e.ColumnIndex == shokenSetchishaRenrakuFlgDataGridViewTextBoxColumn.Index
                || e.ColumnIndex == shokenHoshuKeiyakuKakuninFlgDataGridViewTextBoxColumn.Index
                || e.ColumnIndex == shokenSeisouKaisuuKakuninFlgDataGridViewTextBoxColumn.Index
                || e.ColumnIndex == shokenTenkenKaisuuKakuninFlgDataGridViewTextBoxColumn.Index)
            {
                // チェック状態の置き換え
                if (e.Value.ToString() != "True" && e.Value.ToString() != "False")
                {
                    e.Value = (e.Value.ToString() == "1") ? Resources.list_checked : Resources.list_unchecked;
                }
            }
            else if (e.ColumnIndex == RowNumber.Index)
            {
                // 行番号の設定
                e.Value = e.RowIndex + 1;
            }
            else if (e.ColumnIndex == shokenWdDataGridViewTextBoxColumn.Index)
            {
                // 2015.01.29 toyoda Add Start 所見文字列の(大分類)を単位装置名に置き換える
                ConstMstDataSet.ConstMstRow targetStringConst = ConstMstList.GetRow(
                    FukjBizSystem.Application.Utility.Constants.ConstKbnConstanst.CONST_KBN_077,
                    FukjBizSystem.Application.Utility.Constants.ConstKbnConstanst.CONST_KBN_001);

                if (targetStringConst != null && e.Value.ToString().IndexOf(targetStringConst.ConstValue.ToString()) >= 0)
                {
                    e.Value = e.Value.ToString().Replace(targetStringConst.ConstValue.ToString(), shokenListDataGridView.Rows[e.RowIndex].Cells[TaniSochiNm.Index].Value.ToString());
                }
                // 2015.01.29 toyoda Add End

                // 所見文字列に補足文文字列を結合する
                DataRow[] hosokuRows = shokenKekkaListDataSet.ShokenKekkaHosokuList.Select(string.Format("KensaIraiShokenRenban = '{0}'", shokenListDataGridView.Rows[e.RowIndex].Cells[kensaIraiShokenRenbanDataGridViewTextBoxColumn.Index].Value.ToString()));

                if (hosokuRows.Length > 0)
                {
                    foreach (DataRow hosokuRow in hosokuRows)
                    {
                        e.Value += string.Format("\r\n{0}{1}", "（補足）", hosokuRow["ShokenWd"].ToString());
                    }

                    // 行の高さを調整
                    shokenListDataGridView.Rows[e.RowIndex].Height = 51 + ((hosokuRows.Length - 1) * 26);
                }
                else
                {
                    // デフォルトの行の高さに戻す
                    shokenListDataGridView.Rows[e.RowIndex].Height = 51;
                }

            }
        }
        #endregion

        #region shokenListDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        /// <summary>
        /// 一覧のセルクリック（削除処理）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shokenListDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // ヘッダー処理対象外
            if (e.RowIndex < 0)
            {
                return;
            }

            // 処理対象外列
            if (e.ColumnIndex != Delete.Index)
            {
                return;
            }

            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 対象項目判定

                if (e.ColumnIndex == Delete.Index)
                {
                    DataGridView dgv = (DataGridView)sender;

                    // 対象のレコード（所見結果）を取得
                    DataRow[] shokenKekka = shokenKekkaListDataSet.ShokenKekkaList.Select(
                        string.Format("KensaIraiShokanIraiHoteiKbn = '{0}' AND KensaIraiShokenIraiHokenjoCd = '{1}' AND KensaIraiShokenIraiNendo = '{2}' AND KensaIraiShokenIraiRenban = '{3}' AND KensaIraiShokenRenban = '{4}'",
                        dgv.Rows[e.RowIndex].Cells[kensaIraiShokanIraiHoteiKbnDataGridViewTextBoxColumn.Index].Value.ToString(),
                        dgv.Rows[e.RowIndex].Cells[kensaIraiShokenIraiHokenjoCdDataGridViewTextBoxColumn.Index].Value.ToString(),
                        dgv.Rows[e.RowIndex].Cells[kensaIraiShokenIraiNendoDataGridViewTextBoxColumn.Index].Value.ToString(),
                        dgv.Rows[e.RowIndex].Cells[kensaIraiShokenIraiRenbanDataGridViewTextBoxColumn.Index].Value.ToString(),
                        dgv.Rows[e.RowIndex].Cells[kensaIraiShokenRenbanDataGridViewTextBoxColumn.Index].Value.ToString()));

                    // 対象のレコード（補足文）を取得
                    DataRow[] shokenHosokuRows = shokenKekkaListDataSet.ShokenKekkaHosokuList.Select(
                        string.Format("KensaIraiShokanIraiHoteiKbn = '{0}' AND KensaIraiShokenIraiHokenjoCd = '{1}' AND KensaIraiShokenIraiNendo = '{2}' AND KensaIraiShokenIraiRenban = '{3}' AND KensaIraiShokenRenban = '{4}'",
                        dgv.Rows[e.RowIndex].Cells[kensaIraiShokanIraiHoteiKbnDataGridViewTextBoxColumn.Index].Value.ToString(),
                        dgv.Rows[e.RowIndex].Cells[kensaIraiShokenIraiHokenjoCdDataGridViewTextBoxColumn.Index].Value.ToString(),
                        dgv.Rows[e.RowIndex].Cells[kensaIraiShokenIraiNendoDataGridViewTextBoxColumn.Index].Value.ToString(),
                        dgv.Rows[e.RowIndex].Cells[kensaIraiShokenIraiRenbanDataGridViewTextBoxColumn.Index].Value.ToString(),
                        dgv.Rows[e.RowIndex].Cells[kensaIraiShokenRenbanDataGridViewTextBoxColumn.Index].Value.ToString()));

                    // 所見結果を削除
                    if (shokenKekka.Length > 0)
                    {
                        shokenKekka[0].Delete();
                    }

                    // 補足文があれば合わせて削除
                    if (shokenHosokuRows.Length > 0)
                    {
                        foreach (DataRow shokenHosoku in shokenHosokuRows)
                        {
                            shokenHosoku.Delete();
                        }
                    }
                }
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

        #region ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        /// <summary>
        /// 編集済みの判定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!isInSetData)
            {
                this.IsEdited = true;
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
        /// 2014/11/22　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            try
            {
                // 描画を停止
                this.SuspendLayout();

                // 保持情報をクリア
                myKensaKekkaTbl.Clear();

                #region 書類検査項目

                IGetShoruiKensaALInput alInput = new GetShoruiKensaALInput();

                // 検査依頼のキー
                alInput.IraiHoteiKbn = ((KensaMenuForm)this.TopLevelControl).IraiHoteiKbn;
                alInput.IraiHokenjoCd = ((KensaMenuForm)this.TopLevelControl).IraiHokenjoCd;
                alInput.IraiNendo = ((KensaMenuForm)this.TopLevelControl).IraiNendo;
                alInput.IraiRenban = ((KensaMenuForm)this.TopLevelControl).IraiRenban;

                IGetShoruiKensaALOutput alOutput = new GetShoruiKensaApplicationLogic().Execute(alInput);

                // 検査結果
                myKensaKekkaTbl.Merge(alOutput.KensaKekkaTbl);

                #endregion

                // 保持情報をクリア
                shokenKekkaListDataSet.ShokenKekkaList.Clear();
                shokenKekkaListDataSet.ShokenKekkaHosokuList.Clear();

                #region 所見関連

                IGetShokenKekkaListALInput alShokenInput = new GetShokenKekkaListALInput();

                alShokenInput.IraiHoteiKbn = ((KensaMenuForm)this.TopLevelControl).IraiHoteiKbn;
                alShokenInput.IraiHokenjoCd = ((KensaMenuForm)this.TopLevelControl).IraiHokenjoCd;
                alShokenInput.IraiNendo = ((KensaMenuForm)this.TopLevelControl).IraiNendo;
                alShokenInput.IraiRenban = ((KensaMenuForm)this.TopLevelControl).IraiRenban;

                alShokenInput.ShokenTaishoKensaBitMask = ShokenUtility.GetBitMask(ShokenUtility.SelectMode.Shoken, ShokenUtility.SelectType.ShoruiKensa);
                alShokenInput.TaishouKensaHosokuBitMask = ShokenUtility.GetBitMask(ShokenUtility.SelectMode.Hosokubun, ShokenUtility.SelectType.ShoruiKensa);

                IGetShokenKekkaListALOutput alShokenOutput = new GetShokenKekkaListApplicationLogic().Execute(alShokenInput);

                // 取得データを画面に保持
                shokenKekkaListDataSet.ShokenKekkaList.Merge(alShokenOutput.ShokenKekkaList);
                shokenKekkaListDataSet.ShokenKekkaHosokuList.Merge(alShokenOutput.ShokenKekkaHosokuList);

                #endregion
            }
            finally
            {
                // 描画再開
                this.ResumeLayout();
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
        /// 2014/11/22　豊田　　    新規作成
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
                
                // 規定-保守点検
                kiteiTenkenTextBox.Text = myKensaKekkaTbl[0].IsTenkenKaisuKbnNmNull() ? string.Empty : myKensaKekkaTbl[0].TenkenKaisuKbnNm;

                // 規定-清掃
                kiteiSeisouTextBox.Text = myKensaKekkaTbl[0].IsSeisoKaisuKbnNmNull() ? string.Empty : myKensaKekkaTbl[0].SeisoKaisuKbnNm;

                // 実施-保守点検
                if (myKensaKekkaTbl[0].IsKensaKekkaTenkenKaisuKbnNull() || string.IsNullOrEmpty(myKensaKekkaTbl[0].KensaKekkaTenkenKaisuKbn))
                {
                    jisshiTenkenComboBox.SelectedIndex = -1;
                }
                else
                {
                    jisshiTenkenComboBox.SelectedValue = myKensaKekkaTbl[0].KensaKekkaTenkenKaisuKbn;
                }

                // 実施-清掃
                jisshiSeisouTextBox.Text = myKensaKekkaTbl[0].IsKensaKekkaSeisoDtNull() ?
                    String.Empty : FukjTabletSystem.Application.Utility.DateUtility.ConvertToWareki(myKensaKekkaTbl[0].KensaKekkaSeisoDt, "yy.MM.dd");

                // 事前情報
                jizenJouhouTextBox.Text = myKensaKekkaTbl[0].IsKensaKekkaMemoTegakiNull() ? string.Empty : myKensaKekkaTbl[0].KensaKekkaMemoTegaki;

                // 保守点検-記録有無
                if (myKensaKekkaTbl[0].IsKensaKekkaHoshuTenkenKirokuUmuNull() || string.IsNullOrEmpty(myKensaKekkaTbl[0].KensaKekkaHoshuTenkenKirokuUmu))
                {
                    tenkenKirokuUmuComboBox.SelectedIndex = -1;
                }
                else
                {
                    tenkenKirokuUmuComboBox.SelectedValue = myKensaKekkaTbl[0].KensaKekkaHoshuTenkenKirokuUmu;
                }

                // 保守点検-記録内容
                if (myKensaKekkaTbl[0].IsKensaKekkaHoshuTenkenNaiyoNull() || string.IsNullOrEmpty(myKensaKekkaTbl[0].KensaKekkaHoshuTenkenNaiyo))
                {
                    tenkenKirokuNaiyouComboBox.SelectedIndex = -1;
                }
                else
                {
                    tenkenKirokuNaiyouComboBox.SelectedValue = myKensaKekkaTbl[0].KensaKekkaHoshuTenkenNaiyo;
                }

                // 保守点検-実施回数
                if (myKensaKekkaTbl[0].IsKensaKekkaHoshuTenkenKaisuNull() || string.IsNullOrEmpty(myKensaKekkaTbl[0].KensaKekkaHoshuTenkenKaisu))
                {
                    tenkenJisshiKaisuuComboBox.SelectedIndex = -1;
                }
                else
                {
                    tenkenJisshiKaisuuComboBox.SelectedValue = myKensaKekkaTbl[0].KensaKekkaHoshuTenkenKaisu;
                }

                // 清掃-記録有無
                if (myKensaKekkaTbl[0].IsKensaKekkaSeisoKirokuUmuNull() || string.IsNullOrEmpty(myKensaKekkaTbl[0].KensaKekkaSeisoKirokuUmu))
                {
                    seisouKirokuUmuComboBox.SelectedIndex = -1;
                }
                else
                {
                    seisouKirokuUmuComboBox.SelectedValue = myKensaKekkaTbl[0].KensaKekkaSeisoKirokuUmu;
                }

                // 清掃-記録内容
                if (myKensaKekkaTbl[0].IsKensaKekkaSeisoNaiyoNull() || string.IsNullOrEmpty(myKensaKekkaTbl[0].KensaKekkaSeisoNaiyo))
                {
                    seisouKirokuNaiyouComboBox.SelectedIndex = -1;
                }
                else
                {
                    seisouKirokuNaiyouComboBox.SelectedValue = myKensaKekkaTbl[0].KensaKekkaSeisoNaiyo;
                }

                // 清掃-実施回数
                if (myKensaKekkaTbl[0].IsKensaKekkaSeisoKaisuNull() || string.IsNullOrEmpty(myKensaKekkaTbl[0].KensaKekkaSeisoKaisu))
                {
                    seisouJisshiKaisuuComboBox.SelectedIndex = -1;
                }
                else
                {
                    seisouJisshiKaisuuComboBox.SelectedValue = myKensaKekkaTbl[0].KensaKekkaSeisoKaisu;
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
        
        #region CreateShokenKekkaTbl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateShokenKekkaTbl
        /// <summary>
        /// 画面データを返却用用データに設定する
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/22  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private ShokenKekkaTblDataSet.ShokenKekkaTblDataTable CreateShokenKekkaTbl()
        {
            ShokenKekkaTblDataSet.ShokenKekkaTblDataTable datatable = new ShokenKekkaTblDataSet.ShokenKekkaTblDataTable();

            foreach (ShokenKekkaListDataSet.ShokenKekkaListRow row in shokenKekkaListDataSet.ShokenKekkaList)
            {
                // 画面内で更新は行われないため、追加、削除のみを対象とする

                // 追加行
                if (row.RowState == DataRowState.Added)
                {
                    ShokenKekkaTblDataSet.ShokenKekkaTblRow newRow = datatable.NewShokenKekkaTblRow();

                    foreach (DataColumn col in datatable.Columns)
                    {
                        newRow[col.ColumnName] = row[col.ColumnName];
                    }

                    datatable.AddShokenKekkaTblRow(newRow);

                    newRow.AcceptChanges();
                    newRow.SetAdded();
                }
                // 削除行
                else if (row.RowState == DataRowState.Deleted)
                {
                    ShokenKekkaTblDataSet.ShokenKekkaTblRow newRow = datatable.NewShokenKekkaTblRow();

                    foreach (DataColumn col in datatable.Columns)
                    {
                        newRow[col.ColumnName] = row[col.ColumnName, DataRowVersion.Original];
                    }

                    datatable.AddShokenKekkaTblRow(newRow);

                    newRow.AcceptChanges();
                    newRow.Delete();
                }
            }

            return datatable;
        }
        #endregion

        #region CreateShokenKekkaHosokuTbl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateShokenKekkaHosokuTbl
        /// <summary>
        /// 画面データを返却用用データに設定する
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/22  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private ShokenKekkaHosokuTblDataSet.ShokenKekkaHosokuTblDataTable CreateShokenKekkaHosokuTbl()
        {
            ShokenKekkaHosokuTblDataSet.ShokenKekkaHosokuTblDataTable datatable = new ShokenKekkaHosokuTblDataSet.ShokenKekkaHosokuTblDataTable();

            foreach (ShokenKekkaListDataSet.ShokenKekkaHosokuListRow row in shokenKekkaListDataSet.ShokenKekkaHosokuList)
            {
                // 画面内で更新は行われないため、追加、削除のみを対象とする

                // 追加行
                if (row.RowState == DataRowState.Added)
                {
                    ShokenKekkaHosokuTblDataSet.ShokenKekkaHosokuTblRow newRow = datatable.NewShokenKekkaHosokuTblRow();

                    foreach (DataColumn col in datatable.Columns)
                    {
                        newRow[col.ColumnName] = row[col.ColumnName];
                    }

                    datatable.AddShokenKekkaHosokuTblRow(newRow);

                    newRow.AcceptChanges();
                    newRow.SetAdded();
                }
                // 削除行
                else if (row.RowState == DataRowState.Deleted)
                {
                    ShokenKekkaHosokuTblDataSet.ShokenKekkaHosokuTblRow newRow = datatable.NewShokenKekkaHosokuTblRow();

                    foreach (DataColumn col in datatable.Columns)
                    {
                        newRow[col.ColumnName] = row[col.ColumnName, DataRowVersion.Original];
                    }

                    datatable.AddShokenKekkaHosokuTblRow(newRow);

                    newRow.AcceptChanges();
                    newRow.Delete();
                }
            }

            return datatable;
        }
        #endregion

        #region CreateKensaKekkaTbl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateKensaKekkaTbl
        /// <summary>
        /// 画面データを更新用データに設定する
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/22  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaKekkaTblDataSet.KensaKekkaForShoruiUpdateDataTable CreateKensaKekkaTbl()
        {
            KensaKekkaTblDataSet.KensaKekkaForShoruiUpdateDataTable datatable = new KensaKekkaTblDataSet.KensaKekkaForShoruiUpdateDataTable();

            KensaKekkaTblDataSet.KensaKekkaForShoruiUpdateRow newRow = datatable.NewKensaKekkaForShoruiUpdateRow();

            // キー
            newRow.KensaKekkaIraiHoteiKbn = ((KensaMenuForm)this.TopLevelControl).IraiHoteiKbn;
            newRow.KensaKekkaIraiHokenjoCd = ((KensaMenuForm)this.TopLevelControl).IraiHokenjoCd;
            newRow.KensaKekkaIraiNendo = ((KensaMenuForm)this.TopLevelControl).IraiNendo;
            newRow.KensaKekkaIraiRenban = ((KensaMenuForm)this.TopLevelControl).IraiRenban;

            // 実施-保守点検
            if (jisshiTenkenComboBox.SelectedIndex == -1)
            {
                newRow.KensaKekkaTenkenKaisuKbn = string.Empty;
            }
            else
            {
                newRow.KensaKekkaTenkenKaisuKbn = jisshiTenkenComboBox.SelectedValue.ToString();
            }

            // 保守点検-記録有無
            if (tenkenKirokuUmuComboBox.SelectedIndex == -1)
            {
                newRow.KensaKekkaHoshuTenkenKirokuUmu = string.Empty;
            }
            else
            {
                newRow.KensaKekkaHoshuTenkenKirokuUmu = tenkenKirokuUmuComboBox.SelectedValue.ToString();
            }

            // 保守点検-記録内容
            if (tenkenKirokuNaiyouComboBox.SelectedIndex == -1)
            {
                newRow.KensaKekkaHoshuTenkenNaiyo = string.Empty;
            }
            else
            {
                newRow.KensaKekkaHoshuTenkenNaiyo = tenkenKirokuNaiyouComboBox.SelectedValue.ToString();
            }

            // 保守点検-実施回数
            if (tenkenJisshiKaisuuComboBox.SelectedIndex == -1)
            {
                newRow.KensaKekkaHoshuTenkenKaisu = string.Empty;
            }
            else
            {
                newRow.KensaKekkaHoshuTenkenKaisu = tenkenJisshiKaisuuComboBox.SelectedValue.ToString();
            }

            // 清掃-記録有無
            if (seisouKirokuUmuComboBox.SelectedIndex == -1)
            {
                newRow.KensaKekkaSeisoKirokuUmu = string.Empty;
            }
            else
            {
                newRow.KensaKekkaSeisoKirokuUmu = seisouKirokuUmuComboBox.SelectedValue.ToString();
            }

            // 清掃-記録内容
            if (seisouKirokuNaiyouComboBox.SelectedIndex == -1)
            {
                newRow.KensaKekkaSeisoNaiyo = string.Empty;
            }
            else
            {
                newRow.KensaKekkaSeisoNaiyo = seisouKirokuNaiyouComboBox.SelectedValue.ToString();
            }

            // 清掃-実施回数
            if (seisouJisshiKaisuuComboBox.SelectedIndex == -1)
            {
                newRow.KensaKekkaSeisoKaisu = string.Empty;
            }
            else
            {
                newRow.KensaKekkaSeisoKaisu = seisouJisshiKaisuuComboBox.SelectedValue.ToString();
            }

            datatable.AddKensaKekkaForShoruiUpdateRow(newRow);

            newRow.AcceptChanges();
            newRow.SetModified();

            return datatable;
        }
        #endregion

        #endregion
    }
    #endregion
}
