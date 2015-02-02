using System;
using System.Text;

namespace FukjBizSystem.Application.Utility
{
    /// <summary>
    /// バイト配列と文字列との変換機能を提供する
    /// </summary>
    public class BytesConvert
    {
        /// <summary>
        /// バイナリ変換:エンディアン
        /// </summary>
        /// <summary>
        /// ビッグエンディアン
        /// </summary>
        public const string ENDIAN_BIG = "BIG";
        /// <summary>
        /// リトルエンディアン
        /// </summary>
        public const string ENDIAN_LITTLE = "LITTLE";

        /// <summary>
        /// バイト配列から16進数の文字列を生成します。
        /// </summary>
        /// <param name="bytes">バイト配列</param>
        /// <returns>16進数文字列</returns>
        public static string ToHexStringCRLF(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
            {
                if (b < 16) sb.Append('0'); // 二桁になるよう0を追加
                sb.Append(string.Format("{0}\r\n", Convert.ToString(b, 16)));
            }
            return sb.ToString();
        }

        /// <summary>
        /// バイト配列から16進数の文字列を生成します。
        /// </summary>
        /// <param name="bytes">バイト配列</param>
        /// <returns>16進数文字列</returns>
        public static string ToHexString(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
            {
                if (b < 16) sb.Append('0'); // 二桁になるよう0を追加
                sb.Append(Convert.ToString(b, 16));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 16進数の文字列からバイト配列を生成します。
        /// </summary>
        /// <param name="str">16進数文字列</param>
        /// <returns>バイト配列</returns>
        public static byte[] FromHexString(string str)
        {
            int length = str.Length / 2;
            byte[] bytes = new byte[length];
            int j = 0;
            for (int i = 0; i < length; i++)
            {
                bytes[i] = Convert.ToByte(str.Substring(j, 2), 16);
                j += 2;
            }
            return bytes;
        }

        /// <summary>
        /// バイナリ配列を反転
        /// </summary>
        /// <param name="binaryData">バイナリデータ</param>
        /// <returns>変換結果</returns>
        public static byte[] ReverseBinary(byte[] binaryData)
        {
            byte[] ret = new byte[binaryData.Length];

            Array.Copy(binaryData, ret, binaryData.Length);

            Array.Reverse(ret, 0, binaryData.Length);

            return ret;
        }
    }
}
