﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Business.Abstract;
using Business.Concrete;

namespace Business
{
    public static class IOCUtil
    {
        public static IContainer Container { get; set; }

        static IOCUtil()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<BolumDal>().As<IBolumDal>();
            builder.RegisterType<DoktorDal>().As<IDoktorDal>();
            builder.RegisterType<HastaDal>().As<IHastaDal>();
            builder.RegisterType<HastaneDal>().As<IHastaneDal>();
            builder.RegisterType<RandevuDal>().As<IRandevuDal>();
            builder.RegisterType<FavoriDal>().As<IFavoriDal>();

            builder.RegisterType<BolumManager>().As<IBolumService>();
            builder.RegisterType<LoginManager>().As<ILoginService>();
            builder.RegisterType<RandevuManager>().As<IRandevuService>();
            builder.RegisterType<HastaneManager>().As<IHastaneService>();
            builder.RegisterType<DoktorManager>().As<IDoktorService>();
            builder.RegisterType<HastaManager>().As<IHastaService>();
            builder.RegisterType<FavoriManager>().As<IFavoriService>();


            Container = builder.Build();
        }
    }
}
