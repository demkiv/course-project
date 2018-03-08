module DeanerySystem.ClientSide.Common.Utilities {
    export class QueryString {
        public static GetQueryString(): string {           
            return window.location.href;
        }
    }
}