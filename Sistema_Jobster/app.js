const express = require('express');
const app = express();
const port = 3000;

// Importar las rutas de roles
const roleRoutes = require('./routes/role.routes');

// Otras configuraciones y middlewares de la aplicación

// Registrar las rutas de roles
app.use('/api/roles', roleRoutes);

// Otras rutas y configuraciones de la aplicación

app.listen(port, () => {
  console.log(`Servidor escuchando en http://localhost:${port}`);
});