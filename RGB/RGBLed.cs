using System.Device.Gpio;
using System;
using System.Device.Pwm;
using System.Device.Pwm.Drivers;

namespace RGB
{
    public class RGBLed
    {
        private PwmChannel _redPin;
        private PwmChannel _greenPin;
        private PwmChannel _bluePin;

        const int RPIN = 18;
        const int GPIN = 19;
        const int BPIN = 20;

        public RGBLed()
        {
            _redPin = new SoftwarePwmChannel(pinNumber: RPIN, frequency: 600, dutyCycle: 0.0);
            _greenPin = new SoftwarePwmChannel(pinNumber: GPIN, frequency: 600, dutyCycle: 0.0);
            _bluePin = new SoftwarePwmChannel(pinNumber: BPIN, frequency: 600, dutyCycle: 0.0);
            Console.WriteLine("LED CREATED");

            _redPin.Start();
            _greenPin.Start();
            _bluePin.Start();

        }

        
        public void UpdateColor(int rvalue, int gvalue, int bvalue)
        {
        
            _redPin.DutyCycle = rvalue / 255D;
            _greenPin.DutyCycle = gvalue / 255D;
            _bluePin.DutyCycle = bvalue / 255D;

            Console.WriteLine(_redPin.DutyCycle);
            Console.WriteLine(_greenPin.DutyCycle);
            Console.WriteLine(_bluePin.DutyCycle);

            
        }



        ~RGBLed()
        {
            _redPin.Stop();
            _greenPin.Stop();
            _bluePin.Stop();
        }



    }
}
