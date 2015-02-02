using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.JokasoDaichoKanri.JokasoDaichoList;
using FukjBizSystem.Application.Boundary.Generic;
using FukjBizSystem.Application.Boundary.KensaIraiKanri;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.JokasoDaichoMstDataSetTableAdapters;
using FukjBizSystem.Application.Utility;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.JokasoDaichoKanri
{
    /// <summary>
    /// 
    /// </summary>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/28　habu　　    新規作成
    /// 2014/11/20　habu　　    変更届ボタン追加
    /// 2015/01/29　habu　　    検索条件調整、地区マスタ選択への遷移を追加
    /// </history>
    public partial class JokasoDaichoList : StdListForm
    {
        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public JokasoDaichoList()
        {
            InitializeComponent();
        }
        #endregion

        #region Events

        #region henkouTodokeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/20　habu　　    新規作成
        /// </history>
        private void henkouTodokeButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    if (jokasoDaichoListDataGridView.CurrentRow == null)
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                        return;
                    }

                    DataGridViewRow selectedRow = jokasoDaichoListDataGridView.CurrentRow;

                    string hokenjoCd = selectedRow.Cells[jokasoHokenjoCdDataGridViewTextBoxColumn.Index].Value.ToString();
                    string torokuNendo = selectedRow.Cells[jokasoTorokuNendoDataGridViewTextBoxColumn.Index].Value.ToString();
                    string renban = selectedRow.Cells[jokasoRenbanDataGridViewTextBoxColumn.Index].Value.ToString();

                    //// 登録年度(平成)を西暦に変換
                    //torokuNendo = Common.Common.ConvertToHoshouNendoSeireki(torokuNendo);

                    HenkoTodokeToroku frm = new HenkoTodokeToroku(hokenjoCd, torokuNendo, renban);

                    Program.mForm.MoveNext(frm);
                });

        }
        #endregion

        #region iraiTorokuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/07　habu　　    新規作成
        /// </history>
        private void iraiTorokuButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    if (jokasoDaichoListDataGridView.CurrentRow == null)
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                        return;
                    }

                    DataGridViewRow selectedRow = jokasoDaichoListDataGridView.CurrentRow;

                    string hokenjoCd = selectedRow.Cells[jokasoHokenjoCdDataGridViewTextBoxColumn.Index].Value.ToString();
                    string torokuNendo = selectedRow.Cells[jokasoTorokuNendoDataGridViewTextBoxColumn.Index].Value.ToString();
                    string renban = selectedRow.Cells[jokasoRenbanDataGridViewTextBoxColumn.Index].Value.ToString();
                    // TODO 既に7条検査依頼が登録済みの場合に、正しくチェックではじかれるか?
                    // 7条受付登録に遷移
                    KensaIraiToroku7jo frm = new KensaIraiToroku7jo(hokenjoCd, torokuNendo, renban, KensaIraiToroku7jo.DispMode.AddExistsJokaso);

                    Program.mForm.MoveNext(frm);
                });
        }
        #endregion

        #region iraiEditButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： iraiEditButton_Click
        /// <summary>
        /// ７条編集ボタン押下イベント
        /// （対象浄化槽の直近7条検査を検索して表示・編集）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/30　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void iraiEditButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            try
            {
                // 対象浄化槽の直近7条検査を検索して表示

                if (jokasoDaichoListDataGridView.CurrentRow == null)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                    return;
                }

                DataGridViewRow selectedRow = jokasoDaichoListDataGridView.CurrentRow;

                // 対象の浄化槽台帳番号を取得
                string hokenjoCd = selectedRow.Cells[jokasoHokenjoCdDataGridViewTextBoxColumn.Index].Value.ToString();
                string torokuNendo = selectedRow.Cells[jokasoTorokuNendoDataGridViewTextBoxColumn.Index].Value.ToString();
                string renban = selectedRow.Cells[jokasoRenbanDataGridViewTextBoxColumn.Index].Value.ToString();

                // 直近の検査依頼を取得
                // ステータス<30、かつ、検査予定日がブランクの時のみ編集可能
                IGetKensaIraiByJokasoDaichoNoALInput alInput = new GetKensaIraiByJokasoDaichoNoALInput();
                alInput.KensaIraiJokasoHokenjoCd = hokenjoCd;
                alInput.KensaIraiJokasoTorokuNendo = torokuNendo;
                alInput.KensaIraiJokasoRenban = renban;
                IGetKensaIraiByJokasoDaichoNoALOutput alOutput = new GetKensaIraiByJokasoDaichoNoApplicationLogic().Execute(alInput);
                if (alOutput.KensaIraiTblDT.Rows.Count <= 0)
                {
                    // 編集画面非表示
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データに編集可能な検査依頼は存在しません。");
                    return;
                }
                // 直近の検査依頼を取得（検査依頼日（降順）、依頼年度（降順）、検査連番（降順））
                string fillerStr = "KensaIraiHoteiKbn='1' and KensaIraiStatusKbn<'30' and KensaIraiKensaYoteiNen='' and KensaIraiKensaYoteiTsuki='' and KensaIraiKensaYoteiBi=''";
                string sortStr = "KensaIraiNen desc, KensaIraiTsuki desc, KensaIraiBi desc, KensaIraiNendo desc, KensaIraiRenban desc";
                DataRow[] rows = alOutput.KensaIraiTblDT.Select(fillerStr, sortStr);
                if (rows.Length <= 0)
                {
                    // 編集画面非表示
                    MessageForm.Show2(MessageForm.DispModeType.Error, "対象データに編集可能な検査依頼は存在しません。");
                    return;
                }
                // 対象レコード取得
                KensaIraiTblDataSet.KensaIraiTblRow row = (KensaIraiTblDataSet.KensaIraiTblRow)rows[0];
                // 7条受付登録に遷移
                KensaIraiToroku7jo frm = new KensaIraiToroku7jo(row.KensaIraiHokenjoCd, row.KensaIraiNendo, row.KensaIraiRenban);

                Program.mForm.MoveNext(frm);
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #endregion

        #region StdMethods(must override)

        #region AssignStandardControls
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/28　habu　　    新規作成
        /// </history>
        protected override void AssignStandardControls(StdListForm.StandardControls stdControls, StdListForm.StandardParams stdParams)
        {
            stdControls.ClearButton = clearButton;
            stdControls.CloseButton = tojiruButton;
            stdControls.DetailButton = shosaiButton;
            stdControls.EntryButton = torokuButton;
            stdControls.ListPanel = bushoListPanel;
            stdControls.OutputButton = outputButton;
            stdControls.SearchButton = kensakuButton;
            stdControls.SearchCntLabel = jokasoDaichoListCountLabel;
            stdControls.SearchListDataGridView = jokasoDaichoListDataGridView;
            stdControls.SearchPanel = searchPanel;
            stdControls.ViewChangeButton = viewChangeButton;

            stdParams.ListDataTableType = typeof(JokasoDaichoMstDataSet.JokasoDaichoMstListDataTable);
            stdParams.ListTableAdapterType = typeof(JokasoDaichoMstListTableAdapter);

            stdParams.OutputFileName = "浄化槽台帳一覧";

            // 初期表示時に検索を行わない
            stdParams.DoInitSearch = false;
            // 検索件数上限を設定(2000件)
            stdParams.SearchCntLimit = 2000;
        }
        #endregion

        #region ClearCondition
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/28　habu　　    新規作成
        /// </history>
        protected override void ClearCondition()
        {
            // clear search conditions
            hokenjoCdTextBox.Clear();
            torokuNendoTextBox.Clear();
            jokasoDaichoRenbanFromTextBox.Clear();
            jokasoDaichoRenbanToTextBox.Clear();
            ninsouFromTextBox.Clear();
            ninsouToTextBox.Clear();

            oldChikuCdTextBox.Clear();
            nowChikuCdTextBox.Clear();

            setchishaNmTextBox.Clear();
            setchishaNm2TextBox.Clear();
            setchishaAdrTextBox.Clear();
            setchishaAdr2TextBox.Clear();

            shisetsuNmTextBox.Clear();
            shisetsuNm2TextBox.Clear();
            setchibashoAdrTextBox.Clear();
            setchibashoAdr2TextBox.Clear();

            hoshuGyoshaCdTextBox.Clear();
            seisouGyoshaCdTextBox.Clear();

            hoshuGyoshaNmTextBox.Clear();
            seisouGyoshaNmTextBox.Clear();
        }
        #endregion

        #region CheckCondition
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/28　habu　　    新規作成
        /// </history>
        protected override bool CheckCondition(out string errMsg)
        {
            errMsg = string.Empty;

            // 連番
            if (!CheckRangeCondition(jokasoDaichoRenbanFromTextBox, jokasoDaichoRenbanToTextBox, out errMsg, "連番")) { return false; }

            // 人槽
            if (!CheckRangeCondition(ninsouFromTextBox, ninsouToTextBox, out errMsg, "人槽")) { return false; }

            return true;
        }
        #endregion

        #region MakeCondition
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/28　habu　　    新規作成
        /// 2015/01/29　habu　　    検索条件調整
        /// </history>
        protected override void MakeCondition(ApplicationLogic.Generic.StdList.ISearchBtnClickALInput searchAlInput)
        {
            JokasoDaichoMstDataSet.JokasoDaichoMstListDataTable templateTable = new JokasoDaichoMstDataSet.JokasoDaichoMstListDataTable();

            // 検索条件指定
            AddEqualCond(searchAlInput, templateTable.JokasoHokenjoCdColumn.ColumnName, hokenjoCdTextBox);

            // 年度を西暦に変更
            AddEqualCond(searchAlInput, templateTable.JokasoTorokuNendoColumn.ColumnName, torokuNendoTextBox);
            //AddEqualCondWarekiNendo(searchAlInput, templateTable.JokasoTorokuNendoColumn.ColumnName, torokuNendoTextBox);

            AddGreaterEqualCond(searchAlInput, templateTable.JokasoRenbanColumn.ColumnName, jokasoDaichoRenbanFromTextBox);
            AddLesserEqualCond(searchAlInput, templateTable.JokasoRenbanColumn.ColumnName, jokasoDaichoRenbanToTextBox);

            AddGreaterEqualCond(searchAlInput, templateTable.JokasoShoriTaishoJininColumn.ColumnName, ninsouFromTextBox);
            AddLesserEqualCond(searchAlInput, templateTable.JokasoShoriTaishoJininColumn.ColumnName, ninsouToTextBox);

            AddEqualCond(searchAlInput, templateTable.JokasoKyuChikuCdColumn.ColumnName, oldChikuCdTextBox);
            AddEqualCond(searchAlInput, templateTable.JokasoGenChikuCdColumn.ColumnName, nowChikuCdTextBox);

            AddLikePartialAnyCond(searchAlInput,
                new string[] { templateTable.JokasoSetchishaNmColumn.ColumnName, templateTable.JokasoSetchishaKanaColumn.ColumnName },
                new System.Windows.Forms.Control[] { setchishaNmTextBox });

            AddLikePartialAnyCond(searchAlInput,
                new string[] { templateTable.JokasoSetchishaNmColumn.ColumnName, templateTable.JokasoSetchishaKanaColumn.ColumnName },
                new System.Windows.Forms.Control[] { setchishaNm2TextBox });

            AddLikePartialAnyCond(searchAlInput,
                new string[] { templateTable.JokasoSetchishaAdrColumn.ColumnName },
                new System.Windows.Forms.Control[] { setchishaAdrTextBox });

            AddLikePartialAnyCond(searchAlInput,
                new string[] { templateTable.JokasoSetchishaAdrColumn.ColumnName },
                new System.Windows.Forms.Control[] { setchishaAdr2TextBox });

            AddLikePartialAnyCond(searchAlInput,
                new string[] { templateTable.JokasoShisetsuNmColumn.ColumnName },
                new System.Windows.Forms.Control[] { shisetsuNmTextBox });

            AddLikePartialAnyCond(searchAlInput,
                new string[] { templateTable.JokasoShisetsuNmColumn.ColumnName },
                new System.Windows.Forms.Control[] { shisetsuNm2TextBox });

            AddLikePartialAnyCond(searchAlInput,
                new string[] { templateTable.JokasoSetchiBashoAdrColumn.ColumnName },
                new System.Windows.Forms.Control[] { setchibashoAdrTextBox });

            AddLikePartialAnyCond(searchAlInput,
                new string[] { templateTable.JokasoSetchiBashoAdrColumn.ColumnName },
                new System.Windows.Forms.Control[] { setchibashoAdr2TextBox });

            AddEqualCond(searchAlInput, templateTable.JokasoSeisouGyoshaCdColumn.ColumnName, seisouGyoshaCdTextBox);
            AddEqualCond(searchAlInput, templateTable.JokasoHoshutenkenGyoshaCdColumn.ColumnName, hoshuGyoshaCdTextBox);

            // 並び順指定
            searchAlInput.Query.AddOrderCol(templateTable.JokasoHokenjoCdColumn.ColumnName);
            searchAlInput.Query.AddOrderCol(templateTable.JokasoTorokuNendoColumn.ColumnName);
            searchAlInput.Query.AddOrderCol(templateTable.JokasoRenbanColumn.ColumnName);
        }
        #endregion

        #region DispSearchResult
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/28　habu　　    新規作成
        /// </history>
        protected override void DispSearchResult(ApplicationLogic.Generic.StdList.ISearchBtnClickALOutput searchAlOutput)
        {
            // Clear before fill
            jokasoDaichoMstDataSet.Clear();

            // display search result 
            jokasoDaichoMstDataSet.Merge(searchAlOutput.SearchDataTable);

            // 派生列の生成はCreateDerivedColumn内で実行される

            // process disp data
            #region to be removed
            //foreach (JokasoDaichoMstDataSet.JokasoDaichoMstRow row in jokasoDaichoMstDataSet.JokasoDaichoMst)
            //{
            //    // convert nendo seireki -> wareki
            //    row.JokasoTorokuNendo = Common.Common.ConvertToHoshouNendoWareki(row.JokasoTorokuNendo);
            //}
            #endregion

            #region to be removed
            //foreach (DataGridViewRow row in jokasoDaichoListDataGridView.Rows)
            //{
            //    object val = row.Cells[jokasoTorisageBiDataGridViewTextBoxColumn.Index].Value;

            //    // 表示用浄化槽登録番号生成
            //    {
            //        object hokenjoCd = row.Cells[jokasoHokenjoCdDataGridViewTextBoxColumn.Index].Value;
            //        object nendo = row.Cells[jokasoTorokuNendoDataGridViewTextBoxColumn.Index].Value;
            //        object renban = row.Cells[jokasoRenbanDataGridViewTextBoxColumn.Index].Value;

            //        string torokuNo = Common.Common.CreateKyokaiNoString(hokenjoCd.ToString(), nendo.ToString(), renban.ToString());

            //        row.Cells[JokasoTorokuNo.Index].Value = torokuNo;
            //    }

            //    // 取下げ日が設定されている場合は、取下げ済とする
            //    if (val != DBNull.Value && val != null && !val.Equals(string.Empty))
            //    {
            //        row.Cells[TorisageFlg.Index].Value = "○";
            //    }
            //}
            #endregion
        }
        #endregion

        #region CreateDerivedColumn
        /// <summary>
        /// 
        /// </summary>
        protected override void CreateDerivedColumn()
        {
            foreach (DataGridViewRow row in jokasoDaichoListDataGridView.Rows)
            {
                object val = row.Cells[jokasoTorisageBiDataGridViewTextBoxColumn.Index].Value;

                // 表示用浄化槽登録番号生成
                {
                    object hokenjoCd = row.Cells[jokasoHokenjoCdDataGridViewTextBoxColumn.Index].Value;
                    object nendo = row.Cells[jokasoTorokuNendoDataGridViewTextBoxColumn.Index].Value;
                    object renban = row.Cells[jokasoRenbanDataGridViewTextBoxColumn.Index].Value;

                    string torokuNo = Common.Common.CreateKyokaiNoString(hokenjoCd.ToString(), nendo.ToString(), renban.ToString());

                    row.Cells[JokasoTorokuNo.Index].Value = torokuNo;
                }

                // 取下げ日が設定されている場合は、取下げ済とする
                if (val != DBNull.Value && val != null && !val.Equals(string.Empty))
                {
                    row.Cells[TorisageFlg.Index].Value = "○";
                }
            }
        }
        #endregion

        #region ToNewDetailForm
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/28　habu　　    新規作成
        /// </history>
        protected override void ToNewDetailForm()
        {
            JokasoDaichoShosai frm = new JokasoDaichoShosai();
            // 画面遷移方法変更
            Program.mForm.MoveNext(frm);
            // Program.mForm.ShowForm(frm);
        }
        #endregion

        #region ToEditDetailForm
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/28　habu　　    新規作成
        /// </history>
        protected override void ToEditDetailForm(DataGridViewRow selectedRow)
        {
            // key params of current row
            string hokenjoCd = selectedRow.Cells[jokasoHokenjoCdDataGridViewTextBoxColumn.Index].Value.ToString();
            string torokuNendo = selectedRow.Cells[jokasoTorokuNendoDataGridViewTextBoxColumn.Index].Value.ToString();
            string renban = selectedRow.Cells[jokasoRenbanDataGridViewTextBoxColumn.Index].Value.ToString();

            //// 登録年度(平成)を西暦に変換
            //torokuNendo = Common.Common.ConvertToHoshouNendoSeireki(torokuNendo);

            JokasoDaichoShosai frm = new JokasoDaichoShosai(hokenjoCd, torokuNendo, renban);
            // 画面遷移方法変更
            Program.mForm.MoveNext(frm);
            // Program.mForm.ShowForm(frm);
        }
        #endregion

        #region CloseForm
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/28　habu　　    新規作成
        /// </history>
        protected override void CloseForm()
        {
            Program.mForm.MovePrev();

            //JokasoDaichoKanriMenu frm = new JokasoDaichoKanriMenu();
            //Program.mForm.ShowForm(frm);
        }
        #endregion

        #region SetControlDomain
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/28　habu　　    新規作成
        /// </history>
        protected override void SetControlDomain()
        {
            hokenjoCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 2);

            // 20150119 habu 年度を西暦に変更
            torokuNendoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 4);

            jokasoDaichoRenbanFromTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 5);
            jokasoDaichoRenbanToTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 5);

            ninsouFromTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM);
            ninsouToTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM);

            oldChikuCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 5);
            nowChikuCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 5);

            setchishaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);
            setchishaNm2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);

            setchishaAdrTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 80);
            setchishaAdr2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 80);

            shisetsuNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);
            shisetsuNm2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);

            setchibashoAdrTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 80);
            setchibashoAdr2TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 80);

            hoshuGyoshaCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            hoshuGyoshaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);

            seisouGyoshaCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            seisouGyoshaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);

            jokasoDaichoListDataGridView.SetStdControlDomain(jokasoNinsouDataGridViewTextBoxColumn.Index, ZControlDomain.ZG_STD_NUM);
            jokasoDaichoListDataGridView.SetStdControlDomain(TorisageFlg.Index, ZControlDomain.ZG_STD_NAME, DataGridViewContentAlignment.TopCenter);

        }
        #endregion

        #region SetStdEventHandler
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/28　habu　　    新規作成
        /// </history>
        protected override void SetStdEventHandler()
        {
            Common.Common.SetStdButtonKey(this, Keys.F3, henkouTodokeButton);
            Common.Common.SetStdButtonKey(this, Keys.F4, iraiTorokuButton);
            Common.Common.SetStdButtonKey(this, Keys.F5, iraiEditButton);

            // コード値、範囲値の自動設定

            Common.Common.SetRangeCdAutoFill(jokasoDaichoRenbanFromTextBox, jokasoDaichoRenbanToTextBox);
            Common.Common.SetRangeNoAutoFill(ninsouFromTextBox, ninsouToTextBox);

            Common.Common.SetCdAutoPad(hokenjoCdTextBox);
            Common.Common.SetCdAutoPad(torokuNendoTextBox);
            Common.Common.SetCdAutoPad(oldChikuCdTextBox);
            Common.Common.SetCdAutoPad(nowChikuCdTextBox);

            Common.Common.SetCdAutoPad(hoshuGyoshaCdTextBox);
            Common.Common.SetCdAutoPad(seisouGyoshaCdTextBox);

            MstUtility.GyoshaMst.SetStdGyoshaSearchButton(hoshuGyoshaKensakuButton, hoshuGyoshaCdTextBox, hoshuGyoshaNmTextBox);
            MstUtility.GyoshaMst.SetStdGyoshaSearchButton(seisouGyoshaKensakuButton, seisouGyoshaCdTextBox, seisouGyoshaNmTextBox);

            MstUtility.GyoshaMst.SetStdGyoshaCdChanged(hoshuGyoshaCdTextBox, hoshuGyoshaNmTextBox);
            MstUtility.GyoshaMst.SetStdGyoshaCdChanged(seisouGyoshaCdTextBox, seisouGyoshaNmTextBox);

            MstUtility.ChikuMst.SetStdChikuSearchButton(chikuKensakuButton, oldChikuCdTextBox, nowChikuCdTextBox, null, false);
        }
        #endregion

        #endregion

    }
}
