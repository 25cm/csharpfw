using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zynas.Control.Common
{
    // NOTICE 地区割コードを追加する -> 現状は特に使用されていないため、不要

    #region ZTextBox用のドメイン
    /// <summary>
    /// テキストボックス用のドメイン
    /// </summary>
    public enum ZControlDomain
    {
        /// <summary>
        /// 指定なし
        /// </summary>
        NONE,

        #region ZTextBox
        /// <summary>
        /// 標準名称入力
        /// </summary>
        ZT_STD_NAME,
        /// <summary>
        /// 標準名称入力(カナ)
        /// </summary>
        ZT_STD_NAME_KANA,
        /// <summary>
        /// 標準名称入力(半角カナ)
        /// </summary>
        ZT_STD_NAME_KANA_HALF,
        /// <summary>
        /// 標準名称入力(デフォルト半角カナ、全角カナ許容)
        /// </summary>
        ZT_STD_NAME_KANA_HALF_BOTH,
        /// <summary>
        /// 標準コード入力
        /// </summary>
        ZT_STD_CD,
        /// <summary>
        /// 標準数値入力
        /// </summary>
        ZT_STD_NUM,
        /// <summary>
        /// 標準英数字入力
        /// </summary>
        ZT_STD_ALPHA_NUM,
        /// <summary>
        /// 法定区分
        /// </summary>
        ZT_HOTEI_KBN,
        /// <summary>
        /// 保健所コード
        /// </summary>
        ZT_HOKENJO_CD,
        /// <summary>
        /// 支所コード
        /// </summary>
        ZT_SHISHO_CD,
        /// <summary>
        /// 年度
        /// </summary>
        ZT_NENDO,
        /// <summary>
        /// 日付
        /// </summary>
        ZT_DT,
        /// <summary>
        /// 年月日
        /// </summary>
        ZT_YMD,
        /// <summary>
        /// 年(和暦)
        /// </summary>
        ZT_NEN_WAREKI,
        /// <summary>
        /// 年
        /// </summary>
        ZT_NEN,
        /// <summary>
        /// 月
        /// </summary>
        ZT_TSUKI,
        /// <summary>
        /// 日
        /// </summary>
        ZT_BI,
        /// <summary>
        /// フラグ
        /// </summary>
        ZT_FLG,
        /// <summary>
        /// 電話番号
        /// </summary>
        ZT_TEL_NO,
        /// <summary>
        /// 郵便番号
        /// </summary>
        ZT_ZIP_CD,
        /// <summary>
        /// 設置者区分
        /// </summary>
        ZT_SETCHISHA_KBN,
        /// <summary>
        /// 設置者コード
        /// </summary>
        ZT_SETCHISHA_CD,
        /// <summary>
        /// 検査員コード
        /// </summary>
        ZT_KENSAIN_CD,
        /// <summary>
        /// 地区コード
        /// </summary>
        ZT_CHIKU_CD,
        /// <summary>
        /// 採水員コード
        /// </summary>
        ZT_SAISUIIN_CD,
        /// <summary>
        /// 業者コード
        /// </summary>
        ZT_GYOSHA_CD,
        /// <summary>
        /// 住所
        /// </summary>
        ZT_ADR,
        /// <summary>
        /// 年月
        /// </summary>
        ZT_NEN_GETSU,

        /// <summary>
        /// 区分
        /// </summary>
        ZT_KBN,
        #endregion

        #region CustomNumber
        /// <summary>
        /// 手数料単価
        /// </summary>
        ZN_TESURYO_TANKA,
        /// <summary>
        /// チケット枚数
        /// </summary>
        ZN_TICKET_NUM,
        /// <summary>
        /// 伝票明細番号
        /// </summary>
        ZN_DENPYO_DTL,
        /// <summary>
        /// 世代管理日付
        /// </summary>
        ZN_SEDAI_MNG_DT,
        /// <summary>
        /// 在庫履歴番号
        /// </summary>
        ZN_ZAIKO_RIREKI_NO,
        /// <summary>
        /// 金額
        /// </summary>
        ZN_AMT,
        /// <summary>
        /// ECサイトKey
        /// </summary>
        ZN_ECSITE_KEY,
        /// <summary>
        /// 単価
        /// </summary>
        ZN_TANKA,
        /// <summary>
        /// 表示順
        /// </summary>
        ZN_HYOJI,

        #region DatNT

        /// <summary>
        /// HokenjoCd
        /// </summary>
        ZN_HOKENJOCD,

        #endregion

        #endregion

        #region ZDataGridView

        /// <summary>
        /// 標準名称入力
        /// </summary>
        ZG_STD_NAME,
        /// <summary>
        /// 標準名称入力(カナ)
        /// </summary>
        ZG_STD_NAME_KANA,
        /// <summary>
        /// 標準名称入力(半角カナ)
        /// </summary>
        ZG_STD_NAME_KANA_HALF,
        /// <summary>
        /// 標準コード入力
        /// </summary>
        ZG_STD_CD,
        /// <summary>
        /// 標準数値入力
        /// </summary>
        ZG_STD_NUM,
        /// <summary>
        /// 電話番号
        /// </summary>
        ZG_TEL_NO,
        /// <summary>
        /// 郵便番号
        /// </summary>
        ZG_ZIP_CD,

        #endregion

    }
    #endregion

}
