using System;
using UIKit;
using System.Collections.Generic;

namespace TableViewInViewController 
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
		private readonly List<string> dataSource;
		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="TableViewInViewController.ViewController"/> class.  Here we also build our fake database/source
		/// which is in this case just a collection of 3 strings.  We also delegate our subclassed UITableViewSource to our UITableView's source.  We also
		/// pass our collection in as a parameter to the UITableViewSource so that it has the data we want to display on the table. 
		/// </summary>
		public ViewController ()
		{
			tableView 		= new UITableView ();
			dataSource 		= new List<string> (){ "Data One", "Data Two", "Data Three" };
			tableView.Source 	= new TableViewSource (dataSource);
		}
			
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		/// <summary>
		/// Sets the title of the controller, our background color and adds our TableView to the Controller's View.
		/// </summary>
		public override void ViewDidLoad ()
		{
			Title = "Table View in View Controller";
			View.BackgroundColor = UIColor.White;
			View.AddSubview (tableView);
			base.ViewDidLoad ();
		}

		/// <summary>
		/// Simply need to set our table view to the size of the screen here. 
		/// </summary>
		public override void ViewDidLayoutSubviews ()
		{
			tableView.Frame = View.Bounds;
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