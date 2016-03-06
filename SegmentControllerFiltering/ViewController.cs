using System;
using UIKit;

namespace SegmentControllerFiltering
{
	///<summary>
	/// Our subclassed viewcontroller to house the necessary views for our UISegmentController demonstration.
	///</summary>
	public class ViewController : UIViewController
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		/// <summary>
		/// Our toolbar to act as a container for the segment control. 
		/// </summary>
		private readonly UIToolbar toolBar;
		/// <summary>
		/// Our custom subclassed segment controller.
		/// </summary>
		private readonly SegmentControlSelectionView segController;
		/// <summary>
		/// The default height of the UIToolbar in pts.
		/// </summary>
		private readonly int defaultUIToolBarHeight 	= 29;
		/// <summary>
		/// The default height of the Navigaion bar in pts.
		/// </summary>
		private readonly int defaultNavigationBarHeight = 44;
		/// <summary>
		/// The default padding for most iOS default elements in pts.
		/// </summary>
		private readonly int iosDefaultPadding = 8;
		/// <summary>
		/// The default margin for most iOS default elemetns in pts.
		/// </summary>
		private readonly int iosDefaultMargin 	= 15;
		/// <summary>
		/// A small container to represent the needed y offset in pts for our segmentController to position where we want it.
		/// </summary>
		private float segmentControllerBarYoffset;
		/// <summary>
		/// Button object to take the user to the options view controller.
		/// </summary>
		private UIBarButtonItem optionsButton;
		/// <summary>
		/// The text to display for the optionsButton.
		/// </summary>
		private readonly string optionsButtonText 		= "Options";
		/// <summary>
		/// The text to display in the navigation bar for this controller.
		/// </summary>
		private readonly string contentViewTitleText 		= "Content";
		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		/// <summary>
		/// The api handler to alert any listeners that the "options" button has been pressed.
		/// </summary>
		public event EventHandler buttonSelected;
		/// <summary>
		/// This boolean will dictate what text appears on the label for this controller and acts as a logic
		/// director for the our "fake" database information.
		/// </summary>
		private bool choice = true;
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="SegmentControllerFiltering.ToolBarView"/> class.
		/// </summary>
		public ViewController ()
		{
			this.toolBar 		= new UIToolbar ();
			this.segController 	= new SegmentControlSelectionView ();

		}
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		/// <summary>
		/// Add the UIToolBar and UINavigationBar to the view, add the UISegmentController to the UINavigationBar, init
		/// the needed steps to build the UINavigationBar ( <see cref="SegmentControllerFiltering.ViewController.AddViewControllerTitle"/> for more info )
		/// and subscribe a delegate to the event in our UISegmentController subclass.
		/// </summary>
		public override void ViewDidLoad ()
		{
			this.optionsButton 	= new UIBarButtonItem(this.optionsButtonText,UIBarButtonItemStyle.Plain, buttonSelected);
			this.NavigationItem.SetLeftBarButtonItem(optionsButton, true);
			this.View.Add(this.toolBar);
			this.toolBar.AddSubview (this.segController);
			this.Title = "Segment Controller Filtering";
			this.segController.valueChanged += this.changeBackgroundColor;
			base.ViewDidLoad ();
		}

		/// <summary>
		/// Set the frames for our subviews.  Since UIToolbar is not subclassed set its views frames as well.  The UINavigationBar needs to be offset 
		/// for the StatusBarFrame.  Our UISegmentController needs to be offset on the y axis by the height of the UINavigation bar and the StatusBarFrame 
		/// so we set our segmentControllerBarYOffset to the sum of these 2 elements.  The UIToolbar is then offset with this offset and as we want some 
		/// padding so that our UISegmentController is not right up against the top of the UIToolbar we set the height of our UIToolbar to the sum of its
		/// default height and twice the defualt ios padding. For the UISegmentController we set its width to the difference of its parent elements frame,
		/// the UIToolbar and twice the default ios Margin.  Its height should be the default height of the UIToolbar which allows the UIToolbars padding
		/// height to take effect.  The center point of the UISegmentController then needs to be set using half the width of its parent, UIToolbar and half
		/// the height of its parent, UIToolbar which allows the UISegmentController to be centered both vertically and horizontally.
		/// 
		/// Finally we set our Autoresizing masks to flexibleLeft and FlexibleRight Margins.
		/// </summary>
		public override void ViewDidLayoutSubviews ()
		{
			this.segmentControllerBarYoffset 	= (float)UIApplication.SharedApplication.StatusBarFrame.Height + defaultNavigationBarHeight;
			this.toolBar.Frame  			= new CoreGraphics.CGRect (0, this.segmentControllerBarYoffset, this.View.Bounds.Width, this.defaultUIToolBarHeight + (this.iosDefaultPadding*2));
			this.toolBar.AutoresizingMask 		= UIViewAutoresizing.FlexibleWidth;
			this.segController.Frame 		= new CoreGraphics.CGRect (0, 0, this.View.Bounds.Width - iosDefaultMargin * 2, this.defaultUIToolBarHeight);
			this.segController.Center 		= new CoreGraphics.CGPoint (this.toolBar.Frame.Size.Width / 2, this.toolBar.Frame.Size.Height / 2);
			this.segController.AutoresizingMask 	= UIViewAutoresizing.FlexibleLeftMargin | UIViewAutoresizing.FlexibleRightMargin;
			base.ViewDidLayoutSubviews ();
		}
		//========================================================================================================================================
		//  PUBLIC METHODS
		//========================================================================================================================================
		/// <summary>
		/// This is the only method for the api of this controller class and it allows our so called "logic director" to be set
		/// accordingly.  This updates our boolean for the class.  
		/// </summary>
		/// <param name="choice">true or false (true displays option 1, false displays option 2)</param>
		public void updateContent(bool choice)
		{
			this.choice = choice;
		}
		//========================================================================================================================================
		//  PRIVATE METHODS
		//========================================================================================================================================


		/// <summary>
		/// This is our delegate to demonstrate the use of subscribing to the UISegmentControllers events.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		private void changeBackgroundColor(object sender, EventArgs args)
		{
			switch ((sender as UISegmentedControl).SelectedSegment) {
			case 0: 
				this.View.BackgroundColor = UIColor.White;
				this.toolBar.BarTintColor = UIColor.White;
				break;
			case 1:
				this.View.BackgroundColor = UIColor.Red;
				this.toolBar.BarTintColor = UIColor.Purple;
				break;
			case 2:
				this.View.BackgroundColor = UIColor.Blue;
				this.toolBar.BarTintColor = UIColor.Red;
				break;
			case 3:
				this.View.BackgroundColor = UIColor.Purple;
				this.toolBar.BarTintColor = UIColor.Blue;
				break;
			default:
				this.View.BackgroundColor = UIColor.White;
				this.toolBar.BarTintColor = UIColor.White;
				break;
			}
		}
	}
}

