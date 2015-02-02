using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MealReservationManager.Control
{
    ///  -----------------------------------------------------------------------------
    /// <summary>
    /// 休日設定用カレンダーコントロール
    /// </summary>
    /// <remarks>休日設定画面で使用するカレンダーコントロールです。</remarks>
    ///  -----------------------------------------------------------------------------
    public partial class DormitoryCalender : UserControl
    {

        /// <summary>対象年月</summary>

        private string yearMonth_Value;
        /// <summary>休日のセルスタイル</summary>

        private DataGridViewCellStyle CELL_STYLE_HOLYDAY;
        /// <summary>平日のセルスタイル</summary>

        private DataGridViewCellStyle CELL_STYLE_NORMAL;
        ///  -----------------------------------------------------------------------------
        /// <summary>
        /// 表示テキストと値を管理するクラス
        /// </summary>
        /// <remarks>表示テキストと値を管理するクラスです。</remarks>
        /// <history>
        /// 	[yasutsune]	2009.10.30	Created
        /// </history>
        ///  -----------------------------------------------------------------------------
        public class TextValuePair
        {

            /// <summary>データ値</summary>

            public System.DateTime Value;
            /// <summary>表示テキスト</summary>

            public string Text;
            ///  -----------------------------------------------------------------------------
            /// <summary>
            /// 文字列変換
            /// </summary>
            /// <returns>変換後文字列</returns>
            /// <remarks>TextValuePairの値を文字列に変換します。</remarks>
            /// <history>
            /// 	[yasutsune]	2009.10.30	Created
            /// </history>
            ///  -----------------------------------------------------------------------------
            public override string ToString()
            {
                return Text;
            }

            ///  -----------------------------------------------------------------------------
            /// <summary>
            /// 初期化処理
            /// </summary>
            /// <remarks>インスタンス生成時の処理を行いｍ巣</remarks>
            /// <history>
            /// 	[yasutsune]	2009.10.30	Created
            /// </history>
            ///  -----------------------------------------------------------------------------
            public TextValuePair(string txt, System.DateTime val)
            {
                this.Text = txt;
                this.Value = val;
            }

        }


        /// ----------------------------------------------------------------------------
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>インスタンス生成時の初期化処理を宣言します。</remarks>
        /// <history>
        /// 	[yasutsune]	2009.10.14	Created
        /// </history>
        /// -----------------------------------------------------------------------------

        public DormitoryCalender()
        {
            try
            {
                //この呼び出しは、Windows フォーム デザイナで必要です。
                InitializeComponent();

                //初期化処理
                Initialize();

            }
            catch (Exception ex)
            {
                MessageBox.Show("予期せぬ例外が発生しました。" + Environment.NewLine + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        ///  -----------------------------------------------------------------------------
        /// <summary>
        /// 表示年月設定
        /// </summary>
        /// <value>カレンダーに表示したい年月</value>
        /// <returns>現在カレンダーに表示されている年月</returns>
        /// <remarks>カレンダーの年月を取得または設定します。</remarks>
        /// <history>
        /// 	[yasutsune]	2009.10.14	Created
        /// </history>
        ///  -----------------------------------------------------------------------------
        public string YearMonth
        {

            get { return yearMonth_Value; }


            set
            {
                //対象年月が有効でない場合、例外を発生
                if (CheckYearMonthString(value) == false)
                {
                    throw new Exception("対象年月が不正です。");
                }


                try
                {
                    //対象年月を設定
                    yearMonth_Value = value.Clone().ToString();

                    //コントロールの値セット
                    SetContorls();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("月の設定に失敗しました。" + Environment.NewLine + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        ///  -----------------------------------------------------------------------------
        /// <summary>
        /// 休日リストの設定
        /// </summary>
        /// <param name="holidays">休日のDate型を格納したリスト</param>
        /// <remarks>休日の設定を行います。</remarks>
        /// <history>
        /// 	[yasutsune]	2009.10.14	Created
        /// </history>
        ///  -----------------------------------------------------------------------------

        public void SetHolidays(List<System.DateTime> holidays)
        {

            try
            {
                //全てのセル分ループ
                foreach (DataGridViewRow row in dgvDate.Rows)
                {

                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        //セルの値取得
                        TextValuePair cellValue = cell.Value as TextValuePair;

                        //セルの値がTextValuePair型の場合のみ処理
                        if ((cellValue != null))
                        {
                            if (holidays.Contains(cellValue.Value))
                            {
                                //セルの日付が休日一覧にある場合、休日
                                cell.Style = CELL_STYLE_HOLYDAY;
                            }
                            else
                            {
                                //セルの日付が休日一覧にない場合、平日
                                cell.Style = CELL_STYLE_NORMAL;
                            }
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("休日の設定に失敗しました。" + Environment.NewLine + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///  -----------------------------------------------------------------------------
        /// <summary>
        /// 休日リストの取得
        /// </summary>
        /// <returns>休日のDate型を格納したリスト</returns>
        /// <remarks>休日の取得を行います。</remarks>
        /// <history>
        /// 	[yasutsune]	2009.10.14	Created
        /// </history>
        ///  -----------------------------------------------------------------------------
        public List<System.DateTime> GetHolidays()
        {


            try
            {
                // 休日を格納するリスト
                List<System.DateTime> holidayList = new List<System.DateTime>();

                //全てのセル分ループ
                foreach (DataGridViewRow row in dgvDate.Rows)
                {

                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        //セルの値取得
                        TextValuePair cellValue = cell.Value as TextValuePair;

                        //セルの値がTextValuePair型でない場合、日付セルでないので終了
                        if (cellValue == null)
                        {
                            continue;
                        }

                        //セルスタイルが休日の場合、休日リストに追加
                        if (cell.Style.Equals(CELL_STYLE_HOLYDAY))
                        {
                            holidayList.Add(cellValue.Value);
                        }

                    }
                }

                return holidayList;

            }
            catch (Exception)
            {
                return null;
            }

        }

        ///  -----------------------------------------------------------------------------
        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <remarks>初期化処理</remarks>
        /// <history>
        /// 	[yasutsune]	2009.10.14	Created
        /// </history>
        ///  -----------------------------------------------------------------------------
        private void Initialize()
        {

            try
            {
                //休日のセルスタイル
                CELL_STYLE_HOLYDAY = new DataGridViewCellStyle();
                CELL_STYLE_HOLYDAY.BackColor = Color.Pink;
                CELL_STYLE_HOLYDAY.ForeColor = Color.Black;
                CELL_STYLE_HOLYDAY.SelectionBackColor = Color.Pink;
                CELL_STYLE_HOLYDAY.SelectionForeColor = Color.Black;
                CELL_STYLE_HOLYDAY.Alignment = DataGridViewContentAlignment.MiddleRight;

                //平日のセルスタイル
                CELL_STYLE_NORMAL = new DataGridViewCellStyle();
                CELL_STYLE_NORMAL.BackColor = Color.White;
                CELL_STYLE_NORMAL.ForeColor = Color.Black;
                CELL_STYLE_NORMAL.SelectionBackColor = Color.White;
                CELL_STYLE_NORMAL.SelectionForeColor = Color.Black;
                CELL_STYLE_NORMAL.Alignment = DataGridViewContentAlignment.MiddleRight;

                //年月を今月に設定
                yearMonth_Value = DateTime.Today.ToString("yyyy/MM");

                //コントロールの値セット
                SetContorls();

            }
            catch (Exception ex)
            {
                MessageBox.Show("カレンダーコントロールの初期化に失敗しました。" + Environment.NewLine + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// コントロールの値セット
        /// </summary>
        /// <remarks>コントロールに値を設定します。</remarks>
        /// <history>
        /// 	[yasutsune]	2009.10.14	Created
        /// </history>
        /// -----------------------------------------------------------------------------

        private void SetContorls()
        {
            //一旦行をクリア
            dgvDate.Rows.Clear();

            //曜日表示
            dgvDate.Rows.Add("日", "月", "火", "水", "木", "金", "土");

            //日付表示用行追加
            dgvDate.Rows.Add(6);

            //セルスタイルをクリア
            ClearCellStyle();

            //年月を表示
            lblYearMonth.Text = yearMonth_Value;

            System.DateTime startDate = System.DateTime.Parse(yearMonth_Value + "/01");
            //月開始日付を取得
            System.DateTime endDate = startDate.AddMonths(1).AddDays(-1);
            //月終了日付を取得
            int index = (int)startDate.DayOfWeek;
            //日付表示開始の位置を取得
            DataGridViewCell cell = default(DataGridViewCell);
            //日付表示対象セル

            //日付表示ループ
            System.DateTime dayCount = startDate;

            while (dayCount <= endDate)
            {
                //日付表示対象セルの取得
                cell = dgvDate.Rows[index / 7 + 1].Cells[index % 7];

                //値追加
                cell.Value = new TextValuePair(dayCount.Day.ToString(), dayCount);

                //土日の場合、背景色を赤にする
                if (dayCount.DayOfWeek == DayOfWeek.Sunday | dayCount.DayOfWeek == DayOfWeek.Saturday)
                {
                    cell.Style = CELL_STYLE_HOLYDAY;
                }

                //日付をカウントアップ
                dayCount = dayCount.AddDays(1);

                //インデックスをカウントアップ
                index = index + 1;
            }

        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// セルスタイルのクリア
        /// </summary>
        /// <remarks>セルスタイルの初期化処理を行います。</remarks>
        /// <history>
        /// 	[yasutsune]	2009.10.14	Created
        /// </history>
        /// -----------------------------------------------------------------------------

        private void ClearCellStyle()
        {
            //全てのセル分ループ
            foreach (DataGridViewRow row in dgvDate.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    //セルスタイルを平日にする
                    cell.Style = CELL_STYLE_NORMAL;
                }
            }

        }

        ///  -----------------------------------------------------------------------------
        /// <summary>
        /// セルクリックイベント
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント</param>
        /// <remarks>セルクリック時の処理を宣言します。</remarks>
        /// <history>
        /// 	[yasutsune]	2009.10.14	Created
        /// </history>
        /// -----------------------------------------------------------------------------

        private void dgvDate_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {

            try
            {
                //クリックされたセル取得
                DataGridViewCell cell = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex];

                //セルの値がTextValuePair型でない場合、日付セルでないので終了
                if (cell.Value as TextValuePair == null)
                {
                    return;
                }

                if (cell.Style.Equals(CELL_STYLE_HOLYDAY))
                {
                    //休日の場合、休日→平日
                    cell.Style = CELL_STYLE_NORMAL;
                }
                else if (cell.Style.Equals(CELL_STYLE_NORMAL))
                {
                    //平日の場合、平日→休日
                    cell.Style = CELL_STYLE_HOLYDAY;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("休日設定に失敗しました。" + Environment.NewLine + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            this.OnClick(e);
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// 年月文字列チェック
        /// </summary>
        /// <param name="str">チェックする文字列</param>
        /// <returns>true:年月、false:年月以外</returns>
        /// <remarks>引数の文字列が年月として正しいかチェックします。</remarks>
        /// <history>
        /// 	[takahashi]	2009.10.25	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        private bool CheckYearMonthString(string str)
        {
            //戻り値（初期値：異常終了）
            bool returnValue = false;

            //正規表現を使ってyyyy/MMの形式になっているかをチェック

            if ((System.Text.RegularExpressions.Regex.IsMatch(str, "^[0-9]{4,4}/[0-9]{2,2}$")))
            {
                //年と月で分割
                string[] substr = str.Split('/');

                //月が1～12の値の場合、正常終了
                if (int.Parse(substr[1]) >= 1 & int.Parse(substr[1]) <= 12)
                {
                    returnValue = true;
                }
            }

            //結果を返す
            return returnValue;
        }

    }
}
