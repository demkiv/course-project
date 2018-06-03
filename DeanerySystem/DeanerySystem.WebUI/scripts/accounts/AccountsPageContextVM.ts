import * as $ from 'jquery';
import * as ko from 'knockout';
import { StudentAccountDTO } from "./StudentAccountDTO";
import { access } from 'fs';

export class AccountsPageContextVM {
    private Accounts: KnockoutObservableArray<StudentAccountDTO>;
    constructor() {
        var students = window["data"];
        this.Accounts = ko.observableArray(students);
    }

    public DrawTable(): void {
        var _this = this;
        function restoreRow(oTable, nRow) {
            var aData = oTable.row(nRow).data();
            var jqTds = $('>td', nRow);
            var values = [];
            for (var i = 0, iLen = jqTds.length; i < iLen; i++) {
                values.push(aData[i])
                //oTable.fnUpdate(aData[i], nRow, i, false);
            }

            oTable.row(nRow).data(values).draw();
        }

        function editRow(oTable, nRow) {
            var aData = oTable.row(nRow).data();
            var jqTds = $('>td', nRow);
            //jqTds[0].innerHTML = '<input type="text" class="form-control input-small" value="' + aData[0] + '">';
            jqTds[1].innerHTML = '<input type="text" class="form-control input-small" value="' + aData[1] + '">';
            jqTds[2].innerHTML = '<input type="text" class="form-control input-small" value="' + aData[2] + '">';
            jqTds[3].innerHTML = '<input type="text" class="form-control input-small" value="' + aData[3] + '">';
            jqTds[4].innerHTML = '<input type="text" class="form-control input-small" value="' + aData[4] + '">';
            jqTds[5].innerHTML = '<input type="text" class="form-control input-small" value="' + aData[5] + '">';
            jqTds[6].innerHTML = '<input type="text" class="form-control input-small" value="' + aData[6] + '">';
            jqTds[7].innerHTML = '<input type="text" class="form-control input-small" value="' + aData[7] + '">';
            jqTds[8].innerHTML = '<input type="text" class="form-control input-small" value="' + aData[8] + '">';
            jqTds[9].innerHTML = '<input type="text" class="form-control input-small" value="' + aData[9] + '">';
            jqTds[10].innerHTML = '<input type="text" class="form-control input-small" value="' + aData[10] + '">';
            jqTds[11].innerHTML = '<a class="edit" href="">Зберегти</a>';
            jqTds[12].innerHTML = '<a class="cancel" href="">Скасувати</a>';
        }

        function saveRow(oTable, nRow) {
            debugger;
            var jqInputs = $('input', nRow);
            var tds = $('td', nRow);
            var id = tds[0] && $(tds[0]).data("id");
            var values = [tds[0].innerText];
            var values = values.concat((<any>jqInputs).map((x, e) => { return e.value }).toArray());
            values.push('<a class="edit" href="">Редагувати</a>');
            values.push('<a class="delete" href="">Видалити</a>');
            var account = _this.GetStudentAccountDTO(values);

            if (id) {
                account.Id = id;
                _this.UpdateStudent(account).done(() => {
                    oTable.row(nRow).data(values).draw();
                });
            } else {
                _this.SaveStudent(account).done(() => {
                    oTable.row(nRow).data(values).draw();
                });
            }
            //oTable.row(nRow).data((<any>jqInputs)[0].value, 0, false);
            //oTable.row(nRow).data((<any>jqInputs)[1].value, 1, false);
            //oTable.row(nRow).data((<any>jqInputs)[2].value, 2, false);
            //oTable.row(nRow).data((<any>jqInputs)[3].value, 3, false);
            //oTable.row(nRow).data((<any>jqInputs)[4].value, 4, false);
            //oTable.row(nRow).data((<any>jqInputs)[6].value, 5, false);
            //oTable.row(nRow).data((<any>jqInputs)[6].value, 6, false);
            //oTable.row(nRow).data((<any>jqInputs)[7].value, 7, false);
            //oTable.row(nRow).data((<any>jqInputs)[9].value, 8, false);
            //oTable.row(nRow).data((<any>jqInputs)[9].value, 9, false);
            //oTable.row(nRow).data((<any>jqInputs)[10].value, 10, false);
            //oTable.row(nRow).data('<a class="edit" href="">Редагувати</a>', nRow, 11, false);
            //oTable.row(nRow).data('<a class="delete" href="">Видалити</a>', nRow, 12, false);
        }

        function cancelEditRow(oTable, nRow) {
            var jqInputs = $('input', nRow);
            var values = (<any>jqInputs).map((x, e) => { return e.value });
            values.push('<a class="edit" href="">Редагувати</a>');
            values.push('<a class="delete" href="">Видалити</a>');
            //oTable.fnUpdate((<any>jqInputs)[0].value, nRow, 0, false);
            //oTable.fnUpdate((<any>jqInputs)[1].value, nRow, 1, false);
            //oTable.fnUpdate((<any>jqInputs)[2].value, nRow, 2, false);
            //oTable.fnUpdate((<any>jqInputs)[3].value, nRow, 3, false);
            //oTable.fnUpdate((<any>jqInputs)[4].value, nRow, 4, false);
            //oTable.fnUpdate((<any>jqInputs)[5].value, nRow, 5, false);
            //oTable.fnUpdate((<any>jqInputs)[6].value, nRow, 6, false);
            //oTable.fnUpdate((<any>jqInputs)[7].value, nRow, 7, false);
            //oTable.fnUpdate((<any>jqInputs)[8].value, nRow, 8, false);
            //oTable.fnUpdate((<any>jqInputs)[9].value, nRow, 9, false);
            //oTable.fnUpdate((<any>jqInputs)[10].value, nRow, 10, false);
            //oTable.fnUpdate('<a class="edit" href="">Редагувати</a>', nRow, 11, false);
            oTable.row(nRow).data(values).draw();
        }

        var table = (<any>window).$('#sample_editable_1');

        var oTable = (<any>table).DataTable({

            // Uncomment below line("dom" parameter) to fix the dropdown overflow issue in the datatable cells. The default datatable layout
            // setup uses scrollable div(table-scrollable) with overflow:auto to enable vertical scroll(see: assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.js). 
            // So when dropdowns used the scrollable div should be removed. 
            //"dom": "<'row'<'col-md-6 col-sm-12'l><'col-md-6 col-sm-12'f>r>t<'row'<'col-md-5 col-sm-12'i><'col-md-7 col-sm-12'p>>",

            "lengthMenu": [
                [5, 15, 20, -1],
                [5, 15, 20, "Всі"] // change per page values here
            ],

            // Or you can use remote translation file
            //"language": {
            //   url: '//cdn.datatables.net/plug-ins/3cfcc339e89/i18n/Portuguese.json'
            //},

            // set the initial value
            "pageLength": 5,

            "language": {
                "lengthMenu": " _MENU_ records"
            },
            buttons: [
                {
                    extend: 'print', className: 'btn dark btn-outline', text: 'Друкувати', autoPrint: true,
                    exportOptions: {
                        columns: ':visible',
                    }
                },
                {
                    extend: 'copy', className: 'btn red btn-outline', text: 'Копіювати', exportOptions: {
                        columns: ':visible',
                    }
                },
                {
                    extend: 'pdf', className: 'btn green btn-outline', text: 'PDF', exportOptions: {
                        columns: ':visible',
                    }
                },
                {
                    extend: 'excel', className: 'btn yellow btn-outline ', text: 'Excel', exportOptions: {
                        columns: ':visible',
                    }
                },
                {
                    extend: 'csv', className: 'btn purple btn-outline ', text: 'CSV', exportOptions: {
                        columns: ':visible',
                    }
                },
                {
                    extend: 'colvis', className: 'btn dark btn-outline', text: 'Стовбчики', exportOptions: {
                        columns: ':visible',
                    }
                }
            ],
            "columnDefs": [{ // set default column settings
                'orderable': true,
                'targets': [0]
            }, {
                "searchable": true,
                "targets": [0]
            }],
            "order": [
                [1, "asc"]
            ] // set first column as a default sort by asc
        });

        oTable.buttons().container().appendTo($('#actions'));
        var tableWrapper = $("#sample_editable_1_wrapper");

        var nEditing = null;
        var nNew = false;

        $('#sample_editable_1_new').click(function (e) {
            e.preventDefault();

            if (nNew && nEditing) {
                if (confirm("Попередній рядок не збережено. Ви маєте намір зберегти його ?")) {
                    saveRow(oTable, nEditing); // save
                    $(nEditing).find("td:first").html("Untitled");
                    nEditing = null;
                    nNew = false;

                } else {
                    oTable.row(nEditing).remove().draw(); // cancel
                    nEditing = null;
                    nNew = false;

                    return;
                }
            }

            var aiNew = oTable.row.add(['', '', '', '', '', '', '', '', '', '', '', '', '']).draw();
            var nRow = aiNew.node();
            editRow(oTable, nRow);
            nEditing = nRow;
            nNew = true;
        });

        table.on('click', '.delete', function (e) {
            e.preventDefault();
            var nRow = $(this).parents('tr')[0];
            if (confirm("Ви впевнені, що хочете видалити цей рядок ?") != false) {
                var vals = $('td', nRow);
                var id = $(vals[0]).data("id");
                _this.RemoveStudent(id).done(() => {
                    oTable.row(nRow).remove().draw();
                    alert("Deleted! Do not forget to do some ajax to sync with backend :)");
                })
            }
        });

        table.on('click', '.cancel', function (e) {
            e.preventDefault();
            if (nNew) {
                oTable.row(nEditing).remove().draw();
                nEditing = null;
                nNew = false;
            } else {
                restoreRow(oTable, nEditing);
                nEditing = null;
            }
        });

        table.on('click', '.edit', function (e) {
            e.preventDefault();
            nNew = false;

            /* Get the row as a parent of the link that was clicked on */
            var nRow = $(this).parents('tr')[0];

            if (nEditing !== null && nEditing != nRow) {
                /* Currently editing - but not this row - restore the old before continuing to edit mode */
                restoreRow(oTable, nEditing);
                editRow(oTable, nRow);
                nEditing = nRow;
            } else if (nEditing == nRow && this.innerHTML == "Зберегти") {
                /* Editing this row and want to save it */
                saveRow(oTable, nEditing);
                nEditing = null;
                alert("Updated! Do not forget to do some ajax to sync with backend :)");
            } else {
                /* No edit in progress - let's start one */
                editRow(oTable, nRow);
                nEditing = nRow;
            }
        });
    }

