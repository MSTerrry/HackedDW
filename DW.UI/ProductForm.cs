using DeliveryWizard;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DW.UI
{
    public partial class ProductForm : Form
    {
        public Product Prod { get; set; }
        public ProductForm(Product Prod)
        {
            this.Prod = Prod;
            InitializeComponent();                     
        }

        private void OK_Click(object sender, EventArgs e)
        {
            Prod.Name = TitleBox.Text;
            Prod.Additions = AdditionBox.Text;            
            Prod.Amount = float.Parse(AmountBox.Text);
            Prod.Cost = float.Parse(CostBox.Text);
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            TitleBox.Text = Prod.Name;
            AdditionBox.Text = Prod.Additions;
            AmountBox.Text = Prod.Amount.ToString();
            CostBox.Text = Prod.Cost.ToString();
        }

        private void AmountBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 44 && e.KeyChar != 46)
                e.Handled = true;            
        }

        private void TitleBox_TextChanged(object sender, EventArgs e)
        {
            if (TitleBox != null && CostBox.Text != "0"  && AmountBox.Text != "0")
                OK.Enabled = true;
        }
    }
}
