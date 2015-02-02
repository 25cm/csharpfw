using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Keiri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SeikyuAddMeisaiForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/02  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SeikyuAddMeisaiForm : FukjBaseForm
    {
        #region 定義(public)

        ///// <summary>
        ///// SeikyuShosaiFormLoadDataTable
        ///// </summary>
        //public SeikyuDtlTblDataSet.SeikyuShosaiFormLoadDataTable returnDT;

        /// <summary>
        /// SeikyuShosaiFormLoadDataTable
        /// </summary>
        public SeikyuDtlTblDataSet.SeikyuShosaiFormLoadDtlDataTable returnDT;

        #endregion

        #region プロパティ(private)

        /// <summary>
        /// 請求日
        /// </summary>
        private string _seikyuDt = string.Empty;

        /// <summary>
        /// 請求先
        /// </summary>
        private string _seikyusakiNm = string.Empty;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SeikyuAddMeisaiForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="seikyuDt"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/02  DatNT　  新規作成
        /// 2014/11/06  DatNT   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SeikyuAddMeisaiForm(string seikyuDt, string seikyusakiNm)
        {
            InitializeComponent();

            SetControlDomain();

            _seikyuDt = seikyuDt;

            // 2014/11/06 DatNT v1.03 ADD Start
            _seikyusakiNm = seikyusakiNm;
            // 2014/11/06 DatNT v1.03 ADD End
        }
        #endregion

        #region イベント

        #region CloseButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： CloseButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/02  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CloseButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this.Close();
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

        #region kakuteiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kakuteiButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/02  DatNT　  新規作成
        /// 2014/11/06  DatNT   v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kakuteiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!UnitCheck()) { return; }

                decimal syohiZeiRitsu = Common.Common.GetSyohizei(_seikyuDt);

                //if (Convert.ToInt32(kingakuTextBox.Text) > 0)
                //{
                    // 消費税
                    int syohizei = 0;

                    // 2015.01.07 toyoda Modify Start 金額がマイナスの場合は消費税計算を行わない
                    //if (sotozeiRadioButton.Checked)
                    //{
                    //    syohizei = (int)(Convert.ToInt32(kingakuTextBox.Text) * syohiZeiRitsu);
                    //}

                    //if (uchizeiRadioButton.Checked)
                    //{
                    //    syohizei = (int)(Convert.ToInt32(kingakuTextBox.Text) * syohiZeiRitsu * 100 / (syohiZeiRitsu * 100 + 100));
                    //}
                    if (Convert.ToInt32(kingakuTextBox.Text) > 0)
                    {
                        if (sotozeiRadioButton.Checked)
                        {
                            syohizei = (int)(Convert.ToInt32(kingakuTextBox.Text) * syohiZeiRitsu);
                        }

                        if (uchizeiRadioButton.Checked)
                        {
                            syohizei = (int)(Convert.ToInt32(kingakuTextBox.Text) * syohiZeiRitsu * 100 / (syohiZeiRitsu * 100 + 100));
                        }
                    }
                    // 2015.01.07 toyoda Modify End

                    // 合計金額
                    decimal total = 0;

                    if (sotozeiRadioButton.Checked)
                    {
                        total = Convert.ToInt32(kingakuTextBox.Text) + syohizei;
                    }
                    else
                    {
                        total = Convert.ToInt32(kingakuTextBox.Text);
                    }

                    // 完済
                    string kansai = string.Empty;

                    if (Convert.ToInt32(kingakuTextBox.Text) >= 0)
                    {
                        kansai = "未";
                    }
                    else
                    {
                        kansai = "－";
                    }

                    // 課税フラグ（隠し）
                    string kazeiFlag = string.Empty;

                    // 2015.01.07 toyoda Modify Start 金額がマイナスの場合は消費税計算を行わない
                    //if (taisyogaiRadioButton.Checked)
                    if (taisyogaiRadioButton.Checked || Convert.ToInt32(kingakuTextBox.Text) <= 0)
                    // 2015.01.07 toyoda Modify End
                    {
                        kazeiFlag = "0";
                    }
                    else if (sotozeiRadioButton.Checked)
                    {
                        kazeiFlag = "1";
                    }
                    else
                    {
                        kazeiFlag = "2";
                    }

                    // 2014/11/06 DatNT v1.03 MOD Start
                    //SeikyuDtlTblDataSet.SeikyuShosaiFormLoadDataTable dataTable = new SeikyuDtlTblDataSet.SeikyuShosaiFormLoadDataTable();

                    //SeikyuDtlTblDataSet.SeikyuShosaiFormLoadRow row = dataTable.NewSeikyuShosaiFormLoadRow();

                    SeikyuDtlTblDataSet.SeikyuShosaiFormLoadDtlDataTable dataTable = new SeikyuDtlTblDataSet.SeikyuShosaiFormLoadDtlDataTable();

                    SeikyuDtlTblDataSet.SeikyuShosaiFormLoadDtlRow row = dataTable.NewSeikyuShosaiFormLoadDtlRow();

                    // 明細名目
                    row.SeikyusakiNm = _seikyusakiNm;

                    //// 支所コード
                    //row.SeikyuShisyoCd = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;

                    // 支所名
                    row.shishoNmCol = Common.Common.GetShishoNmByShishoCd(Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd);

                    // 2014/11/06 DatNT v1.03 MOD End

                    // 請求書科目名
                    row.SeikyuKomokuNm = Common.Common.GetConstNmByKbnValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_033, "9");

                    // 商品名
                    row.SeikyuSyohinNm = meisaiNmTextBox.Text.Trim();

                    // 数量
                    row.SeikyuCnt = 1;

                    // 単価
                    row.SeikyuTanka = 0;

                    // 金額
                    row.SeikyuGaku = Convert.ToDecimal(kingakuTextBox.Text);

                    // 消費税
                    row.SyohizeiGaku = syohizei;

                    // 合計金額
                    row.SeikyuKingakuKei = total;

                    // 入金額
                    row.NyukinTotal = 0;

                    // 完済
                    row.SeikyuKansaiFlg = kansai;

                    // 請求項目区分（隠し）
                    row.SeikyuKomokuKbn = "9";

                    // 課税フラグ（隠し）
                    row.KazeiFlag = kazeiFlag;

                    //dataTable.AddSeikyuShosaiFormLoadRow(row);
                    dataTable.AddSeikyuShosaiFormLoadDtlRow(row);
                    row.AcceptChanges();
                    row.SetAdded();

                    returnDT = dataTable;

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;

                    this.Close();
                //}
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

        #region SeikyuAddMeisaiForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SeikyuAddMeisaiForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/02  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SeikyuAddMeisaiForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyCode)
                {
                    case Keys.F1:
                        kakuteiButton.Focus();
                        kakuteiButton.PerformClick();
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

        #endregion

        #region メソッド(private)

        #region SetControlDomain
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetControlDomain
        /// <summary>
        /// 
        /// </summary>
        /// <param name="now"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/12  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            // 明細名目
            meisaiNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);

            // 金額
            kingakuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 10);
        }
        #endregion

        #region UnitCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： UnitCheck
        /// <summary>
        /// 単項目チェック
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/13  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool UnitCheck()
        {
            StringBuilder errMess = new StringBuilder();

            // 明細名目
            if (string.IsNullOrEmpty(meisaiNmTextBox.Text.Trim()))
            {
                errMess.AppendLine("明細名目が入力されていません。");
            }

            // 金額
            if (string.IsNullOrEmpty(kingakuTextBox.Text.Trim()))
            {
                errMess.AppendLine("金額が入力されていません。");
            }

            if (!string.IsNullOrEmpty(errMess.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMess.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #endregion

    }
    #endregion
}
