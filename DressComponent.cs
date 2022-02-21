using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;


namespace BoutiqueShop
{
    public class DressComponent
    {
        static string CONNECTIONSTRING = @"Data Source=RILPT171;Initial Catalog=Shop;User ID=sa;Password=sa123";

       

        public  List<DressClass> GetAllDresses()
        {
            var list = new List<DressClass>();
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                try
                {
                    con.Open();
                    SqlCommand sqlCmd = con.CreateCommand();
                    sqlCmd.CommandText = "SELECT * FROM Boutique";
                    var reader = sqlCmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var Bout = new DressClass();
                        Bout.DressId = Convert.ToInt32(reader[0]);
                        Bout.DressName = reader[1].ToString();
                        Bout.DressType = reader[2].ToString();
                        Bout.Dressprice = Convert.ToInt32(reader[3]);
                        list.Add(Bout);
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
            return list;
        }

        
        public void AddNewDress(DressClass Boutique)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                var query = "INSERT INTO Boutique VALUES(@DressId,@DressName,@Dresstype,@DressPrice)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DressId",Boutique.DressId);
                cmd.Parameters.AddWithValue("@DressName",Boutique.DressName);
                cmd.Parameters.AddWithValue("@DressType", Boutique.DressType);
                cmd.Parameters.AddWithValue("@DressPrice",Boutique.Dressprice);
                try
                {
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new Exception(" Dresses not added!");
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public void UpdateDress(DressClass Boutique)
        {
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                var query = $"UPDATE Boutique set DressName= '{ Boutique.DressName  }', dressType = '{Boutique.DressType}', DressPrice = '{Boutique.Dressprice}'" +
                    $"" +
                    $" WHERE MovieId = {Boutique.DressId}";
                SqlCommand cmd = new SqlCommand(query, con);
                try
                {
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new Exception("No Dress Details were updated");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public void DeleteDress(int id)
        {
            DressClass dressClass = new DressClass();
            using (SqlConnection con = new SqlConnection(CONNECTIONSTRING))
            {
                try
                {
                    con.Open();
                    var cmd = con.CreateCommand();
                    cmd.CommandText = "DELETE FROM Boutique WHERE DressId = " + id;
                    int affectedRows = cmd.ExecuteNonQuery();
                    if (affectedRows == 0)
                        throw new Exception("Cannot Delete Dress");
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }

}
