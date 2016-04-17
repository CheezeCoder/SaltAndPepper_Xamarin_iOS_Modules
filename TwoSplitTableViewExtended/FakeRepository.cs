using System;
using UIKit;
using System.Collections.Generic;
using System.Linq;

namespace TwoSplitTableViewExtended 
{
	/// <summary>
	/// A class to help seed data into our fake database repository.  We use this class to iniate both how certain table views will look as well as their
	/// state date.
	/// </summary>
	public class FakeRepositorySeederHelper
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		/// <summary>
		/// The number of color rows in the color row table view source.  This is specifically used to help seed the database with the correct
		/// amount of rows for our Color Rows.
		/// </summary>
		private readonly int numColorRows = 9;
		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="TwoSplitTableViewExtended.FakeRepositorySeederHelper"/> class.
		/// </summary>
		public FakeRepositorySeederHelper ()
		{
			
		}
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		//========================================================================================================================================
		//  PUBLIC METHODS
		//========================================================================================================================================
		/// <summary>
		/// Inits the bottom table structure.  We create a list of sections with rows, where each row has a certain amount of labels with color states.  Each of the rows
		/// uses a Cell class declared in UITableViewCell where it uses the data here to construct itself.  This way we have a structure of table secionts and rows
		/// ready for use in the TableViewDataSource that helps us build our TableView.  In this case we create 9 cells where there 3 sections and 3 cells in each section.
		/// Thus we have one list of 3 TableViewSections and where each of those TableViewSections have a list of 3 Cells.  
		/// </summary>
		/// <returns>The bottom table view structure.</returns>
		public List<TableViewSection> initBottomTableStructure()
		{
			var sections 	= new List<TableViewSection>();
			var rows 	= new List<TableViewRow> ();
			var Design 	= new CellVisualData ();

			rows.Add (new CellA (new List<UIColor>(){Design.CellA.LabelA.StateOneColor, Design.CellA.LabelA.StateTwoColor}));
			rows.Add (new CellA (new List<UIColor>(){Design.CellA.LabelA.StateOneColor, Design.CellA.LabelA.StateTwoColor}));
			rows.Add (new CellA (new List<UIColor>(){Design.CellA.LabelA.StateOneColor, Design.CellA.LabelA.StateTwoColor}));
			rows.Add (new CellB (new List<UIColor>(){Design.CellB.LabelA.StateOneColor, Design.CellB.LabelB.StateOneColor, Design.CellB.LabelA.StateTwoColor, Design.CellB.LabelB.StateTwoColor}));
			rows.Add (new CellB (new List<UIColor>(){Design.CellB.LabelA.StateOneColor, Design.CellB.LabelB.StateOneColor, Design.CellB.LabelA.StateTwoColor, Design.CellB.LabelB.StateTwoColor}));
			rows.Add (new CellB (new List<UIColor>(){Design.CellB.LabelA.StateOneColor, Design.CellB.LabelB.StateOneColor, Design.CellB.LabelA.StateTwoColor, Design.CellB.LabelB.StateTwoColor}));
			rows.Add (new CellC (new List<UIColor>(){Design.CellC.LabelA.StateOneColor, Design.CellC.LabelB.StateOneColor, Design.CellC.LabelC.StateOneColor, Design.CellC.LabelA.StateTwoColor, Design.CellC.LabelB.StateTwoColor, Design.CellC.LabelC.StateTwoColor}));
			rows.Add (new CellC (new List<UIColor>(){Design.CellC.LabelA.StateOneColor, Design.CellC.LabelB.StateOneColor, Design.CellC.LabelC.StateOneColor, Design.CellC.LabelA.StateTwoColor, Design.CellC.LabelB.StateTwoColor, Design.CellC.LabelC.StateTwoColor}));
			rows.Add (new CellC (new List<UIColor>(){Design.CellC.LabelA.StateOneColor, Design.CellC.LabelB.StateOneColor, Design.CellC.LabelC.StateOneColor, Design.CellC.LabelA.StateTwoColor, Design.CellC.LabelB.StateTwoColor, Design.CellC.LabelC.StateTwoColor}));

			for (int x = 0; x < 3; x += 1) {
				sections.Add (new TableViewSection (TableViewSectionType.AllTypes[x]));
				for (int y = 0; y < 3; y += 1) {
					sections [x].rows.Add (rows[y + (x*3)]);
				}
			}

			return sections;
		}

