using System.Reflection;
using FukjBizSystem.Application.DataAccess.NippoDtlTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Others.KensainGeppoList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetGeppoShukeiByNengetsuBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/22  habu　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetGeppoShukeiByNengetsuBLInput
    {
        /// <summary>
        /// 集計対象年月
        /// </summary>
        string ShukeiNengetsu { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetGeppoShukeiByNengetsuBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/22  habu　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetGeppoShukeiByNengetsuBLInput : IGetGeppoShukeiByNengetsuBLInput
    {
        /// <summary>
        /// 集計対象年月
        /// </summary>
        public string ShukeiNengetsu { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetGeppoShukeiByNengetsuBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/22  habu　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetGeppoShukeiByNengetsuBLOutput : ISelectGeppoShukeiByNengetsuDAOutput, ISelectGeppoKadouShukeiByNengetsuDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetGeppoShukeiByNengetsuBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/22  habu　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetGeppoShukeiByNengetsuBLOutput : IGetGeppoShukeiByNengetsuBLOutput
    {
        /// <summary>
        /// 検査員別検査集計
        /// </summary>
        public NippoDtlTblDataSet.NippoDtlGeppoShukeiDataTable GeoppoShukeiDataTable { get; set; }

        /// <summary>
        /// 検査員別稼動日集計
        /// </summary>
        public NippoDtlTblDataSet.NippoHdrGeppoKadouShukeiDataTable GeoppoShukeiKadouDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetGeppoShukeiByNengetsuBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/22  habu　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetGeppoShukeiByNengetsuBusinessLogic : BaseBusinessLogic<IGetGeppoShukeiByNengetsuBLInput, IGetGeppoShukeiByNengetsuBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetGeppoShukeiByNengetsuBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/22  habu　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetGeppoShukeiByNengetsuBusinessLogic()
        {

        }
        #endregion

        #region メソッド(public)

        #region Execute
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： Execute
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/22  habu　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetGeppoShukeiByNengetsuBLOutput Execute(IGetGeppoShukeiByNengetsuBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetGeppoShukeiByNengetsuBLOutput output = new GetGeppoShukeiByNengetsuBLOutput();

            try
            {
                {
                    ISelectGeppoShukeiByNengetsuDAInput daInput = new SelectGeppoShukeiByNengetsuDAInput();
                    daInput.ShukeiNengetsu = input.ShukeiNengetsu;
                    ISelectGeppoShukeiByNengetsuDAOutput daOutput = new SelectGeppoShukeiByNengetsuDataAccess().Execute(daInput);

                    output.GeoppoShukeiDataTable = daOutput.GeoppoShukeiDataTable;
                }

                {
                    ISelectGeppoKadouShukeiByNengetsuDAInput daInput = new SelectGeppoKadouShukeiByNengetsuDAInput();
                    daInput.ShukeiNengetsu = input.ShukeiNengetsu;
                    ISelectGeppoKadouShukeiByNengetsuDAOutput daOutput = new SelectGeppoKadouShukeiByNengetsuDataAccess().Execute(daInput);

                    output.GeoppoShukeiKadouDataTable = daOutput.GeoppoShukeiKadouDataTable;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }

            return output;
        }
        #endregion

        #endregion

    }
    #endregion
}
