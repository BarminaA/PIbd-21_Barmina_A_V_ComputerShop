namespace ComputerShopView
{
    partial class FormStorageLoad
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Storage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Part = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSaveToExel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Storage,
            this.Part,
            this.Item3});
            this.dataGridView.Location = new System.Drawing.Point(13, 45);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(430, 388);
            this.dataGridView.TabIndex = 1;
            // 
            // Storage
            // 
            this.Storage.HeaderText = "Склад";
            this.Storage.Name = "Storage";
            // 
            // Part
            // 
            this.Part.HeaderText = "Компонент";
            this.Part.Name = "Part";
            // 
            // Item3
            // 
            this.Item3.HeaderText = "Количество";
            this.Item3.Name = "Item3";
            // 
            // buttonSaveToExel
            // 
            this.buttonSaveToExel.Location = new System.Drawing.Point(13, 12);
            this.buttonSaveToExel.Name = "buttonSaveToExel";
            this.buttonSaveToExel.Size = new System.Drawing.Size(150, 27);
            this.buttonSaveToExel.TabIndex = 2;
            this.buttonSaveToExel.Text = "Сохранить в Exel";
            this.buttonSaveToExel.UseVisualStyleBackColor = true;
            this.buttonSaveToExel.Click += new System.EventHandler(this.buttonSaveToExel_Click);
            // 
            // FormStorageLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 449);
            this.Controls.Add(this.buttonSaveToExel);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormStorageLoad";
            this.Text = "Загрузка складов";
            this.Load += new System.EventHandler(this.FormStorageLoad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonSaveToExel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Storage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Part;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item3;
    }
}