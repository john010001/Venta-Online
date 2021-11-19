var app = app || {}; app.paginas = app.paginas || {}; app.paginas.admin = app.paginas.admin || {};

app.paginas.admin.categoria = app.paginas.admin.categoria || (
    function () {

        function init() {
            $(".btn-nuevo").on("click", nuevo);
        }

        function nuevo() {

            app.lib.common.ShowModal("Nueva categoría", "/categoria/agregarPartial", null, "ModelAgregarCategoriaID");

        }

        function editar(id) {
            app.lib.common.ShowModal("Editar categoría", "/categoria/ModificarPartial/" + id, null, "ModelEditarCategoriaID");
        }

        return {
            init: init,
            editar: editar
        };

    }
)();