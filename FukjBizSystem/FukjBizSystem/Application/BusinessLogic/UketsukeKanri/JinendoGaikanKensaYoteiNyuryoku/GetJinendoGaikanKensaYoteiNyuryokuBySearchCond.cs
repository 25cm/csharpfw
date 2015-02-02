using System.Reflection;
using FukjBizSystem.Application.DataAccess.JinendoGaikanYoteiOutputTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.UketsukeKanri.JinendoGaikanKensaYoteiNyuryoku
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetJinendoGaikanKensaYoteiNyuryokuBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetJinendoGaikanKensaYoteiNyuryokuBySearchCondBLInput : ISelectJinendoGaikanKensaYoteiNyuryokuByCondDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetJinendoGaikanKensaYoteiNyuryokuBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetJinendoGaikanKensaYoteiNyuryokuBySearchCondBLInput : IGetJinendoGaikanKensaYoteiNyuryokuBySearchCondBLInput
    {
        /// <summary>
        /// 作成年度
        /// </summary>
        public string Nendo { get; set; }

        /// <summary>
        /// 地区コード（開始）
        /// </summary>
        public string ChikuCdFrom { get; set; }

        /// <summary>
        /// 地区コード（終了）
        /// </summary>
        public string ChikuCdTo { get; set; }

        /// <summary>
        /// 業者コード（開始）
        /// </summary>
        public string GyoshaCdFrom { get; set; }

        /// <summary>
        /// 業者コード（終了）
        /// </summary>
        public string GyoshaCdTo { get; set; }

        /// <summary>
        /// 浄化槽番号（開始）保健所
        /// </summary>
        public string IraiNoFromHokenjo { get; set; }

        /// <summary>
        /// 浄化槽番号（開始）年度
        /// </summary>
        public string IraiNoFromNendo { get; set; }

        /// <summary>
        /// 浄化槽番号（開始）連番
        /// </summary>
        public string IraiNoFromRenban { get; set; }

        /// <summary>
        /// 浄化槽番号（終了）保健所
        /// </summary>
        public string IraiNoToHokenjo { get; set; }

        /// <summary>
        /// 浄化槽番号（終了）年度
        /// </summary>
        public string IraiNoToNendo { get; set; }

        /// <summary>
        /// 浄化槽番号（終了）連番
        /// </summary>
        public string IraiNoToRenban { get; set; }

        /// <summary>
        /// 人槽区分
        /// </summary>
        public int NinsoKbn { get; set; }

        /// <summary>
        /// 差分出力
        /// </summary>
        public int IraiMakeKbn { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetJinendoGaikanKensaYoteiNyuryokuBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetJinendoGaikanKensaYoteiNyuryokuBySearchCondBLOutput : ISelectJinendoGaikanKensaYoteiNyuryokuByCondDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetJinendoGaikanKensaYoteiNyuryokuBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetJinendoGaikanKensaYoteiNyuryokuBySearchCondBLOutput : IGetJinendoGaikanKensaYoteiNyuryokuBySearchCondBLOutput
    {
        /// <summary>
        /// JinendoGaikanKensaYoteiNyuryokuDataTable
        /// </summary>
        public JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanKensaYoteiNyuryokuDataTable JinendoGaikanKensaYoteiNyuryokuDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetJinendoGaikanKensaYoteiNyuryokuBySearchCondBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetJinendoGaikanKensaYoteiNyuryokuBySearchCondBusinessLogic : BaseBusinessLogic<IGetJinendoGaikanKensaYoteiNyuryokuBySearchCondBLInput, IGetJinendoGaikanKensaYoteiNyuryokuBySearchCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetJinendoGaikanKensaYoteiNyuryokuBySearchCondBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetJinendoGaikanKensaYoteiNyuryokuBySearchCondBusinessLogic()
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
        /// 2014/11/17　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetJinendoGaikanKensaYoteiNyuryokuBySearchCondBLOutput Execute(IGetJinendoGaikanKensaYoteiNyuryokuBySearchCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetJinendoGaikanKensaYoteiNyuryokuBySearchCondBLOutput output = new GetJinendoGaikanKensaYoteiNyuryokuBySearchCondBLOutput();

            try
            {
                output.JinendoGaikanKensaYoteiNyuryokuDataTable = new SelectJinendoGaikanKensaYoteiNyuryokuByCondDataAccess().Execute(input).JinendoGaikanKensaYoteiNyuryokuDataTable;
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
