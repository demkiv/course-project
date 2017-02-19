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
        var QueryString = ClientSide.Common.Utilities.QueryString;
        var Initializer = (function () {
            function Initializer(Color) {
                this.Color = Color;
            }
            Initializer.prototype.Initialize = function () {
                var _this = this;
                var url = QueryString.GetQueryString();
                var divs = jQuery("div");
                divs.each(function (index, element) {
                    jQuery(element).css("background-color", _this.Color);
                });
                console.log(url);
                alert("initialzied");
            };
            return Initializer;
        }());
        ClientSide.Initializer = Initializer;
    })(ClientSide = DeanerySystem.ClientSide || (DeanerySystem.ClientSide = {}));
})(DeanerySystem || (DeanerySystem = {}));
jQuery(document)
    .ready(function () {
    var initializer = new DeanerySystem.ClientSide.Initializer("gray");
    initializer.Initialize();
});
