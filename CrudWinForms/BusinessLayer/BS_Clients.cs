using DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessLayer
{
    public class BS_Clients
    {
        DL_Clients dl_Clients = new DL_Clients();

        //Get the data from the DB
        public DataTable ShowData()
        {
            DataTable table = new DataTable();
            table = dl_Clients.Show();

            return table;
        }

        public string InsertData(string firstName, string lastName, string email, string phone, string idDocument)
        {
            return dl_Clients.Insert(firstName, lastName, email, phone, idDocument);
        }

        public string UpdateData(string id, string firstName, string lastName, string email, string phone, string idDocument)
        {
            return dl_Clients.Update(id, firstName, lastName, email, phone, idDocument);
        }

        public string DeleteData(string id)
        {
            return dl_Clients.Delete(id);
        }

        public DataTable SearchData(string searchKeyword, string column)
        {
            return dl_Clients.Search(searchKeyword, column);
        }
    }
}
