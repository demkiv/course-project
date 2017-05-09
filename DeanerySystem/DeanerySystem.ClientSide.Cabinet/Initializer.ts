/// <reference path="../deanerysystem.clientside.common.utilities/querystring.ts" />
/// <reference path="../deanerysystem.clientside.common.definitions/scripts/typings/jquery/jquery.d.ts" />

module DeanerySystem.ClientSide.Cabinet {
    import QueryString = ClientSide.Common.Utilities.QueryString;
    export class Initializer {
        
        //private Color: string;

        constructor(private Color: string) {
        }

        public Initialize() {
            //var url = QueryString.GetQueryString();
            //var divs = jQuery("div");
            //divs.each((index, element) => {
            //    jQuery(element).css("background-color", this.Color);
            //});
            //console.log(url);
            //var contact = new Cabinet.ContactInfo();
            //var vm = new Cabinet.ContactInfoVM(contact);
            //var elemet = $("#contactform")[0];
            //ko.applyBindings(vm, elemet);
            //alert("initialzied");            
        }
    }
}

jQuery(document)
    .ready(() => {
        var initializer = new DeanerySystem.ClientSide.Cabinet.Initializer("gray");
        initializer.Initialize();
    });
