﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kaenTaVen_V2
{
    public struct RevenueByDate
    {
        public string Date { get; set; }
        public decimal TotalAmount { get; set; }
    }
    public class Dashboard : DbConnection
    {
        //Fields & Properties
        private DateTime startDate;
        private DateTime endDate;
        private int numberDays;

        public int NumCustomers { get; private set; }
        public int NumSuppliers { get; private set; }
        public int NumProducts { get; private set; }
        public List<KeyValuePair<string, float>> TopProductsList { get; private set; }
        public List<KeyValuePair<string, float>> UnderstockList { get; private set; }
        public List<RevenueByDate> GrossRevenueList { get; private set; }
        public int NumOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalProfit { get; set; }

        //Constructor
        public Dashboard()
        {

        }

        Connector con = new Connector();
        //Private methods
        private void GetNumberItems()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;

                    //Get Total Number of Customers
                    command.CommandText = "SELECT COUNT(customer_id) FROM tbCustomer";
                    NumCustomers = (int)command.ExecuteScalar();

                    //Get Total Number of Suppliers
                    command.CommandText = "SELECT COUNT(supplier_id) FROM tbSupplier";
                    NumSuppliers = (int)command.ExecuteScalar();

                    //Get Total Number of Products
                    command.CommandText = "SELECT COUNT(product_id) FROM tbProduct";
                    NumProducts = (int)command.ExecuteScalar();

                    //Get Total Number of Orders
                    command.CommandText = @"SELECT COUNT(invoice_id) FROM tbInvoice WHERE date_recorded BETWEEN @fromDate AND @toDate";
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    NumOrders = (int)command.ExecuteScalar();
                }
            }
                
            }
        
        private void GetProductAnalisys()
        {
            TopProductsList = new List<KeyValuePair<string, float>>();
            UnderstockList = new List<KeyValuePair<string, float>>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    SqlDataReader reader;
                    command.Connection = connection;
                    //Get Top 5 products
                    command.CommandText = @"SELECT TOP 5 P.product_name, SUM(Order_detail.quantity) AS total_sale FROM Order_detail INNER JOIN tbProduct P ON P.product_id = Order_detail.product_id INNER JOIN tbInvoice I ON I.invoice_id = Order_detail.invoice_id WHERE date_recorded BETWEEN @fromDate AND @toDate GROUP BY P.product_name ORDER BY total_sale DESC";
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TopProductsList.Add(new KeyValuePair<string, float>(reader[0].ToString(), float.Parse(reader[1].ToString())));
                    }
                    reader.Close();

                    //Get Understock
                    command.CommandText = @"SELECT P.product_name, tbStock.quantity AS Low_Stock FROM tbStock INNER JOIN tbProduct P ON P.product_id = tbStock.product_id WHERE quantity <= 150";
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        UnderstockList.Add(new KeyValuePair<string, float>(reader[0].ToString(), float.Parse(reader[1].ToString())));
                    }
                    reader.Close();
                }
            }
                
            
        }
        private void GetOrderAnalisys()
        {
            GrossRevenueList = new List<RevenueByDate>();
            TotalProfit = 0;
            TotalRevenue = 0;

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = @"SELECT tbInvoice.date_recorded, SUM(tbSales.total_bill_amount) AS total_amount FROM tbInvoice INNER JOIN tbSales ON tbInvoice.invoice_id = tbSales.invoice_id WHERE date_recorded BETWEEN @fromDate AND @toDate GROUP BY date_recorded;	";
                    command.Parameters.Add("@fromDate", System.Data.SqlDbType.DateTime).Value = startDate;
                    command.Parameters.Add("@toDate", System.Data.SqlDbType.DateTime).Value = endDate;
                    var reader = command.ExecuteReader();
                    var resultTable = new List<KeyValuePair<DateTime, decimal>>();
                    while (reader.Read())
                    {
                        resultTable.Add(
                            new KeyValuePair<DateTime, decimal>((DateTime)reader[0], decimal.Parse(reader[1].ToString()))
                            );
                        TotalRevenue += decimal.Parse(reader[1].ToString());
                    }
                    TotalProfit = TotalRevenue * 0.2m;//20%
                    reader.Close();

                    //Group by Hours
                    if (numberDays <= 1)
                    {
                        GrossRevenueList = (from orderList in resultTable
                                            group orderList by orderList.Key.ToString("hh tt")
                                            into order
                                            select new RevenueByDate
                                            {
                                                Date = order.Key,
                                                TotalAmount = order.Sum(amount => amount.Value)
                                            }).ToList();
                    }
                    //Group by Days
                    else if (numberDays <= 30)
                    {
                        GrossRevenueList = (from orderList in resultTable
                                            group orderList by orderList.Key.ToString("dd MMM")
                                           into order
                                            select new RevenueByDate
                                            {
                                                Date = order.Key,
                                                TotalAmount = order.Sum(amount => amount.Value)
                                            }).ToList();
                    }

                    //Group by Weeks
                    else if (numberDays <= 92)
                    {
                        GrossRevenueList = (from orderList in resultTable
                                            group orderList by CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                                                orderList.Key, CalendarWeekRule.FirstDay, DayOfWeek.Monday)
                                            into order
                                            select new RevenueByDate
                                            {
                                                Date = "Week " + order.Key.ToString(),
                                                TotalAmount = order.Sum(amount => amount.Value)
                                            }).ToList();
                    }

                    //Group by Months
                    else if (numberDays <= (365 * 2))
                    {
                        bool isYear = numberDays <= 365 ? true : false;
                        GrossRevenueList = (from orderList in resultTable
                                            group orderList by orderList.Key.ToString("MMM yyyy")
                                           into order
                                            select new RevenueByDate
                                            {
                                                Date = isYear ? order.Key.Substring(0, order.Key.IndexOf(" ")) : order.Key,
                                                TotalAmount = order.Sum(amount => amount.Value)
                                            }).ToList();
                    }

                    //Group by Years
                    else
                    {
                        GrossRevenueList = (from orderList in resultTable
                                            group orderList by orderList.Key.ToString("yyyy")
                                           into order
                                            select new RevenueByDate
                                            {
                                                Date = order.Key,
                                                TotalAmount = order.Sum(amount => amount.Value)
                                            }).ToList();
                    }

                }
            }
        }

        //Public methods
        public bool LoadData(DateTime startDate, DateTime endDate)
        {
            endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day,
                endDate.Hour, endDate.Minute, 59);
            if (startDate != this.startDate || endDate != this.endDate)
            {
                this.startDate = startDate;
                this.endDate = endDate;
                this.numberDays = (endDate - startDate).Days;

                GetNumberItems();
                GetProductAnalisys();
                GetOrderAnalisys();
                Console.WriteLine("Refreshed data: {0} - {1}", startDate.ToString(), endDate.ToString());
                return true;
            }
            else
            {
                Console.WriteLine("Data not refreshed, same query: {0} - {1}", startDate.ToString(), endDate.ToString());
                return false;
            }
        }
    }
}
