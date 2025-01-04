using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketApp
{
    public partial class EntryDialog : Form
    {
        public string EntryText { get; private set; } // Przechowywanie tekstu wpisu
        public EntryDialog()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            EntryText = txtEntry.Text; // Pobierz wpis
            DialogResult = DialogResult.OK; // Zatwierdzenie
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; // Anulowanie
            Close();
        }
    }
}
