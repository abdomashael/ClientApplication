using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApplication
{
    class ITIRepository
    {
        private static ITIRepository itiRepository;
        private ServiceReference1.Service1Client client ;
            
        private DataTable branchesDataTable;
        private DataTable branchesConfigDataTable;
        private DataTable branchesConfigKeysDataTable;
        private DataTable studentsDataTable;
        private DataTable studentsConfigDataTable;
        private DataTable studentsConfigKeysDataTable;
        private DataTable instructorsDataTable;
        private DataTable instructorsConfigDataTable;
        private DataTable instructorsConfigKeysDataTable;

        private ITIRepository()
        {
            client = new ServiceReference1.Service1Client();
        }

        public DataTable BranchesDataTable { get => branchesDataTable; set => branchesDataTable = value; }
        public DataTable BranchesConfigDataTable { get => branchesConfigDataTable; set => branchesConfigDataTable = value; }
        public DataTable BranchesConfigKeysDataTable { get => branchesConfigKeysDataTable; set => branchesConfigKeysDataTable = value; }
        public DataTable StudentsDataTable { get => studentsDataTable; set => studentsDataTable = value; }
        public DataTable StudentsConfigDataTable { get => studentsConfigDataTable; set => studentsConfigDataTable = value; }
        public DataTable StudentsConfigKeysDataTable { get => studentsConfigKeysDataTable; set => studentsConfigKeysDataTable = value; }
        public DataTable InstructorsDataTable { get => instructorsDataTable; set => instructorsDataTable = value; }
        public DataTable InstructorsConfigDataTable { get => instructorsConfigDataTable; set => instructorsConfigDataTable = value; }
        public DataTable InstructorsConfigKeysDataTable { get => instructorsConfigKeysDataTable; set => instructorsConfigKeysDataTable = value; }

        public static ITIRepository getInstance()
        {
            if(itiRepository == null)
            {
                itiRepository = new ITIRepository();
            }
            return itiRepository;
        }

        public void fetchData()
        {
            ServiceReference1.BranchData branchs = new ServiceReference1.BranchData();
            branchs = client.getBranchsData();
            BranchesDataTable = branchs.branchsTable;
            BranchesConfigDataTable = branchs.configTable;
            BranchesConfigKeysDataTable = branchs.configKeysTable;

            ServiceReference1.StudentData students = new ServiceReference1.StudentData();
            students = client.getStudentsData();
            StudentsDataTable = students.studentsTable;
            StudentsConfigDataTable = students.configTable;
            StudentsConfigKeysDataTable = students.configKeysTable;

            ServiceReference1.InstructorData instructors = new ServiceReference1.InstructorData();
            instructors = client.getInstructorsData();
            InstructorsDataTable = instructors.InstructorsTable;
            InstructorsConfigDataTable = instructors.configTable;
            InstructorsConfigKeysDataTable = instructors.configKeysTable;
        }


        public bool CheckConnection()
        {
            try  
            {
                fetchData();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        } 

    }
}
