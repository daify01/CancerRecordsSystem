using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCancerProject.Core
{
    public class GeneralExamination : Entity
    {
        //public virtual long Id
        //{
        //    get; set;
        //}
        public virtual Patient ThePatient
        {
            get; set;
        }
        public virtual string TheGeneralExam
        {
            get; set;
        }
        public virtual string Weight
        {
            get; set;
        }
        public virtual string Height
        {
            get; set;
        }
        public virtual string BMI
        {
            get; set;
        }
        public virtual string BSA
        {
            get; set;
        }
        public virtual string Temperature
        {
            get; set;
        }
        //public virtual bool DilatedVeins
        //{
        //    get; set;
        //}
        //public virtual bool Pluckering
        //{
        //    get; set;
        //}
        //public virtual bool PeauDOrange
        //{
        //    get; set;
        //}
        //public virtual bool SkinTethering
        //{
        //    get; set;
        //}
        //public virtual string TheTexture
        //{
        //    get; set;
        //}
        //public virtual bool Tenderness
        //{
        //    get; set;
        //}
        //public virtual bool Nodules
        //{
        //    get; set;
        //}
        //public virtual bool Ulceration
        //{
        //    get; set;
        //}
        //public virtual bool FungatingMass
        //{
        //    get; set;
        //}
        //public virtual bool MedicalHistory
        //{
        //    get; set;
        //}
        //public virtual bool PresenceOfNippleRetraction
        //{
        //    get; set;
        //}
        //public virtual bool NippleDestruction
        //{
        //    get; set;
        //}
        public virtual string TheLocationOfLesion
        {
            get; set;
        }
        public virtual Symmetry TheSymmetry
        {
            get; set;
        }
        public virtual string Shape
        {
            get; set;
        }
        //public virtual bool VisibleMass
        //{
        //    get; set;
        //}
        public virtual string QuadrantLocated
        {
            get; set;
        }
        public virtual string ColorOfSkinArea
        {
            get; set;
        }
        public virtual string OtherObservations
        {
            get; set;
        }
        public virtual string BloodPressure
        {
            get; set;
        }
        public virtual string RespiratoryRate
        {
            get; set;
        }
        public virtual string PulseRate
        {
            get; set;
        }
        public virtual string HeartSounds
        {
            get; set;
        }
    }
}
