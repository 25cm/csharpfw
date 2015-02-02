using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FukjTabletSystem.Application.Boundary.Kensa.Dialog
{
    #region 所見テーブルのキー
    /// <summary>
    /// 所見テーブルのキー（このキーに対して所見レコード、補足文レコードを返却します）
    /// </summary>
    public class ShokenKey
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ShokenKey()
        {
            // 検査依頼法定区分
            KensaIraiHoteiKbn = string.Empty;
            // 検査依頼保健所コード
            KensaIraiHokenjoCd = string.Empty;
            // 検査依頼年度
            KensaIraiNendo = string.Empty;
            // 検査依頼連番
            KensaIraiRenban = string.Empty;
            // 所見連番
            ShokenRenban = string.Empty;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="kensaIraiHoteiKbn"></param>
        /// <param name="kensaIraiHokenjoCd"></param>
        /// <param name="kensaIraiNendo"></param>
        /// <param name="kensaIraiRenban"></param>
        /// <param name="shokenRenban"></param>
        public ShokenKey(string kensaIraiHoteiKbn,
                    string kensaIraiHokenjoCd,
                    string kensaIraiNendo,
                    string kensaIraiRenban,
                    string shokenRenban)
        {
            // 検査依頼法定区分
            KensaIraiHoteiKbn = kensaIraiHoteiKbn;
            // 検査依頼保健所コード
            KensaIraiHokenjoCd = kensaIraiHokenjoCd;
            // 検査依頼年度
            KensaIraiNendo = kensaIraiNendo;
            // 検査依頼連番
            KensaIraiRenban = kensaIraiRenban;
            // 所見連番
            ShokenRenban = shokenRenban;
        }

        // 検査依頼法定区分
        public string KensaIraiHoteiKbn = string.Empty;
        // 検査依頼保健所コード
        public string KensaIraiHokenjoCd = string.Empty;
        // 検査依頼年度
        public string KensaIraiNendo = string.Empty;
        // 検査依頼連番
        public string KensaIraiRenban = string.Empty;
        // 所見連番
        public string ShokenRenban = string.Empty;
    }
    #endregion
}
