using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalK.enO
{
    internal class Product
    {
        int id;
        string name;
        string insctruction;
        Image image;
        decimal priceB;
        decimal priceS;
        GroupP groupP;
        Term term;
        Manufacturer manufacturer;
        FormP formP;
        Doz doz;
        ActiveSub activeSub;

        public Product(int id, string name, string insctruction, Image image, decimal priceB, decimal priceS, GroupP groupP, Term term, Manufacturer manufacturer, FormP formP, Doz doz, ActiveSub activeSub)
        {
            this.id = id;
            this.name = name;
            this.insctruction = insctruction;
            this.image = image;
            this.priceB = priceB;
            this.priceS = priceS;
            this.groupP = groupP;
            this.term = term;
            this.manufacturer = manufacturer;
            this.formP = formP;
            this.doz = doz;
            this.activeSub = activeSub;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Insctruction { get => insctruction; set => insctruction = value; }
        public Image Image { get => image; set => image = value; }
        public decimal PriceB { get => priceB; set => priceB = value; }
        public decimal PriceS { get => priceS; set => priceS = value; }
        internal GroupP GroupP { get => groupP; set => groupP = value; }
        internal Term Term { get => term; set => term = value; }
        internal Manufacturer Manufacturer { get => manufacturer; set => manufacturer = value; }
        internal FormP FormP { get => formP; set => formP = value; }
        internal Doz Doz { get => doz; set => doz = value; }
        internal ActiveSub ActiveSub { get => activeSub; set => activeSub = value; }
    }
}
