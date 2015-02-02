using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;
using Zynas.Control.Common;

namespace FukjBizSystem.Application.Boundary.SuishitsuKensaUketsuke
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： HhtInputForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/31  宗  　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class HhtInputForm : FukjBaseForm
    {
        #region 定数定義

        // 水質検査区分（画面上部の条件）
        class SuishitsuKensaKbn
        {
            // 計量証明
            public const string KeiryoShomei = "1";
            // 水質検査
            public const string SuishitsuKensa = "2";
            // 外観検査
            public const string GaikanKensa = "3";
        }

        private const int kentaiNoColIndex = 1;

        private const int barcodeNoColIndex = 0;
        #endregion

        #region プロパティ(public)

        /// <summary>
        /// HHTデータ用DataTable
        /// </summary>
        public SuishitsuKensaIraiDataSet.HhtImportDataTable hhtDT = new SuishitsuKensaIraiDataSet.HhtImportDataTable();

        #endregion

        #region プロパティ(private)

        /// <summary>
        /// 法定検査区分
        /// </summary>
        private string _suishitsuKensaKbn = string.Empty;

        /// <summary>
        /// HHTデータ用DataTable
        /// </summary>
        private SuishitsuKensaIraiDataSet.HhtImportDataTable _hhtDT = new SuishitsuKensaIraiDataSet.HhtImportDataTable();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： HhtInputForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/31  宗  　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public HhtInputForm(string kensaKbn, SuishitsuKensaIraiDataSet.HhtImportDataTable dt)
        {
            InitializeComponent();

            // 法定検査区分
            _suishitsuKensaKbn = kensaKbn;
            // HHTデータ用DataTable
            copyHhtData(dt, _hhtDT);
        }
        #endregion

        #region イベント

        #region HhtInputForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： HhtInputForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/31  宗  　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void HhtInputForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 各コントロールのドメイン設定
                setControlDomain();

                // 取得したデータを一覧にセット
                kensaIraiListDataGridView.DataSource = _hhtDT;
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);

                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region haneiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： haneiButton_Click
        /// <summary>
        /// 反映ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/31  宗  　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void haneiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 入力チェック
                foreach (DataGridViewRow dgvr in kensaIraiListDataGridView.Rows)
                {
                    // 新規入力行はスキップ
                    if (dgvr.IsNewRow)
                    {
                        continue;
                    }

                    // 検体番号
                    if (string.IsNullOrEmpty(dgvr.Cells[kentaiNoColIndex].Value.ToString()))
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, "検体番号が設定されていません。");
                        return;
                    }
                    // バーコード番号
                    if (string.IsNullOrEmpty(dgvr.Cells[barcodeNoColIndex].Value.ToString()))
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, "バーコード番号が入力されていません。");
                        return;
                    }
                }

                // HHTデータテーブル編集
                editHhtData();

                //// HHTデータテーブル返却
                //hhtDT = _hhtDT;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region butchInputButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： butchInputButton_Click
        /// <summary>
        /// 連番付与ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/31  宗  　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void butchInputButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(kentaiNoTextBox.Text))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "検体番号(開始番号)を入力して下さい。");
                return;
            }

            // 連番付与
            int rowCnt = int.Parse(kentaiNoTextBox.Text);
            setRenban(rowCnt);
        }
        #endregion

        #region tojiruButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： tojiruButton_Click
        /// <summary>
        /// 閉じるボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/31  宗  　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void tojiruButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this.Close();
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region kensaIraiListDataGridView_CellValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaIraiListDataGridView_CellValueChanged
        /// <summary>
        /// 一覧の値変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/31  宗  　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensaIraiListDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (string.IsNullOrEmpty(kentaiNoTextBox.Text))
            {
                // 検体番号(開始番号)が未入力の場合は付与しない
                return;
            }

            // 連番付与
            int rowCnt = int.Parse(kentaiNoTextBox.Text);
            setRenban(rowCnt);
        }
        #endregion

        #region HhtInputForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： HhtInputForm_KeyDown
        /// <summary>
        /// フォームキー押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/31  宗  　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void HhtInputForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        haneiButton.Focus();
                        haneiButton.PerformClick();
                        break;
                    case Keys.F2:
                        butchInputButton.Focus();
                        butchInputButton.PerformClick();
                        break;
                    case Keys.F12:
                    case Keys.Alt | Keys.X:
                        tojiruButton.Focus();
                        tojiruButton.PerformClick();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #endregion

        #region メソッド

        #region setControlDomain
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： setControlDomain
        /// <summary>
        /// 各コントロールのドメイン設定
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/31  宗  　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void setControlDomain()
        {
            // 検体番号(開始番号)
            kentaiNoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6);
            // 検体番号
            kensaIraiListDataGridView.SetStdControlDomain(kentaiNoColIndex, ZControlDomain.ZG_STD_NUM, 6, DataGridViewContentAlignment.MiddleRight);
            // バーコード番号
            kensaIraiListDataGridView.SetStdControlDomain(barcodeNoColIndex, ZControlDomain.ZG_STD_NUM, 14, DataGridViewContentAlignment.MiddleRight);
        }
        #endregion

        #region editHhtData
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： editHhtData
        /// <summary>
        /// HHTデータ用DataTableを編集
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/31  宗  　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool editHhtData()
        {
            // 先頭行から取込(最終行まで)
            foreach (DataGridViewRow dgvr in kensaIraiListDataGridView.Rows)
            {
                // 新規行はスキップ
                if (dgvr.IsNewRow)
                {
                    continue;
                }

                // 検体番号かバーコード番号が空なら処理を抜ける
                if((string.IsNullOrEmpty(dgvr.Cells[kentaiNoColIndex].Value.ToString()))
                    || (string.IsNullOrEmpty(dgvr.Cells[barcodeNoColIndex].Value.ToString())))
                {
                    return false;
                }

                SuishitsuKensaIraiDataSet.HhtImportRow newRow = hhtDT.NewHhtImportRow();
                // バーコード番号
                newRow.BarcodeNo = string.Empty;
                // 検体番号
                newRow.KentaiNo = string.Empty;
                // 支所コード
                newRow.ShishoCd = string.Empty;
                // 浄化槽台帳保健所コード
                newRow.JokasoHokenjoCd = string.Empty;
                // 浄化槽台帳年度
                newRow.JokasoTorokuNendo = string.Empty;
                // 浄化槽台帳連番
                newRow.JokasoRenban = string.Empty;
                // 検査依頼法定区分
                newRow.KensaIraiHoteiKbn = string.Empty;
                // 検査依頼保健所CD
                newRow.KensaIraiHokenjoCd = string.Empty;
                // 検査依頼依頼年度
                newRow.KensaIraiNendo = string.Empty;
                // 検査依頼連番
                newRow.KensaIraiRenban = string.Empty;
                // 枝番
                newRow.Edaban = string.Empty;
                // 取込状況フラグ
                newRow.TorikomiJyokyoFlg = "0";

                if ((_suishitsuKensaKbn == SuishitsuKensaKbn.KeiryoShomei) || (_suishitsuKensaKbn == SuishitsuKensaKbn.SuishitsuKensa))
                {
                    // 計量証明 OR 水質検査

                    // バーコード番号
                    newRow.BarcodeNo = dgvr.Cells[barcodeNoColIndex].Value.ToString();
                    // 検体番号
                    newRow.KentaiNo = dgvr.Cells[kentaiNoColIndex].Value.ToString().PadLeft(6, '0');

                    if (newRow.BarcodeNo.Length == 10)
                    {
                        // 旧フォーマット

                        // 設置者区分(バーコードの 2桁目から 1文字)
                        newRow.JokasoSetchishaKbn = newRow.BarcodeNo.Substring(1, 1);
                        // 設置者コード(バーコードの 3桁目から 7文字)
                        newRow.JokasoSetchishaCd = newRow.BarcodeNo.Substring(2, 7);
                        // 枝番(バーコードの 10桁目から 1文字)
                        newRow.Edaban = newRow.BarcodeNo.Substring(9, 1);

                        // 設置者区分と設置者コードから浄化槽台帳マスタ情報を取得
                        // データ検索④
                        JokasoDaichoMstDataSet.JokasoDaichoMstDataTable jokasoDaichoMstDT =
                            Common.Common.GetJokasoDaichoMstByJokasoSetchisha(newRow.JokasoSetchishaKbn, newRow.JokasoSetchishaCd);
                        if (jokasoDaichoMstDT.Rows.Count > 0)
                        {
                            JokasoDaichoMstDataSet.JokasoDaichoMstRow row = (JokasoDaichoMstDataSet.JokasoDaichoMstRow)jokasoDaichoMstDT.Rows[0];
                            // 浄化槽台帳保健所コード
                            newRow.JokasoHokenjoCd = row.JokasoHokenjoCd;
                            // 浄化槽台帳年度
                            newRow.JokasoTorokuNendo = row.JokasoTorokuNendo;
                            // 浄化槽台帳連番
                            newRow.JokasoRenban = row.JokasoRenban;
                        }
                        else
                        {
                            // 取込状況フラグ
                            // 該当の浄化槽台帳なし
                            newRow.TorikomiJyokyoFlg = "1";
                        }
                    }
                    else if (newRow.BarcodeNo.Length == 14)
                    {
                        // 新フォーマット

                        // 支所コード(バーコードの 2桁目から 1文字)
                        newRow.ShishoCd = newRow.BarcodeNo.Substring(1, 1);
                        // 検査依頼法定区分(バーコードの 3桁目から 2文字)
                        newRow.JokasoHokenjoCd = newRow.BarcodeNo.Substring(2, 2);
                        // 検査依頼保健所CD(バーコードの 5桁目から 4文字)
                        newRow.JokasoTorokuNendo = newRow.BarcodeNo.Substring(4, 4);
                        // 検査依頼依頼年度(バーコードの 9桁目から 5文字)
                        newRow.JokasoRenban = newRow.BarcodeNo.Substring(8, 5);
                        // 枝番(バーコードの 14桁目から 1文字)
                        newRow.Edaban = newRow.BarcodeNo.Substring(13, 1);
                    }
                }
                else
                {
                    // 外観用

                    // バーコード番号
                    newRow.BarcodeNo = dgvr.Cells[barcodeNoColIndex].Value.ToString();
                    // 検体番号
                    newRow.KentaiNo = dgvr.Cells[kentaiNoColIndex].Value.ToString().PadLeft(6, '0');

                    // バーコード番号が13桁のみセット
                    if (newRow.BarcodeNo.Length == 13)
                    {
                        // 検査依頼法定区分(バーコードの 1桁目から 1文字)
                        newRow.KensaIraiHoteiKbn = newRow.BarcodeNo.Substring(0, 1);
                        // 検査依頼保健所CD(バーコードの 2桁目から 2文字)
                        newRow.KensaIraiHokenjoCd = newRow.BarcodeNo.Substring(1, 2);
                        // 検査依頼依頼年度(バーコードの 4桁目から 4文字)
                        newRow.KensaIraiNendo = newRow.BarcodeNo.Substring(3, 4);
                        // 検査依頼連番(バーコードの 8桁目から 6文字)
                        newRow.KensaIraiRenban = newRow.BarcodeNo.Substring(7, 6);
                    }
                }

                DataRow[] checkRows = hhtDT.Select(string.Format("KentaiNo = '{0}'", newRow.KentaiNo));
                if (checkRows.Length > 0)
                {
                    // 取込状況フラグ
                    // 重複行有
                    newRow.TorikomiJyokyoFlg = "2";
                }

                // 行追加
                hhtDT.AddHhtImportRow(newRow);
            }

            return true;
        }
        #endregion

        #region SetRenban
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SetRenban
        /// <summary>
        /// 連番付与
        /// </summary>
        /// <param name="rowCnt"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/31  宗  　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void setRenban(int rowCnt)
        {
            foreach (DataGridViewRow dgvr in kensaIraiListDataGridView.Rows)
            {
                // 新規入力行はスキップ
                if (dgvr.IsNewRow)
                {
                    continue;
                }

                // 連番付与
                dgvr.Cells[kentaiNoColIndex].Value = rowCnt.ToString().PadLeft(6, '0');

                rowCnt++;
            }
        }
        #endregion

        #region copyHhtData
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： copyHhtData
        /// <summary>
        /// HHTデータ用DataTableをコピー
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/31  宗  　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool copyHhtData(SuishitsuKensaIraiDataSet.HhtImportDataTable hhtDTFrom, SuishitsuKensaIraiDataSet.HhtImportDataTable hhtDTTo)
        {
            // 先頭行から取込(最終行まで)
            foreach (SuishitsuKensaIraiDataSet.HhtImportRow row in hhtDTFrom.Rows)
            {
                SuishitsuKensaIraiDataSet.HhtImportRow newRow = hhtDTTo.NewHhtImportRow();
                // バーコード番号
                newRow.BarcodeNo = row.BarcodeNo;
                // 検体番号
                newRow.KentaiNo = row.KentaiNo;
                // 支所コード
                newRow.ShishoCd = row.ShishoCd;
                // 浄化槽台帳保健所コード
                newRow.JokasoHokenjoCd = row.JokasoHokenjoCd;
                // 浄化槽台帳年度
                newRow.JokasoTorokuNendo = row.JokasoTorokuNendo;
                // 浄化槽台帳連番
                newRow.JokasoRenban = row.JokasoRenban;
                // 検査依頼法定区分
                newRow.KensaIraiHoteiKbn = row.KensaIraiHoteiKbn;
                // 検査依頼保健所CD
                newRow.KensaIraiHokenjoCd = row.KensaIraiHokenjoCd;
                // 検査依頼依頼年度
                newRow.KensaIraiNendo = row.KensaIraiNendo;
                // 検査依頼連番
                newRow.KensaIraiRenban = row.KensaIraiRenban;
                // 枝番
                newRow.Edaban = row.Edaban;
                // 取込状況フラグ
                newRow.TorikomiJyokyoFlg = row.TorikomiJyokyoFlg;

                // 行追加
                hhtDTTo.AddHhtImportRow(newRow);
            }

            return true;
        }
        #endregion

        #endregion
    }
    #endregion
}
