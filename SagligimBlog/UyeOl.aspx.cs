using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace SagligimBlog
{
    public partial class UyeOl : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lb_uyeOl_Click(object sender, EventArgs e)
        {

            if(!string.IsNullOrEmpty(tb_isim.Text) && !string.IsNullOrEmpty(tb_soyad.Text) && !string.IsNullOrEmpty(tb_kullaniciAdi.Text) && !string.IsNullOrEmpty(tb_mail.Text) && !string.IsNullOrEmpty(tb_sifre.Text) && !string.IsNullOrEmpty(tb_sifreTekrar.Text))
            {
                Uye uye = new Uye();
                uye.Isim = tb_isim.Text;
                uye.Soyisim = tb_soyad.Text;
                uye.KullaniciAdi = tb_kullaniciAdi.Text;
                uye.Mail = tb_mail.Text;
                uye.Sifre = tb_sifre.Text;
                uye.UyelikTarihi = DateTime.Now;
                uye.Durum = true;

                if (tb_sifre.Text == tb_sifreTekrar.Text)
                {
                    if (dm.UyeOl(uye))
                    {
                        pnl_basarili.Visible = true;
                        pnl_basarisiz.Visible = false;
                        tb_isim.Text = "";
                        tb_soyad.Text = "";
                        tb_kullaniciAdi.Text = "";
                        tb_mail.Text = "";
                        tb_sifre.Text = "";
                        tb_sifreTekrar.Text = "";
                    }
                    else
                    {
                        pnl_basarili.Visible = false;
                        pnl_basarisiz.Visible = true;
                        lbl_mesaj.Text = "Üye olunurken bir hata oluştu";
                    }
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Parolarınız eşleşmedi.Lütfen kontrol edip tekrar giriniz";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Boş Alan Bırakılamaz!";
            }
           
            
        }
    }
}