using CompanyDataAdministrationAPI.Models;
using CompanyDataAdministrationApplication.Services;
using CompanyDataAdministrationApplication.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyDataAdministrationApplication
{
    public partial class DataAdministration : Form
    {
        private static readonly HttpClient _client = new HttpClient();
        List<Company> companyList = new List<Company>();

        public DataAdministration()
        {
            InitializeComponent();
            FillTable();
        }

        private void FillTable()
        {
            companyList = new CompanyService(_client).GetOverview();
            foreach(Company c in companyList)
            {
                ListViewItem lvi = new ListViewItem(c.CompanyNr);
                lvi.SubItems.Add(c.CompanyName);
                lvi.SubItems.Add(c.EmailAddress);
                lvi.SubItems.Add("dafuq");
                lv_Overview.Items.Add(lvi);
            }
        }

        private void btn_newEntry_Click(object sender, EventArgs e)
        {
            var form = new CompanyNew(_client);
            form.ShowDialog();
        }

        private void UpdateEntry(object sender, MouseEventArgs e)
        {
            var form = new CompanyDetailed(_client, companyList[lv_Overview.SelectedIndices[0]]);
            form.ShowDialog();
        }
    }
}
