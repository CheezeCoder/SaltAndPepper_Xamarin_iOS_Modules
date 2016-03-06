using System;
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
		private readonly List<string> dataSource;
		private readonly string cellReuseIdentifier = "myCell";
		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="TableViewInViewController.TableViewSource"/> class.
		/// </summary>
		public TableViewSource (List<string> data)
		{
			dataSource = data;
		}
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return dataSource.Count;
		}

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