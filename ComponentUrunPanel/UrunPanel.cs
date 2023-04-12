using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YeniData;

namespace ComponentUrunPanel
{
    public delegate void RxOnUrunSec(VwKategorikUrunler SeciliUrun);
    public partial class UrunPanel: UserControl
    {
        public event RxOnUrunSec OnUrunSec;
       
        public UrunPanel()
        {
            InitializeComponent();
        }

       
        private VwKategorikUrunler FUrun;

        public VwKategorikUrunler Urun   
        {
            get { return GetUrun(); }
            set { setUrun(value); }
        }

        private void setUrun(VwKategorikUrunler value)
        {
            FUrun = value;
            FiyatHesapla(ref FUrun);
            LblUrunAdi.Text = FUrun.UrunAdi;
            LblUrunFiyati.Text = FUrun.Fiyat.ToString("f");
            

        }

        private void FiyatHesapla(ref VwKategorikUrunler UrunBilgi)
        {
            double BirimFiyat = UrunBilgi.Fiyat;
            double KdvOrani = UrunBilgi.KdvOrani;
            UrunBilgi.Fiyat = BirimFiyat + (BirimFiyat+KdvOrani)/100 ;
        }

        private VwKategorikUrunler GetUrun()
        {
            return FUrun;
        }

        private void LblUrunAdi_Click(object sender, EventArgs e)
        {
            if (OnUrunSec != null)
                OnUrunSec(FUrun);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (OnUrunSec != null)
                OnUrunSec(FUrun);
        }

        private void LblUrunFiyati_Click(object sender, EventArgs e)
        {
            if (OnUrunSec != null)
                OnUrunSec(FUrun);
        }
    }
}
