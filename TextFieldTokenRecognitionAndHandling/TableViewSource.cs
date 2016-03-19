using System;
using UIKit;

namespace TextFieldTokenRecognitionAndHandling 
{
	///<summary>
	///
	///</summary>
	public class TableViewSource : UITableViewSource
	{
		//========================================================================================================================================
		//  PRIVATE CLASS PROPERTIES
		//========================================================================================================================================
		private readonly string cellIdentifier = "cell";
		//========================================================================================================================================
		//  PUBLIC CLASS PROPERTIES
		//========================================================================================================================================
		//========================================================================================================================================
		//  Constructor
		//========================================================================================================================================
		/// <summary>
		/// Initializes a new instance of the <see cref="TextFieldTokenRecognitionAndHandling.TableViewSource"/> class.
		/// </summary>
		public TableViewSource ()
		{
			
		}
		//========================================================================================================================================
		//  PUBLIC OVERRIDES
		//========================================================================================================================================
		#region implemented abstract members of UITableViewSource

		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (cellIdentifier);

			cell = cell ?? new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);


			var subTf = new UILabel ();
			var myString = "John Doe";
			subTf.Text = myString;
			subTf.TextColor = UIColor.Green;
			var w = subTf.Text.StringSize (subTf.Font).Width;
			subTf.Frame = new CoreGraphics.CGRect (0, 0, w, cell.Frame.Height);
			var uiview = new UIView (subTf.Frame);

			uiview.AddSubview (subTf);

			var tf = new CustomTextField (cell.Bounds);
			tf.LeftView = uiview;
			tf.LeftViewMode = UITextFieldViewMode.Always;



			cell.AddSubview (tf);








			var button = new UIButton (UIButtonType.ContactAdd);

			cell.AccessoryView = button;

			button.TouchDown += (object sender, EventArgs e) => {
				var newlabel = new UILabel ();
				newlabel.Text = "Mark Spencer";
				newlabel.Tag = 5;
				var w2 = newlabel.Text.StringSize (newlabel.Font).Width;
				newlabel.Frame = new CoreGraphics.CGRect (subTf.Frame.Right, 0, w, cell.Frame.Height);



				uiview.AddSubview (newlabel);
				uiview.Frame = new CoreGraphics.CGRect (uiview.Frame.X, uiview.Frame.Y, newlabel.Frame.Width + subTf.Frame.Width, uiview.Frame.Height);
				tf.LeftView.Frame = uiview.Frame;
			};


			tf.didDelete += (object sender, EventArgs e) => {
				foreach(UIView v in uiview)
				{
					if(v.Tag == 5)
					{
						v.RemoveFromSuperview();
						uiview.Frame = new CoreGraphics.CGRect(uiview.Frame.X, uiview.Frame.Y, uiview.Frame.Width - v.Frame.Width, uiview.Frame.Height);
						tf.LeftView.Frame = uiview.Frame;
					}
				}
			};


			Console.WriteLine (cell.AccessoryView.Frame.Width);
			Console.WriteLine (cell.Frame.Width);

			return cell;
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			throw new NotImplementedException ();
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