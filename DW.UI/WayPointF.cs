using System;
using DeliveryWizard;
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
    public partial class WayPointF : Form
    {
        public WayPoint wp { get; set; }
        public WayPointF(WayPoint wp)
        {
            this.wp = wp;
            InitializeComponent();            
        }
                
        private void Save_Click(object sender, EventArgs e)
        {
            wp.Address = AdressBox.Text;
            if (wp.ShopType != null) wp.ShopType = DroppedBox1.SelectedItem.ToString();
            else wp.ShopType = "Другое";            
            wp.PlaceTitle = TitleBox.Text;
            wp.ProductsList = ProductList.Items.OfType<Product>().ToList(); 
        }

        private void WayPointF_Load(object sender, EventArgs e)
        {
            AdressBox.Text = wp.Address;
            DroppedBox1.SelectedItem = wp.ShopType;
            TitleBox.Text = wp.PlaceTitle;
            if (wp.ProductsList != null)
            {
                foreach (var r in wp.ProductsList)
                {
                    ProductList.Items.Add(r);
                }
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            var product = new ProductForm(new Product());
            var res = product.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                ProductList.Items.Add(product.Prod);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            ProductList.Items.Remove(ProductList.SelectedItem);
        }

        private void ProductList_DoubleClick(object sender, EventArgs e)
        {
            var prod = ProductList.SelectedItem as Product;
            if (prod == null)
                return;
            var form = new ProductForm(prod.Clone());
            var res = form.ShowDialog(this);
            if (res == DialogResult.OK)
            {
                var si = ProductList.SelectedIndex;
                ProductList.Items.Remove(ProductList.SelectedItem);
                ProductList.Items.Insert(si,form.Prod);
            }
        }
    }
}
