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
    class Subject_resault_typeRepository
    {
        private string select_all_string = "SELECT * FROM subject_resault_type";
        private string add_string = "INSERT INTO subject_resault_type(name, is_gradable) VALUES (@name, @is_gradable)";
        private string update_string = "UPDATE subject_resault_type SET name = @newname, is_gradable = @newis_gradable WHERE id = @id AND name = @oldname AND is_gradable = @oldis_gradable";
        private string delete_string = "DELETE FROM subject_resault_type WHERE id = @id AND name = @name AND is_gradable = @is_gradable";
        private NpgsqlConnection conn;
        public Subject_resault_typeRepository(NpgsqlConnection _conn)
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
                
                try
                {
                    cmd.Parameters.AddWithValue("name", values[1]);
                    cmd.Parameters.AddWithValue("is_gradable", Convert.ToBoolean(values[2]));
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
                    cmd.Parameters.AddWithValue("newname", newvalues[1]);
                    cmd.Parameters.AddWithValue("newis_gradable", Convert.ToBoolean(newvalues[2]));
                    cmd.Parameters.AddWithValue("id", Convert.ToInt32(oldvalues[0]));
                    cmd.Parameters.AddWithValue("oldname", oldvalues[1]);
                    cmd.Parameters.AddWithValue("oldis_gradable", Convert.ToBoolean(oldvalues[2]));
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
                    cmd.Parameters.AddWithValue("is_gradable", Convert.ToBoolean(values[2]));
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
