const express = require('express');
const router = express.Router();
const roleController = require('../controllers/role.controller');

router.post('/buscar', roleController.buscar);
router.put('/editar', roleController.editar);
router.delete('/eliminar', roleController.eliminar);
router.get('/listar', roleController.listar);

module.exports = router;