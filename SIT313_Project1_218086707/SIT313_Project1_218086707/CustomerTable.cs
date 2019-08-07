using System;
using SQLite;
namespace SIT313_Project1_218086707
{
    public class CustomerTable
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int id { get; set; }
        [MaxLength(25)]
        public string CustomerName { get; set; }
        [MaxLength(25)]
        public string CustomerID { get; set; }
        [MaxLength(25)]
        public string CustomerPW { get; set; }

    }
}
