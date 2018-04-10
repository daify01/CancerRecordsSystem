using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCancerProject.Core;

namespace TheCancerProject.Data.Mappings
{
    public class GeneralExaminationMap : EntityMap<GeneralExamination>
    {
        public GeneralExaminationMap()
        {
            //Map(x => x.Id);
            Map(x => x.BMI);
            Map(x => x.BSA);
            Map(x => x.ColorOfSkinArea);
            //Map(x => x.DilatedVeins);
            //Map(x => x.FungatingMass);
            Map(x => x.Height);
            //Map(x => x.MedicalHistory);
            //Map(x => x.NippleDestruction);
            //Map(x => x.Nodules);
            //Map(x => x.PeauDOrange);
            //Map(x => x.Pluckering);
            //Map(x => x.PresenceOfNippleRetraction);
            Map(x => x.QuadrantLocated);
            Map(x => x.Shape);
            //Map(x => x.SkinTethering);
            Map(x => x.Temperature);
            //Map(x => x.Tenderness);
            Map(x => x.TheGeneralExam);
            Map(x => x.TheLocationOfLesion);
            Map(x => x.TheSymmetry);
            //Map(x => x.TheTexture);
            //Map(x => x.Ulceration);
            //Map(x => x.VisibleMass);
            Map(x => x.Weight);
            Map(x => x.OtherObservations);
            Map(x => x.BloodPressure);
            Map(x => x.PulseRate);
            Map(x => x.RespiratoryRate);
            Map(x => x.HeartSounds);
        }
    }
}
