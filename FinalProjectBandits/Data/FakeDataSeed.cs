using FinalProjectBandits.Models;
using FinalProjectBandits.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectBandits.Data
{
    public class FakeDataSeed
    {
        public static List<TaskListItem> GetTaskListItems()
        {
            List<TaskListItem> Items = new List<TaskListItem>();

            for (int i = 1; i < 20; i++)
            {
                TaskListItem Item = new TaskListItem();
                Item.Id = i;
                Item.TaskTitle = "Title of Item " + i.ToString();
                Item.TaskDescription = "This is a thing I need done.";
                if (i % 2 == 0)
                {
                    Item.Status = ItemStatus.CheckedOut;
                    Item.Category = ItemCategory.PhysicalLabor;
                    Item.DatePosted = new DateTime(2020, 11, i);
                }

                else if (i % 3 == 0)
                {
                    Item.Status = ItemStatus.Done;
                    Item.Category = ItemCategory.LearningSkill;
                    Item.DatePosted = new DateTime(2020, 10, i);
                }
                else
                {
                    Item.Status = ItemStatus.Open;
                    Item.Category = ItemCategory.HomeCare;
                    Item.DatePosted = new DateTime(2020, 12, i);
                }

                Items.Add(Item);
            }

            return Items;
        }
    }
}
