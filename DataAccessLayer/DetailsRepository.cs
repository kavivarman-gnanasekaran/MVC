using DataAccessLayer.Entity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    
      public  class DetailsRepository: IDetailsRepository
    {
        DetailsDbContext con = null;
        public DetailsRepository(DetailsDbContext regis)
        {
            con = regis;
        }

        public void InsertDetails(Details reg)
        {

            try
            {
                con.Add(reg);
                con.SaveChanges();

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public List<Details> showallname()
        {
            try
            {
                return con.Detail.ToList();

            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public Details showDetailsbyName(string Name)
        {
            try
            {
                return con.Detail.FirstOrDefault(X => X.Name == Name);

            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public void UpdateDetatils(Details reg)
        {
            try
            {
                con.Update(reg);
                con.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void DeleteTable(long DoctorDetailsID)
        {
            try
            {
                var count = con.Detail.Find(DoctorDetailsID);
                con.Remove(count);
                con.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}

