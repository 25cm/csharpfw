using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Zynas.Framework.Core.Common.DataAccess;
using Zynas.Framework.Utility;

namespace Zynas.Control.Common
{
    /// <summary>
    /// 
    /// </summary>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25  habu　　    新規作成
    /// </history>
    public class DataBindingHelper
    {
        // NOTICE Initial implementation supports only DataTable as data source
        // NOTICE In future project, plain object(POCO) may be supported

        // NOTICE 現状のZynasFrameworkの挙動だと、毎回更新用のDataTableを新たに生成するので、
        // NOTICE .Net標準のBindingSourceだと、かみ合わない。ので自前でDataBindingを作成

        // NOTICE (マスタなど)コード・名称バインド用のクラスも用意する(別途クラスとして)(今後)

        // NOITCE FillToDataTable時に、明細行数が変更になる場合も考慮する（現在の使用箇所ではないが、、、） -> 今回の使用画面では該当しなかったので見送り

        #region Constants

        /// <summary>
        /// 
        /// </summary>
        private static readonly string PROP_TEXT = "Text";

        /// <summary>
        /// 
        /// </summary>
        private static readonly string DEFAULT_FLG_ON = "1";

        /// <summary>
        /// 
        /// </summary>
        private static readonly string DEFAULT_FLG_OFF = "0";

        /// <summary>
        /// 
        /// </summary>
        private static readonly string MULTI_CD_SEPARATOR = ":";

        #endregion

        #region Fields

        /// <summary>
        /// 
        /// </summary>
        protected List<DataBind> bindingMap;

        /// <summary>
        /// 
        /// </summary>
        protected Dictionary<string, string> ColumnMapping;

        #endregion

        #region Binding Definition Unit Class(Inner)

        protected abstract class DataBind
        {

        }

        protected class ConstDataBind : DataBind
        {
            public object constValue;

            public string srcPropertyName;
            public Type srcPropertyType;
        }

        protected class ControlDataBind : DataBind
        {
            public System.Windows.Forms.Control destControl;
            public string destPropertyName;

            public string srcPropertyName;
            public Type srcPropertyType;
        }

        protected class ComboBoxDataBind : DataBind
        {
            public ComboBox destControl;

            public string srcPropertyName;
            public Type srcPropertyType;
        }

        protected class MultiCdComboBoxDataBind : DataBind
        {
            public ComboBox destControl;

            public IEnumerable<string> srcPropertyName;
            public IEnumerable<Type> srcPropertyType;
        }

        protected class CheckBoxDataBind : DataBind
        {
            public CheckBox destControl;
            public CheckBoxMapping map;

            public string srcPropertyName;
            public Type srcPropertyType;
        }

        protected class CheckBoxMapping
        {
            public object trueValue;
            public object falseValue;
        }

        protected class RadioGroupDataBind : DataBind
        {
            public RadioButtonMapping groupMap;

            public string srcPropertyName;
            public Type srcPropertyType;
        }

        protected class RadioButtonMapping
        {
            public Dictionary<RadioButton, object> radioGroupMap;

            public RadioButtonMapping()
            {
                radioGroupMap = new Dictionary<RadioButton, object>();
            }

            public void AddMapping(RadioButton radio, object value)
            {
                radioGroupMap.Add(radio, value);
            }
        }

        protected class DataGridViewDataBind : DataBind
        {
            public DataGridView destControl;
            public int destColIdx;

            public string srcPropertyName;
            public Type srcPropertyType;
        }

        protected class SplitDateDataBind : DataBind
        {
            public TextBox destControlYear;
            public TextBox destControlMonth;
            public TextBox destControlDay;

            public string srcPropertyName;
            public Type srcPropertyType;
        }

        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public DataBindingHelper()
        {
            bindingMap = new List<DataBind>();

            ColumnMapping = new Dictionary<string, string>();
        }
        #endregion

        #region Initialize methods

        #region AddControlBind methods

        #region AddControlBind(Const)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="sourceColumn"></param>
        public void AddControlBind(string value, DataColumn sourceColumn)
        {
            ConstDataBind bind = new ConstDataBind();
            bind.constValue = value;

            bind.srcPropertyName = sourceColumn.ColumnName;
            bind.srcPropertyType = sourceColumn.DataType;

            bindingMap.Add(bind);
        }
        #endregion

