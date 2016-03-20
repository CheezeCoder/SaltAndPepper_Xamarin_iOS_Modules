using System;
using UIKit;

namespace TwoSplitTableView 
{
	///<summary>
	/// Source for out Top Table View.
	///</summary>
	public class TableViewSourceTop : UITableViewSource
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		/// <summary>
		/// Top table view cell unique identifier.
		/// </summary>
		private const string cellIdentifier 	= "inputCell";
		/// <summary>
		/// The data to display dependant on our bottom table.
		/// </summary>
		private string cellStateData 		=""; 
		/// <summary>
		/// Cell left padding to look good.
		/// </summary>
		private const float cellPadding 	= 15;
		/// <summary>
		/// Prefix for our only top table view cell.  Stays persisentent. 
		/// </summary>
		private const string cellPrefix 	= "Data Response: ";
		/// <summary>
		/// Label that hoses our cell prefix.
		/// </summary>
		private UILabel cellPrefixLabel;
		/// <summary>
		/// Lable that houses our data to display in the cell.
		/// </summary>
		private UILabel	cellDataLabel;
		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="TwoSplitTableView.TableViewSourceTop"/> class. Inits our labels
		/// </summary>
		public TableViewSourceTop ()
		{	
			cellPrefixLabel = new UILabel ();
			cellDataLabel 	= new UILabel ();
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

			cell 			= cell ?? new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);
			cell.SeparatorInset 	= UIEdgeInsets.Zero;
			cell.LayoutMargins 	= UIEdgeInsets.Zero;


			var stringLength 	= cellPrefix.StringSize (UIFont.SystemFontOfSize (UIFont.SystemFontSize)).Width;

			cellDataLabel.Text 	= cellStateData;
			cellDataLabel.TextColor = UIColor.Red;

			if (!cellPrefixLabel.IsDescendantOfView (cell)) {
				cellPrefixLabel.Frame 		= new CoreGraphics.CGRect(cellPadding, 0, stringLength, cell.Bounds.Height);
				cellPrefixLabel.Text 		= cellPrefix;
				cellPrefixLabel.Font 		= UIFont.SystemFontOfSize(UIFont.SystemFontSize);
				cellPrefixLabel.TextColor 	= UIColor.LightGray;
				cell.AddSubview (cellPrefixLabel);
			}

			if (!cellDataLabel.IsDescendantOfView (cell)) {
				cellDataLabel.Frame = new CoreGraphics.CGRect (cellPrefixLabel.Frame.Width + (cellPadding * 2), 0, cell.Frame.Width - stringLength, cell.Frame.Height);
				cell.AddSubview (cellDataLabel);
			}

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
		//========================================================================================================================================
		//  PRIVATE METHODS
		//========================================================================================================================================


	}
}