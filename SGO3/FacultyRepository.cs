using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
using System.Windows.Forms;

namespace SGO3
{
    class FacultyRepository
    {
        private string select_all_string = "SELECT * FROM faculty";
        private string add_string = "INSERT INTO faculty(name) VALUES (@name)";
        private string update_string = "UPDATE faculty SET name = @newname WHERE id = @id AND name = @oldname";
        private string delete_string = "DELETE FROM faculty WHERE id = @id AND name = @name";
        private NpgsqlConnection conn;
        public FacultyRepository(NpgsqlConnection _conn)
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

        public void AddNewString(string name)
        {
            using (var cmd = new NpgsqlCommand(add_string, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("name", name);
                }
                catch (System.FormatException exc)
                {
                    MessageBox.Show(exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
                catch (Npgsql.PostgresException exc)
                {
                    MessageBox.Show(exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void UpdateString(List<string> oldvalues, List<string> newvalues)
        {
            using (var cmd = new NpgsqlCommand(update_string, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("id", Convert.ToInt32(oldvalues[0]));
                    cmd.Parameters.AddWithValue("oldname", oldvalues[1]);
                    cmd.Parameters.AddWithValue("newname", newvalues[1]);
                }
                catch (System.FormatException exc)
                {
                    MessageBox.Show(exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
                catch (Npgsql.PostgresException exc)
                {
                    MessageBox.Show(exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void DeleteString(List<string> values)
        {
            using (var cmd = new NpgsqlCommand(delete_string, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("id", Convert.ToInt32(values[0]));
                    cmd.Parameters.AddWithValue("name", values[1]);
                }
                catch (System.FormatException exc)
                {
                    MessageBox.Show(exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
                catch (Npgsql.PostgresException exc)
                {
                    MessageBox.Show(exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
