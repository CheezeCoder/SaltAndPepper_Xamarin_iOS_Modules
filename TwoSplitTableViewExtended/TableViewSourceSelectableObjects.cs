using System;
using UIKit;
using System.Collections.Generic;
using System.Linq;

namespace TwoSplitTableViewExtended 
{
	/// <summary>
	/// Delgate for our cell interaction.  Allows the string contents of the selected cell to be passed to a receiving 
	/// method.  In this case the parent View Controller for the Table View this source belongs to.  
	/// </summary>
	public delegate void cellContentsHandlerExtd (string contents);
	///<summary>
	/// This class is our view source for our bottom table for when the user goes in to select a string.  This class is meant to represent a
	/// contact picking like function as shown in iOS native Messages app where you can select from a list of contacts and add them to the
	/// upper bar.  This helps us demonstrate how to provide this funcitonality and yet still show another set of data on the same table
	/// view and maintain the alternate data sources's state while switching back and forth.
	///</summary>
	public class TableViewSourceSelectableObjects : UITableViewSource
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		/// <summary>
		/// Bottom table view cell unique identifier.
		/// </summary>
		private const string bottomCellIdentifier = "objectListCell";
		/// <summary>
		/// Header title for our group of data.
		/// </summary>
		private const string sectionTitle = "Data Objects";
		/// <summary>
		/// Occurs when cell is pressed.
		/// </summary>
		public event cellContentsHandlerExtd cellDidPress;
		/// <summary>
		/// Reference to the repo of list of objects that should exist in a database.
		/// </summary>
		private readonly FakeObjectListRepository repo;
		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="TwoSplitTableViewExtended.TableViewSourceSelectableObjects"/> class.
		/// </summary>
		public TableViewSourceSelectableObjects (FakeObjectListRepository repo)
		{	
			this.repo = repo;
		}
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		/// <summary>
		/// Gets the cell.  Checks to make sure there are no cells to dequeu otherwise we create a new cell with default styling
		/// and add the data from the selected index's info in our data repository to the cells text label.
		/// </summary>
		/// <returns>The cell.</returns>
		/// <param name="tableView">Table view.</param>
		/// <param name="indexPath">Index path.</param>
		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (bottomCellIdentifier);
			cell = cell ?? new UITableViewCell (UITableViewCellStyle.Default, bottomCellIdentifier);

			cell.TextLabel.Text = repo.All().ElementAt(indexPath.Row);

			return cell;
		}

		/// <summary>
		/// Rows in section.
		/// </summary>
		/// <returns>The in section.</returns>
		/// <param name="tableview">Tableview.</param>
		/// <param name="section">Section.</param>
		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return repo.All().Count;
		}

		/// <summary>
		/// Titles for the section header.
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
				cellDidPress (repo.All().ElementAt(indexPath.Row));
			}

			tableView.DeselectRow (indexPath, true);
		}

		//========================================================================================================================================
		//  PUBLIC METHODS
		//========================================================================================================================================
		//========================================================================================================================================
		//  PRIVATE METHODS
		//========================================================================================================================================




	}
}