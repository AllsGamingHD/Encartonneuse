using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Encartonneuse
{
    class BDD
    {
        MySqlConnection dbConnect = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=encartonneuse");
        MySqlDataAdapter SQL_Data = new MySqlDataAdapter();
        MySqlCommand SQL_CMD;

        public void Connect()
        {
            try
            {
                dbConnect.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToLower());
            }
        }

        public void Disconnect()
        {
            try
            {
                dbConnect.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToLower());
            }
        }


        public void send_data(bool conforme, int bouteillePos, int ranger)
        {
            try
            {
                SQL_CMD = new MySqlCommand("INSERT INTO `bouteilles` (`conforme`, `heure`, `position`, `ranger`) VALUES ('" + conforme + "', '" + DateTime.Now.ToShortDateString() + "', '" + bouteillePos + "', '" + ranger + "')", dbConnect);

                SQL_Data.SelectCommand = SQL_CMD;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToLower());
            }
        }

        // Affichage de données
        public void Acquisition_Données(string table)
        {
            try
            {
                SQL_CMD = new MySqlCommand("SELECT * FROM `" + table + "`", dbConnect);

                SQL_Data.SelectCommand = SQL_CMD;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToLower());
            }
        }
    }
}
