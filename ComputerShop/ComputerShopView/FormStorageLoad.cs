using ComputerShopServiceDAL.BindingModels;
using ComputerShopServiceDAL.Interfaces;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Attributes;

namespace ComputerShopView
{
    public partial class FormStorageLoad : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IRecordService service;

        public FormStorageLoad(IRecordService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormStorageLoad_Load(object sender, EventArgs e)
        {
            try
            {
                var dict = service.GetStorageLoad();
                if (dict != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var elem in dict)
                    {
                        dataGridView.Rows.Add(new object[] { elem.StorageName, "", "" });
                        foreach (var listElem in elem.Components)
                        {
                            dataGridView.Rows.Add(new object[] { "", listElem.Item1, listElem.Item2 });
                        }
                        dataGridView.Rows.Add(new object[] { "Итого", "", elem.TotalCount });
                        dataGridView.Rows.Add(new object[] { }); } } } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSaveToExel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog { Filter = "xls|*.xls|xlsx|*.xlsx" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    service.SaveStorageLoad(new RecordBindingModel { FileName = sfd.FileName });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
