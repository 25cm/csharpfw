using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Zynas.Control.Common;

namespace Zynas.Control.ZDataGridView
{
    /// <summary>
    /// ZDataGridViewコントロールクラス
    /// 継承元:DataGridViewコントロール
    /// </summary>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25  habu　　    Added DomainControl methods/props
    /// </history>
    public partial class ZDataGridView : DataGridView
    {
        #region ドメイン制御用内部クラス

        // NOTICE 次回以降は専用のパラメータクラスを使用する方向にする
        ///// <summary>
        ///// 
        ///// </summary>
        //protected class StdDomainParams
        //{
        //    public int maxLength;
        //    public string formatStr;
        //}

        #endregion

        #region ドメイン制御用プロパティ

        /// <summary>
        /// ドメイン設定値保持データ
        /// </summary>
        protected Dictionary<int, ZControlDomain> ColumnControlDomain = new Dictionary<int, ZControlDomain>();

        /// <summary>
        /// カラム毎の桁数保持
        /// </summary>
        protected Dictionary<int, int> ColumnLengthMap = new Dictionary<int, int>();

        /// <summary>
        /// 
        /// </summary>
        protected Dictionary<int, DataGridViewContentAlignment> ColumnAlignMap = new Dictionary<int, DataGridViewContentAlignment>();

        /// <summary>
        /// 入力制限イベントハンドラ(KeyPressFilter)保持キャッシュ
        /// </summary>
        protected Dictionary<string, KeyPressEventHandler> KeyPressFilterCache = new Dictionary<string, KeyPressEventHandler>();

        #endregion

        #region セルマージ用内部クラス

        /// <summary>
        /// マージ範囲情報保持クラス
        /// </summary>
        protected class MergeRange
        {
            // NOTICE 機能追加する場合、データ保持形式は随時検討・見直しする
            public int rowIdx = -1;
            public int colMergeUnit = 1;
            public int colIdx = -1;
            public int rowMergeUnit = 1;
            public bool isAutoMerge = false;
        }

        #endregion

        #region セルマージ用プロパティ

        // NOTICE 今後、CellEditイベントも操作するか、検討（自動マージセルに、常に同じ値が設定される様、維持する）

        /// <summary>
        /// 縦方向(列)マージ範囲情報
        /// </summary>
        protected Dictionary<int, MergeRange> colMergeRangeMap = new Dictionary<int, MergeRange>();
        /// <summary>
        /// 横方向(行)マージ範囲情報
        /// </summary>
        protected Dictionary<int, MergeRange> rowMergeRangeMap = new Dictionary<int, MergeRange>();

        #endregion

        #region コンストラクタ
        /// <summary>
        /// デザイナで表示時のコンストラクタ
        /// </summary>
        public ZDataGridView()
        {
            #region デザイナによる初期化
            InitializeComponent();
            #endregion

            //// マージセル用カスタム描画イベント
            //CellPainting += dgv_MergedCellPainting;
        }

        /// <summary>
        /// プログラム実行時のコンストラクタ
        /// </summary>
        /// <param name="container"></param>
        public ZDataGridView(IContainer container)
        {
            #region デザイナによる初期化
            container.Add(this);

            InitializeComponent();
            #endregion

            //// マージセル用カスタム描画イベント
            //CellPainting += dgv_MergedCellPainting;
        }
        #endregion

        #region セルマージ用メソッド

        #region セルマージ範囲設定

        #region AddMergeRange
        /// <summary>
        /// セルマージ範囲設定
        /// </summary>
        /// <param name="rowIdx"></param>
        /// <param name="colMergeUnit"></param>
        /// <param name="colIdx"></param>
        /// <param name="rowMergeUnit"></param>
        /// <param name="autoMerge"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  habu　　    新規作成
        /// </history>
        public void AddMergeRange(int rowIdx, int colMergeUnit, int colIdx, int rowMergeUnit, bool autoMerge)
        {
            MergeRange range = new MergeRange();

            range.rowIdx = rowIdx;
            range.colMergeUnit = colMergeUnit;
            range.colIdx = colIdx;
            range.rowMergeUnit = rowMergeUnit;
            range.isAutoMerge = autoMerge;

            if (!colMergeRangeMap.ContainsKey(colIdx))
            {
                colMergeRangeMap.Add(colIdx, range);
            }
            if (!rowMergeRangeMap.ContainsKey(rowIdx))
            {
                rowMergeRangeMap.Add(rowIdx, range);
            }

            // マージセル描画イベントを活性化
            CellPainting -= dgv_MergedCellPainting;
            CellPainting += dgv_MergedCellPainting;
        }
        #endregion

