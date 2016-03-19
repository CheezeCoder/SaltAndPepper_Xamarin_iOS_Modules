using System;
using UIKit;
using System.Collections.Generic;
using System.Globalization;

namespace TwoSplitTableView 
{
	public delegate void cellContentsHandler (string contents);
	///<summary>
	///
	///</summary>
	public class TableViewSourceBottom : UITableViewSource
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		private readonly List<string> data;
		private const string bottomCellIdentifier = "bottomDataCell";
		private const string sectionTitle = "Data Objects";
		public event cellContentsHandler cellDidPress;


		private const float DEFAULTHEADERVIEWHEIGHT = 55.33333f;

		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="TwoSplitTableView.TableViewSourceBottom"/> class.
		/// </summary>
		public TableViewSourceBottom (List<string> data)
		{	
			this.data = data;
		}
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		#region implemented abstract members of UITableViewSource

		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (bottomCellIdentifier);
			cell = cell ?? new UITableViewCell (UITableViewCellStyle.Default, bottomCellIdentifier);

			cell.TextLabel.Text = data [indexPath.Row];

			return cell;
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return data.Count;
		}


		public override string TitleForHeader (UITableView tableView, nint section)
		{
			
			return sectionTitle;
		}




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