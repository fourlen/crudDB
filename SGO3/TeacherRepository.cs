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
    class TeacherRepository
    {
        private string select_all_string = "SELECT * FROM teacher";
        private string add_string = "INSERT INTO teacher(firstname, middlename, lastname, post, science_degree, kafedra_id) VALUES (@firstname, @middlename, @lastname, @post, @science_degree, @kafedraid)";
        private string update_string = "UPDATE teacher SET firstname = @newfirstname, middlename = @newmiddlename, lastname = @newlastname, post = @newpost, science_degree = @newscience_degree, kafedra_id = @newkafedraid WHERE id = @id AND firstname = @oldfirstname AND middlename = @oldmiddlename AND lastname = @oldlastname AND post = @oldpost AND science_degree = @oldscience_degree AND kafedra_id = @oldkafedraid";
        private string delete_string = "DELETE FROM teacher WHERE id = @id AND firstname = @firstname AND middlename = @middlename AND lastname = @lastname AND post = @post AND science_degree = @science_degree AND kafedra_id = @kafedraid";
        private NpgsqlConnection conn;
        public TeacherRepository(NpgsqlConnection _conn)
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
                    cmd.Parameters.AddWithValue("firstname", values[1]);
                    cmd.Parameters.AddWithValue("middlename", values[2]);
                    cmd.Parameters.AddWithValue("lastname", values[3]);
                    cmd.Parameters.AddWithValue("post", values[4]);
                    cmd.Parameters.AddWithValue("science_degree", values[5]);
                    cmd.Parameters.AddWithValue("kafedraid", Convert.ToInt32(values[6]));
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
                    cmd.Parameters.AddWithValue("newfirstname", newvalues[1]);
                    cmd.Parameters.AddWithValue("newmiddlename", newvalues[2]);
                    cmd.Parameters.AddWithValue("newlastname", newvalues[3]);
                    cmd.Parameters.AddWithValue("newpost", newvalues[4]);
                    cmd.Parameters.AddWithValue("newscience_degree", newvalues[5]);
                    cmd.Parameters.AddWithValue("newkafedraid", Convert.ToInt32(newvalues[6]));
                    cmd.Parameters.AddWithValue("id", Convert.ToInt32(oldvalues[0]));
                    cmd.Parameters.AddWithValue("oldfirstname", oldvalues[1]);
                    cmd.Parameters.AddWithValue("oldmiddlename", oldvalues[2]);
                    cmd.Parameters.AddWithValue("oldlastname", oldvalues[3]);
                    cmd.Parameters.AddWithValue("oldpost", oldvalues[4]);
                    cmd.Parameters.AddWithValue("oldscience_degree", oldvalues[5]);
                    cmd.Parameters.AddWithValue("oldkafedraid", Convert.ToInt32(oldvalues[6]));
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
                    cmd.Parameters.AddWithValue("firstname", values[1]);
                    cmd.Parameters.AddWithValue("middlename", values[2]);
                    cmd.Parameters.AddWithValue("lastname", values[3]);
                    cmd.Parameters.AddWithValue("post", values[4]);
                    cmd.Parameters.AddWithValue("science_degree", values[5]);
                    cmd.Parameters.AddWithValue("kafedraid", Convert.ToInt32(values[6]));
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