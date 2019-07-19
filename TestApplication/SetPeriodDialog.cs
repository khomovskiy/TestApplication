﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApplication
{
    public partial class SetPeriodDialog : Form
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public TimeSpan During { get; set; }
        public SetPeriodDialog()
        {
            InitializeComponent();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            From = fromDateTimePicker.Value;
            To = toDateTimePicker.Value;
            double hours;
            double minutes;
            if (double.TryParse(hoursComboBox.Text, out hours) && double.TryParse(minutesComboBox.Text, out minutes))
            {
                During = TimeSpan.FromHours(hours) + TimeSpan.FromMinutes(minutes);
            }
            else
            {
                MessageBox.Show("Введены неверные значения часов или минут", "InputError", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
