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
    class StudentRepository
    {
        private string select_all_string = "SELECT * FROM student";
        private string add_string = "INSERT INTO student(firstname, middlename, lastname, gruppacode) VALUES (@firstname, @middlename, @lastname, @gruppacode)";
        private string update_string = "UPDATE student SET firstname = @newfirstname, middlename = @newmiddlename, lastname = @newlastname, gruppacode = @newgruppacode WHERE id = @id AND firstname = @oldfirstname AND middlename = @oldmiddlename AND lastname = @oldlastname AND gruppacode = @oldgruppacode";
        private string delete_string = "DELETE FROM student WHERE id = @id AND firstname = @firstname AND middlename = @middlename AND lastname = @lastname AND gruppacode = @gruppacode";
        private NpgsqlConnection conn;
        public StudentRepository(NpgsqlConnection _conn)
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
                    cmd.Parameters.AddWithValue("gruppacode", values[4]);
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
                    cmd.Parameters.AddWithValue("newgruppacode", newvalues[4]);
                    cmd.Parameters.AddWithValue("id", Convert.ToInt32(oldvalues[0]));
                    cmd.Parameters.AddWithValue("oldfirstname", oldvalues[1]);
                    cmd.Parameters.AddWithValue("oldmiddlename", oldvalues[2]);
                    cmd.Parameters.AddWithValue("oldlastname", oldvalues[3]);
                    cmd.Parameters.AddWithValue("oldgruppacode", oldvalues[4]);
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
                    cmd.Parameters.AddWithValue("gruppacode", values[4]);
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
