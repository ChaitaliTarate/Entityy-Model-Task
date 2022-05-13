using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entityy_Model
{
    public partial class Form3 : Form
    {
        ApplicationEntities dbcontext = new ApplicationEntities();
        public Form3()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Student stud = new Student();
            try
            {


                stud.Name = textBoxName.Text;
                stud.Branch = textBoxBranch.Text;
                stud.Percentage = Convert.ToInt32(textBoxPercentage.Text);


              dbcontext.Student.Add(stud);

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
                Student stud = dbcontext.Student.Find(Convert.ToInt32(textBoxRoll.Text));
                if (stud != null)
                {
                    textBoxName.Text = stud.Name;
                    textBoxBranch.Text = stud.Branch;
                    textBoxPercentage.Text = stud.Percentage.ToString();
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
             Student stud = dbcontext.Student.Find(Convert.ToInt32(textBoxRoll.Text));
                if (stud != null)
                {
                    stud.Name = textBoxName.Text;
                    stud.Branch = textBoxBranch.Text;
                    stud.Percentage = Convert.ToInt32(textBoxPercentage.Text);
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
               Student stud= dbcontext.Student.Find(Convert.ToInt32(textBoxRoll.Text));
                if (stud != null)
                {
                    dbcontext.Student.Remove(stud);
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
