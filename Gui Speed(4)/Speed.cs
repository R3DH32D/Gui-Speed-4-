using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui_Speed_4_
{
    public enum MeasureType { ms , kmh, M, kn };
    public class Speed
    {
        private double value;
        private MeasureType type; 

        public Speed(double value, MeasureType type)
        {
            this.value = value;
            this.type = type;
        }
        public string Verbose()
        {
            string typeVerbose = "";
            switch (this.type)
            {
                case MeasureType.ms:
                    typeVerbose = "м/с";
                    break;
                case MeasureType.kmh:
                    typeVerbose = "км/ч";
                    break;
                case MeasureType.M:
                    typeVerbose = "Мах.";
                    break;
                case MeasureType.kn:
                    typeVerbose = "Уз.";
                    break;
            }
            return String.Format("{0} {1}", this.value, typeVerbose);
        }
        public static Speed operator +(Speed instance, double number)
        {
            return new Speed(instance.value + number, instance.type); ;
        }
        
        public static Speed operator +(Speed instance1, Speed instance2)
        {
            
            if (instance1.value >= instance2.value) 
            {
                return new Speed(instance1.value + instance2.To(instance1.type).value, instance1.type); ;
            }
            else
            {
                return new Speed(instance1.To(instance1.type).value + instance2.value, instance2.type); ;
            }
            
        }
        public static Speed operator *(Speed instance, double number)
        {
            
            return new Speed(instance.value * number, instance.type); ;
        }
        public static Speed operator *(Speed instance1, Speed instance2)
        {
            if (instance1.value >= instance2.value)
            {
                return new Speed(instance1.value * instance2.To(instance1.type).value, instance1.type); ;
            }
            else
            {
                return new Speed(instance1.To(instance1.type).value * instance2.value, instance2.type); ;
            }
        }
        public static Speed operator -(Speed instance, double number)
        {
            return new Speed(instance.value - number, instance.type); ;
        }
        public static Speed operator -(Speed instance1, Speed instance2)
        {
            if (instance1.value >= instance2.value)
            {
                return new Speed(instance1.value - instance2.To(instance1.type).value, instance1.type); ;
            }
            else
            {
                return new Speed(instance1.To(instance1.type).value - instance2.value, instance2.type); ;
            }
        }
        public Speed To(MeasureType newType)
        {
            var newValue = this.value;
            if (this.type == MeasureType.ms)
            {
                
                switch (newType)
                { 
                    case MeasureType.ms:
                        newValue = this.value;
                        break;
                    
                    case MeasureType.kmh:
                        newValue = this.value * 3.6;
                        break;
                    
                    case MeasureType.M:
                        newValue = this.value / 340;
                        break;
                    
                    case MeasureType.kn:
                        newValue = this.value * 1.94384;
                        break;
                }
            }
            else if (newType == MeasureType.ms) 
            {
                switch (this.type) 
                {
                    case MeasureType.ms:
                        newValue = this.value;
                        break;
                    case MeasureType.kmh:
                        newValue = this.value / 3.6; 
                        break;
                    case MeasureType.M:
                        newValue = this.value * 340;
                        break;
                    case MeasureType.kn:
                        newValue = this.value / 1.94384; 
                        break;
                }
            }
            else 
            {
                newValue = this.To(MeasureType.ms).To(newType).value;
            }
            return new Speed(newValue, newType);
        }
        public static Speed operator >(Speed instance1, Speed instance2)
        {
            Speed outPut;
            if (instance1.value > instance2.To(instance1.type).value)
            {
                outPut = instance1;
            }
            else if (instance1.value < instance2.To(instance1.type).value)
            { 
                outPut = instance2; 
            }
            else { outPut = instance1; }
                return outPut;
        }
        public static Speed operator <(Speed instance1, Speed instance2)
        {
            Speed outPut;
            if (instance1.value > instance2.To(instance1.type).value)
            {
                outPut = instance2;
            }
            else if (instance1.value < instance2.To(instance1.type).value)
            {
                outPut = instance1;
            }
            else { outPut = instance2; }
            return outPut;
        }
    }
}
