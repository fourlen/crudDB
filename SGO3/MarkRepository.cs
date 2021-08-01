using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace SGO3
{
    class MarkRepository
    {
        private string select_all_string = "SELECT * FROM mark";
        private string add_string = "INSERT INTO mark(mark_value, studentid, subjectid) VALUES (@mark_value, @studentid, @subjectid)"; 
        private string update_string = "UPDATE mark SET mark_value = @newmark_value, studentid = @newstudentid, subjectid = @newsubjectid WHERE mark_value = @oldmark_value AND studentid = @oldstudentid AND subjectid = @oldsubjectid";
        private string delete_string = "DELETE FROM mark WHERE mark_value = @mark_value AND studentid = @studentid AND subjectid = @subjectid";
        private NpgsqlConnection conn;
        public MarkRepository(NpgsqlConnection _conn)
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
                cmd.Parameters.AddWithValue("mark_value", Convert.ToInt32(values[0]));
                cmd.Parameters.AddWithValue("studentid", Convert.ToInt32(values[1]));
                cmd.Parameters.AddWithValue("subjectid", Convert.ToInt32(values[2]));
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateString(List<string> oldvalues, List<string> newvalues)
        {
            using (var cmd = new NpgsqlCommand(update_string, conn))
            {
                cmd.Parameters.AddWithValue("newmark_value", Convert.ToInt32(newvalues[0]));
                cmd.Parameters.AddWithValue("newstudentid", Convert.ToInt32(newvalues[1]));
                cmd.Parameters.AddWithValue("newsubjectid", Convert.ToInt32(newvalues[2]));
                cmd.Parameters.AddWithValue("oldmark_value", Convert.ToInt32(oldvalues[0]));
                cmd.Parameters.AddWithValue("oldstudentid", Convert.ToInt32(oldvalues[1]));
                cmd.Parameters.AddWithValue("oldsubjectid", Convert.ToInt32(oldvalues[2]));
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteString(List<string> values)
        {
            using (var cmd = new NpgsqlCommand(delete_string, conn))
            {
                cmd.Parameters.AddWithValue("mark_value", Convert.ToInt32(values[0]));
                cmd.Parameters.AddWithValue("studentid", Convert.ToInt32(values[1]));
                cmd.Parameters.AddWithValue("subjectid", Convert.ToInt32(values[2]));
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
