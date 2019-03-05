using Bill.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bill.Model.DTO
{
    public class BillsDTO:Bills
    {
        /// <summary>
        /// 账单类型名称
        /// </summary>
        public string BillsTypeName { get; set; }
    }
}
