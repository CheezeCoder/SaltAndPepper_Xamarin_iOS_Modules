using System;
using UIKit;
using System.Collections.Generic;
using System.Globalization;

namespace ContactPicker 
{
	/// <summary>
	/// Delgate for our cell interaction.  Allows the string contents of the selected cell to be passed to a receiving 
	/// method.  In this case the parent View Controller for the Table View this source belongs to.  
	/// </summary>
	public delegate void cellContentsHandler (int row, int section);
	///<summary>
	/// Our Source class for the bottom table view.
	///</summary>
	public class TableViewSourceColorCells : UITableViewSource
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		/// <summary>
		/// The data.
		/// </summary>
		private readonly List<TableViewSection> tableStructureData;
		/// <summary>
		/// Bottom table view cell unique identifier.
		/// </summary>
		private const string bottomCellIdentifier = "bottomDataCell";
		/// <summary>
		/// Header title for our group of data.
		/// </summary>
		private const string sectionTitle = "Data Objects";
		/// <summary>
		/// Occurs when cell is pressed.
		/// </summary>
		public event cellContentsHandler colorCellDidPress;
		/// <summary>
		/// Reference to our Color Row Repository.  Normally if we were using a proper database we could just instanciate this
		/// repo here but for the purpose of this example this instance is a reference to the repo in ViewController and this is
		/// set in the constructor here.
		/// </summary>
		private FakeColorRowRepository repo;

		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="TwoSplitTableViewExtended.TableViewSourceColorCells"/> class. Sets our data.
		/// </summary>
		public TableViewSourceColorCells (List<TableViewSection> tableLayoutData, FakeColorRowRepository repo)
		{	
			this.tableStructureData = tableLayoutData;
			this.repo = repo;
		}
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		#region implemented abstract members of UITableViewSource

		/// <summary>
		/// Uses our TableViewSection and TableViewRow structure to get the correct cell if it is dequeuable which it always should be as we instanciate
		/// all of the cells for our ColorCellSource view in the repo helper method.  The cells should all be ready to be therefore deqeued.  It would 
		/// normally probably be a good idea to check and make sure the cell is there anyways in production code.  The cell is then cast as a 
		/// TableViewRow and we set its state based on what the database has stored for the particular cell index.  
		/// </summary>
		/// <returns>The cell.</returns>
		/// <param name="tableView">Table view.</param>
		/// <param name="indexPath">Index path.</param>
		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (tableStructureData [indexPath.Section].rows [indexPath.Row].Type.ReuseID) ?? tableStructureData [indexPath.Section].rows [indexPath.Row].Cell;

			var tableViewRow = cell as TableViewRow;
			if (tableViewRow != null) {
				tableViewRow.SetState (repo.All()[indexPath.Section][indexPath.Row]);
			}

			return cell;
		}

		/// <summary>
		/// Number of sections.
		/// </summary>
		/// <returns>The of sections.</returns>
		/// <param name="tableView">Table view.</param>
		public override nint NumberOfSections (UITableView tableView)
		{
			return tableStructureData.Count;
		}

		/// <summary>
		/// Rows in the section
		/// </summary>
		/// <returns>The in section.</returns>
		/// <param name="tableview">Tableview.</param>
		/// <param name="section">Section.</param>
		public override nint RowsInSection (UITableView tableview, nint section)
		{
			int s = (int)section;
			return tableStructureData[s].rows.Count;
		}



		/// <summary>
		/// Title for the header for this section.  
		/// </summary>
		/// <returns>The for header.</returns>
		/// <param name="tableView">Table view.</param>
		/// <param name="section">Section.</param>
		public override string TitleForHeader (UITableView tableView, nint section)
		{
			return tableStructureData[(int)section].type.Title;
		}

		/// <summary>
		/// This will check to make sure our event has subscribers and if so fires our event 
		/// letting any listeners handle its event.  In this case the view controller handles
		/// updating the state of the cell and consequently its label color.  Deselects the row.
		/// </summary>
		/// <param name="tableView">Table view.</param>
		/// <param name="indexPath">Index path.</param>
		public override void RowSelected (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			if (colorCellDidPress != null) {
				colorCellDidPress (indexPath.Row, indexPath.Section);
			}

//			var cell = tableView.DequeueReusableCell (tableData [indexPath.Section].rows [indexPath.Row].Type.ReuseID) ?? tableData [indexPath.Section].rows [indexPath.Row].Cell;
//
//			if (cell != null) {
//				var tvr = cell as TableViewRow;
//				if (tvr != null) {
//					tvr.SwitchState ();
//				}
//			}

			tableView.DeselectRow (indexPath, true);
		}

		#endregion
		//========================================================================================================================================
		//  PUBLIC METHODS
		//========================================================================================================================================
		//========================================================================================================================================
		//  PRIVATE METHODS
		//========================================================================================================================================
	}
}