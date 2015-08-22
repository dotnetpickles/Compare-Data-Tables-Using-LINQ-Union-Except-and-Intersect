using System;
//Include this if it is not already there
using System.Data;
using System.Linq;

namespace CompareDataTablesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Table contains students data who enrolled
            //to yoga class
            DataTable dtYoga = new DataTable("YogaClass");
            dtYoga.Columns.Add("StudentId", typeof(int));
            dtYoga.Columns.Add("StudentName", typeof(string));
            dtYoga.Columns.Add("Age", typeof(int));
            dtYoga.Columns.Add("Place", typeof(string));

            //Adding sample records
            dtYoga.Rows.Add(1, "Kanna", 28, "Chennai");
            dtYoga.Rows.Add(2, "Dasan", 29, "Avadi");
            dtYoga.Rows.Add(3, "Kavi", 27, "Ambur");
            dtYoga.Rows.Add(4, "Arasan", 30, "Delhi");
            dtYoga.Rows.Add(5, "Xavier", 25, "Bangalore");

            //Table contains students data who enrolled
            //to karate class
            DataTable dtKarate = new DataTable("KarateClass");
            dtKarate.Columns.Add("StudentId", typeof(int));
            dtKarate.Columns.Add("StudentName", typeof(string));
            dtKarate.Columns.Add("Age", typeof(int));
            dtKarate.Columns.Add("Place", typeof(string));

            //Adding sample records
            dtKarate.Rows.Add(6, "Arvind", 24, "Ambattur");
            dtKarate.Rows.Add(1, "Kanna", 28, "Chennai");
            dtKarate.Rows.Add(3, "Kavi", 27, "Ambur");
            dtKarate.Rows.Add(7, "John", 24, "Velachery");
            dtKarate.Rows.Add(4, "Paul",22, "Adambakkam");
            dtKarate.Rows.Add(4, "Arasan", 30, "Delhi");


            // Printing the list of all students using Union
            Console.WriteLine("\t-------------------------------");
            Console.WriteLine("\tPrinting the list of all students using Union");
            Console.WriteLine("\t-------------------------------");

            DataTable dtBoth = dtYoga.AsEnumerable().Union(dtKarate.AsEnumerable(), DataRowComparer.Default).CopyToDataTable();
            foreach (DataRow dr in dtBoth.Rows)
            {
                Console.WriteLine(string.Format("\tStudentId: {0}, StudentName: {1}", dr[0].ToString(), dr[1].ToString()));
            }


            // Finding out students who enrolled only to Yoga Classes using Except
            DataTable dtOnlyYoga = dtYoga.AsEnumerable().Except(dtKarate.AsEnumerable(), DataRowComparer.Default).CopyToDataTable();

            Console.WriteLine("\t");
            Console.WriteLine("\tEnrolled Students - Only for Yoga Classes using Except");
            Console.WriteLine("\t-------------------------------");
            foreach (DataRow dr in dtOnlyYoga.Rows)
            {
                Console.WriteLine(string.Format("\tStudentId: {0}, StudentName: {1}", dr[0].ToString(), dr[1].ToString()));
            }


            // Finding out students who enrolled only to Yoga Classes using Except
            Console.WriteLine("\t");
            Console.WriteLine("\tEnrolled Students - Only for Karate Classes using Except");
            Console.WriteLine("\t-------------------------------");
            DataTable dtOnlyKarate = dtKarate.AsEnumerable().Except(dtYoga.AsEnumerable(), DataRowComparer.Default).CopyToDataTable();
            foreach (DataRow dr in dtOnlyKarate.Rows)
            {
                Console.WriteLine(string.Format("\tStudentId: {0}, StudentName: {1}", dr[0].ToString(), dr[1].ToString()));
            }

            // Finding out students who enrolled to Both Yoga Classes using Intersect
            Console.WriteLine("\t");
            Console.WriteLine("\tEnrolled Students - For Both Yoga & Karate Classes using Intersect");
            Console.WriteLine("\t-------------------------------");

            DataTable dtBothClasses = dtYoga.AsEnumerable().Intersect(dtKarate.AsEnumerable(), DataRowComparer.Default).CopyToDataTable();
            foreach (DataRow dr in dtBothClasses.Rows)
            {
                Console.WriteLine(string.Format("\tStudentId: {0}, StudentName: {1}", dr[0].ToString(), dr[1].ToString()));
            }


            Console.ReadLine();

        }
    }
}
