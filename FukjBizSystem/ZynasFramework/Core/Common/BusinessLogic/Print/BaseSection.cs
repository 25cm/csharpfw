using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Zynas.Framework.Core.Common.BusinessLogic.Print
{
    public class BaseSection
    {
        // NOTICE ページ行数などは、セル数でなく、実寸でのカウントが望ましい
        // NOTICE レイアウトからのフォーマット自動生成は別途（当面は既存フォーマットのセル単位出力）
        // NOTICE マッピング設定部は独立した処理とする（レイアウト情報のファイルからの読込も考慮して）
        // NOTICE 列単位での改ページは後回しでよい
        // NOTICE 実寸での扱いは後回しでよい
        // NOTICE TableAdapter, メソッド名をDataSouceとして指定するバリエーションも用意する（いづれ）
        // NOTICE タイトル出力（シート内で一回のみ）-> 今回は固定出力を行うため、不要

        /// <summary>
        /// Excel操作親クラス
        /// </summary>
        public PrintHelper Helper;

        #region セクション設定値変数

        // NOTICE 変数分類してregionで分ける => 今後対応する

        /// <summary>
        /// 1レコード分の出力行数
        /// </summary>
        public int unitRowCnt = 1;
        /// <summary>
        /// セクション内の最大行数
        /// </summary>
        public int maxRowCnt = 0;
        /// <summary>
        /// セクションの最大の高さ
        /// </summary>
        public int maxRowHeight = 0;

        /// <summary>
        /// ページ内の開始位置
        /// </summary>
        public int pageRowOrigin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int pageColOrigin { get; set; }

        /// <summary>
        /// セクションのシート内行開始位置
        /// </summary>
        public int sectionRowOrigin { get; set; }
        /// <summary>
        /// セクションのシート内列開始位置
        /// </summary>
        public int sectionColOrigin { get; set; }

        /// <summary>
        /// セクションの行数(複数行の場合、Excel上の純行数)
        /// </summary>
        public int sectionRowCnt { get; set; }

        /// <summary>
        /// セクションの列数(複数列の場合、Excel上の純列数)
        /// </summary>
        public int sectionColCnt;

        // NOTICE 同じ値を複数の場所に出力する場合も一応考慮する -> 今後対応する（現状では、該当なし）

        private Dictionary<string, DataMapping> mappingMap;

        private List<FixedData> fixedList;

        private List<SequenceData> noList;

        private List<string> pageBreakKeys = new List<string>();

        private List<int> mergeKeyCols = new List<int>();

        #endregion

        #region 内部状態変数

        // NOTICE 変数分類する => 今後対応する

        /// <summary>
        /// 出力済み行数(マルチ行単位でなく、Excel行単位)
        /// </summary>
        public int outRowCnt { get; set; }

        #endregion

        #region 内部クラス

        // NOTICE 単票ならこれだけでよいが、、 => 今回の使用範囲では不要
        /// <summary>
        /// マッピング情報保持用内部クラス
        /// </summary>
        public class DataMapping
        {
            public int rowOffset;
            public int colOffset;
            public string propertyName;
        }

        /// <summary>
        /// 固定値出力用
        /// </summary>
        public class FixedData
        {
            public int rowOffset;
            public int colOffset;
            public object value;
        }

        public class SequenceData
        {
            public int rowOffset;
            public int colOffset;
            public int origin;
        }

        // NOTICE セル出力用、オブジェクト出力用出力先指定クラス（Mappingで保持するのは、こちらの方が良い） => 今回の使用範囲では不要
        //public class OutputTarget
        //{

        //}

        #endregion

        #region Events

        public delegate string OutputTitleHandler(ExcelBind excel, DataRow row, int idxRow);
        public event OutputTitleHandler OutputTitle;

        public delegate void OutputRowHandler(ExcelBind excel, DataRow row, int idxRow);
        public event OutputRowHandler OutputRow;

        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public BaseSection()
            : this(1)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitRowCnt"></param>
        public BaseSection(int unitRowCnt)
        {
            // NOTICE コンストラクタ引数を渡す事 -> 今回の使用範囲では、不要

            this.unitRowCnt = unitRowCnt;
            // NOTICE 仮の値を設定 -> 今回の使用範囲では、これでよい
            maxRowCnt = 100;
            maxRowHeight = 10000;

            mappingMap = new Dictionary<string, DataMapping>();
            fixedList = new List<FixedData>();
            noList = new List<SequenceData>();

            pageBreakKeys = new List<string>();
            mergeKeyCols = new List<int>();
        }
        #endregion

        /// <summary>
        /// 出力日付など、ページ内で共通の項目はこちらで設定する
        /// </summary>
        /// <param name="value"></param>
        /// <param name="rowOffset"></param>
        /// <param name="colOffset"></param>
        public void SetFixData(object value, int rowOffset, int colOffset)
        {
            FixedData data = new FixedData();

            data.value = value;
            data.rowOffset = rowOffset;
            data.colOffset = colOffset;

            fixedList.Add(data);
        }

        #region SetNoCol
        /// <summary>
        /// 
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="rowOffset"></param>
        /// <param name="colOffset"></param>
        public void SetNoCol(int origin, int rowOffset, int colOffset)
        {
            SequenceData data = new SequenceData();

            data.origin = origin;
            data.rowOffset = rowOffset;
            data.colOffset = colOffset;

            noList.Add(data);
        }
        #endregion

        /// <summary>
        /// データの出力先情報を指定
        /// </summary>
        /// <param name="col"></param>
        /// <param name="rowOffset"></param>
        /// <param name="colOffset"></param>
        public void SetMapping(DataColumn col, int rowOffset, int colOffset)
        {
            SetMapping(col.ColumnName, rowOffset, colOffset);
        }

        /// <summary>
        /// データの出力先情報を指定
        /// </summary>
        /// <param name="propName"></param>
        /// <param name="rowOffset"></param>
        /// <param name="colOffset"></param>
        public void SetMapping(string propName, int rowOffset, int colOffset)
        {
            // NOTICE UnitRowはここで自動設定しても良い（いづれ） => 今回の使用範囲では、不要

            DataMapping map = new DataMapping();
            map.propertyName = propName;
            map.rowOffset = rowOffset;
            map.colOffset = colOffset;

            mappingMap.Add(propName, map);
        }

        /// <summary>
        /// データの出力先情報を指定
        /// </summary>
        /// <param name="propName"></param>
        /// <param name="colOffset"></param>
        public void SetMapping(string propName, int colOffset)
        {
            SetMapping(propName, 0, colOffset);
        }

        //public void SetMappingAnchor(string colName, string anchorStr)
        //{
        //    // NOTICE セル中の置換文字列を出力位置とする -> 将来的には、置換文字列での出力に対応する

        //    // NOTICE セルを検索して、位置を特定する

        //    // NOTICE 複数ある場合は、複数分を出力先とする
        //}

        //public void SetMappingCellName(string colName, string cellName)
        //{
        //    // NOTICE セル名を出力位置とする -> 将来的には、セル名での出力に対応する

        //    // NOTICE セルを検索して、位置を特定する
        //}

        // NOTICE 出力後の実寸を取得(自動改行などでサイズが変わる場合があるため、セル出力後に行う事) -> 実寸での出力を行う場合には必要
        // NOTICE セクション内の実寸を累積
        // NOTICE 行数又は実寸のいずれかが上限を超えた場合は改ページを行う

        /// <summary>
        /// セクションのページ内領域を指定
        /// </summary>
        /// <param name="rowOrigin"></param>
        /// <param name="colOrigin"></param>
        /// <param name="rowCnt"></param>
        /// <param name="colCnt"></param>
        public void SetPageArea(int rowOrigin, int colOrigin, int rowCnt, int colCnt)
        {
            sectionRowOrigin = rowOrigin;
            sectionColOrigin = colOrigin;

            sectionRowCnt = rowCnt;
            sectionColCnt = colCnt;
        }

        /// <summary>
        /// セクションのページ内領域を指定
        /// </summary>
        /// <param name="rowOrigin"></param>
        /// <param name="rowCnt"></param>
        public void SetPageArea(int rowOrigin, int rowCnt)
        {
            SetPageArea(rowOrigin, 0, rowCnt, 0);
        }

        ///// <summary>
        ///// mm単位でのセクションの高さを設定
        ///// </summary>
        //public void SetSectionHeightmm(double mmHeight)
        //{
        //    // NOTICE 実寸での出力を行う場合は実装する
        //}

        //public void SetRowHeightmm(double mmHeight, int idxRow)
        //{
        //    // NOTICE 実寸での出力を行う場合は実装する
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="mmLength">mm単位での長さ</param>
        ///// <returns>pt単位での長さ</returns>
        //private double mmToPt(double mmLength)
        //{
        //    // NOTICE 実寸での出力を行う場合は実装する

        //    return 0;
        //}

        /// <summary>
        /// データを出力
        /// </summary>
        /// <param name="row"></param>
        /// <param name="currentSectionOrigin"></param>
        /// <param name="idxDataInPage">ページ内インデックス</param>
        public void OutputData(DataRow row, int idxData, int currentSectionOrigin, int idxDataInPage)
        {
            // 行出力位置算出
            int idxRow = currentSectionOrigin + (idxDataInPage * unitRowCnt);

            // 各列ごとのデータ出力実行
            foreach (DataMapping map in mappingMap.Values)
            {
                try
                {
                    if (row.Table == null || row.Table.Columns.Contains(map.propertyName))
                    {
                        object value = row[map.propertyName];

                        // NOTICE ブロック出力も検討する => 出力件数が多い場合は、処理時間の面からブロック出力が可能なことが望ましい
                        // セル出力実行
                        Helper.excel.CellOutput(idxRow + map.rowOffset, pageColOrigin + sectionColOrigin + map.colOffset, value);
                    }
                }
                catch
                {
                    // 対象列がない場合は無効として、処理継続
                }
            }

            // 固定出力実行
            foreach (FixedData data in fixedList)
            {
                Helper.excel.CellOutput(idxRow + data.rowOffset, data.colOffset, data.value);
            }

            // No出力実行
            foreach (SequenceData data in noList)
            {
                Helper.excel.CellOutput(idxRow + data.rowOffset, data.colOffset, data.origin + idxData);
            }

            // カスタム出力実行
            if (OutputRow != null)
            {
                OutputRow(Helper.excel, row, idxRow);
            }

            // 1レコード複数行の場合も、後で対応する
            outRowCnt += unitRowCnt;
        }

        /// <summary>
        /// 改ページ設定
        /// </summary>
        /// <param name="rowIdx"></param>
        public void SetPageBreak(int rowIdx)
        {
            // NOTICE 複数行の場合に正常に動作するか？ => 将来的には、複数行明細レコードに対応する(今回は該当なし)
            // 複数行を考慮する
            SetPageBreakBare(pageRowOrigin + sectionRowOrigin + rowIdx + (unitRowCnt - 1), false);
        }

        /// <summary>
        /// 改ページ設定
        /// </summary>
        /// <param name="rowIdx"></param>
        /// <param name="splitMultiRow"></param>
        public void SetPageBreakBare(int rowIdx, bool splitMultiRow)
        {
            int breakRowIdx = 0;

            if ((rowIdx + 1) % unitRowCnt == 0)
            {
                breakRowIdx = rowIdx;
                // 普通に改ページ
                Helper.excel.SetPageRowBreak(breakRowIdx);
            }
            else
            {
                if (!splitMultiRow)
                {
                    breakRowIdx = rowIdx;
                    // 普通に改ページ
                    Helper.excel.SetPageRowBreak(breakRowIdx);
                }
                else
                {
                    breakRowIdx = (rowIdx + 1) / unitRowCnt * unitRowCnt - 1;
                    // マルチ行単位での改ページ
                    Helper.excel.SetPageRowBreak(breakRowIdx);
                }
            }
        }

        // NOTICE セクション種別毎の専用のメソッドは、専用にクラスに分ける(今後の課題、現状では全てBaseSectionの機能とする)

        /// <summary>
        /// 値が同じ場合にマージするカラムを設定
        /// </summary>
        /// <param name="colIdx"></param>
        public void SetMergeKeyCol(int colIdx)
        {
            mergeKeyCols.Add(colIdx);
        }

        public bool IsPageBreak()
        {
            // 出力行数がページ内上限に達した場合
            if (outRowCnt > 0 && outRowCnt % sectionRowCnt == 0)
            {
                return true;
            }
            else
            {
                // キー項目が切り替わった場合
                // NOTICE キー項目判定処理 -> キー切換えによる、ページ、シート切替を行う場合は、対応が必要

                return false;
            }
        }

        //public bool IsMaxRowHeightOver()
        //{
        //    // NOTICE -> 実寸での出力を行う場合は実装する
        //    return false;
        //}

        //public void Reset()
        //{
        //    // NOTICE 内部状態のリセット（変数の再初期化） => 現状では複数回出力を行わないため、不要
        //}
    }
}
