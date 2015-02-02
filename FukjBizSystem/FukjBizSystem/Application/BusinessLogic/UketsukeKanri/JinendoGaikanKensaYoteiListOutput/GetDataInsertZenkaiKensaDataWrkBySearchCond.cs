using System.Reflection;
using FukjBizSystem.Application.DataAccess.JokasoDaichoMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.UketsukeKanri.JinendoGaikanKensaYoteiListOutput
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetDataInsertZenkaiKensaDataWrkBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetDataInsertZenkaiKensaDataWrkBySearchCondBLInput : ISelectDataInsertZenkaiKensaDataWrkBySearchCondDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetDataInsertZenkaiKensaDataWrkBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetDataInsertZenkaiKensaDataWrkBySearchCondBLInput : IGetDataInsertZenkaiKensaDataWrkBySearchCondBLInput
    {
        /// <summary>
        /// 年度
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
        /// 作表区分１－１
        /// </summary>
        public bool SakuhyoKbn11 { get; set; }

        /// <summary>
        /// 作表区分１－２
        /// </summary>
        public bool SakuhyoKbn12 { get; set; }

        /// <summary>
        /// 作表区分１－３
        /// </summary>
        public bool SakuhyoKbn13 { get; set; }

        /// <summary>
        /// 差分出力/出力差分
        /// </summary>
        public bool SakuhyoKbn31 { get; set; }

        /// <summary>
        /// 差分出力/入力差分
        /// </summary>
        public bool SakuhyoKbn32 { get; set; }

        /// <summary>
        /// 差分出力/すべて
        /// </summary>
        public bool SakuhyoKbn33 { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetDataInsertZenkaiKensaDataWrkBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetDataInsertZenkaiKensaDataWrkBySearchCondBLOutput : ISelectDataInsertZenkaiKensaDataWrkBySearchCondDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetDataInsertZenkaiKensaDataWrkBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetDataInsertZenkaiKensaDataWrkBySearchCondBLOutput : IGetDataInsertZenkaiKensaDataWrkBySearchCondBLOutput
    {
        /// <summary>
        /// DataInsertZenkaiKensaDataWrkDataTable
        /// </summary>
        public JokasoDaichoMstDataSet.DataInsertZenkaiKensaDataWrkDataTable DataInsertZenkaiKensaDataWrkDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetDataInsertZenkaiKensaDataWrkBySearchCondBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetDataInsertZenkaiKensaDataWrkBySearchCondBusinessLogic : BaseBusinessLogic<IGetDataInsertZenkaiKensaDataWrkBySearchCondBLInput, IGetDataInsertZenkaiKensaDataWrkBySearchCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetDataInsertZenkaiKensaDataWrkBySearchCondBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/20  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetDataInsertZenkaiKensaDataWrkBySearchCondBusinessLogic()
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
        /// 2014/11/20  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetDataInsertZenkaiKensaDataWrkBySearchCondBLOutput Execute(IGetDataInsertZenkaiKensaDataWrkBySearchCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetDataInsertZenkaiKensaDataWrkBySearchCondBLOutput output = new GetDataInsertZenkaiKensaDataWrkBySearchCondBLOutput();

            try
            {
                output.DataInsertZenkaiKensaDataWrkDT = new SelectDataInsertZenkaiKensaDataWrkBySearchCondDataAccess().Execute(input).DataInsertZenkaiKensaDataWrkDT;
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
