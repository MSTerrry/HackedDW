namespace DW.UI
{
    partial class ProductForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Title = new System.Windows.Forms.Label();
            this.TitleBox = new System.Windows.Forms.TextBox();
            this.AmountBox = new System.Windows.Forms.TextBox();
            this.Amount = new System.Windows.Forms.Label();
            this.Additional = new System.Windows.Forms.Label();
            this.AdditionBox = new System.Windows.Forms.TextBox();
            this.CostBox = new System.Windows.Forms.TextBox();
            this.Cost = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Location = new System.Drawing.Point(12, 15);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(106, 13);
            this.Title.TabIndex = 0;
            this.Title.Text = "Название продукта";
            // 
            // TitleBox
            // 
            this.TitleBox.Location = new System.Drawing.Point(184, 12);
            this.TitleBox.Name = "TitleBox";
            this.TitleBox.Size = new System.Drawing.Size(232, 20);
            this.TitleBox.TabIndex = 1;
            this.TitleBox.TextChanged += new System.EventHandler(this.TitleBox_TextChanged);
            // 
            // AmountBox
            // 
            this.AmountBox.Location = new System.Drawing.Point(184, 40);
            this.AmountBox.Name = "AmountBox";
            this.AmountBox.Size = new System.Drawing.Size(232, 20);
            this.AmountBox.TabIndex = 3;
            this.AmountBox.TextChanged += new System.EventHandler(this.TitleBox_TextChanged);
            this.AmountBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AmountBox_KeyPress);
            // 
            // Amount
            // 
            this.Amount.AutoSize = true;
            this.Amount.Location = new System.Drawing.Point(12, 43);
            this.Amount.Name = "Amount";
            this.Amount.Size = new System.Drawing.Size(66, 13);
            this.Amount.TabIndex = 2;
            this.Amount.Text = "Количество";
            // 
            // Additional
            // 
            this.Additional.AutoSize = true;
            this.Additional.Location = new System.Drawing.Point(12, 70);
            this.Additional.Name = "Additional";
            this.Additional.Size = new System.Drawing.Size(160, 13);
            this.Additional.TabIndex = 4;
            this.Additional.Text = "Дополнительная информация";
            // 
            // AdditionBox
            // 
            this.AdditionBox.Location = new System.Drawing.Point(184, 67);
            this.AdditionBox.Name = "AdditionBox";
            this.AdditionBox.Size = new System.Drawing.Size(232, 20);
            this.AdditionBox.TabIndex = 5;
            // 
            // CostBox
            // 
            this.CostBox.Location = new System.Drawing.Point(184, 93);
            this.CostBox.Name = "CostBox";
            this.CostBox.Size = new System.Drawing.Size(232, 20);
            this.CostBox.TabIndex = 7;
            this.CostBox.TextChanged += new System.EventHandler(this.TitleBox_TextChanged);
            this.CostBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AmountBox_KeyPress);
            // 
            // Cost
            // 
            this.Cost.AutoSize = true;
            this.Cost.Location = new System.Drawing.Point(12, 96);
            this.Cost.Name = "Cost";
            this.Cost.Size = new System.Drawing.Size(33, 13);
            this.Cost.TabIndex = 6;
            this.Cost.Text = "Цена";
            // 
            // OK
            // 
            this.OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Enabled = false;
            this.OK.Location = new System.Drawing.Point(152, 134);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 8;
            this.OK.Text = "Сохранить";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(243, 134);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 9;
            this.Cancel.Text = "Отменить";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 169);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.CostBox);
            this.Controls.Add(this.Cost);
            this.Controls.Add(this.AdditionBox);
            this.Controls.Add(this.Additional);
            this.Controls.Add(this.AmountBox);
            this.Controls.Add(this.Amount);
            this.Controls.Add(this.TitleBox);
            this.Controls.Add(this.Title);
            this.Name = "ProductForm";
            this.Text = "ProductForm";
            this.Load += new System.EventHandler(this.ProductForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.TextBox TitleBox;
        private System.Windows.Forms.TextBox AmountBox;
        private System.Windows.Forms.Label Amount;
        private System.Windows.Forms.Label Additional;
        private System.Windows.Forms.TextBox AdditionBox;
        private System.Windows.Forms.TextBox CostBox;
        private System.Windows.Forms.Label Cost;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
    }
}