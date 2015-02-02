using System;
using System.Reflection;
using System.Windows.Forms;
using FukjTabletSystem.Application.Boundary.Common;
using Zynas.Framework.Utility;
using System.Diagnostics;

namespace FukjTabletSystem.Application.Utility
{
    /// <summary>
    /// 数値入力コントロール制御クラス
    /// </summary>
    public class NumberInput
    {
        /// <summary>
        /// 数値入力コントロール
        /// </summary>
        private static Process _numberInputDialog;

        /// <summary>
        /// インスタンス
        /// </summary>
        private static NumberInput _numberInput = new NumberInput();             

        #region NumberInput()
        /// <summary>
        /// コンストラクタ
        /// </summary>
        private NumberInput()
        {
            try
            {
                TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
                
                _numberInputDialog = Process.Start(new ProcessStartInfo("NumberInputKeybord.exe"));
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.Message);
            }
            finally
            {
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region Show()
        /// <summary>
        /// 数値入力ダイアログの表示
        /// </summary>
        public static void Show(Control owner)
        {
            try
            {
                TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

                if (_numberInputDialog.HasExited)
                {
                    _numberInputDialog = Process.Start(new ProcessStartInfo("NumberInputKeybord.exe"));
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.Message);
            }
            finally
            {
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region Show()
        /// <summary>
        /// 数値入力ダイアログの終了
        /// </summary>
        public static void Close()
        {
            try
            {
                TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

                if (!_numberInputDialog.HasExited)
                {
                    _numberInputDialog.Kill();
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.Message);
            }
            finally
            {
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion
    }
}
