using System.Diagnostics;
using System.Windows.Forms;

namespace TicketApp
{
    public partial class Form1 : Form
    {
        private List<Task> taskList = new List<Task>(); // Lista przechowuj�ca taski
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

        private List<Task> closedTasks = new List<Task>(); // Lista zamkni�tych task�w

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

            // Dodaj zdarzenie klikni�cia do Label (np. aby wy�wietli� szczeg�y)
            taskLabel.Click += (s, e) =>
            {
                // Tworzymy nowe okno dialogowe i ustawiamy szczeg�y zadania
                TaskDialog dialog = new TaskDialog();
                bool isClosed = closedTasks.Contains(task);
                dialog.SetTaskDetails(task.Title, task.Description, task.Priority, task.AssignedConsultant, isClosed, task.Entries);
                var dialogResult = dialog.ShowDialog(); // Wy�wietlenie okna dialogowego
                                                        // Je�eli u�ytkownik zatwierdzi� zmiany, aktualizujemy task
                if (dialogResult == DialogResult.OK)
                {
                    task.Title = dialog.TaskTitle; // Zaktualizuj tytu�
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
                    // Od�wie� tekst etykiety, aby wy�wietli� zmienione dane
                    taskLabel.Text = $"{task.Id}: {task.Title}";

                }
                else if (dialogResult == DialogResult.Ignore)
                {
                    // Zamkni�cie taska: przenosimy go do listy zamkni�tych
                    closedTasks.Add(task); // Dodajemy do listy zamkni�tych
                    taskList.Remove(task);
                    flowLayoutPanel1.Controls.Remove(taskLabel);
                    // Pobierz aktualnie wybranego konsultanta
                    string selectedConsultant = task.AssignedConsultant ?? "Nieznany konsultant";

                    // Dodaj wpis o zamkni�ciu taska
                    string closureEntry = $"{DateTime.Now}: {selectedConsultant} - ZAMKNI�CIE TASKA";
                    task.Entries.Insert(0, closureEntry); // Dodaj wpis na g�r� listy
                }
            };

            // Dodanie etykiety do FlowLayoutPanel
            flowLayoutPanel1.Controls.Add(taskLabel);
        }

        // DODAWANIE TASKA
        private void AddTaskButton_Click(object sender, EventArgs e)
        {
            // Utw�rz nowe okno dialogowe
            TaskDialog taskDialog = new TaskDialog();
            var dialogResult = taskDialog.ShowDialog();

            // Je�li u�ytkownik klikn�� OK, dodaj task
            if (dialogResult == DialogResult.OK)
            {
                string taskId = GenerateTaskId(); // Wygeneruj ID
                string title = taskDialog.TaskTitle; // Pobierz tytu� od u�ytkownika
                string description = taskDialog.TaskDescription; // Pobierz opis od u�ytkownika
                string priority = taskDialog.SelectedPriority; // Pobierz priorytet z dialogu
                string consultant = taskDialog.SelectedConsultant; // Pobierz wybranego konsultanta

                // Stw�rz nowy task
                Task newTask = new Task(int.Parse(taskId), title, description, priority, consultant);
                taskList.Add(newTask); // Dodaj do listy
                nextTaskId++; // Zwi�ksz Id kolejnego taska

                // Wy�wietl task w FlowLayoutPanel
                AddTaskToPanel(newTask);
            }
        }

        private void btnSearchId_Click(object sender, EventArgs e)
        {
            // Pobierz wpisany ID z TextBoxa
            if (int.TryParse(txtSearchId.Text, out int searchId)) // Sprawd�, czy ID jest liczb�
            {
                // Szukaj taska w li�cie aktywnych
                Task task = taskList.FirstOrDefault(t => t.Id == searchId);

                // Je�li nie znaleziono w aktywnych, szukaj w zamkni�tych
                bool isClosed = false; // Flaga dla statusu
                if (task == null)
                {
                    task = closedTasks.FirstOrDefault(t => t.Id == searchId);
                    isClosed = (task != null); // Oznacz task jako zamkni�ty, je�li znaleziony w zamkni�tych
                    Debug.WriteLine(isClosed);
                }

                // Je�li znaleziono taska
                if (task != null)
                {
                    TaskDialog dialog = new TaskDialog();
                    dialog.SetTaskDetails(task.Title, task.Description, task.Priority,task.AssignedConsultant, isClosed, task.Entries); // Przeka� dane i status
                    dialog.ShowDialog(); // Otw�rz okno dialogowe
                }
                else
                {
                    // Komunikat, gdy task nie istnieje
                    MessageBox.Show("Nie znaleziono taska o podanym ID.", "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Komunikat o b��dnym formacie ID
                MessageBox.Show("Prosz� poda� poprawne ID (liczb�).", "B��d", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
    }
    }
}
