using System;
using UIKit;

namespace TabbedNavigtionControllers
{
	/// <summary>
	/// The First Tab in our UITabBarController Application.  Bookmarks.
	/// </summary>
	public class TabOneNavController : UINavigationController
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		/// <summary>
		/// An empty UINavigation servers no purpose for this example so we create a UIViewController to populate the 
		/// UINavigationController with.
		/// </summary>
		private readonly UIViewController vC = new UIViewController ();
		/// <summary>
		/// The title to set the UINavigationItem in the UINavigationBar with.
		/// </summary>
		private readonly string tabTitle = "Bookmarks";
		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="TabbedNavigtionControllers.TabOneNavController"/> class. 
		/// We must instanciate the UITabBarItem for this UINavigationController here so that when we go to 
		/// set the initial SelectedIndex of the UITabBarController it exists.
		/// </summary>
		public TabOneNavController ()
		{
			this.TabBarItem = new UITabBarItem (UITabBarSystemItem.Bookmarks, 0);
		}

		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		/// <summary>
		/// Set the title of the UIViewController which will set our UINavigationItem title for the UINavigatioBar. Set the background color
		/// to showcase the switching of tabs and set our UIViewControllers frame.  Finally Add the UIViewController to the UINavigationController
		/// using the SetViewControllers method.
		/// </summary>
		public override void ViewDidLoad ()
		{
			this.vC.Title = this.tabTitle;
			this.View.BackgroundColor 	= UIColor.Blue;
			this.vC.View.Frame 			= this.View.Bounds;
			this.SetViewControllers(new UIViewController[]{vC}, true);
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

