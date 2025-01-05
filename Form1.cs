using System.Diagnostics;
using System.Windows.Forms;

namespace TicketApp
{
    public partial class Form1 : Form
    {
        private List<Task> taskList = new List<Task>(); // Lista przechowuj¹ca taski
        private int nextTaskId = 1; // Identyfikator kolejnego taska
        public Form1()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private string GenerateTaskId()
        {
            return nextTaskId.ToString("D4"); // Format liczby na cztery cyfry (np. 0001)
        }

        private List<Task> closedTasks = new List<Task>(); // Lista zamkniêtych tasków

        // Metoda do dodawania Taska do FlowLayoutPanel
        private void AddTaskToPanel(Task task)
        {
            // Tworzenie nowego Label jako reprezentacji taska
            Label taskLabel = new Label();
            taskLabel.Text = $"{task.Id}: {task.Title}";
            taskLabel.AutoSize = true;
            taskLabel.BorderStyle = BorderStyle.FixedSingle;
            taskLabel.Padding = new Padding(5);
            taskLabel.Margin = new Padding(5);

            switch (task.Priority)
            {
                case "Low-SLA":
                    taskLabel.ForeColor = Color.Gray;  // Niski priorytet - szary
                    break;
                case "Normal-SLA":
                    taskLabel.ForeColor = Color.Black; // Normalny priorytet - czarny
                    break;
                case "High-SLA":
                    taskLabel.ForeColor = Color.Red;   // Wysoki priorytet - czerwony
                    break;
            }

            // Dodaj zdarzenie klikniêcia do Label (np. aby wyœwietliæ szczegó³y)
            taskLabel.Click += (s, e) =>
            {
                // Tworzymy nowe okno dialogowe i ustawiamy szczegó³y zadania
                TaskDialog dialog = new TaskDialog();
                bool isClosed = closedTasks.Contains(task);
                dialog.SetTaskDetails(task.Title, task.Description, task.Priority, task.AssignedConsultant, isClosed, task.Entries);
                var dialogResult = dialog.ShowDialog(); // Wyœwietlenie okna dialogowego
                                                        // Je¿eli u¿ytkownik zatwierdzi³ zmiany, aktualizujemy task
                if (dialogResult == DialogResult.OK)
                {
                    task.Title = dialog.TaskTitle; // Zaktualizuj tytu³
                    task.Description = dialog.TaskDescription; // Zaktualizuj opis
                    task.Priority = dialog.SelectedPriority; // Zaktualizuj priorytet
                    task.AssignedConsultant = dialog.SelectedConsultant; // Zaktualizuj konsultanta 
                    task.Entries = dialog.GetEntries();

                    // Zmieniamy kolor czcionki po edycji
                    switch (task.Priority)
                    {
                        case "Low-SLA":
                            taskLabel.ForeColor = Color.Gray;
                            break;
                        case "Normal-SLA":
                            taskLabel.ForeColor = Color.Black;
                            break;
                        case "High-SLA":
                            taskLabel.ForeColor = Color.Red;
                            break;
                    }
                    // Odœwie¿ tekst etykiety, aby wyœwietliæ zmienione dane
                    taskLabel.Text = $"{task.Id}: {task.Title}";

                }
                else if (dialogResult == DialogResult.Ignore)
                {
                    // Zamkniêcie taska: przenosimy go do listy zamkniêtych
                    closedTasks.Add(task); // Dodajemy do listy zamkniêtych
                    taskList.Remove(task);
                    flowLayoutPanel1.Controls.Remove(taskLabel);
                    // Pobierz aktualnie wybranego konsultanta
                    string selectedConsultant = task.AssignedConsultant ?? "Nieznany konsultant";

                    // Dodaj wpis o zamkniêciu taska
                    string closureEntry = $"{DateTime.Now}: {selectedConsultant} - ZAMKNIÊCIE TASKA";
                    task.Entries.Insert(0, closureEntry); // Dodaj wpis na górê listy
                }
            };

            // Dodanie etykiety do FlowLayoutPanel
            flowLayoutPanel1.Controls.Add(taskLabel);
        }

        // DODAWANIE TASKA
        private void AddTaskButton_Click(object sender, EventArgs e)
        {
            // Utwórz nowe okno dialogowe
            TaskDialog taskDialog = new TaskDialog();
            var dialogResult = taskDialog.ShowDialog();

            // Jeœli u¿ytkownik klikn¹³ OK, dodaj task
            if (dialogResult == DialogResult.OK)
            {
                string taskId = GenerateTaskId(); // Wygeneruj ID
                string title = taskDialog.TaskTitle; // Pobierz tytu³ od u¿ytkownika
                string description = taskDialog.TaskDescription; // Pobierz opis od u¿ytkownika
                string priority = taskDialog.SelectedPriority; // Pobierz priorytet z dialogu
                string consultant = taskDialog.SelectedConsultant; // Pobierz wybranego konsultanta

                // Stwórz nowy task
                Task newTask = new Task(int.Parse(taskId), title, description, priority, consultant);
                taskList.Add(newTask); // Dodaj do listy
                nextTaskId++; // Zwiêksz Id kolejnego taska

                // Wyœwietl task w FlowLayoutPanel
                AddTaskToPanel(newTask);
            }
        }

        private void btnSearchId_Click(object sender, EventArgs e)
        {
            // Pobierz wpisany ID z TextBoxa
            if (int.TryParse(txtSearchId.Text, out int searchId)) // SprawdŸ, czy ID jest liczb¹
            {
                // Szukaj taska w liœcie aktywnych
                Task task = taskList.FirstOrDefault(t => t.Id == searchId);

                // Jeœli nie znaleziono w aktywnych, szukaj w zamkniêtych
                bool isClosed = false; // Flaga dla statusu
                if (task == null)
                {
                    task = closedTasks.FirstOrDefault(t => t.Id == searchId);
                    isClosed = (task != null); // Oznacz task jako zamkniêty, jeœli znaleziony w zamkniêtych
                    Debug.WriteLine(isClosed);
                }

                // Jeœli znaleziono taska
                if (task != null)
                {
                    TaskDialog dialog = new TaskDialog();
                    dialog.SetTaskDetails(task.Title, task.Description, task.Priority,task.AssignedConsultant, isClosed, task.Entries); // Przeka¿ dane i status
                    dialog.ShowDialog(); // Otwórz okno dialogowe
                }
                else
                {
                    // Komunikat, gdy task nie istnieje
                    MessageBox.Show("Nie znaleziono taska o podanym ID.", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Komunikat o b³êdnym formacie ID
                MessageBox.Show("Proszê podaæ poprawne ID (liczbê).", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
    }
    }
}
