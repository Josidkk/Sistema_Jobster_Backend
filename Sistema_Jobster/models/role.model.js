class Role {
    constructor({
        Role_Id,
        Role_Descripcion,
        Role_Estado,
        Role_FechaCreacion,
        Role_FechaModificacion,
        Usua_Creacion,
        Usua_Modificacion,
        UsuaC_Nombre,
        UsuaM_Nombre
    }) {
        this.Role_Id = Role_Id;
        this.Role_Descripcion = Role_Descripcion;
        this.Role_Estado = Role_Estado;
        this.Role_FechaCreacion = Role_FechaCreacion;
        this.Role_FechaModificacion = Role_FechaModificacion;
        this.Usua_Creacion = Usua_Creacion;
        this.Usua_Modificacion = Usua_Modificacion;
        this.UsuaC_Nombre = UsuaC_Nombre;
        this.UsuaM_Nombre = UsuaM_Nombre;
    }
}

module.exports = Role;
