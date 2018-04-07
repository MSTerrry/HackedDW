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
            Prod.Amount = int.Parse(AmountBox.Text);
            Prod.Cost = decimal.Parse(CostBox.Text);
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            TitleBox.Text = Prod.Name;
            AdditionBox.Text = Prod.Additions;
            AmountBox.Text = Prod.Amount.ToString();
            CostBox.Text = Prod.Cost.ToString();
        }
    }
}
