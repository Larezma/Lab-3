using System;
using System.Collections.Generic;

namespace BackendApi.Models;

public partial class Trainer
{
    public int TrainerId { get; set; }

    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string MiddleName { get; set; } = null!;

    public string? LastName { get; set; }

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public DateTime CreateAt { get; set; }

    public string Password { get; set; } = null!;

    public virtual ICollection<TrainersSchedule> TrainersSchedules { get; set; } = new List<TrainersSchedule>();

    public virtual User User { get; set; } = null!;

    public virtual ICollection<UserTraining> UserTrainings { get; set; } = new List<UserTraining>();
}
