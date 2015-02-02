using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Microsoft.VisualBasic;

namespace FukjBizSystem.Application.Utility
{
    /// <summary>
    /// usbbarcode.dllラッパークラス
    /// </summary>
    public static class UsbBarcodeUtility
    {
        #region usbbarcode.dll

        /// <summary>
        /// DuploBarcode_Open
        /// </summary>
        /// <param name="iIF_Renamed"></param>
        /// <param name="iEP"></param>
        /// <returns></returns>
        [DllImport("usbbarcode.dll")]
        private extern static int DuploBarcode_Open(short iIF_Renamed, short iEP);
        
        /// <summary>
        /// DuploBarcode_Close
        /// </summary>
        /// <param name="Port"></param>
        [DllImport("usbbarcode.dll")]
        private extern static void DuploBarcode_Close(int Port);
        
        /// <summary>
        /// DuploBarcode_Write
        /// </summary>
        /// <param name="Port"></param>
        /// <param name="lpBuffer"></param>
        /// <param name="nNumberOfBytesToWrite"></param>
        /// <param name="lpNumberOfBytesWrite"></param>
        /// <returns></returns>
        [DllImport("usbbarcode.dll")]
        private extern static bool DuploBarcode_Write(int Port, ref byte lpBuffer, int nNumberOfBytesToWrite, ref int lpNumberOfBytesWrite);
        
        /// <summary>
        /// DuploBarcode_Read
        /// </summary>
        /// <param name="Port"></param>
        /// <param name="lpBuffer"></param>
        /// <param name="nNumberOfBytesToRead"></param>
        /// <param name="lpNumberOfBytesRead"></param>
        /// <returns></returns>
        [DllImport("usbbarcode.dll")]
        private extern static bool DuploBarcode_Read(int Port, ref byte lpBuffer, int nNumberOfBytesToRead, ref int lpNumberOfBytesRead);
        
        /// <summary>
        /// DuploBarcode_ResetDevice
        /// </summary>
        /// <param name="Port"></param>
        [DllImport("usbbarcode.dll")]
        private extern static int DuploBarcode_ResetDevice(int Port);

        #endregion

        #region フィールド(private)

        /// <summary>
        /// 接続状態
        /// </summary>
        private static bool IsOpened = false;

        /// <summary>
        /// 使用ポート
        /// </summary>
        private static int[] MyPort = new int[3] { 0, 0, 0};
                
        #endregion

        #region 定数

        /// <summary>
        /// コマンドステータス
        /// </summary>
        public enum CommandStatus
        {
            /// <summary>
            /// スタートＯＫ
            /// </summary>
            StartOK,

            /// <summary>
            /// スタートＮＧ
            /// </summary>
            StartNG,

            /// <summary>
            /// 正常停止
            /// </summary>
            NormalEnd,

            /// <summary>
            /// 機器異常検知
            /// </summary>
            MachineError,
            
            /// <summary>
            /// 読取エラー
            /// </summary>
            ReadError,

            /// <summary>
            /// 通常データ受信
            /// </summary>
            DataReceive,

            /// <summary>
            /// 受信データ無し
            /// </summary>
            NoDataReceive,

            /// <summary>
            /// その他
            /// </summary>
            Other,
        }

        #endregion

        #region メソッド(public)

        #region GetStatus(byte[] data)
        /// <summary>
        /// ステータスコマンドの判定
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static CommandStatus GetStatus(byte[] data)
        {
            // 受信データ無し
            if (data == null || data.Length == 0)
            {
                return CommandStatus.NoDataReceive;
            }

            // 読み取りエラー
            if (BytesConvert.ToHexString(data) == "18")
            {

                return CommandStatus.ReadError;
            }
            
            string statusCommand = Encoding.ASCII.GetString(data);
            
            switch (statusCommand)
            {
                case "M01": // スタートＯＫ

                    return CommandStatus.StartOK;

                case "M02": // スタートＮＧ

                    return CommandStatus.StartNG;

                case "M03": // 正常停止

                    return CommandStatus.NormalEnd;

                case "M04": // 紙詰まり停止
                case "M05": // 重送停止
                case "M06": // 連鎖停止
                case "M07": // 空送り停止
                case "M08": // カバー停止
                case "M09": // マークエラー停止
                case "M11": // プリンタエラー停止
                case "M13": // 連続読取ミス
                case "M14": // ｱｸｾﾌﾟﾄ２満載

                    return CommandStatus.MachineError;

                case "M00": // スタート確認
                case "M10": // プリンタデータ無し
                case "M12": // 未使用

                    return CommandStatus.Other;

                default:

                    // 通常読み取り
                    return CommandStatus.DataReceive;
            }
        }
        #endregion

        #region Open()
        /// <summary>
        /// 接続処理
        /// </summary>
        /// <returns></returns>
        public static bool Open()
        {
            try
            {
                // 既にOpenされている
                if (IsOpened)
                {
                    // 一旦Close
                    Close();
                }

                for (short i = 0; i < 3; i++)
                {
                    // 接続
                    MyPort[i] = DuploBarcode_Open(0, i);

                    if (MyPort[i] == 0)
                    {
                        return false;
                    }
                }

                // 状態を更新
                IsOpened = true;
            }
            catch
            {
                return false;
            }

            return true;
        }
        #endregion

