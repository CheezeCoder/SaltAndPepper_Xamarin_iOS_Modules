using System;
using UIKit;

namespace TwoSplitTableViewExtended 
{
	public static class DefaultiOSDimensions{
		public const int cellHeight = 44;
		public const int cellWidth = 320;
		public const int cellPadding = 15;

		public static CoreGraphics.CGRect CellFrame()
		{
			return new CoreGraphics.CGRect (0, 0, cellWidth, cellHeight);
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

	public class CellA : TableViewRow
	{
		public CellA() : base(TableViewRowType.A)
		{
			Cell = this;
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();

		}

		public override void SetColor (UIColor c1 , UIColor c2, UIColor c3)
		{
			ContentView.BackgroundColor = c1;
		}
	}

	public class CellB : TableViewRow
	{
		private UILabel labelA;
		private UILabel labelB;

		public CellB() : base(TableViewRowType.B)
		{
			Cell = this;
			labelA = new UILabel ();
			labelB = new UILabel ();
		}

		public override void LayoutSubviews ()
		{
			labelA.Frame = new CoreGraphics.CGRect (DefaultiOSDimensions.cellPadding, 0, (Frame.Width / 2) - (DefaultiOSDimensions.cellPadding * 1.5), Frame.Height);
			labelB.Frame = new CoreGraphics.CGRect(Frame.Width/2 + DefaultiOSDimensions.cellPadding/2, 0, (Frame.Width/2)-(DefaultiOSDimensions.cellPadding * 1.5), Frame.Height); 
			ContentView.AddSubviews (new UIView[]{ labelA, labelB });


			base.LayoutSubviews ();

		}

		public override void SetColor (UIColor c1 , UIColor c2, UIColor c3)
		{
			if (!Object.ReferenceEquals(c2, null)) {
				labelA.BackgroundColor = c1;
				labelB.BackgroundColor = c2;
			}
		}
	}

	public class CellC : TableViewRow
	{
		private UILabel labelA;
		private UILabel labelB;
		private UILabel labelC;
		public CellC() : base(TableViewRowType.C)
		{
			Cell = this;

			labelA = new UILabel();
			labelB = new UILabel();
			labelC = new UILabel();
		}

		public override void LayoutSubviews ()
		{
			

			const float totalMargins 	= DefaultiOSDimensions.cellPadding * 4;
			var labelWidth 			= (Frame.Width - totalMargins)/3;
			labelA.Frame = new  CoreGraphics.CGRect (DefaultiOSDimensions.cellPadding,0,labelWidth, Frame.Height);
			labelB.Frame = new  CoreGraphics.CGRect	(DefaultiOSDimensions.cellPadding * 2 + labelWidth, 0,labelWidth, Frame.Height); 
			labelC.Frame = new  CoreGraphics.CGRect (DefaultiOSDimensions.cellPadding * 3 + labelWidth * 2, 0, labelWidth, Frame.Height);

			ContentView.AddSubviews (new UIView[]{ labelA, labelB, labelC });
			base.LayoutSubviews ();
		}

		public override void SetColor (UIColor c1, UIColor c2, UIColor c3)
		{
			if (!Object.ReferenceEquals(c2, null) && !Object.ReferenceEquals(c3, null)) {
				labelA.BackgroundColor = c1;
				labelB.BackgroundColor = c2;
				labelC.BackgroundColor = c3;
			}
		}
	}
		
}
