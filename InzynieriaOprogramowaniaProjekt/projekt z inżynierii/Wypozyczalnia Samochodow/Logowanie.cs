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
    public partial class Logowanie : Form
    {
        MySqlConnection con = new MySqlConnection(@"Data source=127.0.0.1;Initial Catalog=wypozyczarka;user id=root;password=''");
        
        int i;

        public Logowanie() //wstepna inicjalizacja polaczenia, mozna podpiac ewentualnie te z bazadanych.cs
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //Zarejestruj się
        {
            DodajKlientow dk1 = new DodajKlientow();
            this.Hide();
            dk1.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e) //Zaloguj sie
        {
            con.Open();
            i = 0;
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText="select * from klienci where Login='"+textBox1.Text+"' and Haslo='"+textBox2.Text+"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());
                 
            if (textBox1.Text == "admin" && textBox2.Text == "admin")
             {
                StronaGlowna sg7 = new StronaGlowna();
                this.Hide();
                sg7.ShowDialog();
            }
            else if (i == 0)
            {
                MessageBox.Show("Błędny login lub hasło, spróbuj ponownie!");
            }
            else
            {
                StronaGlowna sg3 = new StronaGlowna();
                this.Hide();
                sg3.ShowDialog();
            }
            con.Close();
        }
    }
}