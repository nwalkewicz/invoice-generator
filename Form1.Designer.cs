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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form));
            input_from = new TextBox();
            label_from = new Label();
            input_to = new TextBox();
            label_to = new Label();
            label_items = new Label();
            dataGridView = new DataGridView();
            tableCol_description = new DataGridViewTextBoxColumn();
            tableCol_quantity = new DataGridViewTextBoxColumn();
            tableCol_unit_cost = new DataGridViewTextBoxColumn();
            tableCol_total = new DataGridViewTextBoxColumn();
            saveFileDialog = new SaveFileDialog();
            button_save = new Button();
            label_total = new Label();
            label_total_value = new Label();
            label_id = new Label();
            fontDialog = new FontDialog();
            button_font = new Button();
            input_id = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)input_id).BeginInit();
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
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { tableCol_description, tableCol_quantity, tableCol_unit_cost, tableCol_total });
            dataGridView.Location = new Point(12, 91);
            dataGridView.Name = "dataGridView";
            dataGridView.RowTemplate.Height = 25;
            dataGridView.ScrollBars = ScrollBars.Vertical;
            dataGridView.Size = new Size(360, 429);
            dataGridView.TabIndex = 7;
            dataGridView.CellFormatting += dataGridView_CellFormatting;
            dataGridView.CellValueChanged += dataGridView_CellValueChanged;
            dataGridView.UserDeletedRow += dataGridView_UserDeletedRow;
            // 
            // tableCol_description
            // 
            tableCol_description.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            tableCol_description.DefaultCellStyle = dataGridViewCellStyle1;
            tableCol_description.HeaderText = "Description";
            tableCol_description.Name = "tableCol_description";
            tableCol_description.Resizable = DataGridViewTriState.False;
            tableCol_description.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // tableCol_quantity
            // 
            tableCol_quantity.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Format = "0.00";
            dataGridViewCellStyle2.NullValue = "0";
            tableCol_quantity.DefaultCellStyle = dataGridViewCellStyle2;
            tableCol_quantity.HeaderText = "Quantity";
            tableCol_quantity.Name = "tableCol_quantity";
            tableCol_quantity.Resizable = DataGridViewTriState.False;
            tableCol_quantity.SortMode = DataGridViewColumnSortMode.NotSortable;
            tableCol_quantity.Width = 59;
            // 
            // tableCol_unit_cost
            // 
            tableCol_unit_cost.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Format = "$0.00";
            dataGridViewCellStyle3.NullValue = "$0.00";
            tableCol_unit_cost.DefaultCellStyle = dataGridViewCellStyle3;
            tableCol_unit_cost.HeaderText = "Unit Cost";
            tableCol_unit_cost.Name = "tableCol_unit_cost";
            tableCol_unit_cost.Resizable = DataGridViewTriState.False;
            tableCol_unit_cost.SortMode = DataGridViewColumnSortMode.NotSortable;
            tableCol_unit_cost.Width = 62;
            // 
            // tableCol_total
            // 
            tableCol_total.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "$0.00";
            dataGridViewCellStyle4.NullValue = "$0.00";
            tableCol_total.DefaultCellStyle = dataGridViewCellStyle4;
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
            button_save.TabIndex = 11;
            button_save.Text = "Save PDF";
            button_save.UseVisualStyleBackColor = true;
            button_save.Click += button_save_Click;
            // 
            // label_total
            // 
            label_total.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label_total.AutoSize = true;
            label_total.Location = new Point(12, 530);
            label_total.Name = "label_total";
            label_total.Size = new Size(35, 15);
            label_total.TabIndex = 8;
            label_total.Text = "Total:";
            // 
            // label_total_value
            // 
            label_total_value.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label_total_value.AutoSize = true;
            label_total_value.Location = new Point(53, 530);
            label_total_value.Name = "label_total_value";
            label_total_value.Size = new Size(34, 15);
            label_total_value.TabIndex = 9;
            label_total_value.Text = "$0.00";
            // 
            // label_id
            // 
            label_id.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label_id.AutoSize = true;
            label_id.Location = new Point(297, 44);
            label_id.Name = "label_id";
            label_id.Size = new Size(14, 15);
            label_id.TabIndex = 4;
            label_id.Text = "#";
            // 
            // button_font
            // 
            button_font.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_font.Location = new Point(216, 526);
            button_font.Name = "button_font";
            button_font.Size = new Size(75, 23);
            button_font.TabIndex = 10;
            button_font.Text = "Font...";
            button_font.UseVisualStyleBackColor = true;
            button_font.Click += button_font_Click;
            // 
            // input_id
            // 
            input_id.Location = new Point(317, 41);
            input_id.Name = "input_id";
            input_id.Size = new Size(57, 23);
            input_id.TabIndex = 5;
            // 
            // form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(384, 561);
            Controls.Add(input_id);
            Controls.Add(button_font);
            Controls.Add(label_id);
            Controls.Add(label_total_value);
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
            ((System.ComponentModel.ISupportInitialize)input_id).EndInit();
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
        private DataGridViewTextBoxColumn tableCol_unit_cost;
        private DataGridViewTextBoxColumn tableCol_total;
        private Label label_total;
        private Label label_total_value;
        private Label label_id;
        private FontDialog fontDialog;
        private Button button_font;
        private NumericUpDown input_id;
    }
}