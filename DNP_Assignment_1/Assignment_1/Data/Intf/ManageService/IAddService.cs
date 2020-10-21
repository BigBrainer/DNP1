using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageService
{
    interface IAddService
    {
        bool AddressTakenCheck(Family family);
        void AddAdults(Family family, List<Adult> adults);
        void AddFamily(Family family);
    }
}