        #region AddControlBind(TextBox)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="sourceColumn"></param>
        public void AddControlBind(TextBox control, DataColumn sourceColumn)
        {
            ControlDataBind bind = new ControlDataBind();
            bind.destControl = control;
            bind.destPropertyName = PROP_TEXT;

            bind.srcPropertyName = sourceColumn.ColumnName;
            bind.srcPropertyType = sourceColumn.DataType;

            bindingMap.Add(bind);
        }
        #endregion

        #region AddControlBind(ComboBox)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="sourceColumn"></param>
        public void AddControlBind(ComboBox control, DataColumn sourceColumn)
        {
            ComboBoxDataBind bind = new ComboBoxDataBind();
            bind.destControl = control;

            bind.srcPropertyName = sourceColumn.ColumnName;
            bind.srcPropertyType = sourceColumn.DataType;

            bindingMap.Add(bind);
        }
        #endregion

        #region AddControlBind(ComboBox)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="sourceColumn"></param>
        public void AddControlBind(ComboBox control, IEnumerable<DataColumn> sourceColumn)
        {
            MultiCdComboBoxDataBind bind = new MultiCdComboBoxDataBind();
            bind.destControl = control;

            string[] colNames = new string[sourceColumn.Count()];
            Type[] colTypes = new Type[sourceColumn.Count()];

            for (int i = 0; i < sourceColumn.Count(); i++)
            {
                colNames[i] = sourceColumn.ElementAt(i).ColumnName;
                colTypes[i] = sourceColumn.ElementAt(i).DataType;
            }

            bind.srcPropertyName = colNames;
            bind.srcPropertyType = colTypes;

            bindingMap.Add(bind);
        }
        #endregion

