using System;
using System.Data;
using System.Drawing;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.Utility;
using FukjTabletSystem.Application.ApplicationLogic.Kensa.KihonJouhouTabPage;
using FukjTabletSystem.Application.Boundary.Common;
using FukjTabletSystem.Application.DataSet.SQLCE;
using FukjTabletSystem.Application.Utility;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.Boundary.Kensa.TabPages
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KihonJouhouTabPage
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/30  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KihonJouhouTabPage : BaseKensaTabPage
    {
        #region フィールド(private)

        /// <summary>
        /// 表示データ設定中フラグ
        /// </summary>
        private bool isInSetData = false;

        /// <summary>
        /// 初期表示終了フラグ
        /// </summary>
        private bool formLoaded = false;

        /// <summary>
        /// 取得データ（浄化槽台帳）
        /// </summary>
        private KensaIraiTblDataSet.KihonJouhouDataTable myKihonJouhou = new KensaIraiTblDataSet.KihonJouhouDataTable();

        /// <summary>
        /// 取得データ（検査依頼）
        /// </summary>
        private KensaIraiTblDataSet.KihonJouhouIraiDataTable myKihonJouhouIrai = new KensaIraiTblDataSet.KihonJouhouIraiDataTable();

        /// <summary>
        /// 建築用途名
        /// </summary>
        private KenchikuyotoMstDataSet.KenchikuyotoAllNmDataTable myKenchikuyotoAllNm = new KenchikuyotoMstDataSet.KenchikuyotoAllNmDataTable();
        
        /// <summary>
        /// 在宅有無
        /// </summary>
        private KensaKekkaTblDataSet.KensaKekkaForZaitakuUpdateDataTable myZaitakuUpdate = new KensaKekkaTblDataSet.KensaKekkaForZaitakuUpdateDataTable();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： InitializeComponent
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/30  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KihonJouhouTabPage()
        {
            InitializeComponent();
        }
        #endregion

        #region イベントハンドラ

        #region KihonJouhou_Load
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KihonJouhou_Load(object sender, EventArgs e)
        {
            if (FukjTabletSystem.Application.Boundary.Common.Utility.IsInDesignMode)
            {
                return;
            }

            // Loadが2回走る・・・
            if (formLoaded)
            {
                return;
            }
            
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // ハガキ送付先
                FukjTabletSystem.Application.Boundary.Common.Utility.SetComboBoxList(
                    hagakiSoufusakiComboBox, ConstMstList.Get("018"), "ConstNm", "ConstValue", true);

                // BOD処理性能
                FukjTabletSystem.Application.Boundary.Common.Utility.SetComboBoxList(
                    bodComboBox, ConstMstList.Get("070"), "ConstNm", "ConstValue", true);

                // 放流先
                FukjTabletSystem.Application.Boundary.Common.Utility.SetComboBoxList(
                    houryuusakiComboBox, NameMstList.Get("001"), "Name", "NameCd", true);

                // 種類
                FukjTabletSystem.Application.Boundary.Common.Utility.SetComboBoxList(
                    shuruiComboBox, ConstMstList.Get("031"), "ConstNm", "ConstValue", true);

                // 使用開始日
                shiyouKaishiNenComboBox.Items.Add("");
                shiyouKaishiGatsuComboBox.Items.Add("");
                shiyouKaishiHiComboBox.Items.Add("");

                // 設置日
                secchiNenComboBox.Items.Add("");
                secchiGatsuComboBox.Items.Add("");
                secchiHiComboBox.Items.Add("");

                for (int i = 0; i < 10; i++)
                {
                    shiyouKaishiNenComboBox.Items.Add(string.Format("{0:0000}", DateTime.Today.Year - i));
                    secchiNenComboBox.Items.Add(string.Format("{0:0000}", DateTime.Today.Year - i));
                }

                for (int i = 1; i <= 12; i++)
                {
                    shiyouKaishiGatsuComboBox.Items.Add(string.Format("{0:00}", i));
                    secchiGatsuComboBox.Items.Add(string.Format("{0:00}", i));
                }

                for (int i = 1; i <= 31; i++)
                {
                    shiyouKaishiHiComboBox.Items.Add(string.Format("{0:00}", i));
                    secchiHiComboBox.Items.Add(string.Format("{0:00}", i));
                }

                // 基本情報の取得
                DoSearch();

                // 取得データの表示
                SetControlData();

                // 編集無し(初期化)
                this.IsEdited = false;

                // フォームロード完了(2重実行制御)
                this.formLoaded = true;
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                TabMessageBox.Show(TabMessageBox.Type.Error, MessageResouce.MSGID_E00001, ex.Message);

                // 親画面の終了
                ((KensaMenuForm)this.TopLevelControl).DoClose();
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion
        
        #region kojiGyoushaSelectButton_Click(object sender, EventArgs e)
        /// <summary>
        /// 工事業者選択ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kojiGyoushaSelectButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                using (GyoshaSelectListForm form = new GyoshaSelectListForm())
                {
                    form.ShowDialog(this);

                    if (form.DialogResult == DialogResult.OK)
                    {
                        // 表示内容の更新
                        kojiGyoushaCdTextBox.Text = form.SelectedGyoshaInfo.GyoshaCd;
                        kojiGyoushaNameTextBox.Text = form.SelectedGyoshaInfo.GyoshaNm;
                        kojiGyoushaTelNoTextBox.Text = form.SelectedGyoshaInfo.GyoshaTelNo;
                    }
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                TabMessageBox.Show(TabMessageBox.Type.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion
        
        #region hoshuGyoushaSelectButton_Click(object sender, EventArgs e)
        /// <summary>
        /// 保守点検業者選択ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hoshuGyoushaSelectButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                using (GyoshaSelectListForm form = new GyoshaSelectListForm())
                {
                    form.ShowDialog(this);

                    if (form.DialogResult == DialogResult.OK)
                    {
                        // 表示内容の更新
                        hoshuGyoushaCdTextBox.Text = form.SelectedGyoshaInfo.GyoshaCd;
                        hoshuGyoushaNameTextBox.Text = form.SelectedGyoshaInfo.GyoshaNm;
                        hoshuGyoushaTelNoTextBox.Text = form.SelectedGyoshaInfo.GyoshaTelNo;
                    }
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                TabMessageBox.Show(TabMessageBox.Type.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region seisouGyoushaSelectButton_Click(object sender, EventArgs e)
        /// <summary>
        /// 清掃管理業者選択ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void seisouGyoushaSelectButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                using (GyoshaSelectListForm form = new GyoshaSelectListForm())
                {
                    form.ShowDialog(this);

                    if (form.DialogResult == DialogResult.OK)
                    {
                        // 表示内容の更新
                        seisouGyoushaCdTextBox.Text = form.SelectedGyoshaInfo.GyoshaCd;
                        seisouGyoushaNameTextBox.Text = form.SelectedGyoshaInfo.GyoshaNm;
                        seisouGyoushaTelNoTextBox.Text = form.SelectedGyoshaInfo.GyoshaTelNo;
                    }
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                TabMessageBox.Show(TabMessageBox.Type.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region zaitakuRadioButton_CheckedChanged(object sender, EventArgs e)
        /// <summary>
        /// 在宅有無チェック変更ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zaitakuRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (isInSetData)
            {
                return;
            }

            if (!((RadioButton)sender).Checked)
            {
                return;
            }

            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                IZaitakuUmuBtnClickALInput alInput = new ZaitakuUmuBtnClickALInput();

                myZaitakuUpdate[0].KensaKekkaZaitakuUmu = zaitakuRadioButton.Checked ? "1" : "0";

                alInput.KensaKekkaForZaitakuUpdate = myZaitakuUpdate;

                // 更新実行
                new ZaitakuUmuBtnClickApplicationLogic().Execute(alInput);

                TabMessageBox.Show2(TabMessageBox.Type.Info, "在宅有無", zaitakuRadioButton.Checked ? "在宅検査を登録しました。" : "不在検査を登録しました。");
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                TabMessageBox.Show(TabMessageBox.Type.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region kakuteiButton_Click(object sender, EventArgs e)
        /// <summary>
        /// 確定登録ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kakuteiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 入力値チェック
                if (!CheckInputValue())
                {
                    return;
                }

                IKakuteiBtnClickALInput alInput = new KakuteiBtnClickALInput();

                // 浄化槽台帳
                alInput.JokasoDaichoMstWithoutLocation = CreateJokasoDaichoMstWithoutLocation();
                // 検査依頼
                alInput.KensaIraiForKihonJouhouUpdate = CreateKensaIraiForKihonjouhouUpdate();

                // 更新実行
                new KakuteiBtnClickApplicationLogic().Execute(alInput);

                TabMessageBox.Show2(TabMessageBox.Type.Info, "基本情報", "検査依頼、浄化槽台帳を更新しました。");

                // 親画面の更新
                ((KensaMenuForm)this.TopLevelControl).ExecSearch();

                // 自画面の更新
                DoSearch();

                // 取得データの表示
                SetControlData();

                // 編集無し(初期化)
                this.IsEdited = false;
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                TabMessageBox.Show(TabMessageBox.Type.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region TextBox_TextChanged(object sender, EventArgs e)
        /// <summary>
        /// 編集済みの判定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (!isInSetData)
            {
                this.IsEdited = true;

                if (sender is TextBox)
                {
                    ((TextBox)sender).ForeColor = Color.Red;
                }
                else if (sender is ComboBox)
                {
                    ((ComboBox)sender).ForeColor = Color.Red;

                    switch (((ComboBox)sender).Name)
                    {
                        case "shiyouKaishiNenComboBox":

                            shiyouKaishiDatePanel.BackColor = Color.Red;

                            break;


                        case "secchiNenComboBox":

                            secchiDatePanel.BackColor = Color.Red;

                            break;
                    }
                }
            }
        }
        #endregion

        #region ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        /// <summary>
        /// 編集済みの判定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!isInSetData)
            {
                this.IsEdited = true;

                ((ComboBox)sender).ForeColor = Color.Red;

                switch (((ComboBox)sender).Name)
                {
                    case "hagakiSoufusakiComboBox":

                        hagakiSoufusakiPanel.BackColor = Color.Red;

                        break;

                    case "bodComboBox":

                        bodPanel.BackColor = Color.Red;

                        break;

                    case "shuruiComboBox":

                        shuruiPanel.BackColor = Color.Red;

                        break;

                    case "houryuusakiComboBox":

                        houryuusakiPanel.BackColor = Color.Red;

                        break;


                    case "shiyouKaishiGatsuComboBox":
                    case "shiyouKaishiHiComboBox":

                        shiyouKaishiDatePanel.BackColor = Color.Red;

                        break;


                    case "secchiGatsuComboBox":
                    case "secchiHiComboBox":

                        secchiDatePanel.BackColor = Color.Red;

                        break;
                }
            }
        }
        #endregion

        #region RadioButton_CheckedChanged(object sender, EventArgs e)
        /// <summary>
        /// 編集済みの判定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!isInSetData)
            {
                this.IsEdited = true;

                ((RadioButton)sender).ForeColor = Color.Red;

                switch (((RadioButton)sender).Name)
                {
                    case "sanjiShoriAriRadioButton":
                    case "sanjishoriNashiRadioButton":

                        sanjiShoriPpanel.BackColor = Color.Red;

                        break;
                }
            }
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region CheckInputValue()
        /// <summary>
        /// 入力値チェック
        /// </summary>
        /// <returns></returns>
        private bool CheckInputValue()
        {
            // 使用開始日の形式チェック
            //if (!string.IsNullOrEmpty(shiyouKaishiNenComboBox.Text)
            // || !string.IsNullOrEmpty(shiyouKaishiGatsuComboBox.Text)
            // || !string.IsNullOrEmpty(shiyouKaishiHiComboBox.Text))
            if (!string.IsNullOrEmpty(shiyouKaishiNenComboBox.Text)
                && !string.IsNullOrEmpty(shiyouKaishiGatsuComboBox.Text)
                && !string.IsNullOrEmpty(shiyouKaishiHiComboBox.Text))
            {
                try
                {
                    DateTime startDate = new DateTime(int.Parse(shiyouKaishiNenComboBox.Text), int.Parse(shiyouKaishiGatsuComboBox.Text), int.Parse(shiyouKaishiHiComboBox.Text));
                }
                catch
                {
                    TabMessageBox.Show2(TabMessageBox.Type.Warn, "使用開始日が不正です。");
                    return false;
                }
            }

            // 設置年月日の形式チェック
            //if (!string.IsNullOrEmpty(secchiNenComboBox.Text)
            // || !string.IsNullOrEmpty(secchiGatsuComboBox.Text)
            // || !string.IsNullOrEmpty(secchiHiComboBox.Text))
            if (!string.IsNullOrEmpty(secchiNenComboBox.Text)
                && !string.IsNullOrEmpty(secchiGatsuComboBox.Text)
                && !string.IsNullOrEmpty(secchiHiComboBox.Text))
            {
                try
                {
                    DateTime setDate = new DateTime(int.Parse(secchiNenComboBox.Text), int.Parse(secchiGatsuComboBox.Text), int.Parse(secchiHiComboBox.Text));
                }
                catch
                {
                    TabMessageBox.Show2(TabMessageBox.Type.Warn, "設置年月日が不正です。");
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region DoSearch
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoSearch
        /// <summary>
        /// 表示データの検索を行う
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/30  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            try
            {
                // 描画を停止
                this.SuspendLayout();

                myKihonJouhou.Clear();
                myKihonJouhouIrai.Clear();
                myKenchikuyotoAllNm.Clear();
                myZaitakuUpdate.Clear();

                IGetKihonJouhouALInput alInput = new GetKihonJouhouALInput();

                alInput.IraiHoteiKbn = ((KensaMenuForm)this.TopLevelControl).IraiHoteiKbn;
                alInput.IraiHokenjoCd = ((KensaMenuForm)this.TopLevelControl).IraiHokenjoCd;
                alInput.IraiNendo = ((KensaMenuForm)this.TopLevelControl).IraiNendo;
                alInput.IraiRenban = ((KensaMenuForm)this.TopLevelControl).IraiRenban;
                
                IGetKihonJouhouALOutput alOutput = new GetKihonJouhouApplicationLogic().Execute(alInput);

                if (alOutput.KihonJouhou.Count == 0 || alOutput.KihonJouhouIrai.Count == 0)
                {
                    // データなしは想定外
                    throw new CustomException(0, "基本情報データが取得できませんでした。");
                }

                // 取得データを画面に保持
                myKihonJouhou.Merge(alOutput.KihonJouhou);
                myKihonJouhouIrai.Merge(alOutput.KihonJouhouIrai);
                myKenchikuyotoAllNm.Merge(alOutput.KenchikuyotoAllNm);
                myZaitakuUpdate.Merge(alOutput.KensaKekkaForZaitakuUpdate);
            }
            finally
            {
                // 描画再開
                this.ResumeLayout();
            }
        }
        #endregion

        #region SetControlData
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetControlData
        /// <summary>
        /// 取得データを画面コントロールにマッピングする
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/30  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlData()
        {
            try
            {
                // マッピング中オン
                isInSetData = true;

                // 文字色を戻す
                ResetControlForeColor();

                // 描画を停止
                this.SuspendLayout();

                KensaIraiTblDataSet.KihonJouhouRow kihonJouhou = myKihonJouhou[0];

                KensaIraiTblDataSet.KihonJouhouIraiRow kihonJouhouIrai = myKihonJouhouIrai[0];
                
                #region 設置者情報

                // スクリーニング区分が0以外の場合のみ表示
                if (kihonJouhou.KensaIraiScreeningKbn != "0")
                {
                    if (kihonJouhou.IsKensaIraiSuishitsuUketsukeDtNull())
                    {
                        // 試料受付日
                        shiryouUketsukeDateTextBox.Text = "__年__月__日";

                        // 検査期限日（受付日＋14日）
                        kensaKigenDateTextBox.Text = "__年__月__日";
                    }
                    else
                    {
                        DateTime baseDate = DateTime.ParseExact(kihonJouhou.KensaIraiSuishitsuUketsukeDt, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);

                        // 試料受付日
                        shiryouUketsukeDateTextBox.Text = FukjTabletSystem.Application.Utility.DateUtility.ConvertToWareki(kihonJouhou.KensaIraiSuishitsuUketsukeDt, "yy年MM月dd日");

                        // 検査期限日（受付日＋14日）
                        kensaKigenDateTextBox.Text = FukjTabletSystem.Application.Utility.DateUtility.ConvertToWareki(baseDate.ToString("yyyyMMdd"), "yy年MM月dd日");
                    }

                    // 2015.01.08 toyoda Modify Start 協会Noは必ず出力
                    //// 協会No
                    //DateTime iraiNendoDt = new DateTime(int.Parse(kihonJouhou.KensaIraiNendo), 4, 1);
                    //kyoukaiNoTextBox.Text = string.Format("{0}-{1}-{2}", kihonJouhou.KensaIraiHokenjoCd, FukjTabletSystem.Application.Utility.DateUtility.ConvertToWareki(iraiNendoDt.ToString("yyyyMMdd"), "yy"), kihonJouhou.KensaIraiRenban);
                    // 2015.01.08 toyoda Modify End
                }
                else
                {
                    // 試料受付日
                    shiryouUketsukeDateTextBox.Text = "__年__月__日";
                    // 検査期限日（受付日＋14日）
                    kensaKigenDateTextBox.Text = "__年__月__日";

                    // 2015.01.08 toyoda Modify Start 協会Noは必ず出力
                    //// 協会No
                    //kyoukaiNoTextBox.Text = "__-__-__";
                    // 2015.01.08 toyoda Modify End
                }

                // 2015.01.08 toyoda Modify Start 協会Noは必ず出力
                // 協会No
                DateTime iraiNendoDt = new DateTime(int.Parse(kihonJouhou.KensaIraiNendo), 4, 1);
                kyoukaiNoTextBox.Text = string.Format("{0}-{1}-{2}", kihonJouhou.KensaIraiHokenjoCd, FukjTabletSystem.Application.Utility.DateUtility.ConvertToWareki(iraiNendoDt.ToString("yyyyMMdd"), "yy"), kihonJouhou.KensaIraiRenban);
                // 2015.01.08 toyoda Modify End

                // 一括請求先
                ikkatsuSeikyuusakiTextBox.Text = kihonJouhou.IsIkkatsuSeikyusakiGyoshaNmNull() ? string.Empty : kihonJouhou.IkkatsuSeikyusakiGyoshaNm;
                
                // 年版
                nenBanTextBox.Text = kihonJouhou.IsJokasoChizuNendoNull() ? string.Empty : kihonJouhou.JokasoChizuNendo;
                // ページ
                pageTextBox.Text = kihonJouhou.IsJokasoChizuPageNoNull() ? string.Empty : kihonJouhou.JokasoChizuPageNo;

                // 年版１
                nenBan1TextBox.Text = kihonJouhou.IsJokasoChizuNendo1Null() ? string.Empty : kihonJouhou.JokasoChizuNendo1;
                // ページ１
                page1TextBox.Text = kihonJouhou.IsJokasoChizuPageNo1Null() ? string.Empty : kihonJouhou.JokasoChizuPageNo1;

                // ハガキ送付先
                if (kihonJouhou.IsJokasoHagakiSoufusakiKbnNull() || string.IsNullOrEmpty(kihonJouhou.JokasoHagakiSoufusakiKbn))
                {
                    hagakiSoufusakiComboBox.SelectedIndex = -1;
                }
                else
                {
                    hagakiSoufusakiComboBox.SelectedValue = kihonJouhou.JokasoHagakiSoufusakiKbn;
                }

                // フリガナ
                furiganaTextBox.Text = kihonJouhouIrai.IsKensaIraiSetchishaKanaNull() ? string.Empty : kihonJouhouIrai.KensaIraiSetchishaKana;

                // 浄化槽管理者
                joukasouKanrishaTextBox.Text = kihonJouhouIrai.IsKensaIraiSetchishaNmNull() ? string.Empty : kihonJouhouIrai.KensaIraiSetchishaNm;

                // 名称
                joukasouNameTextBox.Text = kihonJouhouIrai.IsKensaIraiShisetsuNmNull() ? string.Empty : kihonJouhouIrai.KensaIraiShisetsuNm;

                // 設置場所（郵便番号）
                secchiBashoZipCodeTextBox.Text = kihonJouhouIrai.IsKensaIraiSetchibashoZipCdNull() ? string.Empty : kihonJouhouIrai.KensaIraiSetchibashoZipCd;

                // 設置場所住所
                secchiBashoAddressTextBox.Text = kihonJouhouIrai.IsKensaIraiSetchibashoAdrNull() ? string.Empty : kihonJouhouIrai.KensaIraiSetchibashoAdr;

                // 設置場所電話番号
                secchiBashoTelNoTextBox.Text = kihonJouhouIrai.IsKensaIraiSetchibashoTelNoNull() ? string.Empty : kihonJouhouIrai.KensaIraiSetchibashoTelNo;

                // 使用開始日
                shiyouKaishiNenComboBox.Text = kihonJouhouIrai.IsKensaIraiShiyoKaishiNenNull() ? string.Empty : kihonJouhouIrai.KensaIraiShiyoKaishiNen;

                if (kihonJouhouIrai.IsKensaIraiShiyoKaishiTsukiNull() || string.IsNullOrEmpty(kihonJouhouIrai.KensaIraiShiyoKaishiTsuki))
                {
                    shiyouKaishiGatsuComboBox.SelectedIndex = -1;
                }
                else
                {
                    shiyouKaishiGatsuComboBox.Text = kihonJouhouIrai.KensaIraiShiyoKaishiTsuki;
                }

                if (kihonJouhouIrai.IsKensaIraiShiyoKaishiBiNull() || string.IsNullOrEmpty(kihonJouhouIrai.KensaIraiShiyoKaishiBi))
                {
                    shiyouKaishiHiComboBox.SelectedIndex = -1;
                }
                else
                {
                    shiyouKaishiHiComboBox.Text = kihonJouhouIrai.KensaIraiShiyoKaishiBi;
                }

                // 設置年月日
                secchiNenComboBox.Text = kihonJouhouIrai.IsKensaIraiSetchiNenNull() ? string.Empty : kihonJouhouIrai.KensaIraiSetchiNen;

                if (kihonJouhouIrai.IsKensaIraiSetchiTsukiNull() || string.IsNullOrEmpty(kihonJouhouIrai.KensaIraiSetchiTsuki))
                {
                    secchiGatsuComboBox.SelectedIndex = -1;
                }
                else
                {
                    secchiGatsuComboBox.Text = kihonJouhouIrai.KensaIraiSetchiTsuki;
                }

                if (kihonJouhouIrai.IsKensaIraiSetchiBiNull() || string.IsNullOrEmpty(kihonJouhouIrai.KensaIraiSetchiBi))
                {
                    secchiHiComboBox.SelectedIndex = -1;
                }
                else
                {
                    secchiHiComboBox.Text = kihonJouhouIrai.KensaIraiSetchiBi;
                }
                
                // 処理対象人員
                shoriTaishouJininTextBox.Text = kihonJouhouIrai.IsKensaIraiShoritaishoJininNull() ? string.Empty : kihonJouhouIrai.KensaIraiShoritaishoJinin.ToString();

                // 処理対象人員（備考）
                shoriTaishouBikouTextBox.Text = kihonJouhou.IsJokasoHiHeikinOsuiRyoNull() ? string.Empty : kihonJouhou.JokasoHiHeikinOsuiRyo.ToString();

                // 実使用人員
                JitsuShiyouJininTextBox.Text = kihonJouhouIrai.IsKensaIraiJitsushiyoJininValueNull() ? string.Empty : kihonJouhouIrai.KensaIraiJitsushiyoJininValue;

                // 実使用人員（備考）
                jitsuShiyouBikouTextBox.Text = kihonJouhouIrai.IsKensaIraiJitsushiyoJininNull() ? string.Empty : kihonJouhouIrai.KensaIraiJitsushiyoJinin.ToString();

                // メーカー
                makerCdTextBox.Text = kihonJouhouIrai.IsKensaIraiMakerCdNull() ? string.Empty : kihonJouhouIrai.KensaIraiMakerCd;
                makerNameTextBox.Text = kihonJouhouIrai.IsMakerGyoshaNmNull() ? string.Empty : kihonJouhouIrai.MakerGyoshaNm;
                makerTelNoTextBox.Text = kihonJouhouIrai.IsMakerGyoshaTelNoNull() ? string.Empty : kihonJouhouIrai.MakerGyoshaTelNo;

                // 工事業者
                kojiGyoushaCdTextBox.Text = kihonJouhouIrai.IsKensaIraiKojiGyoshaCdNull() ? string.Empty : kihonJouhouIrai.KensaIraiKojiGyoshaCd;
                kojiGyoushaNameTextBox.Text = kihonJouhouIrai.IsKoujiGyoshaNmNull() ? string.Empty : kihonJouhouIrai.KoujiGyoshaNm;
                kojiGyoushaTelNoTextBox.Text = kihonJouhouIrai.IsKoujiGyoshaTelNoNull() ? string.Empty : kihonJouhouIrai.KoujiGyoshaTelNo;

                // 保守業者
                hoshuGyoushaCdTextBox.Text = kihonJouhouIrai.IsKensaIraiHoshutenkenGyoshaCdNull() ? string.Empty : kihonJouhouIrai.KensaIraiHoshutenkenGyoshaCd;
                hoshuGyoushaNameTextBox.Text = kihonJouhouIrai.IsHoshuGyoshaNmNull() ? string.Empty : kihonJouhouIrai.HoshuGyoshaNm;
                hoshuGyoushaTelNoTextBox.Text = kihonJouhouIrai.IsHoshuGyoshaTelNoNull() ? string.Empty : kihonJouhouIrai.HoshuGyoshaTelNo;

                // 清掃業者
                seisouGyoushaCdTextBox.Text = kihonJouhouIrai.IsKensaIraiSeisoGyoshaCdNull() ? string.Empty : kihonJouhouIrai.KensaIraiSeisoGyoshaCd;
                seisouGyoushaNameTextBox.Text = kihonJouhouIrai.IsSeisouGyoshaNmNull() ? string.Empty : kihonJouhouIrai.SeisouGyoshaNm;
                seisouGyoushaTelNoTextBox.Text = kihonJouhouIrai.IsSeisouGyoshaTelNoNull() ? string.Empty : kihonJouhouIrai.SeisouGyoshaTelNo;

                #endregion

                #region 浄化槽情報

                // 管轄
                kankatsuTextBox.Text = kihonJouhouIrai.IsHokenjoNmNull() ? string.Empty : kihonJouhouIrai.HokenjoNm;

                // BOD処理性能
                if (kihonJouhouIrai.IsKensaIraiShorimokuhyoSuishitsuNull() || kihonJouhouIrai.KensaIraiShorimokuhyoSuishitsu == 0)
                {
                    bodComboBox.SelectedIndex = -1;
                }
                else
                {
                    bodComboBox.SelectedValue = kihonJouhouIrai.KensaIraiShorimokuhyoSuishitsu.ToString();
                }

                // メーカー
                makerName2TextBox.Text = kihonJouhouIrai.IsMakerGyoshaNmNull() ? string.Empty : kihonJouhouIrai.MakerGyoshaNm;

                // 型式名
                katashikiNameTextBox.Text = kihonJouhouIrai.IsKatashikiNmNull() ? string.Empty : kihonJouhouIrai.KatashikiNm;

                // 2015.01.08 toyoda Modify Start 処理方式の出力形式を修正
                // 処理方式(処理方式種別名＋「　」＋処理方式名)
                string shubetsuNm = kihonJouhouIrai.IsShoriHoshikiShubetsuNmNull() ? string.Empty : kihonJouhouIrai.ShoriHoshikiShubetsuNm;
                shoriHoushikiTextBox.Text = kihonJouhouIrai.IsShoriHoshikiNmNull() ? shubetsuNm : string.Format("{0} {1}", shubetsuNm, kihonJouhouIrai.ShoriHoshikiNm);
                // 2015.01.08 toyoda Modify End

                // 建物用途１
                if (kihonJouhouIrai.IsKenchikuyoto1NmNull() || string.IsNullOrEmpty(kihonJouhouIrai.Kenchikuyoto1Nm))
                {
                    youto1TextBox.Text = string.Empty;
                    youto2TextBox.Text = string.Empty;
                }
                else
                {
                    youto1TextBox.Text = GetKenchikuYotoNm(kihonJouhouIrai.KenchikuyotoDaibunrui1, kihonJouhouIrai.KenchikuyotoShobunrui1, kihonJouhouIrai.KenchikuyotoRenban1);
                    youto2TextBox.Text = kihonJouhouIrai.Kenchikuyoto1Nm;
                }
                
                // 建物用途２
                if (kihonJouhouIrai.IsKenchikuyoto2NmNull() || string.IsNullOrEmpty(kihonJouhouIrai.Kenchikuyoto2Nm))
                {
                    youto3TextBox.Text = string.Empty;
                    youto4TextBox.Text = string.Empty;
                }
                else
                {
                    youto3TextBox.Text = GetKenchikuYotoNm(kihonJouhouIrai.KenchikuyotoDaibunrui2, kihonJouhouIrai.KenchikuyotoShobunrui2, kihonJouhouIrai.KenchikuyotoRenban2);
                    youto4TextBox.Text = kihonJouhouIrai.Kenchikuyoto2Nm;
                }
                
                // 建物用途３
                if (kihonJouhouIrai.IsKenchikuyoto3NmNull() || string.IsNullOrEmpty(kihonJouhouIrai.Kenchikuyoto3Nm))
                {
                    youto5TextBox.Text = string.Empty;
                    youto6TextBox.Text = string.Empty;
                }
                else
                {
                    youto5TextBox.Text = GetKenchikuYotoNm(kihonJouhouIrai.KenchikuyotoDaibunrui3, kihonJouhouIrai.KenchikuyotoShobunrui3, kihonJouhouIrai.KenchikuyotoRenban3);
                    youto6TextBox.Text = kihonJouhouIrai.Kenchikuyoto3Nm;
                }
                
                // 建物用途４
                if (kihonJouhouIrai.IsKenchikuyoto4NmNull() || string.IsNullOrEmpty(kihonJouhouIrai.Kenchikuyoto4Nm))
                {
                    youto7TextBox.Text = string.Empty;
                    youto8TextBox.Text = string.Empty;
                }
                else
                {
                    youto7TextBox.Text = GetKenchikuYotoNm(kihonJouhouIrai.KenchikuyotoDaibunrui4, kihonJouhouIrai.KenchikuyotoShobunrui4, kihonJouhouIrai.KenchikuyotoRenban4);
                    youto8TextBox.Text = kihonJouhouIrai.Kenchikuyoto4Nm;
                }
                
                // 建物用途５
                if (kihonJouhouIrai.IsKenchikuyoto5NmNull() || string.IsNullOrEmpty(kihonJouhouIrai.Kenchikuyoto5Nm))
                {
                    youto9TextBox.Text = string.Empty;
                    youto10TextBox.Text = string.Empty;
                }
                else
                {
                    youto9TextBox.Text = GetKenchikuYotoNm(kihonJouhouIrai.KenchikuyotoDaibunrui5, kihonJouhouIrai.KenchikuyotoShobunrui5, kihonJouhouIrai.KenchikuyotoRenban5);
                    youto10TextBox.Text = kihonJouhouIrai.Kenchikuyoto5Nm;
                }

                // 延べ面積
                youtoBikouTextBox.Text = kihonJouhouIrai.IsKensaIraiNobeMensaekiNull() ? string.Empty : kihonJouhouIrai.KensaIraiNobeMensaeki.ToString();

                // 放流先
                if (kihonJouhouIrai.IsKensaIraiHoryusakiCdNull() || string.IsNullOrEmpty(kihonJouhouIrai.KensaIraiHoryusakiCd))
                {
                    houryuusakiComboBox.SelectedIndex = -1;
                }
                else
                {
                    houryuusakiComboBox.SelectedValue = kihonJouhouIrai.KensaIraiHoryusakiCd;
                }

                // 使用開始日
                shiyouKaishiNen2TextBox.Text = kihonJouhouIrai.IsKensaIraiShiyoKaishiNenNull() ? string.Empty : kihonJouhouIrai.KensaIraiShiyoKaishiNen;
                shiyouKaishiGatsu2TextBox.Text = kihonJouhouIrai.IsKensaIraiShiyoKaishiTsukiNull() ? string.Empty : kihonJouhouIrai.KensaIraiShiyoKaishiTsuki;
                shiyouKaishiHi2TextBox.Text = kihonJouhouIrai.IsKensaIraiShiyoKaishiBiNull() ? string.Empty : kihonJouhouIrai.KensaIraiShiyoKaishiBi;

                // 処理対象人員
                shoriTaishouJinin2TextBox.Text = kihonJouhouIrai.IsKensaIraiShoritaishoJininNull() ? string.Empty : kihonJouhouIrai.KensaIraiShoritaishoJinin.ToString();

                // 処理対象人員（備考）
                shoriTaishouBikou2TextBox.Text = kihonJouhou.IsJokasoHiHeikinOsuiRyoNull() ? string.Empty : kihonJouhou.JokasoHiHeikinOsuiRyo.ToString();

                // 実使用人員
                JitsuShiyouJinin2TextBox.Text = kihonJouhouIrai.IsKensaIraiJitsushiyoJininValueNull() ? string.Empty : kihonJouhouIrai.KensaIraiJitsushiyoJininValue;

                // 実使用人員（備考）
                jitsuShiyouBikou2TextBox.Text = kihonJouhouIrai.IsKensaIraiJitsushiyoJininNull() ? string.Empty : kihonJouhouIrai.KensaIraiJitsushiyoJinin.ToString();

                // 2015.01.24 toyoda Add Start 三次処理有無項目追加
                if(kihonJouhouIrai.IsKensaIraiSanjishoriUmuKbnNull() || string.IsNullOrEmpty(kihonJouhouIrai.KensaIraiSanjishoriUmuKbn))
                {
                    sanjiShoriAriRadioButton.Checked = false;
                    sanjishoriNashiRadioButton.Checked = false;
                }
                else
                {
                    if (kihonJouhouIrai.KensaIraiSanjishoriUmuKbn == "1")
                    {
                        sanjiShoriAriRadioButton.Checked = true;
                    }
                    else
                    {
                        sanjishoriNashiRadioButton.Checked = true;
                    }
                }
                // 2015.01.24 toyoda Add End

                // 法根拠
                if (kihonJouhouIrai.IsKensaIraiHokonkyoKbnNull() || string.IsNullOrEmpty(kihonJouhouIrai.KensaIraiHokonkyoKbn))
                {
                    houKonkyoTextBox.Text = string.Empty;
                }
                else
                {
                    ConstMstDataSet.ConstMstDataTable houkonkyo = ConstMstList.Get("029", kihonJouhouIrai.KensaIraiHokonkyoKbn);
                    houKonkyoTextBox.Text = houkonkyo.Count == 0 ? string.Empty : houkonkyo[0].ConstNm;
                }

                // 種類
                if (kihonJouhouIrai.IsKensaIraiShuruiNull() || string.IsNullOrEmpty(kihonJouhouIrai.KensaIraiShurui))
                {
                    shuruiComboBox.SelectedIndex = -1;
                }
                else
                {
                    shuruiComboBox.SelectedValue = kihonJouhouIrai.KensaIraiShurui;
                }

                // 告示区分
                string kokujiKbnValue = (!kihonJouhouIrai.IsKensaIraiKokujiKbnNull() && kihonJouhouIrai.KensaIraiKokujiKbn == "1") ? "1" : "0";
                ConstMstDataSet.ConstMstDataTable kokuji = ConstMstList.Get("069", kokujiKbnValue);

                // 告示外
                if (kokujiKbnValue == "1")
                {
                    // 告示区分
                    kokujiKbnTextBox.Text = kokuji.Count == 0 ? string.Empty : kokuji[0].ConstNm;
                    // 認定番号
                    ninteiNoTextBox.Text = kihonJouhouIrai.IsKensaIraiNinteiNoNull() ? string.Empty : kihonJouhouIrai.KensaIraiNinteiNo;
                }
                else
                {
                    // 告示区分
                    kokujiKbnTextBox.Text = string.Format("{0}　第　{1}－{2}",
                                                        kokuji.Count == 0 ? string.Empty : kokuji[0].ConstNm,
                                                        kihonJouhouIrai.IsKensaIraiKokujiNendoNull() ? string.Empty : kihonJouhouIrai.KensaIraiKokujiNendo,
                                                        kihonJouhouIrai.IsKensaIraiKokujiNoNull() ? string.Empty : kihonJouhouIrai.KensaIraiKokujiNo);
                    // 認定番号
                    ninteiNoTextBox.Text = string.Empty;
                }                

                #endregion

                #region 在宅有無

                if (!myZaitakuUpdate[0].IsKensaKekkaZaitakuUmuNull() && myZaitakuUpdate[0].KensaKekkaZaitakuUmu == "0")
                {
                    // 在宅なし
                    fuzaiRadioButton.Checked = true;
                }
                else if (!myZaitakuUpdate[0].IsKensaKekkaZaitakuUmuNull() && myZaitakuUpdate[0].KensaKekkaZaitakuUmu == "1")
                {
                    // 在宅あり
                    zaitakuRadioButton.Checked = true;
                }

                #endregion
            }
            finally
            {
                // 描画再開
                this.ResumeLayout();

                // マッピング中オフ
                isInSetData = false;
            }
        }
        #endregion
        
        #region ResetControlForeColor()
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ResetControlForeColor
        /// <summary>
        /// 編集中（赤字）の文字色を通常色（黒字）に戻す
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/30  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ResetControlForeColor()
        {
            // テキストボックス
            seisouGyoushaNameTextBox.ForeColor = SystemColors.WindowText;
            hoshuGyoushaNameTextBox.ForeColor = SystemColors.WindowText;
            kojiGyoushaNameTextBox.ForeColor = SystemColors.WindowText;
            makerNameTextBox.ForeColor = SystemColors.WindowText;
            jitsuShiyouBikouTextBox.ForeColor = SystemColors.WindowText;
            JitsuShiyouJininTextBox.ForeColor = SystemColors.WindowText;
            seisouGyoushaTelNoTextBox.ForeColor = SystemColors.WindowText;
            hoshuGyoushaTelNoTextBox.ForeColor = SystemColors.WindowText;
            kojiGyoushaTelNoTextBox.ForeColor = SystemColors.WindowText;
            makerTelNoTextBox.ForeColor = SystemColors.WindowText;
            secchiBashoTelNoTextBox.ForeColor = SystemColors.WindowText;
            secchiBashoAddressTextBox.ForeColor = SystemColors.WindowText;
            secchiBashoZipCodeTextBox.ForeColor = SystemColors.WindowText;
            joukasouNameTextBox.ForeColor = SystemColors.WindowText;
            joukasouKanrishaTextBox.ForeColor = SystemColors.WindowText;
            furiganaTextBox.ForeColor = SystemColors.WindowText;
            pageTextBox.ForeColor = SystemColors.WindowText;
            nenBanTextBox.ForeColor = SystemColors.WindowText;
            page1TextBox.ForeColor = SystemColors.WindowText;
            nenBan1TextBox.ForeColor = SystemColors.WindowText;
            ninteiNoTextBox.ForeColor = SystemColors.WindowText;

            // コンボボックス
            secchiHiComboBox.ForeColor = SystemColors.WindowText;
            secchiGatsuComboBox.ForeColor = SystemColors.WindowText;
            secchiNenComboBox.ForeColor = SystemColors.WindowText;
            shiyouKaishiHiComboBox.ForeColor = SystemColors.WindowText;
            shiyouKaishiGatsuComboBox.ForeColor = SystemColors.WindowText;
            shiyouKaishiNenComboBox.ForeColor = SystemColors.WindowText;
            hagakiSoufusakiComboBox.ForeColor = SystemColors.WindowText;
            bodComboBox.ForeColor = SystemColors.WindowText;
            shuruiComboBox.ForeColor = SystemColors.WindowText;
            houryuusakiComboBox.ForeColor = SystemColors.WindowText;

            // パネル（コンボ色用）
            hagakiSoufusakiPanel.BackColor = Color.LemonChiffon;
            bodPanel.BackColor = Color.LemonChiffon;
            shuruiPanel.BackColor = Color.LemonChiffon;
            houryuusakiPanel.BackColor = Color.LemonChiffon;
            shiyouKaishiDatePanel.BackColor = Color.LemonChiffon;
            secchiDatePanel.BackColor = Color.LemonChiffon;

            // 2015.01.24 toyoda Add Start 三次処理有無項目追加
            sanjiShoriAriRadioButton.ForeColor = SystemColors.WindowText;
            sanjishoriNashiRadioButton.ForeColor = SystemColors.WindowText;
            sanjiShoriPpanel.BackColor = Color.LemonChiffon;
            // 2015.01.24 toyoda Add End
        }
        #endregion

        #region CreateJokasoDaichoMst
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateJokasoDaichoMstWithoutLocation
        /// <summary>
        /// 画面データを更新用データに設定する
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/30  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private JokasoDaichoMstDataSet.JokasoDaichoMstWithoutLocationDataTable CreateJokasoDaichoMstWithoutLocation()
        {
            JokasoDaichoMstDataSet.JokasoDaichoMstWithoutLocationDataTable datatable = new JokasoDaichoMstDataSet.JokasoDaichoMstWithoutLocationDataTable();

            JokasoDaichoMstDataSet.JokasoDaichoMstWithoutLocationRow newRow = datatable.NewJokasoDaichoMstWithoutLocationRow();

            // 初期表示データの取得（更新用のtableAdapterには位置情報、手書きメモを含まない）
            foreach (DataColumn col in datatable.Columns)
            {
                newRow[col.ColumnName] = myKihonJouhou[0][col.ColumnName];
            }

            // 画面表示内容の設定
            
            // 年版
            if (string.IsNullOrEmpty(nenBanTextBox.Text))
            {
                newRow.JokasoChizuNendo = string.Empty;
            }
            else
            {
                newRow.JokasoChizuNendo = nenBanTextBox.Text;
            }

            // ページ
            if (string.IsNullOrEmpty(pageTextBox.Text))
            {
                newRow.JokasoChizuPageNo= string.Empty;
            }
            else
            {
                newRow.JokasoChizuPageNo = pageTextBox.Text;
            }

            // 年版１
            if (string.IsNullOrEmpty(nenBan1TextBox.Text))
            {
                newRow.JokasoChizuNendo1 = string.Empty;
            }
            else
            {
                newRow.JokasoChizuNendo1 = nenBan1TextBox.Text;
            }

            // ページ１
            if (string.IsNullOrEmpty(page1TextBox.Text))
            {
                newRow.JokasoChizuPageNo1 = string.Empty;
            }
            else
            {
                newRow.JokasoChizuPageNo1 = page1TextBox.Text;
            }

            // ハガキ送付先
            if (hagakiSoufusakiComboBox.SelectedIndex == -1)
            {
                newRow.JokasoHagakiSoufusakiKbn = string.Empty;
            }
            else
            {
                newRow.JokasoHagakiSoufusakiKbn = hagakiSoufusakiComboBox.SelectedValue.ToString();
            }

            // フリガナ
            if (string.IsNullOrEmpty(furiganaTextBox.Text))
            {
                newRow.JokasoSetchishaKana = string.Empty;
            }
            else
            {
                newRow.JokasoSetchishaKana = furiganaTextBox.Text;
            }

            // 浄化槽管理者
            if (string.IsNullOrEmpty(joukasouKanrishaTextBox.Text))
            {
                newRow.JokasoSetchishaNm = string.Empty;
            }
            else
            {
                newRow.JokasoSetchishaNm = joukasouKanrishaTextBox.Text;
            }

            // 名称
            if (string.IsNullOrEmpty(joukasouNameTextBox.Text))
            {
                newRow.JokasoShisetsuNm = string.Empty;
            }
            else
            {
                newRow.JokasoShisetsuNm = joukasouNameTextBox.Text;
            }

            // 設置場所（郵便番号）
            if (string.IsNullOrEmpty(secchiBashoZipCodeTextBox.Text))
            {
                newRow.JokasoSetchiBashoZipCd = string.Empty;
            }
            else
            {
                newRow.JokasoSetchiBashoZipCd = secchiBashoZipCodeTextBox.Text;
            }

            // 設置場所住所
            if (string.IsNullOrEmpty(secchiBashoAddressTextBox.Text))
            {
                newRow.JokasoSetchiBashoAdr = string.Empty;
            }
            else
            {
                newRow.JokasoSetchiBashoAdr = secchiBashoAddressTextBox.Text;
            }

            // 設置場所電話番号
            if (string.IsNullOrEmpty(secchiBashoTelNoTextBox.Text))
            {
                newRow.JokasoSetchiBashoTelNo = string.Empty;
            }
            else
            {
                newRow.JokasoSetchiBashoTelNo = secchiBashoTelNoTextBox.Text;
            }

            // 使用開始日
            if (string.IsNullOrEmpty(shiyouKaishiNenComboBox.Text))
            {
                newRow.JokasoSiyokaisiNen = string.Empty;
            }
            else
            {
                newRow.JokasoSiyokaisiNen = shiyouKaishiNenComboBox.Text;
            }

            if (string.IsNullOrEmpty(shiyouKaishiGatsuComboBox.Text))
            {
                newRow.JokasoSiyokaisiTsuki = string.Empty;
            }
            else
            {
                newRow.JokasoSiyokaisiTsuki = shiyouKaishiGatsuComboBox.Text;
            }

            if (string.IsNullOrEmpty(shiyouKaishiHiComboBox.Text))
            {
                newRow.JokasoSiyokaisiBi = string.Empty;
            }
            else
            {
                newRow.JokasoSiyokaisiBi = shiyouKaishiHiComboBox.Text;
            }
            
            // 設置年月日
            if (string.IsNullOrEmpty(secchiNenComboBox.Text))
            {
                newRow.JokasoSetchiNen = string.Empty;
            }
            else
            {
                newRow.JokasoSetchiNen = secchiNenComboBox.Text;
            }

            if (string.IsNullOrEmpty(secchiGatsuComboBox.Text))
            {
                newRow.JokasoSetchiTsuki = string.Empty;
            }
            else
            {
                newRow.JokasoSetchiTsuki = secchiGatsuComboBox.Text;
            }

            if (string.IsNullOrEmpty(secchiHiComboBox.Text))
            {
                newRow.JokasoSetchiBi = string.Empty;
            }
            else
            {
                newRow.JokasoSetchiBi = secchiHiComboBox.Text;
            }

            // 実使用人員
            if (string.IsNullOrEmpty(JitsuShiyouJininTextBox.Text))
            {
                newRow.JokasoJitsuSiyouJininSuchi = string.Empty;
            }
            else
            {
                newRow.JokasoJitsuSiyouJininSuchi = JitsuShiyouJininTextBox.Text;
            }

            // 実使用人員（備考）
            if (string.IsNullOrEmpty(jitsuShiyouBikouTextBox.Text))
            {
                newRow.JokasoJitsuSiyoJinin = string.Empty;
            }
            else
            {
                newRow.JokasoJitsuSiyoJinin = jitsuShiyouBikouTextBox.Text;
            }

            // メーカー
            if (string.IsNullOrEmpty(makerCdTextBox.Text))
            {
                newRow.JokasoMekaGyoshaCd = string.Empty;
            }
            else
            {
                newRow.JokasoMekaGyoshaCd = makerCdTextBox.Text;
            }

            // 工事業者
            if (string.IsNullOrEmpty(kojiGyoushaCdTextBox.Text))
            {
                newRow.JokasoKojiGyoshaKbn = string.Empty;
            }
            else
            {
                newRow.JokasoKojiGyoshaKbn = kojiGyoushaCdTextBox.Text;
            }

            // 保守業者
            if (string.IsNullOrEmpty(hoshuGyoushaCdTextBox.Text))
            {
                newRow.JokasoHoshutenkenGyoshaCd = string.Empty;
            }
            else
            {
                newRow.JokasoHoshutenkenGyoshaCd = hoshuGyoushaCdTextBox.Text;
            }

            // 清掃業者
            if (string.IsNullOrEmpty(seisouGyoushaCdTextBox.Text))
            {
                newRow.JokasoSeisouGyoshaCd = string.Empty;
            }
            else
            {
                newRow.JokasoSeisouGyoshaCd = seisouGyoushaCdTextBox.Text;
            }
            
            // BOD処理性能
            if (bodComboBox.SelectedIndex == -1)
            {
                newRow.JokasoSyoriMokuhyoBOD = 0;
            }
            else
            {
                newRow.JokasoSyoriMokuhyoBOD = int.Parse(bodComboBox.SelectedValue.ToString());
            }

            // 放流先
            if (houryuusakiComboBox.SelectedIndex == -1)
            {
                newRow.JokasoHoryusakiCd = string.Empty;
            }
            else
            {
                newRow.JokasoHoryusakiCd = houryuusakiComboBox.SelectedValue.ToString();
            }

            // 種類
            if (shuruiComboBox.SelectedIndex == -1)
            {
                newRow.JokasoJokasoKumitateKbn = string.Empty;
            }
            else
            {
                newRow.JokasoJokasoKumitateKbn = shuruiComboBox.SelectedValue.ToString();
            }

            // 認定番号
            if (string.IsNullOrEmpty(ninteiNoTextBox.Text))
            {
                newRow.JokasoNinteiNo = string.Empty;
            }
            else
            {
                newRow.JokasoNinteiNo = ninteiNoTextBox.Text;
            }

            // 2015.01.24 toyoda Add Start 三次処理有無項目追加
            if (sanjiShoriAriRadioButton.Checked)
            {
                newRow.Jokaso3JiShoriFlg = "1";
            }
            else if (sanjishoriNashiRadioButton.Checked)
            {
                newRow.Jokaso3JiShoriFlg = "0";
            }
            else
            {
                newRow.Jokaso3JiShoriFlg = string.Empty;
            }
            // 2015.01.24 toyoda Add End

            newRow.UpdateDt = DateTime.Now;
            newRow.UpdateTarm = Dns.GetHostName();
            newRow.UpdateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

            datatable.AddJokasoDaichoMstWithoutLocationRow(newRow);

            datatable[0].AcceptChanges();
            datatable[0].SetModified();

            return datatable;
        }
        #endregion

        #region CreateKensaIraiForKihonjouhouUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateKensaIraiForKihonjouhouUpdate
        /// <summary>
        /// 画面データを更新用データに設定する
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaIraiTblDataSet.KensaIraiForKihonJouhouUpdateDataTable CreateKensaIraiForKihonjouhouUpdate()
        {
            KensaIraiTblDataSet.KensaIraiForKihonJouhouUpdateDataTable datatable = new KensaIraiTblDataSet.KensaIraiForKihonJouhouUpdateDataTable();

            KensaIraiTblDataSet.KensaIraiForKihonJouhouUpdateRow newRow = datatable.NewKensaIraiForKihonJouhouUpdateRow();
            
            // 初期表示データの取得（更新用のtableAdapterには数値検査入力項目を含まない）
            foreach (DataColumn col in datatable.Columns)
            {
                newRow[col.ColumnName] = myKihonJouhouIrai[0][col.ColumnName];
            }

            // 画面表示内容の設定
            
            // フリガナ
            if (string.IsNullOrEmpty(furiganaTextBox.Text))
            {
                newRow.KensaIraiSetchishaKana = string.Empty;
            }
            else
            {
                newRow.KensaIraiSetchishaKana = furiganaTextBox.Text;
            }

            // 浄化槽管理者
            if (string.IsNullOrEmpty(joukasouKanrishaTextBox.Text))
            {
                newRow.KensaIraiSetchishaNm = string.Empty;
            }
            else
            {
                newRow.KensaIraiSetchishaNm = joukasouKanrishaTextBox.Text;
            }

            // 名称
            if (string.IsNullOrEmpty(joukasouNameTextBox.Text))
            {
                newRow.KensaIraiShisetsuNm = string.Empty;
            }
            else
            {
                newRow.KensaIraiShisetsuNm = joukasouNameTextBox.Text;
            }

            // 設置場所（郵便番号）
            if (string.IsNullOrEmpty(secchiBashoZipCodeTextBox.Text))
            {
                newRow.KensaIraiSetchibashoZipCd = string.Empty;
            }
            else
            {
                newRow.KensaIraiSetchibashoZipCd = secchiBashoZipCodeTextBox.Text;
            }

            // 設置場所住所
            if (string.IsNullOrEmpty(secchiBashoAddressTextBox.Text))
            {
                newRow.KensaIraiSetchibashoAdr = string.Empty;
            }
            else
            {
                newRow.KensaIraiSetchibashoAdr = secchiBashoAddressTextBox.Text;
            }

            // 設置場所電話番号
            if (string.IsNullOrEmpty(secchiBashoTelNoTextBox.Text))
            {
                newRow.KensaIraiSetchibashoTelNo = string.Empty;
            }
            else
            {
                newRow.KensaIraiSetchibashoTelNo = secchiBashoTelNoTextBox.Text;
            }

            // 使用開始日
            if (string.IsNullOrEmpty(shiyouKaishiNenComboBox.Text))
            {
                newRow.KensaIraiShiyoKaishiNen = string.Empty;
            }
            else
            {
                newRow.KensaIraiShiyoKaishiNen = shiyouKaishiNenComboBox.Text;
            }

            if (string.IsNullOrEmpty(shiyouKaishiGatsuComboBox.Text))
            {
                newRow.KensaIraiShiyoKaishiTsuki = string.Empty;
            }
            else
            {
                newRow.KensaIraiShiyoKaishiTsuki = shiyouKaishiGatsuComboBox.Text;
            }

            if (string.IsNullOrEmpty(shiyouKaishiHiComboBox.Text))
            {
                newRow.KensaIraiShiyoKaishiBi = string.Empty;
            }
            else
            {
                newRow.KensaIraiShiyoKaishiBi = shiyouKaishiHiComboBox.Text;
            }

            // 設置年月日
            if (string.IsNullOrEmpty(secchiNenComboBox.Text))
            {
                newRow.KensaIraiSetchiNen = string.Empty;
            }
            else
            {
                newRow.KensaIraiSetchiNen = secchiNenComboBox.Text;
            }

            if (string.IsNullOrEmpty(secchiGatsuComboBox.Text))
            {
                newRow.KensaIraiSetchiTsuki = string.Empty;
            }
            else
            {
                newRow.KensaIraiSetchiTsuki = secchiGatsuComboBox.Text;
            }

            if (string.IsNullOrEmpty(secchiHiComboBox.Text))
            {
                newRow.KensaIraiSetchiBi = string.Empty;
            }
            else
            {
                newRow.KensaIraiSetchiBi = secchiHiComboBox.Text;
            }

            // 実使用人員
            if (string.IsNullOrEmpty(JitsuShiyouJininTextBox.Text))
            {
                newRow.KensaIraiJitsushiyoJininValue = string.Empty;
            }
            else
            {
                newRow.KensaIraiJitsushiyoJininValue = JitsuShiyouJininTextBox.Text;
            }

            // 実使用人員（備考）
            if (string.IsNullOrEmpty(jitsuShiyouBikouTextBox.Text))
            {
                newRow.KensaIraiJitsushiyoJinin = string.Empty;
            }
            else
            {
                newRow.KensaIraiJitsushiyoJinin = jitsuShiyouBikouTextBox.Text;
            }

            // メーカー
            if (string.IsNullOrEmpty(makerCdTextBox.Text))
            {
                newRow.KensaIraiMakerCd = string.Empty;
            }
            else
            {
                newRow.KensaIraiMakerCd = makerCdTextBox.Text;
            }

            // 工事業者
            if (string.IsNullOrEmpty(kojiGyoushaCdTextBox.Text))
            {
                newRow.KensaIraiKojiGyoshaCd = string.Empty;
            }
            else
            {
                newRow.KensaIraiKojiGyoshaCd = kojiGyoushaCdTextBox.Text;
            }

            // 保守業者
            if (string.IsNullOrEmpty(hoshuGyoushaCdTextBox.Text))
            {
                newRow.KensaIraiHoshutenkenGyoshaCd = string.Empty;
            }
            else
            {
                newRow.KensaIraiHoshutenkenGyoshaCd = hoshuGyoushaCdTextBox.Text;
            }

            // 清掃業者
            if (string.IsNullOrEmpty(seisouGyoushaCdTextBox.Text))
            {
                newRow.KensaIraiSeisoGyoshaCd = string.Empty;
            }
            else
            {
                newRow.KensaIraiSeisoGyoshaCd = seisouGyoushaCdTextBox.Text;
            }

            // BOD処理性能
            if (bodComboBox.SelectedIndex == -1)
            {
                newRow.KensaIraiShorimokuhyoSuishitsu = 0;
            }
            else
            {
                newRow.KensaIraiShorimokuhyoSuishitsu = int.Parse(bodComboBox.SelectedValue.ToString());
            }

            // 放流先
            if (houryuusakiComboBox.SelectedIndex == -1)
            {
                newRow.KensaIraiHoryusakiCd = string.Empty;
            }
            else
            {
                newRow.KensaIraiHoryusakiCd = houryuusakiComboBox.SelectedValue.ToString();
            }

            // 種類
            if (shuruiComboBox.SelectedIndex == -1)
            {
                newRow.KensaIraiShurui = string.Empty;
            }
            else
            {
                newRow.KensaIraiShurui = shuruiComboBox.SelectedValue.ToString();
            }

            // 認定番号
            if (string.IsNullOrEmpty(ninteiNoTextBox.Text))
            {
                newRow.KensaIraiNinteiNo = string.Empty;
            }
            else
            {
                newRow.KensaIraiNinteiNo = ninteiNoTextBox.Text;
            }

            // 2015.01.24 toyoda Add Start 三次処理有無項目追加
            if (sanjiShoriAriRadioButton.Checked)
            {
                newRow.KensaIraiSanjishoriUmuKbn = "1";
            }
            else if (sanjishoriNashiRadioButton.Checked)
            {
                newRow.KensaIraiSanjishoriUmuKbn = "0";
            }
            else
            {
                newRow.KensaIraiSanjishoriUmuKbn = string.Empty;
            }
            // 2015.01.24 toyoda Add End

            newRow.UpdateDt = DateTime.Now;
            newRow.UpdateTarm = Dns.GetHostName();
            newRow.UpdateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

            datatable.AddKensaIraiForKihonJouhouUpdateRow(newRow);

            datatable[0].AcceptChanges();
            datatable[0].SetModified();

            return datatable;
        }
        #endregion

        #region GetKenchikuYotoNm(string daibunrui, string shoubunrui, int renban)
        /// <summary>
        /// 建築用途マスタ名称取得
        /// </summary>
        /// <param name="daibunrui"></param>
        /// <param name="shoubunrui"></param>
        /// <param name="renban"></param>
        /// <returns></returns>
        private string GetKenchikuYotoNm(string daibunrui, string shoubunrui, int renban)
        {
            // 建築用途マスタ名称を取得
            KenchikuyotoMstDataSet.KenchikuyotoAllNmRow row = myKenchikuyotoAllNm.FindByKenchikuyotoDaibunruiKenchikuyotoShobunruiKenchikuyotoRenban(daibunrui, shoubunrui, renban);

            if (row == null)
            {
                return string.Empty;
            }
            else
            {
                return string.Format("{0}({1})",
                    row.IsKenchikuyotoDaibunruiNmNull() ? string.Empty : row.KenchikuyotoDaibunruiNm,
                    row.IsKenchikuyotoShobunruiNmNull() ? string.Empty : row.KenchikuyotoShobunruiNm);
            }
        }
        #endregion
                        
        #endregion
    }
    #endregion
}
