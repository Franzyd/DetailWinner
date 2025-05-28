using System.Collections.Generic;
using DetailWinner.Data;

namespace DetailWinner.Interfaces;

public interface IDetailImageService
{
    List<DetailImage> DetailImages { get; set; }
}