using CompanyDataAdministrationAPI.Models;
using CompanyDataAdministrationApplication.Services;
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

namespace CompanyDataAdministrationApplication.UI
{
    public partial class CompanyNew : Form
    {
        private readonly HttpClient _client = new HttpClient();

        public CompanyNew(HttpClient client)
        {
            _client = client;
            InitializeComponent();
        }

        private void CheckBoxAddress(object sender, EventArgs e)
        {
            ChangeVisibilityPostal(cb_hasPostal.Checked);
        }

        private void ChangeVisibilityPostal(bool b)
        {
            lbl_strHnr_post.Visible = b;
            txt_strHnr_post.Visible = b;
            lbl_zipCode_post.Visible = b;
            txt_zipCode_post.Visible = b;
            lbl_city_post.Visible = b;
            txt_city_post.Visible = b;
            lbl_country_post.Visible = b;
            txt_country_post.Visible = b;
        }

        //precheck for length and catch errors (phone or fax too long for integers)
        private void btn_save_Click(object sender, EventArgs e)
        {
            List<CompanyFull> companyList = new List<CompanyFull>();

            Company company = new Company {
                CompanyId = 0,
                CompanyName = txt_companyName.Text, 
                CompanyNr = "", 
                EmailAddress = txt_email.Text, 
                Fax = int.Parse(txt_fax.Text), 
                Firstname = txt_firstname.Text, 
                Lastname = txt_lastname.Text, 
                Phone = int.Parse(txt_phone.Text), 
                IsDeleted = false 
            };

            Address main = new Address { 
                AddressId = 0, 
                StrHnr = txt_strHnr.Text, 
                ZipCode = txt_zipCode.Text, 
                City = txt_city.Text, 
                Country = txt_country.Text
            };

            AddressLink mainLink = new AddressLink { 
                AddressLinkId = 0, 
                CompanyId = 0, 
                AddressId = 0, 
                AddressTyp = "main"
            };

            companyList.Add(new CompanyFull { 
                AdressLink=mainLink, 
                Address=main, 
                Company=company 
            });

            if (cb_hasPostal.Checked)
            {
                Address post = new Address
                {
                    AddressId = 0,
                    StrHnr = txt_strHnr_post.Text,
                    ZipCode = txt_zipCode_post.Text,
                    City = txt_city_post.Text,
                    Country = txt_country_post.Text
                };

                AddressLink postLink = new AddressLink
                {
                    AddressLinkId = 0,
                    CompanyId = 0,
                    AddressId = 0,
                    AddressTyp = "post"
                };

                companyList.Add(new CompanyFull
                {
                    AdressLink = postLink,
                    Address = post,
                    Company = company
                });
            }

            new CompanyFullService(_client).Save(companyList); //ew
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
