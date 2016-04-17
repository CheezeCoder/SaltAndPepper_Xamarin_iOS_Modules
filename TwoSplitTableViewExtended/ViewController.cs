using System;
using System.Collections.Generic;
using UIKit;

namespace TwoSplitTableViewExtended 
{
	///<summary>
	/// Our view controller controlling our two table views and facilitating the data passed between them.
	///</summary>
	public class ViewController : UIViewController
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		/// <summary>
		/// Our bottom table view.  This table view houses our data and is the interactive table in our example.
		/// The cells chosen in this table will directly affect the top table view if showing the object list otherwise
		/// the cells will be color coded cells.  The color cells can be selected or deselected.  This selection state
		/// helps to show how to preserve the color row states when switching between this table views sources.
		/// </summary>
		private readonly UITableView BottomTableView;
		/// <summary>
		/// Our top table View.  This view is our dependant table view in our example and will react and display 
		/// information accordingly based on interaction from the bottom table View.
		/// </summary>
		private readonly UITableView TopTableView;
		/// <summary>
		/// This is the UITableViewSource class for the top table.
		/// </summary>
		private readonly TableViewSourceTop TopTableSource;
		/// <summary>
		/// This is the UITableViewSource class for the bottom table that shows the state enabled data aka color rows..
		/// </summary>
		private readonly TableViewSourceColorCells BottomTableColorCellSource;
		/// <summary>
		/// This is the UITableViewSource class for the bottom table that shows a list of selectable object names to be displayed in the top table view.
		/// </summary>
		private readonly TableViewSourceSelectableObjects BottomTableSelectableObjectsSource;
		/// <summary>
		/// Our helper class to help simulate a repository database pattern without acutally building it as it is overkill for this example.
		/// </summary>
		private readonly FakeRepositorySeederHelper repoHelper;
		/// <summary>
		/// The title for our Navigation Controller / App.
		/// </summary>
		private readonly string title 			= "Two Split Table View";
		/// <summary>
		/// Default height of a table cell (43 pts) according to http://iosdesign.ivomynttinen.com/ + 1 for the seperator line.
		/// </summary>
		private readonly float defaultCellHeight 	= 44;
		/// <summary>
		/// The simulated repository for our color row states.
		/// </summary>
		private FakeColorRowRepository fakeColorRowRepo;
		/// <summary>
		/// The simulated repository of our data object strings.
		/// </summary>
		private FakeObjectListRepository fakeObjectListRepo;

		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="TwoSplitTableViewExtended.ViewController"/> class.  Sets up our repo helper to help initialize
		/// data tha might normally exists or be setup in a real database situation.  For the purposes of this example we just use some hardcoded data
		/// and helper methods to simualte a database and repo.  The fake repositories are then initalized and used to help inject our sources with the
		/// correct data.  Once the table sources are instanciated we create our table views.
		/// </summary>
		public ViewController () 
		{
//			dataSourceOne = new List<string> () {
//				"Data Object One",
//				"Data Object Two",
//				"Data Object Three",
//				"Data Object Four",
//				"Data Object Five"
//			};

			repoHelper 				= new FakeRepositorySeederHelper ();

			fakeColorRowRepo 			= new FakeColorRowRepository (repoHelper.initFakeColorRowsContext());
			fakeObjectListRepo 			= new FakeObjectListRepository (repoHelper.initFakeObjectListContext());
				
			TopTableSource 				= new TableViewSourceTop ();
			BottomTableColorCellSource 		= new TableViewSourceColorCells (repoHelper.initBottomTableStructure (), fakeColorRowRepo);
			BottomTableSelectableObjectsSource 	= new TableViewSourceSelectableObjects (fakeObjectListRepo);

			TopTableView 				= new UITableView ();
			BottomTableView 			= new UITableView (CoreGraphics.CGRect.Empty, UITableViewStyle.Grouped);

		}
			
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		/// <summary>
		/// Several important declerations are done here to help setup our views correctly.  We set our sources and then subscribe
		/// our helper methods to the events in different table source's API. This will allow us to pass data between the two table
		/// sources as well as help preserve our data color cells states when moving between sources.  Then add the views.
		/// </summary>
		public override void ViewDidLoad ()
		{
			BottomTableView.Source 				= BottomTableColorCellSource;
			TopTableView.Source 				= TopTableSource;

			BottomTableColorCellSource.colorCellDidPress 	+= updateBottomTableCellState;
			TopTableSource.willSwitchBottomTableData 	+= updateBottomTableSource;
			BottomTableSelectableObjectsSource.cellDidPress += updateTopTable;


			View.AddSubview (TopTableView);
			View.AddSubview (BottomTableView);

			base.ViewDidLoad ();
		}

