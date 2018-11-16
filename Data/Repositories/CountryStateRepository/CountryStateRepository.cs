using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.ProfileRepositories
{
    public class CountryStateRepository
    {

        public void CreateState(State state)
        {
            SqlConnection sqlConnection;
            sqlConnection = new SqlConnection("Server=tcp:douginfnet.database.windows.net,1433;Initial Catalog=HortaDB;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            sqlConnection.Open();

            //######### INSERE NOVO PROFILE ##########
            SqlCommand sqlCommandCreateState;
            sqlCommandCreateState = new SqlCommand("AddState", sqlConnection);
            sqlCommandCreateState.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommandCreateState.Parameters.AddWithValue("Id", state.Id);
            sqlCommandCreateState.Parameters.AddWithValue("Name", state.Name);
            sqlCommandCreateState.Parameters.AddWithValue("Birthday", state.Flag);
            sqlCommandCreateState.ExecuteNonQuery();
            //########################################

            sqlConnection.Close();
        }

        public void CreateCountry(Country country)
        {
            SqlConnection sqlConnection;
            sqlConnection = new SqlConnection("Server=tcp:douginfnet.database.windows.net,1433;Initial Catalog=HortaDB;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            sqlConnection.Open();

            //######### INSERE NOVO PROFILE ##########
            SqlCommand sqlCommandCreateCountry;
            sqlCommandCreateCountry = new SqlCommand("AddCountry", sqlConnection);
            sqlCommandCreateCountry.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommandCreateCountry.Parameters.AddWithValue("Id", country.Id);
            sqlCommandCreateCountry.Parameters.AddWithValue("Name", country.Name);
            sqlCommandCreateCountry.Parameters.AddWithValue("Birthday", country.Flag);
            sqlCommandCreateCountry.ExecuteNonQuery();
            //########################################

            sqlConnection.Close();
        }

        public void DeleteCountry(Guid id)
        {
            SqlConnection sqlConnection;
            sqlConnection = new SqlConnection("Server=tcp:douginfnet.database.windows.net,1433;Initial Catalog=HortaDB;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            sqlConnection.Open();

            Profile profile = new Profile();
            //######### OBTEM TODOS OS PROFILES ##########
            SqlCommand sqlCommandDeleteCountry;
            sqlCommandDeleteCountry = new SqlCommand("DeleteCountry", sqlConnection);
            sqlCommandDeleteCountry.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommandDeleteCountry.Parameters.AddWithValue("Id", id.ToString());
            sqlCommandDeleteCountry.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public void DeleteState(Guid id)
        {
            SqlConnection sqlConnection;
            sqlConnection = new SqlConnection("Server=tcp:douginfnet.database.windows.net,1433;Initial Catalog=HortaDB;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            sqlConnection.Open();

            Profile profile = new Profile();
            //######### OBTEM TODOS OS PROFILES ##########
            SqlCommand sqlCommandDeleteState;
            sqlCommandDeleteState = new SqlCommand("DeleteState", sqlConnection);
            sqlCommandDeleteState.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommandDeleteState.Parameters.AddWithValue("Id", id.ToString());
            sqlCommandDeleteState.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public Country GetCountry(Guid? id)
        {
            SqlConnection sqlConnection;
            sqlConnection = new SqlConnection("Server=tcp:douginfnet.database.windows.net,1433;Initial Catalog=HortaDB;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            sqlConnection.Open();

            Country country = new Country();
            //######### OBTEM TODOS OS PROFILES ##########
            SqlCommand sqlCommandGetCountry;
            sqlCommandGetCountry = new SqlCommand("GetCountry", sqlConnection);
            sqlCommandGetCountry.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommandGetCountry.Parameters.AddWithValue("Id", id.ToString());
            var reader = sqlCommandGetCountry.ExecuteReader();

            while (reader.Read())
            {
                country.Id = Guid.Parse(reader["Id"].ToString());
                country.Name = reader["Name"].ToString();
                country.Flag = reader["Flag"].ToString();
            }
            //############################################

            sqlConnection.Close();
            return country;
        }

        public State GetState(Guid? id)
        {
            SqlConnection sqlConnection;
            sqlConnection = new SqlConnection("Server=tcp:douginfnet.database.windows.net,1433;Initial Catalog=HortaDB;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            sqlConnection.Open();

            State state = new State();
            //######### OBTEM TODOS OS PROFILES ##########
            SqlCommand sqlCommandGetState;
            sqlCommandGetState = new SqlCommand("GetCountry", sqlConnection);
            sqlCommandGetState.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommandGetState.Parameters.AddWithValue("Id", id.ToString());
            var reader = sqlCommandGetState.ExecuteReader();

            while (reader.Read())
            {
                state.Id = Guid.Parse(reader["Id"].ToString());
                state.Name = reader["Name"].ToString();
                state.Flag = reader["Flag"].ToString();
            }
            //############################################

            sqlConnection.Close();
            return state;
        }

        public IEnumerable<Profile> GetAll()
        {
            throw new NotImplementedException();
        }

        public void UpdateState(State state)
        {
            throw new NotImplementedException();
        }

        public void UpdateCountry(Country country)
        {
            throw new NotImplementedException();
        }
    }
}