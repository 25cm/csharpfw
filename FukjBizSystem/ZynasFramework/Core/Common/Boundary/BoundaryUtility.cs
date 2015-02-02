using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Zynas.Framework.Utility;

namespace Zynas.Framework.Core.Common.Boundary
{
    public class BoundaryUtility
    {
        public delegate void EventBody();

        #region StdLoadEventSequence
        /// <summary>
        /// マウスカーソルの砂時計処理、メソッド開始終了ログの処理を行う
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="eventBody"></param>
        /// <param name="writeStartEndTraceLog"></param>
        /// <param name="waitCursor"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/18　habu　　    新規作成
        /// </history>
        public static void StdLoadEventSequence(Form frm, EventBody eventBody, bool waitCursor = true, bool writeStartEndTraceLog = true, EventBody closeBody = null)
        {
            // NOTICE:引数省略の為にオーバーロードを使用すると、
            // 開始終了メソッド名が変わってしまうため(呼出スタックが1段増えるため)、デフォルト引数を使用する
            StackTrace strace = new StackTrace();
            Cursor preCursor = Cursors.Default;

            EventBody defaultCloseBody = delegate()
            {
                frm.DialogResult = DialogResult.Abort;
                frm.Close();
            };

            // 呼出元チェック
            if (strace.FrameCount < 1) { TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), "呼出元メソッド名が参照できません。"); }

            // 開始ログ出力
            if (writeStartEndTraceLog)
            {
                if (strace.FrameCount >= 1) { TraceLog.StartWrite(strace.GetFrame(1).GetMethod()); }
            }

            // カーソル砂時計処理
            if (waitCursor) { preCursor = Cursor.Current; }

            try
            {
                // カーソル砂時計処理
                if (waitCursor) { Cursor.Current = Cursors.WaitCursor; }

                // イベント本体を実行
                eventBody();
            }
            catch (Exception ex)
            {
                // エラーログ出力
                if (strace.FrameCount >= 1) { TraceLog.ErrorWrite(strace.GetFrame(1).GetMethod(), ex.ToString()); }

                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);

                // 初期ロードイベント時のエラーは画面を閉じる
                if (closeBody == null)
                {
                    // デフォルトの終了処理を実行
                    defaultCloseBody();
                }
                else
                {
                    // カスタムの終了処理を実行
                    closeBody();
                }
            }
            finally
            {
                // カーソル砂時計処理
                if (waitCursor) { Cursor.Current = preCursor; }

                // 終了ログ出力
                if (writeStartEndTraceLog)
                {
                    if (strace.FrameCount >= 1) { TraceLog.EndWrite(strace.GetFrame(1).GetMethod()); }
                }
            }
        }
        #endregion

        #region StdEventSequence
        /// <summary>
        /// マウスカーソルの砂時計処理、メソッド開始終了ログの処理を行う
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="eventBody"></param>
        /// <param name="writeStartEndTraceLog"></param>
        /// <param name="waitCursor"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/18　habu　　    新規作成
        /// </history>
        public static void StdEventSequence(EventBody eventBody, bool waitCursor = true, bool writeStartEndTraceLog = true)
        {
            // NOTICE:初期ロード(XXXForm_Load)イベントではStdLoadEventSequenceを使用する
            // NOTICE:引数省略の為にオーバーロードを使用すると、
            // 開始終了メソッド名が変わってしまうため、デフォルト引数を使用する
            StackTrace strace = new StackTrace();
            Cursor preCursor = Cursors.Default;

            // 呼出元チェック
            if (strace.FrameCount < 1) { TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), "呼出元メソッド名が参照できません。"); }

            // 開始ログ出力
            if (writeStartEndTraceLog)
            {
                if (strace.FrameCount >= 1) { TraceLog.StartWrite(strace.GetFrame(1).GetMethod()); }
            }

            // カーソル砂時計処理
            if (waitCursor) { preCursor = Cursor.Current; }

            try
            {
                // カーソル砂時計処理
                if (waitCursor) { Cursor.Current = Cursors.WaitCursor; }

                // イベント本体を実行
                eventBody();
            }
            catch (Exception ex)
            {
                // エラーログ出力
                if (strace.FrameCount >= 1) { TraceLog.ErrorWrite(strace.GetFrame(1).GetMethod(), ex.ToString()); }

                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                // カーソル砂時計処理
                if (waitCursor) { Cursor.Current = preCursor; }

                // 終了ログ出力
                if (writeStartEndTraceLog)
                {
                    if (strace.FrameCount >= 1) { TraceLog.EndWrite(strace.GetFrame(1).GetMethod()); }
                }
            }
        }
        #endregion

    }
}
