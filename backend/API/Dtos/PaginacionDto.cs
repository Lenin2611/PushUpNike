using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PaginacionDto
    {
        public int Page { get; set; } = 1;
        private int recordsPerPage = 5;
        private readonly int MaxQuantityPerPage = 10;
        public int RecordsPerPage
        {
            get { return recordsPerPage; }
            set { recordsPerPage = (value > MaxQuantityPerPage) ? MaxQuantityPerPage : value; } //previene que el usuario mande cantidades incoherentes de registros por página
        }
    }
}