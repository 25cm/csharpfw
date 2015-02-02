using FukjTabletSystem.Application.ApplicationLogic.Common;
using FukjTabletSystem.Application.DataSet.SQLCE;

namespace FukjTabletSystem.Application.Utility
{
    /// <summary>
    /// 名称マスタ取得クラス
    /// </summary>
    public class NameMstList
    {
        #region Get(string nameKbn)
        /// <summary>
        /// 名称マスタテーブルを取得（名称区分）
        /// </summary>
        /// <param name="nameKbn"></param>
        /// <returns></returns>
        public static NameMstDataSet.NameMstDataTable Get(string nameKbn)
        {
            IGetNameMstByNameKbnALInput input = new GetNameMstByNameKbnALInput();

            input.NameKbn = nameKbn;

            IGetNameMstByNameKbnALOutput output = new GetNameMstByNameKbnApplicationLogic().Execute(input);

            return output.NameMst;
        }
        #endregion

        #region GetRow(string nameKbn, string nameCd)
        /// <summary>
        /// 名称マスタレコードを取得（名称区分、名称連番）
        /// </summary>
        /// <param name="nameKbn"></param>
        /// <param name="nameCd"></param>
        /// <returns></returns>
        public static NameMstDataSet.NameMstRow GetRow(string nameKbn, string nameCd)
        {
            IGetNameMstByNameKbnNameCdALInput input = new GetNameMstByNameKbnNameCdALInput();

            input.NameKbn = nameKbn;

            input.NameCd = nameCd;

            IGetNameMstByNameKbnNameCdALOutput output = new GetNameMstByNameKbnNameCdApplicationLogic().Execute(input);

            return output.NameMst.Count > 0 ? output.NameMst[0] : null;
        }
        #endregion
    }
}
