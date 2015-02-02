using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;

namespace Zynas.Framework.Utility
{
    /// <summary>
    /// XML設定ファイルクラス
    /// </summary>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/18　habu　　    新規作成
    /// </history>
    public class PortableSimpleXMLSetting
    {
        // NOTICE Registry , iniへの対応も必要であれば検討する
        // NOTICE SettingProvider準拠は今後の課題とする(普通にやると設定ファイルパスを動的に変更できないので)

        #region Fields

        /// <summary>
        /// 設定ファイルロード・ストアクラス
        /// </summary>
        private PortableSimpleXMLSettingProvider settingBody;

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath">設定ファイルパス</param>
        /// <param name="rootSection">設定ファイル中のセクション名</param>
        /// <param name="keyList">設定項目キーリスト</param>
        /// <param name="dispNameList">設定項目表示名リスト</param>
        public PortableSimpleXMLSetting(string filePath, string rootSection, IEnumerable<string> keyList, IEnumerable<string> dispNameList)
        {
            settingBody = new PortableSimpleXMLSettingProvider(filePath, rootSection, keyList, dispNameList);
        }

        /// <summary>
        /// 設定値キーのリストを取得する
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GeyKeys()
        {
            return settingBody.GetKeys();
        }

        /// <summary>
        /// 設定値を取得する
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetValue(string key)
        {
            return (string)settingBody.GetValue(key);
        }

        /// <summary>
        /// 設定値画面表示名を取得する
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetDispName(string key)
        {
            return (string)settingBody.GetDispName(key);
        }

        /// <summary>
        /// 設定値を書込む
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetValue(string key, string value)
        {
            settingBody.SetValue(key, value);
        }

        /// <summary>
        /// 設定ファイル情報を読込む
        /// </summary>
        public void Load()
        {
            settingBody.ReadXMLSettings();
        }

        /// <summary>
        /// 設定ファイル情報を保存する
        /// </summary>
        public void Save()
        {
            settingBody.WriteXMLSettings();
        }

        #region CustormSettingProvider Class

        /// <summary>
        /// カスタムXML設定ファイル保存・読込用
        /// </summary>
        class PortableSimpleXMLSettingProvider : SettingsProvider
        {
            /// <summary>
            /// XML設定ファイル名
            /// </summary>
            private string _settingFilePath = null;

            /// <summary>
            /// ルートセクション名
            /// </summary>
            private string _rootSection = null;

            /// <summary>
            /// 設定ファイルキーリスト
            /// </summary>
            private IEnumerable<string> _keyList = null;

            /// <summary>
            /// 設定ファイル表示名リスト
            /// </summary>
            private IEnumerable<string> _dispNameList = null;

            /// <summary>
            /// セクション名を省略した場合は、[Common]が使用される
            /// </summary>
            private const string DEFAULT_SECTION = "common";

            /// <summary>
            /// XMLより読込んだ設定値
            /// </summary>
            private Dictionary<string, string> _settingMap = new Dictionary<string, string>();

            /// <summary>
            /// XMLより読込んだ表示名
            /// </summary>
            private Dictionary<string, string> _dispNameMap = new Dictionary<string, string>();

            /// <summary>
            /// 
            /// </summary>
            /// <param name="settingFilePath"></param>
            /// <param name="rootSection"></param>
            /// <param name="keyList"></param>
            /// <param name="dispNameList"></param>
            public PortableSimpleXMLSettingProvider(string settingFilePath, string rootSection, IEnumerable<string> keyList, IEnumerable<string> dispNameList)
            {
                _settingFilePath = settingFilePath;
                _rootSection = rootSection;
                _keyList = keyList;
                _dispNameList = dispNameList;

                // XML読み込み
                ReadXMLSettings();
            }

            #region Constructor Overrides

            /// <summary>
            /// 
            /// </summary>
            /// <param name="settingFilePath"></param>
            /// <param name="rootSection"></param>
            public PortableSimpleXMLSettingProvider(string settingFilePath, string rootSection)
            {
                _settingFilePath = settingFilePath;
                _rootSection = rootSection;
                _keyList = null;

                // XML読み込み
                ReadXMLSettings();
            }

            /// <summary>
            /// セクション名を省略した場合は、[common]が使用される
            /// </summary>
            /// <param name="settingFilePath"></param>
            public PortableSimpleXMLSettingProvider(string settingFilePath) :
                this(settingFilePath, DEFAULT_SECTION)
            {

            }

            #endregion