    private GetStudentAccountDTO(values: string[]): StudentAccountDTO {
        var account = new StudentAccountDTO();
        account.Id = "";
        account.StudentCardId = values[0];
        account.LastName = values[1];
        account.FirstName = values[2];
        account.MiddleName = values[3];
        account.FirstNameEng = values[4];
        account.LastNameEng = values[5];
        account.Email = values[6];
        account.PhoneNumber = values[7];
        account.BirthDate = new Date(values[8]);
        account.Stream = values[9];
        account.Group = values[10];
        return account;
    }

    private SaveStudent(student: StudentAccountDTO): JQueryPromise<{}> {
        var deferr = jQuery.Deferred();
        $.ajax({
            url: '/api/admin/student',
            type: 'POST',
            data: JSON.stringify(student),
            contentType: "application/json; charset=utf-8",
            success: (data: any) => {
                alert("Зміни збережено!");
                deferr.resolve();
            },
            error: function (jqXhr, textStatus, errorThrown) {
                console.log(textStatus, errorThrown);
                deferr.reject();
            }
        });
        return deferr.promise();
    }

    private UpdateStudent(student: StudentAccountDTO): JQueryPromise<{}> {
        var deferr = jQuery.Deferred();
        $.ajax({
            url: '/api/admin/student',
            type: 'PUT',
            data: JSON.stringify(student),
            contentType: "application/json; charset=utf-8",
            success: (data: any) => {
                alert("Зміни збережено!");
                deferr.resolve();
            },
            error: function (jqXhr, textStatus, errorThrown) {
                console.log(textStatus, errorThrown);
                deferr.reject();
            }
        });
        return deferr.promise();
    }

    private RemoveStudent(id: string): JQueryPromise<{}> {
        var deferr = jQuery.Deferred();
        $.ajax({
            url: `/api/admin/student/${id}`,
            type: 'DELETE',
            contentType: "application/json; charset=utf-8",
            success: (data: any) => {
                alert("Зміни збережено!");
                deferr.resolve();
            },
            error: function (jqXhr, textStatus, errorThrown) {
                console.log(textStatus, errorThrown);
                deferr.reject();
            }
        });
        return deferr.promise();
    }
}