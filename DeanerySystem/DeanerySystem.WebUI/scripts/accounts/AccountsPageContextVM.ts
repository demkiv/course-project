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
        }

        function cancelEditRow(oTable, nRow) {
            var jqInputs = $('input', nRow);
            var values = (<any>jqInputs).map((x, e) => { return e.value });
            values.push('<a class="edit" href="">Редагувати</a>');
            values.push('<a class="delete" href="">Видалити</a>');
            oTable.row(nRow).data(values).draw();
        }

        var table = (<any>window).$('#sample_editable_1');

        var oTable = (<any>table).DataTable({
            "lengthMenu": [
                [5, 15, 20, -1],
                [5, 15, 20, "Всі"]
            ],          
            "pageLength": 5,
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
            "columnDefs": [{ 
                'orderable': true,
                'targets': [0]
            }, {
                "searchable": true,
                "targets": [0]
                }],
            "language": {
                "decimal": "",
                "emptyTable": "Немає даних",
                "info": "Показано від _START_ до _END_ з _TOTAL_ записів",
                "infoEmpty": "Показано від 0 до 0 з 0 записів",
                "infoFiltered": "(знайдено з _MAX_ записів)",
                "lengthMenu": "_MENU_ записів",
                "infoPostFix": "",
                "thousands": ",",
                "loadingRecords": "Завантаження...",
                "processing": "Обробка...",
                "search": "Пошук:",
                "zeroRecords": "Не знайдено жодного співпадіння",
                "paginate": {
                    "first": "Перша",
                    "last": "Остання",
                    "next": "Наступна",
                    "previous": "Попередня"
                },
                "aria": {
                    "sortAscending": ": сортувати за зростанням",
                    "sortDescending": ": сортувати за спаданням"
                }
            },
            "order": [
                [1, "asc"]
            ] 
        });

        oTable.buttons().container().appendTo($('#actions'));
        var tableWrapper = $("#sample_editable_1_wrapper");

        var nEditing = null;
        var nNew = false;

        $('#sample_editable_1_new').click(function (e) {
            e.preventDefault();

            if (nNew && nEditing) {
                if (confirm("Попередній рядок не збережено. Ви маєте намір зберегти його ?")) {
                    saveRow(oTable, nEditing);
                    $(nEditing).find("td:first").html("Untitled");
                    nEditing = null;
                    nNew = false;

                } else {
                    oTable.row(nEditing).remove().draw(); 
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
            var nRow = $(this).parents('tr')[0];

            if (nEditing !== null && nEditing != nRow) {
                restoreRow(oTable, nEditing);
                editRow(oTable, nRow);
                nEditing = nRow;
            } else if (nEditing == nRow && this.innerHTML == "Зберегти") {
                saveRow(oTable, nEditing);
                nEditing = null;
            } else {
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
                deferr.resolve();
            },
            error: function (jqXhr, textStatus, errorThrown) {
                console.log(textStatus, errorThrown);
                alert("Сталася помилка!");
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
                deferr.resolve();
            },
            error: function (jqXhr, textStatus, errorThrown) {
                console.log(textStatus, errorThrown);
                alert("Сталася помилка!");
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
                deferr.resolve();
            },
            error: function (jqXhr, textStatus, errorThrown) {
                console.log(textStatus, errorThrown);
                alert("Сталася помилка!");
                deferr.reject();
            }
        });
        return deferr.promise();
    }
}