using System;
using UIKit;
using System.Collections.Generic;

namespace TabbedNavigtionControllers
{
	/// <summary>
	/// Our Subclassed UITabBarController For
	/// </summary>
	public class TabController : UITabBarController
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="TabbedNavigtionControllers.TabController"/> class.
		/// </summary>
		public TabController ()
		{
			init ();
		}

		/// <summary>
		/// Initiates the our subclassed NavigationControllers for each tab of the tabbed application.  We create a list to hold
		/// all of ou UINavigationController cast to UIViewControllers as a UITabBarController expects UIViewControllers to 
		/// represent its tabbed views.  We then run .ToArray() to submit the list in the correct form and set our selected
		/// index of the UITabController to the first UINavigationController.
		/// </summary>
		private void init()
		{
			var one 	= new TabOneNavController ();
			var two 	= new TabTwoNavController ();
			var three 	= new TabThreeNavController ();

			var tabControllers 		= new List<UIViewController> ();

			tabControllers.Add (one);
			tabControllers.Add (two);
			tabControllers.Add (three);

			ViewControllers 		= tabControllers.ToArray ();
			SelectedViewController 	= one;
		}
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		//========================================================================================================================================
		//  PUBLIC METHODS
		//========================================================================================================================================
		//========================================================================================================================================
		//  PRIVATE METHODS
		//========================================================================================================================================
	}
}

