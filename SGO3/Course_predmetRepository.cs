using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace SGO3
{
    class Course_predmetRepository
    {
        private string select_all_string = "SELECT * FROM course_predmet";
        private string add_string = "INSERT INTO course_predmet(course, speciality_code, subjectid, subject_resault_type_id) VALUES (@course, @speciality_code, @subjectid, @subject_resault_type_id)";
        private string update_string = "UPDATE course_predmet SET course = @newcourse, speciality_code = @newspeciality_code, subjectid = @newsubjectid, subject_resault_type_id = @newsubject_resault_type_id WHERE course = @oldcourse AND speciality_code = @oldspeciality_code AND subjectid = @oldsubjectid AND subject_resault_type_id = @oldsubject_resault_type_id";
        private string delete_string = "DELETE FROM course_predmet WHERE course = @course AND speciality_code = @speciality_code AND subjectid = @subjectid AND subject_resault_type_id = @subject_resault_type_id";
        private NpgsqlConnection conn;
        public Course_predmetRepository(NpgsqlConnection _conn)
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
                cmd.Parameters.AddWithValue("course", Convert.ToInt32(values[0]));
                cmd.Parameters.AddWithValue("speciality_code", values[1]);
                cmd.Parameters.AddWithValue("subjectid", Convert.ToInt32(values[2]));
                cmd.Parameters.AddWithValue("subject_resault_type_id", Convert.ToInt32(values[3]));
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateString(List<string> oldvalues, List<string> newvalues)
        {
            using (var cmd = new NpgsqlCommand(update_string, conn))
            {
                cmd.Parameters.AddWithValue("newcourse", Convert.ToInt32(newvalues[0]));
                cmd.Parameters.AddWithValue("newspeciality_code", newvalues[1]);
                cmd.Parameters.AddWithValue("newsubjectid", Convert.ToInt32(newvalues[2]));
                cmd.Parameters.AddWithValue("newsubject_resault_type_id", Convert.ToInt32(newvalues[3]));
                cmd.Parameters.AddWithValue("oldcourse", Convert.ToInt32(oldvalues[0]));
                cmd.Parameters.AddWithValue("oldspeciality_code", oldvalues[1]);
                cmd.Parameters.AddWithValue("oldsubjectid", Convert.ToInt32(oldvalues[2]));
                cmd.Parameters.AddWithValue("oldsubject_resault_type_id", Convert.ToInt32(oldvalues[3]));
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteString(List<string> values)
        {
            using (var cmd = new NpgsqlCommand(delete_string, conn))
            {
                cmd.Parameters.AddWithValue("course", Convert.ToInt32(values[0]));
                cmd.Parameters.AddWithValue("speciality_code", values[1]);
                cmd.Parameters.AddWithValue("subjectid", Convert.ToInt32(values[2]));
                cmd.Parameters.AddWithValue("subject_resault_type_id", Convert.ToInt32(values[3]));
                cmd.Prepare();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
