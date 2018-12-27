﻿using System;
using System.Collections.Generic;
using Homan.BLL.Models;
using Homan.BLL.Utilities;

namespace Homan.BLL.Services.Abstract
{
    public interface IHomeSpaceService
    {
        Result<HomeSpaceModel> GetHomeSpace(Guid id);
        Result Create(HomeSpaceModel homeSpace, Guid userId);
        Result<IEnumerable<HomeSpaceModel>> GetHomeSpacesByUser(Guid userId);
    }
}