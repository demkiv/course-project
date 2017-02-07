/// <reference path="../deanerysystem.clientside.common.utilities/querystring.ts" />
/// <reference path="../deanerysystem.clientside.common.definitions/scripts/typings/jquery/jquery.d.ts" />
module DeanerySystem.ClientSide {
    import QueryString = ClientSide.Common.Utilities.QueryString;
    export class Initializer {
        
        //private Color: string;

        constructor(private Color: string) {
        }

        public Initialize() {
            var url = QueryString.GetQueryString();
            var divs = jQuery("div");
            divs.each((index, element) => {
                jQuery(element).css("background-color", this.Color);
            });
            console.log(url);
            alert("initialzied");            
        }
    }
}

jQuery(document)
    .ready(() => {
        var initializer = new DeanerySystem.ClientSide.Initializer("gray");
        initializer.Initialize();
    });
