using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDotNetProject
{
    public class Car
    {
        private string registration;
        private string serialNumber;
        private string make;
        private string model;
        private string version;
        private DateOnly dateRegistered;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        public string Registration
        {
            get { return registration; }
            set { registration = value; }
        }
        public string SerialNumber
        {
            get { return serialNumber; }
            set { serialNumber = value; }
        }
        public string Make
        {
            get { return make; }
            set { make = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        
        public DateOnly DateRegistered
        {
            get { return dateRegistered; }
            set { dateRegistered = value; }
        }
    }
}
