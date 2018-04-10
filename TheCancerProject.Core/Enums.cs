using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCancerProject.Core
{
    public enum Title
    {
        Mr = 1,
        Mrs,
        Miss,
        Master,
        Dr,
        Prof,
        Chief,
    }

    public enum Sex
    {
        Male = 1,
        Female,
    }
    public enum State
    {
        AbujaFCT = 1,
        Abia,
        Adamawa,
        AkwaIbom,
        Anambra,
        Bauchi,
        Bayelsa,
        Benue,
        Borno,
        CrossRiver,
        Delta,
        Ebonyi,
        Edo,
        Ekiti,
        Enugu,
        Gombe,
        Imo,
        Jigawa,
        Kaduna,
        Kano,
        Katsina,
        Kebbi,
        Kogi,
        Kwara,
        Lagos,
        Nasarawa,
        Niger,
        Ogun,
        Ondo,
        Osun,
        Oyo,
        Plateau,
        Rivers,
        Sokoto,
        Taraba,
        Yobe,
        Zamfara,
    }
    public enum Religion
    {
        Christianity = 1,
        Islam,
        Others,
    }
    public enum MaritalStatus
    {
        Single = 1,
        Engaged,
        Married,
        Divroced,
        Widow,
        Widower,
        Separated,
    }
    public enum Relationship
    {
        Brother = 1,
        Sister,
        Father,
        Mother,
        Uncle,
        Aunt,
        Cousin,
        Nephew,
        Niece,
        Son,
        Daughter
    }

    public enum PresentedComplaints
    {
        BreastLump = 1,
        NipplePain,
        NippleInversion,
        BreastThickening,
        NippleDischarge,
        NippleDeformity,
        AuxilliarySkinThickening,
        AuxilliarySwelling,
        BrestPain,
    }

    public enum Cause
    {
        EarlyMenarch = 1,
        LateMenopause,
        Ketamania,
        Parity,
        AgeAtFirstPregnancy,
        LactationDuration,
        OralContraceptiveUse,
        HormoneReplacementTherapy,
        PreviousBreastCancerOrLump,
        FamilyHistoryOfBreastCancer,
        PreviousOvariaCancer,
        EndometrialCancer,
        ColorectalCancer,
        CigaretteSmoking,
        Diet,
        Alcohol,
        IrradiationExposure,
        TraumaToBreast,
    }

    public enum Complications
    {
        Headache = 1,
        Seizures,
        LossOfConsciousness,
        Cough,
        ChestPain,
        Dyspnoea,
        Vomitting,
        BonePain,
        BackPain,
        PathologicalFractures,
    }

    public enum Care
    {
        PrePresentationInLuth = 1,
        Unorthodox,
        Orthodox,
    }

    public enum PastMedicalHistory
    {
        Hypertensive = 1,
        Diabetic,
        Epileptic,
        PreviousBloodTransfusion,
        Asthmatic,
        PepticUlcerDx,
    }

    public enum GeneralExam
    {
        Ferbile = 1,
        Aferbile,
        Icteric,
        Anicteric,
        Cyanosed,
        Acyanosed,
    }

    public enum Texture
    {
        Rough = 1,
    }

    public enum LocationOfLesion
    {
        LeftBreast = 1,
        LeftAxilla,
        RightBreast,
        RightAxilla,
    }

    public enum Symmetry
    {
        Symmetrical = 1,
        Asymmetrical,
    }

    public enum Appearance
    {
        Symmetrical = 1,
        Asymmetrical,
    }

    public enum QuadrantLocated
    {
        RightUpperInner = 1,
        RightUpperOuter,
        RightLowerInner,
        RightLowerOuter,
        RightAxillary,
        LeftUpperInner,
        LeftUpperOuter,
        LeftLowerInner,
        LeftLowerOuter,
        LeftAxillary,
    }

    public enum AxillaryLymphNodes
    {
        LeftAxilla = 1,
        RightAxilla,
    }

    public enum SupraclavicularNodes
    {
        Left = 1,
        Right,
    }

    public enum AnteriorChestWallNodules
    {
        Left = 1,
        Right,
    }
    public enum BreastWithLesion
    {
        Left = 1,
        Right,
        Bilateral,
    }
    public enum LocationOfLesions
    {
        UpperInner = 1,
        UpperOuter,
        LowerInner,
        LowerOuter,
        Nipple,
        Axillary,
    }
    public enum Temperature
    {
        Aferbile = 1,
        Ferbile,
    }

    public enum TypeOfDischarge
    {
        Black = 1,
        Milky,
        Bloody,
        Greenish,
        Purulent,
        Other
    }

    public enum DischargeState
    {
        Dead = 1,
        Alive
    }

    public enum UserRole
    {
        SuperAdmin = 1,
        HospitalAdmin,
        HospitalUser
    }
}
