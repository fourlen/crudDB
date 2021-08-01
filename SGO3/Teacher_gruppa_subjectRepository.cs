using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace SGO3
{
    class Teacher_gruppa_subjectRepository
    {
        private string select_all_string = "SELECT * FROM teacher_gruppa_subject";
        private string add_string = "INSERT INTO teacher_gruppa_subject(subjectid, gruppacode, teacherid) VALUES (@subjectid, @gruppacode, @teacherid)";
        private string update_string = "UPDATE teacher_gruppa_subject SET subjectid = @newsubjectid, gruppacode = @newgruppacode, teacherid = @newteacherid WHERE subjectid = @oldsubjectid AND gruppacode = @oldgruppacode AND teacherid = @oldteacherid";
        private string delete_string = "DELETE FROM teacher_gruppa_subject WHERE subjectid = @subjectid AND gruppacode = @gruppacode AND teacherid = @teacherid";
        private NpgsqlConnection conn;
        public Teacher_gruppa_subjectRepository(NpgsqlConnection _conn)
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
                cmd.Parameters.AddWithValue("subjectid", Convert.ToInt32(values[0]));
                cmd.Parameters.AddWithValue("gruppacode", values[1]);
                cmd.Parameters.AddWithValue("teacherid", Convert.ToInt32(values[2]));
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateString(List<string> oldvalues, List<string> newvalues)
        {
            using (var cmd = new NpgsqlCommand(update_string, conn))
            {
                cmd.Parameters.AddWithValue("newsubjectid", Convert.ToInt32(newvalues[0]));
                cmd.Parameters.AddWithValue("newgruppacode", newvalues[1]);
                cmd.Parameters.AddWithValue("newteacherid", Convert.ToInt32(newvalues[2]));
                cmd.Parameters.AddWithValue("oldsubjectid", Convert.ToInt32(oldvalues[0]));
                cmd.Parameters.AddWithValue("oldgruppacode", oldvalues[1]);
                cmd.Parameters.AddWithValue("oldteacherid", Convert.ToInt32(oldvalues[2]));
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteString(List<string> values)
        {
            using (var cmd = new NpgsqlCommand(delete_string, conn))
            {
                cmd.Parameters.AddWithValue("subjectid", Convert.ToInt32(values[0]));
                cmd.Parameters.AddWithValue("gruppacode", values[1]);
                cmd.Parameters.AddWithValue("teacherid", Convert.ToInt32(values[2]));
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
