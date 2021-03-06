﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRandevuService
    {
        List<Randevu> TumRandevular(int hastaneId);
        List<Randevu> DoktorRandevulari(int doktorId);
        List<Randevu> HastaRandevulari(int hastaId);
        List<Randevu> BolumRandevulari(int bolumId);
        List<DateTime> MusaitTarihleriGetir(int doktorId, DateTime gun);
        bool Ekle(Randevu randevu);
        Randevu Sil(int randevuId);
        void RandevuMailiGonder(string hastaMail, string mesaj);
        Randevu Getir(DateTime randevuTarihi);
    }
}
