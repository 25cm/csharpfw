using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Common
{
    public partial class YubinNoKensaku : FukjBaseForm
    {
        #region properties

        public string ZipCd { get; set; }

        public string Adr { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public YubinNoKensaku()
        {
            InitializeComponent();
        }
        #endregion

        #region YubinNoKensaku_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void YubinNoKensaku_Load(object sender, EventArgs e)
        {
            this.todofukenInfoTableAdapter.Fill(this.yubinNoAdrMstDataSet.TodofukenInfo);
            adrTextBox.Text = this.Adr;

            todofukenComboBox.Text = "福岡県";

            SetStdEventHandler();
        }
        #endregion

        #region tojiruButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tojiruButton_Click(object sender, EventArgs e)
        {
            this.ZipCd = string.Empty;
            this.Adr = string.Empty;
            this.Close();
        }
        #endregion

        #region kensakuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                IGetYubinNoAdrMstByTodofukenAdrALInput alInput = new GetYubinNoAdrMstByTodofukenAdrALInput();
                alInput.TodofukenNm = todofukenComboBox.Text;
                alInput.AdrNm = "%" + adrTextBox.Text + "%";
                IGetYubinNoAdrMstByTodofukenAdrALOutput alOutput = new GetYubinNoAdrMstByTodofukenAdrApplicationLogic().Execute(alInput);

                if (alOutput.YubinNoAdrMstDT.Columns.Count > 0)
                {
                    yubinNoAdrMstDataGridView.DataSource = alOutput.YubinNoAdrMstDT;
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

        #region selectButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in yubinNoAdrMstDataGridView.SelectedRows)
            {
                this.ZipCd = row.Cells[0].Value.ToString();
                this.Adr = row.Cells[2].Value.ToString() + row.Cells[3].Value.ToString();
            }

            this.Close();
        }
        #endregion

        #region yubinNoAdrMstDataGridView_CellDoubleClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void yubinNoAdrMstDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    if (e.RowIndex <= -1) { return; }

                    selectButton.PerformClick();
                });
        }
        #endregion

        #region SetStdEventHandler
        /// <summary>
        /// 
        /// </summary>
        private void SetStdEventHandler()
        {
            Common.SetStdButtonKey(this, Keys.F1, selectButton);
            Common.SetStdButtonKey(this, Keys.F8, kensakuButton);
            Common.SetStdButtonKey(this, Keys.F12, tojiruButton);
        }
        #endregion
    }
}
