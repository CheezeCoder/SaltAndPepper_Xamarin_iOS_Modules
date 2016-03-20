﻿using System;
using UIKit;
using System.Collections.Generic;

namespace TwoSplitTableView 
{
	///<summary>
	///
	///</summary>
	public class DummyTableViewController : UITableViewController
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		private readonly List<string> dataSource;
		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="TwoSplitTableView.DummyTableViewController"/> class.
		/// </summary>
		public DummyTableViewController () : base(UITableViewStyle.Grouped)
		{
			dataSource = new List<string> () {
				"Data Object One",
				"Data Object Two",
				"Data Object Three",
				"Data Object Four",
				"Data Object Five"
			};

		}
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		public override void ViewDidLoad ()
		{
			TableView.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine;
			TableView.SeparatorColor = UIColor.Green;
			TableView.Source = new TableViewSourceBottom (dataSource);
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