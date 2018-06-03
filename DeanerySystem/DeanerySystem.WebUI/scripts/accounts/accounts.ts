import * as $ from 'jquery';
import * as ko from 'knockout';
import { AccountsPageContextVM } from "./AccountsPageContextVM";

export class Initializer {
    public static Initialize() {
        var element = $("#accountsPage");
        var viewModel = new AccountsPageContextVM();
        ko.applyBindings(viewModel, element[0]);
        viewModel.DrawTable();
    }
}

$(document).ready(() => {
    Initializer.Initialize();
})