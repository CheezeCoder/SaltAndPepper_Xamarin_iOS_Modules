using System;
using UIKit;

namespace SegmentControllerFiltering 
{
	///<summary>
	/// Navigation Controller controlls the two Views.  The two views are a culmination of the Custom Options Page Moudle as well as the
	/// Custom Segment Controller Module.  By combining these two modules and improving upon them we are able to demonstrate how
	/// a custom segment controller can be updated by an option page and how the segment controller can control the display of 
	/// different types of information based on what sections it is showing and the state of the segment controller.
	///</summary>
	public class NavigationController : UINavigationController
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		/// <summary>
		/// The main view controller showing the results of the segment controllers selected index.
		/// </summary>
		private readonly ViewController viewController;
		/// <summary>
		/// View controller to show the options available for the user.  This particular view controller allows the user
		/// to decide on what segments will show in the segement controller in the ViewController.
		/// </summary>
		private readonly OptionsViewController optionsController;
		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="SegmentControllerFiltering.NavigationController"/> class.
		/// </summary>
		public NavigationController ()
		{
			viewController 		= new ViewController ();
			optionsController 	= new OptionsViewController ();
		}
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		/// <summary>
		/// Adds the viewController as the main controller for the navigation controller.  Then we subscribe to each of our view controllers
		/// events using their exposed API's (aka events).  We listen for the options button being pressed in the viewController and push to our
		/// options page if they press the options page.  We also listen for a press of one of the options from the options page and if so update
		/// our viewControllers choice control using viewController exposed API (aka its updateContent method) by passing in a paramater we retrieve
		/// from optionControllers expoesed API (aka the public readonly choice property).  Finally we pop the options page controller from the navigations
		/// controllers view stack. 
		/// </summary>
		public override void ViewDidLoad ()
		{
			SetViewControllers(new UIViewController[]{ viewController  }, true);
			viewController.buttonSelected 	+= (object sender, EventArgs e) => PushViewController(optionsController, true);
			optionsController.choiceMade 	+= (object sender, EventArgs e) =>
			{
				viewController.updateContent(optionsController.choice);
				PopViewController(true);
			};
			base.ViewDidLoad ();
		}
		//========================================================================================================================================
		//  PUBLIC METHODS
		//========================================================================================================================================
		//========================================================================================================================================
		//  PRIVATE METHODS
		//========================================================================================================================================
	}
}