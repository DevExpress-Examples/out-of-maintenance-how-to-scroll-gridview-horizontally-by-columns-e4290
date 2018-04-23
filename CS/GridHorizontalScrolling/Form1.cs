using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GridHorizontalScrolling {
    public partial class Form1 : Form {
        BindingList<Customers> listOfCustomers = new BindingList<Customers>();
        GridEcxtensionHorizontalScrolling Extension;

        public Form1() {
            InitializeComponent();
            gridControl1.DataSource = FillTables();
            gridView1.Columns[0].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gridView1.LeftCoordChanged += gridView1_LeftCoordChanged;
            Extension = new GridEcxtensionHorizontalScrolling(gridView1);
        }

        void gridView1_LeftCoordChanged(object sender, EventArgs e) {
            textEdit1.Text = Extension.UpdateIndexInEditor().ToString();
        }

        BindingList<Customers> FillTables() {
            listOfCustomers.Clear();
            for (int i = 0; i < 5; i++)
                listOfCustomers.Add(new Customers());
            return listOfCustomers;
        }

        private void Form1_Load(object sender, EventArgs e) {
            Extension.UpdateFixedColumnsCount();
            textEdit1.Text = Extension.UpdateIndexInEditor().ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            Extension.ScrollForward();
        }

        private void simpleButton2_Click(object sender, EventArgs e) {
            Extension.ScrollBackward();
        }

        private void textEdit1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
                if (textEdit1.Text != string.Empty)
                    Extension.ScrollTo(Convert.ToInt32(textEdit1.Text));
        }
    }
}