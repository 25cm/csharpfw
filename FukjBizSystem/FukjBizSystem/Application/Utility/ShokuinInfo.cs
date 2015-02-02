using FukjBizSystem.Application.DataSet;

namespace FukjBizSystem.Application.Utility
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ShokuinInfo
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/19  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class ShokuinInfo
    {
        #region 静的プロパティ(private)

        /// <summary>
        /// Instance
        /// </summary>
        public static ShokuinInfo Instance;

        #endregion

        #region 静的メソッド(public)

        #region GetShokuinInfo
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetShainInfo
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/19  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static ShokuinInfo GetShokuinInfo()
        {
            // インスタンスが作成されていない場合
            if (Instance == null)
            {
                // インスタンスを作成
                Instance = new ShokuinInfo();
            }

            return Instance;
        }
        #endregion

        #endregion

        #region プロパティ(public)

        /// <summary>
        /// 担当者情報
        /// </summary>
        private ShokuinMstDataSet.ShokuinMstRow shokuin;
        public ShokuinMstDataSet.ShokuinMstRow Shokuin
        {
            get { return shokuin; }
            set { shokuin = value; }
        }

        // TODO add ShozokuMstRow if nessesary

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ShainInfo
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/19  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private ShokuinInfo()
        {
            // 担当者情報初期化
            shokuin = null;
        }
        #endregion
    }
    #endregion
}
