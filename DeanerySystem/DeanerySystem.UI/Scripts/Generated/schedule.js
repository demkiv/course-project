var DeanerySystem;
(function (DeanerySystem) {
    var ClientSide;
    (function (ClientSide) {
        var Common;
        (function (Common) {
            var Utilities;
            (function (Utilities) {
                var QueryString = (function () {
                    function QueryString() {
                    }
                    QueryString.GetQueryString = function () {
                        return window.location.href;
                    };
                    return QueryString;
                }());
                Utilities.QueryString = QueryString;
            })(Utilities = Common.Utilities || (Common.Utilities = {}));
        })(Common = ClientSide.Common || (ClientSide.Common = {}));
    })(ClientSide = DeanerySystem.ClientSide || (DeanerySystem.ClientSide = {}));
})(DeanerySystem || (DeanerySystem = {}));
var DeanerySystem;
(function (DeanerySystem) {
    var ClientSide;
    (function (ClientSide) {
        var Schedule;
        (function (Schedule) {
            var DataProvider = (function () {
                function DataProvider() {
                }
                DataProvider.GetSchelude = function () {
                    var deferrer = jQuery.Deferred();
                    $.get("../api/schedule/getSchedule", function (data) {
                        deferrer.resolve(data);
                    });
                    return deferrer.promise();
                };
                return DataProvider;
            }());
            Schedule.DataProvider = DataProvider;
        })(Schedule = ClientSide.Schedule || (ClientSide.Schedule = {}));
    })(ClientSide = DeanerySystem.ClientSide || (DeanerySystem.ClientSide = {}));
})(DeanerySystem || (DeanerySystem = {}));
var DeanerySystem;
(function (DeanerySystem) {
    var ClientSide;
    (function (ClientSide) {
        var Schedule;
        (function (Schedule) {
            var Initializer = (function () {
                function Initializer() {
                }
                Initializer.prototype.Initialize = function () {
                    Schedule.DataProvider.GetSchelude().done(function (schedule) {
                        var scheduleVM = new ClientSide.ViewModels.ScheduleVM(schedule);
                        ko.applyBindings(scheduleVM);
                    });
                };
                return Initializer;
            }());
            Schedule.Initializer = Initializer;
        })(Schedule = ClientSide.Schedule || (ClientSide.Schedule = {}));
    })(ClientSide = DeanerySystem.ClientSide || (DeanerySystem.ClientSide = {}));
})(DeanerySystem || (DeanerySystem = {}));
$(document).ready(function () {
    var initializer = new DeanerySystem.ClientSide.Schedule.Initializer();
    initializer.Initialize();
});
var DeanerySystem;
(function (DeanerySystem) {
    var ClientSide;
    (function (ClientSide) {
        var Schedule;
        (function (Schedule) {
            var Models;
            (function (Models) {
                var DayModel = (function () {
                    function DayModel() {
                    }
                    return DayModel;
                }());
                Models.DayModel = DayModel;
            })(Models = Schedule.Models || (Schedule.Models = {}));
        })(Schedule = ClientSide.Schedule || (ClientSide.Schedule = {}));
    })(ClientSide = DeanerySystem.ClientSide || (DeanerySystem.ClientSide = {}));
})(DeanerySystem || (DeanerySystem = {}));
var DeanerySystem;
(function (DeanerySystem) {
    var ClientSide;
    (function (ClientSide) {
        var Schedule;
        (function (Schedule) {
            var Models;
            (function (Models) {
                var Fractions;
                (function (Fractions) {
                    Fractions[Fractions["Numerator"] = 0] = "Numerator";
                    Fractions[Fractions["Denominator"] = 1] = "Denominator";
                    Fractions[Fractions["Integer"] = 2] = "Integer";
                })(Fractions = Models.Fractions || (Models.Fractions = {}));
            })(Models = Schedule.Models || (Schedule.Models = {}));
        })(Schedule = ClientSide.Schedule || (ClientSide.Schedule = {}));
    })(ClientSide = DeanerySystem.ClientSide || (DeanerySystem.ClientSide = {}));
})(DeanerySystem || (DeanerySystem = {}));
var DeanerySystem;
(function (DeanerySystem) {
    var ClientSide;
    (function (ClientSide) {
        var Schedule;
        (function (Schedule) {
            var Models;
            (function (Models) {
                var GroupModel = (function () {
                    function GroupModel() {
                    }
                    return GroupModel;
                }());
                Models.GroupModel = GroupModel;
            })(Models = Schedule.Models || (Schedule.Models = {}));
        })(Schedule = ClientSide.Schedule || (ClientSide.Schedule = {}));
    })(ClientSide = DeanerySystem.ClientSide || (DeanerySystem.ClientSide = {}));
})(DeanerySystem || (DeanerySystem = {}));
var DeanerySystem;
(function (DeanerySystem) {
    var ClientSide;
    (function (ClientSide) {
        var Schedule;
        (function (Schedule) {
            var Models;
            (function (Models) {
                var LessonGroupModel = (function () {
                    function LessonGroupModel() {
                    }
                    return LessonGroupModel;
                }());
                Models.LessonGroupModel = LessonGroupModel;
            })(Models = Schedule.Models || (Schedule.Models = {}));
        })(Schedule = ClientSide.Schedule || (ClientSide.Schedule = {}));
    })(ClientSide = DeanerySystem.ClientSide || (DeanerySystem.ClientSide = {}));
})(DeanerySystem || (DeanerySystem = {}));
var DeanerySystem;
(function (DeanerySystem) {
    var ClientSide;
    (function (ClientSide) {
        var Schedule;
        (function (Schedule) {
            var Models;
            (function (Models) {
                var LessonModel = (function () {
                    function LessonModel() {
                    }
                    return LessonModel;
                }());
                Models.LessonModel = LessonModel;
            })(Models = Schedule.Models || (Schedule.Models = {}));
        })(Schedule = ClientSide.Schedule || (ClientSide.Schedule = {}));
    })(ClientSide = DeanerySystem.ClientSide || (DeanerySystem.ClientSide = {}));
})(DeanerySystem || (DeanerySystem = {}));
var DeanerySystem;
(function (DeanerySystem) {
    var ClientSide;
    (function (ClientSide) {
        var Schedule;
        (function (Schedule) {
            var Models;
            (function (Models) {
                var LessonNumberModel = (function () {
                    function LessonNumberModel() {
                    }
                    return LessonNumberModel;
                }());
                Models.LessonNumberModel = LessonNumberModel;
            })(Models = Schedule.Models || (Schedule.Models = {}));
        })(Schedule = ClientSide.Schedule || (ClientSide.Schedule = {}));
    })(ClientSide = DeanerySystem.ClientSide || (DeanerySystem.ClientSide = {}));
})(DeanerySystem || (DeanerySystem = {}));
var DeanerySystem;
(function (DeanerySystem) {
    var ClientSide;
    (function (ClientSide) {
        var Schedule;
        (function (Schedule) {
            var Models;
            (function (Models) {
                var ScheduleModel = (function () {
                    function ScheduleModel() {
                    }
                    return ScheduleModel;
                }());
                Models.ScheduleModel = ScheduleModel;
            })(Models = Schedule.Models || (Schedule.Models = {}));
        })(Schedule = ClientSide.Schedule || (ClientSide.Schedule = {}));
    })(ClientSide = DeanerySystem.ClientSide || (DeanerySystem.ClientSide = {}));
})(DeanerySystem || (DeanerySystem = {}));
var DeanerySystem;
(function (DeanerySystem) {
    var ClientSide;
    (function (ClientSide) {
        var ViewModels;
        (function (ViewModels) {
            var DayVM = (function () {
                function DayVM(day, groups) {
                    this.day = day;
                    this.groups = groups;
                    this.TemplateName = "day-template";
                    this.Name = ko.observable(day.Name);
                    var lessonNumbers = day.LessonNumbers.map(function (ln) {
                        return new ViewModels.LessonNumberVM(ln, groups);
                    });
                    this.LessonNumbers = ko.observableArray(lessonNumbers);
                    this.RowSpanNumber = ko.observable(2 * lessonNumbers.length);
                }
                return DayVM;
            }());
            ViewModels.DayVM = DayVM;
        })(ViewModels = ClientSide.ViewModels || (ClientSide.ViewModels = {}));
    })(ClientSide = DeanerySystem.ClientSide || (DeanerySystem.ClientSide = {}));
})(DeanerySystem || (DeanerySystem = {}));
var DeanerySystem;
(function (DeanerySystem) {
    var ClientSide;
    (function (ClientSide) {
        var ViewModels;
        (function (ViewModels) {
            var LessonGroupVM = (function () {
                function LessonGroupVM(lessonGroup) {
                    this.lessonGroup = lessonGroup;
                    this.TemplateNameEmpty = "lesson-group-template-empty";
                    this.TemplateNameWithContent = "lesson-group-template";
                    if (this.lessonGroup == null) {
                        this.TemplateName = ko.observable(this.TemplateNameEmpty);
                        this.RowSpanNumber = ko.observable(2);
                    }
                    else {
                        this.TemplateName = ko.observable(this.TemplateNameWithContent);
                        var lessons = this.lessonGroup.Lessons;
                        var integerLesson = ko.utils.arrayFirst(lessons, function (lg) { return lg.Fraction == ClientSide.Schedule.Models.Fractions.Integer; });
                        if (integerLesson == null) {
                            var numeratorLesson = ko.utils.arrayFirst(lessons, function (lg) { return lg.Fraction == ClientSide.Schedule.Models.Fractions.Numerator; });
                            this.FirstRowLesson = ko.observable(new ViewModels.LessonVM(numeratorLesson));
                            var denominatorLesson = ko.utils.arrayFirst(lessons, function (lg) { return lg.Fraction == ClientSide.Schedule.Models.Fractions.Denominator; });
                            this.SecondRowLesson = ko.observable(new ViewModels.LessonVM(denominatorLesson));
                            this.RowSpanNumber = ko.observable(1);
                        }
                        else {
                            this.FirstRowLesson = ko.observable(new ViewModels.LessonVM(integerLesson));
                            this.SecondRowLesson = ko.observable(new ViewModels.LessonVM(null));
                            this.RowSpanNumber = ko.observable(2);
                        }
                    }
                }
                return LessonGroupVM;
            }());
            ViewModels.LessonGroupVM = LessonGroupVM;
        })(ViewModels = ClientSide.ViewModels || (ClientSide.ViewModels = {}));
    })(ClientSide = DeanerySystem.ClientSide || (DeanerySystem.ClientSide = {}));
})(DeanerySystem || (DeanerySystem = {}));
var DeanerySystem;
(function (DeanerySystem) {
    var ClientSide;
    (function (ClientSide) {
        var ViewModels;
        (function (ViewModels) {
            var LessonNumberVM = (function () {
                function LessonNumberVM(lessonNumber, groups) {
                    var _this = this;
                    this.lessonNumber = lessonNumber;
                    this.groups = groups;
                    this.TemplateName = "lesson-number-template";
                    this.Number = ko.observable(lessonNumber.Number);
                    this.Time = ko.computed(function () {
                        return lessonNumber.Start + " - " + lessonNumber.End;
                    });
                    var lessonGroups = new Array();
                    this.groups.forEach(function (group) {
                        var lessonGroup = ko.utils.arrayFirst(_this.lessonNumber.LessonGroups, function (lg) { return lg.GroupId == group; });
                        lessonGroups.push(new ViewModels.LessonGroupVM(lessonGroup));
                    });
                    this.LessonGroups = ko.observableArray(lessonGroups);
                }
                return LessonNumberVM;
            }());
            ViewModels.LessonNumberVM = LessonNumberVM;
        })(ViewModels = ClientSide.ViewModels || (ClientSide.ViewModels = {}));
    })(ClientSide = DeanerySystem.ClientSide || (DeanerySystem.ClientSide = {}));
})(DeanerySystem || (DeanerySystem = {}));
var DeanerySystem;
(function (DeanerySystem) {
    var ClientSide;
    (function (ClientSide) {
        var ViewModels;
        (function (ViewModels) {
            var LessonVM = (function () {
                function LessonVM(lessonGroup) {
                    this.lessonGroup = lessonGroup;
                    this.TemplateNameEmpty = "lesson-template-empty";
                    this.TemplateNameWithContent = "lesson-template";
                    if (lessonGroup == null) {
                        this.TemplateName = ko.observable(this.TemplateNameEmpty);
                    }
                    else {
                        this.TemplateName = ko.observable(this.TemplateNameWithContent);
                        this.Subject = ko.observable(lessonGroup.Subject);
                        this.Lector = ko.observable(lessonGroup.Lector);
                        this.Type = ko.observable(lessonGroup.Type);
                        this.JournalLink = ko.observable(lessonGroup.JournalLink);
                    }
                }
                return LessonVM;
            }());
            ViewModels.LessonVM = LessonVM;
        })(ViewModels = ClientSide.ViewModels || (ClientSide.ViewModels = {}));
    })(ClientSide = DeanerySystem.ClientSide || (DeanerySystem.ClientSide = {}));
})(DeanerySystem || (DeanerySystem = {}));
var DeanerySystem;
(function (DeanerySystem) {
    var ClientSide;
    (function (ClientSide) {
        var ViewModels;
        (function (ViewModels) {
            var ScheduleVM = (function () {
                function ScheduleVM(schedule) {
                    var _this = this;
                    this.schedule = schedule;
                    var groupNames = this.schedule.Groups.map(function (g) {
                        return g.Name;
                    });
                    this.Groups = ko.observableArray(groupNames);
                    var days = this.schedule.Days.map(function (day) {
                        var groupIds = _this.schedule.Groups.map(function (group) { return group.Id; });
                        return new ViewModels.DayVM(day, groupIds);
                    });
                    this.Days = ko.observableArray(days);
                }
                return ScheduleVM;
            }());
            ViewModels.ScheduleVM = ScheduleVM;
        })(ViewModels = ClientSide.ViewModels || (ClientSide.ViewModels = {}));
    })(ClientSide = DeanerySystem.ClientSide || (DeanerySystem.ClientSide = {}));
})(DeanerySystem || (DeanerySystem = {}));
