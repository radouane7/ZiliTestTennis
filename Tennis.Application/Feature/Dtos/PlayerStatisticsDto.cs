using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis.Application.Feature.Dto
{
    public class PlayerStatisticsDto
    {
        public string CountryWithHighestWinRatio { get; set; }
        public double AverageBMI { get; set; } // IMC
        public double MedianHeight { get; set; }
    }
}
