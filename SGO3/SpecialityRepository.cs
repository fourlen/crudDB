using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace SGO3
{
    class SpecialityRepository
    {
        private string select_all_string = "SELECT * FROM speciality";
        private string add_string = "INSERT INTO speciality(code, name, kafedraid) VALUES (@code, @name, @kafedraid)";
        private string update_string = "UPDATE speciality SET code = @newcode, name = @newname, kafedraid = @newkafedraid WHERE code = @oldcode AND name = @oldname AND kafedraid = @oldkafedraid";
        private string delete_string = "DELETE FROM speciality WHERE code = @code AND name = @name AND kafedraid = @kafedraid";
        private NpgsqlConnection conn;
        public SpecialityRepository(NpgsqlConnection _conn)
        {
            conn = _conn;
        }

        public DataTable Table()
        {
            var adapter = new NpgsqlDataAdapter(select_all_string, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public void AddNewString(List<string> values)
        {
            using (var cmd = new NpgsqlCommand(add_string, conn))
            {
                cmd.Parameters.AddWithValue("code", values[0]);
                cmd.Parameters.AddWithValue("name", values[1]);
                cmd.Parameters.AddWithValue("kafedraid", Convert.ToInt32(values[2]));
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateString(List<string> oldvalues, List<string> newvalues)
        {
            using (var cmd = new NpgsqlCommand(update_string, conn))
            {
                cmd.Parameters.AddWithValue("newcode", newvalues[0]);
                cmd.Parameters.AddWithValue("newname", newvalues[1]);
                cmd.Parameters.AddWithValue("newkafedraid", Convert.ToInt32(newvalues[2]));
                cmd.Parameters.AddWithValue("oldcode", oldvalues[0]);
                cmd.Parameters.AddWithValue("oldname", oldvalues[1]);
                cmd.Parameters.AddWithValue("oldkafedraid", Convert.ToInt32(oldvalues[2]));
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteString(List<string> values)
        {
            using (var cmd = new NpgsqlCommand(delete_string, conn))
            {
                cmd.Parameters.AddWithValue("code", values[0]);
                cmd.Parameters.AddWithValue("name", values[1]);
                cmd.Parameters.AddWithValue("kafedraid", Convert.ToInt32(values[2]));
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
