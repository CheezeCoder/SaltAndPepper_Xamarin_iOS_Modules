﻿using System;
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
		private string cellStateData =""; 
		private float cellPadding = 15;
		private string cellPrefix = "Data Response: ";
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

			if (cell.Subviews.Length > 0) {
				foreach (UIView s in cell.Subviews) {
					s.RemoveFromSuperview ();
				}
			}
//			cell.TextLabel.Text = cellStateData;
//			cell.TextLabel.TextColor = UIColor.Red;

			var stringLength = cellPrefix.StringSize (UIFont.SystemFontOfSize (UIFont.SystemFontSize)).Width;
			var textField = new UILabel(new CoreGraphics.CGRect(cellPadding, 0, stringLength, cell.Bounds.Height));
			textField.Text = cellPrefix;
			textField.Font = UIFont.SystemFontOfSize(UIFont.SystemFontSize);
			textField.TextColor = UIColor.LightGray;
			cell.AddSubview (textField);

			var label = new UILabel (new CoreGraphics.CGRect (textField.Frame.Width + (cellPadding * 2), 0, cell.Frame.Width - stringLength, cell.Frame.Height));
			label.Text = cellStateData;
			label.TextColor = UIColor.Red;

			cell.AddSubview (label);

			cell.SeparatorInset 	= UIEdgeInsets.Zero;
			cell.LayoutMargins 	= UIEdgeInsets.Zero;
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
		public void updateField(string contents)
		{
			cellStateData = contents;
		}
		//========================================================================================================================================
		//  PRIVATE METHODS
		//========================================================================================================================================


	}
}