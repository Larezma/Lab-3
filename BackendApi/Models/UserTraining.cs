﻿using System;
using System.Collections.Generic;

namespace BackendApi.Models;

public partial class UserTraining
{
    public int Id { get; set; }

    public int TrainingId { get; set; }

    public int UserId { get; set; }

    public int? TrainerId { get; set; }

    public string DayOfWeek { get; set; } = null!;

    public DateTime StartAt { get; set; }

    public DateTime EndAt { get; set; }

    public string Duration { get; set; } = null!;

    public string? Notes { get; set; }

    public string TrainingStatus { get; set; } = null!;

    public virtual Trainer? Trainer { get; set; }

    public virtual Training Training { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
