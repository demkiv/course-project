namespace DeanerySystem.WebUI.Models.Admin
{
    public class UniversityModel
    {
        public string Name { get; set; }

        public UserModel RectorModel { get; set; }
        public UniversityStatisticsModel UniversityStatisticsModel { get; set; }
    }
}
