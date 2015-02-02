using System;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaTorisageList;
using FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke.GenkinNyukin;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.Utility;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;
using System.Text;

namespace FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaUketsuke.GenkinNyukin
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKakuteiBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKakuteiBtnClickALInput : IBseALInput
    {
        #region プロパティ

        /// <summary>
        /// 検査区分
        /// </summary>
        string KensaKbn { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiNendo
        /// </summary>
        string KeiryoShomeiIraiNendo { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiRenban
        /// </summary>
        string KeiryoShomeiIraiRenban { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiSishoCd
        /// </summary>
        string KeiryoShomeiIraiSishoCd { get; set; }

        /// <summary>
        /// KensaIraiHokenjoCd
        /// </summary>
        string KensaIraiHokenjoCd { get; set; }

        /// <summary>
        /// KensaIraiHoteiKbn
        /// </summary>
        string KensaIraiHoteiKbn { get; set; }

        /// <summary>
        /// KensaIraiNendo
        /// </summary>
        string KensaIraiNendo { get; set; }

        /// <summary>
        /// KensaIraiRenban
        /// </summary>
        string KensaIraiRenban { get; set; }
        

        ///// <summary>
        ///// 更新日
        ///// </summary>
        //DateTime UpdateDt { get; set; }

        /// <summary>
        /// 入金テーブル 
        /// </summary>
        NyukinTblDataSet.NyukinTblDataTable NyukinTblDataTable { get; set; }

        /// <summary>
        /// 検査依頼テーブル
        /// </summary>
        KensaIraiTblDataSet.KensaIraiTblDataTable KensaIraiTblDataTable { get; set; }

        /// <summary>
        /// 計量証明依頼テーブル
        /// </summary>
        KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable KeiryoShomeiIraiTblDataTable { get; set; }
       
        #endregion
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KakuteiBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KakuteiBtnClickALInput : IKakuteiBtnClickALInput
    {
        #region プロパティ

        /// <summary>
        /// KensaKbn
        /// </summary>
        public string KensaKbn { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiNendo
        /// </summary>
        public string KeiryoShomeiIraiNendo { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiRenban
        /// </summary>
        public string KeiryoShomeiIraiRenban { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiSishoCd
        /// </summary>
        public string KeiryoShomeiIraiSishoCd { get; set; }

        /// <summary>
        /// KensaIraiHokenjoCd
        /// </summary>
        public string KensaIraiHokenjoCd { get; set; }

        /// <summary>
        /// KensaIraiHoteiKbn
        /// </summary>
        public string KensaIraiHoteiKbn { get; set; }

        /// <summary>
        /// KensaIraiNendo
        /// </summary>
        public string KensaIraiNendo { get; set; }

        /// <summary>
        /// KensaIraiRenban
        /// </summary>
        public string KensaIraiRenban { get; set; }

        ///// <summary>
        ///// 更新日
        ///// </summary>
        //public DateTime UpdateDt { get; set; }

        /// <summary>
        /// 入金テーブル 
        /// </summary>
        public NyukinTblDataSet.NyukinTblDataTable NyukinTblDataTable { get; set; }

        /// <summary>
        /// 検査依頼テーブル
        /// </summary>
        public KensaIraiTblDataSet.KensaIraiTblDataTable KensaIraiTblDataTable { get; set; }

        /// <summary>
        /// 計量証明依頼テーブル
        /// </summary>
        public KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable KeiryoShomeiIraiTblDataTable { get; set; }        

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("NyukinTblDataTable[{0}], KensaIraiTblDataTable[{1}], KeiryoShomeiIraiTblDataTable[{2}]", 
                                        NyukinTblDataTable[0].NyukinNo, KensaIraiTblDataTable[0].KensaIraiHokenjoCd, KeiryoShomeiIraiTblDataTable[0].KeiryoShomeiIraiSishoCd);
            }
        }

        #endregion
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKakuteiBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKakuteiBtnClickALOutput
    {
        /// <summary>
        /// Message error
        /// </summary>
        string ErrorMsg { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KakuteiBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KakuteiBtnClickALOutput : IKakuteiBtnClickALOutput
    {
        /// <summary>
        /// Message error
        /// </summary>
        public string ErrorMsg { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KakuteiBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KakuteiBtnClickApplicationLogic : BaseApplicationLogic<IKakuteiBtnClickALInput, IKakuteiBtnClickALOutput>
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
        private const string FunctionName = "GenkinNyukin：KakuteiBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KakuteiBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KakuteiBtnClickApplicationLogic()
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
        /// 2014/11/19  ThanhVX　    新規作成
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
        /// 2014/11/19  ThanhVX　    新規作成
        /// 2014/12/21　小松        入金済みの判定時は、区分を正しく指定
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IKakuteiBtnClickALOutput Execute(IKakuteiBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKakuteiBtnClickALOutput output = new KakuteiBtnClickALOutput();

            try
            {
                StartTransaction();
                IUpdateNyukinTblBLInput nyukinBlInput = new UpdateNyukinTblBLInput();
                nyukinBlInput.NyukinTblDataTable = input.NyukinTblDataTable;
                
                if (input.KensaKbn.Equals("1"))
                {
                    // 2014/12/18 ThanhVX Add START

                    //int nyuukin = KeiriUtility.ChkNyukinSumi(input.KensaIraiHoteiKbn,
                    //                                input.KensaIraiHokenjoCd, input.KensaIraiNendo,
                    //                                input.KensaIraiRenban);
                    int nyuukin = KeiriUtility.ChkNyukinSumi(
                        FukjBizSystem.Application.Utility.KeiriUtility.NyukinKbnConstant.KensaTesuryo,
                        input.KensaIraiHoteiKbn, input.KensaIraiHokenjoCd, input.KensaIraiNendo, input.KensaIraiRenban);
                    if (nyuukin == 1)
                    {
                        output.ErrorMsg = "すでに入金済です。";
                        return output;
                    }
                    
                    IGetGenkinNyukinKbnOneByCondBLInput blGenkinInput = new GetGenkinNyukinKbnOneByCondBLInput();
                    blGenkinInput.KensaIraiHokenjoCd = input.KensaIraiHokenjoCd;
                    blGenkinInput.KensaIraiHoteiKbn = input.KensaIraiHoteiKbn;
                    blGenkinInput.KensaIraiNendo = input.KensaIraiNendo;
                    blGenkinInput.KensaIraiRenban = input.KensaIraiRenban;
                    NyukinTblDataSet.GenkinNyukinTblDataTable genkinNyukinTbl = new GetGenkinNyukinKbnOneByCondBusinessLogic().Execute(blGenkinInput).GenkinNyukinTblDataTable;


                    if (genkinNyukinTbl.Count > 0)
                    {
                        if (!genkinNyukinTbl[0].IsNull("KensaIraiSeikyuKbn"))
                        {
                            int seikyu = Int32.Parse(genkinNyukinTbl[0].KensaIraiSeikyuKbn);
                            if (seikyu == 1)
                            {
                                output.ErrorMsg = "すでに請求処理されているため、登録できません。";
                                return output;
                            }
                        }
                    }
                    

                    // 2014/12/18 ThanhVX Add END


                    // checking optimistic lock
                    IGetKensaIraiTblByKeyBLInput blInput = new GetKensaIraiTblByKeyBLInput();
                    blInput.KensaIraiHokenjoCd = input.KensaIraiTblDataTable[0].KensaIraiHokenjoCd;
                    blInput.KensaIraiHoteiKbn = input.KensaIraiTblDataTable[0].KensaIraiHoteiKbn;
                    blInput.KensaIraiNendo = input.KensaIraiTblDataTable[0].KensaIraiNendo;
                    blInput.KensaIraiRenban = input.KensaIraiTblDataTable[0].KensaIraiRenban;
                    IGetKensaIraiTblByKeyBLOutput blOutput = new GetKensaIraiTblByKeyBusinessLogic().Execute(blInput);
                    //if (input.UpdateDt != null && input.UpdateDt != blOutput.KensaIraiTblDataTable[0].UpdateDt)
                    //{
                    //    throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                    //}
                    if (input.KensaIraiTblDataTable[0].UpdateDt != blOutput.KensaIraiTblDataTable[0].UpdateDt)
                    {
                        throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                    }

                    input.KensaIraiTblDataTable[0].UpdateDt = nyukinBlInput.NyukinTblDataTable[0].UpdateDt;

                    IUpdateKensaIraiTblBLInput kensaIraiInput = new UpdateKensaIraiTblBLInput();
                    kensaIraiInput.KensaIraiTblDataTable = input.KensaIraiTblDataTable;
                    new UpdateKensaIraiTblBusinessLogic().Execute(kensaIraiInput);
                }
                else
                {

                    // 2014/12/18 ThanhVX Add START: NyuukinCheck, SeikyuCheck
                    //int nyukin = KeiriUtility.ChkNyukinSumi(input.KeiryoShomeiIraiNendo,
                    //                                input.KeiryoShomeiIraiSishoCd,
                    //                                input.KeiryoShomeiIraiRenban);
                    int nyukin = KeiriUtility.ChkNyukinSumi(
                        FukjBizSystem.Application.Utility.KeiriUtility.NyukinKbnConstant.KeiryoShomei,
                        input.KeiryoShomeiIraiNendo, input.KeiryoShomeiIraiSishoCd, input.KeiryoShomeiIraiRenban);

                    if (nyukin == 1)
                    {
                        output.ErrorMsg = "すでに入金済です。";
                        return output;
                    }

                    IGetGenkinNyukinKbnTwoByCondBLInput blGenkinInput = new GetGenkinNyukinKbnTwoByCondBLInput();
                    blGenkinInput.KeiryoShomeiIraiNendo = input.KeiryoShomeiIraiNendo;
                    blGenkinInput.KeiryoShomeiIraiRenban = input.KeiryoShomeiIraiRenban;
                    blGenkinInput.KeiryoShomeiIraiSishoCd = input.KeiryoShomeiIraiSishoCd;
                    NyukinTblDataSet.GenkinNyukinTblDataTable genkinNyukinTbl = new GetGenkinNyukinKbnTwoByCondBusinessLogic().Execute(blGenkinInput).GenkinNyukinTblDataTable;


                    if (genkinNyukinTbl.Count > 0)
                    {
                        if (!genkinNyukinTbl[0].IsNull("KeiryoShomeiSeikyuKbn"))
                        {
                            int seikyu = Int32.Parse(genkinNyukinTbl[0].KeiryoShomeiSeikyuKbn);
                            if (seikyu == 1)
                            {
                                output.ErrorMsg = "すでに請求処理されているため、登録できません。";
                                return output;
                            }
                        }
                    }
                    // 2014/12/18 ThanhVX Add END

                    // checking optimistic lock
                    IGetKeiryoShomeiIraiTblByKeyBLInput blInput = new GetKeiryoShomeiIraiTblByKeyBLInput();
                    blInput.KeiryoShomeiIraiNendo = input.KeiryoShomeiIraiTblDataTable[0].KeiryoShomeiIraiNendo;
                    blInput.KeiryoShomeiIraiRenban = input.KeiryoShomeiIraiTblDataTable[0].KeiryoShomeiIraiRenban;
                    blInput.KeiryoShomeiIraiSishoCd = input.KeiryoShomeiIraiTblDataTable[0].KeiryoShomeiIraiSishoCd;
                   
                    IGetKeiryoShomeiIraiTblByKeyBLOutput blOutput = new GetKeiryoShomeiIraiTblByKeyBusinessLogic().Execute(blInput);
                    //if (input.UpdateDt != null && input.UpdateDt != blOutput.KeiryoShomeiIraiTblDT[0].UpdateDt)
                    //{
                    //    throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                    //}

                    if (input.KeiryoShomeiIraiTblDataTable[0].UpdateDt != blOutput.KeiryoShomeiIraiTblDT[0].UpdateDt)
                    {
                        throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                    }

                    input.KeiryoShomeiIraiTblDataTable[0].UpdateDt = nyukinBlInput.NyukinTblDataTable[0].UpdateDt;

                    IUpdateKeiryoShomeiIraiTblBLInput keiryoIraiInput = new UpdateKeiryoShomeiIraiTblBLInput();
                    keiryoIraiInput.KeiryoShomeiIraiTblDT = input.KeiryoShomeiIraiTblDataTable;
                    new UpdateKeiryoShomeiIraiTblBusinessLogic().Execute(keiryoIraiInput);
                }
                // Update NyuukinTbl
                new UpdateNyukinTblBusinessLogic().Execute(nyukinBlInput);

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
    }
    #endregion
}
