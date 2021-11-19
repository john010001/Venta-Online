var app = app || {}; app.paginas = app.paginas || {}; app.paginas.admin = app.paginas.admin || {};

app.paginas.admin.productos = app.paginas.admin.productos || (
    function () {

        function init() {
            $(".btn-buscar").on("click", buscar);
            $(".btn-nuevo").on("click", nuevo);
        }

        function buscar() {

            //function de jquery para realizar una llamada ajax mediante
            //el método http post
            $.post("/producto/IndexResultadoAjax",
                {
                    IdCategoria: $("#IdCategoria").val(),
                    NombreProducto: $("#NombreProducto").val(),
                },
                function (response) {
                    $("#listado").html(response);
                }
            );

        }

        function nuevo() {
            app.lib.common.ShowModal("Nuevo producto", "/producto/agregar", null, "ModelNuevoProductoID");

        }

        return {
            init: init,
            buscar: buscar
        };

    }    
    )();