            /// <summary>
            /// XML内の全ての設定内容を読込む
            /// </summary>
            /// <returns></returns>
            public void ReadXMLSettings()
            {
                // キー項目が指定されている場合、未設定でもデフォルト値を取得する
                if (_keyList != null)
                {
                    int idxTemp = 0;
                    foreach (string defKey in _keyList)
                    {
                        if (!_settingMap.ContainsKey(defKey))
                        {
                            _settingMap.Add(defKey, string.Empty);
                        }
                        string defDispName = defKey;

                        if (_dispNameList.Count() - 1 >= idxTemp)
                        {
                            defDispName = _dispNameList.ElementAt<string>(idxTemp);
                        }

                        if (!_dispNameMap.ContainsKey(defKey))
                        {
                            _dispNameMap.Add(defKey, defDispName);
                        }

                        idxTemp++;
                    }
                }

                // 存在しない場合はスキップ
                if (!File.Exists(_settingFilePath))
                {
                    return;
                }

                XmlTextReader reader = new XmlTextReader(new StreamReader(_settingFilePath));

                reader.Read();

                string key = null;
                string value = null;

                while (!reader.EOF)
                {
                    if (reader.IsStartElement(_rootSection))
                    {
                        // NOTICE 今後の課題:既定外のセクションはスキップする(今回はPrinter.xml専用なので、問題ない)
                    }

                    if (reader.IsStartElement("setting"))
                    {
                        reader.ReadAttributeValue();
                        key = reader.GetAttribute("name");

                        reader.Read();
                    }
                    else if (reader.IsStartElement("value"))
                    {
                        value = reader.ReadElementString("value");

                        if (!string.IsNullOrEmpty(key))
                        {
                            if (_keyList != null && _keyList.Contains<string>(key))
                            {
                                if (!_settingMap.ContainsKey(key))
                                {
                                    _settingMap.Add(key, value);
                                }
                                else
                                {
                                    _settingMap[key] = value;
                                }
                            }

                            key = null;
                        }
                    }
                    else
                    {

                        reader.Read();
                    }
                }

                reader.Close();
            }

            /// <summary>
            /// 全ての設定内容を書込む
            /// </summary>
            public void WriteXMLSettings()
            {
                XmlTextWriter writer = new XmlTextWriter(new StreamWriter(_settingFilePath));

                // 自動インデントを有効にする
                writer.Formatting = Formatting.Indented;

                writer.WriteStartDocument();

                writer.WriteStartElement(_rootSection);

                foreach (string settingKey in _settingMap.Keys)
                {
                    string settingValue = _settingMap[settingKey];

                    writer.WriteStartElement("setting");

                    writer.WriteAttributeString("name", settingKey);

                    writer.WriteStartElement("value");

                    writer.WriteValue(settingValue);

                    writer.WriteEndElement();

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();

                writer.WriteEndDocument();

                writer.Close();
            }

            public IEnumerable<string> GetKeys()
            {
                return _settingMap.Keys;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="key"></param>
            /// <returns></returns>
            public string GetValue(string key)
            {
                return _settingMap[key];
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="key"></param>
            /// <returns></returns>
            public string GetDispName(string key)
            {
                return _dispNameMap[key];
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="key"></param>
            /// <param name="value"></param>
            public void SetValue(string key, string value)
            {
                if (!_settingMap.ContainsKey(key))
                {
                    _settingMap.Add(key, value);
                }
                else
                {
                    _settingMap[key] = value;
                }
            }

            #region SettingsProvider Overrides

            /// <summary>
            /// 
            /// </summary>
            public override string ApplicationName
            {
                get { return Assembly.GetExecutingAssembly().GetModules()[0].Name.ToString(); }
                set { }
            }

            #region GetPropertyValues
            /// <summary>
            /// 
            /// </summary>
            /// <param name="context"></param>
            /// <param name="collection"></param>
            /// <returns></returns>
            public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection collection)
            {
                SettingsPropertyValueCollection col = new SettingsPropertyValueCollection();

                foreach (SettingsProperty setting in collection)
                {
                    SettingsPropertyValue val = new SettingsPropertyValue(setting);

                    val.IsDirty = false;
                    try
                    {
                        val.SerializedValue = _settingMap[setting.Name];
                    }
                    catch (Exception e)
                    {
                        throw (new ConfigurationErrorsException("Key not found!", e));
                    }

                    col.Add(val);
                }

                return col;
            }
            #endregion

            #region SetPropertyValues
            /// <summary>
            /// 
            /// </summary>
            /// <param name="context"></param>
            /// <param name="collection"></param>
            public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection collection)
            {
                foreach (SettingsPropertyValue value in collection)
                {
                    try
                    {
                        if (value.IsDirty)
                        {
                            _settingMap[value.Name] = (string)value.SerializedValue;

                            value.IsDirty = false;

                            WriteXMLSettings();
                        }
                    }
                    catch (Exception e)
                    {
                        throw (new ConfigurationErrorsException("Key not found!", e));
                    }
                }
            }
            #endregion

            #region Initialize
            /// <summary>
            /// 
            /// </summary>
            /// <param name="name"></param>
            /// <param name="config"></param>
            public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
            {
                base.Initialize(ApplicationName, config);
            }
            #endregion

            #endregion

        }

        #endregion
    }
}
