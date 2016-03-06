﻿using System;
using System.Collections.Generic;
using UIKit;

namespace TableViewInViewController 
{
	///<summary>
	///
	///</summary>
	public class TableViewSource : UITableViewSource
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		/// <summary>
		/// This is the data source for our table view and will hold whatever collection of strings is passed in through the constructor of
		/// this class.
		/// </summary>
		private readonly List<string> dataSource;
		/// <summary>
		/// A table view uses a string identifier to dequeue cells from memory.  This is an identifier to use for cell's specific to this table view
		/// so anytime the table view needs to make a new cell it will check if there is a cell with this identifier, if there it can simply dequeue the
		/// cell and resue it otherwise there is no cell with this identifier and it makes a new cell with this identifier as its identifier. 
		/// </summary>
		private readonly string cellReuseIdentifier = "myCell";
		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="TableViewInViewController.TableViewSource"/> class. Allocates our data source.
		/// </summary>
		public TableViewSource (List<string> data)
		{
			dataSource = data;
		}
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		/// <summary>
		/// Runs when the table view needs to know how many rowns to have.  In this case it will always be the number of objects we have in our data source
		/// So since the data source is a collection of string, it will return the number of string that are in our List<string>'s 
		/// </summary>
		/// <returns>The in section.</returns>
		/// <param name="tableview">Tableview.</param>
		/// <param name="section">Section.</param>
		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return dataSource.Count;
		}

		/// <summary>
		/// This method will build our cell for us.  It dequeues a cell with the identifier we declared as a private member of this class
		/// or if we have not done this yet we create a new cell with the given identifier.  We then set the label of the cell
		/// to whatever is in our data source.  To get the right index we simply use a catagory of indexPath which is row to indicate
		/// what index of our List<string> to get the tile from.  Then we return the cell for use. 
		/// </summary>
		/// <returns>The cell.</returns>
		/// <param name="tableView">Table view.</param>
		/// <param name="indexPath">Index path.</param>
		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var cell 	= tableView.DequeueReusableCell (cellReuseIdentifier);
			cell 		= cell ?? new UITableViewCell (UITableViewCellStyle.Default, cellReuseIdentifier);

			cell.TextLabel.Text = dataSource [indexPath.Row];

			return cell;

		}
		//========================================================================================================================================
		//  PUBLIC METHODS
		//========================================================================================================================================

		//========================================================================================================================================
		//  PRIVATE METHODS
		//========================================================================================================================================
	}
}