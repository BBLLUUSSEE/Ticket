using Microsoft.AspNet.SignalR.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket
{
    public class AdoNET
    {
        static string connectionStringSQL = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Ticket;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static void ShowAllTickets()
        {
            using SqlConnection connessione = new SqlConnection(connectionStringSQL);
            try
            {
                connessione.Open();

                if (connessione.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("connected to the database");
                }
                else
                {
                    Console.WriteLine("not connected to the database");
                }

                string insertSQL = $"SELECT * FROM Tickets;";

                SqlCommand comando = new SqlCommand();
                comando.Connection = connessione;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = insertSQL;


                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var id = (int)reader["idTicket"];
                    var data = (DateTime)reader["DataDiCreazione"];
                    var richiedente = (string)reader["Richiedente"];
                    var descrizionebreve = (string)reader["DescrizioneBreve"];
                    var descrizionelunga = (string)reader["DescrizioneLunga"];
                    var categoria = (string)reader["Categoria"];
                    var stato = (string)reader["Stato"];
                    var assegnatario = (string)reader["Assegnatario"];
                    var datadichiusura = (DateTime)reader["DataDiChiusura"];

                    Console.WriteLine($"{id} - {data} - {richiedente} - {descrizionebreve} - {descrizionelunga} - {categoria} - {stato} - {assegnatario} - {datadichiusura}");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Errore SQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
            }
            finally
            {
                connessione.Close();
                Console.WriteLine("connection closed");
            }
        }



        public static void ShowOnlyById()
        {
            using SqlConnection connessione = new SqlConnection(connectionStringSQL);
            try
            {
                connessione.Open();

                if (connessione.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("connected to the database");
                }
                else
                {
                    Console.WriteLine("not connected to the database");
                }

                Console.Write("ID: ");
                int idticket = int.Parse(Console.ReadLine());
                string insertSQL = $"SELECT * FROM Tickets WHERE idTicket = {idticket};";

                SqlCommand comando = new SqlCommand();
                comando.Connection = connessione;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = insertSQL;


                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var id = (int)reader["idTicket"];
                    var data = (DateTime)reader["DataDiCreazione"];
                    var richiedente = (string)reader["Richiedente"];
                    var descrizionebreve = (string)reader["DescrizioneBreve"];
                    var descrizionelunga = (string)reader["DescrizioneLunga"];
                    var categoria = (string)reader["Categoria"];
                    var stato = (string)reader["Stato"];
                    var assegnatario = (string)reader["Assegnatario"];
                    var datadichiusura = (DateTime)reader["DataDiChiusura"];

                    Console.WriteLine($"{id} - {data} - {richiedente} - {descrizionebreve} - {descrizionelunga} - {categoria} - {stato} - {assegnatario} - {datadichiusura}");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Errore SQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
            }
            finally
            {
                connessione.Close();
                Console.WriteLine("connection closed");
            }
        }





        public static void ShowOnlyByStato()
        {
            using SqlConnection connessione = new SqlConnection(connectionStringSQL);
            try
            {
                connessione.Open();

                if (connessione.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("connected to the database");
                }
                else
                {
                    Console.WriteLine("not connected to the database");
                }

                Console.Write("Stato: ");
                string bystato = Console.ReadLine();
                string insertSQL = $"SELECT * FROM Tickets WHERE Stato = '{bystato}';";

                SqlCommand comando = new SqlCommand();
                comando.Connection = connessione;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = insertSQL;


                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var id = (int)reader["idTicket"];
                    var data = (DateTime)reader["DataDiCreazione"];
                    var richiedente = (string)reader["Richiedente"];
                    var descrizionebreve = (string)reader["DescrizioneBreve"];
                    var descrizionelunga = (string)reader["DescrizioneLunga"];
                    var categoria = (string)reader["Categoria"];
                    var stato = (string)reader["Stato"];
                    var assegnatario = (string)reader["Assegnatario"];
                    var datadichiusura = (DateTime)reader["DataDiChiusura"];

                    Console.WriteLine($"{id} - {data} - {richiedente} - {descrizionebreve} - {descrizionelunga} - {categoria} - {stato} - {assegnatario} - {datadichiusura}");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Errore SQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
            }
            finally
            {
                connessione.Close();
                Console.WriteLine("connection closed");
            }
        }







        public static void InsertNewTicket()
        {
            using SqlConnection connessione = new SqlConnection(connectionStringSQL);
            try
            {
                connessione.Open();

                if (connessione.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("connected to the database");
                }
                else
                {
                    Console.WriteLine("not connected to the database");
                }

                SqlCommand insertCommand = new SqlCommand();
                insertCommand.CommandType = System.Data.CommandType.Text;
                insertCommand.CommandText = "INSERT INTO Tickets VALUES(" +
                    "@DataDiCreazione, " +
                    "@Richiedente, " +
                    "@DescrizioneBreve, " +
                    "@DescrizioneLunga, " +
                    "@Categoria, " +
                    "@Stato, " +
                    "@Assegnatario, " +
                    "@DataDiChiusura)";
                Console.WriteLine("-------------Inserire una nuovo ticket-----------");

                Console.Write("Data di creazione: ");
                insertCommand.Parameters.AddWithValue("@DataDiCreazione", DateTime.Now);
                DateTime data = DateTime.Parse(Console.ReadLine());

                Console.Write("Richiedente: ");
                string richiedente = Console.ReadLine();
                insertCommand.Parameters.AddWithValue("@Richiedente", richiedente);

                Console.Write("Descrizione breve: ");
                string descrizionebreve = Console.ReadLine();
                insertCommand.Parameters.AddWithValue("@DescrizioneBreve", descrizionebreve);

                Console.Write("Descrizione lunga: ");
                string descrizionelunga = Console.ReadLine();
                insertCommand.Parameters.AddWithValue("@DescrizioneLunga", descrizionelunga);

                Console.Write("Categoria: ");
                decimal categoria = decimal.Parse(Console.ReadLine());
                insertCommand.Parameters.AddWithValue("@Categoria", categoria);

                Console.Write("Stato: ");
                string stato = Console.ReadLine();
                insertCommand.Parameters.AddWithValue("@Stato", stato);

                Console.Write("Assegnatario: ");
                string assegnatario = Console.ReadLine();
                insertCommand.Parameters.AddWithValue("@Assegnatario", assegnatario);

                Console.Write("Data di chiusura: ");
                insertCommand.Parameters.AddWithValue("@DataDiChiusura", DateTime.Now);
                DateTime datadichiusura = DateTime.Parse(Console.ReadLine());
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Errore SQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
            }
            finally
            {
                connessione.Close();
                Console.WriteLine("connection closed");
            }
        }





        public static void CloseTicket()
        {
            using SqlConnection connessione = new SqlConnection(connectionStringSQL);
            try
            {
                connessione.Open();

                if (connessione.State == System.Data.ConnectionState.Open)
                {
                    Console.WriteLine("connected to the database");
                }
                else
                {
                    Console.WriteLine("not connected to the database");
                }


                Console.Write("Id ticket da chiudere: ");
                int id = int.Parse(Console.ReadLine());
                string insertSQL = $"UPDATE Tickets SET Stato = 'Chiuso' WHERE idTicket = {id}";

                SqlCommand insertCommand = connessione.CreateCommand();
                insertCommand.CommandText = insertSQL;

                int Insert = insertCommand.ExecuteNonQuery();

                if (Insert >= 1)
                {
                    Console.WriteLine($"{Insert} expense has been updated correctly");
                }
                else
                {
                    Console.WriteLine("something went wrong, check your expense");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Errore SQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore: {ex.Message}");
            }
            finally
            {
                connessione.Close();
                Console.WriteLine("connection closed");
            }
        }
    }
}