		/// <summary>
		/// Seeds our so called database with state data.  We default all of the color rows states to true in this case
		/// which means that all of our color rows on the color row table view are in their default state.
		/// </summary>
		/// <returns>The fake color rows context.</returns>
		public List<List<bool>> initFakeColorRowsContext()
		{
			var context = new List<List<bool>> ();

			for (int x = 0; x < numColorRows; x++) {
				context.Add (new List<bool> ());
				for (int i = 0; i < 3; i++) {
					context[x].Add (true);
				}	
			}

			return context;
		}

		/// <summary>
		/// Inits the fake object list context.  Sets the so called database for our object list to 5 strings.  This way 
		/// when the user selects the plus button in the top tabe view cell this is the data that is given to the bottom
		/// table view source for the object list view.
		/// </summary>
		/// <returns>The fake object list context.</returns>
		public List<string> initFakeObjectListContext()
		{
			return new List<string> () {
				"Alternate Object One",
				"Alternate Object Two",
				"Alternate Object Three",
				"Alternate Object Four",
				"Alternate Object Five"
			};
		}
		//========================================================================================================================================
		//  PRIVATE METHODS
		//========================================================================================================================================

	}

	///<summary>
	/// The fake repository for our Object List.  This class attempts to simulate a database context with itself being the repository for that 
	/// database.  It is used to get the data for the object list view for the bottom table view.
	///</summary>
	public class FakeObjectListRepository
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		/// <summary>
		/// Fake context for our Object list.
		/// </summary>
		private readonly List<string> simulatedDBContext; 
		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================

		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="TwoSplitTableViewExtended.FakeObjectListRepository"/> class.
		/// </summary>
		public FakeObjectListRepository (List<string> fakeContext)
		{
			simulatedDBContext = fakeContext;
		}
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		//========================================================================================================================================
		//  PUBLIC METHODS
		//========================================================================================================================================
		/// <summary>
		/// Returns all of the objects in our fake context.
		/// </summary>
		public List<string> All()
		{
			return simulatedDBContext;	
		}
			
		//========================================================================================================================================
		//  PRIVATE METHODS
		//========================================================================================================================================

	}


	///<summary>
	/// The fake repository for our Color row states.  This class attempts to simulate a database context with itself being the repository for that 
	/// database.  It is used to get the state data for the color rows view for the bottom table view.
	///</summary>
	public class FakeColorRowRepository
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		/// <summary>
		/// Fake context for our color row states.
		/// </summary>
		private readonly List<List<bool>> simulatedDBContext; 
		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================

		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="TwoSplitTableViewExtended.FakeColorRowRepository"/> class.
		/// </summary>
		public FakeColorRowRepository (List<List<bool>> fakeContext)
		{
			simulatedDBContext = fakeContext;
		}
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		//========================================================================================================================================
		//  PUBLIC METHODS
		//========================================================================================================================================
		/// <summary>
		/// Returns all of the objects in our fake context.
		/// </summary>
		public List<List<bool>> All()
		{
			return simulatedDBContext;	
		}

		/// <summary>
		/// Updates the state of the color row by switching the boolean.  True is the default state and false is the selected state.
		/// Here we just make sure the section and row index provided exist and then flip the boolean at that location in the list.
		/// </summary>
		/// <param name="rowNum">Row number.</param>
		/// <param name="section">Section.</param>
		public void updateRow(int rowNum, int section)
		{
			if (section < simulatedDBContext.Count) {
				if (rowNum < simulatedDBContext[section].Count) {
					simulatedDBContext [section] [rowNum] = !(simulatedDBContext [section] [rowNum]);
				}
			}
		}
		//========================================================================================================================================
		//  PRIVATE METHODS
		//========================================================================================================================================

	}
}