using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.Utility;
using FukjTabletSystem.Application.ApplicationLogic.Kensa;
using FukjTabletSystem.Application.ApplicationLogic.Kensa.GaikanKensaTabPage;
using FukjTabletSystem.Application.Boundary.Kensa.Dialog;
using FukjTabletSystem.Application.DataSet.SQLCE;
using FukjTabletSystem.Application.Utility;
using FukjTabletSystem.Properties;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.Boundary.Kensa.TabPages
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GaikanKensaTabPage
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class GaikanKensaTabPage : BaseKensaTabPage
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GaikanKensaTabPage
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GaikanKensaTabPage()
        {
            InitializeComponent();
        }
        #endregion

        #region イベントハンドラ

        #region GaikanKensaTabPage_Load
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GaikanKensaTabPage_Load(object sender, EventArgs e)
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
                
                // 所見結果情報の取得（外観検査）
                DoSearch();

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
                using (ShokenHanteiDialog frm = new ShokenHanteiDialog(ShokenUtility.SelectMode.Shoken, ShokenUtility.SelectType.GaikanKensa,
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

        #region souchiTsuikaButton_Click(object sender, EventArgs e)
        /// <summary>
        /// 装置追加ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void souchiTsuikaButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 検査依頼のキーと、所見の連番（ここでは使用しないので固定値"01"）を渡す
                using (TaniSochiGroupAddDialog frm = new TaniSochiGroupAddDialog(ShokenUtility.SelectMode.Shoken, ShokenUtility.SelectType.GaikanKensa,
                                                                        new ShokenKey(((KensaMenuForm)this.TopLevelControl).IraiHoteiKbn,
                                                                            ((KensaMenuForm)this.TopLevelControl).IraiHokenjoCd,
                                                                            ((KensaMenuForm)this.TopLevelControl).IraiNendo,
                                                                            ((KensaMenuForm)this.TopLevelControl).IraiRenban,
                                                                            "01")))
                {
                    frm.ShowDialog();

                    if (frm.DialogResult != System.Windows.Forms.DialogResult.OK)
                    {
                        return;
                    }

                    // --------------------------------------------------------------------------
                    //  ※ダイアログ側でデータの確定が行われているため、呼び出し元では何もしない
                    // --------------------------------------------------------------------------
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
        /// 確定ボタン押下
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

                // 更新実行
                new KakuteiBtnClickApplicationLogic().Execute(alInput);

                TabMessageBox.Show2(TabMessageBox.Type.Info, "外観検査", "外観検査結果を更新しました。");
                
                // 自画面の更新
                DoSearch();
                
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
        /// 2014/11/17  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            try
            {
                // 描画を停止
                this.SuspendLayout();

                shokenKekkaListDataSet.ShokenKekkaList.Clear();
                shokenKekkaListDataSet.ShokenKekkaHosokuList.Clear();

                IGetShokenKekkaListALInput alInput = new GetShokenKekkaListALInput();

                alInput.IraiHoteiKbn = ((KensaMenuForm)this.TopLevelControl).IraiHoteiKbn;
                alInput.IraiHokenjoCd = ((KensaMenuForm)this.TopLevelControl).IraiHokenjoCd;
                alInput.IraiNendo = ((KensaMenuForm)this.TopLevelControl).IraiNendo;
                alInput.IraiRenban = ((KensaMenuForm)this.TopLevelControl).IraiRenban;

                alInput.ShokenTaishoKensaBitMask = ShokenUtility.GetBitMask(ShokenUtility.SelectMode.Shoken, ShokenUtility.SelectType.GaikanKensa);
                alInput.TaishouKensaHosokuBitMask = ShokenUtility.GetBitMask(ShokenUtility.SelectMode.Hosokubun, ShokenUtility.SelectType.GaikanKensa);

                IGetShokenKekkaListALOutput alOutput = new GetShokenKekkaListApplicationLogic().Execute(alInput);

                // 取得データを画面に保持
                shokenKekkaListDataSet.ShokenKekkaList.Merge(alOutput.ShokenKekkaList);
                shokenKekkaListDataSet.ShokenKekkaHosokuList.Merge(alOutput.ShokenKekkaHosokuList);
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
                        newRow[col.ColumnName] = row[col.ColumnName,DataRowVersion.Original];
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
                                
        #endregion
    }
    #endregion
}
