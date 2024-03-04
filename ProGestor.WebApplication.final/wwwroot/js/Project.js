$(document).ready(function(){    
    $(".update_status").on("click", function () {
        var url = $(this).data("url");
        var id = $(this).data("id");

        $.ajax({
            url: url,
            type: "GET",
            data: { "projectId": id},
            success: function (result) {
                $("#basicModal .modal-content").html(result)

                $("#basicModal").modal("show");
            },
            error: function (error) {
                console.log("Error al intentar cargar la vista parcial: " + error);
            }
        })
    })
    
    $(".updateDateTime").on("click", function () {
        var url = $(this).data("url");
        var id = $(this).data("id");

        $.ajax({
            url: url,
            type: "GET",
            data: { "projectId": id},
            success: function (result) {
                $("#basicModal .modal-content").html(result)

                $("#basicModal").modal("show");
            },
            error: function (error) {
                console.log("Error al intentar cargar la vista parcial: " + error);
            }
        })
    })
    
    $(".updateEstimation").on("click", function () {
        var url = $(this).data("url");
        var id = $(this).data("id");

        $.ajax({
            url: url,
            type: "GET",
            data: { "projectId": id},
            success: function (result) {
                $("#basicModal .modal-content").html(result)

                $("#basicModal").modal("show");
            },
            error: function (error) {
                console.log("Error al intentar cargar la vista parcial: " + error);
            }
        })
    })
    

    $(".remove_project").on("click", function() {
        Swal.fire({
            title: "¿Esta seguro?",
            text: "¡No podrás revertir esto!",
            icon: "Advertencia",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Si, eliminar"
        }).then((result) => {
            if (result.isConfirmed) {
                var url = $(this).data("url");
                var id = $(this).data("id");

                $.ajax({
                    url: url,
                    data: {"ProjectId": id},
                    type: "POST",
                    success: function (data) {
                        if (data.id == 1) {
                            Swal.fire({
                                title: "Eliminado!",
                                text: "El registro ha sido eliminado!",
                                icon: "success"
                            }).then(function () {
                                window.location.reload();
                            });
                        } else if (data.id == 2) {
                            Swal.fire({
                                title: "No eliminado!",
                                text: "El registro no pudo ser eliminado!",
                                icon: "error"
                            }).then(function () {
                                window.location.reload();
                            });
                        }
                    },
                    error: function () {

                    }


                })
            } else {
                Swal.fire({
                    title: "Operación cancelada",
                    text: "El registro no ha sido eliminado",
                    icon: "error"
                })
            }
        });
    })
    
    
})