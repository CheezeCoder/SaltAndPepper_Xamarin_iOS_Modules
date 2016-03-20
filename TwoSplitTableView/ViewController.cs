using System;
using System.Collections.Generic;
using UIKit;

namespace TwoSplitTableView 
{
	///<summary>
	/// Our view controller controlling our two table views and facilitating the data passed between them.
	///</summary>
	public class ViewController : UIViewController
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		/// <summary>
		/// Our bottom table view.  This table view houses our data and is the interactive table in our example.
		/// The cells chosen in this table will directly affect the top table view.
		/// </summary>
		private readonly UITableView tableViewBottom;
		/// <summary>
		/// Our top table View.  This view is our dependant table view in our example and will react and display 
		/// information accordingly based on interaction from the bottom table View.
		/// </summary>
		private readonly UITableView tableViewTop;
		/// <summary>
		/// This is the UITableViewSource class for the top table.
		/// </summary>
		private readonly TableViewSourceTop topSource;
		/// <summary>
		/// This is the UITableViewSource class for the bottom table.
		/// </summary>
		private readonly TableViewSourceBottom bottomSource;
		/// <summary>
		/// The title for our Navigation Controller / App.
		/// </summary>
		private readonly string title 			= "Two Split Table View";
		/// <summary>
		/// Default height of a table cell (43 pts) according to http://iosdesign.ivomynttinen.com/ + 1 for the seperator line.
		/// </summary>
		private readonly float defaultCellHeight 	= 44;
		/// <summary>
		/// The data for our bottom table.  We dont need data for our top table as the bottom table will provide
		/// the necessary data for out top table. 
		/// </summary>
		private readonly List<string> dataSource;

		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="TwoSplitTableView.ViewController"/> class.  Seeds our fake data source and inits our 
		/// table source classes and table view classes.
		/// </summary>
		public ViewController () 
		{
			dataSource = new List<string> () {
				"Data Object One",
				"Data Object Two",
				"Data Object Three",
				"Data Object Four",
				"Data Object Five"
			};


			topSource 	= new TableViewSourceTop ();
			bottomSource 	= new TableViewSourceBottom (dataSource);
			tableViewTop 	= new UITableView ();
			tableViewBottom = new UITableView (CoreGraphics.CGRect.Empty, UITableViewStyle.Grouped);






		}
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		/// <summary>
		/// Several important declerations are done here to help setup our views correctly.  We set our sources and our background colors and then 
		/// we need to set our top table view seperator and layour margin insets to zero so that the top table view shows its seperator line
		/// all the way across instead of with the default padding such as the inner bottom table view cells have.  We then need to subscribe
		/// our helper method (updateTopTable) to the event in bottom table source's API. This will allow us to pass data between the two table
		/// sources.  Then add the views.
		/// </summary>
		public override void ViewDidLoad ()
		{
			tableViewBottom.Source 			= bottomSource;
			tableViewTop.Source 			= topSource;
			tableViewTop.BackgroundColor = "CECED2".ToUIColor ();
			tableViewTop.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine;
			tableViewTop.SeparatorInset = UIEdgeInsets.Zero;
			tableViewTop.LayoutMargins = UIEdgeInsets.Zero;

			bottomSource.cellDidPress += updateTopTable;


			View.AddSubview (tableViewTop);
			View.AddSubview (tableViewBottom);
			base.ViewDidLoad ();
		}

		/// <summary>
		/// Sets the properties for our views.  We need AutomaticallyAdjustsScrollViewInsets to be turned off for our
		/// top table cell so that it loses its default insets.  This way it positions correctly for our calculations
		/// We also turn off the top table view scrolling so that the user can't accidently scroll it.  This allows it
		/// to simulate the behaviour one finds in the native iOS messages app when choosing a new contact.  Set
		/// our title for the view, our background colors for the view and table views and turn off our autoresizemasks
		/// so that we can declare our own layouts. Finally we call our private method to set up our constraints.
		/// </summary>
		public override void ViewDidLayoutSubviews ()
		{
			// Makes it so that the view of the tableView starts where the navbar ends.  Specific to a scroll view. 
			AutomaticallyAdjustsScrollViewInsets				= false;
			Title 								= title;
			View.BackgroundColor 						= UIColor.White;
			tableViewTop.BackgroundColor 					= UIColor.White;
			tableViewBottom.BackgroundColor 				= "EFEFF4".ToUIColor ();

			tableViewTop.ScrollEnabled 					= false;
			tableViewTop.TranslatesAutoresizingMaskIntoConstraints		= false;
			tableViewBottom.TranslatesAutoresizingMaskIntoConstraints 	= false;
			setViewConstraints ();

			base.ViewDidLayoutSubviews ();
		}
		//========================================================================================================================================
		//  PUBLIC METHODS
		//========================================================================================================================================
		//========================================================================================================================================
		//  PRIVATE METHODS
		//========================================================================================================================================
		/// <summary>
		/// Sets our constraints using the best thing to ever happen to auto layout: Anchors.  The code should be self
		/// explanitory.  As we want our views to stretch the full width and height of the screen we skip using margins
		/// except for the bottom view.  
		/// </summary>
		private void setViewConstraints(){
			
			var margins 		= View.LayoutMarginsGuide;

			tableViewTop.TopAnchor.ConstraintEqualTo (TopLayoutGuide.GetBottomAnchor()).Active 	= true;
			tableViewTop.HeightAnchor.ConstraintEqualTo (defaultCellHeight).Active 			= true;
			tableViewTop.LeadingAnchor.ConstraintEqualTo (View.LeadingAnchor).Active 		= true;
			tableViewTop.TrailingAnchor.ConstraintEqualTo (View.TrailingAnchor).Active 		= true;

			tableViewBottom.TopAnchor.ConstraintEqualTo (tableViewTop.BottomAnchor).Active 		= true;
			tableViewBottom.BottomAnchor.ConstraintEqualTo (margins.BottomAnchor).Active 		= true;
			tableViewBottom.LeadingAnchor.ConstraintEqualTo (View.LeadingAnchor).Active 		= true;
			tableViewBottom.TrailingAnchor.ConstraintEqualTo (View.TrailingAnchor).Active 		= true;
		}

		/// <summary>
		/// Our helper method to facilitate data being passed from the bottom to the top table view source.
		/// We wouldn't need this method here except for the fact that we need to call the Top Table Views
		/// reload data to update the data. 
		/// </summary>
		/// <param name="contents">Contents.</param>
		private void  updateTopTable(string contents)
		{
			topSource.updateField (contents);
			tableViewTop.ReloadData ();

		}


	}
}