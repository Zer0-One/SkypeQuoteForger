using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SkypeQuoteForger {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        bool gotFocus1 = false;
        private void textBox2_Enter(object sender, EventArgs e) {
            if (!gotFocus1) {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
                gotFocus1 = true;
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            DateTime epoch = new DateTime(1970, 1, 1);
            long timestamp = (dateTimePicker1.Value.ToUniversalTime().Ticks - epoch.Ticks) / TimeSpan.TicksPerSecond;
            IDataObject dataObject = new DataObject("Text", textBox2.Text);
            dataObject.SetData("SkypeMessageFragment", new MemoryStream(Encoding.UTF8.GetBytes(String.Format("<quote author=\"{0}\" timestamp=\"{1}\">{2}</quote>", textBox1.Text, timestamp, textBox2.Text))));
            Clipboard.SetDataObject(dataObject);
        }

        bool gotFocus2 = false;
        private void textBox1_Enter(object sender, EventArgs e) {
            if (!gotFocus2) {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
                gotFocus2 = true;
            }
        }
    }
}
