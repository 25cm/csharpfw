using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.KaiinKanri.KaiinNyukin;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.KaiinKanri.KaiinNyukin
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
    /// 2014/10/01  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKakuteiBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// IsCheckDuplicate
        /// </summary>
        bool IsCheckDuplicate { get; set; }

        /// <summary>
        /// NenKaihiTblUpdateDataTable
        /// </summary>
        NenKaihiTblDataSet.NenKaihiTblDataTable NenKaihiTblUpdateDataTable { get; set; }

        /// <summary>
        /// NyukinTblUpdateDataTable
        /// </summary>
        NyukinTblDataSet.NyukinTblDataTable NyukinTblUpdateDataTable { get; set; }
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
    /// 2014/10/01  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KakuteiBtnClickALInput : IKakuteiBtnClickALInput
    {
        /// <summary>
        /// IsCheckDuplicate
        /// </summary>
        public bool IsCheckDuplicate { get; set; }

        /// <summary>
        /// NenKaihiTblUpdateDataTable
        /// </summary>
        public NenKaihiTblDataSet.NenKaihiTblDataTable NenKaihiTblUpdateDataTable { get; set; }

        /// <summary>
        /// NyukinTblUpdateDataTable
        /// </summary>
        public NyukinTblDataSet.NyukinTblDataTable NyukinTblUpdateDataTable { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("会費No[{0}], 入金No[{1}]", NenKaihiTblUpdateDataTable[0].KaihiNo, NyukinTblUpdateDataTable[0].NyukinNo);
            }
        }
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
    /// 2014/10/01  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKakuteiBtnClickALOutput
    {
        /// <summary>
        /// NenKaihiTblInfoDataTable
        /// </summary>
        NenKaihiTblDataSet.NenKaihiTblDataTable NenKaihiTblInfoDataTable { get; set; }
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
    /// 2014/10/01  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KakuteiBtnClickALOutput : IKakuteiBtnClickALOutput
    {
        /// <summary>
        /// NenKaihiTblInfoDataTable
        /// </summary>
        public NenKaihiTblDataSet.NenKaihiTblDataTable NenKaihiTblInfoDataTable { get; set; }
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
    /// 2014/10/01  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KakuteiBtnClickApplicationLogic : BaseApplicationLogic<IKakuteiBtnClickALInput, IKakuteiBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KaiinNyukin：KakuteiBtnClick";

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
        /// 2014/10/01  HuyTX　　    新規作成
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
        /// 2014/10/01  HuyTX　　    新規作成
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
        /// 2014/10/01  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IKakuteiBtnClickALOutput Execute(IKakuteiBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKakuteiBtnClickALOutput output = new KakuteiBtnClickALOutput();

            try
            {
                // トランザクション開始
                StartTransaction();

                //Check duplicate NenKaihiTbl
                if (input.IsCheckDuplicate)
                {
                    IGetNenKaihiTblInfoBLInput getNenKaihiBLInput = new GetNenKaihiTblInfoBLInput();
                    output.NenKaihiTblInfoDataTable = new GetNenKaihiTblInfoBusinessLogic().Execute(getNenKaihiBLInput).NenKaihiTblDataTable;
                    return output;
                }

                // Insert NenKaihiTbl
                IUpdateNenKaihiTblBLInput updateNenKaihiBLInput = new UpdateNenKaihiTblBLInput();
                updateNenKaihiBLInput.NenKaihiTblDataTable = input.NenKaihiTblUpdateDataTable;
                new UpdateNenKaihiTblBusinessLogic().Execute(updateNenKaihiBLInput);

                // Insert NyukinTbl
                IUpdateNyukinTblBLInput updateNyukinBLInput = new UpdateNyukinTblBLInput();
                updateNyukinBLInput.NyukinTblDataTable = input.NyukinTblUpdateDataTable;
                new UpdateNyukinTblBusinessLogic().Execute(updateNyukinBLInput);

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
    }
    #endregion
}
