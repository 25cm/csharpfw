/// TriStateTreeNode class
/// 
///	Contains the logic needed for having the nodes check and uncheck themselves in a logical way.
///	A node can be checked / unchecked in code and that will have consequences for it's parent and child nodes.
///	
///	For instance:
///		1) Unchecking a node will cause all children to be unchecked too and will cause the paren to be either in an unchecked
///		   or indeterminate state.
///		2) Checking a node will cause all children to be checked too and will cause the parent to be either checked or
///		   indeterminate state.
///		   
///	Additionally, a node can be excluded from the "CheckBoxes" property in the treeview, causing
///	the node to be drawn without a checkbox present.
///	
///	Because all custom drawing takes place after the default treeview drawing, lines are drawn to replace the
///	checkboxes that were previously deleted.
///	
///	For the line-drawing to be accurate, a node examines its own state and reports the type of line to draw to the treeview,
///	through the NodeLineType property.
///	

using System.ComponentModel;
using System.Windows.Forms;

namespace FukjTabletSystem.Controls
{
	/// <summary>
	/// NodeLineType enumeration
	/// Type of dotted line to draw when drawing a node.
	/// </summary>
	internal enum NodeLineType
	{
		None,
		Straight,
		WithChildren
	}

	/// <summary>
	///	TriStateTreeNode class
	/// </summary>
	public class TriStateTreeNode : TreeNode
	{
        private int _checkedCount = 0;
        private string _baseText = string.Empty;

		// stores node state ( either checked, unchecked or indeterminate )
		private CheckState _nodeCheckState = CheckState.Unchecked;

		// determines if the node should be regarded a container. 
		// Only a folder can have an third (indeterminate) state
		private bool _isContainer = false;
		private bool _checkboxVisible = true;

        // モニタリングのキー
        private string _pk1_KensaIraiHoteiKbn = string.Empty;
        private string _pk2_KensaIraiHokenjoCd = string.Empty;
        private string _pk3_KensaIraiNendo = string.Empty;
        private string _pk4_KensaIraiRenban = string.Empty;
        private string _pk5_MonitoringGroupCd = string.Empty;
        private string _pk6_MonitoringKbn = string.Empty;
        private string _pk7_MonitoringShosaiCd = string.Empty;

		// public constructor
		public TriStateTreeNode() : base() {}
        public TriStateTreeNode(string text) : base(text) { _baseText = text; }
        public TriStateTreeNode(string text, int imageIndex, int selectedImageIndex) : base(text, imageIndex, selectedImageIndex) { _baseText = text; }
        public TriStateTreeNode(string text, int imageIndex, int selectedImageIndex, TriStateTreeNode[] children) : base(text, imageIndex, selectedImageIndex, children) { _baseText = text; }
        public TriStateTreeNode(string text, TriStateTreeNode[] children) : base(text, children) { _baseText = text; }


		/// <summary>
		/// Get / set if the node is checked or not.
		/// </summary>
		[Browsable(false)]
		new public bool Checked
		{
			get { return (this._nodeCheckState != CheckState.Unchecked); }
			set { SetCheckedState( value ? CheckState.Checked: CheckState.Unchecked ); }
		}

		/// <summary>
		/// Get's the node's current state, either checked / unchecked for non-container nodes,
		/// or checked / unchecked / indeterminate for container nodes.
		/// </summary>
		public CheckState CheckState
		{
			get { return this._nodeCheckState; }
		}

		/// <summary>
		/// Determines if the node should act as a container
		/// </summary>
		public bool IsContainer
		{
			get { return _isContainer; } 
			set { _isContainer = value; }
		}

		public bool CheckboxVisible
		{
			get { return this._checkboxVisible; }
			set { this._checkboxVisible = value; }
		}

        /// <summary>
        /// PKey1
        /// </summary>
        public string PK1_KensaIraiHoteiKbn
        {
            get { return this._pk1_KensaIraiHoteiKbn; }
            set { this._pk1_KensaIraiHoteiKbn = value; }
        }

        /// <summary>
        /// PKey2
        /// </summary>
        public string PK2_KensaIraiHokenjoCd
        {
            get { return this._pk2_KensaIraiHokenjoCd; }
            set { this._pk2_KensaIraiHokenjoCd = value; }
        }

