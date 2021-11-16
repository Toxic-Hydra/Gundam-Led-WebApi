using System;
using System.Collections.Generic;
using RGB.Models;
using RGB.Services;
using Microsoft.AspNetCore.Mvc;
using RGB;

namespace RGB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LedController : ControllerBase
    {
        private static RGBLed light = new RGBLed();
        //LedController gets created an destroyed for every web api call, we make sure RGBLed is only created once
        //if it isn't we get some funny led flickers.
        public LedController() {
            
        }

        // GET all action
        [HttpGet]
        public ActionResult<List<Led>> GetAll()
        {
            var led = LedService.Get(1);
            light.UpdateColor(led.red, led.green, led.blue);
            return LedService.GetAll();
        }
            

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Led> Get(int id)
        {
            var led = LedService.Get(id);
            if (led == null)
                return NotFound();

            light.UpdateColor(led.red, led.green, led.blue);
            return led;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(Led led)
        {
            //TODO: SET OUR LED TO THE NEWLY CREATED ONE
            
            Console.WriteLine("New Led Created");
            LedService.AddLed(led);
            light.UpdateColor(led.red, led.green, led.blue);
            return CreatedAtAction(nameof(Create), new { id = led.Id }, led);
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Led led)
        {
            if (id != led.Id)
                return BadRequest();

            var existingLed = LedService.Get(id);
            if (existingLed == null)
                return NotFound();

            LedService.Update(led);

            return NoContent();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var led = LedService.Get(id);

            if (led == null)
                return NotFound();

            LedService.Delete(id);

            return NoContent();
        }
    }
}
