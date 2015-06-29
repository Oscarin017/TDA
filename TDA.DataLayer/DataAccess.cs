using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDA.Entities;

namespace TDA.DataLayer
{
    public class DataAccess
    {
        TDAEntities1 _context = new TDAEntities1();

        #region Tabla Configuracion
        public List<Configuraciones> SelectConfiguracion()
        {
            var conf = (from a in _context.Configuracion
                         select new Configuraciones
                         {
                             ID = a.ID,
                             Nombre = a.Nombre,
                             Valor = a.Valor,
                             Activo = a.Activo
                         }).ToList();
            return conf;
        }
        #endregion

        #region Tabla Rol
        public List<Roles> SelectRol() {
            var roles = (from a in _context.Rol
                         select new Roles { 
                         ID = a.ID,
                         Nombre =a.Nombre,
                         }).ToList();
            return roles;
        }
        #endregion

        #region Tabla Pagina
        public List<Paginas> SelectPagina()
        {
            var paginas = (from a in _context.Pagina
                         select new Paginas
                         {
                             ID = a.ID,
                             Nombre = a.Nombre,
                         }).ToList();
            return paginas;
        }
        #endregion

        #region Tabla RolPagina
        public List<RolPaginas> SelectRolPagina()
        {
            var paginas = (from a in _context.RolPagina
                           select new RolPaginas
                           {
                               ID = a.ID,
                               Rol = a.Rol,
                               Pagina = a.Pagina
                           }).ToList();
            return paginas;
        }
        #endregion

        #region Tabla Base Salario
        public List<BaseSalarios> SelectBaseSalario()
        {
            var paginas = (from a in _context.BaseSalario
                           select new BaseSalarios
                           {
                               ID = a.ID,
                               Nombre = a.Nombre
                           }).ToList();
            return paginas;
        }
        #endregion

        #region Tabla Dia
        public List<Dias> SelectDia()
        {
            var dias = (from a in _context.Dia
                        select new Dias
                        {
                            ID = a.ID,
                            Nombre = a.Nombre,
                        }).ToList();
            return dias;
        }
        #endregion

        #region Tabla Tipo Identificacion
        public List<TipoIdentificaciones> SelectTipoIdentificacion()
        {
            var tipos = (from a in _context.TipoIdentificacion
                           select new TipoIdentificaciones
                           {
                               ID = a.ID,
                               Nombre = a.Nombre
                           }).ToList();
            return tipos;
        }
        #endregion