        /// <summary>
        /// PKey3
        /// </summary>
        public string PK3_KensaIraiNendo
        {
            get { return this._pk3_KensaIraiNendo; }
            set { this._pk3_KensaIraiNendo = value; }
        }

        /// <summary>
        /// PKey4
        /// </summary>
        public string PK4_KensaIraiRenban
        {
            get { return this._pk4_KensaIraiRenban; }
            set { this._pk4_KensaIraiRenban = value; }
        }

        /// <summary>
        /// PKey5
        /// </summary>
        public string PK5_MonitoringGroupCd
        {
            get { return this._pk5_MonitoringGroupCd; }
            set { this._pk5_MonitoringGroupCd = value; }
        }

        /// <summary>
        /// PKey6
        /// </summary>
        public string PK6_MonitoringKbn
        {
            get { return this._pk6_MonitoringKbn; }
            set { this._pk6_MonitoringKbn = value; }
        }

        /// <summary>
        /// PKey7
        /// </summary>
        public string PK7_MonitoringShosaiCd
        {
            get { return this._pk7_MonitoringShosaiCd; }
            set { this._pk7_MonitoringShosaiCd = value; }
        }

		internal NodeLineType NodeLineType
		{
			get 
			{
				// is this node bound to a treeview ?
				if( null != this.TreeView )
				{
					// do we need to draw lines at all?
					if( !this.TreeView.ShowLines ) { return NodeLineType.None; }
					if( this.CheckboxVisible ) { return NodeLineType.None; }

					if( this.Nodes.Count > 0 )
					{
						return NodeLineType.WithChildren;
					}
					return NodeLineType.Straight;
				}

				// no treeview so this node will never been drawn at all
				return NodeLineType.None;
			}
		}

		/// <summary>
		/// Used internally by the treeview to set a node to s specific state.
		/// </summary>
		/// <param name="value"></param>
		internal void SetCheckedState( CheckState value )
		{
			CheckStateChanged( _nodeCheckState, value ); 
		}

		/// <summary>
		/// Private method that is called by one of the childnodes in order to report a
		/// change in state.
		/// </summary>
		/// <param name="childNewState">New state of the childnode in question</param>
		private void ChildCheckStateChanged( CheckState childNewState )
		{
			bool notifyParent = false;
			CheckState currentState = this._nodeCheckState;
			CheckState newState = this._nodeCheckState;

            this._checkedCount = 0;

            foreach (TreeNode node in this.Nodes)
            {
                this._checkedCount += ((TriStateTreeNode)node)._checkedCount;
            }

            this.Text = string.Format("{0} (選択: {1}件)", this._baseText, this._checkedCount);

			// take action based on the child's new state
			switch( childNewState )
			{
				case CheckState.Indeterminate: // child state changed to indeterminate
					// if one of the children's state changes to indeterminate, 
					// it's parent should do the same, if it is a container too!.
					if( IsContainer )
					{
						newState = CheckState.Indeterminate;

						// the same is valid for this node's parent.
						// check if this node's state has changed and inform the parent
						// if this is the case
						notifyParent = ( newState != currentState );
					}
					break;
				case CheckState.Checked:
					// One of the child nodes was checked so we must check:
					// 1) if the child node is the only child node, our state becomes checked too.
					// 2) if there are children with a state other then checked, our state
					//    must become indeterminate if this is a container.
					if( this.Nodes.Count == 1 ) // if there is only one child, our state changes too!
					{
						// set our state to checked too and set the flag for
						// parent notification. 
						newState = CheckState.Checked;
						notifyParent = true;
						break;
					}

					// set to checked by default
					// if this is not a container, there is no need to check further
					newState = CheckState.Checked;
					if( !IsContainer )
					{
						notifyParent = ( newState != currentState );
						break;
					}

					// traverse all child nodes to see if there are any with a state other then
					// checked. if so, change state to indeterminate.
					foreach( TreeNode node in this.Nodes )
					{
						TriStateTreeNode checkedNode = node as TriStateTreeNode;
						if( checkedNode != null && checkedNode.CheckState != CheckState.Checked  )
						{
							newState = CheckState.Indeterminate;
							break;
						}
					}

					// set notification flag if our state has to be changed too
					notifyParent = ( newState != currentState );
					break;
				case CheckState.Unchecked:
					// For nodes that are no containers, a child being unchecked is not relevant.
					// so we can exit at this point.
					if( !IsContainer )
						break;

					// A child's state has changed to unchecked so check:
					// 1) if this is the only child. if so, uncheck this node too, if it is a container, and set
					//	  notification flag for the parent.
					// 2) Check if there are child nodes with a state other then unchecked.
					//	  if so, change our state to indeterminate.
					if( this.Nodes.Count == 1 )
					{
						// synchronize state with only child.
						// set notification flag
						newState = CheckState.Unchecked;
						notifyParent = true;
						break;
					}
					
					// set to unchecked by default
					newState = CheckState.Unchecked;

					// if there is a child with a state other then unchecked,
					// our state must become indeterminate.
					foreach(TreeNode node in this.Nodes )
					{
						TriStateTreeNode checkedNode = node as TriStateTreeNode;
						if( checkedNode != null && checkedNode.CheckState != CheckState.Unchecked )
						{
							newState = CheckState.Indeterminate;
							break;
						}
					}

					// notify the parent only if our state is about to be changed too.
					notifyParent = ( newState != currentState );
					break;
			}

			// should we notify the parent? ( has our state changed? )
            //if( notifyParent )
			{
				// change state
				this._nodeCheckState = newState;

				// notify parent
				if( this.Parent != null )
				{
					TriStateTreeNode parentNode = this.Parent as TriStateTreeNode;
					if( parentNode != null )
					{
						// call the same method on the parent.
						parentNode.ChildCheckStateChanged( this._nodeCheckState );
					}
				}
			}
		}

