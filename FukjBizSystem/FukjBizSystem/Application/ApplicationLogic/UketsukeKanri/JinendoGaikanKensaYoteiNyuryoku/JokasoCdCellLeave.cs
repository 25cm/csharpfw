using System;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.UketsukeKanri.JinendoGaikanKensaYoteiNyuryoku;
using FukjBizSystem.Application.DataAccess.JokasoDaichoMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.UketsukeKanri.JinendoGaikanKensaYoteiNyuryoku
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IJokasoCdCellLeaveALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IJokasoCdCellLeaveALInput : IBseALInput, IGetJokasoDaichoGyoshaMstSearchBySearchCondBLInput
    {
        /// <summary>
        /// 浄化槽台帳連番 
        /// </summary>
        string Nendo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： JokasoCdCellLeaveALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class JokasoCdCellLeaveALInput : IJokasoCdCellLeaveALInput
    {
        /// <summary>
        /// 浄化槽台帳保健所コード 
        /// </summary>
        public string HokenjoCd { get; set; }

        /// <summary>
        /// 浄化槽台帳年度 
        /// </summary>
        public string TorokuNendo { get; set; }

        /// <summary>
        /// 浄化槽台帳連番 
        /// </summary>
        public string Renban { get; set; }

        /// <summary>
        /// 浄化槽台帳連番 
        /// </summary>
        public string Nendo { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("浄化槽台帳保健所コード [0], 浄化槽台帳年度 [{1}], 浄化槽台帳連番 [{2}], 検査依頼年度  [{3}]",
                    new string[] {
                        HokenjoCd,
                        TorokuNendo,
                        Renban,
                        Nendo});
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IJokasoCdCellLeaveALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IJokasoCdCellLeaveALOutput : IGetJokasoDaichoGyoshaMstSearchBySearchCondBLOutput, IGetKensaIraiTblByJokasoHokenjoNendoRenbanBLOutput
    {
        /// <summary>
        ///次年度外観検査予定出力テーブル 
        /// </summary>
        JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanYoteiOutputTblDataTable JinendoGaikanYoteiOutputTbl { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： JokasoCdCellLeaveALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class JokasoCdCellLeaveALOutput : IJokasoCdCellLeaveALOutput
    {
        /// <summary>
        /// JokasoDaichoGyoshaMstSearchDataTable 
        /// </summary>
        public JokasoDaichoMstDataSet.JokasoDaichoGyoshaMstSearchDataTable JokasoDaichoGyoshaMstSearchDataTable { get; set; }

        /// <summary>
        /// 検査依頼テーブル
        /// </summary>
        public KensaIraiTblDataSet.KensaIraiTblDataTable KensaIraiTblDataTable { get; set; }

        /// <summary>
        ///次年度外観検査予定出力テーブル 
        /// </summary>
        public JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanYoteiOutputTblDataTable JinendoGaikanYoteiOutputTbl { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： JokasoCdCellLeaveApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class JokasoCdCellLeaveApplicationLogic : BaseApplicationLogic<IJokasoCdCellLeaveALInput, IJokasoCdCellLeaveALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "次年度外観検査予定入力：JokasoCdCellLeave";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： JokasoCdCellLeaveApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public JokasoCdCellLeaveApplicationLogic()
        {

        }
        #endregion

        #region メソッド(protected)

        #region GetFunctionName
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetFunctionName
        /// <summary>
        /// 機能名取得
        /// </summary>
        /// <returns>機能名</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override string GetFunctionName()
        {
            return FunctionName;
        }
        #endregion

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
        /// 2014/11/19　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IJokasoCdCellLeaveALOutput Execute(IJokasoCdCellLeaveALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IJokasoCdCellLeaveALOutput output = new JokasoCdCellLeaveALOutput();

            try
            {
                IGetJokasoDaichoGyoshaMstSearchBySearchCondBLOutput blOutput = new GetJokasoDaichoGyoshaMstSearchBySearchCondBusinessLogic().Execute(input);
                output.JokasoDaichoGyoshaMstSearchDataTable = blOutput.JokasoDaichoGyoshaMstSearchDataTable;

                if (blOutput.JokasoDaichoGyoshaMstSearchDataTable.Count > 0)
                {
                    IGetKensaIraiTblByJokasoHokenjoNendoRenbanBLInput blKensaIraiInput = new GetKensaIraiTblByJokasoHokenjoNendoRenbanBLInput();
                    blKensaIraiInput.HokenjoCd = input.HokenjoCd;
                    blKensaIraiInput.Nendo = input.Nendo;
                    blKensaIraiInput.Renban = input.Renban;
                    blKensaIraiInput.TorokuNendo = input.TorokuNendo;
                    IGetKensaIraiTblByJokasoHokenjoNendoRenbanBLOutput blKensaIraiOutput = new GetKensaIraiTblByJokasoHokenjoNendoRenbanBusinessLogic().Execute(blKensaIraiInput);
                    output.KensaIraiTblDataTable = blKensaIraiOutput.KensaIraiTblDataTable;
                }
                else
                {
                    output.KensaIraiTblDataTable = new KensaIraiTblDataSet.KensaIraiTblDataTable();
                }

                IGetJinendoGaikanYoteiOutputTblByKeyBLInput blJinendoInput = new GetJinendoGaikanYoteiOutputTblByKeyBLInput();
                blJinendoInput.JokasoHokenjoCd = input.HokenjoCd;
                blJinendoInput.JokasoRenban = input.Renban;
                blJinendoInput.JokasoTorokuNendo = input.TorokuNendo;
                blJinendoInput.Nendo = input.Nendo;
                IGetJinendoGaikanYoteiOutputTblByKeyBLOutput blJinendoOutput = new GetJinendoGaikanYoteiOutputTblByKeyBusinessLogic().Execute(blJinendoInput);
                output.JinendoGaikanYoteiOutputTbl = blJinendoOutput.JinendoGaikanYoteiOutputTblDT;
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
