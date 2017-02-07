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
