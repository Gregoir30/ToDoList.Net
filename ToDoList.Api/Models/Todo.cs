using System;

namespace ToDoList.Api.Models
{
    public class Todo
    {
        // Propriétés de la tâche
        public int Id { get; set; } // Identifiant unique

        // Utilisation de "required" pour garantir l'initialisation (C# 11 et versions ultérieures)
        public required string Title { get; set; } // Titre obligatoire
        public required string Description { get; set; } // Description obligatoire

        public bool IsCompleted { get; set; } = false; // Initialisé à "non terminé"
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Initialisé à la date/heure actuelle

        public DateTime? DueDate { get; set; } // Date d'échéance optionnelle
        public string Priority { get; set; } = "Medium"; // Par défaut à "Medium"

        // Utilisation de "required" pour garantir l'initialisation
        public required string AssignedTo { get; set; } // Obligatoire pour l'assignation

        // Constructeur sans paramètres (nécessaire pour Entity Framework)
        public Todo()
        {
        }

        // Constructeur avec paramètres pour plus de flexibilité
        public Todo(string title, string description, string assignedTo, string priority = "Medium")
        {
            Title = title;
            Description = description;
            AssignedTo = assignedTo;
            Priority = priority;
        }

        // Méthode pour marquer la tâche comme terminée
        public void MarkAsCompleted()
        {
            IsCompleted = true;
        }

        // Méthode pour modifier la priorité
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

        // Méthode pour prolonger la date d'échéance
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

        // Méthode pour afficher les détails d'une tâche
        public override string ToString()
        {
            return $"Todo [Id={Id}, Title={Title}, IsCompleted={IsCompleted}, Priority={Priority}, DueDate={DueDate?.ToString("yyyy-MM-dd")}, AssignedTo={AssignedTo}]";
        }
    }
}
