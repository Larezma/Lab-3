using System;
using System.Collections.Generic;

namespace BackendApi.Models;

public partial class TrainersSchedule
{
    public int Id { get; set; }

    public int ScheduleId { get; set; }

    public int TrainerId { get; set; }

    public string? TypeOfTraining { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly Time { get; set; }

    public DateTime CreateAt { get; set; }

    public virtual Schedule Schedule { get; set; } = null!;

    public virtual Trainer Trainer { get; set; } = null!;
}
