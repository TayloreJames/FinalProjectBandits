using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBandits.Models.Enums
{

    public enum ItemStatus
    {
        Open,
        CheckedOut,
        Done,
        Deleted,
        Edited
    }

    public enum ItemCategory
    {
        PhysicalLabor,
        Financial,
        ItemsNeeded,
        LearningSkill,
        Transportation,
        HomeCare
    }

}
