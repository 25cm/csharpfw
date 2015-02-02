using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Zynas.Control.Common;
using System.Reflection;
using Zynas.Framework.Utility;
using Zynas.Framework.Core.Common.Boundary;

namespace FukjBizSystem.Application.Boundary.Generic
{
    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<StdShosaiForm, Form>))]
    public abstract partial class StdShosaiForm : Form
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        protected StandardControls _stdControls;
        /// <summary>
        /// 
        /// </summary>
        protected StandardParams _stdParams;

        #endregion

        public enum DispMode
        {
            Add,        // 登録モード
            Edit,       // 編集モード
            Detail,     // 詳細
            Confirm,    // 入力確認
        }

        #region Inner classes

        /// <summary>
        /// 
        /// </summary>
        public class StandardControls
        {
            /// <summary>
            /// represent new entry(touroku) button
            /// </summary>
            public Button EntryButton;

            /// <summary>
            /// 
            /// </summary>
            public Button ChangeButton;

            /// <summary>
            /// 
            /// </summary>
            public Button DeleteButton;

            /// <summary>
            /// 
            /// </summary>
            public Button ReInputButton;

            /// <summary>
            /// 
            /// </summary>
            public Button DecisionButton;

            /// <summary>
            /// Required. represents close(tojiru) button
            /// </summary>
            public Button CloseButton;

        }

        /// <summary>
        /// 
        /// </summary>
        public class StandardParams
        {
            /// <summary>
            /// Required
            /// </summary>
            public Type ListDataTableType;
            /// <summary>
            /// Required
            /// </summary>
            public Type ListTableAdapterType;

            // TODO to be multiple data source

            /// <summary>
            /// 
            /// </summary>
            public StandardParams()
            {
                // Set Default Values
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public StdShosaiForm()
        {
            InitializeComponent();

            _stdControls = new StandardControls();
            _stdParams = new StandardParams();


            Load += StdShosaiForm_Load;
        }
        #endregion

        #region フォーム定義メソッド(Form Difinition Method)

        protected abstract void AssignStandardControls(StandardControls stdControls, StandardParams stdParams);

        #endregion

        #region 標準動作メソッド(Standard Action Method)

        /// <summary>
        /// clear search condition contents(equal to initial value)
        /// </summary>
        protected abstract void ClearCondition();

        // TODO support std method : do validate , create insert data create update

        // TODO support buttons : entry change delete reinput decide 

        /// <summary>
        /// close itself and back to formar form
        /// </summary>
        protected abstract void CloseForm();

        /// <summary>
        /// set control domain to form controls
        /// </summary>
        protected abstract void SetControlDomain();

        // TODO 
        /// <summary>
        /// 
        /// </summary>
        protected abstract void InitDataMapping();

        /// <summary>
        /// 
        /// </summary>
        protected abstract void SetStdEventHandler();

        /// <summary>
        /// 
        /// </summary>
        protected abstract void GetFormData();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected abstract bool DoValidate();

        #endregion

        #region DoFormLoad
        /// <summary>
        /// 
        /// </summary>
        protected virtual void DoFormLoad()
        {
            AssignStandardControls(_stdControls, _stdParams);

            // TODO この時点でパラメータチェックを行うべき

            SetButtonHandeler();

            SetOtherEventHandler();

            SetShortCutKey();

            SetControlDomain();

            InitDataMapping();

            SetStdEventHandler();

            // TODO get data 


        }
        #endregion

        /// <summary>
        /// Clear Form Content
        /// </summary>
        protected abstract void ClearForm();

        protected virtual void DoEntry()
        {
            // TODO 

            if (!DoValidate())
            {
                return;
            }

            // TODO ここで作るべきか?
            CreateDataInsert();
        }

        protected virtual void DoChange()
        {
            // TODO 
        }

        protected virtual void DoDelete()
        {
            // TODO 
        }

        protected virtual void DoReInput()
        {
            // TODO 
        }

        protected virtual void DoDecision()
        {
            // TODO 初期モードによって、登録か、更新かが決まる

        }

        protected virtual DataTable CreateDataInsert()
        {

        }

        protected virtual DataTable CreateDataUpdate()
        {

        }

        #region 標準初期ロードイベント(Standard Load Event Handler)

        #region StdListForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void StdShosaiForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DoFormLoad();
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);

                CloseForm();
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #endregion

        #region 標準ボタンイベント(Standard Button Event Handler)

        #region SetButtonHandeler
        /// <summary>
        /// 
        /// </summary>
        protected virtual void SetButtonHandeler()
        {
            if (_stdControls.EntryButton != null)
            {
                _stdControls.EntryButton.Click += EntryButton_Click;
            }
            if (_stdControls.ChangeButton != null)
            {
                _stdControls.ChangeButton.Click += ChangeButton_Click;
            }
            if (_stdControls.DeleteButton != null)
            {
                _stdControls.DeleteButton.Click += DeleteButton_Click;
            }
            if (_stdControls.ReInputButton != null)
            {
                _stdControls.ReInputButton.Click += ReInputButton_Click;
            }
            if (_stdControls.DecisionButton != null)
            {
                _stdControls.DecisionButton.Click += DecisionButton_Click;
            }
            if (_stdControls.CloseButton != null)
            {
                _stdControls.CloseButton.Click += CloseButton_Click;
            }
        }
        #endregion

        #region EntryButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void EntryButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DoEntry();
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

        #region ChangeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ChangeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DoChange();
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

        #region DeleteButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DoDelete();
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

        #region ReInputButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ReInputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DoReInput();
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

        #region DecisionButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DecisionButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DoDecision();
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

        #region CloseButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CloseButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                CloseForm();
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

        #region SetShortCutKey
        /// <summary>
        /// 
        /// </summary>
        protected virtual void SetShortCutKey()
        {
            if (_stdControls.EntryButton != null)
            {
                Common.Common.SetStdButtonKey(this, Keys.F1, _stdControls.EntryButton);
            }
            if (_stdControls.ChangeButton != null)
            {
                Common.Common.SetStdButtonKey(this, Keys.F2, _stdControls.ChangeButton);
            }
            if (_stdControls.DeleteButton != null)
            {
                Common.Common.SetStdButtonKey(this, Keys.F3, _stdControls.DeleteButton);
            }
            if (_stdControls.ReInputButton != null)
            {
                Common.Common.SetStdButtonKey(this, Keys.F4, _stdControls.ReInputButton);
            }
            if (_stdControls.DecisionButton != null)
            {
                Common.Common.SetStdButtonKey(this, Keys.F5, _stdControls.DecisionButton);
            }
            if (_stdControls.CloseButton != null)
            {
                Common.Common.SetStdButtonKey(this, Keys.F12, _stdControls.CloseButton);
            }
        }
        #endregion

        #endregion

        #region その他標準イベント(Other Standard Event Handler)

        #region SetOtherEventHandler
        /// <summary>
        /// 
        /// </summary>
        protected void SetOtherEventHandler()
        {

        }
        #endregion

        #endregion
    }
}
