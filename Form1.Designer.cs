using System.Data;

namespace invoice_generator
{
    partial class form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form));
            input_from = new TextBox();
            label_from = new Label();
            input_to = new TextBox();
            label_to = new Label();
            label_items = new Label();
            dataGridView = new DataGridView();
            tableCol_description = new DataGridViewTextBoxColumn();
            tableCol_quantity = new DataGridViewTextBoxColumn();
            tableCol_rate = new DataGridViewTextBoxColumn();
            tableCol_total = new DataGridViewTextBoxColumn();
            saveFileDialog = new SaveFileDialog();
            button_save = new Button();
            label_total = new Label();
            label_id = new Label();
            fontDialog = new FontDialog();
            button_font = new Button();
            input_id = new TextBox();
            input_date = new DateTimePicker();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // input_from
            // 
            input_from.AcceptsTab = true;
            input_from.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            input_from.Location = new Point(53, 12);
            input_from.Name = "input_from";
            input_from.Size = new Size(319, 23);
            input_from.TabIndex = 1;
            input_from.Text = "Nicholas Walkewicz";
            // 
            // label_from
            // 
            label_from.AutoSize = true;
            label_from.Location = new Point(12, 15);
            label_from.Name = "label_from";
            label_from.Size = new Size(35, 15);
            label_from.TabIndex = 0;
            label_from.Text = "From";
            // 
            // input_to
            // 
            input_to.AcceptsTab = true;
            input_to.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            input_to.Location = new Point(53, 41);
            input_to.Name = "input_to";
            input_to.Size = new Size(236, 23);
            input_to.TabIndex = 3;
            // 
            // label_to
            // 
            label_to.AutoSize = true;
            label_to.Location = new Point(28, 44);
            label_to.Name = "label_to";
            label_to.Size = new Size(19, 15);
            label_to.TabIndex = 2;
            label_to.Text = "To";
            // 
            // label_items
            // 
            label_items.AutoSize = true;
            label_items.Location = new Point(11, 73);
            label_items.Name = "label_items";
            label_items.Size = new Size(36, 15);
            label_items.TabIndex = 6;
            label_items.Text = "Items";
            // 
            // dataGridView
            // 
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.BackgroundColor = SystemColors.Control;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { tableCol_description, tableCol_quantity, tableCol_rate, tableCol_total });
            dataGridView.Location = new Point(12, 91);
            dataGridView.Name = "dataGridView";
            dataGridView.RowTemplate.Height = 25;
            dataGridView.ScrollBars = ScrollBars.Vertical;
            dataGridView.Size = new Size(360, 400);
            dataGridView.TabIndex = 7;
            dataGridView.CellFormatting += dataGridView_CellFormatting;
            dataGridView.CellValueChanged += dataGridView_CellValueChanged;
            dataGridView.UserDeletedRow += dataGridView_UserDeletedRow;
            // 
            // tableCol_description
            // 
            tableCol_description.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            tableCol_description.DefaultCellStyle = dataGridViewCellStyle5;
            tableCol_description.HeaderText = "Description";
            tableCol_description.Name = "tableCol_description";
            tableCol_description.Resizable = DataGridViewTriState.False;
            tableCol_description.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // tableCol_quantity
            // 
            tableCol_quantity.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.Format = "0.00";
            dataGridViewCellStyle6.NullValue = "0";
            tableCol_quantity.DefaultCellStyle = dataGridViewCellStyle6;
            tableCol_quantity.HeaderText = "Quantity";
            tableCol_quantity.Name = "tableCol_quantity";
            tableCol_quantity.Resizable = DataGridViewTriState.False;
            tableCol_quantity.SortMode = DataGridViewColumnSortMode.NotSortable;
            tableCol_quantity.Width = 59;
            // 
            // tableCol_rate
            // 
            tableCol_rate.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.Format = "$0.00";
            dataGridViewCellStyle7.NullValue = "$0.00";
            tableCol_rate.DefaultCellStyle = dataGridViewCellStyle7;
            tableCol_rate.HeaderText = "Rate";
            tableCol_rate.Name = "tableCol_rate";
            tableCol_rate.Resizable = DataGridViewTriState.False;
            tableCol_rate.SortMode = DataGridViewColumnSortMode.NotSortable;
            tableCol_rate.Width = 36;
            // 
            // tableCol_total
            // 
            tableCol_total.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "$0.00";
            dataGridViewCellStyle8.NullValue = "$0.00";
            tableCol_total.DefaultCellStyle = dataGridViewCellStyle8;
            tableCol_total.HeaderText = "Total";
            tableCol_total.Name = "tableCol_total";
            tableCol_total.ReadOnly = true;
            tableCol_total.Resizable = DataGridViewTriState.False;
            tableCol_total.SortMode = DataGridViewColumnSortMode.NotSortable;
            tableCol_total.Width = 38;
            // 
            // button_save
            // 
            button_save.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_save.Location = new Point(297, 526);
            button_save.Name = "button_save";
            button_save.Size = new Size(75, 23);
            button_save.TabIndex = 12;
            button_save.Text = "&Save as...";
            button_save.UseVisualStyleBackColor = true;
            button_save.Click += button_save_Click;
            // 
            // label_total
            // 
            label_total.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label_total.AutoSize = true;
            label_total.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label_total.Location = new Point(12, 530);
            label_total.Name = "label_total";
            label_total.Size = new Size(71, 15);
            label_total.TabIndex = 10;
            label_total.Text = "Total: $0.00";
            label_total.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_id
            // 
            label_id.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label_id.AutoSize = true;
            label_id.Location = new Point(295, 44);
            label_id.Name = "label_id";
            label_id.Size = new Size(14, 15);
            label_id.TabIndex = 4;
            label_id.Text = "#";
            // 
            // button_font
            // 
            button_font.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_font.Location = new Point(214, 526);
            button_font.Name = "button_font";
            button_font.Size = new Size(75, 23);
            button_font.TabIndex = 11;
            button_font.Text = "&Font...";
            button_font.UseVisualStyleBackColor = true;
            button_font.Click += button_font_Click;
            // 
            // input_id
            // 
            input_id.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            input_id.Location = new Point(315, 41);
            input_id.Name = "input_id";
            input_id.Size = new Size(57, 23);
            input_id.TabIndex = 5;
            // 
            // input_date
            // 
            input_date.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            input_date.Format = DateTimePickerFormat.Custom;
            input_date.Location = new Point(48, 497);
            input_date.Name = "input_date";
            input_date.Size = new Size(324, 23);
            input_date.TabIndex = 9;
            input_date.CustomFormat = "MMM d, yyyy";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(12, 501);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 8;
            label1.Text = "Date";
            // 
            // form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(384, 561);
            Controls.Add(label1);
            Controls.Add(input_date);
            Controls.Add(input_id);
            Controls.Add(button_font);
            Controls.Add(label_id);
            Controls.Add(label_total);
            Controls.Add(button_save);
            Controls.Add(dataGridView);
            Controls.Add(label_items);
            Controls.Add(label_from);
            Controls.Add(input_from);
            Controls.Add(label_to);
            Controls.Add(input_to);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(350, 250);
            Name = "form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Invoice Generator";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox input_from;
        private Label label_from;

        private TextBox input_to;
        private Label label_to;
        private Label label_items;
        private DataGridView dataGridView;
        private SaveFileDialog saveFileDialog;
        private Button button_save;
        private DataGridViewTextBoxColumn tableCol_description;
        private DataGridViewTextBoxColumn tableCol_quantity;
        private DataGridViewTextBoxColumn tableCol_rate;
        private DataGridViewTextBoxColumn tableCol_total;
        private Label label_total;
        private Label label_id;
        private FontDialog fontDialog;
        private Button button_font;
        private TextBox input_id;
        private DateTimePicker input_date;
        private Label label1;
    }
}