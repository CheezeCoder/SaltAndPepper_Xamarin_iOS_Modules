using System;
using UIKit;
using System.Collections.Generic;
using System.Globalization;

namespace TwoSplitTableViewExtended 
{
	public struct TableViewRowType{
		public static TableViewRowType A = new TableViewRowType ("cellTypeA", "typeA");
		public static TableViewRowType B = new TableViewRowType ("cellTypeB", "typeB");
		public static TableViewRowType C = new TableViewRowType ("cellTypeC", "typeC");

		public static List<TableViewRowType> AllTypes = new List<TableViewRowType>(){A, B, C};

		private TableViewRowType (string id, string key)
		{
			ReuseID = id;
			Key = key;
		}

		public string ReuseID { get; set; }
		public string Key { get; set; }
	}

//	public class TableViewRowType{
//
//		public static TableViewRowType A = new TableViewRowType ("cellTypeA", "typeA");
//		public static TableViewRowType B = new TableViewRowType ("cellTypeB", "typeB");
//		public static TableViewRowType C = new TableViewRowType ("cellTypeC", "typeC");
//
//		private TableViewRowType (string id, string key)
//		{
//			ReuseID = id;
//			Key = key;
//		}
//
//		public string ReuseID { get; set; }
//		public string Key { get; set; }
//	}

	public class TableViewSectionType{
		public static TableViewSectionType A = new TableViewSectionType("Setion A", "sectionTypeA");
		public static TableViewSectionType B = new TableViewSectionType("Setion B", "sectionTypeB");
		public static TableViewSectionType C = new TableViewSectionType("Setion C", "sectionTypeC");

		public static List<TableViewSectionType> AllTypes = new List<TableViewSectionType>(){A, B, C};

		private TableViewSectionType(string title, string key)
		{
			Key = key;
			Title = title;
		}

		public string Key {get; set;}
		public string Title{get; set;}
	}


	public struct TableViewSection {
		public TableViewSectionType type;
		public List<TableViewRow> rows;

		public TableViewSection(TableViewSectionType t)
		{
			type = t;
			rows = new List<TableViewRow> ();
		}
	}

	public abstract class TableViewRow : UITableViewCell
	{
		private UITableViewCell cell;
		private TableViewRowType type;

		public TableViewRow(TableViewRowType type)
		{
			this.type = type;
			ContentView.Frame = DefaultiOSDimensions.CellFrame ();
		}

		public TableViewRowType Type{
			get{return type;}
		}

		public UITableViewCell Cell {
			get { return cell; }
			protected set{
				cell = value;
			}
		}

		public abstract void SetColor(UIColor c1, UIColor c2 = null, UIColor c3 = null);
	}



	/// <summary>
	/// Delgate for our cell interaction.  Allows the string contents of the selected cell to be passed to a receiving 
	/// method.  In this case the parent View Controller for the Table View this source belongs to.  
	/// </summary>
	public delegate void cellContentsHandler (string contents);
	///<summary>
	/// Our Source class for the bottom table view.
	///</summary>
	public class TableViewSourceBottom : UITableViewSource
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		/// <summary>
		/// The data.
		/// </summary>
		private readonly List<TableViewSection> tableData;
		private List<List<List<UIColor>>> data;
		/// <summary>
		/// Bottom table view cell unique identifier.
		/// </summary>
		private const string bottomCellIdentifier = "bottomDataCell";
		/// <summary>
		/// Header title for our group of data.
		/// </summary>
		private const string sectionTitle = "Data Objects";
		/// <summary>
		/// Occurs when cell is pressed.
		/// </summary>
		public event cellContentsHandler cellDidPress;

		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="TwoSplitTableViewExtended.TableViewSourceBottom"/> class. Sets our data.
		/// </summary>
		public TableViewSourceBottom (List<TableViewSection> tData, List<List<List<UIColor>>> data)
		{	
			this.tableData = tData;
			this.data = data;
		}
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		#region implemented abstract members of UITableViewSource

		/// <summary>
		/// Nothing to special here. Sets the data from our data source to each cell value as a label.
		/// </summary>
		/// <returns>The cell.</returns>
		/// <param name="tableView">Table view.</param>
		/// <param name="indexPath">Index path.</param>
		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (tableData [indexPath.Section].rows [indexPath.Row].Type.ReuseID) ?? tableData [indexPath.Section].rows [indexPath.Row].Cell;

			var c1 = data [indexPath.Section] [indexPath.Row] [0];
			var c2 = data [indexPath.Section] [indexPath.Row].Count > 1 ? data [indexPath.Section] [indexPath.Row] [1] : null;
			var c3 = data [indexPath.Section] [indexPath.Row].Count > 2 ? data [indexPath.Section] [indexPath.Row] [2] : null;

			if (cell is TableViewRow) {
				(cell as TableViewRow).SetColor (c1, c2, c3);
			}

			return cell;
		}

		public override nint NumberOfSections (UITableView tableView)
		{
			return tableData.Count;
		}

		/// <summary>
		/// Rows the in section.
		/// </summary>
		/// <returns>The in section.</returns>
		/// <param name="tableview">Tableview.</param>
		/// <param name="section">Section.</param>
		public override nint RowsInSection (UITableView tableview, nint section)
		{
			int s = (int)section;
			return tableData[s].rows.Count;
		}

		/// <summary>
		/// Title for header.
		/// </summary>
		/// <returns>The for header.</returns>
		/// <param name="tableView">Table view.</param>
		/// <param name="section">Section.</param>
		public override string TitleForHeader (UITableView tableView, nint section)
		{
			return tableData[(int)section].type.Title;
		}

		/// <summary>
		/// This will check to make sure our event has subscribers and if so fires our event 
		/// with whatever text is in our targeted table cell.  Deselects the row.
		/// </summary>
		/// <param name="tableView">Table view.</param>
		/// <param name="indexPath">Index path.</param>
		public override void RowSelected (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			if (cellDidPress != null) {
				//cellDidPress (data[indexPath.Section].rows[indexPath.Row]);
			}

			tableView.DeselectRow (indexPath, true);
		}

		#endregion
		//========================================================================================================================================
		//  PUBLIC METHODS
		//========================================================================================================================================
		//========================================================================================================================================
		//  PRIVATE METHODS
		//========================================================================================================================================
	}
}