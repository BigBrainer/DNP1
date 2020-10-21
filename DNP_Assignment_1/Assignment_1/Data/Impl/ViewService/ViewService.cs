using FileData;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Viewing
{
    public class ViewService : IViewService
    {
        public IList<Family> families;
        public FileContext fileContext;
        public ViewService()
        {
            fileContext = new FileContext();
        }
        public List<Family> LoadFamily()
        {
            families = fileContext.Families;
            return (List<Family>)families;
        }


    }
}
