using System;
using UIKit;
using System.Collections.Generic;

namespace TwoSplitTableViewExtended 
{
	/// <summary>
	/// Custom top table view cell.
	/// </summary>
	public class CustomTopTableViewCell : UITableViewCell
	{
		//========================================================================================================================================
		//  PRIVATE CONST CLASS PROPERTIES
		//========================================================================================================================================
		/// <summary>
		/// Cell left padding to look good.
		/// </summary>
		private const float cellPadding 	= 15;
		/// <summary>
		/// Top table view cell unique identifier.
		/// </summary>
		public const string cellIdentifier	= "inputCell";
		/// <summary>
		/// Prefix for our only top table view cell.  Stays persisentent. 
		/// </summary>
		private const string cellPrefix 	= "Data Response: ";
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		/// <summary>
		/// Label that hoses our cell prefix.
		/// </summary>
		private UILabel cellPrefixLabel;
		/// <summary>
		/// Lable that houses our data to display in the cell.
		/// </summary>
		private UILabel	cellDataLabel;
		/// <summary>
		/// The cell accessory detail.
		/// </summary>
		private UITableViewCellAccessory cellAccessoryDetail;
		/// <summary>
		/// The color of the cell text.
		/// </summary>
		private UIColor cellTextColor;
		/// <summary>
		/// The color of the inactive accessory.
		/// </summary>
		private UIColor inactiveAccessoryColor;
		/// <summary>
		/// The color of the active accessory.
		/// </summary>
		private UIColor activeAccessoryColor;
		/// <summary>
		/// The color of the cell prefix text.
		/// </summary>
		private UIColor cellPrefixTextColor;
		/// <summary>
		/// The prefix lable font.
		/// </summary>
		private UIFont prefixLableFont;
		/// <summary>
		/// The accessory is active.
		/// </summary>
		bool accessoryIsActive;
		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="TwoSplitTableViewExtended.CustomTopTableViewCell"/> class. Inits our labels
		/// </summary>
		public CustomTopTableViewCell(CoreGraphics.CGRect frame, string id) : base(UITableViewCellStyle.Default, string.IsNullOrEmpty(id) ? cellIdentifier : id)
		{
			prefixLableFont 	= UIFont.SystemFontOfSize (UIFont.SystemFontSize);
			cellPrefixLabel 	= new UILabel (new CoreGraphics.CGRect (cellPadding, 0, getStringWidth (cellPrefix), frame.Height));
			cellDataLabel 		= new UILabel (new CoreGraphics.CGRect (cellPrefixLabel.Frame.Width + (cellPadding * 2), 0, frame.Width - getStringWidth (cellPrefix), frame.Height));
			cellAccessoryDetail 	= UITableViewCellAccessory.DetailButton;
			cellTextColor 		= UIColor.Red;
			inactiveAccessoryColor 	= UIColor.Blue;
			activeAccessoryColor 	= UIColor.Green;
			cellPrefixTextColor 	= UIColor.LightGray;

			ContentView.AddSubviews(new UIView[]{cellPrefixLabel, cellDataLabel});
		}
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		public override void LayoutSubviews ()
		{
			SeparatorInset 			= UIEdgeInsets.Zero;
			LayoutMargins 			= UIEdgeInsets.Zero;
			Accessory 			= cellAccessoryDetail;
			TintColor 			= inactiveAccessoryColor;
			cellDataLabel.TextColor 	= cellTextColor;
			cellPrefixLabel.Font 		= prefixLableFont;
			cellPrefixLabel.TextColor 	= cellPrefixTextColor;
			cellPrefixLabel.Text 		= cellPrefix;


			base.LayoutSubviews ();
		}

		//========================================================================================================================================
		//  PUBLIC METHODS
		//========================================================================================================================================
		public void updateText(string contents)
		{
			this.cellDataLabel.Text = contents;
		}

