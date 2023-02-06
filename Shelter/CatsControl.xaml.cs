using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Globalization;

namespace Shelter
{
    /// <summary>
    /// Logika interakcji dla klasy CatsControl.xaml, INotifyPropertyChanged
    /// </summary>
    public partial class CatsControl : UserControl
    {


        public CatsControl()
        {
            InitializeComponent();
            LoadGrid();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static class Globals
        {
            public static SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FHKBTLQ;Initial Catalog=Pets;Integrated Security=True");
        }
           

        public void LoadGrid()
        {
            //"GETDATA"
            SqlCommand cmd = new SqlCommand("select * from Cats", Globals.con);
            Globals.con.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("Cats");
            dataAdapter.Fill(dt);
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            Globals.con.Close();
            catDataGrid.ItemsSource = dt.DefaultView;
        }
        public void catInsertBtn_Click(object sender, RoutedEventArgs e)
        {
            CatsProperties catsProperties = new CatsProperties();
            Cats cats = new Cats();
            catsProperties.DataContext = cats;
            catsProperties.ShowDialog();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }


        public void catDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            CatsProperties catsProperties = new CatsProperties();
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            if (dr != null)
            {
                catsProperties.cat_Id.Text = dr["ID"].ToString();
                catsProperties.cat_Name.Text = dr["Name"].ToString();
                catsProperties.cat_Breed.Text = dr["Breed"].ToString();
                catsProperties.cat_DominateColor.Text = dr["DominateColor"].ToString();
                catsProperties.cat_Size.Text = dr["SizeCategory"].ToString();
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

