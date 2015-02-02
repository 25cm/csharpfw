using System;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaTorisageList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.GaikanKensa.KensaTorisageList
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
    /// 2014/08/29  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKoshinBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// KensaTorisageListDataTable
        /// </summary>
        KensaIraiTblDataSet.KensaTorisageListDataTable KensaTorisageListDataTable { get; set; }
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
    /// 2014/08/29  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KoshinBtnClickALInput : IKoshinBtnClickALInput
    {
        /// <summary>
        /// KensaTorisageListDataTable
        /// </summary>
        public KensaIraiTblDataSet.KensaTorisageListDataTable KensaTorisageListDataTable { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("検査依頼法定区分 [{0}], 検査依頼保健所コード [{1}], 検査依頼年度 [{2}], 検査依頼連番 [{3}]",
                    new string[] { KensaTorisageListDataTable[0].KensaIraiHoteiKbn, 
                        KensaTorisageListDataTable[0].KensaIraiHokenjoCd, 
                        KensaTorisageListDataTable[0].KensaIraiNendo, 
                        KensaTorisageListDataTable[0].KensaIraiRenban });
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
    /// 2014/08/29  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKoshinBtnClickALOutput
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
    /// 2014/08/29  HuyTX　　    新規作成
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
    /// 2014/08/29  HuyTX　　    新規作成
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
        private const string FunctionName = "KensaTorisageList：KoshinBtnClick";

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
        /// 2014/08/29  HuyTX　　    新規作成
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
        /// 2014/08/29  HuyTX　　    新規作成
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
        /// 2014/08/29  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IKoshinBtnClickALOutput Execute(IKoshinBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKoshinBtnClickALOutput output = new KoshinBtnClickALOutput();

            try
            {
                // トランザクション開始
                StartTransaction();

                KensaIraiTblDataSet .KensaIraiTblDataTable kensaIraiDTUpdate = new KensaIraiTblDataSet.KensaIraiTblDataTable();
                IGetKensaIraiTblByKeyBLInput getKensaIraiBLInput = new GetKensaIraiTblByKeyBLInput();

                foreach (KensaIraiTblDataSet.KensaTorisageListRow row in input.KensaTorisageListDataTable)
                {
                    if (row.SelectChk.ToString() != "1") continue;

                    getKensaIraiBLInput.KensaIraiHoteiKbn = row.KensaIraiHoteiKbn;
                    getKensaIraiBLInput.KensaIraiHokenjoCd = row.KensaIraiHokenjoCd;
                    getKensaIraiBLInput.KensaIraiNendo = row.KensaIraiNendo;
                    getKensaIraiBLInput.KensaIraiRenban = row.KensaIraiRenban;

                    IGetKensaIraiTblByKeyBLOutput getKensaIraiBLOutput = new GetKensaIraiTblByKeyBusinessLogic().Execute(getKensaIraiBLInput);

                    if (getKensaIraiBLOutput.KensaIraiTblDataTable.Count == 0) continue;

                    if (row.UpdateDt != getKensaIraiBLOutput.KensaIraiTblDataTable[0].UpdateDt)
                    {
                        throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                    }

                    kensaIraiDTUpdate.Merge(CreateKensaIraiUpdate(getKensaIraiBLOutput.KensaIraiTblDataTable, row));

                }

                //update KensaIraiTbl
                IUpdateKensaIraiTblBLInput updateBLInput = new UpdateKensaIraiTblBLInput();
                updateBLInput.KensaIraiTblDataTable = kensaIraiDTUpdate;
                new UpdateKensaIraiTblBusinessLogic().Execute(updateBLInput);

                // コミット
                CompleteTransaction();
            }
            catch
            {
                throw;
            }
            finally
            {
                // トランザクション終了
                EndTransaction();

                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }

            return output;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region CreateKensaIraiUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateKensaIraiUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kensaIraiDT"></param>
        /// <param name="kensaTorisageRow"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/29  HuyTX　　    新規作成
        /// 2014/10/02  HuyTX　　    Ver1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaIraiTblDataSet.KensaIraiTblDataTable CreateKensaIraiUpdate(KensaIraiTblDataSet.KensaIraiTblDataTable kensaIraiDT, 
            KensaIraiTblDataSet.KensaTorisageListRow kensaTorisageRow)
        {
            DateTime currentDateTime = Boundary.Common.Common.GetCurrentTimestamp();

            //kensaIraiDT[0].KensaIraiHakkoKbn10 = "1";
            kensaIraiDT[0].KensaIraiStatusKbn = "99";
            kensaIraiDT[0].KensaIraiTorisageNen = currentDateTime.ToString("yyyy");
            kensaIraiDT[0].KensaIraiTorisageTsuki = currentDateTime.ToString("MM");
            kensaIraiDT[0].KensaIraiTorisageBi = currentDateTime.ToString("dd");
            kensaIraiDT[0].UpdateDt = currentDateTime;
            kensaIraiDT[0].UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            kensaIraiDT[0].UpdateTarm = Dns.GetHostName();

            if (kensaTorisageRow.GesuiChk == "1")
            {
                kensaIraiDT[0].KensaIraiTorisageRiyu = "1";
            }

            if (kensaTorisageRow.HaishiChk == "1")
            {
                kensaIraiDT[0].KensaIraiTorisageRiyu = "2";
            }

            if (kensaTorisageRow.GyohenChk == "1")
            {
                kensaIraiDT[0].KensaIraiTorisageRiyu = "3";
            }

            if (kensaTorisageRow.HokaChk == "1")
            {
                kensaIraiDT[0].KensaIraiTorisageRiyu = "9";
            }

            return kensaIraiDT;
        }
        #endregion

        #endregion
    }
    #endregion
}
