using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace FukjBizSystem.Application.DataSet {
    
    
    public partial class SuishitsuNippoHdrTblDataSet {
    }
}

namespace FukjBizSystem.Application.DataSet.SuishitsuNippoHdrTblDataSetTableAdapters
{
	public partial class SuishitsuNippoHdrTblTableAdapter
	{

	}

	public partial class SuishitsuNippoStdTableAdapter
	{
		// こちらを直接呼んでも取得できません。プロシジャ名指定("dbo."+"プロシジャ名")の方で呼び出してください。
		public int? GetReturnValue(int index)
		{
			SqlParameter param = (SqlParameter)this.CommandCollection[index].Parameters["@RETURN_VALUE"];
			return (int?)param.Value;
		}

		// こちらの型式で呼び出すこと。
		public int? GetReturnValue(string procName)
		{
			string procNameLower = procName.ToLower();

			for (int i = 0; i < this.CommandCollection.Length; i++)
			{
				if (CommandCollection[i].CommandText.ToLower() == procNameLower)
				{
					return this.GetReturnValue(i);
				}
			}
			throw new Exception("指定されたストアドは、呼び出されていません。");
		}

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
}
