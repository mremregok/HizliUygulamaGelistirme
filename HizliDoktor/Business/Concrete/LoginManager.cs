﻿using Autofac;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class LoginManager : ILoginService
    {
        IHastaDal hastaDal;
        IDoktorDal doktorDal;

        public LoginManager()
        {
            hastaDal = IOCUtil.Container.Resolve<IHastaDal>();
            doktorDal = IOCUtil.Container.Resolve<IDoktorDal>();
        }

        public bool GirisYap(string TC, string sifre, bool yoneticiGirisi)
        {
            if (yoneticiGirisi && TC == "1" && sifre == "admin") return true;

            if (yoneticiGirisi)
            {
                Doktor doktor = doktorDal.Get(x => x.TC == TC);

                return (doktor != null && doktor.Sifre == sifre);
            }
            else
            {
                Hasta hasta = hastaDal.Get(x => x.TC == TC);

                return (hasta != null && hasta.Sifre == sifre);
            }
        }

        public bool UyeOl(Hasta hasta)
        {
            throw new NotImplementedException();
        }
    }
}
