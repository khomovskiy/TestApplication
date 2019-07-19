namespace TestApplication
{
    partial class TrackUpdateInfoForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgBoards = new System.Windows.Forms.DataGridView();
            this.boardNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.governmentNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdateDateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.orderByDescLastTimeButton = new System.Windows.Forms.RadioButton();
            this.orderByLastTimeButton = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.showAllBoardsButton = new System.Windows.Forms.Button();
            this.NotUpdatedMoreTimeButton = new System.Windows.Forms.Button();
            this.hoursComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.minutesComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BigDelayButton = new System.Windows.Forms.Button();
            this.addRowsButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBoards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataModelBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.5F));
            this.tableLayoutPanel1.Controls.Add(this.dgBoards, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.addRowsButton, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.777778F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.22222F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1000, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgBoards
            // 
            this.dgBoards.AllowUserToAddRows = false;
            this.dgBoards.AllowUserToDeleteRows = false;
            this.dgBoards.AutoGenerateColumns = false;
            this.dgBoards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBoards.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.boardNameDataGridViewTextBoxColumn,
            this.governmentNumberDataGridViewTextBoxColumn,
            this.lastUpdateDateTimeDataGridViewTextBoxColumn,
            this.StartDateTime,
            this.EndDateTime});
            this.dgBoards.DataSource = this.dataModelBindingSource;
            this.dgBoards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgBoards.Location = new System.Drawing.Point(3, 38);
            this.dgBoards.Name = "dgBoards";
            this.dgBoards.ReadOnly = true;
            this.dgBoards.RowHeadersVisible = false;
            this.dgBoards.Size = new System.Drawing.Size(829, 409);
            this.dgBoards.TabIndex = 0;
            // 
            // boardNameDataGridViewTextBoxColumn
            // 
            this.boardNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.boardNameDataGridViewTextBoxColumn.DataPropertyName = "BoardName";
            this.boardNameDataGridViewTextBoxColumn.HeaderText = "Номер борта";
            this.boardNameDataGridViewTextBoxColumn.Name = "boardNameDataGridViewTextBoxColumn";
            this.boardNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // governmentNumberDataGridViewTextBoxColumn
            // 
            this.governmentNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.governmentNumberDataGridViewTextBoxColumn.DataPropertyName = "GovernmentNumber";
            this.governmentNumberDataGridViewTextBoxColumn.HeaderText = "Гос. номер";
            this.governmentNumberDataGridViewTextBoxColumn.Name = "governmentNumberDataGridViewTextBoxColumn";
            this.governmentNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lastUpdateDateTimeDataGridViewTextBoxColumn
            // 
            this.lastUpdateDateTimeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.lastUpdateDateTimeDataGridViewTextBoxColumn.DataPropertyName = "LastUpdateDateTime";
            this.lastUpdateDateTimeDataGridViewTextBoxColumn.HeaderText = "Время последнего обновления";
            this.lastUpdateDateTimeDataGridViewTextBoxColumn.Name = "lastUpdateDateTimeDataGridViewTextBoxColumn";
            this.lastUpdateDateTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastUpdateDateTimeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // StartDateTime
            // 
            this.StartDateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StartDateTime.DataPropertyName = "StartDateTime";
            this.StartDateTime.FillWeight = 150F;
            this.StartDateTime.HeaderText = "Cледующее обновление";
            this.StartDateTime.Name = "StartDateTime";
            this.StartDateTime.ReadOnly = true;
            this.StartDateTime.Visible = false;
            // 
            // EndDateTime
            // 
            this.EndDateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EndDateTime.DataPropertyName = "EndDateTime";
            this.EndDateTime.FillWeight = 150F;
            this.EndDateTime.HeaderText = "Предыдущее обновление";
            this.EndDateTime.Name = "EndDateTime";
            this.EndDateTime.ReadOnly = true;
            this.EndDateTime.Visible = false;
            // 
            // dataModelBindingSource
            // 
            this.dataModelBindingSource.DataSource = typeof(TestApplication.DataModel);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.orderByDescLastTimeButton);
            this.groupBox1.Controls.Add(this.orderByLastTimeButton);
            this.groupBox1.Location = new System.Drawing.Point(838, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(126, 71);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Сортировка";
            // 
            // orderByDescLastTimeButton
            // 
            this.orderByDescLastTimeButton.AutoSize = true;
            this.orderByDescLastTimeButton.Location = new System.Drawing.Point(7, 44);
            this.orderByDescLastTimeButton.Name = "orderByDescLastTimeButton";
            this.orderByDescLastTimeButton.Size = new System.Drawing.Size(93, 17);
            this.orderByDescLastTimeButton.TabIndex = 1;
            this.orderByDescLastTimeButton.Text = "По убыванию";
            this.orderByDescLastTimeButton.UseVisualStyleBackColor = true;
            this.orderByDescLastTimeButton.CheckedChanged += new System.EventHandler(this.OrderByLastDescTimeButton_CheckedChanged);
            // 
            // orderByLastTimeButton
            // 
            this.orderByLastTimeButton.AutoSize = true;
            this.orderByLastTimeButton.Checked = true;
            this.orderByLastTimeButton.Location = new System.Drawing.Point(7, 20);
            this.orderByLastTimeButton.Name = "orderByLastTimeButton";
            this.orderByLastTimeButton.Size = new System.Drawing.Size(109, 17);
            this.orderByLastTimeButton.TabIndex = 0;
            this.orderByLastTimeButton.TabStop = true;
            this.orderByLastTimeButton.Text = "По возрастанию";
            this.orderByLastTimeButton.UseVisualStyleBackColor = true;
            this.orderByLastTimeButton.CheckedChanged += new System.EventHandler(this.OrderByLastTimeButton_CheckedChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.showAllBoardsButton);
            this.flowLayoutPanel1.Controls.Add(this.NotUpdatedMoreTimeButton);
            this.flowLayoutPanel1.Controls.Add(this.hoursComboBox);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.minutesComboBox);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.BigDelayButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(829, 29);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // showAllBoardsButton
            // 
            this.showAllBoardsButton.Location = new System.Drawing.Point(3, 3);
            this.showAllBoardsButton.Name = "showAllBoardsButton";
            this.showAllBoardsButton.Size = new System.Drawing.Size(142, 21);
            this.showAllBoardsButton.TabIndex = 2;
            this.showAllBoardsButton.Text = "Показать все борта";
            this.showAllBoardsButton.UseVisualStyleBackColor = true;
            this.showAllBoardsButton.Click += new System.EventHandler(this.ShowAllBoardsButton_Click);
            // 
            // NotUpdatedMoreTimeButton
            // 
            this.NotUpdatedMoreTimeButton.Location = new System.Drawing.Point(151, 3);
            this.NotUpdatedMoreTimeButton.Name = "NotUpdatedMoreTimeButton";
            this.NotUpdatedMoreTimeButton.Size = new System.Drawing.Size(212, 21);
            this.NotUpdatedMoreTimeButton.TabIndex = 0;
            this.NotUpdatedMoreTimeButton.Text = "Показать необновлённые более чем:";
            this.NotUpdatedMoreTimeButton.UseVisualStyleBackColor = true;
            this.NotUpdatedMoreTimeButton.Click += new System.EventHandler(this.NotUpdatedMoreTimeButton_Click);
            // 
            // hoursComboBox
            // 
            this.hoursComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hoursComboBox.FormattingEnabled = true;
            this.hoursComboBox.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.hoursComboBox.Location = new System.Drawing.Point(369, 3);
            this.hoursComboBox.Name = "hoursComboBox";
            this.hoursComboBox.Size = new System.Drawing.Size(48, 21);
            this.hoursComboBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(423, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 29);
            this.label1.TabIndex = 5;
            this.label1.Text = "час.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // minutesComboBox
            // 
            this.minutesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.minutesComboBox.FormattingEnabled = true;
            this.minutesComboBox.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.minutesComboBox.Location = new System.Drawing.Point(456, 3);
            this.minutesComboBox.Name = "minutesComboBox";
            this.minutesComboBox.Size = new System.Drawing.Size(54, 21);
            this.minutesComboBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(516, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 29);
            this.label2.TabIndex = 6;
            this.label2.Text = "мин.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BigDelayButton
            // 
            this.BigDelayButton.Location = new System.Drawing.Point(552, 3);
            this.BigDelayButton.Name = "BigDelayButton";
            this.BigDelayButton.Size = new System.Drawing.Size(258, 23);
            this.BigDelayButton.TabIndex = 7;
            this.BigDelayButton.Text = "Показать большие задержки обновления";
            this.BigDelayButton.UseVisualStyleBackColor = true;
            this.BigDelayButton.Click += new System.EventHandler(this.BigDelayButton_Click);
            // 
            // addRowsButton
            // 
            this.addRowsButton.Location = new System.Drawing.Point(838, 3);
            this.addRowsButton.Name = "addRowsButton";
            this.addRowsButton.Size = new System.Drawing.Size(150, 29);
            this.addRowsButton.TabIndex = 4;
            this.addRowsButton.Text = "Показать ещё";
            this.addRowsButton.UseVisualStyleBackColor = true;
            this.addRowsButton.Visible = false;
            this.addRowsButton.Click += new System.EventHandler(this.AddRowsButton_Click);
            // 
            // TrackUpdateInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TrackUpdateInfoForm";
            this.Text = "Track Update Info";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgBoards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataModelBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgBoards;
        private System.Windows.Forms.BindingSource dataModelBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton orderByDescLastTimeButton;
        private System.Windows.Forms.RadioButton orderByLastTimeButton;
        private System.Windows.Forms.Button showAllBoardsButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button NotUpdatedMoreTimeButton;
        private System.Windows.Forms.ComboBox hoursComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox minutesComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BigDelayButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn boardNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn governmentNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdateDateTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndDateTime;
        private System.Windows.Forms.Button addRowsButton;
    }
}

