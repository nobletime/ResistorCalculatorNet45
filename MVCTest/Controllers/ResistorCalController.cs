using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ResisterCalculator.Business;
using System.Web.Http.Description;
using ResistorCalculatorTest.Models;


namespace ResistorCalculator.Controllers
{
      [RoutePrefix("ResistorController")]
    public class ResistorCalController : ApiController
    {
        private readonly OhmValueCalculator _ohmValueCalculator = new OhmValueCalculator();

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(string))]
        public IHttpActionResult calculateResistor(ResistorColorBands reistorValues)
        {
            // Json passed to controller gets parsed, JSON passed will have the following structure
            // {bandAColor: aValue, bandBColor: aValue, bandCColor: aValue, bandDColor: aValue}
            return Ok(_ohmValueCalculator.CalculateOhmValue(
                                reistorValues.bandAColor,
                                reistorValues.bandBColor,
                                reistorValues.bandCColor,
                                reistorValues.bandDColor));
        }

    }
}
