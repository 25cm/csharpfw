using System;
using System.Reflection;
using Microsoft.WindowsAPICodePack.Sensors;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.Utility
{
    /// <summary>
    /// GPS位置情報取得クラス
    /// </summary>
    public class LocationGpsInfo
    {
        #region 定数

        /// <summary>
        /// センサータイプ
        /// </summary>
        private static Guid SENSOR_TYPE_LOCATION_GPS = new Guid("ED4CA589-327A-4FF9-A560-91DA4B48275E");

        /// <summary>
        /// データタイプ
        /// </summary>
        private static Guid SENSOR_DATA_TYPE_LOCATION_GUID = new Guid("055C74D8-CA6F-47D6-95C6-1ED3637A0FF4");

        /// <summary>
        /// 受信ステータス
        /// </summary>
        private enum ReadStatus
        {
            // 開始中
            Start,

            // 停止中
            Stoped,
        }

        #endregion

        #region フィールド

        /// <summary>
        /// デバイス利用可能状態
        /// </summary>
        private static bool _isEnabled = false;

        /// <summary>
        /// 位置情報センサ
        /// </summary>
        private static Sensor GeolocationSensor;

        /// <summary>
        /// インスタンス
        /// </summary>
        private static LocationGpsInfo _locationGpsInfo = new LocationGpsInfo();
                        
        /// <summary>
        /// 受信開始状態
        /// </summary>
        private static ReadStatus _status = ReadStatus.Stoped;
        
        /// <summary>
        /// 取得日
        /// </summary>
        private static DateTime? _latestUpdateDateOnce = null;
        public static DateTime? LatestUpdateDateOnce
        {
            get
            {
                return _latestUpdateDateOnce;
            }
        }

        /// <summary>
        /// 緯度
        /// </summary>
        private static double _latitudeOnce = 0;
        public static double LatitudeOnce
        {
            get
            {
                return _latitudeOnce;
            }
        }

        /// <summary>
        /// 経度
        /// </summary>
        private static double _longitudeOnce = 0;
        public static double LongitudeOnce
        {
            get
            {
                return _longitudeOnce;
            }
        }

        /// <summary>
        /// 取得日
        /// </summary>
        private static DateTime? _latestUpdateDate = null;
        public static DateTime? LatestUpdateDate
        {
            get
            {
                return _latestUpdateDate;
            }
        }

        /// <summary>
        /// 緯度
        /// </summary>
        private static double _latitude = 0;
        public static double Latitude
        {
            get
            {
                return _latitude;
            }
        }

        /// <summary>
        /// 経度
        /// </summary>
        private static double _longitude = 0;
        public static double Longitude
        {
            get
            {
                return _longitude;
            }
        }

        #endregion

        #region LocationGpsInfo()
        /// <summary>
        /// コンストラクタ
        /// </summary>
        private LocationGpsInfo()
        {
            try
            {
                TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

                // センサの取得
                SensorList<Sensor> list = SensorManager.GetSensorsByTypeId(SensorTypes.LocationGps);

                GeolocationSensor = list[0];

                GeolocationSensor.AutoUpdateDataReport = false;

                _isEnabled = true;
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.Message);

                _isEnabled = false;
            }
            finally
            {
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion
        
        #region DataReportChanged(Sensor sender, EventArgs e)
        /// <summary>
        /// イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void DataReportChanged(Sensor sender, EventArgs e)
        {
            foreach (Guid formatId in sender.DataReport.Values.Keys)
            {
                if (formatId == SENSOR_DATA_TYPE_LOCATION_GUID)
                {
                    // 位置情報を更新
                    _latitude = (double)sender.DataReport.Values[formatId][0];
                    _longitude = (double)sender.DataReport.Values[formatId][1];
                    _latestUpdateDate = DateTime.Now;
                }
            }
        }
        #endregion
        
        #region DataReportChangedOnce(Sensor sender, EventArgs e)
        /// <summary>
        /// イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void DataReportChangedOnce(Sensor sender, EventArgs e)
        {
            foreach (Guid formatId in sender.DataReport.Values.Keys)
            {
                if (formatId == SENSOR_DATA_TYPE_LOCATION_GUID)
                {
                    // 位置情報を更新
                    _latitudeOnce = (double)sender.DataReport.Values[formatId][0];
                    _longitudeOnce = (double)sender.DataReport.Values[formatId][1];
                    _latestUpdateDateOnce = DateTime.Now;
                }
            }
        }
        #endregion

        #region StartRead()
        /// <summary>
        /// デバイスの読み込み
        /// </summary>
        public static bool StartRead()
        {
            try
            {
                TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

                if (_isEnabled)
                {
                    if (_status == ReadStatus.Stoped)
                    {
                        _latitude = 0;
                        _longitude = 0;
                        _latestUpdateDate = null;

                        GeolocationSensor.DataReportChanged += DataReportChanged;
                        GeolocationSensor.AutoUpdateDataReport = true;

                        _status = ReadStatus.Start;
                    }
                    
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.Message);

                return false;
            }
            finally
            {
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region StopRead()
        /// <summary>
        /// デバイスの読み込み＆受信開始
        /// </summary>
        public static void StopRead()
        {
            try
            {
                TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

                if (_isEnabled)
                {
                    if (_status == ReadStatus.Start)
                    {
                        GeolocationSensor.AutoUpdateDataReport = false;
                        GeolocationSensor.DataReportChanged -= DataReportChanged;

                        _status = ReadStatus.Stoped;
                    }
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
        
        #region ReadOnce()
        /// <summary>
        /// デバイスの読み込み（同期処理）
        /// </summary>
        public static bool ReadOnce(int timeout)
        {
            try
            {
                TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

                if (_isEnabled)
                {
                    _latitudeOnce = 0;
                    _longitudeOnce = 0;
                    _latestUpdateDateOnce = null;
                    
                    if(_status == ReadStatus.Start)
                    {
                        GeolocationSensor.AutoUpdateDataReport = false;

                        GeolocationSensor.DataReportChanged -= DataReportChanged;                        
                    }

                    GeolocationSensor.DataReportChanged += DataReportChangedOnce;

                    bool ret = false;

                    DateTime startTime = DateTime.Now;

                    while(true)
                    {
                        ret = GeolocationSensor.TryUpdateData();
                        
                        if (ret)
                        {
                            break;
                        }

                        // タイムアウト
                        if ((DateTime.Now - startTime) > TimeSpan.FromSeconds(timeout))
                        {
                            break;
                        }

                        System.Threading.Thread.Sleep(500);
                    }

                    GeolocationSensor.DataReportChanged -= DataReportChangedOnce;

                    if (_status == ReadStatus.Start)
                    {
                        GeolocationSensor.DataReportChanged += DataReportChanged;

                        GeolocationSensor.AutoUpdateDataReport = true;
                    }
                    
                    return ret;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.Message);

                return false;
            }
            finally
            {
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion        
    }
}
