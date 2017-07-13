using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnonymousServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileClass f1 = new FileClass();
            var db = new List<FileDbStructure>();
            db.Add(new FileDbStructure("Chirag Shah","Chirag", "Shah", Usertype.Manager));
            if (f1.WriteToDbFile(db))
            {
                //Now I change the comment.
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Failed");
            }
        }
    }
}
