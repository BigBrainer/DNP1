using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace ManageService
{
    interface IRemoveService
    {
        void RemoveMember(Family familyToRemoveFrom, int adultId);
    }
}
