using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RGB.Models;

namespace RGB.Services
{
    public static class LedService
    {
        static List<Led> Leds { get; set; }
        static int nextId = 3;
        static LedService()
        {
            Leds = new List<Led>
            {
                new Led {Id = 1, red = 255, green = 0, blue = 0},
                new Led {Id = 2, red = 0, green = 255, blue = 0}
            };
        }

        public static List<Led> GetAll() => Leds;

        public static Led? Get(int id) => Leds.FirstOrDefault(l => l.Id == id);

        public static void AddLed(Led led)
        {
            led.Id = nextId++;
            Leds.Add(led);

        }

        public static void Delete(int id)
        {
            var led = Get(id);
            if (led is null)
                return;

            Leds.Remove(led);
        }

        public static void Update(Led led)
        {
            var index = Leds.FindIndex(l => l.Id == led.Id);
            if (index == -1)
                return;

            Leds[index] = led;
        }
    }
}
