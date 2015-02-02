
namespace FukjBizSystem.Application.Utility
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： MapLocationUtility
    /// <summary>
    /// 座標変換ユーティリティ
    /// </summary>
    /// <remarks>
    /// 参考:http://www.symmetric.co.jp/blog/archives/37
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/19  豊田　　    新規作成
    /// 2015/01/23  habu　　    日本測地系->世界測地系追加
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public static class MapLocationUtility
    {
        #region WLocToJLoc(double longitudeW, double latitudeW, out double longitudeJ, out double latitudeJ)
        /// <summary>
        /// 世界測地系→日本測地系変換
        /// </summary>
        /// <param name="longitudeW"></param>
        /// <param name="latitudeW"></param>
        /// <param name="longitudeJ"></param>
        /// <param name="latitudeJ"></param>
        /// <returns></returns>
        public static bool WLocToJLoc(double longitudeW, double latitudeW, out double longitudeJ, out double latitudeJ)
        {
            //  タブレットのGPSから取得できる座標は世界測地
            longitudeJ = longitudeW + latitudeW * 0.000046047 + longitudeW * 0.000083049 - 0.010041;
            latitudeJ = latitudeW + latitudeW * 0.00010696 - longitudeW * 0.000017467 - 0.0046020;

            // 2015.1.21 toyoda Add Start 変換結果ログ出力
            Zynas.Framework.Utility.TraceLog.InfoWrite(System.Reflection.MethodInfo.GetCurrentMethod(),
                string.Format("longitudeW={0}, latitudeW={1}, longitudeJ={2}, latitudeJ={3}", longitudeW, latitudeW, longitudeJ, latitudeJ));
            // 2015.1.21 toyoda Add End

            return true;
        }
        #endregion

        #region
        /// <summary>
        /// 日本測地系→世界測地系変換
        /// </summary>
        /// <param name="longitudeW"></param>
        /// <param name="latitudeW"></param>
        /// <param name="longitudeJ"></param>
        /// <param name="latitudeJ"></param>
        /// <returns></returns>
        public static bool JLocToWLoc(double longitudeJ, double latitudeJ, out double longitudeW, out double latitudeW)
        {
            //  タブレットのGPSから取得できる座標は世界測地
            longitudeW = longitudeJ - latitudeJ * 0.000046038 - longitudeJ * 0.000083043 + 0.010040;
            latitudeW = latitudeJ - latitudeJ * 0.00010695 + longitudeJ * 0.000017464 + 0.0046017;

            Zynas.Framework.Utility.TraceLog.InfoWrite(System.Reflection.MethodInfo.GetCurrentMethod(),
                string.Format("longitudeW={0}, latitudeW={1}, longitudeJ={2}, latitudeJ={3}", longitudeW, latitudeW, longitudeJ, latitudeJ));

            return true;
        }
        #endregion

        #region GetMapPoint(double gpsLoc)
        /// <summary>
        /// GPS座標からMAP座標に変換する
        /// </summary>
        /// <param name="gpsLoc"></param>
        /// <returns></returns>
        public static int GetMapPoint(double gpsLoc)
        {
            int 度 = (int)gpsLoc;
            int 分 = (int)((gpsLoc - 度) * 60);
            double 秒 = (int)(((gpsLoc - 度) * 60 - 分) * 60 * 1000) / (double)1000;

            int mapPoint = (int)((度 * 60 * 60 * 1000) + (分 * 60 * 1000) + (秒 * 1000));

            // 2015.1.21 toyoda Add Start 変換結果ログ出力
            Zynas.Framework.Utility.TraceLog.InfoWrite(System.Reflection.MethodInfo.GetCurrentMethod(),
                string.Format("gpsLoc={0}, mapPoint={1}", gpsLoc, mapPoint));
            // 2015.1.21 toyoda Add End

            return mapPoint;
        }
        #endregion

        #region GetLocationPoint
        /// <summary>
        /// MapWorks座標から、GPS座標(緯度または経度)に変換する
        /// </summary>
        /// <param name="mapPoint"></param>
        /// <returns></returns>
        public static double GetLocationPoint(int mapPoint)
        {
            double gpsLoc = 0;

            gpsLoc = (double)mapPoint / 3600000d;

            Zynas.Framework.Utility.TraceLog.InfoWrite(System.Reflection.MethodInfo.GetCurrentMethod(),
                string.Format("gpsLoc={0}, mapPoint={1}", gpsLoc, mapPoint));

            return gpsLoc;
        }
        #endregion

    }
    #endregion
}
