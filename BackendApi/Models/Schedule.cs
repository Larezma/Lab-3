﻿using System;
using System.Collections.Generic;

namespace BackendApi.Models;

public partial class Schedule
{
    public int ScheduleId { get; set; }

    public int TrainingId { get; set; }

    public int TrainerId { get; set; }

    public string TrainingType { get; set; } = null!;

    public string DayOfWeek { get; set; } = null!;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public virtual ICollection<TrainersSchedule> TrainersSchedules { get; set; } = new List<TrainersSchedule>();
}
