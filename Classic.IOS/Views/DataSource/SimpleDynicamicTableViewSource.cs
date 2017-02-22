using System;
using UIKit;
using Foundation;
using Bankia.IOS.SpecificPlatform;
using CoreGraphics;
using MvvmCross.Binding.iOS.Views;

namespace Bankia.IOS.Generic
{
    public class SimpleDynamicTableViewSource : MvxTableViewSource
    {
        private Type CellType { get; set; }

        public SimpleDynamicTableViewSource (UITableView tableView, Type cellType) : base(tableView)
        {
            this.CellType = cellType;

            tableView.Source = this;
            tableView.RowHeight = UITableView.AutomaticDimension;
            tableView.EstimatedRowHeight = 60.0f;
            this.TableView.RegisterNibForCellReuse(UINib.FromName (this.CellType.Name, null), this.CellType.Name);
        }

        protected override UITableViewCell GetOrCreateCellFor (UITableView tableView, NSIndexPath indexPath, object item)
        {
            return this.TableView.DequeueReusableCell(this.CellType.Name, indexPath);
        }

    }
}

