using AmlService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmlService.Repository
{
    public interface IAmlDataAccess
    {
        void SaveData(AmlData data);
    }
}
