using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Zynas.Framework.Utility;

namespace Zynas.Control.Setting
{
    /// <summary>
    /// 設定ファイル編集ベース画面
    /// </summary>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/18　habu　　    新規作成
    /// </history>
    public partial class SettingControl : Form
    {
        // TODO 複数項目で設定値リストが異なる場合を考慮できると良い

        #region プロパティ

        /// <summary>
        /// 設定ファイルオブジェクト
        /// </summary>
        public PortableSimpleXMLSetting Setting { get; set; }

        #endregion

        #region フィールド

        private IEnumerable<string> _settingKeyList = null;
        private IEnumerable<string> _settingValueList = null;
        private IEnumerable<string> _settingDispNameList = null;

        private Dictionary<string, string> cachedSettingData;

        private IEnumerable<string> _itemList;

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public SettingControl()
        {
            InitializeComponent();

            cachedSettingData = new Dictionary<string, string>();
        }

        #region public method

        /// <summary>
        /// 設定項目値リストを設定する
        /// </summary>
        /// <remarks>
        /// 画面表示前に実行する事
        /// </remarks>
        /// <param name="itemList"></param>
        public void AddItemList(IEnumerable<string> itemList)
        {
            _itemList = itemList;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrinterSetting_Load(object sender, EventArgs e)
        {
            PortableSimpleXMLSetting setting = Setting;
            setting.Load();

            _settingKeyList = setting.GeyKeys().ToArray<string>();

            List<string> valueList = new List<string>();
            foreach (string key in _settingKeyList)
            {
                valueList.Add(setting.GetValue(key));
            }
            _settingValueList = valueList.ToArray<string>();

            List<string> dispNameList = new List<string>();
            foreach (string key in _settingKeyList)
            {
                dispNameList.Add(setting.GetDispName(key));
            }
            _settingDispNameList = dispNameList.ToArray<string>();

            SetItems();
        }

        #region entryButton_Click
        /// <summary>
        /// 画面上設定データを設定ファイルに保存する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void entryButton_Click(object sender, EventArgs e)
        {
            PortableSimpleXMLSetting setting = Setting;

            // データ設定
            foreach (string key in cachedSettingData.Keys)
            {
                setting.SetValue(key, cachedSettingData[key]);
            }

            // ファイル保存実行
            setting.Save();

            Close();
        }
        #endregion

        #region closeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region SetItems
        /// <summary>
        /// 画面上の生成項目を生成する
        /// </summary>
        protected void SetItems()
        {
            // TODO レイアウト調整は必要なら変更も検討
            itemLayoutPanel.WrapContents = false;
            itemLayoutPanel.FlowDirection = FlowDirection.TopDown;

            for (int i = 0; i < _settingKeyList.Count<string>(); i++)
            {
                // Generate Setting Item
                {
                    // TODO Value直接入力の仕様も必要であれば検討する(テキストボックス、入力可コンボボックスなど、)
                    // Generate Item Template
                    Panel itemPanel = new Panel();
                    Label itemNameLabel = new Label();
                    ComboBox itemValueComboBox = new ComboBox();

                    string keyName = _settingKeyList.ElementAt<string>(i);
                    string dispName = _settingDispNameList.ElementAt<string>(i);
                    string value = _settingValueList.ElementAt<string>(i);

                    // Setting Control Data
                    itemNameLabel.Text = dispName;
                    itemNameLabel.Location = new Point(0, 0);
                    itemNameLabel.AutoSize = true;
                    itemPanel.Controls.Add(itemNameLabel);

                    itemValueComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                    string[] items = (string[])_itemList.ToArray<string>().Clone();
                    // TODO SelectedValueでは設定できなかったので、SelectedIndexを指定することにする
                    int selIdx = -1;
                    for (int j = 0; j < items.Length; j++)
                    {
                        if (items[j] == value)
                        {
                            selIdx = j;
                        }
                    }
                    itemValueComboBox.Items.AddRange(items);
                    itemValueComboBox.SelectedIndex = selIdx;
                    itemValueComboBox.Location = new Point(80, 0);
                    itemValueComboBox.Size = new Size(250, 21);
                    itemPanel.Controls.Add(itemValueComboBox);

                    itemPanel.MinimumSize = new Size(350, 30);

                    itemLayoutPanel.Controls.Add(itemPanel);

                    // Setting Value Change Handler Event
                    itemValueComboBox.SelectedIndexChanged += delegate(object sender, EventArgs e)
                    {

                        if (!cachedSettingData.ContainsKey(keyName))
                        {
                            cachedSettingData.Add(keyName, itemValueComboBox.Text);
                        }
                        else
                        {
                            cachedSettingData[keyName] = itemValueComboBox.Text;
                        }
                    };
                }
            }
        }
        #endregion

    }
}
