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
            // Przyk�adowe taski
            taskList.Add(new Task(1, "Naprawa serwera", "Serwer nie odpowiada od godziny 12:00", "High-SLA", "Artur Karwatka"));
            taskList.Add(new Task(2, "Aktualizacja oprogramowania", "Aktualizacja bazy danych do najnowszej wersji", "Normal-SLA", "Dawid M�ynarski"));
            taskList.Add(new Task(3, "Konfiguracja VPN", "Ustawienia VPN dla nowego pracownika", "Low-SLA", "Artur Karwatka"));
            taskList.Add(new Task(4, "Analiza log�w", "Przeanalizowanie log�w b��d�w z ostatniego tygodnia", "Normal-SLA", "Dawid M�ynarski"));
            taskList.Add(new Task(5, "Wymiana sprz�tu", "Wymiana starego routera na nowy model", "High-SLA", "Artur Karwatka"));
            taskList.Add(new Task(6, "Testy zabezpiecze�", "Testy penetracyjne nowego systemu", "Normal-SLA", "Dawid M�ynarski"));
            taskList.Add(new Task(7, "Przygotowanie raportu", "Sporz�dzenie raportu z audytu bezpiecze�stwa", "Low-SLA", "Artur Karwatka"));
            taskList.Add(new Task(8, "Utrzymanie sieci", "Przegl�d okresowy infrastruktury sieciowej", "Normal-SLA", "Dawid M�ynarski"));

            // Wy�wietl aktywne taski
            DisplayTasks(taskList);
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
                    dialog.SetTaskDetails(task.Title, task.Description, task.Priority, task.AssignedConsultant, isClosed, task.Entries); // Przeka� dane i status
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

        private void btnSearchContent_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearchContent.Text.ToLower(); // Pobierz tekst i zamie� na ma�e litery
            if (string.IsNullOrWhiteSpace(searchQuery))
            {
                MessageBox.Show("Wprowad� fraz� do wyszukania.", "B��d", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Wyszukiwanie w aktywnych taskach
            var activeResults = taskList
                .Where(t => t.Title.ToLower().Contains(searchQuery) || t.Description.ToLower().Contains(searchQuery))
                .ToList();

            // Wyszukiwanie w zamkni�tych taskach
            var closedResults = closedTasks
                .Where(t => t.Title.ToLower().Contains(searchQuery) || t.Description.ToLower().Contains(searchQuery))
                .ToList();

            // ��czenie wynik�w
            var allResults = activeResults.Concat(closedResults).ToList();

            // Sprawdzenie czy znaleziono wyniki
            if (allResults.Any())
            {
                // Zmie� tytu� labela na "wyniki wyszukiwania"
                lblTasksKind.Text = "Wyniki wyszukiwania";

                // Wyczy�� panel i wy�wietl znalezione taski
                flowLayoutPanel1.Controls.Clear();
                foreach (var task in allResults)
                {
                    AddTaskToPanel(task); // Ponowne dodanie task�w do panelu
                }
            }
            else
            {
                MessageBox.Show("Nie znaleziono task�w pasuj�cych do podanej frazy.", "Brak wynik�w", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            // Zmie� tytu� labela z powrotem na "Aktywne taski"
            lblTasksKind.Text = "Aktywne taski";

            // Wyczy�� panel i ponownie wy�wietl tylko aktywne taski
            flowLayoutPanel1.Controls.Clear();
            foreach (var task in taskList)
            {
                AddTaskToPanel(task);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            // Pobierz wybrane warto�ci z list rozwijanych
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
                        (selectedStatus == "Zamkni�te" && closedTasks.Contains(task))))
                .ToList();

            // Wy�wietl przefiltrowane taski
            DisplayTasks(filteredTasks);
        }

        // Metoda do od�wie�enia wy�wietlania task�w
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
