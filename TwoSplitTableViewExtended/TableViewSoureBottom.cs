using System;
using UIKit;
using System.Collections.Generic;
using System.Globalization;

namespace TwoSplitTableViewExtended 
{
	/// <summary>
	/// Delgate for our cell interaction.  Allows the string contents of the selected cell to be passed to a receiving 
	/// method.  In this case the parent View Controller for the Table View this source belongs to.  
	/// </summary>
	public delegate void cellContentsHandler (string contents);
	///<summary>
	/// Our Source class for the bottom table view.
	///</summary>
	public class TableViewSourceBottom : UITableViewSource
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		/// <summary>
		/// The data.
		/// </summary>
		private readonly List<string> data;
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
		public event cellContentsHandler cellDidPress;

		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="TwoSplitTableViewExtended.TableViewSourceBottom"/> class. Sets our data.
		/// </summary>
		public TableViewSourceBottom (List<string> data)
		{	
			this.data = data;
		}
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		#region implemented abstract members of UITableViewSource

		/// <summary>
		/// Nothing to special here. Sets the data from our data source to each cell value as a label.
		/// </summary>
		/// <returns>The cell.</returns>
		/// <param name="tableView">Table view.</param>
		/// <param name="indexPath">Index path.</param>
		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (bottomCellIdentifier);
			cell = cell ?? new UITableViewCell (UITableViewCellStyle.Default, bottomCellIdentifier);

			cell.TextLabel.Text = data [indexPath.Row];

			return cell;
		}

		/// <summary>
		/// Rows the in section.
		/// </summary>
		/// <returns>The in section.</returns>
		/// <param name="tableview">Tableview.</param>
		/// <param name="section">Section.</param>
		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return data.Count;
		}

		/// <summary>
		/// Title for header.
		/// </summary>
		/// <returns>The for header.</returns>
		/// <param name="tableView">Table view.</param>
		/// <param name="section">Section.</param>
		public override string TitleForHeader (UITableView tableView, nint section)
		{

			return sectionTitle;
		}

		/// <summary>
		/// This will check to make sure our event has subscribers and if so fires our event 
		/// with whatever text is in our targeted table cell.  Deselects the row.
		/// </summary>
		/// <param name="tableView">Table view.</param>
		/// <param name="indexPath">Index path.</param>
		public override void RowSelected (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			if (cellDidPress != null) {
				cellDidPress (data[indexPath.Row]);
			}

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