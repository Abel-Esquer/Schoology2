function eliminar(id) {
    if (confirm("Estas seguro que desea eliminar el registro?")) {
        var url = "/CursoUsuario/Eliminar/" + id;
        window.location.href = url;
    }
}