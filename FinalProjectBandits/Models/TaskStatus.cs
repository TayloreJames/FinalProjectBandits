using System;
using System.ComponentModel.DataAnnotations;
using FinalProjectBandits.Models.Enums;

namespace FinalProjectBandits.Models
{
    public class TaskStatus
    {
        public int ID { get; set; }

        [EnumDataType(typeof(ItemStatus))]
        public ItemStatus Status { get; set; }

        public Customer Customer { get; set; }
    }
}
