﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace AndroidApp
{
    [Activity(Label = "Hastane Güncelleme Onay", Theme = "@style/AppTheme")]
    public class HastaneGuncellemeOnayActivity : AppCompatActivity
    {
        Button btnHastaneGuncellemeOnayGoruntule;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.hastaneGuncellemeOnay_layout);

            btnHastaneGuncellemeOnayGoruntule = FindViewById<Button>(Resource.Id.btnHastaneGuncellemeOnayGoruntule);

            btnHastaneGuncellemeOnayGoruntule.Click += BtnHastaneGuncellemeOnayGoruntule_Click;

            // Create your application here
        }

        private void BtnHastaneGuncellemeOnayGoruntule_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(HastaneListeleActivity));
            StartActivity(intent);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.adminMenu, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menuBtnAnasayfa:
                    {
                        return true;
                    }
                case Resource.Id.menuBtnHastaneEkle:
                    {
                        var intent = new Intent(this, typeof(HastaneEkleActivity));
                        StartActivity(intent);
                        return true;
                    }
                case Resource.Id.menuBtnBolumEkle:
                    {
                        var intent = new Intent(this, typeof(BolumEkleActivity));
                        StartActivity(intent);
                        return true;
                    }
                case Resource.Id.menuBtnDoktorEkle:
                    {
                        var intent = new Intent(this, typeof(DoktorEkleActivity));
                        StartActivity(intent);
                        return true;
                    }
                case Resource.Id.menuBtnAdminRandevuKapat:
                    {
                        var intent = new Intent(this, typeof(AdminRandevuKapatActivity));
                        StartActivity(intent);
                        return true;
                    }
                case Resource.Id.menuBtnAdminCikisYap:
                    {
                        var intent = new Intent(this, typeof(GirisYapActivity));
                        StartActivity(intent);
                        return true;
                    }
                case Resource.Id.menuBtnHastaneListele:
                    {
                        var intent = new Intent(this, typeof(HastaneListeleActivity));
                        StartActivity(intent);
                        return true;
                    }

            }
            return base.OnOptionsItemSelected(item);
        }
        
    }
}