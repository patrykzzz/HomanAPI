﻿using System;
using Homan.DAL.Entities;

namespace Homan.DAL.Repositories.Abstract
{
    public interface IHomeSpaceItemRepository : IRepository<HomeSpaceItem>
    {
        void Add(HomeSpaceItem homeSpaceItem);
        void Update(HomeSpaceItem homeSpaceItem);
        void Remove(Guid id);
        HomeSpaceItem Get(Guid id);
    }
}