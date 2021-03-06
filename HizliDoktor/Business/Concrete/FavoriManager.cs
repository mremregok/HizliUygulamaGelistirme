﻿using Autofac;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class FavoriManager : IFavoriService
    {
        IFavoriDal favoriDal;

        public FavoriManager(IFavoriDal _favoriDal)
        {
            favoriDal = _favoriDal;
        }

        public void Ekle(Favori favori)
        {
            favoriDal.Add(favori);
        }

        public List<Favori> Favoriler(int hastaId)
        {
            List<Favori> favoriler = favoriDal.GetList(x => x.HastaId == hastaId);

            return favoriler;
        }

        public Favori Getir(int favoriId)
        {
            Favori favori = favoriDal.Get(x => x.Id == favoriId);
            return favori;
        }

        public Favori Getir(int hastaId, int doktorId)
        {
            Favori favori = favoriDal.Get(x => x.HastaId == hastaId && x.DoktorId == doktorId);
            return favori;
        }

        public Favori Sil(int favoriId)
        {
            Favori favori = Getir(favoriId);
            favoriDal.Delete(favori);
            return favori;
        }
    }
}
