using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using System.Data;

namespace Shelter
{
    /// <summary>
    /// Logika interakcji dla klasy CatsControl.xaml
    /// </summary>
    public partial class CatsControl : UserControl
    {
        List<Cats> listOfCats = new List<Cats>();
        public CatsControl()
        {
            InitializeComponent();
            catDataGrid.ItemsSource = listOfCats;
            LoadGrid();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FHKBTLQ;Initial Catalog=Pets;Integrated Security=True");

        private void catInsertBtn_Click(object sender, RoutedEventArgs e)
        {
            CatsProperties catsProperties = new CatsProperties();
            Cats cats = new Cats();
            catsProperties.DataContext = cats;
            catsProperties.ShowDialog();
            if (catsProperties.IsPressedOk) {
                listOfCats.Add(cats);
                catDataGrid.Items.Refresh();
            }
            //    try
            //    {
            //        if (isValid())
            //        {
            //            SqlCommand cmd = new SqlCommand("INSERT INTO Cats VALUES (@Name, @Breed, @DominateColor, @SizeCategory)");
            //            cmd.Connection = con;
            //            cmd.CommandType = CommandType.Text;
            //            cmd.Parameters.AddWithValue("@Name", catName_txt.Text);
            //            cmd.Parameters.AddWithValue("@Breed", catBreed_txt.Text);
            //            cmd.Parameters.AddWithValue("@DominateColor", catDominateColor_txt.Text);
            //            cmd.Parameters.AddWithValue("@SizeCategory", catSize_txt.Text);
            //            con.Open();
            //            cmd.ExecuteNonQuery();
            //            con.Close();
            //            LoadGrid();
            //            MessageBox.Show("Succesfully registered", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
            //            clearData();
            //        }
            //    }
            //    catch (SqlException ex) 
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
        }

        private void catUpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (catDataGrid.SelectedItem != null)
            {
                CatsProperties catsProperties = new CatsProperties();
                Cats cats = new Cats((Cats)catDataGrid.SelectedItem);
                catsProperties.DataContext = cats;
                catsProperties.ShowDialog();
                int index = listOfCats.IndexOf((Cats)catDataGrid.SelectedItem);
                if (catsProperties.IsPressedOk)
                {
                    listOfCats[index] = cats;
                    catDataGrid.Items.Refresh();
                }
            }
        }
        // private void catDeleteBtn_Click(object sender, RoutedEventArgs e)
        // {

        // }

        //public void clearData()
        //{
        //    catName_txt.Clear();
        //    catBreed_txt.Clear();
        //    catDominateColor_txt.Clear();
        //    catSize_txt.Clear();
        //    catSearch_txt.Clear();
        //}

        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Cats", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            catDataGrid.ItemsSource = dt.DefaultView;
        }

        //private void catClearBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    clearData();
        //}

        //public bool isValid()
        //{
        //    if (catName_txt.Text == String.Empty)
        //    {
        //        MessageBox.Show("Name is required", "Filed", MessageBoxButton.OK, MessageBoxImage.Error);
        //        return false;
        //    }
        //    if (catBreed_txt.Text == String.Empty)
        //    {
        //        MessageBox.Show("Breed is required", "Filed", MessageBoxButton.OK, MessageBoxImage.Error);
        //        return false;
        //    }
        //    if (catDominateColor_txt.Text == String.Empty)
        //    {
        //        MessageBox.Show("Dominate color is required", "Filed", MessageBoxButton.OK, MessageBoxImage.Error);
        //        return false;
        //    }
        //    if (catSize_txt.Text == String.Empty)
        //    {
        //        MessageBox.Show("Size is required", "Filed", MessageBoxButton.OK, MessageBoxImage.Error);
        //        return false;
        //    }
        //    return true;
        //}
        //private void catInsertBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        if (isValid())
        //        {
        //            SqlCommand cmd = new SqlCommand("INSERT INTO Cats VALUES (@Name, @Breed, @DominateColor, @SizeCategory)");
        //            cmd.Connection = con;
        //            cmd.CommandType = CommandType.Text;
        //            cmd.Parameters.AddWithValue("@Name", catName_txt.Text);
        //            cmd.Parameters.AddWithValue("@Breed", catBreed_txt.Text);
        //            cmd.Parameters.AddWithValue("@DominateColor", catDominateColor_txt.Text);
        //            cmd.Parameters.AddWithValue("@SizeCategory", catSize_txt.Text);
        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //            con.Close();
        //            LoadGrid();
        //            MessageBox.Show("Succesfully registered", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
        //            clearData();
        //        }
        //    }
        //    catch (SqlException ex) 
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void catDeleteBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("DELETE FROM Cats WHERE ID = " +catSearch_txt.Text+ " ", con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        MessageBox.Show("Record has been deleted", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
        //        con.Close();
        //        clearData();
        //        LoadGrid();
        //        con.Close();
        //    }
        //    catch (SqlException ex) 
        //    {
        //        MessageBox.Show("Not Deleted" +ex.Message);
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}

        //private void catUpdateBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("UPDATE Cats set Name = '"+catName_txt.Text+"', Breed = '"+catBreed_txt.Text+"', DominateColor = '"+catDominateColor_txt.Text+"', SizeCategory = '"+catSize_txt.Text+"' WHERE ID = '"+catSearch_txt.Text+"' ", con);
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        MessageBox.Show("Record has been updated successfully", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);
        //    } catch (SqlException ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        con.Close();
        //        clearData();
        //        LoadGrid();
        //    }
        //}
    }
}