        #region AddControlBind(CheckBox)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="trueValue"></param>
        /// <param name="falseValue"></param>
        /// <param name="sourceColumn"></param>
        public void AddControlBind(CheckBox control, object trueValue, object falseValue, DataColumn sourceColumn)
        {
            CheckBoxMapping map = new CheckBoxMapping();
            map.trueValue = trueValue;
            map.falseValue = falseValue;

            AddControlBind(control, map, sourceColumn);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="sourceColumn"></param>
        public void AddControlBind(CheckBox control, DataColumn sourceColumn)
        {
            AddControlBind(control, DEFAULT_FLG_ON, DEFAULT_FLG_OFF, sourceColumn);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="group"></param>
        /// <param name="sourceColumn"></param>
        protected void AddControlBind(CheckBox control, CheckBoxMapping group, DataColumn sourceColumn)
        {
            CheckBoxDataBind bind = new CheckBoxDataBind();
            bind.destControl = control;
            bind.map = group;

            bind.srcPropertyName = sourceColumn.ColumnName;
            bind.srcPropertyType = sourceColumn.DataType;

            bindingMap.Add(bind);
        }
        #endregion

        #region AddControlBind(RadioButtons)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="radios"></param>
        /// <param name="values"></param>
        /// <param name="sourceColumn"></param>
        public void AddControlBind(IEnumerable<RadioButton> radios, IEnumerable<object> values, DataColumn sourceColumn)
        {
            RadioButtonMapping map = new RadioButtonMapping();

            for (int i = 0; i < radios.Count(); i++)
            {
                map.radioGroupMap.Add(radios.ElementAt(i), values.ElementAt(i));
            }

            AddControlBind(map, sourceColumn);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="group"></param>
        /// <param name="sourceColumn"></param>
        protected void AddControlBind(RadioButtonMapping group, DataColumn sourceColumn)
        {
            RadioGroupDataBind bind = new RadioGroupDataBind();
            bind.groupMap = group;

            bind.srcPropertyName = sourceColumn.ColumnName;
            bind.srcPropertyType = sourceColumn.DataType;

            bindingMap.Add(bind);
        }
        #endregion

        #region AddControlBind(DataGridView)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="colIdx"></param>
        /// <param name="sourceColumn"></param>
        public void AddControlBind(DataGridView control, int colIdx, DataColumn sourceColumn)
        {
            DataGridViewDataBind bind = new DataGridViewDataBind();
            bind.destControl = control;
            bind.destColIdx = colIdx;

            bind.srcPropertyName = sourceColumn.ColumnName;
            bind.srcPropertyType = sourceColumn.DataType;

            bindingMap.Add(bind);
        }
        #endregion

        #region other specific bind

        #region AddControlBindDate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="yearControl"></param>
        /// <param name="monthControl"></param>
        /// <param name="dayControl"></param>
        /// <param name="sourceColumn"></param>
        public void AddControlBindDate(TextBox yearControl, TextBox monthControl, TextBox dayControl, DataColumn sourceColumn)
        {
            SplitDateDataBind bind = new SplitDateDataBind();
            bind.destControlYear = yearControl;
            bind.destControlMonth = monthControl;
            bind.destControlDay = dayControl;
            
            bind.srcPropertyName = sourceColumn.ColumnName;
            bind.srcPropertyType = sourceColumn.DataType;

            bindingMap.Add(bind);
        }
        #endregion

        #endregion

        #endregion

        #region CopyDataTable
        /// <summary>
        /// 
        /// </summary>
        /// <param name="srcTable"></param>
        /// <param name="destTable"></param>
        public void CopyDataTable(DataTable destTable, DataTable srcTable, IEnumerable<string> keyColList)
        {
            // Clear before fill 
            destTable.Rows.Clear();

            // srcTableのデータの内、destTableに存在するものをコピーする
            foreach (DataRow srcRow in srcTable.Rows)
            {
                // キー重複チェック
                bool hasDuplicateKey = false;
                DataRow newDestRow;

                // キー列リストが渡された場合は、キー重複チェック
                if (keyColList != null && keyColList.Count() > 0)
                {
                    // キー重複チェック
                    QueryBuilder query = new QueryBuilder();
                    for (int i = 0; i < keyColList.Count(); i++)
                    {
                        query.AddEqualCond(keyColList.ElementAt(i), srcRow[keyColList.ElementAt(i)]);
                    }

                    DataRow[] destRows = destTable.Select(query.WhereStrPlain);

                    hasDuplicateKey = (destRows.Length > 0);

                    if (!hasDuplicateKey)
                    {
                        newDestRow = destTable.NewRow();
                    }
                    else
                    {
                        // キー重複時は上書きとする(後勝ち)
                        newDestRow = destRows[0];
                    }
                }
                else
                {
                    newDestRow = destTable.NewRow();
                }

                // 各列の内容をコピー
                foreach (DataColumn destCol in destTable.Columns)
                {
                    string srcColNm = string.Empty;
                    if (!ColumnMapping.ContainsKey(destCol.ColumnName))
                    {
                        srcColNm = destCol.ColumnName;
                    }
                    else
                    {
                        srcColNm = ColumnMapping[destCol.ColumnName];
                    }

                    // コピー元に存在しない列はスキップ
                    if (!srcTable.Columns.Contains(srcColNm))
                    {
                        continue;
                    }

                    newDestRow[destCol] = srcRow[srcColNm];
                }

                if (!hasDuplicateKey)
                {
                    destTable.Rows.Add(newDestRow);
                }

                // DataRowStateをコピー
                if (srcRow.RowState == DataRowState.Added)
                {
                    newDestRow.AcceptChanges();
                    newDestRow.SetAdded();
                }
                else if (srcRow.RowState == DataRowState.Modified)
                {
                    newDestRow.AcceptChanges();
                    newDestRow.SetModified();
                }
                else if (srcRow.RowState == DataRowState.Unchanged)
                {
                    newDestRow.AcceptChanges();
                }
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="srcTable"></param>
        /// <param name="destTable"></param>
        public void CopyDataTable(DataTable destTable, DataTable srcTable, IEnumerable<DataColumn> keyColList)
        {
            List<string> newKeyColList = new List<string>();
            foreach (DataColumn col in keyColList)
            {
                newKeyColList.Add(col.ColumnName);
            }

            CopyDataTable(destTable, srcTable, newKeyColList);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="srcTable"></param>
        /// <param name="destTable"></param>
        public void CopyDataTable(DataTable destTable, DataTable srcTable)
        {
            CopyDataTable(destTable, srcTable, new List<string>());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="toColName"></param>
        /// <param name="fromColName"></param>
        public void AddColumnMapping(string toColName, string fromColName)
        {
            ColumnMapping.Add(toColName, fromColName);
        }

        #endregion

        #region CheckDataEdited
        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentTable"></param>
        /// <param name="initialTable"></param>
        /// <param name="checkColList"></param>
        /// <returns>return true if any column is changed, false if none of column is changed</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/09  habu　　    新規作成
        /// </history>
        public static bool CheckDataIsEdited(DataRow currentRow, DataRow initialRow, IEnumerable<DataColumn> checkColList)
        {
            foreach (DataColumn col in checkColList)
            {
                if (!currentRow[col.ColumnName].Equals(initialRow[col.ColumnName]))
                {
                    return true;
                }
            }

            // all of column is not changed
            return false;
        }
        #endregion

        #region Data control methods

        //#region Set DataSource
        ///// <summary>
        ///// Set DataSouce To Binding Helper
        ///// </summary>
        ///// <param name="source"></param>
        //public void SetDataSouce(DataTable source)
        //{
        //    dataSource = source;
        //}
        //#endregion

        #region Source -> Control

        // NOTICE オプショナルで、書式フォーマットをサポートするか？（カンマ編集の数値など）-> 今後の課題
        // NOTICE オプショナルで、カスタムのデフォルト値をサポートするか？-> 今後の課題

        #region FillToControl
        /// <summary>
        /// 
        /// </summary>
        public void FillToControl(DataTable sourceTable)
        {
            if (sourceTable is DataTable)
            {
                DataTable source = sourceTable as DataTable;

                SetRecordCnt(source.Rows.Count);

                int rowIdx = 0;
                foreach (DataRow row in source.Rows)
                {
                    FillToControl(row, rowIdx);

                    rowIdx++;
                }
            }
            // NOTICE Accepts POCO, List of POCO
        }
        #endregion

        #region FillToControl
        /// <summary>
        /// ControlにDataRowのデータを設定する
        /// </summary>
        /// <param name="row"></param>
        /// <param name="rowIdx"></param>
        public void FillToControl(DataRow row, int rowIdx)
        {
            foreach (DataBind tbind in bindingMap)
            {
                if (tbind is ControlDataBind)
                {
                    ControlDataBind bind = (tbind as ControlDataBind);

                    if (bind.destPropertyName == PROP_TEXT)
                    {
                        // 全てスペースの場合は空文字とする(コード類を想定)
                        string val = row[bind.srcPropertyName].ToString();
                        if (val.Trim() == string.Empty)
                        {
                            val = val.Trim();
                        }
                        // NOTICE 特定のDomainの場合はTrimする(電話番号などの場合) -> 各機能側で対応されるので、今回は見送り

                        bind.destControl.Text = val;
                        //bind.destControl.Text = row[bind.srcPropertyName].ToString();
                    }
                    // NOTICE 今回は、テキストボックスのみの対応とする
                    //else
                    //{
                    //    SetObjectValue(bind.destControl, bind.destPropertyName, row[bind.srcPropertyName]);
                    //}
                }
                else if (tbind is ComboBoxDataBind)
                {
                    ComboBoxDataBind bind = (tbind as ComboBoxDataBind);

                    for (int i = 0; i < bind.destControl.Items.Count; i++)
                    {
                        if (bind.destControl.Items[i] is DataRowView)
                        {
                            if ((bind.destControl.Items[i] as DataRowView)[bind.destControl.ValueMember].ToString() == row[bind.srcPropertyName].ToString())
                            {
                                bind.destControl.SelectedIndex = i;
                                break;
                            }
                        }
                        else
                        {
                            if (bind.destControl.Items[i].ToString() == row[bind.srcPropertyName].ToString())
                            {
                                bind.destControl.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
                else if (tbind is MultiCdComboBoxDataBind)
                {
                    MultiCdComboBoxDataBind bind = (tbind as MultiCdComboBoxDataBind);

                    StringBuilder buf = new StringBuilder();
                    for (int i = 0; i < bind.srcPropertyName.Count(); i++)
                    {
                        if (i > 0) { buf.Append(MULTI_CD_SEPARATOR); }
                        buf.Append(row[bind.srcPropertyName.ElementAt(i)].ToString());
                    }

                    for (int i = 0; i < bind.destControl.Items.Count; i++)
                    {
                        if (bind.destControl.Items[i] is DataRowView)
                        {
                            if ((bind.destControl.Items[i] as DataRowView)[bind.destControl.ValueMember].ToString() == buf.ToString())
                            {
                                bind.destControl.SelectedIndex = i;
                                break;
                            }
                        }
                        else
                        {
                            if (bind.destControl.Items[i].ToString() == buf.ToString())
                            {
                                bind.destControl.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
                else if (tbind is CheckBoxDataBind)
                {
                    CheckBoxDataBind bind = (tbind as CheckBoxDataBind);

                    if (row[bind.srcPropertyName].Equals(bind.map.trueValue))
                    {
                        bind.destControl.Checked = true;
                    }
                    else if (row[bind.srcPropertyName].Equals(bind.map.falseValue))
                    {
                        bind.destControl.Checked = false;
                    }
                    else
                    {
                        // デフォルトはfalseとする
                        bind.destControl.Checked = false;
                    }
                }
                else if (tbind is RadioGroupDataBind)
                {
                    RadioGroupDataBind bind = (tbind as RadioGroupDataBind);

                    foreach (RadioButton radio in bind.groupMap.radioGroupMap.Keys)
                    {
                        if (row[bind.srcPropertyName].Equals(bind.groupMap.radioGroupMap[radio]))
                        {
                            radio.Checked = true;
                            break;
                        }
                    }
                }
                else if (tbind is SplitDateDataBind)
                {
                    SplitDateDataBind bind = (tbind as SplitDateDataBind);

                    if (row[bind.srcPropertyName] is string)
                    {
                        string dateStr = row[bind.srcPropertyName] as string;

                        if (dateStr.Length != 8)
                        {
                            continue;
                        }

                        bind.destControlYear.Text = dateStr.Substring(0, 4);
                        bind.destControlMonth.Text = dateStr.Substring(4, 2);
                        bind.destControlDay.Text = dateStr.Substring(6, 2);
                    }
                }
                else if (tbind is DataGridViewDataBind)
                {
                    DataGridViewDataBind bind = (tbind as DataGridViewDataBind);

                    bind.destControl.Rows[rowIdx].Cells[bind.destColIdx].Value = row[bind.srcPropertyName];
                }
            }
        }
        #endregion

        #region FillToControl
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        public void FillToControl(DataRow row)
        {
            FillToControl(row, 0);
        }
        #endregion

        #endregion

        #region Control -> Source

        #region FillToDataRow
        /// <summary>
        /// 
        /// </summary>
        public void FillToDataRow(DataTable targetDataTable, DateTime operateDt, string operateUser, string operateMachine, bool isNewData)
        {
            if (targetDataTable is DataTable)
            {
                DataTable source = targetDataTable as DataTable;

                int srcRowCnt = GetRecordCnt();

                for (int i = 0; i < srcRowCnt; i++)
                {
                    DataRow destRow;

                    // 行が不足する場合は追加する
                    if (i > targetDataTable.Rows.Count - 1)
                    {
                        destRow = targetDataTable.NewRow();
                    }
                    else
                    {
                        destRow = targetDataTable.Rows[i];
                    }

                    FillToDataRow(destRow, i);

                    // 共通列の設定を行う
                    // NOTICE ここはプロジェクト固有の部分なので、今後の扱いは要検討 => 全てのテーブルで共通列を持つ
                    // NOTICE Updateの場合も暫定値を設定する(Update クエリ側でset カラムから除外する)
                    //if (isNewData)
                    {
                        destRow["InsertDt"] = operateDt;
                        destRow["InsertUser"] = operateUser;
                        destRow["InsertTarm"] = operateMachine;
                    }
                    destRow["UpdateDt"] = operateDt;
                    destRow["UpdateUser"] = operateUser;
                    destRow["UpdateTarm"] = operateMachine;

                    if (destRow.RowState == DataRowState.Detached)
                    {
                        targetDataTable.Rows.Add(destRow);
                    }
                }
            }
        }
        #endregion

        #region FillToDataRow
        /// <summary>
        /// DataRowに更新用データを設定する
        /// </summary>
        /// <param name="row"></param>
        public void FillToDataRow(DataRow row, int rowIdx)
        {
            foreach (DataBind tbind in bindingMap)
            {
                if (tbind is ConstDataBind)
                {
                    ConstDataBind bind = (tbind as ConstDataBind);

                    row[bind.srcPropertyName] = bind.constValue;
                }
                else if (tbind is ControlDataBind)
                {
                    ControlDataBind bind = (tbind as ControlDataBind);

                    row[bind.srcPropertyName] = TypeUtility.GetConvertedValueForDB(bind.destControl.Text.Trim(), bind.srcPropertyType);
                }
                else if (tbind is ComboBoxDataBind)
                {
                    ComboBoxDataBind bind = (tbind as ComboBoxDataBind);

                    row[bind.srcPropertyName] = bind.destControl.SelectedValue;
                }
                else if (tbind is MultiCdComboBoxDataBind)
                {
                    MultiCdComboBoxDataBind bind = (tbind as MultiCdComboBoxDataBind);

                    if (bind.destControl.SelectedValue != null)
                    {
                        string[] values = bind.destControl.SelectedValue.ToString().Split(new string[] { MULTI_CD_SEPARATOR }, StringSplitOptions.None);

                        if (values.Length >= bind.srcPropertyName.Count())
                        {
                            for (int i = 0; i < bind.srcPropertyName.Count(); i++)
                            {
                                row[bind.srcPropertyName.ElementAt(i)] = values[i];
                            }
                        }
                    }
                }
                else if (tbind is CheckBoxDataBind)
                {
                    CheckBoxDataBind bind = (tbind as CheckBoxDataBind);

                    if (bind.destControl.Checked)
                    {
                        row[bind.srcPropertyName] = bind.map.trueValue;
                    }
                    else
                    {
                        row[bind.srcPropertyName] = bind.map.falseValue;
                    }
                }
                else if (tbind is RadioGroupDataBind)
                {
                    RadioGroupDataBind bind = (tbind as RadioGroupDataBind);

                    foreach (RadioButton radio in bind.groupMap.radioGroupMap.Keys)
                    {
                        if (radio.Checked)
                        {
                            row[bind.srcPropertyName] = bind.groupMap.radioGroupMap[radio];
                            break;
                        }
                    }
                }
                else if (tbind is SplitDateDataBind)
                {
                    SplitDateDataBind bind = (tbind as SplitDateDataBind);

                    string dateStr = string.Empty;

                    dateStr += bind.destControlYear.Text.Trim().PadLeft(4, '0');
                    dateStr += bind.destControlMonth.Text.Trim().PadLeft(2, '0');
                    dateStr += bind.destControlDay.Text.Trim().PadLeft(2, '0');

                    row[bind.srcPropertyName] = dateStr;
                }
                else if (tbind is DataGridViewDataBind)
                {
                    DataGridViewDataBind bind = (tbind as DataGridViewDataBind);

                    row[bind.srcPropertyName] = bind.destControl.Rows[rowIdx].Cells[bind.destColIdx].Value;
                }
            }
        }
        #endregion

        #region FillToDataRow
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        public void FillToDataRow(DataRow row)
        {
            FillToDataRow(row, 0);
        }
        #endregion

        #endregion

        #endregion

        #region private utility method

        #region GetRecordCnt
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int GetRecordCnt()
        {
            int recCnt = 1;

            foreach (DataBind tbind in bindingMap)
            {
                if (tbind is DataGridViewDataBind)
                {
                    DataGridViewDataBind bind = tbind as DataGridViewDataBind;

                    // NOTICE 新規登録行数を考慮するべきか? => 今回の使用範囲では新規登録は該当しない
                    recCnt = bind.destControl.Rows.Count;
                    break;
                }
            }

            return recCnt;
        }
        #endregion

        #region
        /// <summary>
        /// 
        /// </summary>
        /// <param name="recCnt"></param>
        private void SetRecordCnt(int recCnt)
        {
            foreach (DataBind tbind in bindingMap)
            {
                if (tbind is DataGridViewDataBind)
                {
                    DataGridViewDataBind bind = tbind as DataGridViewDataBind;

                    // NOTICE 新規登録行数を考慮するべきか? => 今回の使用範囲では新規登録は該当しない
                    // NOTICE 連結モード、非連結モードともに動作する事 => 今回の使用範囲では新規登録は該当しない
                    bind.destControl.RowCount = recCnt;

                    // do not break(set to all)
                }
            }
        }
        #endregion

        //#region SetObjectValue
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="targetObj"></param>
        ///// <param name="propName"></param>
        ///// <param name="value"></param>
        //private void SetObjectValue(object targetObj, string propName, object value)
        //{
        //    // NOTICE 実行時情報から、プロパティを動的に設定する => 今回は使用しない
        //}
        //#endregion

        #endregion

    }
}
