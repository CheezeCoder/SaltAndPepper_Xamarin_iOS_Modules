using System;
using UIKit;
using System.Collections.Generic;

namespace CustomCellTableView 
{
	///<summary>
	/// View Controller hosues the views.  In this case we only have one view and that is a UIKit default UITableView.  The table view houses
	/// the data source which we set with our subclassed UITableViewSource.
	///</summary>
	public class ViewController : UIViewController
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		/// <summary>
		/// The table view.
		/// </summary>
		private readonly UITableView tableView;
		/// <summary>
		/// The data source.
		/// </summary>
		private readonly List<List<string>> dataSource;
		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="CustomCellTableView.ViewController"/> class.  Here we also build our fake database/source
		/// which is in this case just a collection of 3 strings.  We also delegate our subclassed UITableViewSource to our UITableView's source.  We also
		/// pass our collection in as a parameter to the UITableViewSource so that it has the data we want to display on the table. 
		/// </summary>
		public ViewController ()
		{
			tableView 			= new UITableView ();
			tableView.RowHeight 		= UITableView.AutomaticDimension;
			tableView.EstimatedRowHeight 	= 86;
			dataSource 			= new List<List<string>> (){ 
				new List<string>(){ "Header One", "Subtitle One", "Jan", "01", "12:00" },
				new List<string>(){ "Header Two", "Subtitle Two", "Feb", "02", "13:00" },
				new List<string>(){ "Header Three", "Subtitle Three", "Mar", "03", "14:00" }
			};
			tableView.Source 		= new TableViewSource (dataSource);
		}
			
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		/// <summary>
		/// Sets the title of the controller, our background color and adds our TableView to the Controller's View.
		/// </summary>
		public override void ViewDidLoad ()
		{
			Title 			= "Custom Size and Content Cell in Table View";
			View.BackgroundColor 	= UIColor.White;
			View.AddSubview (tableView);
			base.ViewDidLoad ();
		}

		/// <summary>
		/// Simply need to set our table view to the size of the screen here. 
		/// </summary>
		public override void ViewDidLayoutSubviews ()
		{
			tableView.Frame 	= View.Bounds;
			base.ViewDidLayoutSubviews ();
		}
		//========================================================================================================================================
		//  PUBLIC METHODS
		//========================================================================================================================================
		//========================================================================================================================================
		//  PRIVATE METHODS
		//========================================================================================================================================
	}
}