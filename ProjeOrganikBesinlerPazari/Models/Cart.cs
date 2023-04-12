using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YeniData;

namespace ProjeOrganikBesinlerPazari.Models
{
    public class Cart
    {
        private List<CartLine>_CartLines = new List<CartLine>();

        public List<CartLine> CartLines {

            get { return _CartLines;  }
        }
            
        public void AddProduct(TblUrun Urun,int Quantity)
        {

            var BulunanLine = _CartLines.FirstOrDefault(i => i.Urun.UrunId == Urun.UrunId);

            if (BulunanLine == null)
            {
                _CartLines.Add(new CartLine() { Urun = Urun, Quantity = Quantity });
            }
            else
            {
                BulunanLine.Quantity += Quantity;
            }

        }   
        


        public void DeleteProduct(TblUrun urun)
        {
            _CartLines.RemoveAll(i=>i.Urun.UrunId == urun.UrunId);

        }

        public double TotalPrice()
        {

            return (double)_CartLines.Sum(i => i.Urun.UrunFiyati * i.Quantity);
        }


        public void Clear()
        {

            _CartLines.Clear();
        }

         
    }



    public class CartLine
    {
        public TblUrun Urun { get; set; }
        public int Quantity { get; set; }

    }


}