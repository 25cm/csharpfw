using System.Drawing;
using System.Windows.Forms;
using Zynas.Framework.Core.Base.Common;

namespace Zynas.Framework.Core.Common.Boundary
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FormLocation
    /// <summary>
    /// フォーム表示位置の取得／保存
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2010/04/08　稗田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class FormLocation : Registry
    {
        #region プロパティ(protected)

        /// <summary>
        /// レジストリキー(固有部分)
        /// </summary>
        protected override string NativeKeyName
        {
            get { return _NativeKeyName; }
        }

        #endregion

        #region プロパティ(private)

        /// <summary>
        /// レジストリキー(固有部分)
        /// </summary>
        private const string _NativeKeyName = @"FormLocation";

        /// <summary>
        /// 
        /// </summary>
        private static Point DEF_POINT = new Point(0, 0);

        #endregion

        #region メソッド(public)

        #region GetPoint
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetPoint
        /// <summary>
        /// フォーム表示位置を取得する
        /// </summary>
        /// <param name="user">利用者ID</param>
        /// <param name="form">フォーム</param>
        /// <param name="defPoint">初期表示位置</param>
        /// <returns>フォーム表示位置</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/04/08　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public Point GetPoint(string user, Form form, Point defPoint)
        {
            // 値を取得し位置に変換
            Point point = StringToPoint((string)Read(user, form.Name + "_Location", PointToString(defPoint)));

            // 保存されている位置を含むモニターが存在する場合
            if (ExistScreen(point, form.Size))
            {
                // 変換した位置を戻す
                return point;
            }

            // 初期表示位置を戻す
            return defPoint;
        }
        #endregion

        #region GetPoint
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="form"></param>
        /// <param name="defPoint"></param>
        /// <returns></returns>
        public Point GetPoint(string user, Form form)
        {
            return GetPoint(user, form, DEF_POINT);
        }
        #endregion

        #region SetPoint
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetPoint
        /// <summary>
        /// フォーム表示位置を保存する
        /// </summary>
        /// <param name="user">利用者ID</param>
        /// <param name="form">フォーム</param>
        /// <param name="setPoint">保存位置</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/04/08　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public void SetPoint(string user, Form form, Point setPoint)
        {
            // 文字列に変換し値を設定
            Write(user, form.Name + "_Location", PointToString(setPoint));
        }
        #endregion

        #region GetSize
        /// <summary>
        /// フォーム表示位置を取得する
        /// </summary>
        /// <param name="user">利用者ID</param>
        /// <param name="form">フォーム</param>
        /// <param name="defValue">初期表示位置</param>
        /// <returns>フォーム表示位置</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/04　土生　　    新規作成
        /// </history>
        public Size GetSize(string user, Form form, Size defValue)
        {
            // 値を取得し位置に変換
            Size point = StringToSize((string)Read(user, form.Name + "_Size", SizeToString(defValue)));

            // 変換した位置を戻す
            return point;

            // 初期表示位置を戻す
            //return defValue;
        }
        #endregion

        #region SetSize
        /// <summary>
        /// フォーム表示位置を取得する
        /// </summary>
        /// <param name="user">利用者ID</param>
        /// <param name="form">フォーム</param>
        /// <param name="defValue">初期表示位置</param>
        /// <returns>フォーム表示位置</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/04　土生　　    新規作成
        /// </history>
        public void SetSize(string user, Form form, Size setValue)
        {
            // 文字列に変換し値を設定
            Write(user, form.Name + "_Size", SizeToString(setValue));
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region ExistScreen
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ExistScreen
        /// <summary>
        /// 指定された位置を含むモニターがあるかチェックを行う
        /// </summary>
        /// <param name="point">チェックを行う位置</param>
        /// <returns>成否</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/04/08　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool ExistScreen(Point point, Size size)
        {
            // モニター分繰返し
            foreach (Screen sc in Screen.AllScreens)
            {
                // 指定された位置を含むモニターがあるかチェック
                if (sc.Bounds.Left - (size.Width - 60) <= point.X
                 && point.X < sc.Bounds.Right - 60
                 && sc.Bounds.Top - 15 <= point.Y
                 && point.Y < sc.WorkingArea.Height - 60)
                {
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region PointToString
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： PointToString
        /// <summary>
        /// 指定された位置を位置文字列に変換する
        /// </summary>
        /// <param name="point">文字列に変換する位置</param>
        /// <returns>位置文字列</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/04/08　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string PointToString(Point point)
        {
            // 位置を位置文字列に変換
            return point.X.ToString() + "," + point.Y.ToString();
        }
        #endregion

        #region StringToPoint
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： StringToPoint
        /// <summary>
        /// 指定された位置文字列を位置に変換する
        /// </summary>
        /// <param name="str">位置に変換する位置文字列</param>
        /// <returns>位置文字列</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/04/08　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private Point StringToPoint(string str)
        {
            // 文字列を位置に変換
            string[] stringList = str.Split(',');
            Point point = new Point();
            point.X = int.Parse(stringList[0]);
            point.Y = int.Parse(stringList[1]);

            return point;
        }
        #endregion

        /// <summary>
        /// 指定された位置文字列を位置に変換する
        /// </summary>
        /// <param name="str">位置に変換する位置文字列</param>
        /// <returns>位置文字列</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/04　土生　　    新規作成
        /// </history>
        private string SizeToString(Size obj)
        {
            // 位置を位置文字列に変換
            return obj.Width.ToString() + "," + obj.Height.ToString();
        }

        #region StringToPoint
        /// <summary>
        /// 指定された位置文字列を位置に変換する
        /// </summary>
        /// <param name="str">位置に変換する位置文字列</param>
        /// <returns>位置文字列</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/04　土生　　    新規作成
        /// </history>
        private Size StringToSize(string str)
        {
            // 文字列を位置に変換
            string[] stringList = str.Split(',');
            Size obj = new Size();
            obj.Width = int.Parse(stringList[0]);
            obj.Height = int.Parse(stringList[1]);

            return obj;
        }
        #endregion

        #endregion

    }
    #endregion
}
