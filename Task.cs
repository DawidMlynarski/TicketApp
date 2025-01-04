using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketApp
{
    public class Task
    {
        public int Id { get; set; }          // Numer taska
        public string Title { get; set; }   // Tytuł taska
        public string Description { get; set; } // Szczegółowy opis taska
        public string Priority { get; set; } //priorytet taska
        public string AssignedConsultant { get; set; } // Przypisany konsultant
        public List<string> Entries { get; set; } // Lista wpisów

        public Task(int id, string title, string description, string priority, string assignedConsultant)
        {
            Id = id;
            Title = title;
            Description = description;
            Priority = priority;
            AssignedConsultant = assignedConsultant;
            Entries = new List<string>(); // Inicjalizacja pustej listy wpisów
        }
    }

}
