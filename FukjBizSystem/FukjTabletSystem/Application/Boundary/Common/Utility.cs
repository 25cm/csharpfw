using System;
using System.Data;
using System.Device.Location;
using System.Diagnostics;
using System.Threading;
using FukjTabletSystem.Properties;

namespace FukjTabletSystem.Application.Boundary.Common
{
    public class Utility
    {
        #region ExecScreenKeybord
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ExecScreenKeybord
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/10  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static void ExecScreenKeybord()
        {
            //OSの情報を取得する
            System.OperatingSystem os = System.Environment.OSVersion;

            // windows 8以前の場合
            if (os.Version.Major < 6 || os.Version.Minor < 2)
            {
                return;
            }

            // 起動
            Process keybord = new Process();
            keybord.StartInfo.FileName = @"C:\Program Files\Common Files\microsoft shared\ink\TabTip.exe";
            keybord.Start();

            System.Diagnostics.Process[] ps =
            System.Diagnostics.Process.GetProcesses();

            // 既に起動している場合は一度終了させる（非表示の場合が有るの為）
            foreach (System.Diagnostics.Process p in ps)
            {
                if (p.ProcessName == "TabTip" && p.Id != keybord.Id)
                {
                    try
                    {
                        // 連続で実行するとアクセスエラーが発生するが・・・
                        p.Kill();

                        break;
                    }
                    catch
                    {
                    }
                }
            }
        }
        #endregion

        #region IsOnline
        /// <summary>
        /// オンライン判定
        /// </summary>
        /// <returns></returns>
        public static bool IsOnline()
        {
            bool ret = false;

            // オンラインチェックを使用しない場合は常にオンラインを返す
            if (!Settings.Default.OnlineCheckEnable)
            {
                return true;
            }

            // 接続先
            string host = Settings.Default.OnlineCheckAddress;

            try
            {
                // Pingオブジェクトの作成
                using (System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping())
                {
                    // Pingを送信する
                    System.Net.NetworkInformation.PingReply reply = p.Send(host);

                    //結果を取得
                    if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
                    {
                        ret = true;
                    }

                    p.Dispose();
                }
            }
            catch
            {
                return ret;
            }
            finally
            {
            }

            return ret;
        }
        #endregion

        #region IsInDesignMode
        /// <summary>
        /// デザイナモード判定
        /// </summary>
        /// <returns></returns>
        public static bool IsInDesignMode
        {
            get
            {
                System.Diagnostics.Process process = System.Diagnostics.Process.GetCurrentProcess();
                bool res = process.ProcessName == "devenv";
                process.Dispose();
                return res;
            }
        }
        #endregion

        #region SetComboBoxList
        /// <summary>
        /// データテーブルのデータをコンボボックスに設定する
        /// </summary>
        /// <param name="targetComboBox">設定するコンボボックス</param>
        /// <param name="dataTable">設定するデータテーブル</param>
        /// <param name="DisplayMember">コンボボックスに表示するカラム</param>
        /// <param name="ValueMember">SelectedValueでコンボボックスより取得するカラム</param>
        /// <param name="addEmpty">~行を追加するか</param>
        public static void SetComboBoxList(
            System.Windows.Forms.ComboBox targetComboBox,
            DataTable dataTable,
            string DisplayMember,
            string ValueMember,
            bool addEmpty)
        {
            // 表示用にデータテーブルを作成（NULL制約を外す）
            DataTable dt = new DataTable();
            foreach (DataColumn col in dataTable.Columns)
            {
                dt.Columns.Add(col.ColumnName, col.DataType);
            }

            // 行データの詰め替え（MERGEは制約も移るため）
            foreach (DataRow row in dataTable.Rows)
            {
                dt.ImportRow(row);
            }

            // 空行追加（値を設定しない）
            if (addEmpty)
            {
                DataRow row = dt.NewRow();
                row[DisplayMember] = string.Empty;
                dt.Rows.InsertAt(row, 0);
            }

            // コンボボックスにデータを設定
            targetComboBox.DataSource = dt;
            targetComboBox.DisplayMember = DisplayMember;
            targetComboBox.ValueMember = ValueMember;

            targetComboBox.SelectedIndex = -1;
        }
        #endregion

        #region SetComboBoxList
        /// <summary>
        /// データテーブルのデータをコンボボックスに設定する
        /// </summary>
        /// <param name="targetComboBox">設定するコンボボックス</param>
        /// <param name="dataTable">設定するデータテーブル</param>
        /// <param name="DisplayMember">コンボボックスに表示するカラム</param>
        /// <param name="ValueMember">SelectedValueでコンボボックスより取得するカラム</param>
        /// <param name="addEmpty">~行を追加するか</param>
        public static void SetComboBoxList(
            System.Windows.Forms.ComboBox targetComboBox,
            DataTable dataTable,
            string DisplayMember,
            string ValueMember,
            bool addEmpty,
            string padLeft,
            string padRight)
        {
            // 表示用にデータテーブルを作成（NULL制約を外す）
            DataTable dt = new DataTable();
            foreach (DataColumn col in dataTable.Columns)
            {
                dt.Columns.Add(col.ColumnName, col.DataType);
            }

            // 行データの詰め替え（MERGEは制約も移るため）
            foreach (DataRow row in dataTable.Rows)
            {
                dt.ImportRow(row);

                dt.Rows[dt.Rows.Count - 1][DisplayMember] = string.Format("{0}{1}{2}", padLeft, row[DisplayMember], padRight);
            }

            // 空行追加（値を設定しない）
            if (addEmpty)
            {
                DataRow row = dt.NewRow();
                row[DisplayMember] = string.Empty;
                dt.Rows.InsertAt(row, 0);
            }

            // コンボボックスにデータを設定
            targetComboBox.DataSource = dt;
            targetComboBox.DisplayMember = DisplayMember;
            targetComboBox.ValueMember = ValueMember;

            targetComboBox.SelectedIndex = -1;
        }
        #endregion
    }
}
