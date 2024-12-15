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

        public Task(int id, string title, string description, string priority)
        {
            Id = id;
            Title = title;
            Description = description;
            Priority = priority;
        }
    }

}
