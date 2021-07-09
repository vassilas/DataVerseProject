// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


var CreateCustomerModalShow = function () {
    $("#CreateModal").modal('show');
}

var ConfirmDelete = function (CustomerId, CustomerEmail) {
    $("#hiddenCustomerId").val(CustomerId);
    $("#hiddenCustomerEmail").val(CustomerEmail);
    $("#CustomerIdShow").html(CustomerEmail);
    $("#DeleteModal").modal('show');

}
var DeleteCustomer = function () {
    var empId = $("#hiddenCustomerId").val();
    $.ajax({
        type: "POST",
        url: "/Customers/Delete",
        data: { customer_id: empId },
        success: function (result) {
            $("#DeleteModal").modal("hide");
            $("#row_" + empId).remove();
        }
    })
}