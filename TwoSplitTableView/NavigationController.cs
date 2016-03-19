using System;
using UIKit;

namespace TwoSplitTableView 
{
	///<summary>
	/// Navigation Controller controlls the ViewControllers which in this case there is only one.  So all we need to do is initiate the 
	/// ViewController class to this navigation controller's view controler stack.
	///</summary>
	public class NavigationController : UINavigationController
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		private readonly ViewController viewController;
		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="TwoSplitTableView.NavigationController"/> class.
		/// </summary>
		public NavigationController ()
		{
			viewController = new ViewController ();
		}
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		/// <summary>
		/// Adds the viewController as the main controller for the navigation controller.  
		/// controllers view stack. 
		/// </summary>
		public override void ViewDidLoad ()
		{
			SetViewControllers (new UIViewController[]{ viewController }, true);


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