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
        DataManager dataView;
        public TrackUpdateInfoForm()
        {
            InitializeComponent();
            dataView = new DataManager();
        }
        //Вывести все борта с последним временем обновления координат
        private void ShowAllBoardsButton_Click(object sender, EventArgs e)
        {
            
            dataView.GetLatestUpdateTimes();
            if (dataView.ListDataModels is null || dataView.ListDataModels.Count == 0)
            {
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
            dgBoards.DataSource = new SortableBindingList<DataModel> (dataView.ListDataModels);
        }
        //Вывести все борта, которые не обновлялись более `hours`:`minutes` 
        private void NotUpdatedMoreTimeButton_Click(object sender, EventArgs e)
        {
            double hours;
            double minutes;
            if (double.TryParse(hoursComboBox.Text, out hours) && double.TryParse(minutesComboBox.Text, out minutes))
            {
                dataView.GetBoardNotUpdatedMoreTime(hours, minutes);
                if (dataView.ListDataModels is null || dataView.ListDataModels.Count == 0)
                {
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
                dgBoards.DataSource = new SortableBindingList<DataModel>(dataView.ListDataModels);
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
                    dataView.GetBigUpdateDelayInTimeRange(dialog.From, dialog.To, dialog.During);
                });
                wait.Close();
            }
            else
            {
                return;
            }
            if(dataView.ListDataModels is null || dataView.ListDataModels.Count == 0)
            {
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
            dgBoards.DataSource = new SortableBindingList<DataModel>(dataView.ListDataModels);

        }

        private async void AddRowsButton_Click(object sender, EventArgs e)
        {
            PleaseWait wait = new PleaseWait();
            wait.Show();
            await Task.Run(() =>
            {
                dataView.GetBigUpdateDelayInTimeRange(new DateTime(), new DateTime(), new TimeSpan());
            });
            wait.Close();
            dgBoards.DataSource = new SortableBindingList<DataModel>(dataView.ListDataModels);
        }
    }
}
