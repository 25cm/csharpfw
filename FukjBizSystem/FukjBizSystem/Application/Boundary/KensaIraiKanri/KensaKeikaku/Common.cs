using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using FukjBizSystem.Application.ApplicationLogic.KensaIraiKanri.KensaKeikaku;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KensaIraiKanri;
using FukjBizSystem.Application.Utility;
using Zynas.Control.Common;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.KensaIraiKanri.KensaKeikaku
{
    /// <summary>
    /// 検査予定データ(検査計画立案共通データソース)
    /// </summary>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/26　habu　　    新規作成
    /// </history>
    public class KensaKeikakuDataSource
    {
        public KensaKeikakuDataSet.KensaKeikakuListDataTable KensaYoteiData = null;

        public KensaKeikakuDataSet.KensaKeikakuMemoTblDataTable KensaYoteiMemoData = null;

        private string filterCond = string.Empty;

        private bool _isEdited = false;

        /// <summary>
        /// 保持データ編集フラグ
        /// </summary>
        public bool IsEdited
        {
            get { return _isEdited; }
        }

        #region GetKensaYoteiData
        /// <summary>
        /// 検査予定(検査依頼)データを取得
        /// </summary>
        /// <returns></returns>
        public KensaKeikakuDataSet.KensaKeikakuListDataTable GetKensaYoteiData()
        {
            if (KensaYoteiData == null)
            {
                CreateKensaYoteiData();
            }

            return KensaYoteiData;
        }
        #endregion

        // これは、カレンダー画面専用なので、別クラスに移しても良い
        /// <summary>
        /// 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public KensaKeikakuDataSet.KensaKeikakuListDataTable GetNewKensaYoteiData(string year, string month)
        {
            KensaKeikakuDataSet.KensaKeikakuListDataTable table = GetKensaYoteiData();

            return table;
        }

        #region 検査計画共有データ取得

        #region GetKensaYoteiMemoData
        /// <summary>
        /// 検査予定メモデータを取得
        /// </summary>
        /// <returns></returns>
        public KensaKeikakuDataSet.KensaKeikakuMemoTblDataTable GetKensaYoteiMemoData()
        {
            if (KensaYoteiMemoData == null)
            {
                CreateKensaYoteiData();
            }

            return KensaYoteiMemoData;
        }
        #endregion

        #region CreateKensaYoteiData
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void CreateKensaYoteiData()
        {
            string shishoCd = string.Empty;
            shishoCd = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;

            IDataLoadALInput input = new DataLoadALInput();
            // ログインユーザの所属支所コードでフィルタする
            input.SishoCd = shishoCd;
            IDataLoadALOutput output = new DataLoadApplicationLogic().Execute(input);

            KensaYoteiData = output.EditDataTable;

            KensaYoteiMemoData = output.EditMemoDataTable;

            // 変更状態をリセット
            _isEdited = false;

            return;
        }
        #endregion

        #endregion

        #region 検査計画共有データ更新

        #region SetKensaYoteiDate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="newYoteiDate">検査予定日(yyyyMMdd)</param>
        public void SetKensaYoteiDate(string keyValue, string newYoteiDate)
        {
            // メモリ保持データの検査予定日を更新する
            KensaKeikakuDataSet.KensaKeikakuListDataTable currentKensaData = GetKensaYoteiData();

            foreach (KensaKeikakuDataSet.KensaKeikakuListRow row in currentKensaData.Rows)
            {
                string key = GetKensaIraiKey(row);

                if (key == keyValue)
                {
                    if (!IsValidKensaYoteiDate(newYoteiDate))
                    {
                        break;
                    }

                    string nen = newYoteiDate.Substring(0, 4);
                    string tsuki = newYoteiDate.Substring(5, 2);
                    string bi = newYoteiDate.Substring(8, 2);
                    
                    // 予定日のフォーマットチェックは呼出側で行われていること
                    row[currentKensaData.KensaIraiKensaYoteiNenColumn] = nen;
                    row[currentKensaData.KensaIraiKensaYoteiTsukiColumn] = tsuki;
                    row[currentKensaData.KensaIraiKensaYoteiBiColumn] = bi;

                    #region to be removed
                    //DateTime tempDate;

                    //if (!DateTime.TryParseExact(newYoteiDate, "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.None, out tempDate))
                    //{
                    //    break;
                    //}

                    //// 予定日のフォーマットチェックは呼出側で行われていること
                    //row[currentKensaData.KensaIraiKensaYoteiNenColumn] = tempDate.Year.ToString("0000");
                    //row[currentKensaData.KensaIraiKensaYoteiTsukiColumn] = tempDate.Month.ToString("00");
                    //row[currentKensaData.KensaIraiKensaYoteiBiColumn] = tempDate.Day.ToString("00");
                    #endregion

                    // 変更フラグを保持
                    _isEdited = true;

                    break;
                }
            }
        }
        #endregion

        #region SetJokasoSetchiBashoAddr
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="newAddress"></param>
        public void SetJokasoSetchiBashoAddr(string keyValue, string newAddress)
        {
            // メモリ保持データの検査予定日を更新する
            KensaKeikakuDataSet.KensaKeikakuListDataTable currentKensaData = GetKensaYoteiData();

            foreach (KensaKeikakuDataSet.KensaKeikakuListRow row in currentKensaData.Rows)
            {
                string key = GetKensaIraiKey(row);

                if (key == keyValue)
                {
                    // 予定日のフォーマットチェックは呼出側で行われていること
                    row[currentKensaData.JokasoSetchiBashoAdrColumn] = newAddress;

                    // 変更フラグを保持
                    _isEdited = true;

                    break;
                }
            }
        }
        #endregion

        #region SetJokasoLocation
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="longtitude"></param>
        /// <param name="latitude"></param>
        public void SetJokasoLocation(string keyValue, double longtitude, double latitude)
        {
            // メモリ保持データの検査予定日を更新する
            KensaKeikakuDataSet.KensaKeikakuListDataTable currentKensaData = GetKensaYoteiData();

            foreach (KensaKeikakuDataSet.KensaKeikakuListRow row in currentKensaData.Rows)
            {
                string key = GetKensaIraiKey(row);

                if (key == keyValue)
                {
                    // フォーマットチェックは呼出側で行われていること
                    row[currentKensaData.JokasoZenrinIdoCdColumn] = latitude.ToString("0.0000000").Replace(".", ""); ;
                    row[currentKensaData.JokasoZenrinKeidoCdColumn] = longtitude.ToString("0.0000000").Replace(".", "");

                    // 変更フラグを保持
                    _isEdited = true;

                    break;
                }
            }
        }
        #endregion

        #region SetFilterCond
        /// <summary>
        /// 
        /// </summary>
        public void SetFilterCond(string filterStr)
        {
            filterCond = filterStr;
        }
        #endregion

        #region GetFilterCond
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetFilterCond()
        {
            return filterCond;
        }
        #endregion

        #region GetOrderStr
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetOrderStr()
        {
            string orderStr = string.Empty;

            orderStr = string.Format("{0},{1},{2},{3},{4},{5},{6}"
                , KensaYoteiData.KensaIraiKensaYoteiNenColumn.ColumnName
                , KensaYoteiData.KensaIraiKensaYoteiTsukiColumn.ColumnName
                , KensaYoteiData.KensaIraiKensaYoteiBiColumn.ColumnName
                , KensaYoteiData.KensaIraiHoteiKbnColumn.ColumnName
                , KensaYoteiData.KensaIraiHokenjoCdColumn.ColumnName
                , KensaYoteiData.KensaIraiNendoColumn.ColumnName
                , KensaYoteiData.KensaIraiRenbanColumn.ColumnName
                );

            return orderStr;
        }
        #endregion

        #region WriteBackToDB
        /// <summary>
        /// 
        /// </summary>
        public void WriteBackToDB()
        {
            // 画面上の更新データをDBに反映する
            // 更新対象
            // 浄化槽台帳:設置場所
            // 検査依頼:検査予定(年,月,日)

            KensaIraiTblDataSet.KensaIraiTblDataTable newKensaTable = new KensaIraiTblDataSet.KensaIraiTblDataTable();

            JokasoDaichoMstDataSet.JokasoDaichoMstDataTable newDaichoMstTable = new JokasoDaichoMstDataSet.JokasoDaichoMstDataTable();

            // 更新日時取得
            DateTime shoriDt = Common.Common.GetCurrentTimestamp();

            DataBindingHelper kensaBind = new DataBindingHelper();

            DataBindingHelper daichoBind = new DataBindingHelper();

            // 更新用データ作成
            // 検査依頼
            kensaBind.CopyDataTable(newKensaTable, KensaYoteiData,
                new DataColumn[] { 
                    newKensaTable.KensaIraiHoteiKbnColumn
                    , newKensaTable.KensaIraiHokenjoCdColumn
                    , newKensaTable.KensaIraiNendoColumn
                    , newKensaTable.KensaIraiRenbanColumn });

            foreach (KensaIraiTblDataSet.KensaIraiTblRow newRow in newKensaTable)
            {
                if (newRow.RowState != DataRowState.Modified)
                {
                    continue;
                }

                // 更新情報設定
                newRow.UpdateDt = shoriDt;
                newRow.UpdateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                newRow.UpdateTarm = Dns.GetHostName();

                // 20141225 habu ステータス設定条件を修正
                #region 検査依頼ステータス設定
                string newStatus = string.Empty;

                bool tantoSet = false;
                bool yoteiBiSet = false;

                if (!string.IsNullOrEmpty(TypeUtility.GetString(newRow[newKensaTable.KensaIraiKensaTantoshaCdColumn])))
                {
                    tantoSet = true;
                }

                // 予定の日付まで決定した時点で予定日決定とする
                if (!string.IsNullOrEmpty(TypeUtility.GetString(newRow[newKensaTable.KensaIraiKensaYoteiNenColumn]))
                    && !string.IsNullOrEmpty(TypeUtility.GetString(newRow[newKensaTable.KensaIraiKensaYoteiTsukiColumn]))
                    && !string.IsNullOrEmpty(TypeUtility.GetString(newRow[newKensaTable.KensaIraiKensaYoteiBiColumn]))
                    && TypeUtility.GetString(newRow[newKensaTable.KensaIraiKensaYoteiBiColumn]) != "00")
                {
                    yoteiBiSet = true;
                }

                // 要員、予定日が決定した場合計画済み
                if (tantoSet && yoteiBiSet)
                {
                    newStatus = Utility.Constants.KensaIraiStatusConstant.STATUS_YOTEI_KEIKAKU_ZUMI;
                }
                // 要員のみの場合、要員割当済み
                else if (tantoSet && !yoteiBiSet)
                {
                    newStatus = Utility.Constants.KensaIraiStatusConstant.STATUS_TANTOU_WARIATE_ZUMI;
                }
                // 予定日のみの場合、依頼登録済み
                else if (!tantoSet && yoteiBiSet)
                {
                    newStatus = Utility.Constants.KensaIraiStatusConstant.STATUS_IRAI_TOROKU;
                }
                else
                {
                    newStatus = Utility.Constants.KensaIraiStatusConstant.STATUS_IRAI_TOROKU;
                }

                string oldStatus = TypeUtility.GetString(newRow[newKensaTable.KensaIraiStatusKbnColumn]);

                // 不要な更新は行わない様にする
                if (newStatus != oldStatus)
                {
                    newRow.KensaIraiStatusKbn = newStatus;
                }
                #endregion
            }

            #region to be removed
            //// 浄化槽台帳
            //daichoBind.AddColumnMapping(newDaichoMstTable.KenchikuyotoDaibunrui1Column.ColumnName, KensaYoteiData.JokasoKenchikuyotoDaibunrui1Column.ColumnName);
            //daichoBind.AddColumnMapping(newDaichoMstTable.KenchikuyotoShobunrui1Column.ColumnName, KensaYoteiData.JokasoKenchikuyotoShobunrui1Column.ColumnName);
            //daichoBind.AddColumnMapping(newDaichoMstTable.KenchikuyotoRenban1Column.ColumnName, KensaYoteiData.JokasoKenchikuyotoRenban1Column.ColumnName);
            //daichoBind.AddColumnMapping(newDaichoMstTable.KenchikuyotoDaibunrui2Column.ColumnName, KensaYoteiData.JokasoKenchikuyotoDaibunrui2Column.ColumnName);
            //daichoBind.AddColumnMapping(newDaichoMstTable.KenchikuyotoShobunrui2Column.ColumnName, KensaYoteiData.JokasoKenchikuyotoShobunrui2Column.ColumnName);
            //daichoBind.AddColumnMapping(newDaichoMstTable.KenchikuyotoRenban2Column.ColumnName, KensaYoteiData.JokasoKenchikuyotoRenban2Column.ColumnName);
            //daichoBind.AddColumnMapping(newDaichoMstTable.KenchikuyotoDaibunrui3Column.ColumnName, KensaYoteiData.JokasoKenchikuyotoDaibunrui3Column.ColumnName);
            //daichoBind.AddColumnMapping(newDaichoMstTable.KenchikuyotoShobunrui3Column.ColumnName, KensaYoteiData.JokasoKenchikuyotoShobunrui3Column.ColumnName);
            //daichoBind.AddColumnMapping(newDaichoMstTable.KenchikuyotoRenban3Column.ColumnName, KensaYoteiData.JokasoKenchikuyotoRenban3Column.ColumnName);
            //daichoBind.AddColumnMapping(newDaichoMstTable.KenchikuyotoDaibunrui4Column.ColumnName, KensaYoteiData.JokasoKenchikuyotoDaibunrui4Column.ColumnName);
            //daichoBind.AddColumnMapping(newDaichoMstTable.KenchikuyotoShobunrui4Column.ColumnName, KensaYoteiData.JokasoKenchikuyotoShobunrui4Column.ColumnName);
            //daichoBind.AddColumnMapping(newDaichoMstTable.KenchikuyotoRenban4Column.ColumnName, KensaYoteiData.JokasoKenchikuyotoRenban4Column.ColumnName);
            //daichoBind.AddColumnMapping(newDaichoMstTable.KenchikuyotoDaibunrui5Column.ColumnName, KensaYoteiData.JokasoKenchikuyotoDaibunrui5Column.ColumnName);
            //daichoBind.AddColumnMapping(newDaichoMstTable.KenchikuyotoShobunrui5Column.ColumnName, KensaYoteiData.JokasoKenchikuyotoShobunrui5Column.ColumnName);
            //daichoBind.AddColumnMapping(newDaichoMstTable.KenchikuyotoRenban5Column.ColumnName, KensaYoteiData.JokasoKenchikuyotoRenban5Column.ColumnName);
            #endregion

            daichoBind.CopyDataTable(newDaichoMstTable, KensaYoteiData,
                new DataColumn[] {
                    newDaichoMstTable.JokasoHokenjoCdColumn
                    , newDaichoMstTable.JokasoTorokuNendoColumn
                    , newDaichoMstTable.JokasoRenbanColumn});

            foreach (JokasoDaichoMstDataSet.JokasoDaichoMstRow newRow in newDaichoMstTable)
            {
                if (newRow.RowState != DataRowState.Modified)
                {
                    continue;
                }

                // 更新情報設定
                newRow.UpdateDt = shoriDt;
                newRow.UpdateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                newRow.UpdateTarm = Dns.GetHostName();
            }

            // TODO 楽観ロックチェック行う事

            // 浄化槽台帳,検査依頼更新実行
            // 画面上で実際に変更が行われた検査予定のみ、クエリが発行される
            IDecisionBtnClickALInput input = new DecisionBtnClickALInput();
            input.KensaIraiUpdateData = newKensaTable;
            input.JokasoDaichoMstUpdateData = newDaichoMstTable;

            IDecisionBtnClickALOutput output = new DecisionBtnClickApplicationLogic().Execute(input);

            // 更新後に、データを再ロード
            CreateKensaYoteiData();
        }
        #endregion

        #endregion

        #region GetKensaIraiKey
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public string GetKensaIraiKey(KensaKeikakuDataSet.KensaKeikakuListRow row)
        {
            KensaKeikakuDataSet.KensaKeikakuListDataTable table = new KensaKeikakuDataSet.KensaKeikakuListDataTable();

            string key =
                string.Join("-"
                , new string[]
                {
                    TypeUtility.GetString(row[table.KensaIraiHoteiKbnColumn.ColumnName])
                    , TypeUtility.GetString(row[table.KensaIraiHokenjoCdColumn.ColumnName])
                    , TypeUtility.GetString(row[table.KensaIraiNendoColumn.ColumnName])
                    , TypeUtility.GetString(row[table.KensaIraiRenbanColumn.ColumnName])
                });

            return key;
        }
        #endregion

        #region GetKensaIraiDispKey
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public string GetKensaIraiDispKey(KensaKeikakuDataSet.KensaKeikakuListRow row)
        {
            KensaKeikakuDataSet.KensaKeikakuListDataTable table = new KensaKeikakuDataSet.KensaKeikakuListDataTable();

            string key =
                string.Join("-"
                , new string[]
                {
                    TypeUtility.GetString(row[table.KensaIraiHokenjoCdColumn.ColumnName])
                    , Common.Common.ConvertToHoshouNendoWareki(TypeUtility.GetString(row[table.KensaIraiNendoColumn.ColumnName]))
                    , TypeUtility.GetString(row[table.KensaIraiRenbanColumn.ColumnName])
                });

            return key;
        }
        #endregion

        #region GetKensaYoteiDateStr
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public string GetKensaYoteiDateStr(KensaKeikakuDataSet.KensaKeikakuListRow row)
        {
            KensaKeikakuDataSet.KensaKeikakuListDataTable table = new KensaKeikakuDataSet.KensaKeikakuListDataTable();

            string nen = TypeUtility.GetString(row[table.KensaIraiKensaYoteiNenColumn.ColumnName]);
            string tsuki = TypeUtility.GetString(row[table.KensaIraiKensaYoteiTsukiColumn.ColumnName]);
            string bi = TypeUtility.GetString(row[table.KensaIraiKensaYoteiBiColumn.ColumnName]);

            string yoteiDt = string.Empty;

            if (!string.IsNullOrEmpty(nen)
                && !string.IsNullOrEmpty(tsuki)
                && !string.IsNullOrEmpty(bi))
            {
                yoteiDt = string.Join("/"
                    , new string[] { nen, tsuki, bi });
            }

            return yoteiDt;
        }
        #endregion

        #region GetKensaYoteiDateShortStr
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public string GetKensaYoteiDateShortStr(KensaKeikakuDataSet.KensaKeikakuListRow row)
        {
            KensaKeikakuDataSet.KensaKeikakuListDataTable table = new KensaKeikakuDataSet.KensaKeikakuListDataTable();

            string tsuki = TypeUtility.GetString(row[table.KensaIraiKensaYoteiTsukiColumn.ColumnName]);
            string bi = TypeUtility.GetString(row[table.KensaIraiKensaYoteiBiColumn.ColumnName]);

            string yoteiDt = string.Empty;

            if (!string.IsNullOrEmpty(tsuki)
                && !string.IsNullOrEmpty(bi))
            {
                yoteiDt = string.Join("/"
                    , new string[] { tsuki, bi });
            }

            return yoteiDt;
        }
        #endregion

        #region GetKensaIraiRow

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public KensaKeikakuDataSet.KensaKeikakuListRow GetKensaIraiRow(string key)
        {
            KensaKeikakuDataSet.KensaKeikakuListDataTable table = GetKensaYoteiData();

            string hoteiKbn;
            string hokenjoCd;
            string nendo;
            string renban;

            string[] keyElems = key.Split(new char[] { '-' });

            if (keyElems.Length < 4)
            {
                return null;
            }

            hoteiKbn = keyElems[0];
            hokenjoCd = keyElems[1];
            nendo = keyElems[2];
            renban = keyElems[3];

            KensaKeikakuDataSet.KensaKeikakuListRow[] kensaRows = (KensaKeikakuDataSet.KensaKeikakuListRow[])table
                .Select(string.Format("{0} = '{1}' AND {2} = '{3}' AND {4} = '{5}' AND {6} = '{7}'"
                    , table.KensaIraiHoteiKbnColumn.ColumnName
                    , hoteiKbn
                    , table.KensaIraiHokenjoCdColumn.ColumnName
                    , hokenjoCd
                    , table.KensaIraiNendoColumn.ColumnName
                    , nendo
                    , table.KensaIraiRenbanColumn.ColumnName
                    , renban
                ));

            if (kensaRows.Length == 0)
            {
                return null;
            }

            return kensaRows[0];
        }

        #region IsValidKensaYoteiDate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="yoteiDt"></param>
        /// <returns></returns>
        public bool IsValidKensaYoteiDate(string yoteiDt)
        {
            if (string.IsNullOrEmpty(yoteiDt))
            {
                return false;
            }

            if (yoteiDt.Length != 10)
            {
                return false;
            }

            int temp = 0;

            string nen = yoteiDt.Substring(0, 4);
            string tsuki = yoteiDt.Substring(5, 2);
            string bi = yoteiDt.Substring(8, 2);

            if (!int.TryParse(nen, out temp))
            {
                return false;
            }
            if (!int.TryParse(tsuki, out temp))
            {
                return false;
            }
            if (!int.TryParse(bi, out temp))
            {
                return false;
            }

            return true;
        }
        #endregion

        #endregion
    }

    #region to be removed
    ///// <summary>
    ///// 
    ///// </summary>
    //public class StringUtlity
    //{
    //    #region GetValueString
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="value"></param>
    //    /// <param name="defaultValue"></param>
    //    /// <returns></returns>
    //    public static string GetValueString(object value, string defaultValue)
    //    {
    //        if (value == null || value.Equals(DBNull.Value))
    //        {
    //            return defaultValue;
    //        }

    //        if (value is string)
    //        {
    //            return value as string;
    //        }
    //        else
    //        {
    //            return value.ToString();
    //        }
    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="value"></param>
    //    /// <returns></returns>
    //    public static string GetValueString(object value)
    //    {
    //        return GetValueString(value, string.Empty);
    //    }
    //    #endregion
    //}
    #endregion

}