        #region Tabla Usuario
        public Resultado InsertUsuario(Usuarios usu)
        {
            Resultado resultado = new Resultado();
            string usudb = (from a in _context.Usuario
                            where a.Alias.ToUpper() == usu.Alias.ToUpper()
                            select a.Alias).FirstOrDefault();
            if (string.IsNullOrEmpty(usudb))
            {
                Usuario usuNew = new Usuario()
                {
                    Alias = usu.Alias,
                    Contrasena = usu.Contraseña,
                    Rol = usu.Rol,
                    Email = usu.Email,
                    //Empleado = usu.Empleado
                    UsuarioAlta = usu.UsuarioAlta,
                    FechaAlta = DateTime.Now
                };
                _context.Usuario.Add(usuNew);

            }
            else
            {
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = true;
                return resultado;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;

        }
        public Resultado UpdateUsuario(Usuarios usu)
        {
            Resultado resultado = new Resultado();
            string usuName = (from a in _context.Usuario
                              where a.Alias.ToUpper() == usu.Alias.ToUpper()
                              select a.Alias).FirstOrDefault();
            if (string.IsNullOrEmpty(usuName))
            {
                var usudb = (from a in _context.Usuario
                             where a.ID == usu.ID
                             select a).FirstOrDefault();

                usudb.Alias = usu.Alias;
                usudb.Contrasena = usu.Contraseña;
                usudb.Rol = usu.Rol;
                usudb.Email = usu.Email;
                //usudb.Empleado = usu.Empleado;
                usudb.UsuarioMod = usu.UsuarioMod;
                usudb.FechaMod = DateTime.Now;

            }
            else
            {
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = true;
                return resultado;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public List<Usuarios> SelectUsuarios()
        {
            var usuarios = (from a in _context.Usuario
                         select new Usuarios
                         {
                             ID = a.ID,
                             Alias = a.Alias,
                             Contraseña = a.Contrasena,
                             Email = a.Email,
                             //Empleado = a.Empleado,
                             Rol = a.Rol,
                             UsuarioAlta = a.UsuarioAlta,
                             UsuarioMod = a.UsuarioMod,
                             FechaAlta = a.FechaAlta,
                             FechaMod = a.FechaMod
                         }).ToList();
            return usuarios;
        }
        #endregion

        #region Tabla Pais
        public Resultado InsertPais(Paises pai)
        {
            Resultado resultado = new Resultado();
            string paidb = (from a in _context.Pais
                            where a.Nombre.ToUpper() == pai.Nombre.ToUpper()
                            select a.Nombre).FirstOrDefault();
            if (string.IsNullOrEmpty(paidb))
            {
                Pais paiNew = new Pais()
                {
                    Nombre = pai.Nombre,
                    UsuarioAlta = pai.UsuarioAlta,
                    FechaAlta = DateTime.Now
                };
                _context.Pais.Add(paiNew);

            }
            else
            {
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = true;
                return resultado;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public Resultado UpdatePais(Paises pai)
        {
            Resultado resultado = new Resultado();
            string paiName = (from a in _context.Pais
                              where a.Nombre.ToUpper() == pai.Nombre.ToUpper()
                              select a.Nombre).FirstOrDefault();
            if (string.IsNullOrEmpty(paiName))
            {
                var paidb = (from a in _context.Pais
                             where a.ID == pai.ID
                             select a).FirstOrDefault();

                paidb.Nombre = pai.Nombre;
                paidb.UsuarioMod = pai.UsuarioMod;
                paidb.FechaMod = DateTime.Now;

            }
            else
            {
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = true;
                return resultado;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public Resultado DeletePais(Paises pai)
        {
            Resultado resultado = new Resultado();
            long idEstado = (from a in _context.Estado
                              where a.Pais == pai.ID
                              select a.ID).FirstOrDefault();
            if (idEstado > 0)
            {
                //No se puede eliminar este Rol ya que un usuario hace referencia a el
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = false;
                resultado.Referencia = true;
                return resultado;
            }
            Pais paiDelete = (from a in _context.Pais
                             where a.ID == pai.ID
                             select a).FirstOrDefault();
            _context.Pais.Remove(paiDelete);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                resultado.Referencia = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            resultado.Referencia = false;
            return resultado;
        }
        public List<Paises> SelectPais()
        {
            var paises = (from a in _context.Pais
                         select new Paises
                         {
                             ID = a.ID,
                             Nombre = a.Nombre,
                             UsuarioAlta = a.UsuarioAlta,
                             UsuarioMod = a.UsuarioMod,
                             FechaAlta = a.FechaAlta,
                             FechaMod = a.FechaMod
                         }).ToList();
            return paises;
        }
        #endregion

        #region Tabla Estado
        public Resultado InsertEstado(Estados est)
        {
            Resultado resultado = new Resultado();
            string estdb = (from a in _context.Estado
                            where a.Nombre.ToUpper() == est.Nombre.ToUpper() &&
                                a.Pais == est.Pais
                            select a.Nombre).FirstOrDefault();
            if (string.IsNullOrEmpty(estdb))
            {
                Estado estNew = new Estado()
                {
                    Nombre = est.Nombre,
                    Pais = est.Pais,
                    UsuarioAlta = est.UsuarioAlta,
                    FechaAlta = DateTime.Now
                };
                _context.Estado.Add(estNew);

            }
            else
            {
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = true;
                return resultado;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public Resultado UpdateEstado(Estados est)
        {
            Resultado resultado = new Resultado();
            string estName = (from a in _context.Estado
                              where a.Nombre.ToUpper() == est.Nombre.ToUpper()
                              select a.Nombre).FirstOrDefault();
            if (string.IsNullOrEmpty(estName))
            {
                var estdb = (from a in _context.Estado
                             where a.ID == est.ID
                             select a).FirstOrDefault();

                estdb.Nombre = est.Nombre;
                estdb.UsuarioMod = est.UsuarioMod;
                estdb.FechaMod = DateTime.Now;

            }
            else
            {
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = true;
                return resultado;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public List<Estados> SelectEstado()
        {
            var estados = (from a in _context.Estado
                          select new Estados
                          {
                              ID = a.ID,
                              Nombre = a.Nombre,
                              Pais = a.Pais,
                              UsuarioAlta = a.UsuarioAlta,
                              UsuarioMod = a.UsuarioMod,
                              FechaAlta = a.FechaAlta,
                              FechaMod = a.FechaMod
                          }).ToList();
            return estados;
        }
        #endregion

        #region Tabla Marca
        public Resultado InsertMarca(Marcas mar)
        {
            Resultado resultado = new Resultado();
            string mardb = (from a in _context.Marca
                            where a.Nombre.ToUpper() == mar.Nombre.ToUpper()
                            select a.Nombre).FirstOrDefault();
            if (string.IsNullOrEmpty(mardb))
            {
                Marca marNew = new Marca()
                {
                    Nombre = mar.Nombre,
                    UsuarioAlta = mar.UsuarioAlta,
                    FechaAlta = DateTime.Now
                };
                _context.Marca.Add(marNew);

            }
            else
            {
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = true;
                return resultado;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public Resultado UpdateMarca(Marcas mar)
        {
            Resultado resultado = new Resultado();
            string marName = (from a in _context.Marca
                              where a.Nombre.ToUpper() == mar.Nombre.ToUpper()
                              select a.Nombre).FirstOrDefault();
            if (string.IsNullOrEmpty(marName))
            {
                var mardb = (from a in _context.Marca
                             where a.ID == mar.ID
                             select a).FirstOrDefault();

                mardb.Nombre = mar.Nombre;
                mardb.UsuarioMod = mar.UsuarioMod;
                mardb.FechaMod = DateTime.Now;

            }
            else
            {
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = true;
                return resultado;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public Resultado DeleteMarca(Marcas mar)
        {
            Resultado resultado = new Resultado();

            Marca tivDelete = (from a in _context.Marca
                               where a.ID == mar.ID
                               select a).FirstOrDefault();
            _context.Marca.Remove(tivDelete);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                resultado.Referencia = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            resultado.Referencia = false;
            return resultado;
        }
        public List<Marcas> SelectMarca()
        {
            var marcas = (from a in _context.Marca
                          select new Marcas
                          {
                              ID = a.ID,
                              Nombre = a.Nombre,
                              UsuarioAlta = a.UsuarioAlta,
                              UsuarioMod = a.UsuarioMod,
                              FechaAlta = a.FechaAlta,
                              FechaMod = a.FechaMod
                          }).ToList();
            return marcas;
        }
        #endregion

        #region Tabla Modelo
        public Resultado InsertModelo(Modelos mod)
        {
            Resultado resultado = new Resultado();

            Modelo modNew = new Modelo()
            {
                Nombre = mod.Nombre,
                Marca = mod.Marca,
                UsuarioAlta = mod.UsuarioAlta,
                FechaAlta = DateTime.Now
            };
            _context.Modelo.Add(modNew);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public Resultado UpdateModelo(Modelos mod)
        {
            Resultado resultado = new Resultado();
            var moddb = (from a in _context.Modelo
                         where a.ID == mod.ID
                         select a).FirstOrDefault();

            moddb.Nombre = mod.Nombre;
            moddb.Marca = mod.Marca;
            moddb.UsuarioMod = mod.UsuarioMod;
            moddb.FechaMod = DateTime.Now;


            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public Resultado DeleteModelo(Modelos mod)
        {
            Resultado resultado = new Resultado();
            long idModelo = (from a in _context.Vehiculo
                             where a.Modelo == mod.ID
                             select a.ID).FirstOrDefault();
            if (idModelo > 0)
            {
                //No se puede eliminar este Modelo ya que un Vehiculo hace referencia a el
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = false;
                resultado.Referencia = true;
                return resultado;
            }
            var modDelete = (from a in _context.Modelo
                             where a.ID == mod.ID
                             select a).FirstOrDefault();
            _context.Modelo.Remove(modDelete);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                resultado.Referencia = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            resultado.Referencia = false;
            return resultado;
        }
        public List<Modelos> SelectModelo()
        {
            var modelos = (from a in _context.Modelo
                           select new Modelos
                           {
                               ID = a.ID,
                               Nombre = a.Nombre,
                               Marca = a.Marca,
                               UsuarioAlta = a.UsuarioAlta,
                               UsuarioMod = a.UsuarioMod,
                               FechaAlta = a.FechaAlta,
                               FechaMod = a.FechaMod
                           }).ToList();
            return modelos;
        }
        #endregion

        #region Tabla Color
        public Resultado InsertColor(Colores col)
        {
            Resultado resultado = new Resultado();

            Color colNew = new Color()
            {
                Nombre = col.Nombre,
            };
            _context.Color.Add(colNew);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public Resultado UpdateColor(Colores col)
        {
            Resultado resultado = new Resultado();
            var coldb = (from a in _context.Color
                         where a.ID == col.ID
                         select a).FirstOrDefault();

            coldb.Nombre = col.Nombre;


            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public Resultado DeleteColor(Colores col)
        {
            Resultado resultado = new Resultado();
            long idModelo = (from a in _context.Vehiculo
                             where a.Modelo == col.ID
                             select a.ID).FirstOrDefault();
            if (idModelo > 0)
            {
                //No se puede eliminar este Color ya que un Vehiculo hace referencia a el
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = false;
                resultado.Referencia = true;
                return resultado;
            }
            var colDelete = (from a in _context.Color
                             where a.ID == col.ID
                             select a).FirstOrDefault();
            _context.Color.Remove(colDelete);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                resultado.Referencia = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            resultado.Referencia = false;
            return resultado;
        }
        public List<Colores> SelectColor()
        {
            var colores = (from a in _context.Color
                           select new Colores
                           {
                               ID = a.ID,
                               Nombre = a.Nombre
                           }).ToList();
            return colores;
        }
        #endregion

        #region Tabla Tipo Producto
        public Resultado InsertTipoProducto(TipoProductos tip)
        {
            Resultado resultado = new Resultado();
            string tipdb = (from a in _context.TipoProducto
                            where a.Nombre.ToUpper() == tip.Nombre.ToUpper()
                            select a.Nombre).FirstOrDefault();
            if (string.IsNullOrEmpty(tipdb))
            {
                TipoProducto tipNew = new TipoProducto()
                {
                    Nombre = tip.Nombre,
                    UsuarioAlta = tip.UsuarioAlta,
                    FechaAlta = DateTime.Now
                };
                _context.TipoProducto.Add(tipNew);

            }
            else
            {
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = true;
                return resultado;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public Resultado UpdateTipoProducto(TipoProductos tip)
        {
            Resultado resultado = new Resultado();
            string tipName = (from a in _context.TipoProducto
                              where a.Nombre.ToUpper() == tip.Nombre.ToUpper()
                              select a.Nombre).FirstOrDefault();
            if (string.IsNullOrEmpty(tipName))
            {
                var tipdb = (from a in _context.TipoProducto
                             where a.ID == tip.ID
                             select a).FirstOrDefault();

                tipdb.Nombre = tip.Nombre;
                tipdb.UsuarioMod = tip.UsuarioMod;
                tipdb.FechaMod = DateTime.Now;

            }
            else
            {
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = true;
                return resultado;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public Resultado DeleteTipoProducto(TipoProductos tip)
        {
            Resultado resultado = new Resultado();
            long idRefs = (from a in _context.Producto
                           join b in _context.PromocionTipoProducto on
                            a.TipoProducto equals b.TipoProducto
                           where b.TipoProducto == tip.ID
                           select a.ID).FirstOrDefault();
            if (idRefs > 0)
            {
                //No se puede eliminar este Tipo de Vehiculo ya que un Modelo hace referencia a el
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = false;
                resultado.Referencia = true;
                return resultado;
            }
            TipoProducto tipDelete = (from a in _context.TipoProducto
                                      where a.ID == tip.ID
                                      select a).FirstOrDefault();
            _context.TipoProducto.Remove(tipDelete);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                resultado.Referencia = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            resultado.Referencia = false;
            return resultado;
        }
        public List<TipoProductos> SelectTipoProducto()
        {
            var tipos = (from a in _context.TipoProducto
                         select new TipoProductos
                         {
                             ID = a.ID,
                             Nombre = a.Nombre,
                             UsuarioAlta = a.UsuarioAlta,
                             UsuarioMod = a.UsuarioMod,
                             FechaAlta = a.FechaAlta,
                             FechaMod = a.FechaMod
                         }).ToList();
            return tipos;
        }
        #endregion

        #region Tabla Empleado
        public Resultado InsertEmpleado(Empleados emp)
        {
            Resultado resultado = new Resultado();
            string empdb = (from a in _context.Empleado
                            where a.Email.ToUpper() == emp.Email.ToUpper()
                            ||  a.NSS.ToUpper() == emp.NSS.ToUpper()
                            || a.CURP.ToUpper() == emp.NSS.ToUpper()
                            select a.Nombre).FirstOrDefault();
            if (string.IsNullOrEmpty(empdb))
            {
                Empleado empNew = new Empleado()
                {
                    RFC = emp.RFC,
                    Nombre = emp.Nombre,
                    Apellido = emp.Apellido,
                    Apellido2 = emp.Apellido2,
                    Calle = emp.Calle,
                    NumeroExterior = emp.NumeroExterior,
                    NumeroInterior = emp.NumeroInterior,
                    Colonia = emp.Colonia,
                    CP = emp.CP,
                    Localidad = emp.Localidad,
                    Ciudad = emp.Ciudad,
                    Telefono = emp.Telefono,
                    Email = emp.Email,
                    CURP = emp.CURP,
                    NSS = emp.NSS,
                    Salario = emp.Salario,
                    Estado = emp.Estado,
                    BaseSalario = emp.BaseSalario,
                    UsuarioAlta = emp.UsuarioAlta,
                    FechaAlta = DateTime.Now
                };
                _context.Empleado.Add(empNew);

            }
            else
            {
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = true;
                return resultado;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public Resultado UpdateEmpleado(Empleados emp)
        {
            Resultado resultado = new Resultado();
            string empName = (from a in _context.Empleado
                            where a.Email.ToUpper() == emp.Email.ToUpper()
                            || a.NSS.ToUpper() == emp.NSS.ToUpper()
                            || a.CURP.ToUpper() == emp.NSS.ToUpper()
                            select a.Nombre).FirstOrDefault();
            if (string.IsNullOrEmpty(empName))
            {
                var empdb = (from a in _context.Empleado
                             where a.ID == emp.ID
                             select a).FirstOrDefault();

                empdb.Nombre = emp.Nombre;
                empdb.RFC = emp.RFC;
                empdb.Apellido = emp.Apellido;
                empdb.Apellido2 = emp.Apellido2;
                empdb.Calle = emp.Calle;
                empdb.NumeroExterior = emp.NumeroExterior;
                empdb.NumeroInterior = emp.NumeroInterior;
                empdb.Colonia = emp.Colonia;
                empdb.CP = emp.CP;
                empdb.Localidad = emp.Localidad;
                empdb.Ciudad = emp.Ciudad;
                empdb.Telefono = emp.Telefono;
                empdb.Email = emp.Email;
                empdb.CURP = emp.CURP;
                empdb.NSS = emp.NSS;
                empdb.Salario = emp.Salario;
                empdb.BaseSalario = emp.BaseSalario;
                empdb.Estado = emp.Estado;
                empdb.UsuarioMod = emp.UsuarioMod;
                empdb.FechaMod = DateTime.Now;

            }
            else
            {
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = true;
                return resultado;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public Resultado DeleteEmpleado(Empleados emp)
        {
            Resultado resultado = new Resultado();
            Empleado empDelete = (from a in _context.Empleado
                              where a.ID == emp.ID
                              select a).FirstOrDefault();
            _context.Empleado.Remove(empDelete);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                resultado.Referencia = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            resultado.Referencia = false;
            return resultado;
        }
        public List<Empleados> SelectEmpleado()
        {
            var empleados = (from a in _context.Empleado
                          select new Empleados
                          {
                              ID = a.ID,
                              Nombre = a.Nombre,
                              RFC = a.RFC,
                              Apellido = a.Apellido,
                              Apellido2 = a.Apellido2,
                              Calle = a.Calle,
                              NumeroInterior = a.NumeroInterior,
                              NumeroExterior = a.NumeroInterior,
                              Colonia = a.Colonia,
                              CP = a.CP,
                              Localidad = a.Localidad,
                              Ciudad = a.Ciudad,
                              Telefono = a.Telefono,
                              Email = a.Email,
                              CURP = a.CURP,
                              NSS = a.NSS,
                              Salario = a.Salario,
                              BaseSalario = a.BaseSalario,
                              Estado = a.Estado,
                              UsuarioAlta = a.UsuarioAlta,
                              UsuarioMod = a.UsuarioMod,
                              FechaAlta = a.FechaAlta,
                              FechaMod = a.FechaMod
                          }).ToList();
            return empleados;
        }
        #endregion

        #region Tabla Vehiculo 
        public Resultado InsertVehiculos(Vehiculos veh)
        {
            Resultado resultado = new Resultado();
            string vehdb = (from a in _context.Vehiculo
                         where a.NoSerie.ToUpper() == veh.NoSerie.ToUpper()
                         select a.NoSerie).FirstOrDefault();
            if (string.IsNullOrEmpty(vehdb))
            {
                Vehiculo vehNew = new Vehiculo()
                {
                    NoSerie = veh.NoSerie,
                    Modelo = veh.Modelo,
                    Color = veh.Color,
                    Ano = veh.Ano,
                    Resposable = veh.Responsable,
                    NumeroIdentificacion = veh.NumeroIdentificacion,
                    TipoIdentificacion = veh.TipoIdentificacion,
                    UsuarioAlta = veh.UsuarioAlta,
                    FechaAlta = DateTime.Now
                };
                _context.Vehiculo.Add(vehNew);
            }
            else
            {
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = true;
                return resultado;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public Resultado UpdateVehiculos(Vehiculos veh)
        {
            Resultado resultado = new Resultado();
            string vehdb = (from a in _context.Vehiculo
                         where a.NoSerie.ToUpper() == veh.NoSerie.ToUpper()
                         select a.NoSerie).FirstOrDefault();
            if (string.IsNullOrEmpty(vehdb))
            {
                var vehmod = (from a in _context.Vehiculo
                             where a.ID == veh.ID
                             select a).FirstOrDefault();

                vehmod.NoSerie = veh.NoSerie;
                vehmod.Ano = veh.Ano;
                vehmod.Resposable = veh.Responsable;
                vehmod.NumeroIdentificacion = veh.NumeroIdentificacion;
                vehmod.TipoIdentificacion = veh.TipoIdentificacion;
                vehmod.Modelo = veh.Modelo;
                vehmod.Color = veh.Color;
                vehmod.UsuarioMod = veh.UsuarioMod;
                vehmod.FechaMod = DateTime.Now;
            }
            else
            {
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = true;
                return resultado;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public List<Vehiculos> SelectVehiculos()
        {
            var vehiculos = (from a in _context.Vehiculo
                           select new Vehiculos
                           {
                               ID = a.ID,
                               NoSerie = a.NoSerie,
                               Modelo = a.Modelo,
                               Color = a.Color,
                               Ano = a.Ano,
                               Responsable = a.Resposable,
                               NumeroIdentificacion = a.NumeroIdentificacion,
                               TipoIdentificacion = a.TipoIdentificacion,
                               UsuarioAlta = a.UsuarioAlta,
                               UsuarioMod = a.UsuarioMod,
                               FechaAlta = a.FechaAlta,
                               FechaMod = a.FechaMod
                           }).ToList();
            return vehiculos;
        }
        #endregion

        #region Tabla Proveedor
        public Resultado InsertProveedor(Proveedores pro)
        {
            Resultado resultado = new Resultado();
            string prodb = (from a in _context.Proveedor
                            where a.Nombre.ToUpper() == pro.Nombre.ToUpper()
                            || a.RFC.ToUpper() == pro.RFC.ToUpper()
                            select a.Nombre).FirstOrDefault();
            if (string.IsNullOrEmpty(prodb))
            {
                Proveedor proNew = new Proveedor()
                {
                    Nombre = pro.Nombre,
                    Tipo = pro.Tipo,
                    Apellido = pro.Apellido,
                    Apellido2 = pro.Apellido2,
                    RFC = pro.RFC,
                    Calle = pro.Calle,
                    NumeroInterior = pro.NumeroInterior,
                    NumeroExterior = pro.NumeroExterior,
                    Colonia = pro.Colonia,
                    CP = pro.CP,
                    Localidad = pro.Localidad,
                    Ciudad = pro.Ciudad,
                    Telefono = pro.Telefono,
                    Email = pro.Email,
                    Estado = pro.Estado,
                    UsuarioAlta = pro.UsuarioAlta,
                    FechaAlta = DateTime.Now
                };
                _context.Proveedor.Add(proNew);

            }
            else
            {
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = true;
                return resultado;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public Resultado UpdateProveedor(Proveedores pro)
        {
            Resultado resultado = new Resultado();
            string proName = (from a in _context.Proveedor
                            where a.Nombre.ToUpper() == pro.Nombre.ToUpper()
                            || a.RFC.ToUpper() == pro.RFC.ToUpper()
                            select a.Nombre).FirstOrDefault();
            if (string.IsNullOrEmpty(proName))
            {
                var prodb = (from a in _context.Proveedor
                             where a.ID == pro.ID
                             select a).FirstOrDefault();

                prodb.Nombre = pro.Nombre;
                prodb.Apellido = pro.Apellido;
                prodb.Apellido2 = pro.Apellido2;
                prodb.Tipo = pro.Tipo;
                prodb.RFC = pro.RFC;
                prodb.Calle = pro.Calle;
                prodb.NumeroExterior = pro.NumeroExterior;
                prodb.NumeroInterior = pro.NumeroInterior;
                prodb.Colonia = pro.Colonia;
                prodb.CP = pro.CP;
                prodb.Localidad = pro.Localidad;
                prodb.Ciudad = pro.Ciudad;
                prodb.Telefono = pro.Telefono;
                prodb.Email = pro.Email;
                prodb.Estado = pro.Estado;
                prodb.UsuarioMod = pro.UsuarioMod;
                prodb.FechaMod = DateTime.Now;

            }
            else
            {
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = true;
                return resultado;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public Resultado DeleteProveedor(Proveedores pro)
        {
            Resultado resultado = new Resultado();
            long idRefs = (from a in _context.Producto
                           where a.Proveedor == pro.ID
                           select a.ID).FirstOrDefault();
            if (idRefs > 0)
            {
                //No se puede eliminar este Proveedor ya que un Produto hace referencia a el
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = false;
                resultado.Referencia = true;
                return resultado;
            }
            TipoProducto tipDelete = (from a in _context.TipoProducto
                                      where a.ID == pro.ID
                                      select a).FirstOrDefault();
            _context.TipoProducto.Remove(tipDelete);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                resultado.Referencia = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            resultado.Referencia = false;
            return resultado;
        }
        public List<Proveedores> SelectProveedor()
        {
            var proveedores = (from a in _context.Proveedor
                         select new Proveedores
                         {
                             ID = a.ID,
                             Nombre = a.Nombre,
                             Apellido = a.Apellido,
                             Apellido2 = a.Apellido2,
                             Tipo = (bool)a.Tipo,
                             RFC = a.RFC,
                             Calle = a.Calle,
                             NumeroInterior = a.NumeroInterior,
                             NumeroExterior = a.NumeroExterior,
                             Colonia = a.Colonia,
                             CP = a.CP,
                             Localidad = a.Localidad,
                             Ciudad = a.Ciudad,
                             Telefono = a.Telefono,
                             Email = a.Email,
                             Estado = a.Estado,
                             UsuarioAlta = a.UsuarioAlta,
                             UsuarioMod = a.UsuarioMod,
                             FechaAlta = a.FechaAlta,
                             FechaMod = a.FechaMod
                         }).ToList();
            return proveedores;
        }
        #endregion

        #region Tabla Prodcuto
        public Resultado InsertProducto(Productos pro)
        {
            Resultado resultado = new Resultado();
            string prodb = (from a in _context.Producto
                            where a.Codigo.ToUpper() == pro.Codigo.ToUpper()
                            || a.Descripcion.ToUpper() == pro.Descripcion.ToUpper()
                            select a.Codigo).FirstOrDefault();
            if (string.IsNullOrEmpty(prodb))
            {
                Producto proNew = new Producto()
                {
                    Codigo = pro.Codigo,
                    Descripcion = pro.Descripcion,
                    PrecioVenta = pro.PrecioVenta,
                    PrecioCompra = pro.PrecioCompra,
                    Observaciones = pro.Observaciones,
                    IVAExcencto = pro.IVAExcento,
                    Servicio = pro.Servicio,
                    TipoProducto = pro.TipoProducto,
                    Proveedor = pro.Proveedor,
                    UsuarioAlta = pro.UsuarioAlta,
                    FechaAlta = DateTime.Now
                };
                _context.Producto.Add(proNew);

            }
            else
            {
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = true;
                return resultado;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public Resultado UpdateProducto(Productos pro)
        {
            Resultado resultado = new Resultado();
            string proName = (from a in _context.Producto
                            where a.Codigo.ToUpper() == pro.Codigo.ToUpper()
                            || a.Descripcion.ToUpper() == pro.Descripcion.ToUpper()
                            select a.Codigo).FirstOrDefault();
            if (string.IsNullOrEmpty(proName))
            {
                var prodb = (from a in _context.Producto
                             where a.ID == pro.ID
                             select a).FirstOrDefault();

                prodb.Codigo = pro.Codigo;
                prodb.Descripcion = pro.Descripcion;
                prodb.PrecioVenta = pro.PrecioVenta;
                prodb.PrecioCompra = pro.PrecioCompra;
                prodb.IVAExcencto = pro.IVAExcento;
                prodb.Observaciones = pro.Observaciones;
                prodb.Servicio = pro.Servicio;
                prodb.TipoProducto = pro.TipoProducto;
                prodb.Proveedor = pro.Proveedor;
                prodb.UsuarioMod = pro.UsuarioMod;
                prodb.FechaMod = DateTime.Now;

            }
            else
            {
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = true;
                return resultado;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public Resultado DeleteProducto(Productos pro)
        {
            Resultado resultado = new Resultado();
            long idRefs = (from a in _context.Producto
                           where a.Proveedor == pro.ID
                           select a.ID).FirstOrDefault();
            if (idRefs > 0)
            {
                //No se puede eliminar este Proveedor ya que un Produto hace referencia a el
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = false;
                resultado.Referencia = true;
                return resultado;
            }
            TipoProducto tipDelete = (from a in _context.TipoProducto
                                      where a.ID == pro.ID
                                      select a).FirstOrDefault();
            _context.TipoProducto.Remove(tipDelete);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                resultado.Referencia = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            resultado.Referencia = false;
            return resultado;
        }
        public List<Productos> SelectProducto()
        {
            var productos = (from a in _context.Producto
                               select new Productos
                               {
                                   ID = a.ID,
                                   Codigo = a.Codigo,
                                   Descripcion = a.Descripcion,
                                   PrecioVenta = a.PrecioVenta,
                                   PrecioCompra = a.PrecioCompra,
                                   Observaciones = a.Observaciones,
                                   Servicio = a.Servicio,
                                   IVAExcento = a.IVAExcencto,
                                   TipoProducto = a.TipoProducto,
                                   Proveedor = a.Proveedor,
                                   UsuarioAlta = a.UsuarioAlta,
                                   UsuarioMod = a.UsuarioMod,
                                   FechaAlta = a.FechaAlta,
                                   FechaMod = a.FechaMod
                               }).ToList();
            return productos;
        }
        #endregion

        #region Tabla Tipo Movimiento
        public Resultado InsertTipoMovimiento(TipoMovimientos tim)
        {
            Resultado resultado = new Resultado();
            string timdb = (from a in _context.TipoMovimiento
                            where a.Nombre.ToUpper() == tim.Nombre.ToUpper()
                            select a.Nombre).FirstOrDefault();
            if (string.IsNullOrEmpty(timdb))
            {
                TipoMovimiento timNew = new TipoMovimiento()
                {
                    Nombre = tim.Nombre,
                    Tipo = tim.Tipo,
                    UsuarioAlta = tim.UsuarioAlta,
                    FechaAlta = DateTime.Now
                };
                _context.TipoMovimiento.Add(timNew);

            }
            else
            {
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = true;
                return resultado;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public Resultado UpdateTipoMovimiento(TipoMovimientos tim)
        {
            Resultado resultado = new Resultado();
            string timName = (from a in _context.TipoMovimiento
                              where a.Nombre.ToUpper() == tim.Nombre.ToUpper()
                              select a.Nombre).FirstOrDefault();
            if (string.IsNullOrEmpty(timName))
            {
                var prodb = (from a in _context.TipoMovimiento
                             where a.ID == tim.ID
                             select a).FirstOrDefault();

                prodb.Nombre = tim.Nombre;
                prodb.Tipo = tim.Tipo;
                prodb.UsuarioMod = tim.UsuarioMod;
                prodb.FechaMod = DateTime.Now;

            }
            else
            {
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = true;
                return resultado;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public Resultado DeleteTipoMovimiento(TipoMovimientos tim)
        {
            Resultado resultado = new Resultado();
            long idRefs = (from a in _context.Movimiento
                           where a.TipoMoviemiento == tim.ID
                           select a.ID).FirstOrDefault();
            if (idRefs > 0)
            {
                //No se puede eliminar este Proveedor ya que un Produto hace referencia a el
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = false;
                resultado.Referencia = true;
                return resultado;
            }
            TipoProducto tipDelete = (from a in _context.TipoProducto
                                      where a.ID == tim.ID
                                      select a).FirstOrDefault();
            _context.TipoProducto.Remove(tipDelete);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                resultado.Referencia = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            resultado.Referencia = false;
            return resultado;
        }
        public List<TipoMovimientos> SelectTipoMovimiento()
        {
            var tipos = (from a in _context.TipoMovimiento
                             select new TipoMovimientos
                             {
                                 ID = a.ID,
                                 Nombre = a.Nombre,
                                 Tipo = a.Tipo,
                                 UsuarioAlta = a.UsuarioAlta,
                                 UsuarioMod = a.UsuarioMod,
                                 FechaAlta = a.FechaAlta,
                                 FechaMod = a.FechaMod
                             }).ToList();
            return tipos;
        }
        #endregion

        #region Tabla Movimiento 
        public Resultado InsertMovimiento(Movimientos mov)
        {
            Resultado resultado = new Resultado();
            
            Movimiento movNew = new Movimiento()
            {
                Cantidad = mov.Cantidad,
                Fecha = mov.Fecha,
                Importe = mov.Importe,
                TipoMoviemiento = mov.TipoMovimiento,
                Producto = mov.Producto,
                UsuarioAlta = mov.UsuarioAlta,
                FechaAlta = DateTime.Now
            };
            _context.Movimiento.Add(movNew);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public Resultado DeleteMovimiento(Movimientos mov)
        {
            Resultado resultado = new Resultado();
            
            Movimiento movDelete = (from a in _context.Movimiento
                                      where a.ID == mov.ID
                                      select a).FirstOrDefault();
            _context.Movimiento.Remove(movDelete);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                resultado.Referencia = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            resultado.Referencia = false;
            return resultado;
        }
        public List<Movimientos> SelectMovimiento()
        {
            var movimientos = (from a in _context.Movimiento
                         select new Movimientos
                         {
                             ID = a.ID,
                             Cantidad = a.Cantidad,
                             Fecha = a.Fecha,
                             Importe = a.Importe,
                             TipoMovimiento = a.TipoMoviemiento,
                             Producto = a.Producto,
                             UsuarioAlta = a.UsuarioAlta,
                             UsuarioMod = a.UsuarioMod,
                             FechaAlta = a.FechaAlta,
                             FechaMod = a.FechaMod
                         }).ToList();
            return movimientos;
        }
        #endregion

        #region Tabla Grupo Cliente
        public Resultado InsertGrupoCliente(GrupoClientes gcl)
        {
            Resultado resultado = new Resultado();
            string gcldb = (from a in _context.GrupoCliente
                            where a.Nombre.ToUpper() == gcl.Nombre.ToUpper()
                            select a.Nombre).FirstOrDefault();
            if (string.IsNullOrEmpty(gcldb))
            {
                GrupoCliente gclNew = new GrupoCliente()
                {
                    Nombre = gcl.Nombre,
                    UsuarioAlta = gcl.UsuarioAlta,
                    FechaAlta = DateTime.Now
                };
                _context.GrupoCliente.Add(gclNew);

            }
            else
            {
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = true;
                return resultado;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public Resultado UpdateGurpoCliente(GrupoClientes gcl)
        {
            Resultado resultado = new Resultado();
            string gclName = (from a in _context.GrupoCliente
                              where a.Nombre.ToUpper() == gcl.Nombre.ToUpper()
                              select a.Nombre).FirstOrDefault();
            if (string.IsNullOrEmpty(gclName))
            {
                var gcldb = (from a in _context.GrupoCliente
                             where a.ID == gcl.ID
                             select a).FirstOrDefault();

                gcldb.Nombre = gcl.Nombre;
                gcldb.UsuarioMod = gcl.UsuarioMod;
                gcldb.FechaMod = DateTime.Now;

            }
            else
            {
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = true;
                return resultado;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public Resultado DeleteGrupoCliente(GrupoClientes gcl)
        {
            Resultado resultado = new Resultado();
            long idRefs = (from a in _context.Cliente
                           where a.GrupoCliente == gcl.ID
                           select a.ID).FirstOrDefault();
            if (idRefs > 0)
            {
                //No se puede eliminar este Grupo de Clientes ya que un Cliente hace referencia a el
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = false;
                resultado.Referencia = true;
                return resultado;
            }
            var gclDelete = (from a in _context.GrupoCliente
                                      where a.ID == gcl.ID
                                      select a).FirstOrDefault();
            _context.GrupoCliente.Remove(gclDelete);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                resultado.Referencia = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            resultado.Referencia = false;
            return resultado;
        }
        public List<GrupoClientes> SelectGrupoCliente()
        {
            var grupos = (from a in _context.GrupoCliente
                         select new GrupoClientes
                         {
                             ID = a.ID,
                             Nombre = a.Nombre,
                             UsuarioAlta = a.UsuarioAlta,
                             UsuarioMod = a.UsuarioMod,
                             FechaAlta = a.FechaAlta,
                             FechaMod = a.FechaMod
                         }).ToList();
            return grupos;
        }
        #endregion

        #region Tabla Cliente
        public Resultado InsertCliente(Clientes cli)
        {
            Resultado resultado = new Resultado();
            string clidb = (from a in _context.Cliente
                            where a.Nombre.ToUpper() == cli.Nombre.ToUpper()
                            || a.RFC.ToUpper() == cli.RFC.ToUpper() 
                            select a.Nombre).FirstOrDefault();
            if (string.IsNullOrEmpty(clidb))
            {
                Cliente cliNew = new Cliente()
                {
                    Nombre = cli.Nombre,
                    Apellido = cli.Apellido,
                    Apellido2 = cli.Apellido2,
                    RFC = cli.RFC,
                    Calle = cli.Calle,
                    NumeroExterior = cli.NumeroExterior,
                    NumeroInterior = cli.NumeroInterior,
                    Colonia = cli.Colonia,
                    CP = cli.CP,
                    Localidad = cli.Localidad,
                    Ciudad = cli.Ciudad,
                    Telefono =cli.Telefono,
                    Email = cli.Email,
                    Estado = cli.Estado,
                    GrupoCliente = cli.GrupoCliente,
                    UsuarioAlta = cli.UsuarioAlta,
                    FechaAlta = DateTime.Now
                };
                _context.Cliente.Add(cliNew);

            }
            else
            {
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = true;
                return resultado;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public Resultado UpdateCliente(Clientes cli)
        {
            Resultado resultado = new Resultado();
            string cliName = (from a in _context.Cliente
                              where a.Nombre.ToUpper() == cli.Nombre.ToUpper()
                              || a.RFC.ToUpper() == cli.RFC.ToUpper() 
                              select a.Nombre).FirstOrDefault();
            if (string.IsNullOrEmpty(cliName))
            {
                var clidb = (from a in _context.Cliente
                             where a.ID == cli.ID
                             select a).FirstOrDefault();

                clidb.Nombre = cli.Nombre;
                clidb.Apellido = cli.Apellido;
                clidb.Apellido2 = cli.Apellido2;
                clidb.RFC = cli.RFC;
                clidb.Calle = cli.Calle;
                clidb.NumeroExterior = cli.NumeroExterior;
                clidb.NumeroInterior = cli.NumeroInterior;
                clidb.Colonia = cli.Colonia;
                clidb.CP = cli.CP;
                clidb.Localidad = cli.Localidad;
                clidb.Ciudad = cli.Ciudad;
                clidb.Telefono = cli.Telefono;
                clidb.Email = cli.Email;
                clidb.Estado = cli.Estado;
                clidb.GrupoCliente = cli.GrupoCliente;
                clidb.UsuarioMod = cli.UsuarioMod;
                clidb.FechaMod = DateTime.Now;

            }
            else
            {
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = true;
                return resultado;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public Resultado DeleteCliente(Clientes cli)
        {
            Resultado resultado = new Resultado();
            long idRefs = (from a in _context.Cliente
                           where a.GrupoCliente == cli.ID
                           select a.ID).FirstOrDefault();
            if (idRefs > 0)
            {
                //No se puede eliminar este Grupo de Clientes ya que un Cliente hace referencia a el
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = false;
                resultado.Referencia = true;
                return resultado;
            }
            var gclDelete = (from a in _context.GrupoCliente
                             where a.ID == cli.ID
                             select a).FirstOrDefault();
            _context.GrupoCliente.Remove(gclDelete);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                resultado.Referencia = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            resultado.Referencia = false;
            return resultado;
        }
        public List<Clientes> SelectCliente()
        {
            var clientes = (from a in _context.Cliente
                          select new Clientes
                          {
                              ID = a.ID,
                              //Tipo = a.Tipo,
                              Nombre = a.Nombre,
                              Apellido = a.Apellido,
                              Apellido2 = a.Apellido2,
                              RFC = a.RFC,
                              Calle = a.Calle,
                              NumeroExterior =a.NumeroExterior,
                              NumeroInterior = a.NumeroInterior,
                              Colonia = a.Colonia,
                              CP = a.CP,
                              Localidad = a.Localidad,
                              Ciudad = a.Ciudad,
                              Telefono = a.Telefono,
                              Email = a.Email,
                              Estado = a.Estado,
                              GrupoCliente = a.GrupoCliente,
                              UsuarioAlta = a.UsuarioAlta,
                              UsuarioMod = a.UsuarioMod,
                              FechaAlta = a.FechaAlta,
                              FechaMod = a.FechaMod
                          }).ToList();
            return clientes;
        }
        #endregion

        #region Tabla Paquete 
        public Resultado InsertPaquete(Paquetes paq)
        {
            Resultado resultado = new Resultado();
            string paqdb = (from a in _context.Paquete
                            where a.Nombre.ToUpper() == paq.Nombre.ToUpper()
                            select a.Nombre).FirstOrDefault();
            if (string.IsNullOrEmpty(paqdb))
            {
                Paquete paqNew = new Paquete()
                {
                    Nombre = paq.Nombre,
                    Descripcion = paq.Descripcion,
                    Precio = paq.Precio,
                    ParaGrupoCliente  = paq.ParaGrupoCliente,
                    Activo = paq.Activo,
                    FechaInicio = paq.FechaInicio,
                    FechaFin = paq.FechaFin,
                    UsuarioAlta = paq.UsuarioAlta,
                    FechaAlta = DateTime.Now
                };
                _context.Paquete.Add(paqNew);

            }
            else
            {
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = true;
                return resultado;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public Resultado UpdatePaquete(Paquetes paq)
        {
            Resultado resultado = new Resultado();
            string paqName = (from a in _context.Paquete
                              where a.Nombre.ToUpper() == paq.Nombre.ToUpper()
                              select a.Nombre).FirstOrDefault();
            if (string.IsNullOrEmpty(paqName))
            {
                var paqdb = (from a in _context.Paquete
                             where a.ID == paq.ID
                             select a).FirstOrDefault();

                paqdb.Nombre = paq.Nombre;
                paqdb.Descripcion = paq.Descripcion;
                paqdb.Precio = paq.Precio;
                paqdb.ParaGrupoCliente = paq.ParaGrupoCliente;
                paqdb.Activo = paq.Activo;
                paqdb.FechaInicio = paq.FechaInicio;
                paqdb.FechaFin = paq.FechaFin;
                paqdb.UsuarioMod = paq.UsuarioMod;
                paqdb.FechaMod = DateTime.Now;

            }
            else
            {
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = true;
                return resultado;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public List<Paquetes> SelectPaquete()
        {
            var paquetes = (from a in _context.Paquete
                            select new Paquetes
                            {
                                ID = a.ID,
                                Nombre = a.Nombre,
                                Descripcion = a.Descripcion,
                                Precio = a.Precio,
                                ParaGrupoCliente = a.ParaGrupoCliente,
                                Activo = a.Activo,
                                FechaFin = a.FechaFin,
                                FechaInicio = a.FechaInicio,
                                UsuarioAlta = a.UsuarioAlta,
                                UsuarioMod = a.UsuarioMod,
                                FechaAlta = a.FechaAlta,
                                FechaMod = a.FechaMod
                            }).ToList();
            return paquetes;
        }
        #endregion

        #region Tabla Paquete Dia
        public Resultado InsertPaqueteDia(PaqueteDias pqd)
        {
            Resultado resultado = new Resultado();
            
            PaqueteDia pqdNew = new PaqueteDia()
            {
                Paquete = pqd.Paquete,
                Dia = pqd.Dia,
                UsuarioAlta = pqd.UsuarioAlta,
                FechaAlta = DateTime.Now
            };
            _context.PaqueteDia.Add(pqdNew);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public Resultado DeletePaqueteDia(PaqueteDias pqd)
        {
            Resultado resultado = new Resultado();
            
            var gclDelete = (from a in _context.PaqueteDia
                             where a.ID == pqd.ID
                             select a).FirstOrDefault();
            _context.PaqueteDia.Remove(gclDelete);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                resultado.Referencia = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            resultado.Referencia = false;
            return resultado;
        }
        public List<PaqueteDias> SelectPaqueteDia()
        {
            var paquetes = (from a in _context.PaqueteDia
                            select new PaqueteDias
                            {
                                ID = a.ID,
                                Paquete = a.Paquete,
                                Dia = a.Dia,
                                UsuarioAlta = a.UsuarioAlta,
                                UsuarioMod = a.UsuarioMod,
                                FechaAlta = a.FechaAlta,
                                FechaMod = a.FechaMod
                            }).ToList();
            return paquetes;
        }
        #endregion

        #region Tabla Paquete Grupo Cliente 
        public Resultado InsertPaqueteGrupoCliente(PaqueteGrupoClientes pgc)
        {
            Resultado resultado = new Resultado();

            PaqueteGrupoCliente pgcNew = new PaqueteGrupoCliente()
            {
                Paquete = pgc.Paquete,
                GrupoCliente = pgc.GrupoCliente
            };
            _context.PaqueteGrupoCliente.Add(pgcNew);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public Resultado DeletePaqueteGrupoCliente(PaqueteGrupoClientes pgc)
        {
            Resultado resultado = new Resultado();
            var pgcDelete = (from a in _context.PaqueteGrupoCliente
                             where a.ID == pgc.ID
                             select a).FirstOrDefault();
            _context.PaqueteGrupoCliente.Remove(pgcDelete);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                resultado.Referencia = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            resultado.Referencia = false;
            return resultado;
        }
        public List<PaqueteGrupoClientes> SelectPaqueteGrupoCliente()
        {
            var paquetes = (from a in _context.PaqueteGrupoCliente
                            select new PaqueteGrupoClientes
                            {
                                ID = a.ID,
                                Paquete = a.Paquete,
                                GrupoCliente = a.GrupoCliente
                            }).ToList();
            return paquetes;
        }
        #endregion

        #region Tabla Paquete Producto 
        public Resultado InsertPaqueteProducto(PaqueteProductos ppr)
        {
            Resultado resultado = new Resultado();

            PaqueteProducto pprNew = new PaqueteProducto()
            {
                Paquete = ppr.Paquete,
                Producto = ppr.Producto
            };
            _context.PaqueteProducto.Add(pprNew);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public Resultado DeletePaqueteProducto(PaqueteProductos ppr)
        {
            Resultado resultado = new Resultado();
            var pprDelete = (from a in _context.PaqueteProducto
                             where a.ID == ppr.ID
                             select a).FirstOrDefault();
            _context.PaqueteProducto.Remove(pprDelete);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                resultado.Referencia = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            resultado.Referencia = false;
            return resultado;
        }
        public List<PaqueteProductos> SelectPaqueteProducto()
        {
            var paquetes = (from a in _context.PaqueteProducto
                            select new PaqueteProductos
                            {
                                ID = a.ID,
                                Paquete = a.Paquete,
                                Producto = a.Producto
                            }).ToList();
            return paquetes;
        }
        #endregion

        #region Tabla Promocion 
        public Resultado InsertPromocion(Promociones pro)
        {
            Resultado resultado = new Resultado();
            string prodb = (from a in _context.Promocion
                            where a.Nombre.ToUpper() == pro.Nombre.ToUpper()
                            select a.Nombre).FirstOrDefault();
            if (string.IsNullOrEmpty(prodb))
            {
                Promocion proNew = new Promocion()
                {
                    Nombre = pro.Nombre,
                    Descripcion = pro.Descripcion,
                    Tipo = pro.Tipo,
                    Valor = pro.Valor,
                    Comprar = pro.Comprar,
                    Pagar = pro.Pagar,
                    Activo = pro.Activo,
                    FechaInicio = pro.FechaInicio,
                    FechaFin = pro.FechaFin,
                    ParaPaquete = pro.ParaPaquete,
                    ParaTipoProducto = pro.ParaTipoProducto,
                    ParaProducto = pro.ParaProducto,
                    ParaGrupoCliente = pro.ParaGrupoCliente,
                    UsuarioAlta = pro.UsuarioAlta,
                    FechaAlta = DateTime.Now
                };
                _context.Promocion.Add(proNew);

            }
            else
            {
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = true;
                return resultado;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public Resultado UpdatePromocion(Promociones pro)
        {
            Resultado resultado = new Resultado();
            string proName = (from a in _context.Promocion
                              where a.Nombre.ToUpper() == pro.Nombre.ToUpper()
                              select a.Nombre).FirstOrDefault();
            if (string.IsNullOrEmpty(proName))
            {
                var prodb = (from a in _context.Promocion
                             where a.ID == pro.ID
                             select a).FirstOrDefault();

                prodb.Nombre = pro.Nombre;
                prodb.Descripcion = pro.Descripcion;
                prodb.Tipo = pro.Tipo;
                prodb.Valor = pro.Valor;
                prodb.Comprar = pro.Comprar;
                prodb.Pagar = pro.Pagar;
                prodb.Activo = pro.Activo;
                prodb.FechaInicio = pro.FechaInicio;
                prodb.FechaFin = pro.FechaFin;
                prodb.ParaPaquete = pro.ParaPaquete;
                prodb.ParaTipoProducto = pro.ParaTipoProducto;
                prodb.ParaProducto = pro.ParaProducto;
                prodb.ParaGrupoCliente = pro.ParaGrupoCliente;
                prodb.UsuarioMod = pro.UsuarioMod;
                prodb.FechaMod = DateTime.Now;

            }
            else
            {
                resultado.Realizado = false;
                resultado.ErrorDB = false;
                resultado.YaExiste = true;
                return resultado;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public List<Promociones> SelectPromocion()
        {
            var promociones = (from a in _context.Promocion
                            select new Promociones
                            {
                                ID = a.ID,
                                Nombre = a.Nombre,
                                Descripcion = a.Descripcion,
                                Tipo = a.Tipo,
                                Valor = a.Valor,
                                Comprar = a.Comprar,
                                Pagar = a.Pagar,
                                Activo = a.Activo,
                                FechaInicio = a.FechaInicio,
                                FechaFin = a.FechaFin,
                                ParaPaquete = a.ParaPaquete,
                                ParaTipoProducto = a.ParaTipoProducto,
                                ParaGrupoCliente = a.ParaGrupoCliente,
                                ParaProducto = a.ParaProducto,
                                UsuarioAlta = a.UsuarioAlta,
                                UsuarioMod = a.UsuarioMod,
                                FechaAlta = a.FechaAlta,
                                FechaMod = a.FechaMod
                            }).ToList();
            return promociones;
        }
        #endregion

        #region Tabla Promocion Dia 
        public Resultado InsertPromocionDia(PromocionDias prd)
        {
            Resultado resultado = new Resultado();

            PromocionDia prdNew = new PromocionDia()
            {
                Promocion = prd.Promocion,
                Dia = prd.Dia,
                UsuarioAlta = prd.UsuarioAlta,
                FechaAlta = DateTime.Now
            };
            _context.PromocionDia.Add(prdNew);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public Resultado DeletePromocionDia(PromocionDias prd)
        {
            Resultado resultado = new Resultado();

            var prdDelete = (from a in _context.PromocionDia
                             where a.ID == prd.ID
                             select a).FirstOrDefault();
            _context.PromocionDia.Remove(prdDelete);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                resultado.Referencia = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            resultado.Referencia = false;
            return resultado;
        }
        public List<PromocionDias> SelectPromocionDia()
        {
            var promocion = (from a in _context.PromocionDia
                            select new PromocionDias
                            {
                                ID = a.ID,
                                Promocion = a.Promocion,
                                Dia = a.Dia,
                                UsuarioAlta = a.UsuarioAlta,
                                UsuarioMod = a.UsuarioMod,
                                FechaAlta = a.FechaAlta,
                                FechaMod = a.FechaMod
                            }).ToList();
            return promocion;
        }
        #endregion

        #region Tabla Promocion Paquete
        public Resultado InsertPromocionPaquete(PromocionPaquetes prr)
        {
            Resultado resultado = new Resultado();

            PromocionPaquete prrNew = new PromocionPaquete()
            {
                Promocion = prr.Promocion,
                Paquete = prr.Paquete
            };
            _context.PromocionPaquete.Add(prrNew);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public Resultado DeletePromocionPaquete(PromocionPaquetes prr)
        {
            Resultado resultado = new Resultado();
            var prrDelete = (from a in _context.PromocionPaquete
                             where a.ID == prr.ID
                             select a).FirstOrDefault();
            _context.PromocionPaquete.Remove(prrDelete);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                resultado.Referencia = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            resultado.Referencia = false;
            return resultado;
        }
        public List<PromocionPaquetes> SelectPromocionPaquete()
        {
            var promos = (from a in _context.PromocionPaquete
                          select new PromocionPaquetes
                          {
                              ID = a.ID,
                              Promocion = a.Promocion,
                              Paquete = a.Paquete
                          }).ToList();
            return promos;
        }
        #endregion

        #region Tabla Promocion Tipo Producto 
        public Resultado InsertPromocionTipoProducto(PromocionTipoProductos ptp)
        {
            Resultado resultado = new Resultado();

            PromocionTipoProducto ptpNew = new PromocionTipoProducto()
            {
                Promocion = ptp.Promocion,
                TipoProducto = ptp.TipoProducto
            };
            _context.PromocionTipoProducto.Add(ptpNew);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public Resultado DeletePromocionTipoProducto(PromocionTipoProductos ptp)
        {
            Resultado resultado = new Resultado();
            var ptpDelete = (from a in _context.PromocionTipoProducto
                             where a.ID == ptp.ID
                             select a).FirstOrDefault();
            _context.PromocionTipoProducto.Remove(ptpDelete);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                resultado.Referencia = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            resultado.Referencia = false;
            return resultado;
        }
        public List<PromocionTipoProductos> SelectPromocionTipoProducto()
        {
            var promos = (from a in _context.PromocionTipoProducto
                          select new PromocionTipoProductos
                          {
                              ID = a.ID,
                              Promocion = a.Promocion,
                              TipoProducto = a.TipoProducto
                          }).ToList();
            return promos;
        }
        #endregion

        #region Tabla Promocion Producto
        public Resultado InsertPromocionProducto(PromocionProductos prr)
        {
            Resultado resultado = new Resultado();

            PromocionProducto prrNew = new PromocionProducto()
            {
                Promocion = prr.Promocion,
                Producto = prr.Producto
            };
            _context.PromocionProducto.Add(prrNew);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public Resultado DeletePromocionProducto(PromocionProductos prr)
        {
            Resultado resultado = new Resultado();
            var prrDelete = (from a in _context.PromocionProducto
                             where a.ID == prr.ID
                             select a).FirstOrDefault();
            _context.PromocionProducto.Remove(prrDelete);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                resultado.Referencia = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            resultado.Referencia = false;
            return resultado;
        }
        public List<PromocionProductos> SelectPromocionProducto()
        {
            var promos = (from a in _context.PromocionProducto
                          select new PromocionProductos
                          {
                              ID = a.ID,
                              Promocion = a.Promocion,
                              Producto = a.Producto
                          }).ToList();
            return promos;
        }
        #endregion

        #region Tabla Promocion Grupo Cliente
        public Resultado InsertPromocionGrupoCliente(PromocionGrupoClientes prc)
        {
            Resultado resultado = new Resultado();

            PromocionTipoCliente  prcNew = new PromocionTipoCliente()
            {
                Promocion = prc.Promocion,
                GrupoCliente = prc.GrupoCliente
            };
            _context.PromocionTipoCliente.Add(prcNew);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            return resultado;
        }
        public Resultado DeletePromocionGrupoCliente(PromocionGrupoClientes prc)
        {
            Resultado resultado = new Resultado();
            var prcDelete = (from a in _context.PromocionTipoCliente
                             where a.ID == prc.ID
                             select a).FirstOrDefault();
            _context.PromocionTipoCliente.Remove(prcDelete);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                resultado.Realizado = false;
                resultado.ErrorDB = true;
                resultado.YaExiste = false;
                resultado.Referencia = false;
                return resultado;
            }
            resultado.Realizado = true;
            resultado.ErrorDB = false;
            resultado.YaExiste = false;
            resultado.Referencia = false;
            return resultado;
        }
        public List<PromocionGrupoClientes> SelectPromocionGrupoCliente()
        {
            var promos = (from a in _context.PromocionTipoCliente
                            select new PromocionGrupoClientes
                            {
                                ID = a.ID,
                                Promocion = a.Promocion,
                                GrupoCliente = a.GrupoCliente
                            }).ToList();
            return promos;
        }
        #endregion


        
    }
}
