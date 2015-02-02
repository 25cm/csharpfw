using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using FukjTabletSystem.Application.Utility;

namespace MapWorksViewer.MapWorks
{
    class SettingFile
    {
  	    //******************************************************************************
        //                           SettingFile
	    //******************************************************************************

	    //******************************************************************************
	    //                           汎用関数(ﾗｲﾌﾞﾗﾘ)
	    //******************************************************************************

        /// <summary>
        /// 設定ファイル名（XML）
        /// </summary>
        public static string xmlFileName = "MapWorksViewer.xml";
        /// <summary>
        /// 設定ファイル情報保持クラス
        /// </summary>
        public static XmlInitial xmlPara = new XmlInitial();

        /// <summary>
        /// XMLファイル読み込み
        /// </summary>
        /// <param name="filePath">XMLファイルパス</param>
        public static void ReadXml(string filePath)
        {
            if (File.Exists(filePath))
            {
                XmlSerializer xs = new XmlSerializer(typeof(XmlInitial));
                FileStream tr = new FileStream(filePath, FileMode.Open);
                try
                {
                    xmlPara = (XmlInitial)xs.Deserialize(tr);
                }
                catch
                {
                    xmlPara = new XmlInitial();
                }
                finally
                {
                    tr.Close();
                }
            }
            else
            {
                xmlPara = new XmlInitial();
            }
        }

        /// <summary>
        /// XMLファイル書き込み
        /// </summary>
        /// <param name="filePath">XMLファイルパス</param>
        public static void WriteXml(string filePath)
        {
            XmlSerializer xs = new XmlSerializer(typeof(XmlInitial));
            TextWriter tw = new StreamWriter(filePath);
            try
            {
                xs.Serialize(tw, xmlPara);
            }
            catch(Exception ex)
            {
                TabMessageBox.Show2(TabMessageBox.Type.Error, "設定ファイル保存エラー", "設定ファイル保存時にエラーが発生しました。\n" + ex.Message);
            }
            finally
            {
                tw.Close();
            }
        }
    }
}
