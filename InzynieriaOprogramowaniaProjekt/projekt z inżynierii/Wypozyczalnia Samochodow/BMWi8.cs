using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Wypozyczalnia_Samochodow
{
    public partial class BMWi8 : Form
    {
        MySqlConnection con = new MySqlConnection(@"Data source=127.0.0.1;Initial Catalog=wypozyczarka;user id=root;password=''");
        MySqlCommand komenda;
        MySqlDataReader czytnik;
        string zapytanieSQL = "";
        private int idSamochodu, idKlienta, odkiedy, dokiedy;
        public BMWi8()
        {
            InitializeComponent();
        }

        private void PowrótButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guzik1zdjecie_Click(object sender, EventArgs e)
        {

            bmw1zdjecie.Visible = false;
            bmw2zdjecie.Visible = false;
            bmw3zdjecie.Visible = false;
            bmw4zdjecie.Visible = true;
        }

        private void guzik2zdjecie_Click(object sender, EventArgs e)
        {
            bmw1zdjecie.Visible = false;
            bmw2zdjecie.Visible = false;
            bmw3zdjecie.Visible = true;
            bmw4zdjecie.Visible = false;
        }

        private void guzik3zdjecie_Click(object sender, EventArgs e)
        {
            bmw1zdjecie.Visible = false;
            bmw2zdjecie.Visible = true;
            bmw3zdjecie.Visible = false;
            bmw4zdjecie.Visible = false;
        }

        private void guzik4zdjecie_Click(object sender, EventArgs e)
        {
            bmw1zdjecie.Visible = true;
            bmw2zdjecie.Visible = false;
            bmw3zdjecie.Visible = false;
            bmw4zdjecie.Visible = false;
        }

        private void BMWi8_Load(object sender, EventArgs e)
        {

        }

        private void wyswietlinfobmw_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed) //Jak polaczenie mamy zmakniete to otwiera i leci dalej
                    con.Open();

                zapytanieSQL = "select * from naszesamochody where idSamochodu=55";
                komenda = new MySqlCommand(zapytanieSQL, con);
                czytnik = komenda.ExecuteReader();

                BMWlistbox.Items.Clear(); BMWlistbox2.Items.Clear(); BMWlistbox3.Items.Clear(); BMWlistbox4.Items.Clear(); BMWlistbox5.Items.Clear();
                BMWlistbox6.Items.Clear(); BMWlistbox7.Items.Clear(); BMWlistbox8.Items.Clear(); BMWlistbox9.Items.Clear(); BMWlistbox10.Items.Clear();
                //Przed pobraniem czyści dane, by zapobiec nakładaniu się informacji


                if (czytnik.HasRows)
                {
                    
                    while (czytnik.Read())
                    {
                        BMWlistbox.Items.Add(string.Format("Marka: {1}", czytnik[0].ToString(), czytnik["Marka"].ToString()));
                        BMWlistbox2.Items.Add(string.Format("Model: {1}", czytnik[0].ToString(), czytnik["Model"].ToString()));
                        BMWlistbox3.Items.Add(string.Format("Kolor: {1}", czytnik[0].ToString(), czytnik["Kolor"].ToString()));
                        BMWlistbox4.Items.Add(string.Format("Rocznik: {1}", czytnik[0].ToString(), czytnik["Rocznik"].ToString()));
                        BMWlistbox5.Items.Add(string.Format("Silnik: {1}", czytnik[0].ToString(), czytnik["Silnik"].ToString()));
                        BMWlistbox6.Items.Add(string.Format("Moc (KM): {1}", czytnik[0].ToString(), czytnik["Moc"].ToString()));
                        BMWlistbox7.Items.Add(string.Format("Czas 0-100 (sek): {1}", czytnik[0].ToString(), czytnik["od 0 do 100"].ToString()));
                        BMWlistbox8.Items.Add(string.Format("Ilość miejsc: {1}", czytnik[0].ToString(), czytnik["Ilosc miejsc"].ToString()));
                        BMWlistbox9.Items.Add(string.Format("Cena za godzinę: {1}", czytnik[0].ToString(), czytnik["CenaZaGodzine"].ToString()));
                        BMWlistbox10.Items.Add(string.Format("Dostępność: {1}", czytnik[0].ToString(), czytnik["Dostepnosc"].ToString()));





                    }
                    czytnik.Close();
                }

            }
            catch (Exception ex)
            {
                string byk = string.Format("Błąd pobierania danych:\n{0}", ex.Message);
                MessageBox.Show(byk, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void wypozyczbmwi8_Click(object sender, EventArgs e)
        {
           
        }
    }
}
