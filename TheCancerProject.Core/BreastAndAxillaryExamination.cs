using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCancerProject.Core
{
    public class BreastAndAxillaryExamination : Entity
    {
        //public virtual long Id
        //{
        //    get; set;
        //}
        //public virtual Patient ThePatient
        //{
        //    get; set;
        //}
        //public virtual bool EdemaInArms
        //{
        //    get; set;
        //}
        //public virtual bool SupraclavicularFullness
        //{
        //    get; set;
        //}
        //public virtual bool AxillaryFullness
        //{
        //    get; set;
        //}
        //public virtual bool AnteriorChestWallFullness
        //{
        //    get; set;
        //}
        public virtual string TheAxillaryLymphNodes
        {
            get; set;
        }
        public virtual string TheSupraclavicularNodes
        {
            get; set;
        }
        public virtual string TheAnteriorChestWallNodules
        {
            get; set;
        }
        public virtual string FindingsUnderBreast
        {
            get; set;
        }
        public virtual string FindingsUnderArms
        {
            get; set;
        }
        public virtual BreastWithLesion TheBreastWithLesion
        {
            get; set;
        }
        public virtual string TheLocationOfLesions
        {
            get; set;
        }
        public virtual Temperature TheTemperature
        {
            get; set;
        }
        public virtual Appearance Appearance
        {
            get; set;
        }
        public virtual bool Elevated
        {
            get; set;
        }
        public virtual string NumberOfLesions
        {
            get; set;
        }
        public virtual bool Deviated
        {
            get; set;
        }
        public virtual string Size
        {
            get; set;
        }
        public virtual bool Cracks
        {
            get; set;
        }
        public virtual bool Fissure
        {
            get; set;
        }
        public virtual bool Ulcer
        {
            get; set;
        }
        public virtual bool Scale
        {
            get; set;
        }
        public virtual bool Discharge
        {
            get; set;
        }
        public virtual TypeOfDischarge TypeOfDischarge
        {
            get; set;
        }
        public virtual string AreolaColor
        {
            get; set;
        }
        public virtual string Surface
        {
            get; set;
        }
    }
}
