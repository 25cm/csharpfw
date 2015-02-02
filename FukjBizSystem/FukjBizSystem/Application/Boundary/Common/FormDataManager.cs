using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FukjBizSystem.Application.Boundary.Common
{
    /// <summary>
    /// FormData To Manager class.
    /// For purpose of form state save/restore on form transition
    /// </summary>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/17  habu　　　  新規作成
    /// </history>
    public class FormData
    {
        #region static

        private static FormData _instance;

        static FormData()
        {
            _instance = new FormData();
        }

        #endregion

        #region Fields

        private Dictionary<string, Dictionary<string, object>> formDataMap;

        #endregion

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        FormData()
        {
            formDataMap = new Dictionary<string, Dictionary<string, object>>();
        }

        #endregion

        #region Load
        /// <summary>
        /// Load set of FormData from Manager
        /// </summary>
        /// <param name="formNameId">formName. Typycally class name of Form</param>
        /// <returns>Dictionary(Map) of formData</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/17  habu　　　  新規作成
        /// </history>
        public static Dictionary<string, object> Load(string formNameId)
        {
            if (!_instance.formDataMap.ContainsKey(formNameId))
            {
                _instance.formDataMap.Add(formNameId, new Dictionary<string, object>());
            }

            return _instance.formDataMap[formNameId];
        }
        #endregion

        /// <summary>
        /// Load one property data from FormData Manager
        /// </summary>
        /// <param name="formNameId">formName. Typycally class name of Form</param>
        /// <param name="formData">Dictionary(Map) of formData</param>
        /// <returns>form data value. returns null if not set</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/17  habu　　　  新規作成
        /// </history>
        public static object LoadValue(string formNameId, string formPropertyName)
        {
            Dictionary<string, object> formData = Load(formNameId);

            if (!formData.ContainsKey(formPropertyName))
            {
                return null;
            }
            else
            {
                return formData[formPropertyName];
            }
        }

        #region Save
        /// <summary>
        /// Save set of FormData to Manager
        /// </summary>
        /// <param name="formNameId">formName. Typycally class name of Form</param>
        /// <param name="formData">Dictionary(Map) of formData</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/17  habu　　　  新規作成
        /// </history>
        public static void Save(string formNameId, Dictionary<string, object> formData)
        {
            if (!_instance.formDataMap.ContainsKey(formNameId))
            {
                _instance.formDataMap.Add(formNameId, formData);
            }
            else
            {
                // overwrites existing
                _instance.formDataMap[formNameId] = formData;
            }
        }
        #endregion

        #region SaveValue
        /// <summary>
        /// Save one property data to FormData Manager
        /// </summary>
        /// <param name="formNameId">formName. Typycally class name of Form</param>
        /// <param name="formPropertyName">form data key</param>
        /// <param name="value">form data value</param>
        public static void SaveValue(string formNameId, string formPropertyName, object value)
        {
            Dictionary<string, object> formData = Load(formNameId);

            if (!formData.ContainsKey(formPropertyName))
            {
                formData.Add(formPropertyName, value);
            }
            else
            {
                formData[formPropertyName] = value;
            }
        }
        #endregion

        #region Clear
        /// <summary>
        /// 
        /// </summary>
        public static void Clear()
        {
            // clear all of form data
            _instance.formDataMap.Clear();
        }
        #endregion

    }
}
