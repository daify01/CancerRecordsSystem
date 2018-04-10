using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using TheCancerProject.Core;

namespace TheCancerProject
{
    public class WebObjects
    {
        static public void EnumToListBox(Type EnumType, ListControl TheListBox)
        {
            Array Values = System.Enum.GetValues(EnumType);

            foreach (int Value in Values)
            {
                string Name = Enum.GetName(EnumType, Value);
                string Display = SpaceWords(Name);
                //ListItem Item = new ListItem(Display, Value.ToString());
                ListItem Item = new ListItem(Display, Name);
                TheListBox.Items.Add(Item);
            }
        }
        public static List<object> GetEnumNames(string enumStringType)
        {
            List<object> result = new List<object>();
            Type enumType = Type.GetType(enumStringType);
            foreach (object enumValue in Enum.GetValues(enumType))
            {
                string enumName = Enum.GetName(enumType, enumValue);
                var data = new
                {
                    Name = SpaceWords(enumName),
                    Value = enumValue
                };
                result.Add(data);
            }
            return result;
        }

        private static string SpaceWords(string words)
        {
            StringBuilder result = new StringBuilder();
            foreach (char letter in words.ToCharArray())
            {
                if (char.IsUpper(letter))
                {
                    result.Append(' ');
                }
                result.Append(letter);
            }
            return result.Replace('_', ' ').ToString();
        }

        public static string selectedListBoxValues(ListControl TheListBox)
        {
            string selectedValues = string.Empty;
            for (int i = 0; i < TheListBox.Items.Count - 1; i++)
            {
                if (TheListBox.Items[i].Selected)
                    selectedValues += TheListBox.Items[i].Value + ";" ;
            }
            return selectedValues;
        }

        public static void displayStoredSelectedListBoxValues(string valuesfromDB, ListControl TheListBox)
        {
            string[] theDBValues = valuesfromDB.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            List<ListItem> itemsToDisplayAsSelected = new List<ListItem>();
            foreach (var item in theDBValues)
            {
                ListItem thisItem = null;
                thisItem = TheListBox.Items.FindByValue(item);
                if (thisItem != null)
                {
                    itemsToDisplayAsSelected.Add(thisItem);
                }
                itemsToDisplayAsSelected.ForEach(x => x.Selected = true);
            }
        }

        //public static void populatePatientObjectValues(Patient thePatient, object currentObjectToUpdate)
        //{
        //    foreach (var entity in thePatient.GetType().GetMembers())
        //    {
        //        if(entity.)
        //    }
        //}
    }

    public static class SessionObjects
    {
        public static Core.Patient ThePatient
        {
            get
            {
                return HttpContext.Current.Session["::ThePatient::"] as Core.Patient;
            }
            set
            {
                HttpContext.Current.Session["::ThePatient::"] = value;
            }
        }
        public static Core.Biodata TheBiodata
        {
            get
            {
                return HttpContext.Current.Session["TheBiodata"] as Core.Biodata;
            }
            set
            {
                HttpContext.Current.Session["TheBiodata"] = value;
            }
        }
        public static Core.Hospital TheHospital
        {
            get
            {
                return HttpContext.Current.Session["::Hospital::"] as Core.Hospital;
            }
            set
            {
                HttpContext.Current.Session["::Hospital::"] = value;
            }
        }
        public static string HospitalNumber
        {
            get
            {
                return HttpContext.Current.Session["HospitalNumber"] as string;
            }
            set
            {
                HttpContext.Current.Session["HospitalNumber"] = value;
            }
        }
    }
}