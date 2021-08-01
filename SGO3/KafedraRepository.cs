using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace SGO3
{
    class KafedraRepository
    {
        private string select_all_string = "SELECT * FROM kafedra";
        private string add_string = "INSERT INTO kafedra(name, faculty_id, boss) VALUES (@name, @faculty_id, @boss)";
        private string update_string = "UPDATE kafedra SET name = @newname, faculty_id = @newfaculty_id, boss = @newboss WHERE id = @id AND name = @oldname AND faculty_id = @oldfaculty_id AND boss = @oldboss";
        private string delete_string = "DELETE FROM kafedra WHERE id = @id AND name = @name AND faculty_id = @faculty_id AND boss = @boss";
        private NpgsqlConnection conn;
        public KafedraRepository(NpgsqlConnection _conn)
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
                cmd.Parameters.AddWithValue("name", values[1]);
                cmd.Parameters.AddWithValue("faculty_id", Convert.ToInt32(values[2]));
                cmd.Parameters.AddWithValue("boss", Convert.ToInt32(values[3]));
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateString(List<string> oldvalues, List<string> newvalues)
        {
            using (var cmd = new NpgsqlCommand(update_string, conn))
            {
                cmd.Parameters.AddWithValue("newname", newvalues[1]);
                cmd.Parameters.AddWithValue("newfaculty_id", Convert.ToInt32(newvalues[2]));
                cmd.Parameters.AddWithValue("newboss", Convert.ToInt32(newvalues[3]));
                cmd.Parameters.AddWithValue("id", Convert.ToInt32(oldvalues[0]));
                cmd.Parameters.AddWithValue("oldname", oldvalues[1]);
                cmd.Parameters.AddWithValue("oldfaculty_id", Convert.ToInt32(oldvalues[2]));
                cmd.Parameters.AddWithValue("oldboss", Convert.ToInt32(oldvalues[3]));
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteString(List<string> values)
        {
            using (var cmd = new NpgsqlCommand(delete_string, conn))
            {
                cmd.Parameters.AddWithValue("id", Convert.ToInt32(values[0]));
                cmd.Parameters.AddWithValue("name", values[1]);
                cmd.Parameters.AddWithValue("faculty_id", Convert.ToInt32(values[2]));
                cmd.Parameters.AddWithValue("boss", Convert.ToInt32(values[3]));
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
