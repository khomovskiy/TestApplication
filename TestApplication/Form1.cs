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
        //Сортировка по времени последнего обновления по возрастанию
        private void OrderByLastTimeButton_CheckedChanged(object sender, EventArgs e)
        {
            if (dataView.ListDataModels is null) return;
            dataView.ListDataModels = dataView.ListDataModels.OrderBy(i => i.LastUpdateDateTime).ToList();
            dgBoards.DataSource = dataView.ListDataModels;
        }
        //Сортировка по времени последнего обновления по убыванию
        private void OrderByLastDescTimeButton_CheckedChanged(object sender, EventArgs e)
        {
            if (dataView.ListDataModels is null) return;
            dataView.ListDataModels = dataView.ListDataModels.OrderByDescending(i => i.LastUpdateDateTime).ToList();
            dgBoards.DataSource = dataView.ListDataModels;
        }
        //Вывести все борта с последним временем обновления координат
        private void ShowAllBoardsButton_Click(object sender, EventArgs e)
        {
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
            dataView.GetLatestUpdateTimes();
            if (dataView.ListDataModels is null) return;
            dataView.ListDataModels = dataView.ListDataModels.OrderByDescending(i => i.LastUpdateDateTime).ToList();
            orderByDescLastTimeButton.Checked = true;
            dgBoards.DataSource = dataView.ListDataModels;
        }
        //Вывести все борта, которые не обновлялись более `hours`:`minutes` 
        private void NotUpdatedMoreTimeButton_Click(object sender, EventArgs e)
        {
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
            double hours;
            double minutes;
            if (double.TryParse(hoursComboBox.Text, out hours) && double.TryParse(minutesComboBox.Text, out minutes))
            {
                dataView.GetBoardNotUpdatedMoreTime(hours, minutes);
                if (dataView.ListDataModels is null) return;
                dataView.ListDataModels = dataView.ListDataModels.OrderByDescending(i => i.LastUpdateDateTime).ToList();
                orderByDescLastTimeButton.Checked = true;
                dgBoards.DataSource = dataView.ListDataModels;
            }
            else
            {
                MessageBox.Show("Введены неверные значения часов или минут", "InputError", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BigDelayButton_Click(object sender, EventArgs e)
        {
            addRowsButton.Visible = true;
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
            dgBoards.DataSource = dataView.ListDataModels;

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
            dgBoards.DataSource = null;
            dgBoards.DataSource = dataView.ListDataModels;
            dgBoards.Refresh();
        }
    }
}
