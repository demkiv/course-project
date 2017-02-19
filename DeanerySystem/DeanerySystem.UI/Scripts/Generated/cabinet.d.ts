/// <reference path="../../../deanerysystem.clientside.common.definitions/scripts/typings/jquery/jquery.d.ts" />
declare module DeanerySystem.ClientSide.Common.Utilities {
    class QueryString {
        static GetQueryString(): string;
    }
}
declare module DeanerySystem.ClientSide.Schedule {
    class DataProvider {
        static GetSchelude(): JQueryPromise<Models.ScheduleModel>;
    }
}
declare module DeanerySystem.ClientSide.Schedule {
    class Initializer {
        Initialize(): void;
    }
}
declare module DeanerySystem.ClientSide.Schedule.Models {
    class DayModel {
        Day: string;
        DayRowSpan: number;
        LessonNumberModels: LessonNumberModel[];
        constructor();
    }
}
declare module DeanerySystem.ClientSide.Schedule.Models {
    enum Fractions {
        Numerator = 0,
        Denominator = 1,
        Integer = 2,
    }
}
declare module DeanerySystem.ClientSide.Schedule.Models {
    class GroupModel {
        Id: number;
        Name: string;
        constructor();
    }
}
declare module DeanerySystem.ClientSide.Schedule.Models {
    class LessonGroupModel {
        FirstRowLesson: LessonModel;
        SecondRowLesson: LessonModel;
        IsSolid: boolean;
        constructor();
    }
}
declare module DeanerySystem.ClientSide.Schedule.Models {
    class LessonModel {
        Fraction: Fractions;
        Subject: string;
        Lector: string;
        Type: string;
        JornalLink: string;
        constructor();
    }
}
declare module DeanerySystem.ClientSide.Schedule.Models {
    class LessonNumberModel {
        Number: number;
        Start: Date;
        End: Date;
        LessonGroupModels: LessonGroupModel[];
        constructor();
    }
}
declare module DeanerySystem.ClientSide.Schedule.Models {
    class ScheduleModel {
        GroupModels: GroupModel[];
        DayModels: DayModel[];
        constructor();
    }
}
