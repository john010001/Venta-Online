var app = app || {}; app.lib = app.lib || {};

app.lib.common = app.lib.common || (function () {
    function stateModal(info) {
        var stateModaInfo;

        function getStateModal() {
            return stateModaInfo;
        }

        if (info !== undefined)
            stateModaInfo = info;

        return getStateModal();
    }

    function createGuid() {
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = Math.random() * 16 | 0, v = c === 'x' ? r : (r & 0x3 | 0x8);
            return v.toString(16);
        });
    }

    function setObjectLocalStorage(jsObject, keyStorage) {
        var json = JSON.stringify(jsObject);
        localStorage.setItem(keyStorage, json);

    }

    function getObjectLocalStorage(keyStorage) {
        var json = localStorage.getItem(keyStorage);
        return JSON.parse(json);
    }

    function showModal(title, url, closeFunction, modalId) {
        //Invocando a la vista utilizando AJAX
        var containerId = modalId || createGuid();
        var modalHtml = "<div class=\"modal\" tabindex=\"-1\" role=\"dialog\" id=\"" + containerId + "\">";
        modalHtml += "    <div class=\"modal-dialog\" role=\"document\">";
        modalHtml += "        <div class=\"modal-content\">";
        modalHtml += "            <div class=\"modal-header\">";
        modalHtml += "                <h5 class=\"modal-title\">" + title + "</h5>";
        modalHtml += "                    <button type =\"button\" class=\"close\" data-dismiss=\"modal\" aria-label=\"Close\">";
        modalHtml += "                        <span aria-hidden=\"true\">&times;</span>";
        modalHtml += "                </button>";
        modalHtml += "            </div>";
        modalHtml += "    <div class=\"modal-body\">";
        modalHtml += "            </div>";
        modalHtml += "        </div>";
        modalHtml += "    </div>";
        modalHtml += " </div>";

        $('body').append(modalHtml);

        $.get(url,
            function (html) {
                $('#' + containerId + " .modal-body").html(html);
                $("#" + containerId).modal({
                    backdrop: 'static',
                    keyboard: false
                });
                if (closeFunction !== undefined) {
                    $("#" + containerId).on('hidden.bs.modal', closeFunction);
                }
            }
        );

        return containerId;
    }

    function closeModal(state, modalWindow) {
        if (state !== undefined) {
            stateModal(state);
        }

        var currentModal = null;
        if (typeof modalWindow === "object") {
            currentModal = $(modalWindow).parents(".modal.show");
        }
        else {
            currentModal = "#" + modalWindow;
        }

        $(currentModal).modal("hide");
        $(currentModal).remove();

    }

    function ToastrConfig() {
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": false,
            "progressBar": true,
            "positionClass": "toast-top-right",
            "preventDuplicates": true,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "2500",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        };
    }

    function showMessageSuccess(message) {
        ToastrConfig();

        toastr["success"](message);
    }

    function showMessageError(message) {
        ToastrConfig();

        toastr["error"](message);
    }


    return {
        ShowModal: showModal,
        CloseModal: closeModal,
        GetStateModal: stateModal,
        ShowMessageSuccess: showMessageSuccess,
        ShowMessageError: showMessageError
    };

})();