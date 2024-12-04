using System;

namespace ToDoList.Api.Models
{
    public class Todo
    {
        // Propri�t�s de la t�che
        public int Id { get; set; } // Identifiant unique

        // Utilisation de "required" pour garantir l'initialisation (C# 11 et versions ult�rieures)
        public required string Title { get; set; } // Titre obligatoire
        public required string Description { get; set; } // Description obligatoire

        public bool IsCompleted { get; set; } = false; // Initialis� � "non termin�"
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Initialis� � la date/heure actuelle

        public DateTime? DueDate { get; set; } // Date d'�ch�ance optionnelle
        public string Priority { get; set; } = "Medium"; // Par d�faut � "Medium"

        // Utilisation de "required" pour garantir l'initialisation
        public required string AssignedTo { get; set; } // Obligatoire pour l'assignation

        // Constructeur sans param�tres (n�cessaire pour Entity Framework)
        public Todo()
        {
        }

        // Constructeur avec param�tres pour plus de flexibilit�
        public Todo(string title, string description, string assignedTo, string priority = "Medium")
        {
            Title = title;
            Description = description;
            AssignedTo = assignedTo;
            Priority = priority;
        }

        // M�thode pour marquer la t�che comme termin�e
        public void MarkAsCompleted()
        {
            IsCompleted = true;
        }

        // M�thode pour modifier la priorit�
        public void SetPriority(string priority)
        {
            if (priority == "High" || priority == "Medium" || priority == "Low")
            {
                Priority = priority;
            }
            else
            {
                throw new ArgumentException("Invalid priority. Allowed values: High, Medium, Low.");
            }
        }

        // M�thode pour prolonger la date d'�ch�ance
        public void ExtendDueDate(int days)
        {
            if (DueDate.HasValue)
            {
                DueDate = DueDate.Value.AddDays(days);
            }
            else
            {
                throw new InvalidOperationException("Cannot extend due date. No due date is set.");
            }
        }

        // M�thode pour afficher les d�tails d'une t�che
        public override string ToString()
        {
            return $"Todo [Id={Id}, Title={Title}, IsCompleted={IsCompleted}, Priority={Priority}, DueDate={DueDate?.ToString("yyyy-MM-dd")}, AssignedTo={AssignedTo}]";
        }
    }
}
