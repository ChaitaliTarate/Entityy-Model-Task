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
    public partial class Form2 : Form
    {
        ApplicationEntities dbcontext = new ApplicationEntities();
        public Form2()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Product1 product = new Product1();
            try
            {


              product.PName = textBoxName.Text;
              product.Price=Convert.ToDecimal(textBoxPrice.Text);

                //dbcontext.product1.Add(product);

               // dbcontext.Products.Add(product);

                dbcontext.SaveChanges();
                MessageBox.Show("Done");
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
               Product1 prod = dbcontext.Product1.Find(Convert.ToInt32(textBoxId.Text));
                if (prod != null)
                {
                   prod.PName = textBoxName.Text;
                    prod.Price = Convert.ToInt32(textBoxPrice.Text);
                    
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
             Product1 prod = dbcontext.Product1.Find(Convert.ToInt32(textBoxId.Text));
                if (prod != null)
                {
                    dbcontext.Product1.Remove(prod);
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Product1 prod = dbcontext.Product1.Find(Convert.ToInt32(textBoxId.Text));
                if (prod != null)
                {
                    textBoxName.Text = prod.PName;
                    textBoxPrice.Text = prod.Price;
                   
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
