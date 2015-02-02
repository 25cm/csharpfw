using System;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaTorisageList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.GaikanKensa.KensaKanryoInputList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKoshinBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/09  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKoshinBtnClickALInput : IBseALInput, IUpdateKensaIraiTblBLInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KoshinBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/09  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KoshinBtnClickALInput : IKoshinBtnClickALInput
    {
        /// <summary>
        /// KensaIraiTblDataTable
        /// </summary>
        public KensaIraiTblDataSet.KensaIraiTblDataTable KensaIraiTblDataTable { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                // TODO ログ出力用データ文字列を作成してください
                return string.Empty;
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKoshinBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/09  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKoshinBtnClickALOutput : IUpdateKensaIraiTblBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KoshinBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/09  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KoshinBtnClickALOutput : IKoshinBtnClickALOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KoshinBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/09  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KoshinBtnClickApplicationLogic : BaseApplicationLogic<IKoshinBtnClickALInput, IKoshinBtnClickALOutput>
    {
        #region 定義

        public enum OperationErr
        {
            RakkanLock,     // 楽観ロックエラー
        }

        #endregion

        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaKanryoInputList：KoshinBtnClickApplicationLogic";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KoshinBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/09  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KoshinBtnClickApplicationLogic()
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
        /// 2014/09/09  DatNT　  新規作成
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
        /// 2014/09/09  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IKoshinBtnClickALOutput Execute(IKoshinBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKoshinBtnClickALOutput output = new KoshinBtnClickALOutput();

            try
            {
                StartTransaction();

                IUpdateKensaIraiTblBLInput blInput      = new UpdateKensaIraiTblBLInput();
                blInput.KensaIraiTblDataTable           = CreateKensaIraiTblDT(input);
                IUpdateKensaIraiTblBLOutput blOutput    = new UpdateKensaIraiTblBusinessLogic().Execute(blInput);

                CompleteTransaction();
            }
            catch
            {
                throw;
            }
            finally
            {
                EndTransaction();

                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }

            return output;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region CreateKensaIraiTblDT
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateKensaIraiTblDT
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="input">AL入力情報</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/09  DatNT　  新規作成
        /// 2014/10/08  DatNT　  V1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaIraiTblDataSet.KensaIraiTblDataTable CreateKensaIraiTblDT(IKoshinBtnClickALInput input)
        {
            DateTime now = Boundary.Common.Common.GetCurrentTimestamp();

            string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

            KensaIraiTblDataSet.KensaIraiTblDataTable updateDT = new KensaIraiTblDataSet.KensaIraiTblDataTable();

            foreach (KensaIraiTblDataSet.KensaIraiTblRow row in input.KensaIraiTblDataTable)
            {
                IGetKensaIraiTblByKeyBLInput blInput    = new GetKensaIraiTblByKeyBLInput();
                blInput.KensaIraiHoteiKbn               = row.KensaIraiHoteiKbn;
                blInput.KensaIraiHokenjoCd              = row.KensaIraiHokenjoCd;
                blInput.KensaIraiNendo                  = row.KensaIraiNendo;
                blInput.KensaIraiRenban                 = row.KensaIraiRenban;
                IGetKensaIraiTblByKeyBLOutput blOutput  = new GetKensaIraiTblByKeyBusinessLogic().Execute(blInput);

                // 更新日が違うか？
                if (blOutput.KensaIraiTblDataTable[0].UpdateDt != row.UpdateDt)
                {
                    throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                }

                // 更新日
                blOutput.KensaIraiTblDataTable[0].UpdateDt = now;

                // 更新者
                blOutput.KensaIraiTblDataTable[0].UpdateUser = loginUser;

                // 更新端末
                blOutput.KensaIraiTblDataTable[0].UpdateTarm = Dns.GetHostName();

                // 2014/10/08 DatNT V1.02 MOD Start
                //if (blOutput.KensaIraiTblDataTable[0].KensaIraiKeninKbn != row.KensaIraiKeninKbn
                //    || blOutput.KensaIraiTblDataTable[0].KensaIraiKensaKanryoKbn != row.KensaIraiKensaKanryoKbn)
                //{
                //    // 検印区分
                //    blOutput.KensaIraiTblDataTable[0].KensaIraiKeninKbn = row.KensaIraiKeninKbn;

                //    // 検査完了区分
                //    blOutput.KensaIraiTblDataTable[0].KensaIraiKensaKanryoKbn = row.KensaIraiKensaKanryoKbn;

                //    updateDT.ImportRow(blOutput.KensaIraiTblDataTable[0]);
                //}

                // ステータス区分
                blOutput.KensaIraiTblDataTable[0].KensaIraiStatusKbn = row.KensaIraiStatusKbn;

                updateDT.ImportRow(blOutput.KensaIraiTblDataTable[0]);
                // 2014/10/08 DatNT V1.02 MOD End
            }

            return updateDT;
        }
        #endregion

        #endregion
    }
    #endregion
}
