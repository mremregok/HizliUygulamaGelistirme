﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IDoktorService
    {
        void Ekle(Doktor doktor);
        Doktor Sil(int doktorId);
        void Guncelle(Doktor doktor);
        Doktor Getir(int doktorId);
        Doktor Getir(string TC);
        List<Doktor> TumDoktorlar();
        List<Doktor> Doktorlar(int bolumId);
    }
}
