using System;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaTorisageList;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaYoteiList;
using FukjBizSystem.Application.BusinessLogic.JokasoDaichoKanri;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.GaikanKensa.KensaYoteiList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ITorikeshiBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/04  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ITorikeshiBtnClickALInput : IBseALInput, IUpdateKensaIraiTblBLInput, IUpdateJokasoDaichoMstBLInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： TorikeshiBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/04  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class TorikeshiBtnClickALInput : ITorikeshiBtnClickALInput
    {
        /// <summary>
        /// KensaIraiTblDataTable
        /// </summary>
        public KensaIraiTblDataSet.KensaIraiTblDataTable KensaIraiTblDataTable { get; set; }

        /// <summary>
        /// JokasoDaichoMstDataTable
        /// </summary>
        public JokasoDaichoMstDataSet.JokasoDaichoMstDataTable JokasoDaichoMstDT { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("KensaIraiTblDataTable[{0}], JokasoDaichoMstDataTable[{1}]", 
                    new string[] { 
                        KensaIraiTblDataTable[0].KensaIraiHoteiKbn + KensaIraiTblDataTable[0].KensaIraiHokenjoCd + KensaIraiTblDataTable[0].KensaIraiNendo + KensaIraiTblDataTable[0].KensaIraiRenban,
                        JokasoDaichoMstDT[0].JokasoHokenjoCd + JokasoDaichoMstDT[0].JokasoTorokuNendo + JokasoDaichoMstDT[0].JokasoRenban
                    });
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ITorikeshiBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/04  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ITorikeshiBtnClickALOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： TorikeshiBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/04  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class TorikeshiBtnClickALOutput : ITorikeshiBtnClickALOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： TorikeshiBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/04  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class TorikeshiBtnClickApplicationLogic : BaseApplicationLogic<ITorikeshiBtnClickALInput, ITorikeshiBtnClickALOutput>
    {
        #region 定義

        public enum OperationErr
        {
            RakkanLock,     // 楽観ロックエラー
        }

        #endregion

        #region private

        /// <summary>
        /// Login User
        /// </summary>
        private string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

        /// <summary>
        /// PC Update
        /// </summary>
        private string pcUpdate = Dns.GetHostName();

        #endregion

        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaYoteiList：TorikeshiBtnClickApplicationLogic";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： TorikeshiBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/04  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public TorikeshiBtnClickApplicationLogic()
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
        /// 2014/09/04  DatNT　  新規作成
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
        /// 2014/09/04  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ITorikeshiBtnClickALOutput Execute(ITorikeshiBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ITorikeshiBtnClickALOutput output = new TorikeshiBtnClickALOutput();

            try
            {
                StartTransaction();

                DateTime now = Boundary.Common.Common.GetCurrentTimestamp();

                KensaIraiTblDataSet.KensaIraiTblDataTable kensaIraiDT = CreateKensaIraiTblDT(input, now);

                JokasoDaichoMstDataSet.JokasoDaichoMstDataTable daichoMstDT = CreateJokasoDaichoMstDT(input, now);

                // Update KensaIraiTbl
                IUpdateKensaIraiTblBLInput updateKensaIraiInput     = new UpdateKensaIraiTblBLInput();
                updateKensaIraiInput.KensaIraiTblDataTable          = kensaIraiDT;
                IUpdateKensaIraiTblBLOutput updateKensaIraiOutput   = new UpdateKensaIraiTblBusinessLogic().Execute(updateKensaIraiInput);

                // Update JokasoDaichoMs
                IUpdateJokasoDaichoMstBLInput updateDaichoInput     = new UpdateJokasoDaichoMstBLInput();
                updateDaichoInput.JokasoDaichoMstDT                 = daichoMstDT;
                IUpdateJokasoDaichoMstBLOutput updateDaichoOutput   = new UpdateJokasoDaichoMstBusinessLogic().Execute(updateDaichoInput);

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
        /// <param name="now"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/04  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaIraiTblDataSet.KensaIraiTblDataTable CreateKensaIraiTblDT(ITorikeshiBtnClickALInput input, DateTime now)
        {
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

                // ハガキ印刷済区分
                blOutput.KensaIraiTblDataTable[0].KensaIraiHagakiInsatsuzumiKbn = string.Empty;

                // 更新日
                blOutput.KensaIraiTblDataTable[0].UpdateDt = now;

                // 更新者
                blOutput.KensaIraiTblDataTable[0].UpdateUser = loginUser;

                // 更新端末
                blOutput.KensaIraiTblDataTable[0].UpdateTarm = pcUpdate;

                updateDT.ImportRow(blOutput.KensaIraiTblDataTable[0]);
            }

            return updateDT;
        }
        #endregion

        #region CreateJokasoDaichoMstDT
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateJokasoDaichoMstDT
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="input">AL入力情報</param>
        /// <param name="now"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/04  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private JokasoDaichoMstDataSet.JokasoDaichoMstDataTable CreateJokasoDaichoMstDT(ITorikeshiBtnClickALInput input, DateTime now)
        {
            JokasoDaichoMstDataSet.JokasoDaichoMstDataTable updateDT = new JokasoDaichoMstDataSet.JokasoDaichoMstDataTable();

            foreach (JokasoDaichoMstDataSet.JokasoDaichoMstRow row in input.JokasoDaichoMstDT)
            {
                IGetJokasoDaichoMstByKeyBLInput blInput     = new GetJokasoDaichoMstByKeyBLInput();
                blInput.HokenjoCd                           = row.JokasoHokenjoCd;
                blInput.TorokuNendo                         = row.JokasoTorokuNendo;
                blInput.Renban                              = row.JokasoRenban;
                IGetJokasoDaichoMstByKeyBLOutput blOutput   = new GetJokasoDaichoMstByKeyBusinessLogic().Execute(blInput);

                // 更新日が違うか？
                if (blOutput.JokasoDaichoMstDT[0].UpdateDt != row.UpdateDt)
                {
                    throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                }

                // はがき区分
                blOutput.JokasoDaichoMstDT[0].JokasoHagakiKbn = row.JokasoHagakiKbn;

                // 更新日
                blOutput.JokasoDaichoMstDT[0].UpdateDt = now;

                // 更新者
                blOutput.JokasoDaichoMstDT[0].UpdateUser = loginUser;

                // 更新端末
                blOutput.JokasoDaichoMstDT[0].UpdateTarm = pcUpdate;

                updateDT.ImportRow(blOutput.JokasoDaichoMstDT[0]);
            }

            return updateDT;
        }
        #endregion

        #endregion

    }
    #endregion
}