		/// <summary>
		/// Sets the properties for our views.  We need AutomaticallyAdjustsScrollViewInsets to be turned off for our
		/// top table cell so that it loses its default insets.  This way it positions correctly for our calculations.
		/// We then need to set our top table view seperator and layout margin insets to zero so that the top table view 
		/// shows its seperator line all the way across instead of with the default padding such as the inner bottom table 
		/// view cells have. We also turn off the top table view scrolling so that the user can't accidently scroll it. This 
		/// allows it to simulate the behaviour one finds in the native iOS messages app when choosing a new contact.  Set
		/// our title for the view, our background colors for the view and table views and turn off our autoresizemasks
		/// so that we can declare our own layouts. Finally we call our private method to set up our constraints.
		/// </summary>
		public override void ViewDidLayoutSubviews ()
		{
			// Makes it so that the view of the tableView starts where the navbar ends.  Specific to a scroll view. 
			AutomaticallyAdjustsScrollViewInsets				= false;
			Title 								= title;
			View.BackgroundColor 						= UIColor.White;
			TopTableView.BackgroundColor 					= UIColor.White;
			BottomTableView.BackgroundColor 				= "EFEFF4".ToUIColor ();
			TopTableView.BackgroundColor 					= "CECED2".ToUIColor ();

			TopTableView.SeparatorStyle 					= UITableViewCellSeparatorStyle.SingleLine;
			TopTableView.SeparatorInset 					= UIEdgeInsets.Zero;
			TopTableView.LayoutMargins 					= UIEdgeInsets.Zero;

			TopTableView.ScrollEnabled 					= false;
			TopTableView.TranslatesAutoresizingMaskIntoConstraints		= false;
			BottomTableView.TranslatesAutoresizingMaskIntoConstraints 	= false;
			setViewConstraints ();

			base.ViewDidLayoutSubviews ();
		}
		//========================================================================================================================================
		//  PUBLIC METHODS
		//========================================================================================================================================
		//========================================================================================================================================
		//  PRIVATE METHODS
		//========================================================================================================================================
		/// <summary>
		/// Sets our constraints using the best thing to ever happen to auto layout: Anchors.  The code should be self
		/// explanitory.  As we want our views to stretch the full width and height of the screen we skip using margins
		/// except for the bottom view.  
		/// </summary>
		private void setViewConstraints(){

			var margins 		= View.LayoutMarginsGuide;

			TopTableView.TopAnchor.ConstraintEqualTo (TopLayoutGuide.GetBottomAnchor()).Active 	= true;
			TopTableView.HeightAnchor.ConstraintEqualTo (defaultCellHeight).Active 			= true;
			TopTableView.LeadingAnchor.ConstraintEqualTo (View.LeadingAnchor).Active 		= true;
			TopTableView.TrailingAnchor.ConstraintEqualTo (View.TrailingAnchor).Active 		= true;

			BottomTableView.TopAnchor.ConstraintEqualTo (TopTableView.BottomAnchor).Active 		= true;
			BottomTableView.BottomAnchor.ConstraintEqualTo (margins.BottomAnchor).Active 		= true;
			BottomTableView.LeadingAnchor.ConstraintEqualTo (View.LeadingAnchor).Active 		= true;
			BottomTableView.TrailingAnchor.ConstraintEqualTo (View.TrailingAnchor).Active 		= true;
		}




		/// <summary>
		/// Updates the repo of the users currently selected color cell states.
		/// We need to take care of this in the view controller as the display of the
		/// chosen color rows is controlled via the repository.  So if a user selects
		/// a cell we need to update the repository to reflect this choice and then reload
		/// the table view to visually reprsenent this choice.  This way we are sure we are 
		/// saving the state of the color rows as well as showing the users most up to date
		/// choices.
		/// </summary>
		/// <param name="row">Row.</param>
		/// <param name="section">Section.</param>
		private void updateBottomTableCellState(int row, int section)
		{
			fakeColorRowRepo.updateRow (row, section);
			BottomTableView.ReloadData ();
		}

		/// <summary>
		/// Event helper method facilitates switching the bottom table view source
		/// to a new source.  The user in this case would be in the color cell source
		/// view on the bottom table and so we need to switch out the bottom source to
		/// the objects source to allow the user to make a new data object selection.
		/// We do this and then reload the bottom table view data.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		private void updateBottomTableSource(Object sender, EventArgs args)
		{
			BottomTableView.Source = BottomTableSelectableObjectsSource;
			BottomTableView.ReloadData ();
		}

		/// <summary>
		/// Our helper method to facilitate data being passed from the bottom to the top table view source
		/// as well as switching the source for our bottom table.  This is called when the user has the
		/// Object list source active as the bottom table view source.  Thus we need to reset the bottom
		/// table view to the color rows as the user has succesfully made thier choice.  We update the top
		/// table view to represent the users choice and then we set our bottom table view back to the
		/// color cell source and reload both tables data to display them properly.
		/// </summary>
		/// <param name="contents">Contents.</param>
		private void  updateTopTable(string contents)
		{
			TopTableSource.updateField (contents);
			BottomTableView.Source = BottomTableColorCellSource;
			BottomTableView.ReloadData ();
			TopTableView.ReloadData ();

		}



	}
}