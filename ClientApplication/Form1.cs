using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientApplication
{
    public partial class Form1 : Form
    {

        private ITIRepository repository;
        //To Keep Track on current selectec item in comboBoxes
        private int branchID = 1, branchConfigKeyID = 1, studentID = 1, studentConfigKeyID = 1, instructorID = 1, instructorConfigKeyID = 1;

        public Form1()
        {
            //Singleton Pattern to insure that have only one instance over application
            repository = ITIRepository.getInstance();

            InitializeComponent();

            this.bindData();

        }



        private void BranchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            branchID = getSelectedItemID(sender, "BranchID");

            checkBranchKey();

        }


        private void ConfigKBranchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            branchConfigKeyID = getSelectedItemID(sender, "_BranchConfigurationsKeyID");

            checkBranchKey();
        }

        private void InstructorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            instructorID = getSelectedItemID(sender, "EmployeeID");

            checkInstructorKey();
        }

        private void ConfigKInstructorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            instructorConfigKeyID = getSelectedItemID(sender, "_EmployeeConfigurationsKeyID");
            checkInstructorKey();

        }

        private void StudentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            studentID = getSelectedItemID(sender, "StudentID");

            checkStudentKey();
        }



        private void ConfigKStudentComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            studentConfigKeyID = getSelectedItemID(sender, "_StudentConfigurationsKeyID");

            checkStudentKey();
        }


        private void bindData()
        {

            branchComboBox.DataSource = repository.BranchesDataTable;
            branchComboBox.DisplayMember = "Name";
            branchComboBox.ValueMember = "BranchID";

            configKBranchComboBox.DataSource = repository.BranchesConfigKeysDataTable;
            configKBranchComboBox.DisplayMember = "NameE";
            configKBranchComboBox.ValueMember = "_BranchConfigurationsKeyID";


            studentComboBox.DataSource = repository.StudentsDataTable;
            studentComboBox.DisplayMember = "Name";
            studentComboBox.ValueMember = "StudentID";

            configKStudentComboBox.DataSource = repository.StudentsConfigKeysDataTable;
            configKStudentComboBox.DisplayMember = "NameE";
            configKStudentComboBox.ValueMember = "_StudentConfigurationsKeyID";

            instructorComboBox.DataSource = repository.InstructorsDataTable;
            instructorComboBox.DisplayMember = "Name";
            instructorComboBox.ValueMember = "EmployeeID";

            configKInstructorComboBox.DataSource = repository.InstructorsConfigKeysDataTable;
            configKInstructorComboBox.DisplayMember = "NameE";
            configKInstructorComboBox.ValueMember = "_EmployeeConfigurationsKeyID";

        }

        private void checkBranchKey()
        {
            DataRow[] res = repository.BranchesConfigDataTable.Select("BranchID = " + branchID + " AND _BranchConfigurationsKeyID = " + branchConfigKeyID);

            if (res.Length > 0)
            {
                configVBranchTextBox.Text = res[0]["BranchConfigurationsValue"].ToString();
            }
            else
            {
                res = repository.BranchesConfigKeysDataTable.Select("_BranchConfigurationsKeyID = " + branchConfigKeyID);
                configVBranchTextBox.Text = res[0]["_BranchConfigurationKeyValue"].ToString();
            }
        }


        private void checkStudentKey()
        {
            DataRow[] res = repository.StudentsConfigDataTable.Select("StudentID = " + studentID + " AND _StudentConfigurationsKeyID = " + studentConfigKeyID);

            if (res.Length > 0)
            {
                configVStudentTextBox.Text = res[0]["StudentConfigurationsValue"].ToString();
            }
            else
            {
                res = repository.StudentsConfigKeysDataTable.Select("_StudentConfigurationsKeyID = " + studentConfigKeyID);
                configVStudentTextBox.Text = res[0]["_StudentConfigurationKeyValue"].ToString();
            }
        }

        private void checkInstructorKey()
        {
            DataRow[] res = repository.InstructorsConfigDataTable.Select("EmployeeID = " + instructorID + " AND _EmployeeConfigurationsKeyID = " + instructorConfigKeyID);

            if (res.Length > 0)
            {
                configVInstructorTextBox.Text = res[0]["EmployeeConfigurationsValue"].ToString();
            }
            else
            {
                res = repository.InstructorsConfigKeysDataTable.Select("_EmployeeConfigurationsKeyID = " + instructorConfigKeyID);
                configVInstructorTextBox.Text = res[0]["_EmployeeConfigurationKeyValue"].ToString();
            }
        }

        private int getSelectedItemID(Object sender,string coloumnName)
        {
            ComboBox comboBox = (ComboBox)sender;

            DataRowView oDataRowView = comboBox.SelectedItem as DataRowView;

            int iValue = 0;

            if (oDataRowView != null)
            {
                iValue = (int)oDataRowView.Row[coloumnName];
            }

            return iValue;

        }

    }
}
