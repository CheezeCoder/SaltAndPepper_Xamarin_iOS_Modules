﻿using System;
using UIKit;

namespace TwoSplitTableView 
{
	///<summary>
	///
	///</summary>
	public class TableViewSourceBottom : UITableViewSource
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="TwoSplitTableView.TableViewSourceBottom"/> class.
		/// </summary>
		public TableViewSourceBottom ()
		{
			
		}
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		#region implemented abstract members of UITableViewSource

		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			throw new NotImplementedException ();
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			throw new NotImplementedException ();
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