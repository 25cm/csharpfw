using System;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.UketsukeKanri.JinendoGaikanKensaYoteiNyuryoku;
using FukjBizSystem.Application.DataAccess.JinendoGaikanYoteiOutputTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;


namespace FukjBizSystem.Application.ApplicationLogic.UketsukeKanri.JinendoGaikanKensaYoteiNyuryoku
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKensakuBtnClickALInput
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
    interface IKensakuBtnClickALInput : IBseALInput, IGetJinendoGaikanKensaYoteiNyuryokuBySearchCondBLInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensakuBtnClickALInput
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
    class KensakuBtnClickALInput : IKensakuBtnClickALInput
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

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("作成年度[{0}], 地区コード（開始）[{1}], 地区コード（終了）[{2}], 業者コード（開始）[{3}], 業者コード（終了）[{4}], "
                    + "浄化槽番号（開始）保健所 [{5}], 浄化槽番号（開始）年度 [{6}], 浄化槽番号（開始）連番 [{7}], 浄化槽番号（終了）保健所 [{8}], 浄化槽番号（終了）年度 [{9}], "
                    + "浄化槽番号（終了）連番 [{10}], 人槽区分 [{11}], 差分出力 [{12}] ",
                    new string[] {
                        Nendo,
                        ChikuCdFrom,
                        ChikuCdTo,
                        GyoshaCdFrom,
                        GyoshaCdTo,
                        IraiNoFromHokenjo,
                        IraiNoFromNendo,
                        IraiNoFromRenban,
                        IraiNoToHokenjo,
                        IraiNoToNendo,
                        IraiNoToRenban,
                        NinsoKbn.ToString(),
                        IraiMakeKbn.ToString(),
                    });
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKensakuBtnClickALOutput
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
    interface IKensakuBtnClickALOutput : IGetJinendoGaikanKensaYoteiNyuryokuBySearchCondBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensakuBtnClickALOutput
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
    class KensakuBtnClickALOutput : IKensakuBtnClickALOutput
    {
        /// <summary>
        /// JinendoGaikanKensaYoteiNyuryokuDataTable
        /// </summary>
        public JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanKensaYoteiNyuryokuDataTable JinendoGaikanKensaYoteiNyuryokuDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensakuBtnClickApplicationLogic
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
    class KensakuBtnClickApplicationLogic : BaseApplicationLogic<IKensakuBtnClickALInput, IKensakuBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "JinendoGaikanKensaYoteiNyuryoku：KensakuBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensakuBtnClickApplicationLogic
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
        public KensakuBtnClickApplicationLogic()
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
        /// 2014/11/17　HieuNH　　　新規作成
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
        /// 2014/11/17　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IKensakuBtnClickALOutput Execute(IKensakuBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKensakuBtnClickALOutput output = new KensakuBtnClickALOutput();

            try
            {
                IGetJinendoGaikanKensaYoteiNyuryokuBySearchCondBLOutput blOutput = new GetJinendoGaikanKensaYoteiNyuryokuBySearchCondBusinessLogic().Execute(input);
                output.JinendoGaikanKensaYoteiNyuryokuDataTable = blOutput.JinendoGaikanKensaYoteiNyuryokuDataTable;
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
