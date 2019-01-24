using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogBook2
{
    public class Data
    {
        public  string Lesson=string.Empty;
        public  int TeacherMaxDiamond { get; set; } = 5;

        public int[] studentsDiamond = new int[8];
        public string[] studentsName =
        {
            "Abdullabayli Saleh Hikmat",
            "Mustafayev Tural Elbrus",
            "Omarov Islam Ilham",
            "Jamalzade Elvin Rasim",
            "Ahmadov Anar Aladdin",
            "Osmanov Samir Akif",
            "Mustafayev Nurullah Hokmuran",
            "Naghiyev Elshan Mirzabala"
        };
        public string[] studentsCWpoints = new string[8];
        public string[] studentsHWpoints = new string[8];
        public string[] studentsComment = new string[8];
    }
}
