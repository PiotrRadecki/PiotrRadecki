using System.Data;
using System.Data.SqlClient;
using System.Windows;
using static Shelter.CatsControl;

namespace Shelter
{
    /// <summary>
    /// Logika interakcji dla klasy CatsProperties.xaml
    /// </summary>
    public partial class CatsProperties : Window
    {
        public bool IsPressedOk { get; set; }
        public CatsProperties()
        {
            InitializeComponent();
        }

		public bool isValid()
		{
			if (cat_Name.Text == string.Empty)
			{
				MessageBox.Show("Name is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}

			if (cat_Breed.Text == string.Empty)
			{
				MessageBox.Show("Genre is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}

			if (cat_DominateColor.Text == string.Empty)
			{
				MessageBox.Show("Cover is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}

			if (cat_Size.Text == string.Empty)
			{
				MessageBox.Show("Language is required", "Failed", MessageBoxButton.OK, MessageBoxImage.Error);
				return false;
			}

			return true;
		}


        private void catAddBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isValid())
                {
                    SqlCommand cmd = new SqlCommand("INSERTDATA", Globals.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Name", SqlDbType.NChar, 20).Value = cat_Name.ToString();
                    cmd.Parameters.Add("@Breed", SqlDbType.NChar, 50).Value = cat_Breed.ToString();
                    cmd.Parameters.Add("@DominateColor", SqlDbType.NChar, 50).Value = cat_DominateColor.ToString();
                    cmd.Parameters.Add("@SizeCategory", SqlDbType.NChar, 20).Value = cat_Size.ToString();
                    CatsControl.Globals.con.Open();
                    cmd.ExecuteNonQuery();
                    CatsControl.Globals.con.Close();
                    CatsControl catsControl = new CatsControl();
                    MessageBox.Show("Succesfully registered", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                    catsControl.catDataGrid.Items.Refresh();
                    catsControl.LoadGrid();
                }
            }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            IsPressedOk = false;
            this.Close();

        }



        private void catCloseBtn_Click(object sender, RoutedEventArgs e)
        {
            IsPressedOk = false;
            this.Close();
        }

        private void catEditBtn_Click(object sender, RoutedEventArgs e)
        {
            CatsControl.Globals.con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Cats set Name = '" + cat_Name.Text + "', Breed = '" + cat_Breed.Text + "', DominateColor = '" + cat_DominateColor.Text + "', SizeCategory = '" + cat_Size.Text + "' WHERE ID = '" + cat_Id.Text + "' ", CatsControl.Globals.con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record has been updated successfully", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);
                CatsControl.Globals.con.Close();
                CatsControl catsControl = new CatsControl();
                catsControl.LoadGrid();
                CatsControl.Globals.con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CatsControl catsControl = new CatsControl();
                catsControl.LoadGrid();
                CatsControl.Globals.con.Close();
                IsPressedOk = false;
                this.Close();
            }
        }
    }
}