        #region OverLoads
        #region AddAutoMergeCol
        /// <summary>
        /// セルマージ範囲設定(オーバーロード)
        /// </summary>
        /// <param name="colIdx"></param>
        /// <param name="rowMergeUnit"></param>
        protected void AddAutoMergeCol(int colIdx, int rowMergeUnit)
        {
            AddMergeRange(-1, 1, colIdx, rowMergeUnit, true);
        }
        #endregion

        #region AddAutoMergeCol
        /// <summary>
        /// 
        /// </summary>
        /// <param name="colIdx"></param>
        public void AddAutoMergeCol(int colIdx)
        {
            AddAutoMergeCol(colIdx, 2);
        }
        #endregion

        #region AddMergeCol
        /// <summary>
        /// 
        /// </summary>
        /// <param name="colIdx"></param>
        /// <param name="rowMergeUnit"></param>
        public void AddMergeCol(int colIdx, int rowMergeUnit)
        {
            AddMergeRange(-1, 1, colIdx, rowMergeUnit, false);
        }
        #endregion
        #endregion

        ///// <summary>
        ///// 列ヘッダマージ範囲設定
        ///// </summary>
        ///// <param name="colIdxFrom"></param>
        ///// <param name="colIdxTo"></param>
        //public void AddAutoMergeColHeader(int colIdxFrom, int colIdxTo)
        //{
        //    // NOTICE ヘッダのマージは、できれば（一応可能な模様（カスタム描画で））必要な画面があれば実装する
        //}
        #endregion

        #region ClearMergeCol
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  habu　　    新規作成
        /// </history>
        public void ClearMergeCol()
        {
            colMergeRangeMap.Clear();
            rowMergeRangeMap.Clear();

            // マージ描画イベントを非活性化
            CellPainting -= dgv_MergedCellPainting;
        }
        #endregion

        #region セルマージ用イベント
        /// <summary>
        /// マージセル用イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  habu　　    新規作成
        /// </history>
        protected void dgv_MergedCellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // セルの下側の境界線を「境界線なし」に設定
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;

            // 1行目や列ヘッダ、行ヘッダの場合は何もしない
            if (e.RowIndex < 1 || e.ColumnIndex < 0) { return; }

            // 1行上と同じ値の場合
            if (IsBeMergedCell((DataGridView)sender, e.ColumnIndex, e.RowIndex))
            {
                // セルの上側の境界線を「境界線なし」に設定
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;

                e.PaintBackground(e.ClipBounds, true);
            }
            else
            {
                // セルの上側の境界線を既定の境界線に設定
                e.AdvancedBorderStyle.Top = ((DataGridView)sender).AdvancedCellBorderStyle.Top;

                e.PaintBackground(e.ClipBounds, true);
                e.PaintContent(e.ClipBounds);
            }

            e.Handled = true;
        }
        #endregion

