using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk4
{
    class DeskQuote
    {
        public enum Delivery
        {
            Rush3Days = 3,
            Rush5Days = 5,
            Rush7Days = 7,
            NoRush14Days = 14
        }

        public DeskQuote(Desk desk, string customerName, int deliveryTime, DateTime orderDate)
        {
            Desk = desk;
            CustomerName = customerName;
            DeliveryTime = deliveryTime;
            OrderDate = orderDate;

            CalcQuote();
        }

        public DateTime OrderDate { get; set; }

        public string CustomerName { get; set; }

        public decimal Price { get; set; }

        public int DeliveryTime { get; set; }

        public Desk Desk { get; set; }

        public void CalcQuote()
        {
            // calcualte surface area
            decimal surfaceArea = Desk.Depth * Desk.Width;

            var rushFee = 0;

            // calculate size (0 -> small, 1-> medium, 2-> large)
            int size = ((int)surfaceArea == 2000) ? 1 : (int)surfaceArea / 1000;
            if (size > 2)
            {
                size = 2;
            }

            // Add cost of drawers
            Price = Desk.NumDrawers * 50;

            // 1$ per square inch AFTER $1,000 OR 200
            Price += (size > 0)? surfaceArea - 1000 : 200;

            // calculate material cost
            Price += Desk.SurfaceMaterial;

            // add rush delivery fee if applicable
            switch(DeliveryTime)
            {
                case 3:
                    rushFee = 60 + (10 * size);
                    break;

                case 5:
                    rushFee = 40 + (10 * size);
                    break;

                case 7:
                    rushFee = 30 + (5 * size);
                    break;
            }

            Price += rushFee;
        }
    }
}
