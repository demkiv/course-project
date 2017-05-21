module DeanerySystem.ClientSide.Administration {
    export class AdministrationVM {
        public AdminItems: AdminItemVM[];
        public UniversityInfo: UniversityInfoVM;

        constructor(adminModel: AdministrationModel) {
            this.AdminItems = [];
            this.AdminItems.push(new AdminItemVM("Факультети", adminModel.FacultiesCount, "faculties"));
            this.AdminItems.push(new AdminItemVM("Потоки", adminModel.StreamsCount, "streams"));
            this.AdminItems.push(new AdminItemVM("Кафедри", adminModel.DepartmentsCount, "departments"));
            this.AdminItems.push(new AdminItemVM("Групи", adminModel.GroupsCount, "groups"));
            this.AdminItems.push(new AdminItemVM("Викладачі", adminModel.ProfessorsCount, "professors"));
            this.AdminItems.push(new AdminItemVM("Студенти", adminModel.StreamsCount, "students"));

            this.UniversityInfo = new UniversityInfoVM(adminModel.University);
        }
    }
}