using System;
using UIKit;

namespace CustomOptionsPage 
{
	///<summary>
	/// Our Navigation Controller to hand the navigation between our two UIViewControllers.
	///</summary>
	public class NavigationController : UINavigationController
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		/// <summary>
		/// The UIViewController that controls our Content.
		/// </summary>
		private ContentViewController cVC;
		/// <summary>
		/// The UIViewController that controls our Options.
		/// </summary>
		private OptionsViewController oVC;
		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="CustomOptionsPage.NavigationController"/> class.
		/// </summary>
		public NavigationController ()
		{
			cVC = new ContentViewController();
			oVC = new OptionsViewController();


		}
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		/// <summary>
		/// Sets our root view controller aka the first UIViewController out of our 2 UIViewControllers to show.  We then subscribe to 
		/// the content UIViewControllers buttonSelected event to know if a user clicks on the options button there.  The delegate
		/// for this subscription is therefore to push our Options View Controller so the user can see the options they have.
		/// We then subscribe to the options choice made event.  This way when a user selects an options we use OptionsViewController's
		/// API (aka its exposed choice property) and update our ContentViewController's data (aka its exposed choice property). Note that
		/// as we will never need to change the choice property of OptionsViewController outside of its implementation the property is readonly.
		/// We then add a PopViewController to the delegate for the choice made event in UIOptionsController.
		/// </summary>
		public override void ViewDidLoad()
		{
			SetViewControllers(new UIViewController[]{ cVC }, true);
			cVC.buttonSelected += (object sender, EventArgs e) => this.PushViewController(this.oVC, true);
			oVC.choiceMade += (object sender, EventArgs e) =>
			{
				cVC.updateContent(oVC.choice);
				this.PopViewController(true);
			};

			base.ViewDidLoad();
		}
		//========================================================================================================================================
		//  PUBLIC METHODS
		//========================================================================================================================================
		//========================================================================================================================================
		//  PRIVATE METHODS
		//========================================================================================================================================

	}
}