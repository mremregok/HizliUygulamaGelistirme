﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IHastaService
    {
        void Ekle(Hasta hasta);
        Hasta Sil(int hastaId);
        void Guncelle(Hasta hasta);
        Hasta Getir(string TC);
    }
}