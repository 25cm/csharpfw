namespace FukjBizSystem.Application.DataSet
{
    public partial class SeikyuShimeSyoriWrkDataSet
    {
    }
}

namespace FukjBizSystem.Application.DataSet.SeikyuShimeSyoriWrkDataSetTableAdapters
{
    #region SeikyuShimeTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/26  habu　  新規作成
    /// </history>
    public partial class SeikyuShimeTableAdapter
    {
        #region CommandTimeout
        // コマンドタイムアウト設定（単位は秒）
        public int CommandTimeout
        {
            get { return CommandCollection[0].CommandTimeout; }
            set
            {
                for (int i = 0; i < this.CommandCollection.Length; ++i)
                {
                    if (CommandCollection[i] != null)
                    {
                        ((System.Data.SqlClient.SqlCommand)(this.CommandCollection[i])).CommandTimeout = value;
                    }
                }
            }
        }
        #endregion
    }
    #endregion
}
