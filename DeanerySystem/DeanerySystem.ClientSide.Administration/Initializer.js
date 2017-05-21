/// <reference path="../deanerysystem.clientside.common.definitions/scripts/typings/jquery/jquery.d.ts" />
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
                return Initializer;
            }());
            Administration.Initializer = Initializer;
        })(Administration = ClientSide.Administration || (ClientSide.Administration = {}));
    })(ClientSide = DeanerySystem.ClientSide || (DeanerySystem.ClientSide = {}));
})(DeanerySystem || (DeanerySystem = {}));
jQuery(document).ready(function () {
    var initializer = new DeanerySystem.ClientSide.Administration.Initializer();
    initializer.Initialize();
});
//# sourceMappingURL=Initializer.js.map