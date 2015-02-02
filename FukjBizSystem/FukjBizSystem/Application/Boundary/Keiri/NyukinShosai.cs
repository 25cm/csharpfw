using System;
using System.Globalization;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Keiri.NyukinShosai;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Keiri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： NyukinShosaiForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/02　HuyTX     新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class NyukinShosaiForm : FukjBaseForm
    {
        #region 定義(public)

        #region 表示モード
        /// <summary>
        /// 表示モード
        /// </summary>
        public enum DispMode
        {
            Add,                // 登録モード
            Edit,               // 編集モード
            Reference,          // 参照モード
            WaitingKeyInput     //キー入力待ちモード
        }
        #endregion

        #endregion

        #region プロパティ(private)

        /// <summary>
        /// currentDateTime 
        /// </summary>
        private DateTime _currentDateTime = Common.Common.GetCurrentTimestamp();

        /// <summary>
        /// loginUser 
        /// </summary>
        private string _loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

        /// <summary>
        /// loginTarm 
        /// </summary>
        private string _loginTarm = Dns.GetHostName();

        /// <summary>
        /// displayMode
        /// </summary>
        private DispMode _displayMode = DispMode.WaitingKeyInput;

        /// <summary>
        /// shozokuShishoCd 
        /// </summary>
        private string _shozokuShishoCd = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;

        /// <summary>
        /// _nyukinNo 
        /// </summary>
        private string _nyukinNo = string.Empty;

        #region DataTable

        /// <summary>
        /// jokasoRow
        /// </summary>
        private JokasoDaichoMstDataSet.JokasoDaichoMstSearchRow _jokasoRow;

        /// <summary>
        /// nyukinTblShosaiDataTable 
        /// </summary>
        private NyukinTblDataSet.NyukinTblShosaiDataTable _nyukinTblShosaiDataTable = new NyukinTblDataSet.NyukinTblShosaiDataTable();

        /// <summary>
        /// seikyuNyukinTblListDataTable 
        /// </summary>
        private SeikyuNyukinTblDataSet.SeikyuNyukinTblListDataTable _seikyuNyukinTblListDataTable = new SeikyuNyukinTblDataSet.SeikyuNyukinTblListDataTable();

        /// <summary>
        /// seikyushoKagamiHdrInfoDataTable
        /// </summary>
        private SeikyusyoKagamiHdrTblDataSet.SeikyushoKagamiHdrInfoDataTable _seikyushoKagamiHdrInfoDataTable = new SeikyusyoKagamiHdrTblDataSet.SeikyushoKagamiHdrInfoDataTable();

        /// <summary>
        /// nyukinTblDTByKey
        /// </summary>
        private NyukinTblDataSet.NyukinTblDataTable _nyukinTblDTByKey = new NyukinTblDataSet.NyukinTblDataTable();

        // 2014.12.27 toyoda Delete Start
        ///// <summary>
        ///// seikyuDtlTblDTLoad
        ///// </summary>
        //private SeikyuDtlTblDataSet.SeikyuDtlTblDataTable _seikyuDtlTblDTLoad = new SeikyuDtlTblDataSet.SeikyuDtlTblDataTable();

        ///// <summary>
        ///// kensaIraiTblDTLoad 
        ///// </summary>
        //private KensaIraiTblDataSet.KensaIraiTblDataTable _kensaIraiTblDTLoad = new KensaIraiTblDataSet.KensaIraiTblDataTable();

        ///// <summary>
        ///// yoshiHanbaiHdrTblDTLoad
        ///// </summary>
        //private YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblDataTable _yoshiHanbaiHdrTblDTLoad = new YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblDataTable();

        ///// <summary>
        ///// nenKaihiTblDTLoad 
        ///// </summary>
        //private NenKaihiTblDataSet.NenKaihiTblDataTable _nenKaihiTblDTLoad = new NenKaihiTblDataSet.NenKaihiTblDataTable();

        ///// <summary>
        ///// seikyuHdrTblDTLoad
        ///// </summary>
        //private SeikyuHdrTblDataSet.SeikyuHdrTblDataTable _seikyuHdrTblDTLoad = new SeikyuHdrTblDataSet.SeikyuHdrTblDataTable();
        
        ///// <summary>
        ///// kurikoshiKinTblDTLoad
        ///// </summary>
        //KurikoshiKinTblDataSet.KurikoshiKinTblDataTable _kurikoshiKinTblDTLoad = new KurikoshiKinTblDataSet.KurikoshiKinTblDataTable();

        ///// <summary>
        ///// seikyuNyukinTblDTLoad
        ///// </summary>
        //SeikyuNyukinTblDataSet.SeikyuNyukinTblDataTable _seikyuNyukinTblDTLoad = new SeikyuNyukinTblDataSet.SeikyuNyukinTblDataTable();
        // 2014.12.27 toyoda Delete End

        #endregion 

        /// <summary>
        /// sanshutsuNyukingaku
        /// </summary>
        private decimal _sanshutsuNyukingaku;

        /// <summary>
        /// errMsg 
        /// </summary>
        private StringBuilder _errMsg = new StringBuilder();

        /// <summary>
        /// nyukinWarifuriTotal
        /// </summary>
        private decimal _nyukinWarifuriTotal;

        // 2014.12.27 toyoda Delete Start
        ///// <summary>
        ///// updateSuccess 
        ///// </summary>
        //private bool _updateSuccess = false;
        // 2014.12.27 toyoda Delete End

        /// <summary>
        /// isLoad 
        /// </summary>
        private bool _isLoad = false;

        /// <summary>
        /// oyaSeikyuNo 
        /// </summary>
        private string _oyaSeikyuNo = string.Empty;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： NyukinShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/02　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public NyukinShosaiForm()
        {
            InitializeComponent();
            SetControlDomain();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： NyukinShosaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <param name="nyukinNo"></param>
        /// <param name="oyaSeikyuNo"></param>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/02　HuyTX    新規作成
        /// 2014/12/22　HuyTX    Add arguments
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public NyukinShosaiForm(string nyukinNo, string oyaSeikyuNo)
        {
            InitializeComponent();
            SetControlDomain();
            _nyukinNo = nyukinNo;
            _oyaSeikyuNo = oyaSeikyuNo;
        }
        #endregion

        #region イベント

        #region NyukinShosaiForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： NyukinShosaiForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/02　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void NyukinShosaiForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DoFormLoad();

                _isLoad = true;
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);

                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region gyoshaCdTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyoshaCdTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/02　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaCdTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(gyoshaCdTextBox.Text))
                {
                    gyoshaNmTextBox.Clear();
                    return;
                }

                gyoshaCdTextBox.Text = gyoshaCdTextBox.Text.PadLeft(4, '0');
                IGyoshaCdTextBoxLeaveALInput alInput = new GyoshaCdTextBoxLeaveALInput();
                alInput.GyoshaCd = gyoshaCdTextBox.Text.Trim();
                IGyoshaCdTextBoxLeaveALOutput alOutput = new GyoshaCdTextBoxLeaveApplicationLogic().Execute(alInput);

                if (alOutput.GyoshaMstDataTable.Count > 0)
                {
                    gyoshaNmTextBox.Text = alOutput.GyoshaMstDataTable[0].GyoshaNm;
                    nyukinshaNmTextBox.Text = alOutput.GyoshaMstDataTable[0].GyoshaNm;
                }
                else
                {
                    gyoshaNmTextBox.Clear();
                    nyukinshaNmTextBox.Clear();
                    MessageForm.Show2(MessageForm.DispModeType.Error, "業者データが存在しません。");
                    //gyoshaCdTextBox.Clear();
                    gyoshaCdTextBox.Focus();
                }

            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region gyoshaSrhButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gyoshaSrhButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/02　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaSrhButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                GyoshaMstSearchForm frm = new GyoshaMstSearchForm();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    gyoshaCdTextBox.Text = frm._selectedRow.GyoshaCd;
                    gyoshaNmTextBox.Text = frm._selectedRow.GyoshaNm;
                    nyukinshaNmTextBox.Text = frm._selectedRow.GyoshaNm;
                }
                
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region jokasoSrhButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： jokasoSrhButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/02　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void jokasoSrhButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                JokasoDaichoSearchForm frm = new JokasoDaichoSearchForm();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    settishaNmTextBox.Text = frm._selectedRow.JokasoSetchishaNm;
                    nyukinshaNmTextBox.Text = frm._selectedRow.JokasoSetchishaNm;

                    _jokasoRow = frm._selectedRow;
                }

            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region kensakuButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensakuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/02　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(seikyuNoTextBox.Text)
                    && ((gyoshaRadioButton.Checked && string.IsNullOrEmpty(gyoshaCdTextBox.Text))
                    || (kojinRadioButton.Checked && string.IsNullOrEmpty(settishaNmTextBox.Text))))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "請求Noを入力してください");
                    return;
                }

                //浄化槽row初期化 add 2015.01.07 kiyokuni start
                if (_jokasoRow == null)
                {
                    JokasoDaichoMstDataSet.JokasoDaichoMstSearchDataTable jokasoDT1 = new JokasoDaichoMstDataSet.JokasoDaichoMstSearchDataTable();
                    _jokasoRow = jokasoDT1.NewJokasoDaichoMstSearchRow();
                    _jokasoRow.JokasoHokenjoCd = string.Empty;
                    _jokasoRow.JokasoTorokuNendo = string.Empty;
                    _jokasoRow.JokasoRenban = string.Empty;
                }
                //浄化槽row初期化 add 2015.01.07 kiyokuni end
                
                IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();

                SeikyushoKagamiHdrSearchCond searchCond = new SeikyushoKagamiHdrSearchCond();
                searchCond.SeikyuNo = !string.IsNullOrEmpty(seikyuNoTextBox.Text.Trim()) ? seikyuNoTextBox.Text.Trim() : string.Empty;
                searchCond.GyoshaCd = gyoshaRadioButton.Checked ? gyoshaCdTextBox.Text : string.Empty;
                searchCond.JokasoHokenjoCd = kojinRadioButton.Checked ? _jokasoRow.JokasoHokenjoCd : string.Empty;
                searchCond.JokasoTorokuNendo = kojinRadioButton.Checked ? _jokasoRow.JokasoTorokuNendo : string.Empty;
                searchCond.JokasoRenban = kojinRadioButton.Checked ? _jokasoRow.JokasoRenban: string.Empty;

                alInput.SearchCond = searchCond;
                IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);

                _seikyushoKagamiHdrInfoDataTable = alOutput.SeikyushoKagamiHdrInfoDataTable;
                _seikyuNyukinTblListDataTable = alOutput.SeikyuNyukinTblListDataTable;
                
                //if (_seikyushoKagamiHdrInfoDataTable == null || _seikyushoKagamiHdrInfoDataTable.Count == 0)
                if (!string.IsNullOrEmpty(seikyuNoTextBox.Text.Trim()) && (_seikyushoKagamiHdrInfoDataTable == null || _seikyushoKagamiHdrInfoDataTable.Count == 0))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象の請求Noが存在しません。");
                    return;
                }

                if (_seikyuNyukinTblListDataTable == null || _seikyuNyukinTblListDataTable.Count == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "入金可能な請求データが存在しません。");
                    return;
                }

                _displayMode = DispMode.Add;
                //設置者キーの取得 add 2015.01.07 kiyokuni start
                _jokasoRow.JokasoHokenjoCd = _seikyushoKagamiHdrInfoDataTable[0].JokasoHokenjoCd;
                _jokasoRow.JokasoTorokuNendo = _seikyushoKagamiHdrInfoDataTable[0].JokasoTorokuNendo;
                _jokasoRow.JokasoRenban = _seikyushoKagamiHdrInfoDataTable[0].JokasoRenban;
                //設置者キーの取得 add 2015.01.07 kiyokuni end
                
                SetDisplayControlByMode();
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region clearButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： clearButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/02　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                _jokasoRow = null;

                // 2014.12.27 toyoda Delete Start
                //if (_updateSuccess)
                //{
                //    IClearBtnClickALInput alInput = new ClearBtnClickALInput();
                //    IClearBtnClickALOutput alOutput = new ClearBtnClickApplicationLogic().Execute(alInput);
                //    _seikyuDtlTblDTLoad = alOutput.SeikyuDtlTblDataTable;
                //    _kensaIraiTblDTLoad = alOutput.KensaIraiTblDataTable;
                //    _yoshiHanbaiHdrTblDTLoad = alOutput.YoshiHanbaiHdrTblDataTable;
                //    _nenKaihiTblDTLoad = alOutput.NenKaihiTblDataTable;
                //    _seikyuHdrTblDTLoad = alOutput.SeikyuHdrTblDataTable;
                //    _kurikoshiKinTblDTLoad = alOutput.KurikoshiKinTblDataTable;
                //    _seikyuNyukinTblDTLoad = alOutput.SeikyuNyukinTblDataTable;
                //}
                // 2014.12.27 toyoda Delete End

                _displayMode = DispMode.WaitingKeyInput;
                SetDisplayControlByMode();

                // 2014.12.27 toyoda Delete Start
                //_updateSuccess = false;
                // 2014.12.27 toyoda Delete End
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region henkinInputButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： henkinInputButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/02　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void henkinInputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!TransitionCheck()) return;

                //transition to 006-021
                HenkinShosaiForm frm = new HenkinShosaiForm(nyukinNoTextBox.Text.Trim());
                Program.mForm.MoveNext(frm, FormEnd);
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region jidoWarifuriButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： jidoWarifuriButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/09　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void jidoWarifuriButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!NyukinCheck()) return;

                GetSanshutsuNyukingaku();
                CalculatorKingaku(_sanshutsuNyukingaku);

            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region nyukinGakuTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： nyukinGakuTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/09　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void nyukinGakuTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                GetSanshutsuNyukingaku();
                //CalculatorKingaku(_sanshutsuNyukingaku);
                CalculatorKingaku(_sanshutsuNyukingaku, false);
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region shiharaiTesuryoTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： shiharaiTesuryoTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/02　HuyTX    新規作成
        /// 2014/12/08　HuyTX    update source code
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shiharaiTesuryoTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //if (string.IsNullOrEmpty(shiharaiTesuryoTextBox.Text.Trim()) || !NyukinCheck()) return;
                if (!NyukinCheck())
                {
                    return;
                }

                GetSanshutsuNyukingaku();
                //CalculatorKingaku(_sanshutsuNyukingaku);
                CalculatorKingaku(_sanshutsuNyukingaku, false);
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region nyukinDtDateTimePicker_ValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： nyukinDtDateTimePicker_ValueChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/02　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void nyukinDtDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                toriatsukaiDtDateTimePicker.Value = nyukinDtDateTimePicker.Value;
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region updateButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： updateButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/02　HuyTX    新規作成
        /// 2014/12/08　HuyTX    Ver1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void updateButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                object nyukinWarifuri = _seikyuNyukinTblListDataTable != null && _seikyuNyukinTblListDataTable.Count > 0 ? _seikyuNyukinTblListDataTable.Compute(string.Format("SUM({0})", _seikyuNyukinTblListDataTable.nyukinWarifuriColColumn.ColumnName), "") : null;
                _nyukinWarifuriTotal = nyukinWarifuri != null ? Decimal.Parse(nyukinWarifuri.ToString()) : 0;

                if (!UpdateCheck()) return;
                if (!UpdateConfirmCheck()) return;

                //reset current datetime
                _currentDateTime = Boundary.Common.Common.GetCurrentTimestamp();

                IUpdateBtnClickALInput alInput = new UpdateBtnClickALInput();
                alInput.DispMode = _displayMode;
                
                alInput.NyukinTblDataTable = string.IsNullOrEmpty(_nyukinNo) ? CreateNyukinTblInsert() : CreateNyukinTblUpdate(_nyukinTblDTByKey);
                alInput.SeikyuNyukinTblListDataTable = _seikyuNyukinTblListDataTable;

                // 2014.12.27 toyoda Delete Start
                //alInput.SeikyuDtlTblDataTableLoad = _seikyuDtlTblDTLoad;
                //alInput.SeikyuNyukinTblDataTableLoad = _seikyuNyukinTblDTLoad;
                //alInput.KensaIraiTblDataTableLoad = _kensaIraiTblDTLoad;
                //alInput.YoshiHanbaiHdrTblDataTableLoad = _yoshiHanbaiHdrTblDTLoad;
                //alInput.NenKaihiTblDataTableLoad = _nenKaihiTblDTLoad;
                //alInput.SeikyuHdrTblDataTableLoad = _seikyuHdrTblDTLoad;
                //alInput.KurikoshiKinTblDataTableLoad = _kurikoshiKinTblDTLoad;
                // 2014.12.27 toyoda Delete End

                alInput.NyukinmotoKbn = gyoshaRadioButton.Checked ? "1" : kojinRadioButton.Checked ? "2" : "0";
                alInput.GyoshaCd = gyoshaCdTextBox.Text.Trim();
                alInput.JokasoRow = _jokasoRow;
                alInput.JikaiKurikoshi = !string.IsNullOrEmpty(jikaiKurikoshiTextBox.Text.Trim()) ? Decimal.Parse(jikaiKurikoshiTextBox.Text.Trim()) : 0;

                new UpdateBtnClickApplicationLogic().Execute(alInput);

                //update success
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "更新処理が完了しました。");

                // 2014.12.27 toyoda Delete Start
                //_updateSuccess = true;
                // 2014.12.27 toyoda Delete End

                clearButton.PerformClick();
            }
            catch (CustomException cex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), cex.ToString());

                if (cex.ResultCode == ResultCode.LockError)
                {
                    // 楽観ロックエラー
                    // 「対象の情報が更新されています。
                    //   再度検索後、操作をやり直してください。」
                    MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00009);
                }
                else
                {
                    // 何らかのカスタム例外
                    // 「想定外のシステムエラーが発生しました。
                    //   システム管理者へ連絡してください。
                    //   {0}」
                    MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, cex.Message);
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region deleteButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： deleteButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/02　HuyTX    新規作成
        /// 2014/12/14　HuyTX    update source code
        /// 2014/12/20　HuyTX    Ver1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void deleteButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!DeleteCheck()) return;
                if (!DeleteConfirmCheck()) return;

                IDeleteBtnClickALInput alInput = new DeleteBtnClickALInput();
                alInput.SeikyuNyukinTblListDataTable = _seikyuNyukinTblListDataTable;

                // 2014.12.27 toyoda Delete Start
                //alInput.SeikyuDtlTblDataTableLoad = _seikyuDtlTblDTLoad;
                //alInput.SeikyuHdrTblDataTableLoad = _seikyuHdrTblDTLoad;
                //alInput.KurikoshiKinTblDataTableLoad = _kurikoshiKinTblDTLoad;
                // 2014.12.27 toyoda Delete End

                alInput.NyukinNo = nyukinNoTextBox.Text.Trim();
                alInput.NyukinmotoKbn = gyoshaRadioButton.Checked ? "1" : kojinRadioButton.Checked ? "2" : "0";
                alInput.GyoshaCd = gyoshaCdTextBox.Text.Trim();
                if (kojinRadioButton.Checked)
                {
                    JokasoDaichoMstDataSet.JokasoDaichoMstSearchDataTable jokasoDT = new JokasoDaichoMstDataSet.JokasoDaichoMstSearchDataTable();
                    _jokasoRow = jokasoDT.NewJokasoDaichoMstSearchRow();
                    _jokasoRow.JokasoHokenjoCd = _nyukinTblDTByKey[0].JokasoHokenjoCd;
                    _jokasoRow.JokasoTorokuNendo = _nyukinTblDTByKey[0].JokasoTorokuNendo;
                    _jokasoRow.JokasoRenban = _nyukinTblDTByKey[0].JokasoRenban;
                    alInput.JokasoRow = _jokasoRow;
                }
                
                alInput.ZeikaiKurikoshi = !string.IsNullOrEmpty(zeikaiKurikoshiTextBox.Text.Trim()) ? Decimal.Parse(zeikaiKurikoshiTextBox.Text.Trim()) : 0;

                // 2014.12.27 toyoda Delete Start
                //alInput.KensaIraiTblDataTableLoad = _kensaIraiTblDTLoad;
                //alInput.YoshiHanbaiHdrTblDataTableLoad = _yoshiHanbaiHdrTblDTLoad;
                //alInput.NenKaihiTblDataTableLoad = _nenKaihiTblDTLoad;
                // 2014.12.27 toyoda Delete End

                new DeleteBtnClickApplicationLogic().Execute(alInput);

                // Delete completed
                this.DialogResult = DialogResult.OK;
                Program.mForm.MovePrev();
            }
            catch (CustomException cex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), cex.ToString());

                if (cex.ResultCode == ResultCode.LockError)
                {
                    // 楽観ロックエラー
                    // 「対象の情報が更新されています。
                    //   再度検索後、操作をやり直してください。」
                    MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00009);
                }
                else
                {
                    // 何らかのカスタム例外
                    // 「想定外のシステムエラーが発生しました。
                    //   システム管理者へ連絡してください。
                    //   {0}」
                    MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, cex.Message);
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region closeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： closeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/02　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!TransitionCheck()) return;

                this.DialogResult = DialogResult.OK;
                Program.mForm.MovePrev();
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region NyukinShosaiForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： NyukinShosaiForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/02　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void NyukinShosaiForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F2:
                        updateButton.Focus();
                        updateButton.PerformClick();
                        break;

                    case Keys.F3:
                        deleteButton.Focus();
                        deleteButton.PerformClick();
                        break;

                    case Keys.F5:
                        jidoWarifuriButton.Focus();
                        jidoWarifuriButton.PerformClick();
                        break;

                    case Keys.F6:
                        kensakuButton.Focus();
                        kensakuButton.PerformClick();
                        break;

                    case Keys.F7:
                        clearButton.Focus();
                        clearButton.PerformClick();
                        break;

                    case Keys.F8:
                        henkinInputButton.Focus();
                        henkinInputButton.PerformClick();
                        break;

                    case Keys.F12:
                        closeButton.Focus();
                        closeButton.PerformClick();
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region numberTextBox_TextChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： numberTextBox_TextChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/12　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void numberTextBox_TextChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                TextBox textBox = (TextBox)sender;

                if (string.IsNullOrEmpty(textBox.Text.Trim())) return;

                textBox.Text = Math.Truncate(Decimal.Parse(textBox.Text)).ToString("N0");
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region tesuryoUchiRadioButton_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： tesuryoUchiRadioButton_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/09　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void tesuryoUchiRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!_isLoad) return;
                //if (string.IsNullOrEmpty(shiharaiTesuryoTextBox.Text.Trim()) || !NyukinCheck()) return;

                GetSanshutsuNyukingaku();
                //CalculatorKingaku(_sanshutsuNyukingaku);
                CalculatorKingaku(_sanshutsuNyukingaku, false);
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region seikyuNyukinListDataGridView_CellValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： seikyuNyukinListDataGridView_CellValueChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/10　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void seikyuNyukinListDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!_isLoad) return;

                if (seikyuNyukinListDataGridView.Columns[e.ColumnIndex].Name == nyukinWarifuriCol.Name)
                {
                    if (string.IsNullOrEmpty(Convert.ToString(seikyuNyukinListDataGridView.CurrentRow.Cells[nyukinWarifuriCol.Name].Value)))
                    {
                        seikyuNyukinListDataGridView.CurrentRow.Cells[nyukinWarifuriCol.Name].Value = 0;
                    }
                    GetSanshutsuNyukingaku();
                    CalculatorKingaku(_sanshutsuNyukingaku, false);
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region DoFormLoad
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoFormLoad
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/03　HuyTX    新規作成
        /// 2014/12/13　HuyTX    update source code
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            IFormLoadALInput alInput = new FormLoadALInput();
            alInput.NyukinNo = !string.IsNullOrEmpty(_nyukinNo) ? _nyukinNo : string.Empty;
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            //set source to shishoCombobox
            Utility.Utility.SetComboBoxList(shisyoComboBox, alOutput.ShishoMstDataTable, 
                                            alOutput.ShishoMstDataTable.ShishoNmColumn.ColumnName, 
                                            alOutput.ShishoMstDataTable.ShishoCdColumn.ColumnName, true);

            ConstMstDataSet.ConstMstDataTable constDT = (ConstMstDataSet.ConstMstDataTable)Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_002);
            Utility.Utility.SetComboBoxList(nyukinHohoComboBox, constDT, constDT.ConstValueColumn.ColumnName, constDT.ConstRenbanColumn.ColumnName, true);

            // 2014.12.27 toyoda Delete Start
            //_seikyuDtlTblDTLoad = alOutput.SeikyuDtlTblDataTable;
            //_kensaIraiTblDTLoad = alOutput.KensaIraiTblDataTable;
            //_yoshiHanbaiHdrTblDTLoad = alOutput.YoshiHanbaiHdrTblDataTable;
            //_nenKaihiTblDTLoad = alOutput.NenKaihiTblDataTable;
            //_seikyuHdrTblDTLoad = alOutput.SeikyuHdrTblDataTable;
            //_kurikoshiKinTblDTLoad = alOutput.KurikoshiKinTblDataTable;
            //_seikyuNyukinTblDTLoad = alOutput.SeikyuNyukinTblDataTable;
            // 2014.12.27 toyoda Delete End

            if (!string.IsNullOrEmpty(_nyukinNo))
            {
                _nyukinTblShosaiDataTable = alOutput.NyukinTblShosaiDataTable;
                _seikyuNyukinTblListDataTable = _nyukinTblShosaiDataTable.Count > 0 && _nyukinTblShosaiDataTable[0].NyukinSyubetsu == "1" ? alOutput.SeikyuNyukinTblListDataTable : new SeikyuNyukinTblDataSet.SeikyuNyukinTblListDataTable();
                _displayMode = alOutput.DisplayMode;

                _nyukinTblDTByKey = alOutput.NyukinTblDataTable;
            }

            SetDisplayControlByMode();

            if (!string.IsNullOrEmpty(_oyaSeikyuNo))
            {
                seikyuNoTextBox.Text = _oyaSeikyuNo;
            }
        }
        #endregion

        #region MakeDataInsert/Update

        #region CreateNyukinTblInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateNyukinTblInsert
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/03　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private NyukinTblDataSet.NyukinTblDataTable CreateNyukinTblInsert()
        {
            NyukinTblDataSet.NyukinTblDataTable nyukinDT = new NyukinTblDataSet.NyukinTblDataTable();
            NyukinTblDataSet.NyukinTblRow nyukinRow = nyukinDT.NewNyukinTblRow();

            //入金No
            string nendo = Utility.DateUtility.GetNendo(_currentDateTime).ToString();
            string nyukinNo = Utility.Saiban.GetSaibanRenban(nendo, Utility.Constants.SaibanKbnConstant.SAIBAN_KBN_07);
            nyukinRow.NyukinNo = nendo + nyukinNo;

            //支所コード
            nyukinRow.NyukinShisyoCd = shisyoComboBox.SelectedValue.ToString();

            //入金日
            nyukinRow.NyukinDt = nyukinDtDateTimePicker.Value.ToString("yyyyMMdd");

            //入金取扱日
            nyukinRow.NyukinToriatukaiDt = toriatsukaiDtDateTimePicker.Value.ToString("yyyyMMdd");

            #region 入金種別
            //入金種別
            if (seikyuRadioButton.Checked)
            {
                nyukinRow.NyukinSyubetsu = Utility.Constants.NyukinSyubetsuConstant.NYUKIN_SYUBETSU_1;
            }
            else if (maeukekinRadioButton.Checked)
            {
                nyukinRow.NyukinSyubetsu = Utility.Constants.NyukinSyubetsuConstant.NYUKIN_SYUBETSU_2;
            }
            else if (yoshiHanbaiRadioButton.Checked)
            {
                nyukinRow.NyukinSyubetsu = Utility.Constants.NyukinSyubetsuConstant.NYUKIN_SYUBETSU_3;
            }
            else if (nenkaihiRadioButton.Checked)
            {
                nyukinRow.NyukinSyubetsu = Utility.Constants.NyukinSyubetsuConstant.NYUKIN_SYUBETSU_4;
            }
            else if (keiryoSyomeiRadioButton.Checked)
            {
                nyukinRow.NyukinSyubetsu = Utility.Constants.NyukinSyubetsuConstant.NYUKIN_SYUBETSU_5;
            }
            else if (kensaTesuryoRadioButton.Checked)
            {
                nyukinRow.NyukinSyubetsu = Utility.Constants.NyukinSyubetsuConstant.NYUKIN_SYUBETSU_6;
            }
            else if (kinoHoshoRadioButton.Checked)
            {
                nyukinRow.NyukinSyubetsu = Utility.Constants.NyukinSyubetsuConstant.NYUKIN_SYUBETSU_7;
            }
            #endregion

            //連携No
            nyukinRow.NyukinRenkeiNo = string.Empty;

            //計量証明検査依頼年度
            nyukinRow.KeiryoShomeiIraiNendo = string.Empty;

            //計量証明支所コード
            nyukinRow.KeiryoShomeiIraiSishoCd = string.Empty;

            //計量証明依頼連番
            nyukinRow.KeiryoShomeiIraiRenban = string.Empty;

            //検査依頼法定区分
            nyukinRow.KensaIraiHoteiKbn = string.Empty;

            //検査依頼保健所コード
            nyukinRow.KensaIraiHokenjoCd = string.Empty;

            //検査依頼年度
            nyukinRow.KensaIraiNendo = string.Empty;

            //検査依頼連番
            nyukinRow.KensaIraiRenban = string.Empty;

            //入金方法
            nyukinRow.NyukinHoho = nyukinHohoComboBox.SelectedValue.ToString();

            //入金口座
            nyukinRow.NyukinKoza = kozaNoTextBox.Text.Trim();

            //請求額
            object seikyuGakuTotal = _seikyuNyukinTblListDataTable != null ? _seikyuNyukinTblListDataTable.Compute(string.Format("SUM({0})", _seikyuNyukinTblListDataTable.seikyuKingakuColColumn.ColumnName), "") : null;
            nyukinRow.SeikyuGaku = seikyuGakuTotal != null ? Decimal.Parse(seikyuGakuTotal.ToString()) : 0;

            //入金入力額
            nyukinRow.NyukinGaku = Convert.ToDecimal(nyukinGakuTextBox.Text.Trim());

            //手数料
            nyukinRow.TesuryoGaku = !string.IsNullOrEmpty(shiharaiTesuryoTextBox.Text.Trim()) ? Convert.ToDecimal(shiharaiTesuryoTextBox.Text.Trim()) : 0;

            //手数料内外区分
            nyukinRow.TesuryoNaigaiKbn = tesuryoUchiRadioButton.Checked ? "1" : "2";

            //実入金額
            decimal nyukinGaku = 0;
            decimal shiharaiTesuryo = 0;
            Decimal.TryParse(nyukinGakuTextBox.Text, out nyukinGaku);
            Decimal.TryParse(shiharaiTesuryoTextBox.Text, out shiharaiTesuryo);
            nyukinRow.JitsuNyukinGaku = tesuryoUchiRadioButton.Checked ? nyukinGaku : (nyukinGaku - shiharaiTesuryo);

            //入金元区分
            nyukinRow.NyukinmotoKbn = gyoshaRadioButton.Checked ? "1" : "2";

            //業者コード
            nyukinRow.NyukinGyosyaCd = gyoshaRadioButton.Checked ? gyoshaCdTextBox.Text.Trim() : string.Empty;

            //浄化槽保健所コード
            nyukinRow.JokasoHokenjoCd = kojinRadioButton.Checked ? (_jokasoRow != null ? _jokasoRow.JokasoHokenjoCd : string.Empty) : string.Empty;

            //浄化槽台帳登録年度
            nyukinRow.JokasoTorokuNendo = kojinRadioButton.Checked ? (_jokasoRow != null ? _jokasoRow.JokasoTorokuNendo : string.Empty) : string.Empty;

            //浄化槽台帳連番
            nyukinRow.JokasoRenban = kojinRadioButton.Checked ? (_jokasoRow != null ? _jokasoRow.JokasoRenban : string.Empty) : string.Empty;

            //入金者名称
            nyukinRow.NyukinsyaNm = nyukinshaNmTextBox.Text;

            //割振り済フラグ
            nyukinRow.WarifuriFlg = seikyuZangakuTextBox.Text == "0" ? "1" : "0";

            //割振り済金額
            nyukinRow.WarifuriGaku = _nyukinWarifuriTotal;

            //返金額合計
            nyukinRow.HenkinGaku = 0;

            //完済フラグ
            nyukinRow.KansaiFlag = "0";

            //次回繰り越し金
            nyukinRow.JikaiKurikoshiKin = !string.IsNullOrEmpty(jikaiKurikoshiTextBox.Text.Trim()) ? Convert.ToDecimal(jikaiKurikoshiTextBox.Text.Trim()) : 0;

            //繰り越し金
            decimal zeikaiKurikoshi = 0;
            decimal sonotaSashihiki = 0;
            Decimal.TryParse(zeikaiKurikoshiTextBox.Text.Trim(), out zeikaiKurikoshi);
            Decimal.TryParse(sonotaSashihikiTextBox.Text.Trim(), out sonotaSashihiki);
            //nyukinRow.KurikoshiKin = !string.IsNullOrEmpty(zeikaiKurikoshiTextBox.Text.Trim()) ? Convert.ToDecimal(zeikaiKurikoshiTextBox.Text.Trim()) : 0;
            nyukinRow.KurikoshiKin = zeikaiKurikoshi + sonotaSashihiki;

            //登録日
            nyukinRow.InsertDt = _currentDateTime;

            //登録者
            nyukinRow.InsertUser = _loginUser;

            //登録端末
            nyukinRow.InsertTarm = _loginTarm;

            //更新日
            nyukinRow.UpdateDt = _currentDateTime;

            //更新者
            nyukinRow.UpdateUser = _loginUser;

            //更新端末
            nyukinRow.UpdateTarm = _loginTarm;

            nyukinDT.AddNyukinTblRow(nyukinRow);
            nyukinRow.AcceptChanges();
            nyukinRow.SetAdded();

            return nyukinDT;
        }
        #endregion

        #region CreateNyukinTblUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateNyukinTblUpdate
        /// <summary>
        /// 
        /// </summary>
        ///<param name="nyukinTblDT"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/03　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private NyukinTblDataSet.NyukinTblDataTable CreateNyukinTblUpdate(NyukinTblDataSet.NyukinTblDataTable nyukinTblDT)
        {
            //入金日
            nyukinTblDT[0].NyukinDt = nyukinDtDateTimePicker.Value.ToString("yyyyMMdd");

            //入金取扱日
            nyukinTblDT[0].NyukinToriatukaiDt = toriatsukaiDtDateTimePicker.Value.ToString("yyyyMMdd");

            //入金方法
            nyukinTblDT[0].NyukinHoho = nyukinHohoComboBox.SelectedValue.ToString();

            //入金口座
            nyukinTblDT[0].NyukinKoza = kozaNoTextBox.Text.Trim();

            //入金入力額
            nyukinTblDT[0].NyukinGaku = !string.IsNullOrEmpty(nyukinGakuTextBox.Text.Trim()) ? Convert.ToDecimal(nyukinGakuTextBox.Text.Trim()) : 0;

            //手数料
            nyukinTblDT[0].TesuryoGaku = !string.IsNullOrEmpty(shiharaiTesuryoTextBox.Text.Trim()) ? Convert.ToDecimal(shiharaiTesuryoTextBox.Text.Trim()) : 0;

            //手数料内外区分
            nyukinTblDT[0].TesuryoNaigaiKbn = tesuryoUchiRadioButton.Checked ? "1" : "2";

            //実入金額
            nyukinTblDT[0].JitsuNyukinGaku = tesuryoUchiRadioButton.Checked ? nyukinTblDT[0].NyukinGaku : nyukinTblDT[0].NyukinGaku - nyukinTblDT[0].TesuryoGaku;

            //入金者名称
            nyukinTblDT[0].NyukinsyaNm = nyukinshaNmTextBox.Text;

            //割振り済フラグ
            nyukinTblDT[0].WarifuriFlg = seikyuZangakuTextBox.Text.Trim() == "0" ? "1" : "0";

            //割振り済金額
            nyukinTblDT[0].WarifuriGaku = _nyukinWarifuriTotal;

            //次回繰り越し金
            nyukinTblDT[0].JikaiKurikoshiKin = !string.IsNullOrEmpty(jikaiKurikoshiTextBox.Text.Trim()) ? Convert.ToDecimal(jikaiKurikoshiTextBox.Text.Trim()) : 0;

            //更新者
            nyukinTblDT[0].UpdateUser = _loginUser;

            //更新端末
            nyukinTblDT[0].UpdateTarm = _loginTarm;

            return nyukinTblDT;
        }
        #endregion

        #endregion

        #region SetDisplayControl

        #region DisplayControlModeWaitingKeyInput
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DisplayControlModeWaitingKeyInput
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/06　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DisplayControlModeWaitingKeyInput()
        {
            //請求No
            seikyuNoTextBox.Enabled = true;
            seikyuNoTextBox.Clear();

            //連続入力チェックボックス
            renzokuCheckBox.Enabled = true;
            renzokuCheckBox.Checked = renzokuCheckBox.Checked;

            //検索ボタン
            kensakuButton.Enabled = true;

            //クリアボタン
            clearButton.Enabled = true;

            //入金No
            nyukinNoTextBox.Enabled = false;
            nyukinNoTextBox.Clear();

            //支所コンボボックス
            shisyoComboBox.Enabled = false;
            shisyoComboBox.SelectedIndex = 0;

            //業者/個人ラジオボタン
            nyukinKbnPanel.Enabled = true;
            gyoshaRadioButton.Checked = true;

            //業者コード
            gyoshaCdTextBox.Enabled = true;
            gyoshaCdTextBox.Clear();

            //業者名
            gyoshaNmTextBox.Enabled = false;
            gyoshaNmTextBox.Clear();

            //業者検索ボタン
            gyoshaSrhButton.Enabled = true;

            //設置者名
            settishaNmTextBox.Enabled = true;
            settishaNmTextBox.Clear();

            //設置者検索ボタン
            jokasoSrhButton.Enabled = true;

            //入金者
            nyukinshaNmTextBox.Enabled = false;
            nyukinshaNmTextBox.Clear();

            //口座番号
            kozaNoTextBox.Enabled = false;
            kozaNoTextBox.Clear();

            //入金種別ラジオボタン
            nyukinShubetsuPanel.Enabled = false;
            seikyuRadioButton.Checked = true;

            //入金方法
            nyukinHohoComboBox.Enabled = false;
            nyukinHohoComboBox.SelectedIndex = renzokuCheckBox.Checked ? nyukinHohoComboBox.SelectedIndex : 0;

            //入金額
            nyukinGakuTextBox.Enabled = false;
            nyukinGakuTextBox.Clear();

            //自動割振りボタン
            jidoWarifuriButton.Enabled = false;

            //支払手数料
            shiharaiTesuryoTextBox.Enabled = false;
            shiharaiTesuryoTextBox.Clear();

            //支払手数料内外区分
            tesuryoKbnPanel.Enabled = false;
            tesuryoUchiRadioButton.Checked = true;

            //入金日
            nyukinDtDateTimePicker.Enabled = false;
            nyukinDtDateTimePicker.Value = renzokuCheckBox.Checked ? nyukinDtDateTimePicker.Value : _currentDateTime;

            //入金取扱日
            toriatsukaiDtDateTimePicker.Enabled = false;
            toriatsukaiDtDateTimePicker.Value = renzokuCheckBox.Checked ? toriatsukaiDtDateTimePicker.Value : _currentDateTime;

            //最終返金日
            henkinDtTextBox.Enabled = false;
            henkinDtTextBox.Clear();

            //返金金額
            henkinsumiGakuTextBox.Enabled = false;
            henkinsumiGakuTextBox.Clear();

            //返金入力ボタン
            henkinInputButton.Enabled = false;

            //繰り越し金
            zeikaiKurikoshiTextBox.Enabled = false;
            zeikaiKurikoshiTextBox.Clear();

            //その他差引額
            sonotaSashihikiTextBox.Enabled = false;
            sonotaSashihikiTextBox.Clear();

            //次回繰越し金
            jikaiKurikoshiTextBox.Enabled = false;
            jikaiKurikoshiTextBox.Clear();

            //請求残合計
            seikyuZangakuTextBox.Enabled = false;
            seikyuZangakuTextBox.Clear();

            //請求入金一覧
            seikyuNyukinListDataGridView.DataSource = null;
            seikyuNyukinListDataGridView.Rows.Clear();
            SetDisplayDgv();

            //更新ボタン
            updateButton.Enabled = false;

            //削除ボタン
            deleteButton.Enabled = false;

        }
        #endregion

        #region DisplayControlModeAdd
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DisplayControlModeAdd
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/06　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DisplayControlModeAdd()
        {
            //請求No
            seikyuNoTextBox.Enabled = false;

            //連続入力チェックボックス
            renzokuCheckBox.Enabled = true;
            renzokuCheckBox.Checked = renzokuCheckBox.Checked;

            //検索ボタン
            kensakuButton.Enabled = false;

            //クリアボタン
            clearButton.Enabled = true;

            //入金No
            nyukinNoTextBox.Enabled = false;
            nyukinNoTextBox.Clear();

            //支所コンボボックス
            shisyoComboBox.Enabled = false;
            shisyoComboBox.SelectedValue = _shozokuShishoCd;

            //業者/個人ラジオボタン
            nyukinKbnPanel.Enabled = false;
            if (!string.IsNullOrEmpty(seikyuNoTextBox.Text))
            {
                gyoshaRadioButton.Checked = _seikyushoKagamiHdrInfoDataTable[0].SeikyusakiKbn == "1" ? true : false;
                kojinRadioButton.Checked = _seikyushoKagamiHdrInfoDataTable[0].SeikyusakiKbn == "2" ? true : false;
            }

            //業者コード
            gyoshaCdTextBox.Enabled = false;
            gyoshaCdTextBox.Text = !string.IsNullOrEmpty(seikyuNoTextBox.Text) ? _seikyushoKagamiHdrInfoDataTable[0].IkkatsuSeikyuSakiCd : gyoshaCdTextBox.Text;

            //業者名
            gyoshaNmTextBox.Enabled = false;
            gyoshaNmTextBox.Text = _seikyushoKagamiHdrInfoDataTable[0].GyoshaNm;

            //業者検索ボタン
            gyoshaSrhButton.Enabled = false;

            //設置者名
            settishaNmTextBox.Enabled = false;
            settishaNmTextBox.Text = _seikyushoKagamiHdrInfoDataTable[0].JokasoSetchishaNm;

            //設置者検索ボタン
            jokasoSrhButton.Enabled = false;

            //入金者
            nyukinshaNmTextBox.Enabled = true;
            nyukinshaNmTextBox.Text = !string.IsNullOrEmpty(seikyuNoTextBox.Text) ? _seikyushoKagamiHdrInfoDataTable[0].SeikyusakiNm : (gyoshaRadioButton.Checked ? _seikyushoKagamiHdrInfoDataTable[0].GyoshaNm : _seikyushoKagamiHdrInfoDataTable[0].JokasoSetchishaNm);

            //口座番号
            kozaNoTextBox.Enabled = true;
            kozaNoTextBox.Clear();

            //入金種別ラジオボタン
            nyukinShubetsuPanel.Enabled = false;
            seikyuRadioButton.Checked = true;

            //入金方法
            nyukinHohoComboBox.Enabled = true;
            nyukinHohoComboBox.SelectedIndex = renzokuCheckBox.Checked ? nyukinHohoComboBox.SelectedIndex : 0;

            //入金額
            nyukinGakuTextBox.Enabled = true;
            object zangakuTotal = _seikyuNyukinTblListDataTable != null ? _seikyuNyukinTblListDataTable.Compute(string.Format("SUM({0})", _seikyuNyukinTblListDataTable.zangakuColColumn.ColumnName), "") : null;
            nyukinGakuTextBox.Text = zangakuTotal != null ? zangakuTotal.ToString() : "0";

            //自動割振りボタン
            jidoWarifuriButton.Enabled = true;

            //支払手数料
            shiharaiTesuryoTextBox.Enabled = true;
            shiharaiTesuryoTextBox.Clear();

            //支払手数料内外区分
            tesuryoKbnPanel.Enabled = true;
            tesuryoUchiRadioButton.Checked = true;

            //入金日
            nyukinDtDateTimePicker.Enabled = true;
            nyukinDtDateTimePicker.Value = renzokuCheckBox.Checked ? nyukinDtDateTimePicker.Value : _currentDateTime;

            //入金取扱日
            toriatsukaiDtDateTimePicker.Enabled = true;
            toriatsukaiDtDateTimePicker.Value = renzokuCheckBox.Checked ? toriatsukaiDtDateTimePicker.Value : _currentDateTime;

            //最終返金日
            henkinDtTextBox.Enabled = false;
            henkinDtTextBox.Clear();

            //返金金額
            henkinsumiGakuTextBox.Enabled = false;
            henkinsumiGakuTextBox.Clear();

            //返金入力ボタン
            henkinInputButton.Enabled = false;

            //繰り越し金
            zeikaiKurikoshiTextBox.Enabled = false;
            zeikaiKurikoshiTextBox.Text = !_seikyushoKagamiHdrInfoDataTable[0].IsKurikoshiKinNull() ? _seikyushoKagamiHdrInfoDataTable[0].KurikoshiKin.ToString() : "0";

            //その他差引額
            sonotaSashihikiTextBox.Enabled = false;
            sonotaSashihikiTextBox.Text = !_seikyushoKagamiHdrInfoDataTable[0].IsTotalSeikyuKingakuKeiNegNull() ? Math.Abs(_seikyushoKagamiHdrInfoDataTable[0].TotalSeikyuKingakuKeiNeg).ToString() : "0";

            //次回繰越し金
            jikaiKurikoshiTextBox.Enabled = false;
            jikaiKurikoshiTextBox.Text = "0";

            //請求残合計
            seikyuZangakuTextBox.Enabled = false;
            seikyuZangakuTextBox.Text = nyukinGakuTextBox.Text;

            //請求入金一覧
            seikyuNyukinListDataGridView.Enabled = true;
            seikyuNyukinListDataGridView.DataSource = _seikyuNyukinTblListDataTable;
            SetDisplayDgv();

            //更新ボタン
            updateButton.Enabled = true;

            //削除ボタン
            deleteButton.Enabled = false;

        }
        #endregion

        #region DisplayControlModeEditOrRefs
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DisplayControlModeEditOrRefs
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/07　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DisplayControlModeEditOrRefs()
        {
            //請求No
            seikyuNoTextBox.Enabled = false;
            seikyuNoTextBox.Clear();

            //連続入力チェックボックス
            renzokuCheckBox.Enabled = _displayMode == DispMode.Edit ? true : false;
            renzokuCheckBox.Checked = renzokuCheckBox.Checked;

            //検索ボタン
            kensakuButton.Enabled = false;

            //クリアボタン
            clearButton.Enabled = true;

            //入金No
            nyukinNoTextBox.Enabled = false;
            nyukinNoTextBox.Text = _nyukinTblShosaiDataTable.Count > 0 ? _nyukinTblShosaiDataTable[0].NyukinNo : string.Empty;

            //支所コンボボックス
            shisyoComboBox.Enabled = false;
            shisyoComboBox.SelectedValue = _nyukinTblShosaiDataTable.Count > 0 ? _nyukinTblShosaiDataTable[0].NyukinShisyoCd : string.Empty;

            //業者/個人ラジオボタン
            nyukinKbnPanel.Enabled = false;
            gyoshaRadioButton.Checked = (_nyukinTblShosaiDataTable.Count > 0 && _nyukinTblShosaiDataTable[0].NyukinmotoKbn == "1") ? true : false ;
            kojinRadioButton.Checked = (_nyukinTblShosaiDataTable.Count > 0 && _nyukinTblShosaiDataTable[0].NyukinmotoKbn == "2") ? true : false;

            //業者コード
            gyoshaCdTextBox.Enabled = false;
            gyoshaCdTextBox.Text = gyoshaRadioButton.Checked && _nyukinTblShosaiDataTable.Count > 0 ? _nyukinTblShosaiDataTable[0].NyukinGyosyaCd : string.Empty;
            
            //業者名
            gyoshaNmTextBox.Enabled = false;
            gyoshaNmTextBox.Text = gyoshaRadioButton.Checked && _nyukinTblShosaiDataTable.Count > 0 ? _nyukinTblShosaiDataTable[0].GyoshaNm : string.Empty;

            //業者検索ボタン
            gyoshaSrhButton.Enabled = false;

            //設置者名
            settishaNmTextBox.Enabled = false;
            settishaNmTextBox.Text = kojinRadioButton.Checked && _nyukinTblShosaiDataTable.Count > 0 ? _nyukinTblShosaiDataTable[0].JokasoSetchishaNm : string.Empty;

            //設置者検索ボタン
            jokasoSrhButton.Enabled = false;

            //入金者
            nyukinshaNmTextBox.Enabled = _displayMode == DispMode.Edit ? true : false;
            nyukinshaNmTextBox.Text = _nyukinTblShosaiDataTable.Count > 0 ? _nyukinTblShosaiDataTable[0].NyukinsyaNm : string.Empty;

            //口座番号
            kozaNoTextBox.Enabled = _displayMode == DispMode.Edit ? true : false;
            kozaNoTextBox.Text = _nyukinTblShosaiDataTable.Count > 0 ? _nyukinTblShosaiDataTable[0].NyukinKoza : string.Empty;

            //入金種別ラジオボタン
            nyukinShubetsuPanel.Enabled = false;

            if (_nyukinTblShosaiDataTable.Count > 0)
            {
                if (_nyukinTblShosaiDataTable[0].NyukinSyubetsu == Utility.Constants.NyukinSyubetsuConstant.NYUKIN_SYUBETSU_1)
                {
                    seikyuRadioButton.Checked = true;
                }
                else if (_nyukinTblShosaiDataTable[0].NyukinSyubetsu == Utility.Constants.NyukinSyubetsuConstant.NYUKIN_SYUBETSU_2)
                {
                    maeukekinRadioButton.Checked = true;
                }
                else if (_nyukinTblShosaiDataTable[0].NyukinSyubetsu == Utility.Constants.NyukinSyubetsuConstant.NYUKIN_SYUBETSU_3)
                {
                    yoshiHanbaiRadioButton.Checked = true;
                }
                else if (_nyukinTblShosaiDataTable[0].NyukinSyubetsu == Utility.Constants.NyukinSyubetsuConstant.NYUKIN_SYUBETSU_4)
                {
                    nenkaihiRadioButton.Checked = true;
                }
                else if (_nyukinTblShosaiDataTable[0].NyukinSyubetsu == Utility.Constants.NyukinSyubetsuConstant.NYUKIN_SYUBETSU_5)
                {
                    keiryoSyomeiRadioButton.Checked = true;
                }
                else if (_nyukinTblShosaiDataTable[0].NyukinSyubetsu == Utility.Constants.NyukinSyubetsuConstant.NYUKIN_SYUBETSU_6)
                {
                    kensaTesuryoRadioButton.Checked = true;
                }
                else if (_nyukinTblShosaiDataTable[0].NyukinSyubetsu == Utility.Constants.NyukinSyubetsuConstant.NYUKIN_SYUBETSU_7)
                {
                    kinoHoshoRadioButton.Checked = true;
                }
            }

            //入金方法
            nyukinHohoComboBox.Enabled = _displayMode == DispMode.Edit ? true : false;
            nyukinHohoComboBox.SelectedValue = renzokuCheckBox.Checked ? nyukinHohoComboBox.SelectedValue : (_nyukinTblShosaiDataTable.Count > 0 ? _nyukinTblShosaiDataTable[0].NyukinHoho : string.Empty);

            //入金額
            nyukinGakuTextBox.Enabled = _displayMode == DispMode.Edit ? true : false;
            nyukinGakuTextBox.Text = _nyukinTblShosaiDataTable.Count > 0 && !_nyukinTblShosaiDataTable[0].IsNyukinGakuNull() ? Math.Truncate(_nyukinTblShosaiDataTable[0].NyukinGaku).ToString() : string.Empty;

            //自動割振りボタン
            jidoWarifuriButton.Enabled = _displayMode == DispMode.Edit ? true : false;

            //支払手数料
            shiharaiTesuryoTextBox.Enabled = _displayMode == DispMode.Edit ? true : false;
            shiharaiTesuryoTextBox.Text = _nyukinTblShosaiDataTable.Count > 0 && !_nyukinTblShosaiDataTable[0].IsTesuryoGakuNull() ? Math.Truncate(_nyukinTblShosaiDataTable[0].TesuryoGaku).ToString() : string.Empty;

            //支払手数料内外区分
            tesuryoKbnPanel.Enabled = _displayMode == DispMode.Edit ? true : false;
            tesuryoUchiRadioButton.Checked = _nyukinTblShosaiDataTable.Count > 0 && _nyukinTblShosaiDataTable[0].TesuryoNaigaiKbn == "1" ? true : false;
            tesuryoSotoRadioButton.Checked = _nyukinTblShosaiDataTable.Count > 0 && _nyukinTblShosaiDataTable[0].TesuryoNaigaiKbn == "2" ? true : false;

            //入金日
            nyukinDtDateTimePicker.Enabled = _displayMode == DispMode.Edit ? true : false;
            //nyukinDtDateTimePicker.Value = renzokuCheckBox.Checked ? nyukinDtDateTimePicker.Value : DateTime.ParseExact(_nyukinTblShosaiDataTable[0].NyukinDt, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            nyukinDtDateTimePicker.Value = !renzokuCheckBox.Checked && _nyukinTblShosaiDataTable.Count > 0 ? DateTime.ParseExact(_nyukinTblShosaiDataTable[0].NyukinDt, "yyyy/MM/dd", CultureInfo.InvariantCulture) : nyukinDtDateTimePicker.Value;
            
            //入金取扱日
            toriatsukaiDtDateTimePicker.Enabled = _displayMode == DispMode.Edit ? true : false;
            //toriatsukaiDtDateTimePicker.Value = renzokuCheckBox.Checked ? toriatsukaiDtDateTimePicker.Value : DateTime.ParseExact(_nyukinTblShosaiDataTable[0].NyukinToriatukaiDt, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            toriatsukaiDtDateTimePicker.Value = !renzokuCheckBox.Checked && _nyukinTblShosaiDataTable.Count > 0 ? DateTime.ParseExact(_nyukinTblShosaiDataTable[0].NyukinToriatukaiDt, "yyyy/MM/dd", CultureInfo.InvariantCulture) : toriatsukaiDtDateTimePicker.Value;

            //最終返金日
            henkinDtTextBox.Enabled = false;
            henkinDtTextBox.Text = _nyukinTblShosaiDataTable.Count > 0 ? _nyukinTblShosaiDataTable[0].HenkinDt : string.Empty;

            //返金金額
            henkinsumiGakuTextBox.Enabled = false;
            henkinsumiGakuTextBox.Text = _nyukinTblShosaiDataTable.Count > 0 && !_nyukinTblShosaiDataTable[0].IsHenkinGakuNull() ? _nyukinTblShosaiDataTable[0].HenkinGaku.ToString() : string.Empty;

            //返金入力ボタン
            henkinInputButton.Enabled = true;

            //繰り越し金
            zeikaiKurikoshiTextBox.Enabled = false;
            zeikaiKurikoshiTextBox.Text = _nyukinTblShosaiDataTable.Count > 0 && !_nyukinTblShosaiDataTable[0].IsKurikoshiKinNull() ? _nyukinTblShosaiDataTable[0].KurikoshiKin.ToString() : string.Empty;

            //その他差引額
            sonotaSashihikiTextBox.Enabled = false;
            sonotaSashihikiTextBox.Text = "0";

            //次回繰越し金
            jikaiKurikoshiTextBox.Enabled = false;
            jikaiKurikoshiTextBox.Text = _nyukinTblShosaiDataTable.Count > 0 && !_nyukinTblShosaiDataTable[0].IsJikaiKurikoshiKinNull() ? _nyukinTblShosaiDataTable[0].JikaiKurikoshiKin.ToString() : string.Empty;

            //請求残合計
            seikyuZangakuTextBox.Enabled = false;
            object zangakuTotal = _seikyuNyukinTblListDataTable != null ? _seikyuNyukinTblListDataTable.Compute(string.Format("SUM({0})", _seikyuNyukinTblListDataTable.zangakuColColumn.ColumnName), "") : null; 
            seikyuZangakuTextBox.Text = zangakuTotal != null ? zangakuTotal.ToString() : "0";

            //請求入金一覧
            SetDisplayDgv();
            seikyuNyukinListDataGridView.DataSource = _seikyuNyukinTblListDataTable;

            //更新ボタン
            updateButton.Enabled = _displayMode == DispMode.Edit ? true : false;

            //削除ボタン
            deleteButton.Enabled = _displayMode == DispMode.Edit ? true : false;

        }
        #endregion

        #region SetDisplayControlByMode
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDisplayControlByMode
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/12　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDisplayControlByMode()
        {
            switch (_displayMode)
            {
                case DispMode.Add:
                    DisplayControlModeAdd();
                    break;
                case DispMode.Edit:
                case DispMode.Reference:
                    DisplayControlModeEditOrRefs();
                    break;
                case DispMode.WaitingKeyInput:
                    DisplayControlModeWaitingKeyInput();
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region SetDisplayDgv
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDisplayDgv
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/10　HuyTX    新規作成
        /// 2014/12/22　HuyTX    Ver1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDisplayDgv()
        {
            foreach (DataGridViewColumn col in seikyuNyukinListDataGridView.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;

                if (col.DataPropertyName == _seikyuNyukinTblListDataTable.KaikeiRendoFlgColumn.ColumnName
                    || col.DataPropertyName == _seikyuNyukinTblListDataTable.YoshiHanbaiNoColumn.ColumnName)
                {
                    col.Visible = false;
                }

                if ((_displayMode == DispMode.Add || _displayMode == DispMode.Edit) && col.Name == nyukinWarifuriCol.Name)
                {
                    col.ReadOnly = false;
                    continue;
                }
                col.ReadOnly = true;
            }

        }
        #endregion

        #endregion

        #region SetControlDomain
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetControlDomain
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/11　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            seikyuNoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 8);
            nyukinNoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 11);
            //gyoshaCdTextBox.SetStdControlDomain(ZControlDomain.ZT_GYOSHA_CD);
            gyoshaCdTextBox.SetStdControlDomain(ZControlDomain.ZT_GYOSHA_CD, 4);
            gyoshaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);
            settishaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);
            nyukinshaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);
            kozaNoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);
            nyukinGakuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 10);
            shiharaiTesuryoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 10);
            henkinDtTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 10);
            henkinsumiGakuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 10);
            zeikaiKurikoshiTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 10);
            sonotaSashihikiTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 10);
            jikaiKurikoshiTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 10);
            seikyuZangakuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 10);

            seikyuNyukinListDataGridView.SetStdControlDomain(shishosakiNmCol.Index, ZControlDomain.ZG_STD_NAME, 60);
            seikyuNyukinListDataGridView.SetStdControlDomain(shishoNoCol.Index, ZControlDomain.ZG_STD_CD, 10);
            seikyuNyukinListDataGridView.SetStdControlDomain(renbanCol.Index, ZControlDomain.ZG_STD_NUM, 3);
            seikyuNyukinListDataGridView.SetStdControlDomain(seikyuKamokuCol.Index, ZControlDomain.ZG_STD_NAME, 40);
            seikyuNyukinListDataGridView.SetStdControlDomain(syohinCol.Index, ZControlDomain.ZG_STD_NAME, 60);
            seikyuNyukinListDataGridView.SetStdControlDomain(seikyuKingakuCol.Index, ZControlDomain.ZG_STD_NUM, 10);
            seikyuNyukinListDataGridView.SetStdControlDomain(nyukinWarifuriCol.Index, ZControlDomain.ZG_STD_NUM, 10, 0, InputValidateUtility.SignFlg.Positive);
            seikyuNyukinListDataGridView.SetStdControlDomain(zangakuCol.Index, ZControlDomain.ZG_STD_NUM, 10);
        }
        #endregion

        #region Validate

        #region UpdateCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： UpdateCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/08　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool UpdateCheck()
        {
            _errMsg.Length = 0;

            //入金者
            if (string.IsNullOrEmpty(nyukinshaNmTextBox.Text.Trim()))
            {
                _errMsg.AppendLine("入金者を入力してください");
            }

            //入金額
            if (string.IsNullOrEmpty(nyukinGakuTextBox.Text.Trim()))
            {
                _errMsg.AppendLine("入金額を入力してください");
            }

            //入金方法
            if (nyukinHohoComboBox.SelectedIndex <= 0)
            {
                _errMsg.AppendLine("入金方法を入力してください");
            }

            //入金方法、手数料
            if ((nyukinHohoComboBox.SelectedValue.ToString() == Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_003 || nyukinHohoComboBox.GetItemText(nyukinHohoComboBox.SelectedItem) == "現金")
                && (!string.IsNullOrEmpty(shiharaiTesuryoTextBox.Text.Trim()) && Convert.ToInt32(shiharaiTesuryoTextBox.Text.Trim()) > 0))
            {
                _errMsg.AppendLine("現金の場合、支払手数料は入力できません");
            }

            //残額＜０
            if(_seikyuNyukinTblListDataTable.Select(string.Format("{0} < 0", _seikyuNyukinTblListDataTable.zangakuColColumn.ColumnName)).Length > 0
            || (!string.IsNullOrEmpty(seikyuZangakuTextBox.Text.Trim()) && Convert.ToDecimal(seikyuZangakuTextBox.Text.Trim()) < 0))
            {
               _errMsg.AppendLine("入金割振り額が請求額をオーバーしています。");
            }


            //算出入金額と割り振り額の不一致
            GetSanshutsuNyukingaku();
            if (!string.IsNullOrEmpty(jikaiKurikoshiTextBox.Text.Trim())
                && _sanshutsuNyukingaku != (Convert.ToDecimal(jikaiKurikoshiTextBox.Text.Trim()) + _nyukinWarifuriTotal))
            {
                _errMsg.AppendLine("入金額と割振り額が一致しません。\n自動割振りからやり直して、正しい金額を割り振ってください。");
            }

            if (!string.IsNullOrEmpty(_errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, _errMsg.ToString());
                return false;
            }


            return true;
        }
        #endregion

        #region NyukinCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： NyukinCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/09　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool NyukinCheck()
        {
            _errMsg.Length = 0;
            if (string.IsNullOrEmpty(nyukinGakuTextBox.Text))
            {
                _errMsg.AppendLine("入金額を入力してください");
            }
            else if (tesuryoUchiRadioButton.Checked
                && !string.IsNullOrEmpty(shiharaiTesuryoTextBox.Text.Trim()) 
                && Convert.ToInt32(nyukinGakuTextBox.Text) < Convert.ToInt32(shiharaiTesuryoTextBox.Text))
            {
                _errMsg.AppendLine("支払手数料が入金額をオーバーしています");
            }

            if (!string.IsNullOrEmpty(_errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, _errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region TransitionCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： TransitionCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/09　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool TransitionCheck()
        {
            if (_displayMode != DispMode.Add && _displayMode != DispMode.Edit) return true;

            return MessageForm.Show2(MessageForm.DispModeType.Question, "更新処理が行われていない場合、入力した内容は全て破棄されます。\n入金入力を終了しますか？") == DialogResult.Yes;
        }
        #endregion

        #region UpdateConfirmCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： UpdateConfirmCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/10　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool UpdateConfirmCheck()
        {
            _errMsg.Length = 0;

            //次回繰越し金＞0
            if (!string.IsNullOrEmpty(jikaiKurikoshiTextBox.Text.Trim())
                && Convert.ToDecimal(jikaiKurikoshiTextBox.Text.Trim()) > 0)
            {
                _errMsg.AppendLine("入金額、繰り越し額の総計が請求額を上回っています。\n超過分を次回繰越し金として更新します。\nよろしいですか？");
            }

            //請求残合計＞０
            if (!string.IsNullOrEmpty(seikyuZangakuTextBox.Text.Trim())
                && Convert.ToDecimal(seikyuZangakuTextBox.Text.Trim()) > 0)
            {
                _errMsg.AppendLine("入金額が請求額に対して不足しています。\nこのまま更新してよろしいですか？");
            }

            //会計済
            if (_displayMode == DispMode.Edit
                && _seikyuNyukinTblListDataTable.Select(string.Format("{0} = '1'", _seikyuNyukinTblListDataTable.KaikeiRendoFlgColumn.ColumnName)).Length > 0)
            {
                _errMsg.AppendLine("会計連動済のデータが存在します。\nこのまま更新してよろしいですか？");
            }

            //次回繰越し金＝0, 請求残合計＝０, 会計連動なし
            if (_errMsg.Length == 0)
            {
                _errMsg.AppendLine("入力された内容で更新します。よろしいですか？");
            }

            return (MessageForm.Show2(MessageForm.DispModeType.Question, _errMsg.ToString()) == DialogResult.Yes) ? true : false;
        }
        #endregion

        #region DeleteCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DeleteCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/14　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DeleteCheck()
        {
            if (!string.IsNullOrEmpty(henkinsumiGakuTextBox.Text.Trim())
                && Decimal.Parse(henkinsumiGakuTextBox.Text.Trim()) > 0)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "返金が発生しているため、入金データは削除できません。");
                return false;
            }
            return true;
        }
        #endregion

        #region DeleteConfirmCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DeleteConfirmCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/14　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DeleteConfirmCheck()
        {
            _errMsg.Length = 0;

            //会計済
            if (_displayMode == DispMode.Edit
                && _seikyuNyukinTblListDataTable.Select(string.Format("{0} = '1'", _seikyuNyukinTblListDataTable.KaikeiRendoFlgColumn.ColumnName)).Length > 0)
            {
                _errMsg.AppendLine("会計連動済のデータが存在します。\n削除してよろしいですか？");
            }
            else
            {
                _errMsg.AppendLine("表示されている入金データを完全に削除します。\nよろしいですか？");
            }

            return (MessageForm.Show2(MessageForm.DispModeType.Question, _errMsg.ToString()) == DialogResult.Yes) ? true : false;
        }
        #endregion

        #endregion

        #region CalculatorKingaku
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CalculatorKingaku
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sanshutsuNyukingaku"></param>
        /// <param name="isSetNyukinWarifuri"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/09　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CalculatorKingaku(decimal sanshutsuNyukingaku, bool isSetNyukinWarifuri = true)
        {
            decimal nyukinWarifuriTotal = 0;
            decimal zangakuTotal = 0;
            bool endValue = false;
            _nyukinWarifuriTotal = 0;

            for (int i = 0; i < _seikyuNyukinTblListDataTable.Count; i++)
            {
                SeikyuNyukinTblDataSet.SeikyuNyukinTblListRow row = _seikyuNyukinTblListDataTable[i];

                if (isSetNyukinWarifuri)
                {
                    //set nyukinWarifuri
                    row.nyukinWarifuriCol = (endValue || sanshutsuNyukingaku == 0) ? 0 : row.seikyuKingakuCol;

                    //count up nyukinWarifuriTotal
                    if (!endValue)
                    {
                        if (nyukinWarifuriTotal + row.nyukinWarifuriCol <= sanshutsuNyukingaku)
                        {
                            nyukinWarifuriTotal += row.nyukinWarifuriCol;
                        }
                        else
                        {
                            row.nyukinWarifuriCol = sanshutsuNyukingaku - nyukinWarifuriTotal;
                            nyukinWarifuriTotal = sanshutsuNyukingaku;
                            endValue = true;
                        }
                    }
                }
                //else
                //{
                    //get total nyukinWarifuri(43)
                    //_nyukinWarifuriTotal += row.nyukinWarifuriCol;
                //}
                _nyukinWarifuriTotal += row.nyukinWarifuriCol;

                //calculator (44)残額
                row.zangakuCol = row.seikyuKingakuCol - row.nyukinWarifuriCol;

                //count up (44)残額
                zangakuTotal += row.zangakuCol;

            }

            //set value to (35)請求残合計
            seikyuZangakuTextBox.Text = zangakuTotal.ToString();

            //set value to (34)次回繰越し金
            //if (isSetNyukinWarifuri)
            //{
            //    jikaiKurikoshiTextBox.Text = nyukinWarifuriTotal < sanshutsuNyukingaku ? (sanshutsuNyukingaku - nyukinWarifuriTotal).ToString() : "0";
            //}
            jikaiKurikoshiTextBox.Text = _nyukinWarifuriTotal < sanshutsuNyukingaku ? (sanshutsuNyukingaku - _nyukinWarifuriTotal).ToString() : "0";

        }
        #endregion

        #region GetSanshutsuNyukingaku
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetSanshutsuNyukingaku
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/09　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void GetSanshutsuNyukingaku()
        {
            //入金額
            decimal nyukinGaku;
            //支払手数料
            decimal shiharaiTesuryo;
            //前回繰越し金
            decimal zeikaiKurikoshi;
            //その他差引
            decimal sonotaSashihiki;
            //返金済額
            decimal henkinsumiGaku;
            _sanshutsuNyukingaku = 0;

            Decimal.TryParse(Convert.ToString(nyukinGakuTextBox.Text.Trim()), out nyukinGaku);
            Decimal.TryParse(Convert.ToString(shiharaiTesuryoTextBox.Text.Trim()), out shiharaiTesuryo);
            Decimal.TryParse(Convert.ToString(zeikaiKurikoshiTextBox.Text.Trim()), out zeikaiKurikoshi);
            Decimal.TryParse(Convert.ToString(sonotaSashihikiTextBox.Text.Trim()), out sonotaSashihiki);
            Decimal.TryParse(Convert.ToString(henkinsumiGakuTextBox.Text.Trim()), out henkinsumiGaku);

            _sanshutsuNyukingaku = tesuryoUchiRadioButton.Checked ? nyukinGaku - shiharaiTesuryo : nyukinGaku;
            _sanshutsuNyukingaku += (zeikaiKurikoshi + Math.Abs(sonotaSashihiki));
            _sanshutsuNyukingaku -= henkinsumiGaku;

        }
        #endregion

        #region FormEnd
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： FormEnd
        /// <summary>
        /// 
        /// </summary>
        /// <param name="childForm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/24　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void FormEnd(Form childForm)
        {
            // 子画面が正常終了した場合                                                                            
            if (childForm.DialogResult == DialogResult.OK)
            {
                DoFormLoad();
            }
        }
        #endregion

        #endregion

    }
    #endregion
}
