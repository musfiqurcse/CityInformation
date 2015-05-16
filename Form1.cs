using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CityInformation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool searchCity = false;
        private bool searchCountry = false;
        private static string connectionString = @"SERVER=.\SQLEXPRESS;DATABASE=CityInformation_DB;INTEGRATED SECURITY=TRUE";
        private string checkCity;
        SqlConnection connectionLink= new SqlConnection(connectionString);
        CityInfo newCityInfo = new CityInfo();
        private bool updateMode = false;
        private void CityInformation_Load(object sender, EventArgs e)
        {
            LoadCityInformation();
        }

        private void LoadCityInformation()
        {
            string query = "SELECT * FROM CityInformation_Table";
            SqlCommand newCommand = new SqlCommand(query,connectionLink);
            connectionLink.Open();
            SqlDataReader reader = newCommand.ExecuteReader();
            CityInfo selectedCityInfo= new CityInfo();
            List<CityInfo> newCityList = new List<CityInfo>();
            while (reader.Read())
            {
                CityInfo cityRecord= new CityInfo();
                cityRecord.cityName = reader[1].ToString();
                cityRecord.about = reader[2].ToString();
                cityRecord.country = reader[3].ToString();
                newCityList.Add(cityRecord);
            }

            reader.Close();
            connectionLink.Close();
            LoadListView(newCityList);
        }

        private void LoadListView(List<CityInfo> cityList)
        {
            cityDetailsListView.Items.Clear();
            int count = 1;
            foreach (var cityDetails in cityList)
            {
                ListViewItem items=new ListViewItem(count.ToString());
                items.SubItems.Add(cityDetails.cityName);
                items.SubItems.Add(cityDetails.about);
                items.SubItems.Add(cityDetails.country);
                cityDetailsListView.Items.Add(items);
                count++;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (updateMode)
            {
                SetTextValue();
                if (checkCity != cityNameTextBox.Text)
                {
                    MessageBox.Show("You can't Change the city name");
                    updateMode = false;
                    saveButton.Text = "Save";

                }
                else
                {
                    string query = "UPDATE CityInformation_Table SET About='" + newCityInfo.about + "',Country='" +
                                   newCityInfo.country + "' WHERE City_Name='" +
                                   newCityInfo.cityName + "'";
                    SetCityInformation(query);
                    MessageBox.Show("Updated City Information Successfully");
                    updateMode = false;
                    saveButton.Text = "Save";
                }
            }
            else
           {
             SetTextValue();
                if(newCityInfo.cityName.Length < 4)
                {
                MessageBox.Show("City Name is less than four characters");
                 }
            else if (IsCityNameExist(newCityInfo.cityName))
            {
                MessageBox.Show("City Name is already exist");
            }
            else
            {
                string query = "INSERT INTO CityInformation_Table VALUES('"+newCityInfo.cityName+"','"+newCityInfo.about+"','"+newCityInfo.country+"')";
                SetCityInformation(query);
                MessageBox.Show("Save City Information Successfully");

            }
               
             
           }
            ClearAll();
            LoadCityInformation();
        }

        private void SetCityInformation(string query)
        {
            SqlCommand newCmd=new SqlCommand(query,connectionLink);
            connectionLink.Open();
            int roweffect = newCmd.ExecuteNonQuery();
            connectionLink.Close();

        }

        private void SetTextValue()
        {
            newCityInfo.cityName = cityNameTextBox.Text;
            newCityInfo.about = aboutTextBox.Text;
            newCityInfo.country = countryTextBox.Text;
        }


        private bool IsCityNameExist(string newCityName)
        {
            bool result = false;
            string query = "SELECT * FROM CityInformation_Table WHERE City_Name='" + newCityName + "'";
            SqlCommand newCmd= new SqlCommand(query,connectionLink);
            connectionLink.Open();
            SqlDataReader reader = newCmd.ExecuteReader();
            while (reader.Read())
            {
                result = true;
                break;
            }
            reader.Close();
            connectionLink.Close();
            return result;

        }

        private void ClearAll()
        {
            searchTextBox.Text = cityNameTextBox.Text = aboutTextBox.Text = countryTextBox.Text = null;
        }

        private void cityDetailsListView_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem itemSelect = cityDetailsListView.SelectedItems[0];
            string cityName = itemSelect.SubItems[1].Text.ToString();
            CityInfo cityDetails=new CityInfo();
            cityDetails = GetCityDetail(cityName);
            updateMode = true;
           checkCity= cityNameTextBox.Text = cityDetails.cityName;
            aboutTextBox.Text = cityDetails.about;
            countryTextBox.Text = cityDetails.country;
            saveButton.Text = "Update";
        }

        private CityInfo GetCityDetail(string cityName)
        {
            CityInfo infoFind=new CityInfo();
            string query = "SELECT * FROM CityInformation_Table WHERE City_Name='" + cityName + "'";
            SqlCommand newCmd = new SqlCommand(query, connectionLink);
            connectionLink.Open();
            SqlDataReader reader = newCmd.ExecuteReader();
            while (reader.Read())
            {
                infoFind.cityName = reader[1].ToString();
                infoFind.about = reader[2].ToString();
                infoFind.country = reader[3].ToString();
                break;
            }
            reader.Close();
            connectionLink.Close();
            return infoFind;
        }

     
     
        private void searchButton_Click(object sender, EventArgs e)
        {
            
            string searchByText = searchTextBox.Text;
            if (searchCountry)
            {
                Search(searchByText,2);

            }
            else
            {
                Search(searchByText,1);

            }


        }

        private void Search(string searchByText,int operation)
        {
            string query = "SELECT * FROM  CityInformation_Table";
            SqlCommand newCmd= new SqlCommand(query,connectionLink);
            int count = 0;
            
             connectionLink.Open();
            SqlDataReader reader = newCmd.ExecuteReader();
            List<CityInfo> info=new List<CityInfo>();

            if (operation == 1)
            {
                while (reader.Read())
                {
                    CityInfo infoGet = new CityInfo();
                    if (reader[1].ToString().Contains(searchByText) || reader[1].ToString().Contains(searchByText.ToUpper()) || reader[1].ToString().Contains(searchByText.ToLower()))
                    {
                        infoGet.cityName = reader[1].ToString();
                        infoGet.about = reader[2].ToString();
                        infoGet.country = reader[3].ToString();
                        info.Add(infoGet);
                        count++;
                    }
                   
                    
                }
                reader.Close();
                connectionLink.Close();
                if(count>0)
                LoadListView(info);
                else
                {
                    MessageBox.Show("City is not Found");
                }
            }
            else
            {
                  while (reader.Read())
                {
                    CityInfo infoGet = new CityInfo();
                    if (reader[3].ToString().Contains(searchByText))
                    {
                        infoGet.cityName = reader[1].ToString();
                        infoGet.about = reader[2].ToString();
                        infoGet.country = reader[3].ToString();
                        info.Add(infoGet);
                        count++;
                    }
                   
                    
                }
                reader.Close();
                connectionLink.Close();
                if(count>0)
                LoadListView(info);
                else
                {
                    MessageBox.Show("Country is not Found");
                }
            }
            ClearAll();

        }

       

        private void searchbyCountryRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            searchCountry = true;
            searchCity = false;
        }

        private void searchbyCityRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            searchCity = true;
            searchCountry = false;
        }

    }
}
