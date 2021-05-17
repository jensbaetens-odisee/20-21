﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTDD
{
    public interface ISlotDataRepository
    {
        List<Slot> LoadData();
        void RemoveOneItemFromSlot(int slotNumber);
    }
}
