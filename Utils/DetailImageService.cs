﻿using System.Collections.Generic;
using DetailWinner.Data;
using DetailWinner.Interfaces;

namespace DetailWinner.Utils;

public class DetailImageService : IDetailImageService
{
    public List<DetailImage> DetailImages { get; set; } = [new()];
}