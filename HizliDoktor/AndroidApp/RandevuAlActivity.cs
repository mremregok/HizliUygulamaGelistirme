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
using Autofac;
using Business.Abstract;
using Entities.Concrete;

namespace AndroidApp
{
    [Activity(Label = "Randevu Al", Theme = "@style/AppTheme")]
    public class RandevuAlActivity : AppCompatActivity
    {
        IRandevuService randevuService;
        IHastaneService hastaneService;
        IBolumService bolumService;
        IDoktorService doktorService;
        IHastaService hastaService;

        private GridView gridTarihler;
        private Spinner spinnerIller, spinnerIlceler, spinnerHastaneler, spinnerBolumler, spinnerDoktorlar;
        private Button btnOncekiGun, btnSonrakiGun;
        private TextView lblSeciliTarih;
        private List<Hastane> hastaneler;
        private List<Bolum> bolumler;
        private List<Doktor> doktorlar;
        private DateTime seciliTarih = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1, 8, 0, 0);

        public RandevuAlActivity()
        {
            randevuService = Business.IOCUtil.Container.Resolve<IRandevuService>();
            hastaneService = Business.IOCUtil.Container.Resolve<IHastaneService>();
            bolumService   = Business.IOCUtil.Container.Resolve<IBolumService>();
            doktorService  = Business.IOCUtil.Container.Resolve<IDoktorService>();
            hastaService = Business.IOCUtil.Container.Resolve<IHastaService>();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.randevuAl_layout);

            List<string> hastaneOlanIller = hastaneService.HastaneOlanIller();

            gridTarihler = FindViewById<GridView>(Resource.Id.gridTarihler);

            spinnerIller      = FindViewById<Spinner>(Resource.Id.spinnerIller);
            spinnerIlceler    = FindViewById<Spinner>(Resource.Id.spinnerIlceler);
            spinnerHastaneler = FindViewById<Spinner>(Resource.Id.spinnerHastaneler);
            spinnerBolumler   = FindViewById<Spinner>(Resource.Id.spinnerBolumler);
            spinnerDoktorlar  = FindViewById<Spinner>(Resource.Id.spinnerDoktorlar);

            btnOncekiGun   = FindViewById<Button>(Resource.Id.btnOncekiGun);
            btnSonrakiGun  = FindViewById<Button>(Resource.Id.btnSonrakiGun);
            lblSeciliTarih = FindViewById<TextView>(Resource.Id.lblSeciliTarih);
            lblSeciliTarih.Text = seciliTarih.ToShortDateString();

            ArrayAdapter adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, hastaneOlanIller);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerIller.Adapter = adapter;

            spinnerIller.ItemSelected += SpinnerIller_ItemSelected;
            spinnerIlceler.ItemSelected += SpinnerIlceler_ItemSelected;
            spinnerHastaneler.ItemSelected += SpinnerHastaneler_ItemSelected;
            spinnerBolumler.ItemSelected += SpinnerBolumler_ItemSelected;
            spinnerDoktorlar.ItemSelected += SpinnerDoktorlar_ItemSelected;

            btnOncekiGun.Click += BtnOncekiGun_Click;
            btnSonrakiGun.Click += BtnSonrakiGun_Click;
        }

        private void BtnSonrakiGun_Click(object sender, EventArgs e)
        {
            seciliTarih = seciliTarih.AddDays(1);
            lblSeciliTarih.Text = seciliTarih.ToShortDateString();
            btnOncekiGun.Enabled = true;
        }

        private void BtnOncekiGun_Click(object sender, EventArgs e)
        {
            if (seciliTarih.Day - 1 <= DateTime.Now.Day + 1) btnOncekiGun.Enabled = false;

            seciliTarih = seciliTarih.AddDays(-1);
            lblSeciliTarih.Text = seciliTarih.ToShortDateString();
        }

        private void SpinnerIller_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            List<string> hastaneOlanIlceler = hastaneService.HastaneOlanIlceler((string)spinnerIller.SelectedItem);

            ArrayAdapter adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, hastaneOlanIlceler);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerIlceler.Adapter = adapter;
        }

        private void SpinnerIlceler_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            hastaneler = hastaneService.Hastaneler((string)spinnerIller.SelectedItem, (string)spinnerIlceler.SelectedItem);

            List<string> hastaneAdlari = new List<string>();

            foreach (var item in hastaneler)
            {
                hastaneAdlari.Add(item.Ad);
            }

            ArrayAdapter adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, hastaneAdlari);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerHastaneler.Adapter = adapter;
        }

        private void SpinnerHastaneler_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Hastane hastane = hastaneler[e.Position];

            bolumler = bolumService.Bolumler(hastane.Id);

            List<string> bolumAdlari = new List<string>();

            foreach (var item in bolumler)
            {
                bolumAdlari.Add(item.Ad);
            }

            ArrayAdapter adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, bolumAdlari);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerBolumler.Adapter = adapter;
        }

        private void SpinnerBolumler_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Bolum bolum = bolumler[e.Position];

            doktorlar = doktorService.Doktorlar(bolum.Id);

            List<string> doktorAdlari = new List<string>();

            foreach (var item in doktorlar)
            {
                doktorAdlari.Add(item.Ad);
            }

            ArrayAdapter adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, doktorAdlari);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerDoktorlar.Adapter = adapter;
        }

        private void SpinnerDoktorlar_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.hastaMenu, menu);
            return true;
        }

    }
}
