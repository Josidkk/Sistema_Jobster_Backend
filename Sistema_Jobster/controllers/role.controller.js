const roleRepository = require('../repositories/role.repository');

const buscar = async (req, res) => {
    try {
        const { Role_Id } = req.body;
        const role = await roleRepository.buscar(Role_Id);
        if (role) res.json(role);
        else res.status(404).json({ message: 'Rol no encontrado' });
    } catch (err) {
        res.status(500).json({ message: 'Error interno', error: err.message });
    }
};

const editar = async (req, res) => {
    try {
        const role = req.body;
        const result = await roleRepository.editar(role);
        res.json(result);
    } catch (err) {
        res.status(500).json({ message: 'Error interno', error: err.message });
    }
};

const eliminar = async (req, res) => {
    try {
        const { Role_Id } = req.body;
        const result = await roleRepository.eliminar(Role_Id);
        res.json(result);
    } catch (err) {
        res.status(500).json({ message: 'Error interno', error: err.message });
    }
};

const listar = async (req, res) => {
    try {
        const roles = await roleRepository.listar();
        res.json(roles);
    } catch (err) {
        res.status(500).json({ message: 'Error interno', error: err.message });
    }
};

module.exports = {
    buscar,
    editar,
    eliminar,
    listar
};
