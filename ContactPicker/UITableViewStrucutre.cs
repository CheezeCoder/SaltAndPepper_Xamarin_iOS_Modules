using System;
using System.Collections.Generic;
using UIKit;

namespace ContactPicker
{
	/// <summary>
	/// Struct representing the possible type of row that our Bottom Table View can have while using the ColorCellSource.
	/// Functions as a suedo smart enum.
	/// </summary>
	public struct TableViewRowType{
		/// <summary>
		/// Row of type A.  For Type A cell.
		/// </summary>
		public static TableViewRowType A = new TableViewRowType ("cellTypeA", "typeA");
		/// <summary>
		/// Row of type B.  For Type B cell.
		/// </summary>
		public static TableViewRowType B = new TableViewRowType ("cellTypeB", "typeB");
		/// <summary>
		/// Row of type C  For Type C cell.
		/// </summary>
		public static TableViewRowType C = new TableViewRowType ("cellTypeC", "typeC");

		/// <summary>
		/// Initializes a new instance of the <see cref="TwoSplitTableViewExtended.TableViewRowType"/> struct.
		/// </summary>
		/// <param name="id">Identifier.</param>
		/// <param name="key">Key.</param>
		private TableViewRowType (string id, string key)
		{
			ReuseID = id;
			Key = key;
		}

		/// <summary>
		/// Holds the reuse identifier for cell dequeing for a given cell type.
		/// </summary>
		/// <value>The reuse I.</value>
		public string ReuseID { get; set; }
		/// <summary>
		/// Key for this row.
		/// </summary>
		/// <value>The key.</value>
		public string Key { get; set; }
	}

	/// <summary>
	/// Struct representing the possible type of section that our Bottom Table View can have while using the ColorCellSource.
	/// Functions as a suedo smart enum.
	/// </summary>
	public struct TableViewSectionType{
		public static TableViewSectionType A = new TableViewSectionType("Setion A");
		public static TableViewSectionType B = new TableViewSectionType("Setion B");
		public static TableViewSectionType C = new TableViewSectionType("Setion C");

		/// <summary>
		/// Returns a list of all types of Sections types for this smart enum.  Useful for 
		/// when seeding data in our RepoHelper class.
		/// </summary>
		public static List<TableViewSectionType> AllTypes = new List<TableViewSectionType>(){A, B, C};

		/// <summary>
		/// Initializes a new instance of the <see cref="TwoSplitTableViewExtended.TableViewSectionType"/> struct.
		/// </summary>
		/// <param name="title">Title.</param>
		private TableViewSectionType(string title)
		{
			Title = title;
		}

		/// <summary>
		/// Holds the title for the set section of a section Type.
		/// </summary>
		/// <value>The title.</value>
		public string Title{get; set;}
	}

	/// <summary>
	/// Represents a TableViewSection for our Table Bottom View while using the ColorCellSource.
	/// </summary>
	public struct TableViewSection {
		/// <summary>
		/// The Section type of this section.
		/// </summary>
		public TableViewSectionType type;
		/// <summary>
		/// A list of all rows in this section reprsented through TableViewRows.
		/// </summary>
		public List<TableViewRow> rows;

		/// <summary>
		/// Initializes a new instance of the <see cref="TwoSplitTableViewExtended.TableViewSection"/> struct.
		/// </summary>
		/// <param name="t">T.</param>
		public TableViewSection(TableViewSectionType t)
		{
			type = t;
			rows = new List<TableViewRow> ();
		}
	}

	/// <summary>
	/// Base class for all of our ColorCellSource table cells.  This allows us to set the color
	/// properly and add methods to update the state of the cell and allow for easier dequeing. 
	/// </summary>
	public abstract class TableViewRow : UITableViewCell
	{
		/// <summary>
		/// The acutal UITableViewCell this abstract class represents.  Needed for instanciated and or dequeing new
		/// cells if one is not available when the GetCell method is called.
		/// </summary>
		private UITableViewCell cell;
		/// <summary>
		/// The type of row this is.
		/// </summary>
		private TableViewRowType type;
		/// <summary>
		/// The color options for the labels of this specific cell.
		/// </summary>
		private List<UIColor> options;
		/// <summary>
		/// The runtime state of the cell represented by a boolean.  True for default.  False for active.
		/// </summary>
		protected bool state;
		/// <summary>
		/// A list of this cells non active label colors.
		/// </summary>
		protected List<UIColor> primaryStateColors;
		/// <summary>
		/// A list of this cells active lable colors.
		/// </summary>
		protected List<UIColor> secondaryStatColors;

		/// <summary>
		/// Initializes a new instance of the <see cref="TwoSplitTableViewExtended.TableViewRow"/> class.  Sets the type, and provides
		/// the color options for this cell.  Also provides the cells dimensions as well splits up the color otptions for the cells
		/// labels into the correct lists.
		/// </summary>
		/// <param name="options">Options.</param>
		/// <param name="type">Type.</param>
		public TableViewRow(List<UIColor> options, TableViewRowType type)
		{
			this.type 		= type;
			this.options 		= options;
			ContentView.Frame 	= DefaultiOSDimensions.CellFrame ();
			primaryStateColors 	= new List<UIColor> ();
			secondaryStatColors 	= new List<UIColor> ();
			for (var x = 0; x < options.Count / 2; x += 1) {
				primaryStateColors.Add (options [x]);
			}
			for (var x = options.Count / 2; x < options.Count; x += 1) {
				secondaryStatColors.Add (options [x]);
			}
		}

		/// <summary>
		/// Returns the type of this cell as determined by TableViewRowType.
		/// </summary>
		/// <value>The type.</value>
		public TableViewRowType Type{
			get{return type;}
		}

		/// <summary>
		/// Returns the actual instance of the UITableViewCell of this representation.
		/// </summary>
		/// <value>The cell.</value>
		public UITableViewCell Cell {
			get { return cell; }
			protected set{
				cell = value;
			}
		}

		/// <summary>
		/// Gets the color options for this cells label colors.
		/// </summary>
		/// <value>The options.</value>
		public List<UIColor> Options {
			get{ return options; }
		}

		/// <summary>
		/// Switchs the state of the cell to its opposite.
		/// </summary>
		public abstract void SwitchState();
		/// <summary>
		/// Sets the run time state of the cell.
		/// </summary>
		/// <param name="state">If set to <c>true</c> state.</param>
		public void SetState(bool state)
		{
			this.state = state;
		}
	}
}

