const sql = require('mssql');
const Role = require('../models/role.model');

const buscar = async (Role_Id) => {
    const pool = await sql.connect();
    const result = await pool.request()
        .input('Role_Id', sql.Int, Role_Id)
        .execute('Acce.SP_Roles_Buscar');
    return result.recordset[0] ? new Role(result.recordset[0]) : null;
};

const editar = async (role) => {
    const pool = await sql.connect();
    const result = await pool.request()
        .input('Role_Id', sql.Int, role.Role_Id)
        .input('Role_Descripcion', sql.VarChar(100), role.Role_Descripcion)
        .input('Usua_Modificacion', sql.Int, role.Usua_Modificacion)
        .input('Role_FechaModificacion', sql.DateTime, role.Role_FechaModificacion)
        .execute('Acce.SP_Roles_Editar');
    return result.recordset[0];
};

const eliminar = async (Role_Id) => {
    const pool = await sql.connect();
    const result = await pool.request()
        .input('Role_Id', sql.Int, Role_Id)
        .execute('Acce.SP_Roles_Eliminar');
    return result.recordset[0];
};

const listar = async () => {
    const pool = await sql.connect();
    const result = await pool.request()
        .execute('Acce.SP_Roles_Listar');
    return result.recordset.map(row => new Role(row));
};

module.exports = {
    buscar,
    editar,
    eliminar,
    listar
};
