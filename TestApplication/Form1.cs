using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApplication
{
    public partial class TrackUpdateInfoForm : Form
    {
        DataManager DataView { get; set; }
        public TrackUpdateInfoForm()
        {
            InitializeComponent();
            DataView = new DataManager();
        }
        //Вывести все борта с последним временем обновления координат
        private void ShowAllBoardsButton_Click(object sender, EventArgs e)
        {

            DataView.GetLatestUpdateTimes();
            if (DataView.ListDataModels is null)
            {
                return;
            }
            else if(DataView.ListDataModels.Count == 0)
            {
                MessageBox.Show("По выполненому запросу данные не найдены", "No Data Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgBoards.DataSource = null;
                return;
            }
            
            addRowsButton.Visible = false;
            foreach (DataGridViewTextBoxColumn column in dgBoards.Columns)
            {
                if (column.Name == "StartDateTime" || column.Name == "EndDateTime")
                {
                    column.Visible = false;
                }
                else if (column.Name == "lastUpdateDateTimeDataGridViewTextBoxColumn")
                {
                    column.Visible = true;
                }
            }
            dgBoards.DataSource = new SortableBindingList<DataModel>(DataView.ListDataModels);
        }
        //Вывести все борта, которые не обновлялись более `hours`:`minutes` 
        private void NotUpdatedMoreTimeButton_Click(object sender, EventArgs e)
        {
            if (double.TryParse(hoursComboBox.Text, out double hours) && double.TryParse(minutesComboBox.Text, out double minutes))
            {
                DataView.GetBoardNotUpdatedMoreTime(hours, minutes);
                if (DataView.ListDataModels is null)
                {
                    return;
                }
                else if (DataView.ListDataModels.Count == 0)
                {
                    MessageBox.Show("По выполненому запросу данные не найдены", "No Data Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgBoards.DataSource = null;
                    return;
                }
                addRowsButton.Visible = false;
                foreach (DataGridViewTextBoxColumn column in dgBoards.Columns)
                {
                    if (column.Name == "StartDateTime" || column.Name == "EndDateTime")
                    {
                        column.Visible = false;
                    }
                    else if (column.Name == "lastUpdateDateTimeDataGridViewTextBoxColumn")
                    {
                        column.Visible = true;
                    }
                }
                dgBoards.DataSource = new SortableBindingList<DataModel>(DataView.ListDataModels);
            }
            else
            {
                MessageBox.Show("Введены неверные значения часов или минут", "InputError", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BigDelayButton_Click(object sender, EventArgs e)
        {
            SetPeriodDialog dialog = new SetPeriodDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                PleaseWait wait = new PleaseWait();
                wait.Show();
                await Task.Run(() =>
                {
                    DataView.GetBigUpdateDelayInTimeRange(dialog.From, dialog.To, dialog.During);
                });
                wait.Close();
            }
            else
            {
                return;
            }
            if (DataView.ListDataModels is null)
            {
                return;
            }
            else if (DataView.ListDataModels.Count == 0)
            {
                MessageBox.Show("По выполненому запросу данные не найдены", "No Data Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgBoards.DataSource = null;
                addRowsButton.Visible = false;
                return;
            }
            foreach (DataGridViewTextBoxColumn column in dgBoards.Columns)
            {
                if (column.Name == "StartDateTime" || column.Name == "EndDateTime")
                {
                    column.Visible = true;
                }
                else if (column.Name == "lastUpdateDateTimeDataGridViewTextBoxColumn")
                {
                    column.Visible = false;
                }
            }
            addRowsButton.Visible = true;
            dgBoards.DataSource = new SortableBindingList<DataModel>(DataView.ListDataModels);
        }

        private async void AddRowsButton_Click(object sender, EventArgs e)
        {
            PleaseWait wait = new PleaseWait();
            wait.Show();
            await Task.Run(() =>
            {
                DataView.GetBigUpdateDelayInTimeRange(new DateTime(), new DateTime(), new TimeSpan());
            });
            wait.Close();
            dgBoards.DataSource = new SortableBindingList<DataModel>(DataView.ListDataModels);
        }
    }
}
