using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.RequestParameters
{
    public class Pagination
    {
        public int Page { get; set; } = 1;

        private int size;

        public int Size
        {
            get { return size; }
            set { size = value > 100 ? 100 : value; }
        }
    }
}
