using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDotNetProject
{
    internal class Certificate
    {
        private int id;
        private string date; 
        private string registration; 
        private string serialNumber;
        private string workshop;
        private string worker; 
        private string customer; 
        private string contact;
        private string registrationcertificate;
        private string registrationcertificateOriginal;
        private string lastRegistration;
        private string eTypeApproveNr;
        private string documentedByBrochure;
        private string documentedByLab; 
        private string documentedByCocDoc;
        private int mileage;
        private string gearBoxVerified;
        private string serviceHistoryVerified;
        private string keyControlled;
        private string originalPaintThickness; 
        private string originalPaintThicknessMeasured;
        private string paintConclusion;
        private string engineNumberVerified;
        private string originalPaint;
        private string serialCorrect;
        private string serialCondition;
        private string serialDamaged;
        private string picturesAppended;
        private string identityVerified;
        private string make;
        private string model;
        private string version;
        private DateOnly dateRegistered;
        private int keys;
        private string gearBoxNumber; 

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
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
        public string Workshop
        {
            get { return workshop; }
            set { workshop = value; }
        }
        public string Worker
        {
            get { return worker; }
            set { worker = value; }
        }
        public string Customer
        {
            get { return customer; }
            set { customer = value; }
        }
        public string Contact
        {
            get { return contact; }
            set { contact = value; }
        }
        public string Registrationcertificate
        {
            get { return registrationcertificate; }
            set { registrationcertificate = value; }
        }
        public string RegistrationcertificateOriginal
        {
            get { return registrationcertificateOriginal; }
            set { registrationcertificateOriginal = value; }
        }
        public string LastRegistration
        {
            get { return lastRegistration; }
            set { lastRegistration = value; }
        }
        public string ETypeApproveNr
        {
            get { return eTypeApproveNr; }
            set { eTypeApproveNr = value; }
        }
        public string GearBoxVerified
        {
            get { return gearBoxVerified; }
            set { gearBoxVerified = value; }
        }
        public string ServiceHistoryVerified
        {
            get { return serviceHistoryVerified; }
            set { serviceHistoryVerified = value; }
        }
        public string KeyControlled
        {
            get { return keyControlled; }
            set { keyControlled = value; }
        }
        public string DocumentedByBrochure
        {
            get { return documentedByBrochure; }
            set { documentedByBrochure = value;}
        }
        public string DocumentedByLab
        {
            get { return documentedByLab; }
            set { documentedByLab = value; }
        }
        public string DocumentedByCocDoc
        {
            get { return documentedByCocDoc; }
            set { documentedByCocDoc = value; }
        }
        public int Mileage
        {
            get { return mileage; }
            set { mileage = value; }
        }
        public string OriginalPaintThickness
        {
            get { return originalPaintThickness; }
            set { originalPaintThickness = value; }
        }
        public string OriginalPaintThicknessMeasured
        {
            get { return originalPaintThicknessMeasured; }
            set { originalPaintThicknessMeasured = value; }
        }
        public string PaintConclusion
        {
            get { return paintConclusion; }
            set { paintConclusion = value; }
        }
        public string EngineNumberVerified
        {
            get { return engineNumberVerified; }
            set { engineNumberVerified = value; }
        }
        public string OriginalPaint
        {
            get { return originalPaint; }
            set { originalPaint = value; }
        }
        public string SerialCorrect
        {
            get { return serialCorrect; }
            set { serialCorrect = value; }
        }
        public string SerialCondition
        {
            get { return serialCondition; }
            set { serialCondition = value; }
        }
        public string SerialDamaged
        {
            get { return serialDamaged; }
            set { serialDamaged = value; }
        }
        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        public string PicturesAppended
        {
            get { return picturesAppended; }
            set { picturesAppended = value;}
        }
        public string IdentityVerified
        {
            get { return identityVerified; }
            set { identityVerified = value; }
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
        
        public string Version
        {
            get { return version; }
            set { version = value; }
        }
        public int Keys
        {
            get { return keys; }
            set { keys = value; }
        }
        public string GearBoxNumber
        {
            get { return gearBoxNumber; }
            set { gearBoxNumber = value; }
        }
    }
}
