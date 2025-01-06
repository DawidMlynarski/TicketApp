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
            // Przyk³adowe taski
            taskList.Add(new Task(1, "Naprawa serwera", "Serwer nie odpowiada od godziny 12:00", "High-SLA", "Artur Karwatka"));
            taskList.Add(new Task(2, "Aktualizacja oprogramowania", "Aktualizacja bazy danych do najnowszej wersji", "Normal-SLA", "Dawid M³ynarski"));
            taskList.Add(new Task(3, "Konfiguracja VPN", "Ustawienia VPN dla nowego pracownika", "Low-SLA", "Artur Karwatka"));
            taskList.Add(new Task(4, "Analiza logów", "Przeanalizowanie logów b³êdów z ostatniego tygodnia", "Normal-SLA", "Dawid M³ynarski"));
            taskList.Add(new Task(5, "Wymiana sprzêtu", "Wymiana starego routera na nowy model", "High-SLA", "Artur Karwatka"));
            taskList.Add(new Task(6, "Testy zabezpieczeñ", "Testy penetracyjne nowego systemu", "Normal-SLA", "Dawid M³ynarski"));
            taskList.Add(new Task(7, "Przygotowanie raportu", "Sporz¹dzenie raportu z audytu bezpieczeñstwa", "Low-SLA", "Artur Karwatka"));
            taskList.Add(new Task(8, "Utrzymanie sieci", "Przegl¹d okresowy infrastruktury sieciowej", "Normal-SLA", "Dawid M³ynarski"));

            // Wyœwietl aktywne taski
            DisplayTasks(taskList);
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
                    dialog.SetTaskDetails(task.Title, task.Description, task.Priority, task.AssignedConsultant, isClosed, task.Entries); // Przeka¿ dane i status
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

        private void btnSearchContent_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearchContent.Text.ToLower(); // Pobierz tekst i zamieñ na ma³e litery
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                MessageBox.Show("WprowadŸ frazê do wyszukania.", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Wyszukiwanie w aktywnych taskach
            var activeResults = taskList
                .Where(t => t.Title.ToLower().Contains(searchQuery) || t.Description.ToLower().Contains(searchQuery))
                .ToList();

            // Wyszukiwanie w zamkniêtych taskach
            var closedResults = closedTasks
                .Where(t => t.Title.ToLower().Contains(searchQuery) || t.Description.ToLower().Contains(searchQuery))
                .ToList();

            // £¹czenie wyników
            var allResults = activeResults.Concat(closedResults).ToList();

            // Sprawdzenie czy znaleziono wyniki
            if (allResults.Any())
            {
                // Zmieñ tytu³ labela na "wyniki wyszukiwania"
                lblTasksKind.Text = "Wyniki wyszukiwania";

                // Wyczyœæ panel i wyœwietl znalezione taski
                flowLayoutPanel1.Controls.Clear();
                foreach (var task in allResults)
                {
                    AddTaskToPanel(task); // Ponowne dodanie tasków do panelu
                }
            }
            else
            {
                MessageBox.Show("Nie znaleziono tasków pasuj¹cych do podanej frazy.", "Brak wyników", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            // Zmieñ tytu³ labela z powrotem na "Aktywne taski"
            lblTasksKind.Text = "Aktywne taski";

            // Wyczyœæ panel i ponownie wyœwietl tylko aktywne taski
            flowLayoutPanel1.Controls.Clear();
            foreach (var task in taskList)
            {
                AddTaskToPanel(task);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            // Pobierz wybrane wartoœci z list rozwijanych
            string selectedPriority = cmbPriorityFilter.SelectedItem?.ToString();
            string selectedConsultant = cmbConsultantFilter.SelectedItem?.ToString();
            string selectedStatus = cmbStatusFilter.SelectedItem?.ToString();

            // Filtruj taski
            var filteredTasks = taskList
                .Where(task =>
                    (string.IsNullOrEmpty(selectedPriority) || task.Priority == selectedPriority) &&
                    (string.IsNullOrEmpty(selectedConsultant) || task.AssignedConsultant == selectedConsultant) &&
                    (string.IsNullOrEmpty(selectedStatus) ||
                        (selectedStatus == "Aktywne" && !closedTasks.Contains(task)) ||
                        (selectedStatus == "Zamkniête" && closedTasks.Contains(task))))
                .ToList();

            // Wyœwietl przefiltrowane taski
            DisplayTasks(filteredTasks);
        }

        // Metoda do odœwie¿enia wyœwietlania tasków
        private void DisplayTasks(List<Task> tasksToDisplay)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var task in tasksToDisplay)
            {
                AddTaskToPanel(task);
            }
        }
    }
}
