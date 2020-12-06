using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBandits.Models.Enums
{

    public enum ItemStatus
    {
        Open = 1,
        CheckedOut = 2,
        Done = 3,
        Deleted = 4,
        Edited = 5
    }

    public enum ItemCategory
    {
        PhysicalLabor = 1,
        Financial = 2,
        ItemsNeeded = 3,
        LearningSkill = 4,
        Transportation = 5,
        HomeCare = 6
    }

}