		/// <summary>
		/// This method is only called when a node's state has been changed through the 
		/// Checked property
		/// </summary>
		/// <param name="oldState">Previous state</param>
		/// <param name="newState">New state</param>
		private void CheckStateChanged( CheckState oldState, CheckState newState )
		{
			// States are equal?
			if( newState != oldState )
			{
				// not equal.
				// modify state
				this._nodeCheckState = newState;

                if (newState == System.Windows.Forms.CheckState.Checked)
                {
                    this._checkedCount = 1;
                }
                else
                {
                    this._checkedCount = 0;
                }

				// change state of the children
				if( this.Nodes != null && this.Nodes.Count > 0 )
				{
					foreach( TreeNode node in this.Nodes )
					{
						TriStateTreeNode tsNode = node as TriStateTreeNode;
						if( tsNode != null )
						{
							tsNode.ChangeChildState( newState );
						}
					}
				}

				// notify the parent of the changed state.
				if( this.Parent != null )
				{
					TriStateTreeNode parentNode = this.Parent as TriStateTreeNode;
					if( parentNode != null )
					{
						parentNode.ChildCheckStateChanged( this._nodeCheckState );
					}
				}
			}
		}

		/// <summary>
		/// This method is only called by other nodes so it can be private.
		/// Changes state of the node to the state provided.
		/// </summary>
		/// <param name="newState"></param>
		private void ChangeChildState( CheckState newState )
		{
			// change state
			this._nodeCheckState = newState;

			// change state on the children
			if( this.Nodes != null && this.Nodes.Count > 0 )
			{
				foreach( TreeNode node in this.Nodes )
				{
					TriStateTreeNode tsNode = node as TriStateTreeNode;
					if( tsNode != null )
					{
						tsNode.ChangeChildState( newState );
					}
				}
			}
		}
        
        public void SetCount()
        {
            SetCountMain(this);
        }

        private bool SetCountMain(TriStateTreeNode node)
        {
            if (node.Nodes.Count == 0)
            {
                TriStateTreeNode tsParent = node.Parent as TriStateTreeNode;

                tsParent.ChildCheckStateChanged(System.Windows.Forms.CheckState.Checked);

                return true;
            }
            else
            {
                foreach (TreeNode childNodes in node.Nodes)
                {
                    TriStateTreeNode tsNode = childNodes as TriStateTreeNode;

                    if (SetCountMain(tsNode))
                    {
                        break;
                    }
                }

                return false;
            }
        }
	}
}
