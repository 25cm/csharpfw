
namespace FukjTabletSystem.Application.Utility
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Constants
    /// <summary>
    /// 定数の定義を行うクラスです。
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/22　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class Constants
    {        
        #region マスタテーブル

        /// <summary>
        /// 機能マスタ
        /// </summary>
        public const string TABLENAME_FunctionMst = "FunctionMst";

        /// <summary>
        /// 定数マスタ
        /// </summary>
        public const string TABLENAME_ConstMst = "ConstMst";
        
        /// <summary>
        /// 業者マスタ（製造、工事、保守点検、清掃、持込、収集、取扱）
        /// </summary>
        public const string TABLENAME_GyoshaMst = "GyoshaMst";

        /// <summary>
        /// 保健所マスタ
        /// </summary>
        public const string TABLENAME_HokenjoMst = "HokenjoMst";
        
        /// <summary>
        /// 型式マスタ
        /// </summary>
        public const string TABLENAME_KatashikiMst = "KatashikiMst";

        /// <summary>
        /// 建築用途大分類マスタ
        /// </summary>
        public const string TABLENAME_KenchikuyotoDaibunruiMst = "KenchikuyotoDaibunruiMst";

        /// <summary>
        /// 建築用途マスタ
        /// </summary>
        public const string TABLENAME_KenchikuyotoMst = "KenchikuyotoMst";

        /// <summary>
        /// 建築用途小分類マスタ
        /// </summary>
        public const string TABLENAME_KenchikuyotoShobunruiMst = "KenchikuyotoShobunruiMst";

        /// <summary>
        /// メモ大分類マスタ
        /// </summary>
        public const string TABLENAME_MemoDaibunruiMst = "MemoDaibunruiMst";

        /// <summary>
        /// メモマスタ
        /// </summary>
        public const string TABLENAME_MemoMst = "MemoMst";

        /// <summary>
        /// 名称マスタ
        /// </summary>
        public const string TABLENAME_NameMst = "NameMst";
        
        /// <summary>
        /// 所見マスタ
        /// </summary>
        public const string TABLENAME_ShokenMst = "ShokenMst";

        /// <summary>
        /// 職員マスタ
        /// </summary>
        public const string TABLENAME_ShokuinMst = "ShokuinMst";

        /// <summary>
        /// 処理方式マスタ
        /// </summary>
        public const string TABLENAME_ShoriHoshikiMst = "ShoriHoshikiMst";
        
        /// <summary>
        /// 処理方式別水質検査実施マスタ
        /// </summary>
        public const string TABLENAME_ShoriHoshikiSuishitsuKensaJisshiMst = "ShoriHoshikiSuishitsuKensaJisshiMst";

        /// <summary>
        /// 単位装置グループマスタ
        /// </summary>
        public const string TABLENAME_TaniSochiGroupMst = "TaniSochiGroupMst";

        /// <summary>
        /// 単位装置検査項目別状況マスタ
        /// </summary>
        public const string TABLENAME_TaniSochiKensaJokyoMst = "TaniSochiKensaJokyoMst";

        /// <summary>
        /// 単位装置検査状況別程度マスタ
        /// </summary>
        public const string TABLENAME_TaniSochiKensaJokyoTeidoMst = "TaniSochiKensaJokyoTeidoMst";

        /// <summary>
        /// 単位装置検査項目マスタ
        /// </summary>
        public const string TABLENAME_TaniSochiKensaKomokuMst = "TaniSochiKensaKomokuMst";

        /// <summary>
        /// 単位装置マスタ
        /// </summary>
        public const string TABLENAME_TaniSochiMst = "TaniSochiMst";
        
        /// <summary>
        /// 和暦マスタ
        /// </summary>
        public const string TABLENAME_WarekiMst = "WarekiMst";

        /// <summary>
        /// モニタリンググループマスタ
        /// </summary>
        public const string TABLENAME_MonitoringGroupMst = "MonitoringGroupMst";

        /// <summary>
        /// モニタリング詳細マスタ
        /// </summary>
        public const string TABLENAME_MonitoringShosaiMst = "MonitoringShosaiMst";

        /// <summary>
        /// 法定管理マスタ
        /// </summary>
        public const string TABLENAME_HoteiKanriMst = "HoteiKanriMst";
        
        /// <summary>
        /// 型式別単位装置マスタ
        /// </summary>
        public const string TABLENAME_KatashikiBetsuTaniSochiMst = "KatashikiBetsuTaniSochiMst";

        #endregion

        #region トランザクションデータテーブル
        
        /// <summary>
        /// 現場写真テーブル
        /// </summary>
        public const string TABLENAME_GenbaShashinTbl = "GenbaShashinTbl";
        
        /// <summary>
        /// 浄化槽台帳マスタ
        /// </summary>
        public const string TABLENAME_JokasoDaichoMst = "JokasoDaichoMst";
        
        /// <summary>
        /// 浄化槽保有単位装置グループテーブル
        /// </summary>
        public const string TABLENAME_JokasoHoyuTaniSochiGroupTbl = "JokasoHoyuTaniSochiGroupTbl";

        /// <summary>
        /// 浄化槽定型メモテーブル
        /// </summary>
        public const string TABLENAME_JokasoMemoTbl = "JokasoMemoTbl";

        /// <summary>
        /// 検査依頼関連ファイルテーブル
        /// </summary>
        public const string TABLENAME_KensaIraiKanrenFileTbl = "KensaIraiKanrenFileTbl";

        /// <summary>
        /// 検査依頼テーブル
        /// </summary>
        public const string TABLENAME_KensaIraiTbl = "KensaIraiTbl";

        /// <summary>
        /// 検査依頼履歴テーブル
        /// </summary>
        public const string TABLENAME_KensaIraiHistTbl = "KensaIraiHistTbl";
        
        /// <summary>
        /// 検査結果テーブル
        /// </summary>
        public const string TABLENAME_KensaKekkaTbl = "KensaKekkaTbl";

        /// <summary>
        /// 再採水テーブル
        /// </summary>
        public const string TABLENAME_SaiSaisuiTbl = "SaiSaisuiTbl";

        /// <summary>
        /// 所見結果テーブル
        /// </summary>
        public const string TABLENAME_ShokenKekkaTbl = "ShokenKekkaTbl";

        /// <summary>
        /// 所見結果補足文テーブル
        /// </summary>
        public const string TABLENAME_ShokenKekkaHosokuTbl = "ShokenKekkaHosokuTbl";

        /// <summary>
        /// モニタリングテーブル
        /// </summary>
        public const string TABLENAME_MonitoringTbl = "MonitoringTbl";

        #endregion

        #region 検査状況
        /// <summary>
        /// 検査状況
        /// </summary>
        public static class KensaJoukyouKbn
        {
            public const string INITIAL = "001";

            public const string IN_WORK = "002";

            public const string COMPLETE = "003";

            public const string STOPPED = "004";
        }
        #endregion
    }
    #endregion
}
