using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Collections.Generic;

namespace XamarinWebAPI
{
    public class TableSource<T> : UITableViewSource 
    {
        public List<T> Data { get; set; }
        protected string cellIdentifier = "TableCell";

        public TableSource ()
        {
            Data = new List<T> ();
        }

        public TableSource(List<T> data)
        {
            Data = data;
        }

        /// <summary>
        /// Called by the TableView to determine how many cells to create for that particular section.
        /// </summary>
        public override int RowsInSection (UITableView tableview, int section)
        {
            return Data.Count;
        }

        /// <summary>
        /// Called when a row is touched
        /// </summary>
        public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
        {
            if (OnRowSelected != null) {
                OnRowSelected (this, new RowSelectedEventArgs (tableView, indexPath));
            }
        }

        public class RowSelectedEventArgs : EventArgs
        {
            public UITableView tableView { get; set; }
            public NSIndexPath indexPath { get; set; }

            public RowSelectedEventArgs(UITableView tableView, NSIndexPath indexPath) : base()
            { 
                this.tableView = tableView;
                this.indexPath = indexPath;
            }
        }

        public event EventHandler<RowSelectedEventArgs> OnRowSelected;

        /// <summary>
        /// Called by the TableView to get the actual UITableViewCell to render for the particular row
        /// </summary>
        public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
        {
            // request a recycled cell to save memory
            UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);
            // if there are no cells to reuse, create a new one
            if (cell == null)
                cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);

            cell.TextLabel.Text = Data[indexPath.Row].ToString();

            return cell;
        }
    }
}