using System;
using System.Collections.Generic;

namespace BackendApi.Models;

public partial class Training
{
    public int Id { get; set; }

    public int TrainingId { get; set; }

    public DateTime TrainingDate { get; set; }

    public string DurationMinutes { get; set; } = null!;

    public decimal CaloriesBurned { get; set; }

    public string? Notes { get; set; }

    public string TrainingType { get; set; } = null!;

    public virtual ICollection<UserTraining> UserTrainings { get; set; } = new List<UserTraining>();
}
