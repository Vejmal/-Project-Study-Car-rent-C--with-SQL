using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
//Add MySql Library
using MySql.Data.MySqlClient;

namespace Wypozyczalnia_Samochodow
{
    class BazaDanychPolaczenie
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //baza danych wypozyczarka.sql - lokalna

        #region Inicjalizacja łącza z bazą
        //Konstruktor
        public BazaDanychPolaczenie()
        {
            Initialize();
        }
        private void Initialize()
        {
            server = "127.0.0.1";//adres localhost 
            database = "wypozyczarka";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }
        #endregion
        #region OpenConnection
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                //MessageBox.Show("Zostales polaczony z serwerem.");
                return true;
            }
            catch (MySqlException)//Zastosowanie wyjątku w razie braku połączenia z bazą danych
                {
                    MessageBox.Show("Problem z połączeniem do BazyDanych.\nSprawdź połączenie internetowe \nSkontaktuj się z administratorem!");
                }
            return false;
        }
        #endregion
        #region CloseConnection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);//Wyjątek na nie zamknięcie połączenia
                return false;
            }
        }
        #endregion

        //administracja danymi

        #region Pokaż wszystkie pojazdy
        //Query jest napisane głownie pod formularze gdzie potrzeba zwrócić dane wszystkich aut
        public List<string>[] SelectWszystkie()
        {
            string query = "SELECT * FROM naszesamochody";


            //Create a list to store the result
            List<string>[] list = new List<string>[11];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();
            list[4] = new List<string>();
            list[5] = new List<string>();
            list[6] = new List<string>();
            list[7] = new List<string>();
            list[8] = new List<string>();
            list[9] = new List<string>();
            list[10] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["idSamochodu"] + "");
                    list[1].Add(dataReader["Marka"] + "");
                    list[2].Add(dataReader["Model"] + "");
                    list[3].Add(dataReader["Kolor"] + "");
                    list[4].Add(dataReader["Rocznik"] + "");
                    list[5].Add(dataReader["Silnik"] + "");
                    list[6].Add(dataReader["Moc"] + "");
                    list[7].Add(dataReader["od 0 do 100"] + "");
                    list[8].Add(dataReader["Ilosc miejsc"] + "");
                    list[9].Add(dataReader["CenaZaGodzine"] + "");
                    list[10].Add(dataReader["Dostepnosc"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }

        }
        #endregion
        #region Dodaj pojazd
        public void DodawanieSamochodow(string marka, string model, string kolor, int rocznik, float cena)
        {
            string query = "INSERT INTO NaszeSamochody (Marka,Model,Kolor,Rocznik,CenaZaGodzine) VALUES('" + marka + "','" + model + "','" + kolor + "'," + rocznik + "," + cena + ")";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
        #endregion //do kasacji
        #region Usuń pojazd
        public void UsuwanieSamochodow(int idUsuwane)
        {
            string query = "delete from NaszeSamochody WHERE idSamochodu=('" + idUsuwane + "')";
            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
        #endregion  // do kasacji
        #region Dodawanie nowych Klientów
        public void DodawanieKlientow(string imie, string nazwisko, string telefon, string login, string haslo)
        {
            string query = "INSERT INTO Klienci (Imie,Nazwisko,NumerTelefonu,Login,Haslo) VALUES('" + imie + "','" + nazwisko + "','" + telefon + "','" + login + "','" + haslo + "')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
        #endregion
        #region Usuwanie klientów z bazy
        public void UsuwanieKlientow(int idKlientaUsuwanego)
        {
            string query = "delete from Klienci WHERE idKlienta=('" + idKlientaUsuwanego + "')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
        #endregion
        #region Wypożycz pojazd dla klienta
        public void WypozyczanieSamochodow(int idKlienta, int idSamochodu, int NaIleGodzin)
        {
            string query = "INSERT INTO wypozyczenia (idSamochodu,idKlienta,Data Od, Data Do) VALUES ('" + idSamochodu + "','" + idKlienta + "','" + NaIleGodzin + "')";
            string query2 = "UPDATE NaszeSamochody Set Dostepnosc = 'Niedostępny' where idSamochodu = ('" + idSamochodu + "')";
            //Przy wypożyczeniu samochodu dla klienta dodajemy nowy wpis wypozyczenia do bazy (query)
            //Dodatkowo każdy nowo wypożyczony samochód otrzymuje status "Niedostępny"
            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlCommand cmd2 = new MySqlCommand(query2, connection);

                //Execute command
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
        #endregion
        #region Zmiana statusu pojazdu - dostepny/niedostepny
        public void ZmianaStatusu(int IdZmiany, string Status)
        {
            string query2 = "UPDATE naszesamochody SET Dostepnosc=('" + Status + "') WHERE naszesamochody.idSamochodu=( SELECT wypozyczenia.idSamochodu FROM wypozyczenia WHERE wypozyczenia.idWypozyczenia=('" + IdZmiany + "'))";
            //Query służy do określenia czy samochód wypożyczony został zwrócony do Wypożyczalni
            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd2 = new MySqlCommand(query2, connection);

                //Execute command
                cmd2.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
        #endregion
        #region Pokaż klientów
        public List<string>[] SelectALLKlienci()
        {
            string query = "SELECT * FROM Klienci";

            //Create a list to store the result
            List<string>[] list = new List<string>[4];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["idKlienta"] + "");
                    list[1].Add(dataReader["Imie"] + "");
                    list[2].Add(dataReader["Nazwisko"] + "");
                    list[3].Add(dataReader["NumerTelefonu"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }
        #endregion
        #region Wyświetl wypożyczenia
        public List<string>[] PokazWypozyczenia()
        {
            string query = "SELECT Wypozyczenia.idWypozyczenia, NaszeSamochody.Marka, NaszeSamochody.Model, Klienci.Imie, Klienci.Nazwisko, Wypozyczenia.NaIleGodzin, NaszeSamochody.CzyZwrocono FROM NaszeSamochody INNER JOIN (Klienci INNER JOIN Wypozyczenia ON Klienci.IdKlienta = Wypozyczenia.idKlienta) ON NaszeSamochody.idSamochodu = Wypozyczenia.idSamochodu";
            //Create a list to store the result
            List<string>[] list = new List<string>[7];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();
            list[4] = new List<string>();
            list[5] = new List<string>();
            list[6] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["idWypozyczenia"] + "");
                    list[1].Add(dataReader["Marka"] + "");
                    list[2].Add(dataReader["Model"] + "");
                    list[3].Add(dataReader["Imie"] + "");
                    list[4].Add(dataReader["Nazwisko"] + "");
                    list[5].Add(dataReader["NaIleGodzin"] + "");
                    list[6].Add(dataReader["CzyZwrocono"] + "");

                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }
        #endregion

        

    }
        
}