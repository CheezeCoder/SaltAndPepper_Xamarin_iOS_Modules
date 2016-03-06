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
		/// This view represents updates based on the input from the segmentController while in its 1st state.
		/// </summary>
		private readonly UIView firstView;
		/// <summary>
		/// This view represents updates based on the input from the segmentController while in its 2nd state.
		/// </summary>
		private readonly UIView secondView;
		/// <summary>
		/// The default height of the UIToolbar in pts.
		/// </summary>
		private readonly int defaultUIToolBarHeight 		= 29;
		/// <summary>
		/// The default height of the Navigaion bar in pts.
		/// </summary>
		private readonly int defaultNavigationBarHeight 	= 44;
		/// <summary>
		/// The default padding for most iOS default elements in pts.
		/// </summary>
		private readonly int iosDefaultPadding 			= 8;
		/// <summary>
		/// The default margin for most iOS default elemetns in pts.
		/// </summary>
		private readonly int iosDefaultMargin 			= 15;
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
		private readonly string contentViewTitleText 		= "Segment Controller Filtering";
		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		/// <summary>
		/// The api handler to alert any listeners that the "options" button has been pressed.
		/// </summary>
		public event EventHandler buttonSelected;
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="SegmentControllerFiltering.ToolBarView"/> class.
		/// </summary>
		public ViewController ()
		{
			toolBar 	= new UIToolbar ();
			segController 	= new SegmentControlSelectionView ();
			firstView 	= new UIView ();
			secondView 	= new UIView ();

		}
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		/// <summary>
		/// Add the UIToolBar to the view, add the UISegmentController to the UINavigationBar, set the controller title, add our two
		/// segment controller affected views to the controller view and set the view associated with the inactive segmentController state
		/// to hidden and subscribe a delegate to the event in our UISegmentController subclass.
		/// </summary>
		public override void ViewDidLoad ()
		{

			Title 		= contentViewTitleText;
			optionsButton 	= new UIBarButtonItem(optionsButtonText,UIBarButtonItemStyle.Plain, buttonSelected);
			NavigationItem.SetLeftBarButtonItem(optionsButton, true);

			View.AddSubviews (new UIView[]{ firstView, secondView });
			View.Add(toolBar);

			secondView.Hidden 		= true;
			segController.valueChanged 	+= changeBackgroundColor;
			toolBar.AddSubview (segController);
			base.ViewDidLoad ();
		}

		/// <summary>
		/// Set the frames for our subviews.  Since UIToolbar is not subclassed set its views frames as well. Our UISegmentController needs to be offset
		/// on the y axis by the height of the UINavigation bar and the StatusBarFrame so we set our segmentControllerBarYOffset to the sum of these 2 
		/// elements.  The UIToolbar is then offset with this offset and as we want some padding so that our UISegmentController is not right up against 
		/// the top of the UIToolbar we set the height of our UIToolbar to the sum of its default height and twice the defualt ios padding. For the 
		/// UISegmentController we set its width to the difference of its parent elements frame, the UIToolbar and twice the default ios Margin.  Its height 
		/// should be the default height of the UIToolbar which allows the UIToolbars padding height to take effect.  The center point of the 
		/// UISegmentController then needs to be set using half the width of its parent, UIToolbar and half the height of its parent, UIToolbar which 
		/// allows the UISegmentController to be centered both vertically and horizontally.  We then give our firstView the same size as the controller
		/// view and set our secondView to half the size of the controller and center it.  
		/// 
		/// 
		/// 
		/// Finally we set our Autoresizing masks to flexibleLeft and FlexibleRight Margins.
		/// </summary>
		public override void ViewDidLayoutSubviews ()
		{
			firstView.Frame  		= View.Bounds;
			secondView.Frame 		= new CoreGraphics.CGRect (0, 0, View.Bounds.Width / 2, View.Bounds.Height / 2);
			secondView.Center 		= View.Center;
			segmentControllerBarYoffset 	= (float)UIApplication.SharedApplication.StatusBarFrame.Height + defaultNavigationBarHeight;
			toolBar.Frame  			= new CoreGraphics.CGRect (0, segmentControllerBarYoffset, View.Bounds.Width, defaultUIToolBarHeight + (iosDefaultPadding*2));
			toolBar.AutoresizingMask 	= UIViewAutoresizing.FlexibleWidth;
			segController.Frame 		= new CoreGraphics.CGRect (0, 0, View.Bounds.Width - iosDefaultMargin * 2, defaultUIToolBarHeight);
			segController.Center 		= new CoreGraphics.CGPoint (toolBar.Frame.Size.Width / 2, toolBar.Frame.Size.Height / 2);
			segController.AutoresizingMask 	= UIViewAutoresizing.FlexibleLeftMargin | UIViewAutoresizing.FlexibleRightMargin;
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
			secondView.Hidden 	= choice;
			firstView.Hidden 	= !choice;
			segController.updateSegmentController (choice);
		}
		//========================================================================================================================================
		//  PRIVATE METHODS
		//========================================================================================================================================


		/// <summary>
		/// This is our delegate to demonstrate the use of subscribing to the UISegmentControllers events.  This is slightly updated from
		/// how it looks in CustomSegmentController.  Here we update the secondView background as well as the first.  Because even in both 
		/// states the SegmentControllers will return the same selected index for each segments respective position we can resuse
		/// the case.  In a more complex situation it would be best to maintain some sort of private state and then we can handle each
		/// index accordingly.  For now as the secondView or firstView is hidden when the other is visible this method of updating
		/// both view's backgrounds at the same time works. 
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		private void changeBackgroundColor(object sender, EventArgs args)
		{
			switch ((sender as UISegmentedControl).SelectedSegment) {
			case 0: 
				firstView.BackgroundColor 	= UIColor.White;
				secondView.BackgroundColor 	= UIColor.Yellow;
				toolBar.BarTintColor 		= UIColor.White;
				break;
			case 1:
				firstView.BackgroundColor 	= UIColor.Red;
				secondView.BackgroundColor 	= UIColor.Red;
				toolBar.BarTintColor 		= UIColor.Purple;
				break;
			case 2:
				firstView.BackgroundColor 	= UIColor.Blue;
				secondView.BackgroundColor 	= UIColor.Blue;
				toolBar.BarTintColor 		= UIColor.Red;
				break;
			case 3:
				firstView.BackgroundColor 	= UIColor.Purple;
				secondView.BackgroundColor 	= UIColor.Purple;
				toolBar.BarTintColor 		= UIColor.Blue;
				break;
			default:
				firstView.BackgroundColor 	= UIColor.White;
				secondView.BackgroundColor 	= UIColor.Yellow;
				toolBar.BarTintColor 		= UIColor.White;
				break;
			}
		}
	}
}

