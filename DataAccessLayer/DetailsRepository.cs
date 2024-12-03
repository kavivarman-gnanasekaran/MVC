using ClosedXML.Excel;
using DataAccessLayer.Entity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
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
        //This Method will Stream Object as an input which contains the Excel file
        //And then convert that Excel file to List of Employees
        public List<Details> ParseExcelFile(Stream stream)
        {
            var employees = new List<Details>();

            //Create a workbook instance
            //Opens an existing workbook from a stream.
            using (var workbook = new XLWorkbook(stream))
            {
                //Lets assume the First Worksheet contains the data
                var worksheet = workbook.Worksheet(1);

                //Lets assume first row contains the header, so skip the first row
                var rows = worksheet.RangeUsed().RowsUsed().Skip(1);

                //Loop Through all the Rows except the first row which contains the header data
                foreach (var row in rows)
                {
                    //Create an Instance of Employee object and populate it with the Excel Data Row
                    var employee = new Details
                    {
                        DoctorDetailsID = row.Cell(1).GetValue<long>(),

                        Name = row.Cell(2).GetValue<string>(),

                        Degree = row.Cell(3).GetValue<string>(),

                        UID = row.Cell(4).GetValue<long>(),

                        DateofBirth = row.Cell(5).GetValue<DateTime>(),

                        HospitalName = row.Cell(6).GetValue<string>(),

                        MobileNumber = row.Cell(7).GetValue<long>()
                    };

                    //Add the Employee to the List of Employees
                    employees.Add(employee);
                }
            }

            //Finally return the List of Employees
            return employees;
        }

    }
}

