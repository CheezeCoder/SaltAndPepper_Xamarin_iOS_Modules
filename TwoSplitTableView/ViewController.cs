using System;
using System.Collections.Generic;
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
		private readonly string title 			= "Two Split Table View";
		private readonly float defaultCellHeight 	= 44;
		private readonly List<string> dataSource;

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
		public override void ViewDidLoad ()
		{
			AutomaticallyAdjustsScrollViewInsets 	= false;
			tableViewBottom.Source 			= bottomSource;
			tableViewTop.Source 			= topSource;
			tableViewTop.BackgroundColor = "CECED2".ToUIColor ();
			tableViewTop.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine;
			tableViewTop.SeparatorInset = UIEdgeInsets.Zero;
			tableViewTop.LayoutMargins = UIEdgeInsets.Zero;
		


			//Remove unused table cells below existing cells.
			tableViewBottom.TableFooterView 	= new UIView ();

			bottomSource.cellDidPress += updateTopTable;


			View.AddSubview (tableViewTop);
			View.AddSubview (tableViewBottom);
			base.ViewDidLoad ();
		}

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

		private void  updateTopTable(string contents)
		{
			topSource.updateField (contents);
			tableViewTop.ReloadData ();

		}


	}
}