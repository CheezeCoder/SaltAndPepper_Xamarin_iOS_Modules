using System;
using UIKit;

namespace TwoSplitTableView 
{
	///<summary>
	///
	///</summary>
	public class TableViewSourceTop : UITableViewSource
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		private readonly string cellIdentifier = "inputCell";
		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="TwoSplitTableView.TableViewSourceTop"/> class.
		/// </summary>
		public TableViewSourceTop ()
		{
			
		}
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		#region implemented abstract members of UITableViewSource

		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (cellIdentifier);

			cell = cell ?? new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);

			var tf = new UITextField (cell.Bounds);
			cell.AddSubview (tf);
			cell.AccessoryView = new UIButton (UIButtonType.ContactAdd);

			return cell;
				



		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return 1;
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