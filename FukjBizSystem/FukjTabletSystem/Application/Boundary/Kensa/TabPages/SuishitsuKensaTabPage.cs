using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.Utility;
using FukjTabletSystem.Application.ApplicationLogic.Kensa;
using FukjTabletSystem.Application.ApplicationLogic.Kensa.SuishitsuKensaTabPage;
using FukjTabletSystem.Application.Boundary.Kensa.Dialog;
using FukjTabletSystem.Application.DataSet.SQLCE;
using FukjTabletSystem.Application.Utility;
using FukjTabletSystem.Properties;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.Boundary.Kensa.TabPages {

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SuishitsuKensaTabPage
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SuishitsuKensaTabPage : BaseKensaTabPage
    {
        #region フィールド(private)

        /// <summary>
        /// 表示データ設定中フラグ
        /// </summary>
        private bool isInSetData = false;

        /// <summary>
        /// 取得データ（検査結果（今回））
        /// </summary>
        private KensaKekkaTblDataSet.KensaKekkaTblByKensaIraiKeyDataTable myKensaKekkaTbl = new KensaKekkaTblDataSet.KensaKekkaTblByKensaIraiKeyDataTable();

        /// <summary>
        /// 取得データ（検査結果（前回））
        /// </summary>
        private KensaKekkaTblDataSet.KensaKekkaTblByKensaIraiKeyDataTable myLastKensaKekkaTbl = new KensaKekkaTblDataSet.KensaKekkaTblByKensaIraiKeyDataTable();

        /// <summary>
        /// 取得データ（再採水）
        /// </summary>
        private SaiSaisuiTblDataSet.SaiSaisuiTblByKensaIraiKeyDataTable mySaiSaisuiTbl = new SaiSaisuiTblDataSet.SaiSaisuiTblByKensaIraiKeyDataTable();

        /// <summary>
        /// 取得データ（処理方式別水質検査実施マスタ）
        /// </summary>
        private ShoriHoshikiSuishitsuKensaJisshiMstDataSet.ShoriHoshikiSuishitsuKensaJisshiMstDataTable myKensaJisshiMst = new ShoriHoshikiSuishitsuKensaJisshiMstDataSet.ShoriHoshikiSuishitsuKensaJisshiMstDataTable();
        
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： InitializeComponent
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19　戸口　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SuishitsuKensaTabPage()
        {
            InitializeComponent();
        }
        #endregion

        #region イベントハンドラ

        #region SuishitsuKensa_Load
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SuishitsuKensa_Load(object sender, EventArgs e)
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

                // Ph（水素イオン濃度）
                FukjTabletSystem.Application.Boundary.Common.Utility.SetComboBoxList(
                    pHComboBox, ConstMstList.Get("025"), "ConstNm", "ConstValue", true, "　　　　", string.Empty);

                // Do（溶存酸素量１）
                FukjTabletSystem.Application.Boundary.Common.Utility.SetComboBoxList(
                    doComboBox, ConstMstList.Get("025"), "ConstNm", "ConstValue", true, "　　　　", string.Empty);

                // 二次透視度
                FukjTabletSystem.Application.Boundary.Common.Utility.SetComboBoxList(
                    nijiToushidoComboBox, ConstMstList.Get("025"), "ConstNm", "ConstValue", true, "　　　　", string.Empty);

                // 透視度
                FukjTabletSystem.Application.Boundary.Common.Utility.SetComboBoxList(
                    toushidoComboBox, ConstMstList.Get("025"), "ConstNm", "ConstValue", true, "　　　　", string.Empty);

                // 残留塩素濃度
                FukjTabletSystem.Application.Boundary.Common.Utility.SetComboBoxList(
                    zanryuEnsoComboBox, ConstMstList.Get("025"), "ConstNm", "ConstValue", true, "　　　　", string.Empty);

                // SV30（汚泥沈殿率）
                FukjTabletSystem.Application.Boundary.Common.Utility.SetComboBoxList(
                    sv30ComboBox, ConstMstList.Get("025"), "ConstNm", "ConstValue", true, "　　　　", string.Empty);

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
                using (ShokenHanteiDialog frm = new ShokenHanteiDialog(ShokenUtility.SelectMode.Shoken, ShokenUtility.SelectType.SuishitsuKensa,
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

                // 入力値チェック
                if (!CheckInputValue())
                {
                    return;
                }

                IKakuteiBtnClickALInput alInput = new KakuteiBtnClickALInput();

                // 所見結果を作成
                alInput.ShokenKekkaTbl = CreateShokenKekkaTbl();

                // 所見結果補足を作成
                alInput.ShokenKekkaHosokuTbl = CreateShokenKekkaHosokuTbl();

                // 検査結果を作成
                alInput.KensaKekkaForSuishitsuUpdate = CreateKensaKekkaTbl();

                // 再採水を作成
                alInput.SaiSaisuiTblForSuishitsuUpdate = CreateSaiSaisuiTbl();

                // 更新実行
                new KakuteiBtnClickApplicationLogic().Execute(alInput);

                TabMessageBox.Show2(TabMessageBox.Type.Info, "水質検査", "水質検査結果を更新しました。");

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

        #region TextBox_TextChanged(object sender, EventArgs e)
        /// <summary>
        /// 編集済みの判定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (!isInSetData) {
                this.IsEdited = true;
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
            if (!isInSetData) {
                this.IsEdited = true;
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

        #endregion

        #region メソッド(private)

        #region CheckInputValue()
        /// <summary>
        /// 入力値チェック
        /// </summary>
        /// <returns></returns>
        private bool CheckInputValue()
        {
            // Ph
            if (!string.IsNullOrEmpty(pHTextBox.Text))
            {
                if(((decimal)pHTextBox.CustomValue) >= 1000 || ((decimal)pHTextBox.CustomValue) < 0)
                {
                    TabMessageBox.Show2(TabMessageBox.Type.Warn, "Phは0.0～999.9の間で設定してください。");
                    return false;
                }
            }

            // 水温
            if (!string.IsNullOrEmpty(suionTextBox.Text))
            {
                if (((decimal)suionTextBox.CustomValue) >= 100 || ((decimal)suionTextBox.CustomValue) < 0)
                {
                    TabMessageBox.Show2(TabMessageBox.Type.Warn, "水温は0.0～99.9の間で設定してください。");
                    return false;
                }
            }

            // DO（From)
            if (!string.IsNullOrEmpty(doFromTextBox.Text))
            {
                if (((decimal)doFromTextBox.CustomValue) >= 100 || ((decimal)doFromTextBox.CustomValue) < 0)
                {
                    TabMessageBox.Show2(TabMessageBox.Type.Warn, "溶存酸素量（From)は0.0～99.9の間で設定してください。");
                    return false;
                }
            }

            // DO（To)
            if (!string.IsNullOrEmpty(doToTextBox.Text))
            {
                if (((decimal)doToTextBox.CustomValue) >= 100 || ((decimal)doToTextBox.CustomValue) < 0)
                {
                    TabMessageBox.Show2(TabMessageBox.Type.Warn, "溶存酸素量（To)は0.0～99.9の間で設定してください。");
                    return false;
                }
            }

            // 二次透視度
            if (!string.IsNullOrEmpty(nijiToushidoTextBox.Text))
            {
                if (((decimal)nijiToushidoTextBox.CustomValue) >= 100 || ((decimal)nijiToushidoTextBox.CustomValue) < 0)
                {
                    TabMessageBox.Show2(TabMessageBox.Type.Warn, "二次透視度は0～99の間で設定してください。");
                    return false;
                }
            }

            // 透視度
            if (!string.IsNullOrEmpty(toushidoTextBox.Text))
            {
                if (((decimal)toushidoTextBox.CustomValue) >= 100 || ((decimal)toushidoTextBox.CustomValue) < 0)
                {
                    TabMessageBox.Show2(TabMessageBox.Type.Warn, "透視度は0～99の間で設定してください。");
                    return false;
                }
            }

            // 残留塩素
            if (!string.IsNullOrEmpty(zanryuEnsoTextBox.Text))
            {
                if (((decimal)zanryuEnsoTextBox.CustomValue) >= 100 || ((decimal)zanryuEnsoTextBox.CustomValue) < 0)
                {
                    TabMessageBox.Show2(TabMessageBox.Type.Warn, "残留塩素は0.00～99.99の間で設定してください。");
                    return false;
                }
            }

            // SV30
            if (!string.IsNullOrEmpty(sv30TextBox.Text))
            {
                if (((decimal)sv30TextBox.CustomValue) >= 100 || ((decimal)sv30TextBox.CustomValue) < 0)
                {
                    TabMessageBox.Show2(TabMessageBox.Type.Warn, "汚泥沈殿率は0～99の間で設定してください。");
                    return false;
                }
            }
            
            // 2015.01.29 toyoda Add Start 要望対応
            // MLSS
            if (!string.IsNullOrEmpty(mlssTextBox.Text))
            {
                if (((decimal)mlssTextBox.CustomValue) >= 1000000 || ((decimal)mlssTextBox.CustomValue) < 0)
                {
                    TabMessageBox.Show2(TabMessageBox.Type.Warn, "MLSSは0～999999の間で設定してください。");
                    return false;
                }
            }
            // 2015.01.29 toyoda Add End

            return true;
        }
        #endregion

        #region DoSearch
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoSearch
        /// <summary>
        /// 表示データの検索を行う
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19　戸口　　    新規作成
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
                myLastKensaKekkaTbl.Clear();
                mySaiSaisuiTbl.Clear();
                myKensaJisshiMst.Clear();

                #region 水質検査項目
                
                IGetSuishitsuKensaALInput alInput = new GetSuishitsuKensaALInput();

                // 検査依頼の検索条件をセット（各ＢＬでは、これをキーとして使用する）
                alInput.IraiHoteiKbn = ((KensaMenuForm)this.TopLevelControl).IraiHoteiKbn;
                alInput.IraiHokenjoCd = ((KensaMenuForm)this.TopLevelControl).IraiHokenjoCd;
                alInput.IraiNendo = ((KensaMenuForm)this.TopLevelControl).IraiNendo;
                alInput.IraiRenban = ((KensaMenuForm)this.TopLevelControl).IraiRenban;

                // 今回＆前回のセットか、再採水＆今回のセットを使うかを判断するための区分
                alInput.ScreeningKbn = ((KensaMenuForm)this.TopLevelControl).KensaIraiInfo.KensaIraiScreeningKbn;
                
                IGetSuishitsuKensaALOutput alOutput = new GetSuishitsuKensaApplicationLogic().Execute(alInput);
                
                // 取得データを画面に保持
                
                // 検査結果（今回）
                myKensaKekkaTbl.Merge(alOutput.KensaKekkaTbl);

                // 検査結果（前回）は取れた場合のみセット
                if (alOutput.LastKensaKekkaTbl != null)
                {
                    if (alOutput.LastKensaKekkaTbl.Count > 0)
                    {
                        // 検査結果（前回） ※この時点では、今回分も含む全てのデータが検索されている。
                        myLastKensaKekkaTbl.Merge(alOutput.LastKensaKekkaTbl);
                    }
                }

                // 再採水は取れた場合のみセット
                if (alOutput.SaiSaisuiTbl != null)
                {
                    if (alOutput.SaiSaisuiTbl.Count > 0)
                    {
                        // 再採水
                        mySaiSaisuiTbl.Merge(alOutput.SaiSaisuiTbl);
                    }
                }

                // 処理方式別水質検査実施マスタは取れた場合のみセット
                if (alOutput.ShoriHoshikiSuishitsuKensaJisshiMst != null)
                {
                    if (alOutput.ShoriHoshikiSuishitsuKensaJisshiMst.Count > 0)
                    {
                        // 処理方式別水質検査実施マスタ
                        myKensaJisshiMst.Merge(alOutput.ShoriHoshikiSuishitsuKensaJisshiMst);
                    }
                }

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

                alShokenInput.ShokenTaishoKensaBitMask = ShokenUtility.GetBitMask(ShokenUtility.SelectMode.Shoken, ShokenUtility.SelectType.SuishitsuKensa);
                alShokenInput.TaishouKensaHosokuBitMask = ShokenUtility.GetBitMask(ShokenUtility.SelectMode.Hosokubun, ShokenUtility.SelectType.SuishitsuKensa);

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
        /// 2014/11/19　戸口　　    新規作成
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

                // 初期表示に戻す
                this.SetDefault();

                #region 入力可否制御
                
                // PH
                bool jisshiFlg = JudgeActivate("001");
                if (!jisshiFlg)
                {
                    this.pHTextBox.CustomReadOnly = true;
                    this.pHTextBox.Text = "-";

                    this.maePhTextBox.Text = "-";

                    this.pHComboBox.Enabled = false;
                    this.pHComboBox.SelectedValue = "0";
                }

                // 水温
                jisshiFlg = JudgeActivate("001");
                if (!jisshiFlg)
                {
                    this.suionTextBox.CustomReadOnly = true;
                    this.suionTextBox.Text = "-";
                }

                // DO
                jisshiFlg = JudgeActivate("002");
                if (!jisshiFlg)
                {
                    this.doFromTextBox.CustomReadOnly = true;
                    this.doFromTextBox.Text = "-";

                    this.doToTextBox.CustomReadOnly = true;
                    this.doToTextBox.Text = "-";

                    this.maeDoTextBox.Text = "-";

                    this.doComboBox.Enabled = false;
                    this.doComboBox.SelectedValue = "0";
                }

                // 二次透視度
                jisshiFlg = JudgeActivate("003");
                if (!jisshiFlg)
                {
                    this.nijiToushidoTextBox.CustomReadOnly = true;
                    this.nijiToushidoTextBox.Text = "-";

                    this.maeNijiToushidoTextBox.Text = "-";

                    this.nijiToushidoComboBox.Enabled = false;
                    this.nijiToushidoComboBox.SelectedValue = "0";
                }

                // 透視度
                jisshiFlg = JudgeActivate("004");
                if (!jisshiFlg)
                {
                    this.toushidoTextBox.CustomReadOnly = true;
                    this.toushidoTextBox.Text = "-";

                    this.maeToushidoTextBox.Text = "-";

                    this.toushidoComboBox.Enabled = false;
                    this.toushidoComboBox.SelectedValue = "0";
                }

                // 残留塩素濃度
                jisshiFlg = JudgeActivate("005");
                if (!jisshiFlg)
                {
                    this.zanryuEnsoTextBox.CustomReadOnly = true;
                    this.zanryuEnsoTextBox.Text = "-";

                    this.maeZanryuEnsoTextBox.Text = "-";

                    this.zanryuEnsoComboBox.Enabled = false;
                    this.zanryuEnsoComboBox.SelectedValue = "0";
                }

                // SV30
                jisshiFlg = JudgeActivate("006");
                if (!jisshiFlg)
                {
                    this.sv30TextBox.CustomReadOnly = true;
                    this.sv30TextBox.Text = "-";

                    this.maeSv30TextBox.Text = "-";

                    this.sv30ComboBox.Enabled = false;
                    this.sv30ComboBox.SelectedValue = "0";
                }

                // BOD(今回値は常に参照のみ）
                this.bodTextBox.CustomReadOnly = true;
                this.bodTextBox.Text = "-";
                bool bodJisshiFlg = JudgeActivate("007");
                if(!bodJisshiFlg)
                {
                    this.maeBodTextBox.Text = "-";
                }

                // 2015.01.29 toyoda Add Start 要望対応
                // 塩化物イオン(今回値は常に参照のみ）
                this.enkabutsuIonTextBox.CustomReadOnly = true;
                this.enkabutsuIonTextBox.Text = "-";
                bool enkabutsuIonJisshiFlg = JudgeActivate("008");
                if (!enkabutsuIonJisshiFlg)
                {
                    this.maeEnkabutsuIonTextBox.Text = "-";
                }

                // MLSS
                bool mlssJisshiFlg = JudgeActivate("009");
                if (!mlssJisshiFlg)
                {
                    this.mlssTextBox.CustomReadOnly = true;
                    this.mlssTextBox.Text = "-";

                    this.maeMlssTextBox.Text = "-";
                }

                // ATUBOD(今回値は常に参照のみ）
                this.atuBodTextBox.CustomReadOnly = true;
                this.atuBodTextBox.Text = "-";
                bool atuBodJisshiFlg = JudgeActivate("010");
                if (!atuBodJisshiFlg)
                {
                    this.maeAtuBodTextBox.Text = "-";
                }
                // 2015.01.29 toyoda Add End

                #endregion

                // 検査依頼のスクリーニング区分に応じて画面表示を行う
                if (((KensaMenuForm)this.TopLevelControl).KensaIraiInfo.KensaIraiScreeningKbn.Equals("0"))
                {
                    if (myKensaKekkaTbl.Rows.Count > 0)
                    {
                        // 今回内容：検査結果（今回）
                        KensaKekkaTblDataSet.KensaKekkaTblByKensaIraiKeyRow kensakekka = myKensaKekkaTbl[0];

                        #region 今回内容：検査結果（今回）

                        // PH
                        if (!pHTextBox.CustomReadOnly)
                        {
                            this.pHTextBox.Text = kensakekka.IsKensaKekkaSuisoIonNodoNull() ?
                                string.Empty : kensakekka.KensaKekkaSuisoIonNodo.ToString();

                            if (kensakekka.IsKensaKekkaSuisoIonNodoHanteiNull() || string.IsNullOrEmpty(kensakekka.KensaKekkaSuisoIonNodoHantei))
                            {
                                this.pHComboBox.SelectedIndex = -1;
                            }
                            else
                            {
                                this.pHComboBox.SelectedValue = kensakekka.KensaKekkaSuisoIonNodoHantei;
                            }
                        }

                        // 水温
                        if (!suionTextBox.CustomReadOnly)
                        {
                            this.suionTextBox.Text = kensakekka.IsKensaKekkaOndoNull() ?
                                string.Empty : kensakekka.KensaKekkaOndo.ToString();
                        }

                        // DO
                        if (!doFromTextBox.CustomReadOnly)
                        {
                            //From
                            this.doFromTextBox.Text = kensakekka.IsKensaKekkaYozonSansoryo1Null() ?
                                string.Empty : kensakekka.KensaKekkaYozonSansoryo1.ToString();

                            //To
                            this.doToTextBox.Text = kensakekka.IsKensaKekkaYozonSansoryo2Null() ?
                                string.Empty : kensakekka.KensaKekkaYozonSansoryo2.ToString();

                            if (kensakekka.IsKensaKekkaYozonSansoryoHanteiNull() || string.IsNullOrEmpty(kensakekka.KensaKekkaYozonSansoryoHantei))
                            {
                                this.doComboBox.SelectedIndex = -1;
                            }
                            else
                            {
                                this.doComboBox.SelectedValue = kensakekka.KensaKekkaYozonSansoryoHantei;
                            }
                        }

                        // 透視度二次処理水
                        if (!nijiToushidoTextBox.CustomReadOnly)
                        {
                            this.nijiToushidoTextBox.Text = kensakekka.IsKensaKekkaToshido2jiSyorisuiNull() ?
                                string.Empty : kensakekka.KensaKekkaToshido2jiSyorisui.ToString();

                            if (kensakekka.IsKensaKekkaToshidoHantei2jiSyorisuiNull() || string.IsNullOrEmpty(kensakekka.KensaKekkaToshidoHantei2jiSyorisui))
                            {
                                this.nijiToushidoComboBox.SelectedIndex = -1;
                            }
                            else
                            {
                                this.nijiToushidoComboBox.SelectedValue = kensakekka.KensaKekkaToshidoHantei2jiSyorisui;
                            }
                        }

                        // 透視度
                        if (!toushidoTextBox.CustomReadOnly)
                        {
                            this.toushidoTextBox.Text = kensakekka.IsKensaKekkaToshidoNull() ?
                                string.Empty : kensakekka.KensaKekkaToshido.ToString();

                            if (kensakekka.IsKensaKekkaToshidoHanteiNull() || string.IsNullOrEmpty(kensakekka.KensaKekkaToshidoHantei))
                            {
                                this.toushidoComboBox.SelectedIndex = -1;
                            }
                            else
                            {
                                this.toushidoComboBox.SelectedValue = kensakekka.KensaKekkaToshidoHantei;
                            }
                        }

                        // 残留塩素濃度
                        if (!zanryuEnsoTextBox.CustomReadOnly)
                        {
                            this.zanryuEnsoTextBox.Text = kensakekka.IsKensaKekkaZanryuEnsoNodoNull() ?
                                string.Empty : kensakekka.KensaKekkaZanryuEnsoNodo.ToString();

                            if (kensakekka.IsKensaKekkaZanryuEnsoNodoHanteiNull() || string.IsNullOrEmpty(kensakekka.KensaKekkaZanryuEnsoNodoHantei))
                            {
                                this.zanryuEnsoComboBox.SelectedIndex = -1;
                            }
                            else
                            {
                                this.zanryuEnsoComboBox.SelectedValue = kensakekka.KensaKekkaZanryuEnsoNodoHantei;
                            }
                        }

                        // SV30
                        if (!sv30TextBox.CustomReadOnly)
                        {
                            this.sv30TextBox.Text = kensakekka.IsKensaKekkaOdeiChindenritsuNull() ?
                                string.Empty : kensakekka.KensaKekkaOdeiChindenritsu.ToString();

                            if (kensakekka.IsKensaKekkaOdeiChindenritsuHanteiNull() || string.IsNullOrEmpty(kensakekka.KensaKekkaOdeiChindenritsuHantei))
                            {
                                this.sv30ComboBox.SelectedIndex = -1;
                            }
                            else
                            {
                                this.sv30ComboBox.SelectedValue = kensakekka.KensaKekkaOdeiChindenritsuHantei;
                            }
                        }
                        
                        // 2015.01.29 toyoda Add Start 要望対応
                        // 塩化物イオン
                        if (enkabutsuIonJisshiFlg)
                        {
                            this.enkabutsuIonTextBox.Text = kensakekka.IsKensaKekkaEnsoIonNodoNull() ?
                                string.Empty : kensakekka.KensaKekkaEnsoIonNodo.ToString();
                        }

                        // MLSS
                        if (mlssJisshiFlg)
                        {
                            this.mlssTextBox.Text = kensakekka.IsKensaKekkaMLSSNull() ?
                                string.Empty : kensakekka.KensaKekkaMLSS.ToString();
                        }

                        // ATUBOD
                        if (atuBodJisshiFlg)
                        {
                            this.atuBodTextBox.Text = kensakekka.IsKensaKekkaATUBODNull() ?
                                string.Empty : kensakekka.KensaKekkaATUBOD.ToString();
                        }
                        // 2015.01.29 toyoda Add End

                        #endregion
                    }

                    // 前回内容：検査結果（前回）　※検査依頼履歴には今回分は含まれないので、0件より多い場合のみ処理する。
                    if (myLastKensaKekkaTbl.Rows.Count > 0)
                    {
						// クエリ側で年、月、日の桁合わせができないため、画面側で今回分より古いデータの最大を使用するよう制御する。
						string curY = String.Empty;
						string curM = String.Empty;
						string curD = String.Empty;
						string curYmd = String.Empty;
						string lstY = String.Empty;
						string lstM = String.Empty;
						string lstD = String.Empty;
						string lstYmd = String.Empty;

						curY = ((KensaMenuForm)this.TopLevelControl).KensaIraiInfo.IsKensaIraiKensaYoteiNenNull() ?
							"0000" : ((KensaMenuForm)this.TopLevelControl).KensaIraiInfo.KensaIraiKensaYoteiNen.PadLeft(4, '0');
						curM = ((KensaMenuForm)this.TopLevelControl).KensaIraiInfo.IsKensaIraiKensaYoteiTsukiNull() ?
							"00" : ((KensaMenuForm)this.TopLevelControl).KensaIraiInfo.KensaIraiKensaYoteiTsuki.PadLeft(2, '0');
						curD = ((KensaMenuForm)this.TopLevelControl).KensaIraiInfo.IsKensaIraiKensaYoteiBiNull() ?
							"00" : ((KensaMenuForm)this.TopLevelControl).KensaIraiInfo.KensaIraiKensaYoteiBi.PadLeft(2, '0');
						curYmd = curY + curM + curD;

						// 前回検査結果にnullをセットしておく
						KensaKekkaTblDataSet.KensaKekkaTblByKensaIraiKeyRow lastkekka = null;

						// 検査予定年月日の降順(年月日がnullのデータは最後尾)で並んだ検査結果行の中で、今回の検査予定年月日よりも古いデータを見つけて入れ替える
						foreach (KensaKekkaTblDataSet.KensaKekkaTblByKensaIraiKeyRow wkKekka in myLastKensaKekkaTbl)
						{
							lstY = wkKekka.IsKensaIraiKensaYoteiNenNull() ? "0000" : wkKekka.KensaIraiKensaYoteiNen.PadLeft(4, '0');
							lstM = wkKekka.IsKensaIraiKensaYoteiTsukiNull() ? "00" : wkKekka.KensaIraiKensaYoteiTsuki.PadLeft(2, '0');
							lstD = wkKekka.IsKensaIraiKensaYoteiBiNull() ? "00" : wkKekka.KensaIraiKensaYoteiBi.PadLeft(2, '0');
							lstYmd = lstY + lstM + lstD;

							// 今回の検査予定年月日よりも古い場合
							if (String.Compare(curYmd,lstYmd) > 0)
							{
								lastkekka = wkKekka;	// 前回の検査結果をセット
								break;
							}
						}

                        #region 前回内容：検査結果（前回）

						// 前回の検査結果が取得できた場合のみ、前回内容を表示する。
						if (lastkekka != null)
						{
							// 採水日
							this.maekensaDateTextBox.Text = lastkekka.IsKensaKekkaSaisuiDtNull() ?
								String.Empty : FukjTabletSystem.Application.Utility.DateUtility.ConvertToWareki(lastkekka.KensaKekkaSaisuiDt, "yy.MM.dd");

							// 検査種別
							this.maeShubetsuTextBox.Text = lastkekka.IsHoteiKbnNmNull() ?
								String.Empty : lastkekka.HoteiKbnNm;

							// PH
							if (!pHTextBox.CustomReadOnly)
							{
								this.maePhTextBox.Text = lastkekka.IsKensaKekkaSuisoIonNodoNull() ?
									String.Empty : lastkekka.KensaKekkaSuisoIonNodo.ToString("F1");
							}

							// DO
							if (!doFromTextBox.CustomReadOnly)
							{
								this.maeDoTextBox.Text = lastkekka.IsKensaKekkaYozonSansoryo1Null() ?
                                    String.Empty : lastkekka.KensaKekkaYozonSansoryo1.ToString("F1");
							}

							// 透視度二次処理水
							if (!nijiToushidoTextBox.CustomReadOnly)
							{
								this.maeNijiToushidoTextBox.Text = lastkekka.IsKensaKekkaToshido2jiSyorisuiNull() ?
                                    String.Empty : lastkekka.KensaKekkaToshido2jiSyorisui.ToString("F0");
							}

							// 透視度
							if (!toushidoTextBox.CustomReadOnly)
							{
								this.maeToushidoTextBox.Text = lastkekka.IsKensaKekkaToshidoNull() ?
                                    String.Empty : lastkekka.KensaKekkaToshido.ToString("F0");
							}

							// 残留塩素濃度
							if (!zanryuEnsoTextBox.CustomReadOnly)
							{
								this.maeZanryuEnsoTextBox.Text = lastkekka.IsKensaKekkaZanryuEnsoNodoNull() ?
                                    String.Empty : lastkekka.KensaKekkaZanryuEnsoNodo.ToString("F2");
							}

							// SV30
							if (!sv30TextBox.CustomReadOnly)
							{
								this.maeSv30TextBox.Text = lastkekka.IsKensaKekkaOdeiChindenritsuNull() ?
                                    String.Empty : lastkekka.KensaKekkaOdeiChindenritsu.ToString("F0");
							}

							// BOD
							if (bodJisshiFlg)
							{
								this.maeBodTextBox.Text = lastkekka.IsKensaKekkaBODNull() ?
                                    String.Empty : lastkekka.KensaKekkaBOD.ToString("F1");
							}

                            // 2015.01.29 toyoda Add Start 要望対応
                            // 塩化物イオン
                            if (enkabutsuIonJisshiFlg)
                            {
                                this.maeEnkabutsuIonTextBox.Text = lastkekka.IsKensaKekkaEnsoIonNodoNull() ?
                                    string.Empty : lastkekka.KensaKekkaEnsoIonNodo.ToString();
                            }

                            // MLSS
                            if (mlssJisshiFlg)
                            {
                                this.maeMlssTextBox.Text = lastkekka.IsKensaKekkaMLSSNull() ?
                                    string.Empty : lastkekka.KensaKekkaMLSS.ToString();
                            }

                            // ATUBOD
                            if (atuBodJisshiFlg)
                            {
                                this.maeAtuBodTextBox.Text = lastkekka.IsKensaKekkaATUBODNull() ?
                                    string.Empty : lastkekka.KensaKekkaATUBOD.ToString();
                            }
                            // 2015.01.29 toyoda Add End
						}

                        #endregion
                    }
                }
                else
                {
                    if (mySaiSaisuiTbl.Rows.Count > 0)
                    {
                        // 今回内容：再採水
                        SaiSaisuiTblDataSet.SaiSaisuiTblByKensaIraiKeyRow saisaisui = mySaiSaisuiTbl[0];

                        #region 今回内容：再採水

                        // PH
                        if (!pHTextBox.CustomReadOnly)
                        {
                            this.pHTextBox.Text = saisaisui.IsSaiSaisuiSuisoIonNodoNull() ?
                                string.Empty : saisaisui.SaiSaisuiSuisoIonNodo.ToString();

                            if (saisaisui.IsSaiSaisuiSuisoIonNodoHanteiNull() || string.IsNullOrEmpty(saisaisui.SaiSaisuiSuisoIonNodoHantei))
                            {
                                this.pHComboBox.SelectedIndex = -1;
                            }
                            else
                            {
                                this.pHComboBox.SelectedValue = saisaisui.SaiSaisuiSuisoIonNodoHantei;
                            }
                        }

                        // 水温
                        if (!suionTextBox.CustomReadOnly)
                        {
                            this.suionTextBox.Text = saisaisui.IsSaiSaisuiOndoNull() ?
                                string.Empty : saisaisui.SaiSaisuiOndo.ToString();
                        }

                        // DO
                        if (!doFromTextBox.CustomReadOnly)
                        {
                            //From
                            this.doFromTextBox.Text = saisaisui.IsSaiSaisuiYozonSansoryo1Null() ?
                                string.Empty : saisaisui.SaiSaisuiYozonSansoryo1.ToString();

                            //To
                            this.doToTextBox.Text = saisaisui.IsSaiSaisuiYozonSansoryo2Null() ?
                                string.Empty : saisaisui.SaiSaisuiYozonSansoryo2.ToString();


                            if (saisaisui.IsSaiSaisuiYozonSansoryoHanteiNull() || string.IsNullOrEmpty(saisaisui.SaiSaisuiYozonSansoryoHantei))
                            {
                                this.doComboBox.SelectedIndex = -1;
                            }
                            else
                            {
                                this.doComboBox.SelectedValue = saisaisui.SaiSaisuiYozonSansoryoHantei;
                            }
                        }

                        // 透視度二次処理水
                        if (!nijiToushidoTextBox.CustomReadOnly)
                        {
                            this.nijiToushidoTextBox.Text = saisaisui.IsSaiSaisuiToshido2jishorisuiNull() ?
                                string.Empty : saisaisui.SaiSaisuiToshido2jishorisui.ToString();

                            if (saisaisui.IsSaiSaisuiToshidoHantei2jishorisuiNull() || string.IsNullOrEmpty(saisaisui.SaiSaisuiToshidoHantei2jishorisui))
                            {
                                this.nijiToushidoComboBox.SelectedIndex = -1;
                            }
                            else
                            {
                                this.nijiToushidoComboBox.SelectedValue = saisaisui.SaiSaisuiToshidoHantei2jishorisui;
                            }
                        }

                        // 透視度
                        if (!toushidoTextBox.CustomReadOnly)
                        {
                            this.toushidoTextBox.Text = saisaisui.IsSaiSaisuiToshidoNull() ?
                                string.Empty : saisaisui.SaiSaisuiToshido.ToString();

                            if (saisaisui.IsSaiSaisuiToshidoHanteiNull() || string.IsNullOrEmpty(saisaisui.SaiSaisuiToshidoHantei))
                            {
                                this.toushidoComboBox.SelectedIndex = -1;
                            }
                            else
                            {
                                this.toushidoComboBox.SelectedValue = saisaisui.SaiSaisuiToshidoHantei;
                            }
                        }

                        // 残留塩素濃度
                        if (!zanryuEnsoTextBox.CustomReadOnly)
                        {
                            this.zanryuEnsoTextBox.Text = saisaisui.IsSaiSaisuiZanryuEnsoNodoNull() ?
                                string.Empty : saisaisui.SaiSaisuiZanryuEnsoNodo.ToString();

                            if (saisaisui.IsSaiSaisuiZanryuEnsoNodoHanteiNull() || string.IsNullOrEmpty(saisaisui.SaiSaisuiZanryuEnsoNodoHantei))
                            {
                                this.zanryuEnsoComboBox.SelectedIndex = -1;
                            }
                            else
                            {
                                this.zanryuEnsoComboBox.SelectedValue = saisaisui.SaiSaisuiZanryuEnsoNodoHantei;
                            }
                        }

                        // SV30
                        if (!sv30TextBox.CustomReadOnly)
                        {
                            this.sv30TextBox.Text = saisaisui.IsSaiSaisuiOdeichindenritsuNull() ?
                                string.Empty : saisaisui.SaiSaisuiOdeichindenritsu.ToString();

                            if (saisaisui.IsSaiSaisuiOdeichindenritsuHanteiNull() || string.IsNullOrEmpty(saisaisui.SaiSaisuiOdeichindenritsuHantei))
                            {
                                this.sv30ComboBox.SelectedIndex = -1;
                            }
                            else
                            {
                                this.sv30ComboBox.SelectedValue = saisaisui.SaiSaisuiOdeichindenritsuHantei;
                            }
                        }

                        // 2015.01.29 toyoda Add Start 要望対応
                        // 塩化物イオン
                        if (enkabutsuIonJisshiFlg)
                        {
                            this.enkabutsuIonTextBox.Text = saisaisui.IsSaiSaisuiEnkaIonNodoNull() ?
                                string.Empty : saisaisui.SaiSaisuiEnkaIonNodo.ToString();
                        }

                        // MLSS
                        if (mlssJisshiFlg)
                        {
                            this.mlssTextBox.Text = saisaisui.IsSaiSaisuiMLSSNull() ?
                                string.Empty : saisaisui.SaiSaisuiMLSS.ToString();
                        }

                        // ATUBOD
                        if (atuBodJisshiFlg)
                        {
                            this.atuBodTextBox.Text = saisaisui.IsSaiSaisuiATUBODNull() ?
                                string.Empty : saisaisui.SaiSaisuiATUBOD.ToString();
                        }
                        // 2015.01.29 toyoda Add End

                        #endregion
                    }

                    if (myKensaKekkaTbl.Rows.Count > 0)
                    {
                        // 前回内容：検査結果（今回）
                        KensaKekkaTblDataSet.KensaKekkaTblByKensaIraiKeyRow kensakekka = myKensaKekkaTbl[0];

                        #region 前回内容：検査結果（今回）

                        // 採水日
                        this.maekensaDateTextBox.Text = kensakekka.IsKensaKekkaSaisuiDtNull() ?
                            String.Empty : FukjTabletSystem.Application.Utility.DateUtility.ConvertToWareki(kensakekka.KensaKekkaSaisuiDt, "yy.MM.dd");

                        // 検査種別
                        this.maeShubetsuTextBox.Text = kensakekka.IsHoteiKbnNmNull() ?
                            String.Empty : kensakekka.HoteiKbnNm;

                        // PH
                        if (!pHTextBox.CustomReadOnly)
                        {
                            this.maePhTextBox.Text = kensakekka.IsKensaKekkaSuisoIonNodoNull() ?
                                String.Empty : kensakekka.KensaKekkaSuisoIonNodo.ToString("F1");
                        }

                        // DO
                        if (!doFromTextBox.CustomReadOnly)
                        {
                            this.maeDoTextBox.Text = kensakekka.IsKensaKekkaYozonSansoryo1Null() ?
                                String.Empty : kensakekka.KensaKekkaYozonSansoryo1.ToString("F1");
                        }

                        // 透視度二次処理水
                        if (!nijiToushidoTextBox.CustomReadOnly)
                        {
                            this.maeNijiToushidoTextBox.Text = kensakekka.IsKensaKekkaToshido2jiSyorisuiNull() ?
                                String.Empty : kensakekka.KensaKekkaToshido2jiSyorisui.ToString("F0");
                        }

                        // 透視度
                        if (!toushidoTextBox.CustomReadOnly)
                        {
                            this.maeToushidoTextBox.Text = kensakekka.IsKensaKekkaToshidoNull() ?
                                String.Empty : kensakekka.KensaKekkaToshido.ToString("F0");
                        }

                        // 残留塩素濃度
                        if (!zanryuEnsoTextBox.CustomReadOnly)
                        {
                            this.maeZanryuEnsoTextBox.Text = kensakekka.IsKensaKekkaZanryuEnsoNodoNull() ?
                                String.Empty : kensakekka.KensaKekkaZanryuEnsoNodo.ToString("F2");
                        }

                        // SV30
                        if (!sv30TextBox.CustomReadOnly)
                        {
                            this.maeSv30TextBox.Text = kensakekka.IsKensaKekkaOdeiChindenritsuNull() ?
                                String.Empty : kensakekka.KensaKekkaOdeiChindenritsu.ToString("F0");
                        }

                        // BOD
                        if (bodJisshiFlg)
                        {
                            this.maeBodTextBox.Text = kensakekka.IsKensaKekkaBODNull() ?
                                String.Empty : kensakekka.KensaKekkaBOD.ToString("F1");
                        }

                        // 2015.01.29 toyoda Add Start 要望対応
                        // 塩化物イオン
                        if (enkabutsuIonJisshiFlg)
                        {
                            this.maeEnkabutsuIonTextBox.Text = kensakekka.IsKensaKekkaEnsoIonNodoNull() ?
                                string.Empty : kensakekka.KensaKekkaEnsoIonNodo.ToString();
                        }

                        // MLSS
                        if (mlssJisshiFlg)
                        {
                            this.maeMlssTextBox.Text = kensakekka.IsKensaKekkaMLSSNull() ?
                                string.Empty : kensakekka.KensaKekkaMLSS.ToString();
                        }

                        // ATUBOD
                        if (atuBodJisshiFlg)
                        {
                            this.maeAtuBodTextBox.Text = kensakekka.IsKensaKekkaATUBODNull() ?
                                string.Empty : kensakekka.KensaKekkaATUBOD.ToString();
                        }
                        // 2015.01.29 toyoda Add End

                        #endregion
                    }
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

        #region JudgeActivate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： JudgeActivate
        /// <summary>
        /// 水質検査項目について内部テーブルと照合し、活性表示とするか否かを判定する
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19　戸口　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool JudgeActivate(string renban)
        {
            bool result= false;

            string constval = ConstMstList.GetRow("071", renban).ConstValue;

            // 検査区分：法定区分
            string kensaKbn = ((KensaMenuForm)this.TopLevelControl).IraiHoteiKbn;
            // 検査項目コード
            string kensaKomokuCd = constval;

            //KensaJisshiUmuFlgが0で存在する場合、検査実施する項目とみなす。
            DataRow[] wkList = myKensaJisshiMst.Select( 
                "KensaKbn = '" + kensaKbn + "' AND " +
                "KensaJisshiUmuFlg = '0' AND " +
                "KensaKomokuCd = '" + kensaKomokuCd + "'"
            );

            if(wkList.Length > 0)
            {
                result = true;
            }

            return result;
        }
        #endregion

        #region SetDefault
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetControlData
        /// <summary>
        /// 画面コントロールの表示を初期状態にする
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19　戸口　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDefault()
        {
            // 今回内容
            this.pHTextBox.Text = String.Empty;
            this.suionTextBox.Text = String.Empty;
            this.doFromTextBox.Text = String.Empty;
            this.doToTextBox.Text = String.Empty;
            this.nijiToushidoTextBox.Text = String.Empty;
            this.toushidoTextBox.Text = String.Empty;
            this.zanryuEnsoTextBox.Text = String.Empty;
            this.sv30TextBox.Text = String.Empty;
            this.bodTextBox.Text = String.Empty;

            // 2015.01.29 toyoda Add Start 要望対応
            this.atuBodTextBox.Text = string.Empty;
            this.enkabutsuIonTextBox.Text = string.Empty;
            this.mlssTextBox.Text = string.Empty;
            // 2015.01.29 toyoda Add End

            // 判定
            pHComboBox.SelectedIndex = -1;
            doComboBox.SelectedIndex = -1;
            nijiToushidoComboBox.SelectedIndex = -1;
            toushidoComboBox.SelectedIndex = -1;
            zanryuEnsoComboBox.SelectedIndex = -1;
            sv30ComboBox.SelectedIndex = -1;

            // 前回内容
            this.maekensaDateTextBox.Text = String.Empty;
            this.maeShubetsuTextBox.Text = String.Empty;
            this.maePhTextBox.Text = String.Empty;
            this.maeDoTextBox.Text = String.Empty;
            this.maeNijiToushidoTextBox.Text = String.Empty;
            this.maeToushidoTextBox.Text = String.Empty;
            this.maeZanryuEnsoTextBox.Text = String.Empty;
            this.maeSv30TextBox.Text = String.Empty;
            this.maeBodTextBox.Text = String.Empty;

            // 2015.01.29 toyoda Add Start 要望対応
            this.maeAtuBodTextBox.Text = string.Empty;
            this.maeEnkabutsuIonTextBox.Text = string.Empty;
            this.maeMlssTextBox.Text = string.Empty;
            // 2015.01.29 toyoda Add End

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
        /// 2014/11/15  豊田　　    新規作成
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
        /// 2014/11/15  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaKekkaTblDataSet.KensaKekkaForSuishitsuUpdateDataTable CreateKensaKekkaTbl()
        {
            KensaKekkaTblDataSet.KensaKekkaForSuishitsuUpdateDataTable datatable = new KensaKekkaTblDataSet.KensaKekkaForSuishitsuUpdateDataTable();
            
            if (((KensaMenuForm)this.TopLevelControl).KensaIraiInfo.KensaIraiScreeningKbn.Equals("0"))
            {
                KensaKekkaTblDataSet.KensaKekkaForSuishitsuUpdateRow newRow = datatable.NewKensaKekkaForSuishitsuUpdateRow();
                
                newRow.KensaKekkaIraiHoteiKbn = ((KensaMenuForm)this.TopLevelControl).IraiHoteiKbn;
                newRow.KensaKekkaIraiHokenjoCd = ((KensaMenuForm)this.TopLevelControl).IraiHokenjoCd;
                newRow.KensaKekkaIraiNendo = ((KensaMenuForm)this.TopLevelControl).IraiNendo;
                newRow.KensaKekkaIraiRenban = ((KensaMenuForm)this.TopLevelControl).IraiRenban;
                
                // PH
	            newRow.KensaKekkaSuisoIonNodo = string.IsNullOrEmpty(pHTextBox.Text) ? 0 : double.Parse(pHTextBox.Text);
                
                // PH（判定）
                if(pHComboBox.SelectedIndex == -1)
                {
                    newRow.KensaKekkaSuisoIonNodoHantei = string.Empty;
                }
                else
                {
	                newRow.KensaKekkaSuisoIonNodoHantei = pHComboBox.SelectedValue.ToString();
                }
 
                // 温度
	            newRow.KensaKekkaOndo = string.IsNullOrEmpty(suionTextBox.Text) ? 0 : decimal.Parse(suionTextBox.Text);                
                // DO（From）
	            newRow.KensaKekkaYozonSansoryo1 = string.IsNullOrEmpty(doFromTextBox.Text) ? 0 : double.Parse(doFromTextBox.Text);
                // DO（To）
	            newRow.KensaKekkaYozonSansoryo2 = string.IsNullOrEmpty(doToTextBox.Text) ? 0 : double.Parse(doToTextBox.Text);
                
                // DO（判定）
                if(pHComboBox.SelectedIndex == -1)
                {
                    newRow.KensaKekkaYozonSansoryoHantei = string.Empty;
                }
                else
                {
	                newRow.KensaKekkaYozonSansoryoHantei = doComboBox.SelectedValue.ToString();
                }

                // 二次透視度
	            newRow.KensaKekkaToshido2jiSyorisui = string.IsNullOrEmpty(nijiToushidoTextBox.Text) ? 0 : double.Parse(nijiToushidoTextBox.Text);
                
                // 二次透視度（判定）
                if(nijiToushidoComboBox.SelectedIndex == -1)
                {
                    newRow.KensaKekkaToshidoHantei2jiSyorisui = string.Empty;
                }
                else
                {
	                newRow.KensaKekkaToshidoHantei2jiSyorisui = nijiToushidoComboBox.SelectedValue.ToString();
                }

                // 透視度
	            newRow.KensaKekkaToshido = string.IsNullOrEmpty(toushidoTextBox.Text) ? 0 : double.Parse(toushidoTextBox.Text);
                
                // 透視度（判定）
                if(toushidoComboBox.SelectedIndex == -1)
                {
                    newRow.KensaKekkaToshidoHantei = string.Empty;
                }
                else
                {
	                newRow.KensaKekkaToshidoHantei = toushidoComboBox.SelectedValue.ToString();
                }

                // 残留塩素
	            newRow.KensaKekkaZanryuEnsoNodo = string.IsNullOrEmpty(zanryuEnsoTextBox.Text) ? 0 : double.Parse(zanryuEnsoTextBox.Text);
                
                // 残留塩素（判定）
                if(zanryuEnsoComboBox.SelectedIndex == -1)
                {
                    newRow.KensaKekkaZanryuEnsoNodoHantei = string.Empty;
                }
                else
                {
	                newRow.KensaKekkaZanryuEnsoNodoHantei = zanryuEnsoComboBox.SelectedValue.ToString();
                }
                
                // SV30
	            newRow.KensaKekkaOdeiChindenritsu = string.IsNullOrEmpty(sv30TextBox.Text) ? 0 : decimal.Parse(sv30TextBox.Text);
                
                // SV30（判定）
                if (sv30ComboBox.SelectedIndex == -1)
                {
                    newRow.KensaKekkaOdeiChindenritsuHantei = string.Empty;
                }
                else
                {
	                newRow.KensaKekkaOdeiChindenritsuHantei = sv30ComboBox.SelectedValue.ToString();
                }

                // 2015.01.29 toyoda Add Start 要望対応
                // MLSS
                newRow.KensaKekkaMLSS = string.IsNullOrEmpty(mlssTextBox.Text) ? 0 : decimal.Parse(mlssTextBox.Text);
                // 2015.01.29 toyoda Add End

                datatable.AddKensaKekkaForSuishitsuUpdateRow(newRow);

                newRow.AcceptChanges();
                newRow.SetModified();
            }

            return datatable;
        }
        #endregion
        
        #region CreateSaiSaisuiTbl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSaiSaisuiTbl
        /// <summary>
        /// 画面データを更新用データに設定する
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/15  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SaiSaisuiTblDataSet.SaiSaisuiTblForSuishitsuUpdateDataTable CreateSaiSaisuiTbl()
        {
            SaiSaisuiTblDataSet.SaiSaisuiTblForSuishitsuUpdateDataTable datatable = new SaiSaisuiTblDataSet.SaiSaisuiTblForSuishitsuUpdateDataTable();
            
            if (!((KensaMenuForm)this.TopLevelControl).KensaIraiInfo.KensaIraiScreeningKbn.Equals("0"))
            {
                SaiSaisuiTblDataSet.SaiSaisuiTblForSuishitsuUpdateRow newRow = datatable.NewSaiSaisuiTblForSuishitsuUpdateRow();
                
                newRow.SaiSaisuiIraiHoteiKbn = ((KensaMenuForm)this.TopLevelControl).IraiHoteiKbn;
                newRow.SaiSaisuiIraiHokenjoCd = ((KensaMenuForm)this.TopLevelControl).IraiHokenjoCd;
                newRow.SaiSaisuiIraiNendo = ((KensaMenuForm)this.TopLevelControl).IraiNendo;
                newRow.SaiSaisuiIraiRrenban = ((KensaMenuForm)this.TopLevelControl).IraiRenban;
                
                // PH
	            newRow.SaiSaisuiSuisoIonNodo = string.IsNullOrEmpty(pHTextBox.Text) ? 0 : double.Parse(pHTextBox.Text);
                
                // PH（判定）
                if(pHComboBox.SelectedIndex == -1)
                {
                    newRow.SaiSaisuiSuisoIonNodoHantei = string.Empty;
                }
                else
                {
	                newRow.SaiSaisuiSuisoIonNodoHantei = pHComboBox.SelectedValue.ToString();
                }
 
                // 温度
	            newRow.SaiSaisuiOndo = string.IsNullOrEmpty(suionTextBox.Text) ? 0 : decimal.Parse(suionTextBox.Text);                
                // DO（From）
	            newRow.SaiSaisuiYozonSansoryo1 = string.IsNullOrEmpty(doFromTextBox.Text) ? 0 : double.Parse(doFromTextBox.Text);
                // DO（To）
	            newRow.SaiSaisuiYozonSansoryo2 = string.IsNullOrEmpty(doToTextBox.Text) ? 0 : double.Parse(doToTextBox.Text);
                
                // DO（判定）
                if (doComboBox.SelectedIndex == -1)
                {
                    newRow.SaiSaisuiYozonSansoryoHantei = string.Empty;
                }
                else
                {
	                newRow.SaiSaisuiYozonSansoryoHantei = doComboBox.SelectedValue.ToString();
                }

                // 二次透視度
	            newRow.SaiSaisuiToshido2jishorisui = string.IsNullOrEmpty(nijiToushidoTextBox.Text) ? 0 : double.Parse(nijiToushidoTextBox.Text);
                
                // 二次透視度（判定）
                if(nijiToushidoComboBox.SelectedIndex == -1)
                {
                    newRow.SaiSaisuiToshidoHantei2jishorisui = string.Empty;
                }
                else
                {
	                newRow.SaiSaisuiToshidoHantei2jishorisui = nijiToushidoComboBox.SelectedValue.ToString();
                }

                // 透視度
	            newRow.SaiSaisuiToshido = string.IsNullOrEmpty(toushidoTextBox.Text) ? 0 : double.Parse(toushidoTextBox.Text);
                
                // 透視度（判定）
                if(toushidoComboBox.SelectedIndex == -1)
                {
                    newRow.SaiSaisuiToshidoHantei = string.Empty;
                }
                else
                {
	                newRow.SaiSaisuiToshidoHantei = toushidoComboBox.SelectedValue.ToString();
                }

                // 残留塩素
	            newRow.SaiSaisuiZanryuEnsoNodo = string.IsNullOrEmpty(zanryuEnsoTextBox.Text) ? 0 : double.Parse(zanryuEnsoTextBox.Text);
                
                // 残留塩素（判定）
                if(zanryuEnsoComboBox.SelectedIndex == -1)
                {
                    newRow.SaiSaisuiZanryuEnsoNodoHantei = string.Empty;
                }
                else
                {
	                newRow.SaiSaisuiZanryuEnsoNodoHantei = zanryuEnsoComboBox.SelectedValue.ToString();
                }
                
                // SV30
	            newRow.SaiSaisuiOdeichindenritsu = string.IsNullOrEmpty(sv30TextBox.Text) ? 0 : decimal.Parse(sv30TextBox.Text);
                
                // SV30（判定）
                if (sv30ComboBox.SelectedIndex == -1)
                {
                    newRow.SaiSaisuiOdeichindenritsuHantei = string.Empty;
                }
                else
                {
	                newRow.SaiSaisuiOdeichindenritsuHantei = sv30ComboBox.SelectedValue.ToString();
                }

                // 2015.01.29 toyoda Add Start 要望対応
                // MLSS
                newRow.SaiSaisuiMLSS = string.IsNullOrEmpty(mlssTextBox.Text) ? 0 : decimal.Parse(mlssTextBox.Text);
                // 2015.01.29 toyoda Add End

                datatable.AddSaiSaisuiTblForSuishitsuUpdateRow(newRow);

                newRow.AcceptChanges();
                newRow.SetModified();
            }

            return datatable;
        }
        #endregion

        #endregion
    }
    #endregion
}
