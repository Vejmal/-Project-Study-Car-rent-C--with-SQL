using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wypozyczalnia_Samochodow
{
    public partial class DodajKlientow : Form
    {
        private BazaDanychPolaczenie dbConnect;
        private string imie, nazwisko, telefon, login, haslo;
        public DodajKlientow()
        {
            InitializeComponent();
            dbConnect = new BazaDanychPolaczenie();
            //Wyświetlenie listy wszystkich klientów wypożyczalni
            List<string>[] list;
            list = dbConnect.SelectALLKlienci();
        }

        private void dodajklienta_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtImie.Text) || String.IsNullOrEmpty(txtNazwisko.Text) || String.IsNullOrEmpty(txtNumerTelefonu.Text) || String.IsNullOrEmpty(txtLogin.Text) || String.IsNullOrEmpty(txtHaslo.Text))//Jeśli nic nie wpisano to wyświetl kompunikat
            {
                MessageBox.Show("Podano niepoprawne dane!");
            }
            else
            {
                if (txtLogin.Text != "admin" && txtHaslo.Text != "haslo") {
                    imie = txtImie.Text;
                    nazwisko = txtNazwisko.Text;
                    telefon = txtNumerTelefonu.Text;
                    login = txtLogin.Text;
                    haslo = txtHaslo.Text;

                    dbConnect.DodawanieKlientow(imie, nazwisko, telefon, login, haslo);//Przekazuje zmienne do metody dodającej rekord do bazy danych
                    MessageBox.Show("Dodano nowego klienta!");
                    Logowanie lg2 = new Logowanie();
                    this.Hide();
                    lg2.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Nie mozesz miec loginu/hasla admin.");
                }
            }
        }

        private void PowrotDoMenu_Click(object sender, EventArgs e)//Przycisk powrót do menu
        {
            Logowanie l1 = new Logowanie();
            this.Hide();//
            l1.ShowDialog();//Wyswietlanie 2 formularza i ukrywanie bieżącego.
        }

        private void DodajKlientow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();//Po zamknięciu formularza zamykamy aplikacje
        }
    }
}
