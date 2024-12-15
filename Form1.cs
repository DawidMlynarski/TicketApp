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

            // Dodaj zdarzenie klikniêcia do Label (np. aby wyœwietliæ szczegó³y)
            taskLabel.Click += (s, e) =>
            {
                MessageBox.Show($"Task {task.Id}\n\n{task.Description}", "Szczegó³y Taska");
            };

            // Dodanie etykiety do FlowLayoutPanel
            flowLayoutPanel1.Controls.Add(taskLabel);
        }
        private void AddTaskButton_Click(object sender, EventArgs e)
        {
            // Tworzenie nowego taska
            string title = $"Task {nextTaskId}"; // Przyk³adowy tytu³
            string description = $"Opis dla Taska {nextTaskId}"; // Przyk³adowy opis
            Task newTask = new Task(nextTaskId, title, description);

            // Dodanie taska do listy
            taskList.Add(newTask);
            nextTaskId++; // Zwiêksz Id kolejnego taska

            // Wyœwietlenie taska w FlowLayoutPanel
            AddTaskToPanel(newTask);
        }
    }
}
