var DeanerySystem;
(function (DeanerySystem) {
    var ClientSide;
    (function (ClientSide) {
        var Administration;
        (function (Administration) {
            var Initializer = (function () {
                function Initializer() {
                }
                Initializer.prototype.Initialize = function () {
                };
                Initializer.prototype.InitializeFacultiesOverview = function () {
                    var data = window["dsFaculties"];
                    var facultiesOverviewVM = new Administration.FacultiesOverviewVM(data);
                    var element = jQuery("#faculties-overview-area");
                    ko.applyBindings(facultiesOverviewVM, element.get(0));
                };
                return Initializer;
            }());
            Administration.Initializer = Initializer;
        })(Administration = ClientSide.Administration || (ClientSide.Administration = {}));
    })(ClientSide = DeanerySystem.ClientSide || (DeanerySystem.ClientSide = {}));
})(DeanerySystem || (DeanerySystem = {}));
var DeanerySystem;
(function (DeanerySystem) {
    var ClientSide;
    (function (ClientSide) {
        var Administration;
        (function (Administration) {
            var AdministrationModel = (function () {
                function AdministrationModel() {
                }
                return AdministrationModel;
            }());
            Administration.AdministrationModel = AdministrationModel;
        })(Administration = ClientSide.Administration || (ClientSide.Administration = {}));
    })(ClientSide = DeanerySystem.ClientSide || (DeanerySystem.ClientSide = {}));
})(DeanerySystem || (DeanerySystem = {}));
var DeanerySystem;
(function (DeanerySystem) {
    var ClientSide;
    (function (ClientSide) {
        var Administration;
        (function (Administration) {
            var FacultyOverviewModel = (function () {
                function FacultyOverviewModel() {
                }
                return FacultyOverviewModel;
            }());
            Administration.FacultyOverviewModel = FacultyOverviewModel;
        })(Administration = ClientSide.Administration || (ClientSide.Administration = {}));
    })(ClientSide = DeanerySystem.ClientSide || (DeanerySystem.ClientSide = {}));
})(DeanerySystem || (DeanerySystem = {}));
var DeanerySystem;
(function (DeanerySystem) {
    var ClientSide;
    (function (ClientSide) {
        var Administration;
        (function (Administration) {
            var UniversityModel = (function () {
                function UniversityModel() {
                }
                return UniversityModel;
            }());
            Administration.UniversityModel = UniversityModel;
        })(Administration = ClientSide.Administration || (ClientSide.Administration = {}));
    })(ClientSide = DeanerySystem.ClientSide || (DeanerySystem.ClientSide = {}));
})(DeanerySystem || (DeanerySystem = {}));
var DeanerySystem;
(function (DeanerySystem) {
    var ClientSide;
    (function (ClientSide) {
        var Administration;
        (function (Administration) {
            var AdministrationVM = (function () {
                function AdministrationVM(adminModel) {
                    this.AdminItems = [];
                    this.AdminItems.push(new Administration.AdminItemVM("Факультети", adminModel.FacultiesCount, "faculties"));
                    this.AdminItems.push(new Administration.AdminItemVM("Потоки", adminModel.StreamsCount, "streams"));
                    this.AdminItems.push(new Administration.AdminItemVM("Кафедри", adminModel.DepartmentsCount, "departments"));
                    this.AdminItems.push(new Administration.AdminItemVM("Групи", adminModel.GroupsCount, "groups"));
                    this.AdminItems.push(new Administration.AdminItemVM("Викладачі", adminModel.ProfessorsCount, "professors"));
                    this.AdminItems.push(new Administration.AdminItemVM("Студенти", adminModel.StreamsCount, "students"));
                    this.UniversityInfo = new Administration.UniversityInfoVM(adminModel.University);
                }
                return AdministrationVM;
            }());
            Administration.AdministrationVM = AdministrationVM;
        })(Administration = ClientSide.Administration || (ClientSide.Administration = {}));
    })(ClientSide = DeanerySystem.ClientSide || (DeanerySystem.ClientSide = {}));
})(DeanerySystem || (DeanerySystem = {}));
var DeanerySystem;
(function (DeanerySystem) {
    var ClientSide;
    (function (ClientSide) {
        var Administration;
        (function (Administration) {
            var AdminItemVM = (function () {
                function AdminItemVM(Title, Count, Url) {
                    this.Title = Title;
                    this.Count = Count;
                    this.Url = Url;
                }
                return AdminItemVM;
            }());
            Administration.AdminItemVM = AdminItemVM;
        })(Administration = ClientSide.Administration || (ClientSide.Administration = {}));
    })(ClientSide = DeanerySystem.ClientSide || (DeanerySystem.ClientSide = {}));
})(DeanerySystem || (DeanerySystem = {}));
var DeanerySystem;
(function (DeanerySystem) {
    var ClientSide;
    (function (ClientSide) {
        var Administration;
        (function (Administration) {
            var FacultiesOverviewVM = (function () {
                function FacultiesOverviewVM(faculties) {
                    var _this = this;
                    var facultiesVMs = faculties.map(function (f) { return new Administration.FacultyOverviewVM(f); });
                    this.Faculties = ko.observableArray(facultiesVMs);
                    var templateName = faculties && faculties.length > 0 ? "faculties-overview" : "faculties-overview-empty";
                    this.TemplateName = ko.observable(templateName);
                    this.Faculties.subscribe(function () {
                        var templateName = _this.Faculties && _this.Faculties.length > 0
                            ? "faculties-overview"
                            : "faculties-overview-empty";
                        _this.TemplateName = ko.observable(templateName);
                    });
                }
                return FacultiesOverviewVM;
            }());
            Administration.FacultiesOverviewVM = FacultiesOverviewVM;
        })(Administration = ClientSide.Administration || (ClientSide.Administration = {}));
    })(ClientSide = DeanerySystem.ClientSide || (DeanerySystem.ClientSide = {}));
})(DeanerySystem || (DeanerySystem = {}));
var DeanerySystem;
(function (DeanerySystem) {
    var ClientSide;
    (function (ClientSide) {
        var Administration;
        (function (Administration) {
            var FacultyOverviewVM = (function () {
                function FacultyOverviewVM(model) {
                    this.Id = ko.observable(model.Id);
                    this.Name = ko.observable(model.Name);
                    this.PictureUrl = ko.observable(model.PictureUrl);
                }
                return FacultyOverviewVM;
            }());
            Administration.FacultyOverviewVM = FacultyOverviewVM;
        })(Administration = ClientSide.Administration || (ClientSide.Administration = {}));
    })(ClientSide = DeanerySystem.ClientSide || (DeanerySystem.ClientSide = {}));
})(DeanerySystem || (DeanerySystem = {}));
var DeanerySystem;
(function (DeanerySystem) {
    var ClientSide;
    (function (ClientSide) {
        var Administration;
        (function (Administration) {
            var UniversityInfoVM = (function () {
                function UniversityInfoVM(universityModel) {
                    this.Title = ko.observable(universityModel.Name);
                    this.RectorId = ko.observable(universityModel.RectorId);
                    this.RectorDisplayName = universityModel.RectorFirstName + " " + universityModel.RectorLastName;
                }
                return UniversityInfoVM;
            }());
            Administration.UniversityInfoVM = UniversityInfoVM;
        })(Administration = ClientSide.Administration || (ClientSide.Administration = {}));
    })(ClientSide = DeanerySystem.ClientSide || (DeanerySystem.ClientSide = {}));
})(DeanerySystem || (DeanerySystem = {}));
