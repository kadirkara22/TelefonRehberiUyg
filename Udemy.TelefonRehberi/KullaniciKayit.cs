using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Udemy.TelefonRehberi
{
    public partial class KullaniciKayit : Form
    {
        public KullaniciKayit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer.BLL BLL = new BusinessLogicLayer.BLL();
          int ReturnValue=  BLL.KullaniciEkle(txt_yeni_kullaniciadi.Text,txt_y_kullanicisifre.Text,txt_y_kullanicisifretekrar.Text,txt_kullanici_soru.Text,txt_kullanici_cevap.Text);
            if(ReturnValue!=0)
            {
                if (ReturnValue > 0)
                {
                    MessageBox.Show("Yeni Kullanici Eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_yeni_kullaniciadi.Clear();
                    txt_y_kullanicisifre.Clear();
                    txt_y_kullanicisifretekrar.Clear();
                    txt_kullanici_soru.Clear();
                    txt_kullanici_cevap.Clear();
                    
                }
                else
                {
                    MessageBox.Show("Şifreler Uyuşmuyor", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_yeni_kullaniciadi.Clear();
                    txt_y_kullanicisifre.Clear();
                    txt_y_kullanicisifretekrar.Clear();
                    txt_kullanici_soru.Clear();
                    txt_kullanici_cevap.Clear();
                }

            }
            else
            {
                MessageBox.Show("Farklı Kullanıcı Adı Giriniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            

        }
    }
}
