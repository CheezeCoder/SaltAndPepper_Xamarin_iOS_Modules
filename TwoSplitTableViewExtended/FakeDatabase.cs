using System;
using UIKit;
using System.Collections.Generic;

namespace TwoSplitTableViewExtended 
{

	///<summary>
	///
	///</summary>
	public class FakeDatabase
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		private List<List<List<UIColor>>> bottomTableData; 
		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================

		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="TwoSplitTableViewExtended.FakeDatabase"/> class.
		/// </summary>
		public FakeDatabase ()
		{
			SeedFakeData ();
		}
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		//========================================================================================================================================
		//  PUBLIC METHODS
		//========================================================================================================================================
		public List<List<List<UIColor>>> getFakeData()
		{
			return bottomTableData;	
		}
		//========================================================================================================================================
		//  PRIVATE METHODS
		//========================================================================================================================================
		private void SeedFakeData()
		{
			List<List<List<UIColor>>> objectData = new List<List<List<UIColor>>> ();

			List<List<UIColor>> sectionAData = new List<List<UIColor>> ();
			List<List<UIColor>> sectionBData = new List<List<UIColor>> ();
			List<List<UIColor>> sectionCData = new List<List<UIColor>> ();

			objectData.Add (sectionAData);
			objectData.Add (sectionBData);
			objectData.Add (sectionCData);



			for (int x = 0; x < objectData.Count; x += 1) {
				List<UIColor> rowOneData   = new List<UIColor> ();
				List<UIColor> rowTwoData   = new List<UIColor> ();
				List<UIColor> rowThreeData = new List<UIColor> ();
				objectData [x].Add (rowOneData);
				objectData [x].Add (rowTwoData);
				objectData [x].Add (rowThreeData);
				for (int y = 0; y < 3; y += 1) {
					if (x == 0)
						objectData [x] [y].Add (UIColor.Brown);
					if (x == 1) {
						objectData [x] [y].Add (UIColor.Red);
						objectData [x] [y].Add (UIColor.Orange);
					}
					if (x == 2) {
						objectData [x] [y].Add (UIColor.Purple);
						objectData [x] [y].Add (UIColor.LightGray);
						objectData [x] [y].Add (UIColor.Green);
					}
				}
			}


			bottomTableData = objectData;


//			bottomTableData = new List<TableViewSection> ();
//			for (int x = 0; x < 3; x += 1) {
//				bottomTableData.Add (new TableViewSection (TableViewSectionType.AllTypes[x]));
//				for (int y = 0; y < 3; y += 1) {
//					TableViewRow row = new TableViewRow (TableViewRowType.AllTypes[x]);
//					bottomTableData [x].rows.Add (row);
//				}
//			}
		}
	}
}