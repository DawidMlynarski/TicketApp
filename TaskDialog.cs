using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
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
        public string SelectedConsultant { get; set; }
        private List<string> entries = new List<string>(); // Lista wpisów
        public bool IsClosed { get; private set; } // Właściwość do sprawdzenia statusu



        public TaskDialog()
        {
            InitializeComponent();

        }
        // Metoda do ustawiania tytułu i opisu zadania w formularzu
        public void SetTaskDetails(string title, string description, string priority, string consultant, bool isClosed, List<string> taskEntries = null)
        {
            TaskTitle = title;
            TaskDescription = description;
            SelectedPriority = priority; // Ustawienie priorytetu
            SelectedConsultant = consultant;
            IsClosed = isClosed;

            // Ustawienie wartości w kontrolkach
            txtTitle.Text = title;
            txtDescription.Text = description;
            cmbPriority.SelectedItem = priority;
            cmbConsultant.SelectedItem = consultant;

            // Ustawienie statusu taska
            lblStatus.Text = IsClosed ? "Status: Task zamknięty" : "Status: Task aktywny";
            lblStatus.ForeColor = IsClosed ? Color.Red : Color.Green; // Kolor dla statusu

            // Załaduj wpisy, jeśli istnieją
            entries = taskEntries ?? new List<string>();
            UpdateEntriesDisplay(); // Odśwież RichTextBox
                                    

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            TaskTitle = txtTitle.Text; // Pobiera tytuł
            TaskDescription = txtDescription.Text; // Pobiera opis
            SelectedPriority = cmbPriority.SelectedItem.ToString();
            SelectedConsultant = cmbConsultant.SelectedItem.ToString();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddEntry_Click(object sender, EventArgs e)
        {
            EntryDialog entryDialog = new EntryDialog();
            if (entryDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedConsultant = cmbConsultant.SelectedItem?.ToString() ?? "Nieznany konsultant";

                // Tworzenie wpisu z datą, konsultantem i treścią wpisu
                string newEntry = $"{DateTime.Now}: {selectedConsultant} - {entryDialog.EntryText}";
                entries.Insert(0, newEntry); // Dodajemy wpis na górę listy (najnowszy)

                // Odświeżenie RichTextBox
                UpdateEntriesDisplay();
            }
        }
        private void UpdateEntriesDisplay()
        {
            rtbEntries.Clear(); // Czyścimy pole
            foreach (var entry in entries)
            {
                rtbEntries.AppendText(entry + Environment.NewLine); // Dodajemy wpisy po kolei
            }
        }
        public List<string> GetEntries()
        {
            return entries; // Zwróć wpisy do głównego formularza
        }
    }
}
