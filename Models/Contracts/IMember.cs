﻿using System.Collections.Generic;

namespace TaskManagement.Models.Contracts
{
    public interface IMember : INameable, IHistoryable
    {
      List<ITask> Tasks { get; }
    }
}
