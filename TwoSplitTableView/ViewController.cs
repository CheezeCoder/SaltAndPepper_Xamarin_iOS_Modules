using System;
using UIKit;

namespace TwoSplitTableView 
{
	///<summary>
	///
	///</summary>
	public class ViewController : UIViewController
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		/// <summary>
		/// 
		/// </summary>
		private readonly UITableView tableViewBottom;
		/// <summary>
		/// 
		/// </summary>
		private readonly UITableView tableViewTop;
		/// <summary>
		/// 
		/// </summary>
		private readonly TableViewSourceTop topSource;
		/// <summary>
		/// 
		/// </summary>
		private readonly TableViewSourceBottom bottomSource;
		private readonly string title = "Two Split Table View";
		private readonly float defaultCellHeight =43;
		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="TwoSplitTableView.ViewController"/> class.
		/// </summary>
		public ViewController () 
		{
			tableViewTop 	= new UITableView ();
			tableViewBottom = new UITableView ();
			topSource 	= new TableViewSourceTop ();
			bottomSource 	= new TableViewSourceBottom ();

			tableViewTop.Source = topSource;
			tableViewTop.ScrollEnabled = false;
			// Makes it so that the view of the tableView starts where the navbar ends.  Specific to a scroll view.  
			AutomaticallyAdjustsScrollViewInsets = false;




		}
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		public override void ViewDidLoad ()
		{
			View.AddSubview (tableViewTop);
			View.AddSubview (tableViewBottom);
			tableViewTop.TranslatesAutoresizingMaskIntoConstraints 		= false;
			tableViewBottom.TranslatesAutoresizingMaskIntoConstraints 	= false;
			setViewConstraints ();
			base.ViewDidLoad ();
		}

		public override void ViewDidLayoutSubviews ()
		{
			Title 				= title;
			View.BackgroundColor 		= UIColor.White;
			tableViewTop.BackgroundColor 	= UIColor.Blue;
			tableViewBottom.BackgroundColor = UIColor.Green;

			base.ViewDidLayoutSubviews ();
		}
		//========================================================================================================================================
		//  PUBLIC METHODS
		//========================================================================================================================================
		//========================================================================================================================================
		//  PRIVATE METHODS
		//========================================================================================================================================
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
	}
}