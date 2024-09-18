using DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace DataAccessLayer
{
  public  interface IDetailsRepository
    {
        public void InsertDetails(Details reg);
        public void UpdateDetatils(Details reg);
        public void DeleteTable(long reg);
        public List<Details> showallname();
        public Details showDetailsbyName(string name);

    }
}
