/*                  GROUP 2 FINAL PROJECT : TARNEEB GAME
 * EDWARD, NAJEEBULLA, AYESHA, RAMONA, MICHAELA 
 * 2021-04-16
 * PROF: ALAADIN ADDAS 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls; 
using System.Data.SqlClient;

/// <summary>
/// Tarneeb project name space 
/// </summary>
namespace TarneebSandbox
{
    /// <summary>
    /// class responsible for adding game logs with database 
    /// </summary>
    class Gameplay_db : UserControl
    {
        /// <summary>
        /// constructor 
        /// </summary>
        public Gameplay_db()
        {
            
        }
        //should return a random number
        public int random()
        {
            Random rand = new Random();
            int number = rand.Next();
            return number;
        }
        /// <summary>
        /// method used to add game log into the database 
        /// </summary>
        /// <param name="player_name"></param>
        /// <param name="date_time"></param>
        /// <param name="suit_played"></param>
        /// <param name="card_played"></param>
        public void AddGameToLog(String player_name, DateTime date_time, String suit_played, String card_played)
        {
            try
            {
                String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;
                                AttachDbFilename=|DataDirectory|\Tarneeb_db.mdf;
                                Integrated Security=True;Connect Timeout=30";
                //We added the data source to our settings in order to achieve this.
                //creating a new connection.
                SqlConnection cn = new SqlConnection(connectionString);
                //opening the connection
                cn.Open();


                string insertQuery = "INSERT " +
                    "INTO tbl_gamelog ( player_name, date_time, suit_played,card_played) " +
                    "VALUES(" +
                    player_name + "," +
                    date_time + "," +
                    suit_played + "," +
                    card_played + "," +
                    player_name + ")";
                //creating a new command and passing it the query + the connection.
                SqlCommand command = new SqlCommand(insertQuery, cn);
                //executing the query. 
                command.ExecuteNonQuery();
                //closing the connection (good practice).
                cn.Close();
                //Show a pop up message box if the record was added successfully.
                MessageBox.Show(" Successfully logged data.");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}