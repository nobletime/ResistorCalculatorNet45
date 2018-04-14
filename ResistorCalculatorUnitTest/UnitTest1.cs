using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResisterCalculator.Business;
using ResistorCalculatorTest.Models;
using Newtonsoft.Json.Linq;

namespace ResistorCalculatorUnitTest
{
    [TestClass]
    public class ResistorCalControllerTest
    {
        [TestMethod]
        public void ohmValueCalculatorTest()
        {
            OhmValueCalculator _ohmValueCalculator = new OhmValueCalculator();

            ResistorColorBands reistorColors = new ResistorColorBands()
            {
                bandAColor = "Red",
                bandBColor = "Brown",
                bandCColor = "Red",
                bandDColor = "Gold"
            };


        string result = _ohmValueCalculator.CalculateOhmValue(
                                reistorColors.bandAColor,
                                reistorColors.bandBColor,
                                reistorColors.bandCColor,
                                reistorColors.bandDColor);

            Assert.IsNotNull(result);

            JToken token = JToken.Parse(result);
            JObject resistor = JObject.Parse(token.ToString());

            Assert.AreEqual(resistor["resistance"].ToString(), "2.1 K");
            Assert.AreEqual(resistor["tolerance"].ToString(), "5");


            reistorColors.bandAColor = "Green";
            reistorColors.bandBColor = "Yellow";
            reistorColors.bandCColor = "Blue";
            reistorColors.bandDColor = "Silver";

            string result2 = _ohmValueCalculator.CalculateOhmValue(
                               reistorColors.bandAColor,
                               reistorColors.bandBColor,
                               reistorColors.bandCColor,
                               reistorColors.bandDColor);

            Assert.IsNotNull(result2);

            token = JToken.Parse(result2);
            resistor = JObject.Parse(token.ToString());

            Assert.AreEqual(resistor["resistance"].ToString(), "54 M");
            Assert.AreEqual(resistor["tolerance"].ToString(), "10");


            // testing wront value now

            string result3 = _ohmValueCalculator.CalculateOhmValue(
                   "White",
                   "Yellow",
                   "Black",
                   "Gold");

            Assert.IsNotNull(result3);

            token = JToken.Parse(result3);
            resistor = JObject.Parse(token.ToString());

            Assert.AreNotEqual(resistor["resistance"].ToString(), "54 M");
            Assert.AreNotEqual(resistor["tolerance"].ToString(), "10");
        }
    }
}