        #region セルマージ判定用メソッド
        /// <summary>
        /// 被マージセル判定
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="col"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  habu　　    新規作成
        /// </history>
        protected bool IsBeMergedCell(DataGridView dgv, int col, int row)
        {
            MergeRange range = null;

            // マージ対象でない場合は、常に無効
            if (rowMergeRangeMap.ContainsKey(row))
            {
                range = rowMergeRangeMap[row];

                if (col % range.colMergeUnit == 0)
                {
                    return false;
                }
            }
            else if (colMergeRangeMap.ContainsKey(col))
            {
                range = colMergeRangeMap[col];

                // マージベースセルの場合は、対象外
                if (row % range.rowMergeUnit == 0)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            // 自動マージでない場合は、指定マージ範囲内で常にマージ
            if (!range.isAutoMerge)
            {
                return true;
            }
            // 自動マージの場合は、値のチェックを行い、同じ値であればマージ
            else
            {
                // マージベースセル位置算出
                int baseRowIdx = row / range.rowMergeUnit * range.rowMergeUnit;
                int baseColIdx = col / range.colMergeUnit * range.colMergeUnit;

                // マージベースセル
                DataGridViewCell cellMergeBase = dgv[baseColIdx, baseRowIdx];
                // 被マージセル
                DataGridViewCell cellBeMerged = dgv[col, row];

                // 両方ともnullの場合は同じ値とみなす
                if (cellBeMerged.Value == null && cellMergeBase.Value == null)
                {
                    return true;
                }
                // 片方のみnullの場合は異なる値とみなす
                else if (cellBeMerged.Value == null)
                {
                    return false;
                }
                else
                {
                    // カスタムクラスの場合、Equalsメソッドは適切に実装されている必要がある
                    if (cellBeMerged.Value.Equals(cellMergeBase.Value))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        #endregion

        #endregion

        private const int DEFAULT_MAX_LENGTH = 32767;

        #region ドメイン制御用メソッド

        #region SetControlDomain
        /// <summary>
        /// 定義済みドメインを設定
        /// </summary>
        /// <param name="colIdx"></param>
        /// <param name="domain"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  habu　　    新規作成
        /// </history>
        public void SetControlDomain(int colIdx, ZControlDomain domain)
        {
            // カラムごとのドメインを保持
            if (!ColumnControlDomain.ContainsKey(colIdx))
            {
                ColumnControlDomain.Add(colIdx, domain);
            }
            else
            {
                ColumnControlDomain[colIdx] = domain;
            }

            int maxLength = DEFAULT_MAX_LENGTH;
            // 追加パラメータを保持
            if (!ColumnLengthMap.ContainsKey(colIdx))
            {
                ColumnLengthMap.Add(colIdx, maxLength);
            }
            else
            {
                ColumnLengthMap[colIdx] = maxLength;
            }

            SetControlProperty(colIdx);
        }
        #endregion

        #region SetStdControlDomain
        /// <summary>
        /// 汎用ドメインを設定
        /// </summary>
        /// <param name="domain">One of ZG_STD_XXX</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/18  habu　　    新規作成
        /// </history>
        public void SetStdControlDomain(int colIdx, ZControlDomain domain)
        {
            // カラムごとのドメインを保持
            if (!ColumnControlDomain.ContainsKey(colIdx))
            {
                ColumnControlDomain.Add(colIdx, domain);
            }
            else
            {
                ColumnControlDomain[colIdx] = domain;
            }

            int maxLength = DEFAULT_MAX_LENGTH;
            // 追加パラメータを保持
            if (!ColumnLengthMap.ContainsKey(colIdx))
            {
                ColumnLengthMap.Add(colIdx, maxLength);
            }
            else
            {
                ColumnLengthMap[colIdx] = maxLength;
            }

            SetControlProperty(colIdx);
        }
        #endregion

        #region SetStdControlDomain
        /// <summary>
        /// 汎用ドメインを設定
        /// </summary>
        /// <param name="domain">One of ZG_STD_XXX</param>
        /// <param name="maxLength">Input length limit</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  habu　　    新規作成
        /// </history>
        public void SetStdControlDomain(int colIdx, ZControlDomain domain, int maxLength)
        {
            // カラムごとのドメインを保持
            if (!ColumnControlDomain.ContainsKey(colIdx))
            {
                ColumnControlDomain.Add(colIdx, domain);
            }
            else
            {
                ColumnControlDomain[colIdx] = domain;
            }

            // 追加パラメータを保持
            if (!ColumnLengthMap.ContainsKey(colIdx))
            {
                ColumnLengthMap.Add(colIdx, maxLength);
            }
            else
            {
                ColumnLengthMap[colIdx] = maxLength;
            }

            SetControlProperty(colIdx);
        }
        #endregion

        #region SetStdControlDomain
        /// <summary>
        /// 汎用ドメインを設定
        /// </summary>
        /// <param name="domain">One of ZG_STD_XXX</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/18  habu　　    新規作成
        /// </history>
        public void SetStdControlDomain(int colIdx, ZControlDomain domain, DataGridViewContentAlignment align)
        {
            // カラムごとのドメインを保持
            if (!ColumnControlDomain.ContainsKey(colIdx))
            {
                ColumnControlDomain.Add(colIdx, domain);
            }
            else
            {
                ColumnControlDomain[colIdx] = domain;
            }

            int maxLength = DEFAULT_MAX_LENGTH;
            // 追加パラメータを保持
            if (!ColumnLengthMap.ContainsKey(colIdx))
            {
                ColumnLengthMap.Add(colIdx, maxLength);
            }
            else
            {
                ColumnLengthMap[colIdx] = maxLength;
            }
            if (!ColumnAlignMap.ContainsKey(colIdx))
            {
                ColumnAlignMap.Add(colIdx, align);
            }
            else
            {
                ColumnAlignMap[colIdx] = align;
            }

            SetControlProperty(colIdx);
        }
        #endregion

        #region SetStdControlDomain
        /// <summary>
        /// 汎用ドメインを設定
        /// </summary>
        /// <param name="colIdx"></param>
        /// <param name="domain">One of ZG_STD_XXX</param>
        /// <param name="maxLength">Input length limit</param>
        /// <param name="align"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  habu　　    新規作成
        /// </history>
        public void SetStdControlDomain(int colIdx, ZControlDomain domain, int maxLength, DataGridViewContentAlignment align)
        {
            // カラムごとのドメインを保持
            if (!ColumnControlDomain.ContainsKey(colIdx))
            {
                ColumnControlDomain.Add(colIdx, domain);
            }
            else
            {
                ColumnControlDomain[colIdx] = domain;
            }

            // 追加パラメータを保持
            if (!ColumnLengthMap.ContainsKey(colIdx))
            {
                ColumnLengthMap.Add(colIdx, maxLength);
            }
            else
            {
                ColumnLengthMap[colIdx] = maxLength;
            }
            if (!ColumnAlignMap.ContainsKey(colIdx))
            {
                ColumnAlignMap.Add(colIdx, align);
            }
            else
            {
                ColumnAlignMap[colIdx] = align;
            }

            SetControlProperty(colIdx);
        }
        #endregion

        #region SetStdControlDomain
        /// <summary>
        /// 
        /// </summary>
        /// <param name="colIdx"></param>
        /// <param name="domain"></param>
        /// <param name="precisionLength"></param>
        /// <param name="scaleLength"></param>
        /// <param name="sign"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/15  habu　　    新規作成
        /// </history>
        public void SetStdControlDomain(int colIdx, ZControlDomain domain, int precisionLength, int scaleLength, InputValidateUtility.SignFlg sign)
        {
            int signCnt = sign == InputValidateUtility.SignFlg.Positive ? 0 : 1;
            int fpointCnt = scaleLength > 0 ? 1 : 0;

            int maxLength = precisionLength + fpointCnt + signCnt;

            // カラムごとのドメインを保持
            if (!ColumnControlDomain.ContainsKey(colIdx))
            {
                ColumnControlDomain.Add(colIdx, domain);
            }
            else
            {
                ColumnControlDomain[colIdx] = domain;
            }

            // 追加パラメータを保持
            if (!ColumnLengthMap.ContainsKey(colIdx))
            {
                ColumnLengthMap.Add(colIdx, maxLength);
            }
            else
            {
                ColumnLengthMap[colIdx] = maxLength;
            }

            SetControlProperty(colIdx);
        }
        #endregion

        #region SetStdControlDomain
        /// <summary>
        /// 
        /// </summary>
        /// <param name="colIdx"></param>
        /// <param name="domain"></param>
        /// <param name="precisionLength"></param>
        /// <param name="scaleLength"></param>
        /// <param name="sign"></param>
        /// <param name="align"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/15  habu　　    新規作成
        /// </history>
        public void SetStdControlDomain(int colIdx, ZControlDomain domain, int precisionLength, int scaleLength, InputValidateUtility.SignFlg sign, DataGridViewContentAlignment align)
        {
            int signCnt = sign == InputValidateUtility.SignFlg.Positive ? 0 : 1;
            int fpointCnt = scaleLength > 0 ? 1 : 0;

            int maxLength = precisionLength + fpointCnt + signCnt;

            // カラムごとのドメインを保持
            if (!ColumnControlDomain.ContainsKey(colIdx))
            {
                ColumnControlDomain.Add(colIdx, domain);
            }
            else
            {
                ColumnControlDomain[colIdx] = domain;
            }

            // 追加パラメータを保持
            if (!ColumnLengthMap.ContainsKey(colIdx))
            {
                ColumnLengthMap.Add(colIdx, maxLength);
            }
            else
            {
                ColumnLengthMap[colIdx] = maxLength;
            }
            if (!ColumnAlignMap.ContainsKey(colIdx))
            {
                ColumnAlignMap.Add(colIdx, align);
            }
            else
            {
                ColumnAlignMap[colIdx] = align;
            }

            SetControlProperty(colIdx);
        }
        #endregion

        #region SetControlProperty
        /// <summary>
        /// 
        /// </summary>
        /// <param name="colIdx"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  habu　　    新規作成
        /// </history>
        public void SetControlProperty(int colIdx)
        {
            // ドメインが未設定の場合は無効
            if (!ColumnControlDomain.ContainsKey(colIdx))
            {
                return;
            }

            // 指定列のドメインを取得
            ZControlDomain conDomain = ColumnControlDomain[colIdx];

            // NOTICE マルチ行の場合の対応は別途検討する（使用頻度は低いはず）

            DataGridViewEditingControlShowingEventHandler stdEvent;
            stdEvent = CreateStdEditorHandler(colIdx, conDomain);

            if (conDomain == ZControlDomain.NONE)
            {
                Columns[colIdx].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                // 登録済みのハンドラを一旦削除(2重登録の防止)
                // NOTICE ここで一旦削除するのは本当に必要か？ -> 削除しても不都合はないため、このままとする
                EditingControlShowing -= stdEvent;
                EditingControlShowing += stdEvent;
            }
            else if (conDomain == ZControlDomain.ZG_STD_NAME || conDomain == ZControlDomain.ZT_STD_NAME)
            {
                Columns[colIdx].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                EditingControlShowing -= stdEvent;
                EditingControlShowing += stdEvent;
            }
            else if (conDomain == ZControlDomain.ZG_STD_NAME_KANA || conDomain == ZControlDomain.ZT_STD_NAME_KANA)
            {
                Columns[colIdx].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                EditingControlShowing -= stdEvent;
                EditingControlShowing += stdEvent;
            }
            else if (conDomain == ZControlDomain.ZG_STD_NAME_KANA_HALF || conDomain == ZControlDomain.ZT_STD_NAME_KANA_HALF)
            {
                Columns[colIdx].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                EditingControlShowing -= stdEvent;
                EditingControlShowing += stdEvent;
            }
            else if (conDomain == ZControlDomain.ZG_STD_CD || conDomain == ZControlDomain.ZT_STD_CD)
            {
                Columns[colIdx].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                EditingControlShowing -= stdEvent;
                EditingControlShowing += stdEvent;
            }
            else if (conDomain == ZControlDomain.ZG_STD_NUM || conDomain == ZControlDomain.ZT_STD_NUM)
            {
                Columns[colIdx].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                EditingControlShowing -= stdEvent;
                EditingControlShowing += stdEvent;
            }
            else if (conDomain == ZControlDomain.ZG_TEL_NO || conDomain == ZControlDomain.ZT_TEL_NO)
            {
                Columns[colIdx].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                EditingControlShowing -= stdEvent;
                EditingControlShowing += stdEvent;
            }
            else if (conDomain == ZControlDomain.ZG_ZIP_CD || conDomain == ZControlDomain.ZT_ZIP_CD)
            {
                Columns[colIdx].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                EditingControlShowing -= stdEvent;
                EditingControlShowing += stdEvent;
            }

            // Alignが指定されている場合は設定
            if (ColumnAlignMap.ContainsKey(colIdx))
            {
                Columns[colIdx].DefaultCellStyle.Alignment = ColumnAlignMap[colIdx];
            }
        }
        #endregion

        #region CreateStdEditorHandler
        /// <summary>
        /// 
        /// </summary>
        /// <param name="colIdx"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  habu　　    新規作成
        /// 2014/12/18  habu　　    新規作成
        /// </history>
        protected DataGridViewEditingControlShowingEventHandler CreateStdEditorHandler(int colIdx, ZControlDomain domain)
        {
            #region 個別パラメータ宣言

            int maxLength = int.MaxValue;
            ImeMode imeMode = System.Windows.Forms.ImeMode.On;
            string filterFormat = string.Empty;

            #endregion

            DataGridViewEditingControlShowingEventHandler stdEvent;
            stdEvent = delegate(object sender, DataGridViewEditingControlShowingEventArgs e)
            {
                // カラムインデックスチェック
                DataGridView dgv = (DataGridView)sender;
                if (dgv.CurrentCell.OwningColumn.Index != colIdx)
                {
                    return;
                }

                if (e.Control is DataGridViewTextBoxEditingControl)
                {
                    (e.Control as DataGridViewTextBoxEditingControl).MaxLength = maxLength;
                    (e.Control as DataGridViewTextBoxEditingControl).ImeMode = imeMode;

                    // 20141218 habu Mod ひらがなカラムとフィルタ有のカラムが共存できないのを修正
                    // 登録済みのフィルターイベントをクリアする(複数のフィルターを設定して、正常に動作する様に)
                    // Clear KeyPressFilter of previous editing
                    ClearKeyPressFilter(e.Control);

                    if (!string.IsNullOrEmpty(filterFormat))
                    {
                        //// 登録済みのフィルターイベントをクリアする(複数のフィルターを設定して、正常に動作する様に)
                        //// Clear KeyPressFilter of previous editing
                        //ClearKeyPressFilter(e.Control);

                        // Create KeyPressFilter or Get from cache if already exits
                        KeyPressEventHandler keyPressFilter = PreserveKeyPressFilter(filterFormat);

                        e.Control.KeyPress += keyPressFilter;
                    }
                }
                else if (e.Control is DataGridViewComboBoxEditingControl)
                {
                    (e.Control as DataGridViewComboBoxEditingControl).MaxLength = maxLength;
                    (e.Control as DataGridViewComboBoxEditingControl).ImeMode = imeMode;

                    // NOTICE これは(DropDownList以外を)任意に指定できる必要があるか検討する（福岡浄化槽では多分不要）
                    (e.Control as DataGridViewComboBoxEditingControl).DropDownStyle = ComboBoxStyle.DropDownList;
                }
            };

            #region カラム毎、個別イベントパラメータ設定

            const char HALF_WHITE_SPACE = ' ';
            const char FULL_WHITE_SPACE = '　';

            if (domain == ZControlDomain.NONE)
            {
                // NONE
            }
            else if (domain == ZControlDomain.ZG_STD_NAME || domain == ZControlDomain.ZT_STD_NAME)
            {
                maxLength = ColumnLengthMap[colIdx];
                imeMode = ImeMode.Hiragana;
            }
            else if (domain == ZControlDomain.ZG_STD_NAME_KANA || domain == ZControlDomain.ZT_STD_NAME_KANA)
            {
                maxLength = ColumnLengthMap[colIdx];
                imeMode = ImeMode.Katakana;
                filterFormat = "ア" + FULL_WHITE_SPACE;
            }
            else if (domain == ZControlDomain.ZG_STD_NAME_KANA_HALF || domain == ZControlDomain.ZT_STD_NAME_KANA_HALF)
            {
                maxLength = ColumnLengthMap[colIdx];
                imeMode = ImeMode.KatakanaHalf;
                filterFormat = "ｱ" + HALF_WHITE_SPACE;
            }
            else if (domain == ZControlDomain.ZG_STD_CD || domain == ZControlDomain.ZT_STD_CD)
            {
                maxLength = ColumnLengthMap[colIdx];
                imeMode = ImeMode.Off;
                filterFormat = "Aa9";
            }
            else if (domain == ZControlDomain.ZG_STD_NUM || domain == ZControlDomain.ZT_STD_NUM)
            {
                maxLength = ColumnLengthMap[colIdx];
                imeMode = ImeMode.Off;
                // TODO +-の有無を加味する(入力フォーマット制限)
                filterFormat = "9#";
            }
            else if (domain == ZControlDomain.ZG_TEL_NO || domain == ZControlDomain.ZT_TEL_NO)
            {
                maxLength = 13;
                imeMode = ImeMode.Off;
                filterFormat = "9#";
            }
            else if (domain == ZControlDomain.ZG_ZIP_CD || domain == ZControlDomain.ZT_ZIP_CD)
            {
                maxLength = 8;
                imeMode = ImeMode.Off;
                filterFormat = "9#";
            }

            #endregion

            return stdEvent;
        }
        #endregion

        #region Editor Input Filter Handler

        #region PreserveKeyPressFilter
        /// <summary>
        /// Create input filter handler (get from cache if exists
        /// </summary>
        /// <remarks>
        /// preserves created handler for clearing handlers later
        /// </remarks>
        /// <param name="format"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  habu　　    新規作成
        /// </history>
        protected KeyPressEventHandler PreserveKeyPressFilter(string format)
        {
            if (KeyPressFilterCache.ContainsKey(format))
            {
                return KeyPressFilterCache[format];
            }
            else
            {
                KeyPressFilterCache.Add(format, InputValidateUtility.GetKeyPressFilter(format));
                return KeyPressFilterCache[format];
            }
        }
        #endregion

        #region ClearKeyPressFilter
        /// <summary>
        /// Clear all previous event handlers
        /// </summary>
        /// <param name="con"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  habu　　    新規作成
        /// </history>
        protected void ClearKeyPressFilter(System.Windows.Forms.Control con)
        {
            // Clear all previous event handlers
            foreach (KeyPressEventHandler ev in KeyPressFilterCache.Values)
            {
                con.KeyPress -= ev;
            }
        }
        #endregion

        #endregion

        #region DoValidate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="autoFocus"></param>
        /// <param name="isNessesary"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  habu　　    新規作成
        /// </history>
        public bool DoValidate(int rowIdx, int colIdx, bool isNesessary, string controlDispName, out string errorMsg, bool autoFocus)
        {
            bool validateOk = true;
            errorMsg = string.Empty;

            // 指定列のドメインを取得
            ZControlDomain controlDomain = ColumnControlDomain[colIdx];

            string checkValue = string.Empty;

            if (this[rowIdx, colIdx].Value == null)
            {
                checkValue = string.Empty;
            }
            else if (this[rowIdx, colIdx].Value == DBNull.Value)
            {
                checkValue = string.Empty;
            }
            // TODO supports number types , datetime type
            // NOTICE currentry supports only string values
            else if (!(this[rowIdx, colIdx].Value is string))
            {
                return true;
            }
            else
            {
                checkValue = (string)this[rowIdx, colIdx].Value;
            }

            // 必須チェック
            if (isNesessary && string.IsNullOrEmpty(checkValue))
            {
                validateOk = false;
                errorMsg = string.Format("必須項目：{0}が入力されていません。", controlDispName);
            }

            #region Contents length validation

            if (ColumnLengthMap.ContainsKey(colIdx))
            {
                int length = ColumnLengthMap[colIdx];

                // NOTICE 現状はZG_STD_CDの1種類だけなのでこれでよいが、今後追加された場合は、コードかどうかの判定は別途行う
                if (controlDomain == ZControlDomain.ZG_STD_CD || controlDomain == ZControlDomain.ZT_STD_CD)
                {
                    // コードは丁度の桁数でなければならない
                    if (!string.IsNullOrEmpty(checkValue) && checkValue.Length != length)
                    {
                        validateOk = false;
                        errorMsg = string.Format("{0}は{1}桁で入力して下さい。", controlDispName, length);
                    }
                }
                else
                {
                    if (checkValue.Length > length)
                    {
                        validateOk = false;
                        errorMsg = string.Format("{0}は{1}桁以下で入力して下さい。", controlDispName, length);
                    }
                }
            }

            #endregion

            #region Content format validation

            if (controlDomain == ZControlDomain.ZG_STD_NAME)
            {

            }
            else if (controlDomain == ZControlDomain.ZG_STD_CD)
            {
                validateOk = InputValidateUtility.ValidateString(checkValue, "Aa9");
                if (!validateOk) { errorMsg = controlDispName + "は半角数字で入力して下さい。"; }
            }
            else if (controlDomain == ZControlDomain.ZG_STD_NUM)
            {
                validateOk = InputValidateUtility.ValidateString(checkValue, "9#");
                if (!validateOk) { errorMsg = controlDispName + "は半角数字で入力して下さい。"; }
            }

            #endregion

            // 該当コントロールにフォーカス
            if (!validateOk && autoFocus)
            {
                Focus();

                this[rowIdx, colIdx].Selected = true;
            }

            return validateOk;
        }
        #endregion

        #endregion

        #region ラジオボタン制御
        /// <summary>
        /// 
        /// </summary>
        /// <param name="radioColIdices"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/14  habu　　    新規作成
        /// </history>
        public void SetRadioGroup(IEnumerable<int> radioColIdices)
        {
            List<int> colList = new List<int>(radioColIdices);

            // 変更前イベント設定
            this.CellValidating += delegate(object sender, DataGridViewCellValidatingEventArgs e)
            {
                // 範囲外の場合は処理終了
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                {
                    return;
                }

                // チェックボックスでない場合は処理終了
                if (!(this.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn))
                {
                    return;
                }

                // 対象外カラムの場合はスキップ
                if (!colList.Contains(e.ColumnIndex))
                {
                    return;
                }

                DataGridViewRow gridRow = this.Rows[e.RowIndex];

                bool oldValue = (bool)gridRow.Cells[e.ColumnIndex].Value;

                bool newValue = (bool)e.FormattedValue;

                // true -> falseになる場合はキャンセル
                if (oldValue && !newValue)
                {
                    e.Cancel = true;
                    // 編集前の状態に戻す
                    (sender as DataGridView).RefreshEdit();
                }
            };

            // 変更後イベント設定
            this.CellValueChanged += delegate(object sender, DataGridViewCellEventArgs e)
            {
                // 範囲外の場合は処理終了
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                {
                    return;
                }

                // チェックボックスでない場合は処理終了
                if (!(this.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn))
                {
                    return;
                }

                // 対象外カラムの場合はスキップ
                if (!colList.Contains(e.ColumnIndex))
                {
                    return;
                }

                DataGridViewRow gridRow = this.Rows[e.RowIndex];

                bool newValue = (bool)gridRow.Cells[e.ColumnIndex].Value;

                //// falseになった場合は処理終了
                //if (!newValue)
                //{
                //    return;
                //}
                // falseになった場合は自分以外をtrueにする
                if (!newValue)
                {
                    foreach (int colIdx in radioColIdices)
                    {
                        // 自分自身の場合はスキップ
                        if (colIdx == e.ColumnIndex)
                        {
                            continue;
                        }

                        bool otherColValue = (bool)gridRow.Cells[colIdx].Value;

                        // falseだった場合はtrueに反転
                        if (!otherColValue)
                        {
                            gridRow.Cells[colIdx].Value = true;
                        }
                    }
                }
                else
                {
                    foreach (int colIdx in radioColIdices)
                    {
                        // 自分自身の場合はスキップ
                        if (colIdx == e.ColumnIndex)
                        {
                            continue;
                        }

                        bool otherColValue = (bool)gridRow.Cells[colIdx].Value;

                        // trueだった場合はfalseに反転
                        if (otherColValue)
                        {
                            gridRow.Cells[colIdx].Value = false;
                        }
                    }
                }
            };
        }
        #endregion
    }
}
