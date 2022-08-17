var dataTable;

$(document).ready(function () {
    loadDataTable()
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "http://localhost:5114/Admin/Product/GetAll"
        },
        "columns": [{
                "data": "title",
                "width": "10%"
            },
            {
                "data": "isbn",
                "width": "10%"
            },
            {
                "data": "author",
                "width": "10%"
            },
            {
                "data": "price",
                "width": "10%"
            },
            {
                "data": "category.name",
                "width": "10%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return ` 
                    <div class="d-flex flex-row justify-content-around  btn-group-lg" role="group">
                        <a href="/Admin/Product/Upsert?id=${data}" class="btn btn-primary d-flex flex-row">
                        <i class="bi bi-pencil-square"></i> Edit
                        </a>
                        <a onClick=Delete('http://localhost:5114/Admin/Product/Delete/${data}') class="btn btn-danger d-flex flex-row">
                            <i class="bi bi-trash-fill"></i> Delete
                        </a>
                    </div>
                    `
                },
                "width": "10%"
            },


        ]
    });
}


function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: "DELETE", 
                success: function (data) {
                    if(data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    } else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}