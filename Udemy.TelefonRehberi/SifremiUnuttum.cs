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
    public partial class SifremiUnuttum : Form
    {
        public SifremiUnuttum()
        {
            InitializeComponent();
        }

        private void btn_gg_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer.BLL BLL = new BusinessLogicLayer.BLL();
            int ReturnValue = BLL.KullaniciDüzenle(txt_gg_kullaniciadi.Text, txt_gg_kullanicisifre.Text, txt_gg_kullanicisifretekrar.Text, txt_gg_kullanici_soru.Text, txt_gg_kullanici_cevap.Text);
            if(ReturnValue!=0)
            {
                if(ReturnValue>0)
                {
                    MessageBox.Show(" Kullanici Güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_gg_kullaniciadi.Clear();
                    txt_gg_kullanicisifre.Clear();
                    txt_gg_kullanicisifretekrar.Clear();
                    txt_gg_kullanici_soru.Clear();
                    txt_gg_kullanici_cevap.Clear();
                }
                else
                {
                    MessageBox.Show("Soru ve Cevabınız doğru giriniz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_gg_kullaniciadi.Clear();
                    txt_gg_kullanicisifre.Clear();
                    txt_gg_kullanicisifretekrar.Clear();
                    txt_gg_kullanici_soru.Clear();
                    txt_gg_kullanici_cevap.Clear();
                }
            }
            else
            {
                MessageBox.Show(".", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_gg_kullaniciadi.Clear();
                txt_gg_kullanicisifre.Clear();
                txt_gg_kullanicisifretekrar.Clear();
                txt_gg_kullanici_soru.Clear();
                txt_gg_kullanici_cevap.Clear();
            }

        }
    }
}
