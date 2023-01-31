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
            LoadGrid();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FHKBTLQ;Initial Catalog=Pets;Integrated Security=True");

        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("GETDATA", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            catDataGrid.ItemsSource = dt.DefaultView;
        }
        public void catInsertBtn_Click(object sender, RoutedEventArgs e)
        {
            CatsProperties catsProperties = new CatsProperties();
            Cats cats = new Cats();
            catsProperties.DataContext = cats;
            catsProperties.ShowDialog();
            if (catsProperties.IsPressedOk) {
                listOfCats.Add(cats);
                try
                {
                        SqlCommand cmd = new SqlCommand("INSERTDATA", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Name", SqlDbType.NChar, 20).Value = cats.catName;
                    cmd.Parameters.Add("@Breed", SqlDbType.NChar, 50).Value = cats.catBreed;
                    cmd.Parameters.Add("@DominateColor", SqlDbType.NChar, 50).Value = cats.catDominateColor;
                    cmd.Parameters.Add("@SizeCategory", SqlDbType.NChar, 20).Value = cats.catSize;
                    con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        LoadGrid();
                        MessageBox.Show("Succesfully registered", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catDataGrid.Items.Refresh();


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
    }
}
