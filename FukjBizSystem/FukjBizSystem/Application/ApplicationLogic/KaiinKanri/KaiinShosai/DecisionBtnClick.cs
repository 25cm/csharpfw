using System;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.BusinessLogic.Master.GyoshaMstShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.KaiinKanri.KaiinShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDecisionBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/25  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDecisionBtnClickALInput : IBseALInput/*, IUpdateGyoshaBukaiMstBLInput*/
    {
        /// <summary>
        /// 業者コード
        /// </summary>
        string GyoshaCd { get; set; }

        /// <summary>
        /// Current system date
        /// </summary>
        DateTime SystemDt { get; set; }

        /// <summary>
        /// GyoshaBukaiDgv
        /// </summary>
        DataGridView GyoshaBukaiDgv { get; set; }

        /// <summary>
        /// 業者部会マスタ
        /// </summary>
        //GyoshaBukaiMstDataSet.GyoshaBukaiMstDataTable GyoshaBukaiMstDataTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DecisionBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/25  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DecisionBtnClickALInput : IDecisionBtnClickALInput
    {
        /// <summary>
        /// 業者コード
        /// </summary>
        public string GyoshaCd { get; set; }

        /// <summary>
        /// Current system date
        /// </summary>
        public DateTime SystemDt { get; set; }

        /// <summary>
        /// GyoshaBukaiDgv
        /// </summary>
        public DataGridView GyoshaBukaiDgv { get; set; }

        /// <summary>
        /// 業者部会マスタ
        /// </summary>
        //public GyoshaBukaiMstDataSet.GyoshaBukaiMstDataTable GyoshaBukaiMstDataTable { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                //return string.Format("業者コード[{0}], 業者部会マスタ[{1}]", new string[] { GyoshaCd, GyoshaBukaiMstDataTable[0].BukaiGyoshaCd });
                return string.Format("業者コード[{0}]", new string[] { GyoshaCd });
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDecisionBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/25  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDecisionBtnClickALOutput : IUpdateGyoshaBukaiMstBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DecisionBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/25  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DecisionBtnClickALOutput : IDecisionBtnClickALOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DecisionBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/25  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DecisionBtnClickApplicationLogic : BaseApplicationLogic<IDecisionBtnClickALInput, IDecisionBtnClickALOutput>
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
        private const string FunctionName = "KaiinShosai：DecisionBtnClickApplicationLogic";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DecisionBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/25  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DecisionBtnClickApplicationLogic()
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
        /// 2014/07/25  DatNT　  新規作成
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
        /// 2014/07/25  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDecisionBtnClickALOutput Execute(IDecisionBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDecisionBtnClickALOutput output = new DecisionBtnClickALOutput();

            try
            {
                StartTransaction();

                if (!string.IsNullOrEmpty(input.GyoshaCd))
                {
                    // Delete
                    IDeleteGyoshaBukaiMstByGyoshaCdBLInput deleteInput = new DeleteGyoshaBukaiMstByGyoshaCdBLInput();
                    deleteInput.GyoshaCd = input.GyoshaCd;
                    IDeleteGyoshaBukaiMstByGyoshaCdBLOutput deleteOutput = new DeleteGyoshaBukaiMstByGyoshaCdBusinessLogic().Execute(deleteInput);
                }

                //if (input.GyoshaBukaiMstDataTable != null && input.GyoshaBukaiMstDataTable.Count > 0)
                //{
                //    // Insert
                //    IUpdateGyoshaBukaiMstBLInput blInput    = new UpdateGyoshaBukaiMstBLInput();
                //    blInput.GyoshaBukaiMstDataTable         = input.GyoshaBukaiMstDataTable;
                //    IUpdateGyoshaBukaiMstBLOutput blOutput  = new UpdateGyoshaBukaiMstBusinessLogic().Execute(blInput);
                //}

                // 20141121 AnhNV ADD Start
                // Delete - Insert
                IUpdateGyoshaBukaiMstBLInput blInput = new UpdateGyoshaBukaiMstBLInput();
                blInput.GyoshaBukaiMstDataTable = CreateGyoshaBukaiMstDataTableInsert(input);
                IUpdateGyoshaBukaiMstBLOutput blOutput = new UpdateGyoshaBukaiMstBusinessLogic().Execute(blInput);
                // 20141121 AnhNV ADD End

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

        #region DoUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/28  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private GyoshaBukaiMstDataSet.GyoshaBukaiMstDataTable CreateGyoshaBukaiMstDataTableInsert(IDecisionBtnClickALInput input)
        {
            // Login user
            string user = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            // Login machine
            string host = Dns.GetHostName();
            GyoshaBukaiMstDataSet.GyoshaBukaiMstDataTable dataTable = new GyoshaBukaiMstDataSet.GyoshaBukaiMstDataTable();

            foreach (DataGridViewRow dgvRow in input.GyoshaBukaiDgv.Rows)
            {
                if (dgvRow.Cells["bukaiGyoshaCdCol"].Value == null)
                {
                    // don't add to table
                }
                else
                {
                    GyoshaBukaiMstDataSet.GyoshaBukaiMstRow row = dataTable.NewGyoshaBukaiMstRow();

                    // 業者コード
                    row.BukaiGyoshaCd = input.GyoshaCd;

                    // 連番
                    if (dgvRow.Cells["BukaiCol"].Value.ToString() == "製造部会")
                    {
                        row.BukaiKbn = "1";
                    }
                    else if (dgvRow.Cells["BukaiCol"].Value.ToString() == "工事部会")
                    {
                        row.BukaiKbn = "2";
                    }
                    else if (dgvRow.Cells["BukaiCol"].Value.ToString() == "保守部会")
                    {
                        row.BukaiKbn = "3";
                    }
                    else if (dgvRow.Cells["BukaiCol"].Value.ToString() == "清掃部会")
                    {
                        row.BukaiKbn = "4";
                    }

                    // 会員コード 7
                    row.BukaiKaiinCd = dgvRow.Cells["BukaiKaiinCdCol"].Value == null ? string.Empty : dgvRow.Cells["BukaiKaiinCdCol"].Value.ToString().Trim();

                    // 入会日 8
                    row.BukaiNyukaiDt = dgvRow.Cells["bukaiNyukaiDtCol"].Value == null ? string.Empty : dgvRow.Cells["bukaiNyukaiDtCol"].Value.ToString().Trim();

                    // 退会日 9
                    row.BukaiTaikaiDt = dgvRow.Cells["bukaiTaikaiDtCol"].Value == null ? string.Empty : dgvRow.Cells["bukaiTaikaiDtCol"].Value.ToString().Trim();

                    // 設備士代表者氏名（管理管士）10
                    row.BukaiSetsubishiDaihyoshaNm = dgvRow.Cells["bukaiSetsubishiDaihyoshaNmCol"].Value == null ? string.Empty : dgvRow.Cells["bukaiSetsubishiDaihyoshaNmCol"].Value.ToString().Trim();

                    // 免状番号 11
                    row.BukaiMenJoNo = dgvRow.Cells["bukaiMenJoNoCol"].Value == null ? string.Empty : dgvRow.Cells["bukaiMenJoNoCol"].Value.ToString().Trim();

                    #region BukaiKankeiHokenjo
                    // 関係保係健所１  12
                    row.BukaiKankeiHokenjo1 = dgvRow.Cells["bukaiKankeiHokenjo1Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiKankeiHokenjo1Col"].Value.ToString().Trim();

                    // 関係保係健所２  13
                    row.BukaiKankeiHokenjo2 = dgvRow.Cells["bukaiKankeiHokenjo2Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiKankeiHokenjo2Col"].Value.ToString().Trim();

                    // 関係保係健所３  14
                    row.BukaiKankeiHokenjo3 = dgvRow.Cells["bukaiKankeiHokenjo3Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiKankeiHokenjo3Col"].Value.ToString().Trim();

                    // 関係保係健所4  15
                    row.BukaiKankeiHokenjo4 = dgvRow.Cells["bukaiKankeiHokenjo4Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiKankeiHokenjo4Col"].Value.ToString().Trim();

                    // 関係保係健所5  16
                    row.BukaiKankeiHokenjo5 = dgvRow.Cells["bukaiKankeiHokenjo5Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiKankeiHokenjo5Col"].Value.ToString().Trim();

                    // 関係保係健所6  17
                    row.BukaiKankeiHokenjo6 = dgvRow.Cells["bukaiKankeiHokenjo6Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiKankeiHokenjo6Col"].Value.ToString().Trim();

                    // 関係保係健所7  18
                    row.BukaiKankeiHokenjo7 = dgvRow.Cells["bukaiKankeiHokenjo7Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiKankeiHokenjo7Col"].Value.ToString().Trim();

                    // 関係保係健所8  19
                    row.BukaiKankeiHokenjo8 = dgvRow.Cells["bukaiKankeiHokenjo8Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiKankeiHokenjo8Col"].Value.ToString().Trim();

                    // 関係保係健所9  20
                    row.BukaiKankeiHokenjo9 = dgvRow.Cells["bukaiKankeiHokenjo9Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiKankeiHokenjo9Col"].Value.ToString().Trim();

                    // 関係保係健所10  21
                    row.BukaiKankeiHokenjo10 = dgvRow.Cells["bukaiKankeiHokenjo10Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiKankeiHokenjo10Col"].Value.ToString().Trim();

                    // 関係保係健所11  22
                    row.BukaiKankeiHokenjo11 = dgvRow.Cells["bukaiKankeiHokenjo11Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiKankeiHokenjo11Col"].Value.ToString().Trim();

                    // 関係保係健所12  23
                    row.BukaiKankeiHokenjo12 = dgvRow.Cells["bukaiKankeiHokenjo12Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiKankeiHokenjo12Col"].Value.ToString().Trim();

                    // 関係保係健所13  24
                    row.BukaiKankeiHokenjo13 = dgvRow.Cells["bukaiKankeiHokenjo13Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiKankeiHokenjo13Col"].Value.ToString().Trim();

                    // 関係保係健所14  25
                    row.BukaiKankeiHokenjo14 = dgvRow.Cells["bukaiKankeiHokenjo14Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiKankeiHokenjo14Col"].Value.ToString().Trim();

                    // 関係保係健所15  26
                    row.BukaiKankeiHokenjo15 = dgvRow.Cells["bukaiKankeiHokenjo15Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiKankeiHokenjo15Col"].Value.ToString().Trim();
                    #endregion

                    #region BukaiTantoShichoson
                    // 担当市当町村１  27
                    row.BukaiTantoShichoson1 = dgvRow.Cells["bukaiTantoShichoson1Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiTantoShichoson1Col"].Value.ToString().Trim();

                    // 担当市当町村2  28
                    row.BukaiTantoShichoson2 = dgvRow.Cells["bukaiTantoShichoson2Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiTantoShichoson2Col"].Value.ToString().Trim();

                    // 担当市当町村3  29
                    row.BukaiTantoShichoson3 = dgvRow.Cells["bukaiTantoShichoson3Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiTantoShichoson3Col"].Value.ToString().Trim();

                    // 担当市当町村4  30
                    row.BukaiTantoShichoson4 = dgvRow.Cells["bukaiTantoShichoson4Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiTantoShichoson4Col"].Value.ToString().Trim();

                    // 担当市当町村5  31
                    row.BukaiTantoShichoson5 = dgvRow.Cells["bukaiTantoShichoson5Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiTantoShichoson5Col"].Value.ToString().Trim();

                    // 担当市当町村6  32
                    row.BukaiTantoShichoson6 = dgvRow.Cells["BukaiTantoShichoson6Col"].Value == null ? string.Empty : dgvRow.Cells["BukaiTantoShichoson6Col"].Value.ToString().Trim();

                    // 担当市当町村7  33
                    row.BukaiTantoShichoson7 = dgvRow.Cells["BukaiTantoShichoson7Col"].Value == null ? string.Empty : dgvRow.Cells["BukaiTantoShichoson7Col"].Value.ToString().Trim();

                    // 担当市当町村8  34
                    row.BukaiTantoShichoson8 = dgvRow.Cells["BukaiTantoShichoson8Col"].Value == null ? string.Empty : dgvRow.Cells["BukaiTantoShichoson8Col"].Value.ToString().Trim();

                    // 担当市当町村9  35
                    row.BukaiTantoShichoson9 = dgvRow.Cells["bukaiTantoShichoson9Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiTantoShichoson9Col"].Value.ToString().Trim();

                    // 担当市当町村10  36
                    row.BukaiTantoShichoson10 = dgvRow.Cells["bukaiTantoShichoson10Col"].Value == null ? string.Empty : dgvRow.Cells["bukaiTantoShichoson10Col"].Value.ToString().Trim();
                    #endregion

                    // In case of UPDATE
                    if (!string.IsNullOrEmpty(Convert.ToString(dgvRow.Cells["InsertDtCol"].Value)))
                    {
                        // Get GyoshaBukaiMst by key
                        IGetGyoshaBukaiMstByKeyBLInput keyInput = new GetGyoshaBukaiMstByKeyBLInput();
                        keyInput.BukaiGyoshaCd = input.GyoshaCd;
                        keyInput.BukaiKbn = row.BukaiKbn;
                        IGetGyoshaBukaiMstByKeyBLOutput keyOutput = new GetGyoshaBukaiMstByKeyBusinessLogic().Execute(keyInput);

                        if (keyOutput.GyoshaBukaiMstDataTable.Count > 0)
                        {
                            // 更新日が違うか？
                            if (keyOutput.GyoshaBukaiMstDataTable[0].UpdateDt != Convert.ToDateTime(dgvRow.Cells["UpdateDtCol"].Value))
                            {
                                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                            }
                        }

                        // 登録日時
                        row.InsertDt = Convert.ToDateTime(dgvRow.Cells["InsertDtCol"].Value);

                        // 登録者
                        row.InsertUser = Convert.ToString(dgvRow.Cells["InsertUserCol"].Value);

                        // 登録端末
                        row.InsertTarm = Convert.ToString(dgvRow.Cells["InsertTarmCol"].Value);
                    }
                    else // In case of INSERT
                    {
                        // 登録日時
                        row.InsertDt = input.SystemDt;

                        // 登録者
                        row.InsertUser = user;

                        // 登録端末
                        row.InsertTarm = host;
                    }

                    // 更新日時
                    row.UpdateDt = input.SystemDt;

                    // 更新者
                    row.UpdateUser = user;

                    // 更新端末
                    row.UpdateTarm = host;

                    // 行を挿入
                    dataTable.AddGyoshaBukaiMstRow(row);

                    // 行の状態を設定
                    row.AcceptChanges();

                    // 行の状態を設定（新規）
                    row.SetAdded();
                }
            }

            return dataTable;
        }
        #endregion

        #endregion
    }
    #endregion
}
