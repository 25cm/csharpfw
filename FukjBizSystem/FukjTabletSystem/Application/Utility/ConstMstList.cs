using FukjTabletSystem.Application.ApplicationLogic.Common;
using FukjTabletSystem.Application.DataSet.SQLCE;

namespace FukjTabletSystem.Application.Utility
{
    /// <summary>
    /// 定数マスタ取得クラス
    /// </summary>
    public class ConstMstList
    {
        #region Get(string contKbn)
        /// <summary>
        /// 定数マスタテーブルを取得（定数区分）
        /// </summary>
        /// <param name="contKbn"></param>
        /// <returns></returns>
        public static ConstMstDataSet.ConstMstDataTable Get(string contKbn)
        {
            IGetConstMstByKbnALInput input = new GetConstMstByKbnALInput();

            input.ConstKbn = contKbn;

            IGetConstMstByKbnALOutput output = new GetConstMstByKbnApplicationLogic().Execute(input);

            return output.ConstMst;
        }
        #endregion

        #region Get(string contKbn, string value)
        /// <summary>
        /// 定数マスタテーブルを取得（定数区分、定数値）
        /// </summary>
        /// <param name="contKbn"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ConstMstDataSet.ConstMstDataTable Get(string contKbn, string value)
        {
            IGetConstMstByKbnValueALInput input = new GetConstMstByKbnValueALInput();

            input.ConstKbn = contKbn;

            input.ConstValue = value;

            IGetConstMstByKbnValueALOutput output = new GetConstMstByKbnValueApplicationLogic().Execute(input);

            return output.ConstMst;
        }
        #endregion

        #region GetRow(string contKbn, string renban)
        /// <summary>
        /// 定数マスタレコードを取得（定数区分、定数連番）
        /// </summary>
        /// <param name="contKbn"></param>
        /// <param name="renban"></param>
        /// <returns></returns>
        public static ConstMstDataSet.ConstMstRow GetRow(string contKbn, string renban)
        {
            IGetConstMstByKeyALInput input = new GetConstMstByKeyALInput();

            input.ConstKbn = contKbn;

            input.ConstRenban = renban;

            IGetConstMstByKeyALOutput output = new GetConstMstByKeyApplicationLogic().Execute(input);

            return output.ConstMst.Count > 0 ? output.ConstMst[0] : null;
        }
        #endregion
    }
}