        #region Close()
        /// <summary>
        /// 切断処理
        /// </summary>
        /// <returns></returns>
        public static bool Close()
        {
            try
            {
                // 既にCloseされている
                if (!IsOpened)
                {
                    return true;
                }

                for (short i = 0; i < 3; i++)
                {
                    // 切断
                    DuploBarcode_Close(MyPort[i]);
                }

                MyPort = new int[3] { 0, 0, 0 };

                // 状態を更新
                IsOpened = false;
            }
            catch
            {
                return false;
            }

            return true;
        }
        #endregion

        #region Reset()
        /// <summary>
        /// 切断処理
        /// </summary>
        /// <returns></returns>
        public static bool Reset()
        {
            try
            {
                if (!IsOpened)
                {
                    return false;
                }

                for (short i = 0; i < 3; i++)
                {
                    // 切断
                    int ret = DuploBarcode_ResetDevice(MyPort[i]);
                }
            }
            catch
            {
                return false;
            }
            
            return true;
        }
        #endregion

        #region Write(string str)
        /// <summary>
        /// コマンド送信処理
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool Write(string str)
        {
            try
            {
                if (!IsOpened)
                {
                    return false;
                }

                int lpNumberOfBytesWrite = 0;

                str += (char)0x03;

                byte[] binData = AscBinChange(ref str);

                return DuploBarcode_Write(MyPort[0], ref binData[0], binData.Length, ref lpNumberOfBytesWrite);
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Read(out byte[] readBytes)
        /// <summary>
        /// 読取処理
        /// </summary>
        /// <param name="readBytes"></param>
        /// <returns></returns>
        public static bool Read(out byte[] readBytes)
        {
            try
            {
                bool ret = ReadMain(out readBytes);

                while (!ret)
                {
                    Thread.Sleep(10);

                    ret = ReadMain(out readBytes);
                }

                return ret;
            }
            catch
            {
                readBytes = null;

                return false;
            }
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region ReadMain(out byte[] readBytes)
        /// <summary>
        /// 読取処理メイン
        /// </summary>
        /// <param name="readBytes"></param>
        /// <returns></returns>
        private static bool ReadMain(out byte[] readBytes)
        {
            if (!IsOpened)
            {
                readBytes = null;

                return false;
            }

            int lpNumberOfBytesRead = 0;

            int nNumberOfBytesToRead = 64;

            byte[] newReadBytes = new byte[nNumberOfBytesToRead];

            bool ret = DuploBarcode_Read(MyPort[2], ref newReadBytes[0], nNumberOfBytesToRead, ref lpNumberOfBytesRead);

            if (ret && lpNumberOfBytesRead == 1)
            {
                lpNumberOfBytesRead = 0;

                nNumberOfBytesToRead = 64;

                newReadBytes = new byte[nNumberOfBytesToRead];

                ret = DuploBarcode_Read(MyPort[1], ref newReadBytes[0], nNumberOfBytesToRead, ref lpNumberOfBytesRead);
            }

            if (lpNumberOfBytesRead == 0)
            {
                readBytes = null;

                return false;
            }

            readBytes = new byte[lpNumberOfBytesRead - 1];

            Array.Copy(newReadBytes, readBytes, lpNumberOfBytesRead - 1);

            return true;
        }
        #endregion

        #region AscBinChange(ref string AscData)
        /// <summary>
        /// バイナリ変換
        /// </summary>
        /// <param name="AscData"></param>
        /// <returns></returns>
        private static byte[] AscBinChange(ref string AscData)
        {
            int ByteCntAll = 0;
            int ByteCnt = 0;

            byte[] BinData = null;
            
            for (int i = 1; i <= Strings.Len(AscData); i++)
            {
                if (Strings.Len(Conversion.Hex(Strings.Asc(Strings.Mid(AscData, i, 1)))) <= 2)
                {
                    ByteCntAll = ByteCntAll + 1;
                }
                else
                {
                    ByteCntAll = ByteCntAll + 2;
                }
            }

            BinData = new byte[ByteCntAll];

            ByteCntAll = 0;

            for (int i = 1; i <= Strings.Len(AscData); i++)
            {
                ByteCnt = Strings.Len(Conversion.Hex(Strings.Asc(Strings.Mid(AscData, i, 1))));

                if (ByteCnt <= 2)
                {
                    BinData[ByteCntAll] = Convert.ToByte(Strings.Asc(Strings.Mid(AscData, i, 1)));
                    ByteCntAll = ByteCntAll + 1;
                }
                else
                {
                    if (ByteCnt == 3)
                    {
                        BinData[ByteCntAll] = Convert.ToByte("&H0" + Strings.Mid(Conversion.Hex(Strings.Asc(Strings.Mid(AscData, i, 1))), 1, 1));
                        ByteCntAll = ByteCntAll + 1;
                        BinData[ByteCntAll] = Convert.ToByte("&H" + Strings.Mid(Conversion.Hex(Strings.Asc(Strings.Mid(AscData, i, 1))), 2, 2));
                        ByteCntAll = ByteCntAll + 1;
                    }
                    else
                    {
                        BinData[ByteCntAll] = Convert.ToByte("&H" + Strings.Mid(Conversion.Hex(Strings.Asc(Strings.Mid(AscData, i, 1))), 1, 2));
                        ByteCntAll = ByteCntAll + 1;
                        BinData[ByteCntAll] = Convert.ToByte("&H" + Strings.Mid(Conversion.Hex(Strings.Asc(Strings.Mid(AscData, i, 1))), 3, 2));
                        ByteCntAll = ByteCntAll + 1;
                    }
                }
            }

            return BinData;
        }
        #endregion
        
        #endregion

    }
}
