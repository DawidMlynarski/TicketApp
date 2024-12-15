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


            // Dodaj zdarzenie klikni�cia do Label (np. aby wy�wietli� szczeg�y)
            taskLabel.Click += (s, e) =>
            {
                // Tworzymy nowe okno dialogowe i ustawiamy szczeg�y zadania
                TaskDialog dialog = new TaskDialog();
                dialog.SetTaskDetails(task.Title, task.Description);
                var dialogResult = dialog.ShowDialog(); // Wy�wietlenie okna dialogowego
                                                        // Je�eli u�ytkownik zatwierdzi� zmiany, aktualizujemy task
                if (dialogResult == DialogResult.OK)
                {
                    task.Title = dialog.TaskTitle; // Zaktualizuj tytu�
                    task.Description = dialog.TaskDescription; // Zaktualizuj opis

                    // Od�wie� tekst etykiety, aby wy�wietli� zmienione dane
                    taskLabel.Text = $"{task.Id}: {task.Title}";
                }
                else if (dialogResult == DialogResult.Ignore)
                {
                    // Zamkni�cie taska: przenosimy go do listy zamkni�tych
                    closedTasks.Add(task); // Dodajemy do listy zamkni�tych
                    flowLayoutPanel1.Controls.Remove(taskLabel);
                }
            };

            // Dodanie etykiety do FlowLayoutPanel
            flowLayoutPanel1.Controls.Add(taskLabel);
        }
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

                // Stw�rz nowy task
                Task newTask = new Task(int.Parse(taskId), title, description);
                taskList.Add(newTask); // Dodaj do listy
                nextTaskId++; // Zwi�ksz Id kolejnego taska

                // Wy�wietl task w FlowLayoutPanel
                AddTaskToPanel(newTask);
            }
        }

    }
}
