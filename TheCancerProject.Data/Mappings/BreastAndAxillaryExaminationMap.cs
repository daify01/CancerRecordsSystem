using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCancerProject.Core;

namespace TheCancerProject.Data.Mappings
{
    public class BreastAndAxillaryExaminationMap : EntityMap<BreastAndAxillaryExamination>
    {
        public BreastAndAxillaryExaminationMap()
        {
            //Map(x => x.Id);
            //Map(x => x.AnteriorChestWallFullness);
            Map(x => x.Appearance);
            Map(x => x.AreolaColor);
            //Map(x => x.AxillaryFullness);
            Map(x => x.Cracks);
            Map(x => x.Deviated);
            Map(x => x.Discharge);
           //Map(x => x.EdemaInArms);
            Map(x => x.Elevated);
            Map(x => x.FindingsUnderArms).CustomSqlType("nvarchar(max)").Length(int.MaxValue);
            Map(x => x.FindingsUnderBreast).CustomSqlType("nvarchar(max)").Length(int.MaxValue);
            Map(x => x.Fissure);
            Map(x => x.NumberOfLesions);
            Map(x => x.Scale);
            Map(x => x.Size);
            //Map(x => x.SupraclavicularFullness);
            Map(x => x.Surface);
            Map(x => x.TheAnteriorChestWallNodules);
            Map(x => x.TheAxillaryLymphNodes);
            Map(x => x.TheBreastWithLesion);
            Map(x => x.TheLocationOfLesions);
            Map(x => x.TheSupraclavicularNodes);
            Map(x => x.TheTemperature);
            Map(x => x.TypeOfDischarge);
            Map(x => x.Ulcer);
        }
    }
}
