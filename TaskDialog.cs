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
    public partial class TaskDialog : Form
    {
        public string TaskTitle { get; private set; }
        public string TaskDescription { get; private set; }
        public string SelectedPriority { get; set; } // Priorytet wybrany w TaskDialog



        public TaskDialog()
        {
            InitializeComponent();

        }
        // Metoda do ustawiania tytułu i opisu zadania w formularzu
        public void SetTaskDetails(string title, string description, string priority)
        {
            TaskTitle = title;
            TaskDescription = description;
            SelectedPriority = priority; // Ustawienie priorytetu

            // Ustawienie wartości w kontrolkach
            txtTitle.Text = title;
            txtDescription.Text = description;
            cmbPriority.SelectedItem = priority;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            TaskTitle = txtTitle.Text; // Pobiera tytuł
            TaskDescription = txtDescription.Text; // Pobiera opis
            SelectedPriority = cmbPriority.SelectedItem.ToString();
            this.DialogResult = DialogResult.OK; // Zwraca wynik dialogu
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Ignore;
            this.Close();
        }
    }
}
