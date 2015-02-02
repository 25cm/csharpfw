using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.BusinessLogic.KinoHoshoKanri.HoshoNoPrint;
using FukjBizSystem.Application.BusinessLogic.KinoHoshoKanri.HoshoShinseiKokan;
using FukjBizSystem.Application.BusinessLogic.KinoHoshoKanri.HoshoShinseiShosai;
using FukjBizSystem.Application.BusinessLogic.YoshiHanbaiKanri.ZaikoList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.KinoHoshoKanri.HoshoShinseiKokan
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IExChangeBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/13　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IExChangeBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// IsUpdate
        /// </summary>
        bool IsUpdate { get; set; }

        /// <summary>
        /// HoshoTorokuInfoDataGridView
        /// </summary>
        DataGridView HoshoTorokuInfoDataGridView { get; set; }

        /// <summary>
        /// ShishoArr
        /// </summary>
        Dictionary<string, int> ShishoArr { get; set; }

        /// <summary>
        /// HoshoTorokuTblDTLoadForm
        /// </summary>
        HoshoTorokuTblDataSet.HoshoTorokuTblDataTable HoshoTorokuTblDTLoadForm { get; set; }

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ExChangeBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/13　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ExChangeBtnClickALInput : IExChangeBtnClickALInput
    {
        /// <summary>
        /// IsUpdate
        /// </summary>
        public bool IsUpdate { get; set; }

        /// <summary>
        /// HoshoTorokuInfoDataGridView
        /// </summary>
        public DataGridView HoshoTorokuInfoDataGridView { get; set; }

        /// <summary>
        /// ShishoArr
        /// </summary>
        public Dictionary<string, int> ShishoArr { get; set; }

        /// <summary>
        /// HoshoTorokuTblDTLoadForm
        /// </summary>
        public HoshoTorokuTblDataSet.HoshoTorokuTblDataTable HoshoTorokuTblDTLoadForm { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("保証登録検査機関～保証登録連番[{0}]", HoshoTorokuInfoDataGridView.Rows[0].Cells["OldHoshoTorokuNoCol"].Value);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IExChangeBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/13　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IExChangeBtnClickALOutput
    {
        /// <summary>
        /// HoshoTorokuShinseiKokanInfoDataTable
        /// </summary>
        HoshoTorokuTblDataSet.HoshoTorokuShinseiKokanInfoDataTable HoshoTorokuShinseiKokanInfoDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ExChangeBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/13　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ExChangeBtnClickALOutput : IExChangeBtnClickALOutput
    {
        /// <summary>
        /// HoshoTorokuShinseiKokanInfoDataTable
        /// </summary>
        public HoshoTorokuTblDataSet.HoshoTorokuShinseiKokanInfoDataTable HoshoTorokuShinseiKokanInfoDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ExChangeBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/13　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ExChangeBtnClickApplicationLogic : BaseApplicationLogic<IExChangeBtnClickALInput, IExChangeBtnClickALOutput>
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
        private const string FunctionName = "HoshoShinseiKokan：ExChangeBtnClick";

        /// <summary>
        /// hoshoTorokuTblDTUpdate
        /// </summary>
        private HoshoTorokuTblDataSet.HoshoTorokuTblDataTable _hoshoTorokuTblDTUpdate = new HoshoTorokuTblDataSet.HoshoTorokuTblDataTable();

        /// <summary>
        /// yoshiZaikoTblDTUpdate
        /// </summary>
        private YoshiZaikoTblDataSet.YoshiZaikoTblDataTable _yoshiZaikoTblDTUpdate = new YoshiZaikoTblDataSet.YoshiZaikoTblDataTable();

        /// <summary>
        /// currentDateTime
        /// </summary>
        private DateTime currentDateTime = Boundary.Common.Common.GetCurrentTimestamp();

        /// <summary>
        /// loginUser
        /// </summary>
        private string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

        /// <summary>
        /// updateTarm
        /// </summary>
        private string loginTarm = Dns.GetHostName();

        /// <summary>
        /// hoshoTorokuTblDTLoadForm 
        /// </summary>
        private HoshoTorokuTblDataSet.HoshoTorokuTblDataTable _hoshoTorokuTblDTLoadForm = new HoshoTorokuTblDataSet.HoshoTorokuTblDataTable();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ExChangeBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/13　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public ExChangeBtnClickApplicationLogic()
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
        /// 2014/08/13　HuyTX　　    新規作成
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
        /// 2014/08/13　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IExChangeBtnClickALOutput Execute(IExChangeBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IExChangeBtnClickALOutput output = new ExChangeBtnClickALOutput();

            try
            {
                // トランザクション開始
                StartTransaction();

                if (!input.IsUpdate)
                {
                    IGetHoshoShinseiKokanInfoBLInput getInfoBLInput = new GetHoshoShinseiKokanInfoBLInput();
                    output.HoshoTorokuShinseiKokanInfoDataTable = new GetHoshoShinseiKokanInfoBusinessLogic().Execute(getInfoBLInput).HoshoTorokuShinseiKokanInfoDataTable;
                    return output;
                }

                //Update data
                for (int i = 0; i < input.HoshoTorokuInfoDataGridView.RowCount - 1; i++)
                {
                    DataGridViewRow row = input.HoshoTorokuInfoDataGridView.Rows[i];

                    //Delete old HoshoToroku
                    _hoshoTorokuTblDTUpdate = GetHoshoTorokuRecord(row.Cells["OldHoshoTorokuNoCol"].Value.ToString());
                    if (_hoshoTorokuTblDTUpdate.Count != 0)
                    {
                        _hoshoTorokuTblDTLoadForm = GetHoshoTorokuLoadForm(input.HoshoTorokuTblDTLoadForm, row.Cells["OldHoshoTorokuNoCol"].Value.ToString());
                        DeleteOldHoshoToroku(_hoshoTorokuTblDTUpdate, _hoshoTorokuTblDTLoadForm);
                    }

                    //Update new HoshoToroku
                    _hoshoTorokuTblDTUpdate = GetHoshoTorokuRecord(row.Cells["NewHoshoTorokuNoCol"].Value.ToString());
                    if (_hoshoTorokuTblDTUpdate.Count != 0)
                    {
                        _hoshoTorokuTblDTLoadForm = GetHoshoTorokuLoadForm(input.HoshoTorokuTblDTLoadForm, row.Cells["NewHoshoTorokuNoCol"].Value.ToString());
                        UpdateNewHoshoToroku(_hoshoTorokuTblDTUpdate, row, _hoshoTorokuTblDTLoadForm);
                    }

                    //Insert new KokanHosho
                    InsertKokanHosho(row);

                }

                //Update YoshiZaiko
                foreach (var item in input.ShishoArr)
                {
                    if (item.Value == 0) continue;

                    _yoshiZaikoTblDTUpdate = GetYoshiZaikoRecord(item.Key);

                    if (_yoshiZaikoTblDTUpdate.Count == 0) continue;

                    _yoshiZaikoTblDTUpdate[0].YoshiZaikoSuryo = _yoshiZaikoTblDTUpdate[0].YoshiZaikoSuryo - item.Value;

                    //Update
                    UpdateYoshiZaiko(_yoshiZaikoTblDTUpdate);

                }

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

        #region GetHoshoTorokuRecord
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： GetHoshoTorokuRecord
        /// <summary>
        ///
        /// </summary>
        /// <param name="hoshoTorokuNo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/13  HuyTX　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        private HoshoTorokuTblDataSet.HoshoTorokuTblDataTable GetHoshoTorokuRecord(string hoshoTorokuNo)
        {
            IGetHoshoTorokuTblByKeyBLInput blInput = new GetHoshoTorokuTblByKeyBLInput();

            blInput.HoshoTorokuKensakikan = hoshoTorokuNo.Substring(0, 4);
            //blInput.HoshoTorokuNendo = Boundary.Common.Common.ConvertToHoshouNendoSeireki(hoshoTorokuNo.Substring(4, 2));
            blInput.HoshoTorokuNendo = Utility.DateUtility.ConvertFromWareki(hoshoTorokuNo.Substring(4, 2)).Substring(0, 4);
            blInput.HoshoTorokuRenban = hoshoTorokuNo.Substring(6);

            IGetHoshoTorokuTblByKeyBLOutput blOutput = new GetHoshoTorokuTblByKeyBusinessLogic().Execute(blInput);

            return blOutput.HoshoTorokuTblDataTable;
        }
        #endregion

        #region GetYoshiZaikoRecord
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： GetYoshiZaikoRecord
        /// <summary>
        ///
        /// </summary>
        /// <param name="shishoCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/13  HuyTX　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        private YoshiZaikoTblDataSet.YoshiZaikoTblDataTable GetYoshiZaikoRecord(string shishoCd)
        {
            IGetYoshiZaikoTblByKeyBLInput blInput = new GetYoshiZaikoTblByKeyBLInput();
            
            blInput.YoshiZaikoShishoCd = shishoCd;
            blInput.YoshiZaikoYoshiCd = Boundary.Common.Common.GetConstValue(Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001);

            IGetYoshiZaikoTblByKeyBLOutput blOutput = new GetYoshiZaikoTblByKeyBusinessLogic().Execute(blInput);

            return blOutput.YoshiZaikoTblDataTable;
        }
        #endregion

        #region DeleteOldHoshoToroku
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： DeleteOldHoshoToroku
        /// <summary>
        ///
        /// </summary>
        /// <param name="hoshoTorokuTblDT"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/13  HuyTX　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        private void DeleteOldHoshoToroku(HoshoTorokuTblDataSet.HoshoTorokuTblDataTable hoshoTorokuTblDT, HoshoTorokuTblDataSet.HoshoTorokuTblDataTable hoshoTorokuLoadForm)
        {
            //Rakkan check
            if (hoshoTorokuLoadForm[0].UpdateDt != hoshoTorokuTblDT[0].UpdateDt)
            {
                // 更新されている場合は、他のユーザから更新されていると判断し、楽観ロックエラーで例外を発生
                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
            }

            IUpdateHoshoTorokuTblBLInput blInput = new UpdateHoshoTorokuTblBLInput();

            hoshoTorokuTblDT[0].HoshoTorokuKokanDt = currentDateTime.ToString("yyyyMMdd");
            hoshoTorokuTblDT[0].HoshoTorokuDeleteFlg = "1";
            hoshoTorokuTblDT[0].UpdateDt = currentDateTime;
            hoshoTorokuTblDT[0].UpdateUser = loginUser;
            hoshoTorokuTblDT[0].UpdateTarm = loginTarm;

            blInput.HoshoTorokuTblDT = hoshoTorokuTblDT;

            new UpdateHoshoTorokuTblBusinessLogic().Execute(blInput);
        }
        #endregion

        #region UpdateNewHoshoToroku
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： UpdateNewHoshoToroku
        /// <summary>
        ///
        /// </summary>
        /// <param name="hoshoTorokuTblDT"></param>
        /// <param name="row"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/13  HuyTX　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        private void UpdateNewHoshoToroku(HoshoTorokuTblDataSet.HoshoTorokuTblDataTable hoshoTorokuTblDT, DataGridViewRow row, HoshoTorokuTblDataSet.HoshoTorokuTblDataTable hoshoTorokuLoadForm)
        {
            //Rakkan check
            if (hoshoTorokuLoadForm[0].UpdateDt != hoshoTorokuTblDT[0].UpdateDt)
            {
                // 更新されている場合は、他のユーザから更新されていると判断し、楽観ロックエラーで例外を発生
                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
            }

            IUpdateHoshoTorokuTblBLInput blInput = new UpdateHoshoTorokuTblBLInput();

            hoshoTorokuTblDT[0].HoshoTorokuShishoKbn = row.Cells["HoshoTorokuShishoKbnCol"].Value.ToString();
            hoshoTorokuTblDT[0].HoshoTorokuUriageDt = row.Cells["HoshoTorokuUriageDtCol"].Value.ToString();
            hoshoTorokuTblDT[0].HoshoTorokuHanbaisakiCd = row.Cells["HoshoTorokuHanbaisakiCdCol"].Value.ToString();
            hoshoTorokuTblDT[0].UpdateDt = currentDateTime;
            hoshoTorokuTblDT[0].UpdateUser = loginUser;
            hoshoTorokuTblDT[0].UpdateTarm = loginTarm;

            blInput.HoshoTorokuTblDT = hoshoTorokuTblDT;

            new UpdateHoshoTorokuTblBusinessLogic().Execute(blInput);
        }
        #endregion

        #region InsertKokanHosho
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： InsertKokanHosho
        /// <summary>
        ///
        /// </summary>
        /// <param name="row"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/13  HuyTX　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        private void InsertKokanHosho(DataGridViewRow row)
        {
            IUpdateKokanHoshoTblBLInput blInput = new UpdateKokanHoshoTblBLInput();

            KokanHoshoTblDataSet.KokanHoshoTblDataTable kokanHoshoTblDT = new KokanHoshoTblDataSet.KokanHoshoTblDataTable();
            KokanHoshoTblDataSet.KokanHoshoTblRow newRow = kokanHoshoTblDT.NewKokanHoshoTblRow();

            string hoshoTorokuNoOld = row.Cells["OldHoshoTorokuNoCol"].Value.ToString();
            string hoshoTorokuNoNew = row.Cells["NewHoshoTorokuNoCol"].Value.ToString();


            newRow.KokanHoshoTorokuKensakikan = hoshoTorokuNoOld.Substring(0, 4);
            //newRow.KokanHoshoTorokuNendo = Boundary.Common.Common.ConvertToHoshouNendoSeireki(hoshoTorokuNoOld.Substring(4, 2));
            newRow.KokanHoshoTorokuNendo = Utility.DateUtility.ConvertFromWareki(hoshoTorokuNoOld.Substring(4, 2)).Substring(0, 4);

            newRow.KokanHoshoTorokuRenban = hoshoTorokuNoOld.Substring(6);
            newRow.KokanHoshoRenban = "0";
            newRow.KokanHoshoNo1 = hoshoTorokuNoNew.Substring(0, 4);
            //newRow.KokanHoshoNo2 = Boundary.Common.Common.ConvertToHoshouNendoSeireki(hoshoTorokuNoNew.Substring(4, 2));
            newRow.KokanHoshoNo2 = Utility.DateUtility.ConvertFromWareki(hoshoTorokuNoNew.Substring(4, 2)).Substring(0, 4);
            newRow.KokanHoshoNo3 = hoshoTorokuNoNew.Substring(6);

            newRow.InsertDt = currentDateTime;
            newRow.InsertUser = loginUser;
            newRow.InsertTarm = loginTarm;
            newRow.UpdateDt = currentDateTime;
            newRow.UpdateUser = loginUser;
            newRow.UpdateTarm = loginTarm;

            kokanHoshoTblDT.AddKokanHoshoTblRow(newRow);
            newRow.AcceptChanges();
            newRow.SetAdded();

            blInput.KokanHoshoTblDataTable = kokanHoshoTblDT;

            new UpdateKokanHoshoTblBusinessLogic().Execute(blInput);
        }
        #endregion

        #region UpdateYoshiZaiko
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： UpdateYoshiZaiko
        /// <summary>
        ///
        /// </summary>
        /// <param name="yoshiZaikoTblDT"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/13  HuyTX　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        private void UpdateYoshiZaiko(YoshiZaikoTblDataSet.YoshiZaikoTblDataTable yoshiZaikoTblDT)
        {
            IUpdateYoshiZaikoTblBLInput blInput = new UpdateYoshiZaikoTblBLInput();

            yoshiZaikoTblDT[0].UpdateDt = currentDateTime;
            yoshiZaikoTblDT[0].UpdateUser = loginUser;
            yoshiZaikoTblDT[0].UpdateTarm = loginTarm;

            blInput.YoshiZaikoTblDataTable = yoshiZaikoTblDT;

            new UpdateYoshiZaikoTblBusinessLogic().Execute(blInput);

        }
        #endregion

        #region GetHoshoTorokuLoadForm
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： GetHoshoTorokuLoadForm
        /// <summary>
        ///
        /// </summary>
        /// <param name="hoshoTorokuTblDT"></param>
        /// <param name="hoshoTorokuNo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/18  HuyTX　　 新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        private HoshoTorokuTblDataSet.HoshoTorokuTblDataTable GetHoshoTorokuLoadForm(HoshoTorokuTblDataSet.HoshoTorokuTblDataTable hoshoTorokuTblDT, string hoshoTorokuNo)
        {
            HoshoTorokuTblDataSet.HoshoTorokuTblDataTable returnDT = new HoshoTorokuTblDataSet.HoshoTorokuTblDataTable();
            HoshoTorokuTblDataSet.HoshoTorokuTblRow[] hoshoTorokuRows = (HoshoTorokuTblDataSet.HoshoTorokuTblRow[])hoshoTorokuTblDT.Select(string.Format("HoshoTorokuKensakikan = '{0}' AND HoshoTorokuNendo = '{1}' AND HoshoTorokuRenban = '{2}'", 
                new string[]{hoshoTorokuNo.Substring(0, 4), 
                            Utility.DateUtility.ConvertFromWareki(hoshoTorokuNo.Substring(4, 2), "yyyy"),
                            hoshoTorokuNo.Substring(6)}));

            if (hoshoTorokuRows.Length > 0)
            {
                returnDT.ImportRow(hoshoTorokuRows[0]);
            }

            return returnDT;
        }
        #endregion

        #endregion
    }
    #endregion
}
