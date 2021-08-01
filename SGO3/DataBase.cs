using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace SGO3
{
    class DataBase
    {
        private static string connString = $"Host=192.168.56.101;Port=5432;Database=Students;Username=student;Password=student";
        private NpgsqlConnection conn = new NpgsqlConnection(connString);

        private FacultyRepository _facultyRepository;
        private Course_predmetRepository _course_predmetRepository;
        private GruppaRepository _gruppaRepository;
        private KafedraRepository _kafedraRepository;
        private MarkRepository _markRepository;
        private SpecialityRepository _specialityRepository;
        private StudentRepository _studentRepository;
        private SubjectRepository _subjectRepository;
        private Subject_resault_typeRepository _subject_Resault_typeRepository;
        private TeacherRepository _teacherRepository;
        private Teacher_gruppa_subjectRepository _teacher_Gruppa_SubjectRepository;
        public DataBase()
        {
            conn.Open();
            _facultyRepository = new FacultyRepository(conn);
            _course_predmetRepository = new Course_predmetRepository(conn);
            _gruppaRepository = new GruppaRepository(conn);
            _kafedraRepository = new KafedraRepository(conn);
            _markRepository = new MarkRepository(conn);
            _specialityRepository = new SpecialityRepository(conn);
            _studentRepository = new StudentRepository(conn);
            _subjectRepository = new SubjectRepository(conn);
            _subject_Resault_typeRepository = new Subject_resault_typeRepository(conn);
            _teacherRepository = new TeacherRepository(conn);
            _teacher_Gruppa_SubjectRepository = new Teacher_gruppa_subjectRepository(conn);
        }

        public FacultyRepository facultyRepository { get => _facultyRepository; }
        public Course_predmetRepository course_PredmetRepository { get => _course_predmetRepository; }
        public GruppaRepository gruppaRepository { get => _gruppaRepository; }
        public KafedraRepository kafedraRepository { get => _kafedraRepository; }
        public MarkRepository markRepository { get => _markRepository; }
        public SpecialityRepository specialityRepository { get => _specialityRepository; }
        public StudentRepository studentRepository { get => _studentRepository; }
        public SubjectRepository subjectRepository { get => _subjectRepository; }
        public Subject_resault_typeRepository subject_Resault_typeRepository { get => _subject_Resault_typeRepository; }
        public TeacherRepository teacherRepository { get => _teacherRepository; }
        public Teacher_gruppa_subjectRepository teacher_Gruppa_SubjectRepository { get => _teacher_Gruppa_SubjectRepository; }
    }
}