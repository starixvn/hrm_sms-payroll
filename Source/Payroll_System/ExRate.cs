using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Payroll_System
{
    public partial class ExRate : First
    {
        TSQL tSQL;
        string thisMonthyStr;
        DataTable CurrencyDT;
        DataTable CurrencyAllandEnable;
        DataTable baseTable;
        int readRow = -1;
        bool all_hasload;

        #region =======  this form ========
        public ExRate()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ExRate_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            tSQL = new TSQL(base.RemoteDBAbsPath());

            all_hasload = false;
            label3.Text = tSQL.LockData_openMonth();
            CurrencyDT = tSQL.CurrencyData_SelectShowRate();

            load_yearBox();
            load_CurrencyListBox();
            load_CurrencyHead2Grid();
            load_Rate();

            //base currency
            createBaseDataTable();
            all_hasload = true;
        }
        //Create Dic Item
        private void createBaseDataTable()
        {
            baseTable = new DataTable();
            int colcount = RecGrid.ColumnCount;
            int rowcount = RecGrid.Rows.Count;
            int col;
            int row;
            object[] Ary;

            for (row = 0; row < rowcount; row++)
            {
                Ary = new object[colcount];
                for (col = 0; col < colcount; col++)
                {
                    if (row == 0)
                    {
                        //create head
                        baseTable.Columns.Add(RecGrid.Columns[col].HeaderText, System.Type.GetType("System.String"));
                    }
                    Ary[col] = base.obj2str(RecGrid.Rows[row].Cells[col].Value);
                }
                baseTable.Rows.Add(Ary);
            }
        }
        private void load_CurrencyListBox()
        {
            txtCurrency.Items.Clear();

            CurrencyAllandEnable = tSQL.CurrencyData_SelectAllandEnable();
            string formatStr;
            foreach (DataRow row in CurrencyAllandEnable.Rows)
            {
                formatStr = string.Format("{0}", row["Pcurrency"].ToString());
                txtCurrency.Items.Add(formatStr);
            }
            if (txtCurrency.Items.Count > 0)
            {
                txtCurrency.Text = "MYR";
            }
        }

        private void ExRate_FormClosed(object sender, FormClosedEventArgs e)
        {
            tSQL.closeConnection();
        }

        private void load_yearBox()
        {
            yearSelection.Items.Clear();
            DataTable data = tSQL.ExRateData_selectbyYear();

            if (data.Rows.Count == 0)
            {
                yearSelection.Items.Add(DateTime.Now.Year.ToString());
            }
            else
            {
                foreach (DataRow row in data.Rows)
                {
                    yearSelection.Items.Add(row[0].ToString());
                }
            }

            yearSelection.Text = DateTime.Now.ToString("yyyy");
        }

        private string GetValueFromComboBox(ComboBox comboBox)
        {
            if (comboBox == null)
            {
                return string.Empty;
            }

            string value = string.Empty;
            if (comboBox.Items.Count > 0 && comboBox.SelectedItem != null)
            {
                value = comboBox.SelectedItem.ToString();
            }

            return value;
        }

        private void load_CurrencyHead2Grid()
        {
            int i = 1;
            DataGridViewTextBoxColumn column;

            foreach (DataRow row in CurrencyDT.Rows)
            {
                column = new DataGridViewTextBoxColumn();
                column.Name = string.Format("{0}", row["Pcurrency"].ToString());
                column.Width = 60;
                column.DataPropertyName = string.Format("{0}", row["Pcurrency"].ToString());
                column.HeaderText = row["Pcurrency"].ToString();
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                if (row["enable"].ToString() == "Y")
                {
                    column.HeaderCell.Style.ForeColor = Color.Black;
                }
                else
                {
                    column.HeaderCell.Style.ForeColor = Color.Gray;
                }
                RecGrid.Columns.Add(column);
                RecGrid.Columns[i].Tag = row["strFormat"].ToString(); //save strFormat
                i++;
            }
        }
        private void load_Rate()
        {
            string fieldname;
            int i;
            int m;
            string _month;
            string _searchdate;
            bool _lock;
            string IsDisable;

            RecGrid.Rows.Clear();
            RecGrid.RowCount = 12;

            thisMonthyStr = label3.Text;

            DataTable dt;

            int ColumnIndex;
            for (m = 0; m < 12; m++)
            {
                _month = string.Format("{0:00}", m + 1);
                RecGrid.Rows[m].Cells[0].Value = _month;
                _searchdate = this.GetValueFromComboBox(yearSelection) + _month;
                dt = tSQL.ExRateData_getAllbyDate(_searchdate);
                if (_searchdate == label3.Text)
                {
                    readRow = m;  //save source line
                    _lock = true;
                }
                else
                {
                    _lock = false;
                }
                markGridCell(m, 0, false, "Y");

                if (!_lock)
                {
                    for (i = 1; i <= CurrencyDT.Rows.Count; i++)
                    {
                        if (RecGrid.Columns[i].HeaderCell.Style.ForeColor == Color.Gray)
                        {
                            IsDisable = "N";
                        }
                        else
                        {
                            IsDisable = "Y";
                        }
                        markGridCell(m, i, _lock, IsDisable);
                    }
                }
                else
                {
                    // when open month
                    for (i = 1; i <= CurrencyDT.Rows.Count; i++)
                    {
                        if (RecGrid.Columns[i].HeaderCell.Style.ForeColor == Color.Gray)
                        {
                            markGridCell(m, i, false, "N");
                        }
                    }
                }

                if (dt.Rows.Count > 0)
                {
                    for (i = 0; i < dt.Rows.Count; i++)
                    {
                        fieldname = dt.Rows[i]["exchangeCurrency"].ToString();
                        ColumnIndex = RecGrid.Rows[m].Cells[fieldname].ColumnIndex;
                        if (RecGrid.Columns.Contains(fieldname))
                        {
                            RecGrid.Rows[m].Cells[fieldname].Value = dt.Rows[i]["showRate"].ToString();
                            markGridCell(m, ColumnIndex, _lock, "");
                        }
                    }
                }
            }
            txtCurrency.Text = "MYR";
        }
        private void markGridCell(int rows, int cells, bool read_only, string IsDisable)
        {
            if (IsDisable == "Y")
            {
                RecGrid.Rows[rows].Cells[cells].Style.BackColor = Control.DefaultBackColor;
                RecGrid.Rows[rows].Cells[cells].Style.SelectionBackColor = Control.DefaultBackColor;
                RecGrid.Rows[rows].Cells[cells].Style.ForeColor = Color.Black;
                RecGrid.Rows[rows].Cells[cells].Style.SelectionForeColor = Control.DefaultForeColor;
                RecGrid.Rows[rows].Cells[cells].ReadOnly = !read_only;
            }
            else if (IsDisable == "N")
            {
                RecGrid.Rows[rows].Cells[cells].Style.BackColor = Control.DefaultBackColor;
                RecGrid.Rows[rows].Cells[cells].Style.SelectionBackColor = Control.DefaultBackColor;
                RecGrid.Rows[rows].Cells[cells].Style.ForeColor = Color.Gray;
                RecGrid.Rows[rows].Cells[cells].Style.SelectionForeColor = Color.Gray;
                RecGrid.Rows[rows].Cells[cells].ReadOnly = !read_only;
            }
            else
            {
                //nothing
            }

        }
        private void YearBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (all_hasload) load_Rate();
        }
        #endregion ====  this form ========

        #region =====================  monitor Grid ======================
        private void RecGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            enableBtn(true);
        }
        private void RecGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            enableBtn(false);
        }
        private void RecGrid_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            enableBtn(true);
        }
        private void enableBtn(bool b)
        {
            yearSelection.Enabled = b;
            btnSave.Enabled = b;
            if (this.GetValueFromComboBox(txtCurrency) != "MYR")
            {
                btnSave.Enabled = false;
            }
        }
        #endregion =====================  monitor Grid ======================


        // Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool flag = true;
            string Head_currency;
            string amount;
            int cellCount = RecGrid.Rows[0].Cells.Count;
            string strFormat;

            //reInsert (because maybe lost enable currency
            if (readRow > -1)
            {
                tSQL.ExRateData_Delete(thisMonthyStr);
                for (int i = 0; i < cellCount; i++)
                {
                    Head_currency = RecGrid.Columns[i].HeaderText;
                    if (RecGrid.Rows[readRow].Cells[i].Value != null && i != 0)
                    {
                        amount = RecGrid.Rows[readRow].Cells[i].Value.ToString().Trim();
                        if (amount == string.Empty) amount = "0";
                        strFormat = RecGrid.Columns[i].Tag.ToString();
                        amount = string.Format(strFormat, Convert.ToDouble(amount));
                        //has value, insert to DB
                        flag = flag && tSQL.ExRateData_Insert("MYR", thisMonthyStr, Head_currency, amount);
                    }
                }
            }

            if (flag)
            {
                MessageBox.Show("Saved.", "Save Rate", MessageBoxButtons.OK);
                load_Rate();
            }
            else
            {
                MessageBox.Show(tSQL.errMessage, "Save Rate", MessageBoxButtons.OK);
            }

            createBaseDataTable();
        }

        private void txtCurry_SelectedIndexChanged(object sender, EventArgs e)
        {
            //change rate
            string pcurrcy;
            string _format;
            double _base;
            double _rate;
            double _newrate;

            int colcount = RecGrid.ColumnCount;
            int rowcount = RecGrid.Rows.Count;
            int col;
            int row;
            string colValue;

            if (txtCurrency.SelectedItem != null)
            {
                pcurrcy = txtCurrency.SelectedItem.ToString();
                // disable [Save]
                if (pcurrcy == "MYR")
                {
                    btnSave.Enabled = true;
                    for (row = 0; row < rowcount; row++)
                    {
                        for (col = 1; col < colcount; col++)
                        {
                            RecGrid.Rows[row].Cells[col].Value = baseTable.Rows[row][col].ToString();
                        }
                    }
                }
                else
                {
                    // change!  
                    btnSave.Enabled = false;
                    for (row = 0; row < rowcount; row++)
                    {
                        colValue = base.obj2str(baseTable.Rows[row][pcurrcy]);
                        _base = txt2double(colValue);
                        for (col = 1; col < colcount; col++)
                        {
                            _rate = txt2double(base.obj2str(baseTable.Rows[row][col]));
                            _format = base.obj2str(RecGrid.Columns[col].Tag);

                            if (_base != 0)
                                _newrate = (1 / _base * _rate);
                            else
                                _newrate = 0;

                            if (colValue != string.Empty)
                            {
                                if (_newrate != 0)
                                {
                                    RecGrid.Rows[row].Cells[col].Value = string.Format(_format, _newrate);
                                }
                                else
                                {
                                    RecGrid.Rows[row].Cells[col].Value = "0";
                                }
                            }
                            else
                            {
                                RecGrid.Rows[row].Cells[col].Value = string.Empty;
                            }
                        }
                    }

                }
            }
            else
            {
                btnSave.Enabled = false;
                txtCurrency.Text = string.Empty;
            }
        }


    }
}