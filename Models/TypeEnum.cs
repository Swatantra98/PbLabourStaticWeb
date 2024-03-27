using System.ComponentModel;

namespace PbLabourStatic.Models
{
    public enum OfficerType
    {
        [Description("ADF/DDF")]
        DF = 1,
        
        [Description("ALC/LCO")]
        LC = 2,

        [Description("LEO")]
        LEO = 3,
    }
    public enum OfficerDesignation
    {
        [Description("Deputy Director of Factories")]
        DeputyDirectorOfFactories = 1,

        [Description("Assistant Director of Factories")]
        AssistantDirectorOfFactories = 2,

        [Description("Assistant Labour Commissioner")]
        AssistantLabourCommissioner = 3,

        [Description("Labour-cum-conciliation Officer")]
        LabourCumConciliationOfficer = 4,

        [Description("Labour Inspector Grade-I")]
        LabourInspectorGradeOne = 5,

        [Description("Labour Inspector Grade-II")]
        LabourInspectorGradeTwo = 6
    }
}
