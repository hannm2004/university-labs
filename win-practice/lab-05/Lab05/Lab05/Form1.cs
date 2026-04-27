using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab05.Model;
using Microsoft.Reporting.WinForms;


namespace Lab05
{
    public partial class Form1: Form
    {
        Model1 dbSinhVien = new Model1();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Student> listSinhVien = dbSinhVien.Student.ToList();
            List<StudentReport> listSVreport = new List<StudentReport>();
            foreach (var sutdent in listSinhVien)
            {
                StudentReport studentReport = new StudentReport();
                studentReport.StudentID = sutdent.StudentID;
                studentReport.StudentName = sutdent.FullName;
                studentReport.DiemTB = sutdent.AverageScore.Value;
                studentReport.FacultyName = sutdent.Faculty.FacultyName;
                listSVreport.Add(studentReport);
            }

            this.reportViewer1.LocalReport.ReportPath = "./report/ReportSinhVien.rdlc";
            var reportDataSource = new ReportDataSource("DataSetStudent", listSVreport);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }
    }
}
