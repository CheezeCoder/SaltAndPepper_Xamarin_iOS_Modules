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
			tableViewTop = new UITableView ();
			tableViewBottom = new UITableView ();
			topSource = new TableViewSourceTop ();
			bottomSource = new TableViewSourceBottom ();

			tableViewTop.TranslatesAutoresizingMaskIntoConstraints = false;
			tableViewBottom.TranslatesAutoresizingMaskIntoConstraints = false;


		}
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		public override void ViewDidLoad ()
		{
			View.AddSubview (tableViewTop);
			View.AddSubview (tableViewBottom);
			setViewConstraints ();
			base.ViewDidLoad ();
		}

		public override void LoadView ()
		{
			
			base.LoadView ();
		}

		public override void UpdateViewConstraints ()
		{
			
			base.UpdateViewConstraints ();
		}

		public override void ViewDidLayoutSubviews ()
		{
			Title 			= "Two Split Table View";



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

			tableViewTop.TopAnchor.ConstraintEqualTo (margins.TopAnchor).Active = true;
			tableViewTop.HeightAnchor.ConstraintEqualTo (108).Active = true;
			tableViewTop.LeadingAnchor.ConstraintEqualTo (View.LeadingAnchor).Active = true;
			tableViewTop.TrailingAnchor.ConstraintEqualTo (View.TrailingAnchor).Active = true;

			tableViewBottom.TopAnchor.ConstraintEqualTo (tableViewTop.BottomAnchor).Active = true;
			tableViewBottom.BottomAnchor.ConstraintEqualTo (margins.BottomAnchor).Active = true;
			tableViewBottom.LeadingAnchor.ConstraintEqualTo (View.LeadingAnchor).Active = true;
			tableViewBottom.TrailingAnchor.ConstraintEqualTo (View.TrailingAnchor).Active = true;
		}
	}
}