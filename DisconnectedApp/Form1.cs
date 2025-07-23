using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;

namespace DisconnectedApp
{
    public partial class Form1 : Form
    {
        private SqlDataAdapter adapter;
        private readonly string connString;
        private readonly DataSet _dataSet = new();
     
        public Form1()
        {
            InitializeComponent();

            connString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("Default");
        }

        private void execBtn_Click(object sender, EventArgs e)
        {
            string columnName = cmdTextBox.Text.Trim();

            if (!Regex.IsMatch(columnName, @"^[a-zA-Z0-9_]+$"))
            {
                MessageBox.Show("Недопустимое имя столбца.");
                return;
            }

            string query = $"SELECT [{columnName}] FROM People"; // Экранируем имя столбца с помощью [ ]

            using SqlConnection conn = new(connString);
            SqlCommand command = new(query, conn);

            adapter = new(command);

            _dataSet.Clear();
            adapter.Fill(_dataSet);
            dataGridView1.DataSource = _dataSet.Tables[0];
        }
    }
}
