﻿using System;
using UIKit;
using System.Collections.Generic;

namespace TableViewInViewController 
{
	///<summary>
	///
	///</summary>
	public class ViewController : UIViewController
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		private readonly UITableView tableView;
		private readonly List<string> dataSource;
		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="TableViewInViewController.ViewController"/> class.
		/// </summary>
		public ViewController ()
		{
			tableView 		= new UITableView ();
			dataSource 		= new List<string> (){ "Data One", "Data Two", "Data Three" };
			tableView.Source 	= new TableViewSource (dataSource);

		}
			
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		public override void ViewDidLoad ()
		{
			Title = "Table View in View Controller";
			View.BackgroundColor = UIColor.White;
			View.AddSubview (tableView);
			base.ViewDidLoad ();
		}

		public override void ViewDidLayoutSubviews ()
		{
			tableView.Frame = View.Bounds;
			base.ViewDidLayoutSubviews ();
		}
		//========================================================================================================================================
		//  PUBLIC METHODS
		//========================================================================================================================================
		//========================================================================================================================================
		//  PRIVATE METHODS
		//========================================================================================================================================
	}
}