		public void updateTint()
		{
			TintColor = accessoryIsActive ? activeAccessoryColor : inactiveAccessoryColor;
			accessoryIsActive =! accessoryIsActive;
		}
		//========================================================================================================================================
		//  PRIVATE METHODS
		//========================================================================================================================================
		private nfloat getStringWidth(string item)
		{
			return item.StringSize (prefixLableFont).Width;
		}
	}

	///<summary>
	/// Source for out Top Table View.
	///</summary>
	public class TableViewSourceTop : UITableViewSource
	{
		//========================================================================================================================================
		//  PRIVATE CONST CLASS PROPERTIES
		//========================================================================================================================================
		/// <summary>
		/// The width of the io default cell.
		/// </summary>
		private const float ioDefaultCellWidth = 320;
		/// <summary>
		/// The height of the io default cell.
		/// </summary>
		private const float ioDefaultCellHeight = 44;
		/// <summary>
		/// Top table view cell unique identifier.
		/// </summary>
		public const string cellIdentifier	= "inputCell";
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		/// <summary>
		/// The data.
		/// </summary>
		private readonly List<string> data;
		/// <summary>
		/// The data to display dependant on our bottom table.
		/// </summary>
		private string cellStateData =""; 

		/// <summary>
		/// Occurs when will switch data.
		/// </summary>
		public event EventHandler willSwitchData;
		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="TwoSplitTableViewExtended.TableViewSourceTop"/> class. Inits our labels
		/// </summary>
		public TableViewSourceTop ()
		{	
		}
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		#region implemented abstract members of UITableViewSource

		/// <summary>
		/// Sets up our cell.  Only one table cell will ever show in our top table view, so we set it up with that in mind.
		/// Sets our inset and layout margins to zero.  This is also done for the table view and not all of these may need
		/// to be set, but just to be sure this is done so that our seperator stretches across the cell.  We are setting up 
		/// our own views for the cell so we can be ok with the insets at zero.  Next we use the system defualt font and font size
		/// to get the length of our prefix label.
		/// 
		/// This will help us figure out the size for out two labels.  Our prefix lable should be the same size always but can
		/// variate a bit depending on the user font system settings.  With our size calculated we can set the frame of the 
		/// prefix to be as wide as it needs to be and then set our data label to be as wide as the remaining space left in the
		/// table cell.  We also need to check if the labels have been previously added or we end up having new labels added
		/// over top of eachother.  If a label is not added (is not a child of the cell) then we can set its properties and add
		/// it.  
		/// </summary>
		/// <returns>The cell.</returns>
		/// <param name="tableView">Table view.</param>
		/// <param name="indexPath">Index path.</param>
		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var cell 		= tableView.DequeueReusableCell (cellIdentifier);
			cell 			= cell ?? new CustomTopTableViewCell (new CoreGraphics.CGRect(0,0,ioDefaultCellWidth, ioDefaultCellHeight), cellIdentifier);

			if((cell as CustomTopTableViewCell) != null) (cell as CustomTopTableViewCell).updateText (cellStateData);

			return cell;
		}

		/// <summary>
		/// Rows in the table.
		/// </summary>
		/// <returns>The in section.</returns>
		/// <param name="tableview">Tableview.</param>
		/// <param name="section">Section.</param>
		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return 1;
		}

		#endregion
		//========================================================================================================================================
		//  PUBLIC METHODS
		//========================================================================================================================================
		/// <summary>
		/// Our accessor for the data.  This allows any class to subscribe or use this method to update the cell data label.
		/// </summary>
		/// <param name="contents">Contents.</param>
		public void updateField(string contents)
		{
			cellStateData = contents;
		}

		public override void AccessoryButtonTapped (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			if (willSwitchData != null) {
				willSwitchData (this, EventArgs.Empty);
			}
			if((tableView.CellAt (indexPath) as CustomTopTableViewCell) != null) (tableView.CellAt (indexPath) as CustomTopTableViewCell).updateTint ();
		}
		//========================================================================================================================================
		//  PRIVATE METHODS
		//========================================================================================================================================


	}
}