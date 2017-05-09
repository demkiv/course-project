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
        var Cabinet;
        (function (Cabinet) {
            var Initializer = (function () {
                function Initializer(Color) {
                    this.Color = Color;
                }
                Initializer.prototype.Initialize = function () {
                };
                return Initializer;
            }());
            Cabinet.Initializer = Initializer;
        })(Cabinet = ClientSide.Cabinet || (ClientSide.Cabinet = {}));
    })(ClientSide = DeanerySystem.ClientSide || (DeanerySystem.ClientSide = {}));
})(DeanerySystem || (DeanerySystem = {}));
jQuery(document)
    .ready(function () {
    var initializer = new DeanerySystem.ClientSide.Cabinet.Initializer("gray");
    initializer.Initialize();
});
