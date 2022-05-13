using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entityy_Model
{
    
    public partial class Form1 : Form
    {
        ApplicationEntities dbcontext = new ApplicationEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Employee1 emp = new Employee1();
            try
            {

               
                emp.EmpName = textBoxName.Text;
                emp.Designation = textBoxDesignation.Text;
                emp.Salary = Convert.ToDecimal(textBoxSalary.Text);
                 

                 dbcontext.Employee1.Add(emp);

                dbcontext.SaveChanges();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Employee1 emp = dbcontext.Employee1.Find(Convert.ToInt32(textBoxId.Text));
                if (emp != null)
                {
                    textBoxName.Text = emp.EmpName;
                    textBoxDesignation.Text = emp.Designation;
                    textBoxSalary.Text = emp.Salary.ToString();
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Employee1 emp = dbcontext.Employee1.Find(Convert.ToInt32(textBoxId.Text));
                if (emp != null)
                {
                    emp.EmpName = textBoxName.Text;
                    emp.Designation = textBoxDesignation.Text;
                    emp.Salary = Convert.ToDecimal(textBoxSalary.Text);
                    dbcontext.SaveChanges();
                    MessageBox.Show("updated");
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Employee1 emp = dbcontext.Employee1.Find(Convert.ToInt32(textBoxId.Text));
                if (emp != null)
                {
                    dbcontext.Employee1.Remove(emp);
                    dbcontext.SaveChanges();
                    MessageBox.Show("deleted");
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
