namespace ComputerShopView
{
    partial class FormMain
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компанентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изделияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.складыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пополнитьСкладToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonCreateBooking = new System.Windows.Forms.Button();
            this.buttonTakeBookingInWork = new System.Windows.Forms.Button();
            this.buttonBookingReady = new System.Windows.Forms.Button();
            this.buttonPayBooking = new System.Windows.Forms.Button();
            this.buttonRef = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.пополнитьСкладToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1108, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.клиентыToolStripMenuItem,
            this.компанентыToolStripMenuItem,
            this.изделияToolStripMenuItem,
            this.складыToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(115, 24);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.клиентыToolStripMenuItem.Text = "Покупатели";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.покупателиToolStripMenuItem_Click);
            // 
            // компанентыToolStripMenuItem
            // 
            this.компанентыToolStripMenuItem.Name = "компанентыToolStripMenuItem";
            this.компанентыToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.компанентыToolStripMenuItem.Text = "Компаненты";
            this.компанентыToolStripMenuItem.Click += new System.EventHandler(this.компанентыToolStripMenuItem_Click);
            // 
            // изделияToolStripMenuItem
            // 
            this.изделияToolStripMenuItem.Name = "изделияToolStripMenuItem";
            this.изделияToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.изделияToolStripMenuItem.Text = "Изделие";
            this.изделияToolStripMenuItem.Click += new System.EventHandler(this.изделиеToolStripMenuItem_Click);
            // 
            // складыToolStripMenuItem
            // 
            this.складыToolStripMenuItem.Name = "складыToolStripMenuItem";
            this.складыToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.складыToolStripMenuItem.Text = "Склады";
            this.складыToolStripMenuItem.Click += new System.EventHandler(this.складToolStripMenuItem_Click);
            // 
            // пополнитьСкладToolStripMenuItem
            // 
            this.пополнитьСкладToolStripMenuItem.Name = "пополнитьСкладToolStripMenuItem";
            this.пополнитьСкладToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.пополнитьСкладToolStripMenuItem.Text = "Пополнить склад";
            this.пополнитьСкладToolStripMenuItem.Click += new System.EventHandler(this.пополнитьСкладToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 31);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(885, 478);
            this.dataGridView.TabIndex = 1;
            // 
            // buttonCreateBooking
            // 
            this.buttonCreateBooking.Location = new System.Drawing.Point(903, 31);
            this.buttonCreateBooking.Name = "buttonCreateBooking";
            this.buttonCreateBooking.Size = new System.Drawing.Size(193, 68);
            this.buttonCreateBooking.TabIndex = 2;
            this.buttonCreateBooking.Text = "Создать заказ";
            this.buttonCreateBooking.UseVisualStyleBackColor = true;
            this.buttonCreateBooking.Click += new System.EventHandler(this.buttonCreateBooking_Click);
            // 
            // buttonTakeBookingInWork
            // 
            this.buttonTakeBookingInWork.Location = new System.Drawing.Point(903, 105);
            this.buttonTakeBookingInWork.Name = "buttonTakeBookingInWork";
            this.buttonTakeBookingInWork.Size = new System.Drawing.Size(193, 65);
            this.buttonTakeBookingInWork.TabIndex = 3;
            this.buttonTakeBookingInWork.Text = "Отдать на выполнение";
            this.buttonTakeBookingInWork.UseVisualStyleBackColor = true;
            this.buttonTakeBookingInWork.Click += new System.EventHandler(this.buttonTakeBookingInWork_Click);
            // 
            // buttonBookingReady
            // 
            this.buttonBookingReady.Location = new System.Drawing.Point(903, 176);
            this.buttonBookingReady.Name = "buttonBookingReady";
            this.buttonBookingReady.Size = new System.Drawing.Size(193, 65);
            this.buttonBookingReady.TabIndex = 4;
            this.buttonBookingReady.Text = "Заказ готов";
            this.buttonBookingReady.UseVisualStyleBackColor = true;
            this.buttonBookingReady.Click += new System.EventHandler(this.buttonBookingReady_Click);
            // 
            // buttonPayBooking
            // 
            this.buttonPayBooking.Location = new System.Drawing.Point(903, 247);
            this.buttonPayBooking.Name = "buttonPayBooking";
            this.buttonPayBooking.Size = new System.Drawing.Size(193, 65);
            this.buttonPayBooking.TabIndex = 5;
            this.buttonPayBooking.Text = "Заказ оплачен";
            this.buttonPayBooking.UseVisualStyleBackColor = true;
            this.buttonPayBooking.Click += new System.EventHandler(this.buttonPayBooking_Click);
            // 
            // buttonRef
            // 
            this.buttonRef.Location = new System.Drawing.Point(903, 318);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(193, 65);
            this.buttonRef.TabIndex = 6;
            this.buttonRef.Text = "Обновить список";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 591);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.buttonPayBooking);
            this.Controls.Add(this.buttonBookingReady);
            this.Controls.Add(this.buttonTakeBookingInWork);
            this.Controls.Add(this.buttonCreateBooking);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "Компьютерный магазин";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компанентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изделияToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonCreateBooking;
        private System.Windows.Forms.Button buttonTakeBookingInWork;
        private System.Windows.Forms.Button buttonBookingReady;
        private System.Windows.Forms.Button buttonPayBooking;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.ToolStripMenuItem складыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пополнитьСкладToolStripMenuItem;
    }
}