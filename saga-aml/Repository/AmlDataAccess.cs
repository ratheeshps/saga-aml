using AmlService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmlService.Repository
{
    public class AmlDataAccess : IAmlDataAccess
    {
        public void SaveData(AmlData data)
        {
            using (var db=new TraxDbContext())
            {
                db.AmlTransactions.Add(data);
                db.SaveChanges();
            }
        }
    }
}
