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
    class GruppaRepository
    {
        private string select_all_string = "SELECT * FROM gruppa";
        private string add_string = "INSERT INTO gruppa(code, course, starosta, speciality_code) VALUES (@code, @course, @starosta, @speciality_code)";
        private string update_string = "UPDATE gruppa SET code = @newcode, course = @newcourse, starosta = @newstarosta, speciality_code = @newspeciality_code WHERE code = @oldcode AND course = @oldcourse AND starosta = @oldstarosta AND speciality_code = @oldspeciality_code";
        private string delete_string = "DELETE FROM gruppa WHERE code = @code AND course = @course AND starosta = @starosta AND speciality_code = @speciality_code";
        private NpgsqlConnection conn;
        public GruppaRepository(NpgsqlConnection _conn)
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
                    cmd.Parameters.AddWithValue("code", values[0]);
                    cmd.Parameters.AddWithValue("course", Convert.ToInt32(values[1]));
                    cmd.Parameters.AddWithValue("starosta", values[2]);
                    cmd.Parameters.AddWithValue("speciality_code", values[3]);
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
                    cmd.Parameters.AddWithValue("newcode", newvalues[0]);
                    cmd.Parameters.AddWithValue("newcourse", Convert.ToInt32(newvalues[1]));
                    cmd.Parameters.AddWithValue("newstarosta", newvalues[2]);
                    cmd.Parameters.AddWithValue("newspeciality_code", newvalues[3]);
                    cmd.Parameters.AddWithValue("oldcode", oldvalues[0]);
                    cmd.Parameters.AddWithValue("oldcourse", Convert.ToInt32(oldvalues[1]));
                    cmd.Parameters.AddWithValue("oldstarosta", oldvalues[2]);
                    cmd.Parameters.AddWithValue("oldspeciality_code", oldvalues[3]);
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
                    cmd.Parameters.AddWithValue("code", values[0]);
                    cmd.Parameters.AddWithValue("course", Convert.ToInt32(values[1]));
                    cmd.Parameters.AddWithValue("starosta", values[2]);
                    cmd.Parameters.AddWithValue("speciality_code", values[3]);
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
