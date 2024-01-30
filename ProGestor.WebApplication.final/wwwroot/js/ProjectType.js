
$(document).ready(function(){
    $(".btn_update_project_type").on("click", function(){
        var url = $(this).data("url");
        var id = $(this).data("id");
        
        $.ajax({
            url:url,
            data: {id:id},
            type: "GET",
            success: function(result){
                $("#project_type_modal_update .modal-content").html(result)

                $("#project_type_modal_update").modal("show");
            },
            error: function(){
                
            }
        });
        
    });

    $(".remove_project_type").on("click", function(){
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
                    data: {id : id},
                    type:"POST",
                    success : function(data){
                        if(data.id == 1){
                            Swal.fire({
                                title: "Eliminado!",
                                text: data.message,
                                icon: "success"
                            }).then(function(){
                                window.location.reload();
                            });
                        }
                        else if(data.id == 2){
                            Swal.fire({
                                title: "No eliminado!",
                                text:data.message,
                                icon: "error"
                            }).then(function(){
                                window.location.reload();
                            });
                        }
                    },
                    error: function(){}
                })
            }else{
                Swal.fire({
                    title: "Operación cancelada",
                    text:"El registro no ha sido eliminado",
                    icon: "error"
                })
            }
        });
    });
})







