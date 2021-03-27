using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class Form1 : Form
    {
        BS_Clients bs_Clients = new BS_Clients();
        bool editClicked = false;

        public Form1()
        {
            InitializeComponent();
        }

        //Refreshes the DB table
        void RefreshTable()
        {
            dataGridViewDBTable.DataSource = bs_Clients.ShowData();
        }
        
        void ClearTextBoxes()
        {
            txtbFirstName.Text = "";
            txtbLastName.Text = "";
            txtbEmail.Text = "";
            txtbPhone.Text = "";
            txtbIdDocument.Text = "";

            editClicked = false;
            lbTextFields.Text = "Insert New Data";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshTable();

            cbSearchFilters.Items.Add("-");
            cbSearchFilters.Items.Add("ID");
            cbSearchFilters.Items.Add("First Name");
            cbSearchFilters.Items.Add("Last Name");
            cbSearchFilters.Items.Add("Email");
            cbSearchFilters.Items.Add("Phone");
            cbSearchFilters.Items.Add("ID Document");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Shows a message box if the changes were succesfully added or not
            if (!editClicked)
                MessageBox.Show(bs_Clients.InsertData(txtbFirstName.Text, txtbLastName.Text, txtbEmail.Text, txtbPhone.Text, txtbIdDocument.Text));
            else
            {
                MessageBox.Show(bs_Clients.UpdateData(dataGridViewDBTable.SelectedCells[0].Value.ToString(), txtbFirstName.Text, txtbLastName.Text, txtbEmail.Text, txtbPhone.Text, txtbIdDocument.Text));
                
                editClicked = false;
            }                

            ClearTextBoxes();
            RefreshTable();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            lbTextFields.Text = "Editing Existing Data";
            editClicked = true;

            txtbFirstName.Text = dataGridViewDBTable.SelectedCells[1].Value.ToString();
            txtbLastName.Text = dataGridViewDBTable.SelectedCells[2].Value.ToString();
            txtbEmail.Text = dataGridViewDBTable.SelectedCells[3].Value.ToString();
            txtbPhone.Text = dataGridViewDBTable.SelectedCells[4].Value.ToString();
            txtbIdDocument.Text = dataGridViewDBTable.SelectedCells[5].Value.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show(bs_Clients.DeleteData(dataGridViewDBTable.SelectedCells[0].Value.ToString()));

            RefreshTable();
        }
    }
}
