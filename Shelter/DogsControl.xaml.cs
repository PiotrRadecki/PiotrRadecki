using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Shelter
{
    /// <summary>
    /// Logika interakcji dla klasy DogsControl.xaml
    /// </summary>
    public partial class DogsControl : UserControl
    {
        public DogsControl()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FHKBTLQ;Initial Catalog=Pets;Integrated Security=True");

        public void clearData()
        {
            dogName_txt.Clear();
            dogBreed_txt.Clear();
            dogDominateColor_txt.Clear();
            dogSize_txt.Clear();
            dogSearch_txt.Clear();
        }

        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Dogs", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            dogDatagrid.ItemsSource = dt.DefaultView;
        }

        private void dogClearBtn_Click(object sender, RoutedEventArgs e)
        {
            clearData();
        }

        public bool isValid()
        {
            if (dogName_txt.Text == String.Empty)
            {
                MessageBox.Show("Name is required", "Filed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (dogBreed_txt.Text == String.Empty)
            {
                MessageBox.Show("Breed is required", "Filed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (dogDominateColor_txt.Text == String.Empty)
            {
                MessageBox.Show("Dominate color is required", "Filed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (dogSize_txt.Text == String.Empty)
            {
                MessageBox.Show("Size is required", "Filed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void dogInsertBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isValid())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Dogs VALUES (@Name, @Breed, @DominateColor, @SizeCategory)");
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Name", dogName_txt.Text);
                    cmd.Parameters.AddWithValue("@Breed", dogBreed_txt.Text);
                    cmd.Parameters.AddWithValue("@DominateColor", dogDominateColor_txt.Text);
                    cmd.Parameters.AddWithValue("@SizeCategory", dogSize_txt.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    LoadGrid();
                    MessageBox.Show("Succesfully registered", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                    clearData();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dogDeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Dogs WHERE ID = " + dogSearch_txt.Text + " ", con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record has been deleted", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                con.Close();
                clearData();
                LoadGrid();
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Not Deleted" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void dogUpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Dogs set Name = '" + dogName_txt.Text + "', Breed = '" + dogBreed_txt.Text + "', DominateColor = '" + dogDominateColor_txt.Text + "', SizeCategory = '" + dogSize_txt.Text + "' WHERE ID = '" + dogSearch_txt.Text + "' ", con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record has been updated successfully", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                clearData();
                LoadGrid();
            }
        }
    }
}
