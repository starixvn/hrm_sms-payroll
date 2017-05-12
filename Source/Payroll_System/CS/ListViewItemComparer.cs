namespace Payroll_System.CS
{
    using System.Collections;
    using System.Windows.Forms;

    public class ListViewItemComparer : IComparer
    {
        private readonly int _col;
        private readonly SortOrder _order;
        public ListViewItemComparer()
        {
            _col = 0;
            _order = SortOrder.Ascending;
        }
        public ListViewItemComparer(int column, SortOrder order)
        {
            _col = column;
            _order = order;
        }
        public int Compare(object x, object y)
        {
            var returnVal = string.CompareOrdinal(
                ((ListViewItem)x).SubItems[_col].Text,
                ((ListViewItem)y).SubItems[_col].Text);

            // Determine whether the sort order is descending.
            if (_order == SortOrder.Descending)
            {
                // Invert the value returned by String.Compare.
                returnVal *= -1;
            }

            return returnVal;
        }
    }
}
