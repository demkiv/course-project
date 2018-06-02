import { AccountsPageContextVM } from "./AccountsPageContextVM";

export class Initializer {
    public static Initialize() {
        var element = $("#accountsPage");
        var viewModel = new AccountsPageContextVM();
        ko.applyBindings(viewModel, element);
    }
}

$(document).ready(() => {
    Initializer.Initialize();
})