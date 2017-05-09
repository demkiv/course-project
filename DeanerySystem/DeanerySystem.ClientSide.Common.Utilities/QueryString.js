var DeanerySystem;
(function (DeanerySystem) {
    var ClientSide;
    (function (ClientSide) {
        var Common;
        (function (Common) {
            var Utilities;
            (function (Utilities) {
                class QueryString {
                    static GetQueryString() {
                        return window.location.href;
                    }
                }
                Utilities.QueryString = QueryString;
            })(Utilities = Common.Utilities || (Common.Utilities = {}));
        })(Common = ClientSide.Common || (ClientSide.Common = {}));
    })(ClientSide = DeanerySystem.ClientSide || (DeanerySystem.ClientSide = {}));
})(DeanerySystem || (DeanerySystem = {}));
