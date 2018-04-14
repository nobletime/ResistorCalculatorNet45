using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ResisterCalculator.Business
{
    public class OhmValueCalculator : IOhmValueCalculator
    {
        public string CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {

            int addNum = Int32.Parse(getValue(bandAColor).ToString() + getValue(bandBColor).ToString());
            var power = Math.Pow(10, getValue(bandCColor));

            string resistance = convert(addNum * power);
            string tolerance = getTolerance(bandDColor).ToString();

            Dictionary<string,string> resistorVal = new Dictionary<string, string>();
            resistorVal.Add("resistance", resistance);
            resistorVal.Add("tolerance" , tolerance);
            return JsonConvert.SerializeObject(resistorVal);
        }

        private int getValue(string value)
        {
            switch (value)
            {
                case "Black":
                    return 0;
                case "Brown":
                    return 1;
                case "Red":
                    return 2;
                case "Orange":
                    return 3;
                case "Yellow":
                    return 4;
                case "Green":
                    return 5;
                case "Blue":
                    return 6;
                case "Violet":
                    return 7;
                case "Grey":
                    return 8;
                case "White":
                    return 9;
                default:
                    return Int32.Parse(value);
            }
        }


        private int getTolerance(string tol)
        {
            switch (tol)
            {
                case "Gold":
                    return 5;
                case "Silver":
                    return 10;
                case "Transparent":
                    return 20;
                default:
                    return Int32.Parse(tol);
            }
        }


        private string convert(double value)
        {
            string conVal = value.ToString();
            if (value >= 1000 && value <= 999999)
            {
                value = value / 1000;
                conVal = value.ToString() + " K";
            }
            else if (value >= 1000000 && value <= 999999999)
            {
                value = value / 1000000;
                conVal = value.ToString() + " M";
            }
            else if (value >= 1000000000 && value <= 99999999999)
            {
                value = value / 1000000000;
                conVal = value.ToString() + " G";
            }

            return conVal;
        }

    }

}