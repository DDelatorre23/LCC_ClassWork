using System;
using Foundation;
using UIKit;
using System.Collections.Generic;

namespace FourFuncCalc
{
	public partial class CalculationsHistoryController : UITableViewController
	{
		public List<string> Calculations { get; set; }

		static NSString calcHistoryCellId = new NSString("CalcHistoryCell");

		public CalculationsHistoryController(IntPtr handle) : base(handle)
		{
			TableView.RegisterClassForCellReuse(typeof(UITableViewCell), calcHistoryCellId);
			TableView.Source = new CalcHistoryDataSource(this);
			Calculations = new List<string>();
		}

		class CalcHistoryDataSource : UITableViewSource
		{
			CalculationsHistoryController controller;

			public CalcHistoryDataSource(CalculationsHistoryController controller)
			{
				this.controller = controller;
			}

			public override nint RowsInSection(UITableView tableView, nint section)
			{
				return controller.Calculations.Count;
			}

			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell(CalculationsHistoryController.calcHistoryCellId);

				int row = indexPath.Row;
				cell.TextLabel.Text = controller.Calculations[row];
				return cell;
			}
		}
	}
}