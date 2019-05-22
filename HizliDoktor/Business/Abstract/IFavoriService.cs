﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    interface IFavoriService
    {
        void Ekle(Favori favori);
        Favori Sil(int favoriId);
        Favori Getir(int favoriId);
        List<Favori> Favoriler();
    }
}
