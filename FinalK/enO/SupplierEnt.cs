using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalK.enO
{
    internal class SupplierEnt
    {
        int id;
        string name;
        string telephone;
        string address;

        public SupplierEnt(int id, string name, string telephone, string address)
        {
            this.id = id;
            this.name = name;
            this.telephone = telephone;
            this.address = address;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public string Address { get => address; set => address = value; }
    }
}
