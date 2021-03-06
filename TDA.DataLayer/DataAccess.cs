﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDA.Entities;

namespace TDA.DataLayer
{
    public class DataAccess
    {
        TDAEntities _context = new TDAEntities();

        #region Tabla Configuracion
        public List<Configuraciones> SelectConfiguracion()
        {
            var conf = (from a in _context.Configuracion
                         select new Configuraciones
                         {
                             ID = a.ID,
                             Nombre = a.Nombre,
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
        //Select Pagina Rol
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
        public Paginas BuscarPaginaID(long? ID)
        {
            var paginas = (from a in _context.Pagina
                           where a.ID == ID
                           select new Paginas
                           {
                               ID = a.ID,
                               Nombre = a.Nombre,
                           }).FirstOrDefault();
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
            var paginas = (from a in _context.BaseSalario orderby a.ID
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
                    Empleado = usu.Empleado,
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
                usudb.Empleado = usu.Empleado;
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
        public Resultado DeleteUsuario(Usuarios usu)
        {
            Resultado resultado = new Resultado();
            var usudb = (from a in _context.Usuario
                            where a.ID == usu.ID
                            select a).FirstOrDefault();

            _context.Usuario.Remove(usudb);
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
        public List<Usuarios> SelectUsuarios(Usuarios usu)
        {
            var usuarios = (from a in _context.Usuario
                            select new Usuarios
                            {
                                ID = a.ID,
                                Alias = a.Alias,
                                Contraseña = a.Contrasena,
                                Email = a.Email,
                                Empleado = a.Empleado,
                                Rol = a.Rol,
                                UsuarioAlta = a.UsuarioAlta,
                                UsuarioMod = a.UsuarioMod,
                                FechaAlta = a.FechaAlta,
                                FechaMod = a.FechaMod
                            }).ToList();
            usuarios = usuarios.Where(p => String.IsNullOrEmpty(usu.Alias) || p.Alias.Contains(usu.Alias)).ToList();
            usuarios = usuarios.Where(p => usu.Rol < 0 || p.Rol == usu.Rol ).ToList();
            return usuarios;
        }
        public List<Usuarios> BuscarUsuariosID(long ID)
        {
            var usuarios = (from a in _context.Usuario
                            where a.ID == ID
                            select new Usuarios
                            {
                                ID = a.ID,
                                Alias = a.Alias,
                                Contraseña = a.Contrasena,
                                Email = a.Email,
                                Empleado = a.Empleado,
                                Rol = a.Rol,
                                UsuarioAlta = a.UsuarioAlta,
                                UsuarioMod = a.UsuarioMod,
                                FechaAlta = a.FechaAlta,
                                FechaMod = a.FechaMod
                            }).ToList();
            return usuarios;
        }
        public Usuarios BuscarUsuarioAlias(String Alias)
        {
            var usuarios = (from a in _context.Usuario
                            where a.Alias == Alias
                            select new Usuarios
                            {
                                ID = a.ID,
                                Alias = a.Alias,
                                Contraseña = a.Contrasena,
                                Email = a.Email,
                                Empleado = a.Empleado,
                                Rol = a.Rol,
                                UsuarioAlta = a.UsuarioAlta,
                                UsuarioMod = a.UsuarioMod,
                                FechaAlta = a.FechaAlta,
                                FechaMod = a.FechaMod
                            }).FirstOrDefault();
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
        public List<Paises> SelectPais(Paises pai)
        {
            if (!String.IsNullOrWhiteSpace(pai.Nombre))
            {
                return BuscarPais(pai.Nombre);
            }
            else {
                return BuscarPais();
            }

        }
        public List<Paises> BuscarPaisID(long ID)
        {
            var paises = (from a in _context.Pais
                          where a.ID == ID
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
        //Buscar por Nombre
        public List<Paises> BuscarPais()
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
        public List<Paises> BuscarPais(String Nombre)
        {
            var paises = (from a in _context.Pais
                          where a.Nombre.ToUpper().Contains(Nombre.ToUpper())
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
                              where a.Nombre.ToUpper() == est.Nombre.ToUpper() && a.Pais == est.Pais
                              select a.Nombre).FirstOrDefault();
            if (string.IsNullOrEmpty(estName))
            {
                var estdb = (from a in _context.Estado
                             where a.ID == est.ID
                             select a).FirstOrDefault();

                estdb.Nombre = est.Nombre;
                estdb.Pais = est.Pais;
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
        public Resultado DeleteEstado(Estados est)
        {
            Resultado resultado = new Resultado();
            string estName = (from a in _context.Estado
                              join b in _context.Cliente on a.ID equals b.Estado
                              join c in _context.Proveedor on a.ID equals c.Estado
                              join d in _context.Empleado on a.ID equals d.Estado
                              where a.ID == est.ID
                              select a.Nombre).FirstOrDefault();
            if (string.IsNullOrEmpty(estName))
            {
                var estDel = (from a in _context.Estado
                              where a.ID == est.ID
                              select a).FirstOrDefault();
                _context.Estado.Remove(estDel);
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
        public List<Estados> SelectEstado(Estados est)
        {
            if (!String.IsNullOrWhiteSpace(est.Nombre))
            {
                if (est.Pais > 0)
                {
                    return BuscarEstado(est.Nombre, est.Pais);
                }
                return BuscarEstado(est.Nombre);
            }
            else if (est.Pais > 0)
            {
                return BuscarEstado(est.Pais);
            }
            else
            {
                return BuscarEstado();
            }
        }
        public List<Estados> BuscarEstadoID(long ID)
        {
            var estados = (from a in _context.Estado
                           where a.ID == ID
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
        //Buscar por Pais y Nombre
        public List<Estados> BuscarEstado()
        {
            var estados = (from a in _context.Estado
                           join b in _context.Pais on a.Pais equals b.ID
                           select new Estados
                           {
                               ID = a.ID,
                               Nombre = a.Nombre,
                               Pais = a.Pais,
                               UsuarioAlta = a.UsuarioAlta,
                               UsuarioMod = a.UsuarioMod,
                               FechaAlta = a.FechaAlta,
                               FechaMod = a.FechaMod,
                               PaisNombre = b.Nombre
                           }).ToList();
            return estados;
        }
        public List<Estados> BuscarEstado(String Nombre)
        {
            var estados = (from a in _context.Estado
                           join b in _context.Pais on a.Pais equals b.ID
                           where a.Nombre.ToUpper().Contains(Nombre.ToUpper())
                           select new Estados
                           {
                               ID = a.ID,
                               Nombre = a.Nombre,
                               Pais = a.Pais,
                               UsuarioAlta = a.UsuarioAlta,
                               UsuarioMod = a.UsuarioMod,
                               FechaAlta = a.FechaAlta,
                               FechaMod = a.FechaMod,
                               PaisNombre = b.Nombre
                           }).ToList();
            return estados;
        }
        public List<Estados> BuscarEstado(long? Pais)
        {
            var estados = (from a in _context.Estado
                           join b in _context.Pais on a.Pais equals b.ID
                           where a.Pais == Pais
                           select new Estados
                           {
                               ID = a.ID,
                               Nombre = a.Nombre,
                               Pais = a.Pais,
                               UsuarioAlta = a.UsuarioAlta,
                               UsuarioMod = a.UsuarioMod,
                               FechaAlta = a.FechaAlta,
                               FechaMod = a.FechaMod,
                               PaisNombre = b.Nombre
                           }).ToList();
            return estados;
        }
        public List<Estados> BuscarEstado(String Nombre, long? Pais)
        {
            var estados = (from a in _context.Estado
                           join b in _context.Pais on a.Pais equals b.ID
                           where a.Nombre.ToUpper().Contains(Nombre.ToUpper()) && a.Pais == Pais
                           select new Estados
                           {
                               ID = a.ID,
                               Nombre = a.Nombre,
                               Pais = a.Pais,
                               UsuarioAlta = a.UsuarioAlta,
                               UsuarioMod = a.UsuarioMod,
                               FechaAlta = a.FechaAlta,
                               FechaMod = a.FechaMod,
                               PaisNombre = b.Nombre
                           }).ToList();
            return estados;
        }

        #endregion

        #region Ciudad
        public List<string> SelectCiudadCliente(long lEstado)
        {  
            var ciudades = (from a in _context.Pais
                            join b in _context.Estado on a.ID equals b.Pais
                            join c in _context.Cliente on b.ID equals c.Estado
                            orderby c.Ciudad
                            where c.Estado == lEstado
                            select c.Ciudad).ToList();            
            ciudades = ciudades.GroupBy(c => c).Select(g => g.First()).ToList();
            return ciudades;
        }
        public List<string> SelectCiudadEmpleado(long lEstado)
        {
            var ciudades = (from a in _context.Pais                            
                            join b in _context.Estado on a.ID equals b.Pais
                            join c in _context.Empleado on b.ID equals c.Estado
                            orderby c.Ciudad
                            where c.Estado == lEstado
                            select c.Ciudad).ToList();
            ciudades = ciudades.GroupBy(c => c).Select(g => g.First()).ToList();
            return ciudades;
        }
        public List<string> SelectCiudadProveedor(long lEstado)
        {
            
            var ciudades = (from a in _context.Pais
                            join b in _context.Estado on a.ID equals b.Pais
                            join c in _context.Proveedor on b.ID equals c.Estado
                            orderby c.Ciudad
                            where c.Estado == lEstado
                            select c.Ciudad).ToList();
            ciudades = ciudades.GroupBy(c => c).Select(g => g.First()).ToList();
            return ciudades;
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
        public List<Marcas> SelectMarca(Marcas mar)
        {
            if (!String.IsNullOrWhiteSpace(mar.Nombre))
            {
                return BuscarMarca(mar.Nombre);
            }
            return BuscarMarca();
        }
        public List<Marcas> BuscarMarcaID(long ID)
        {
            var marcas = (from a in _context.Marca
                          where a.ID == ID
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
        // Buscar por Nombre
        public List<Marcas> BuscarMarca()
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
        public List<Marcas> BuscarMarca(String Nombre)
        {
            var marcas = (from a in _context.Marca
                          where a.Nombre.ToUpper().Contains(Nombre.ToUpper())
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
        public List<Modelos> SelectModelo(Modelos mod)
        {
            if (!String.IsNullOrWhiteSpace(mod.Nombre))
            {
                if (mod.Marca > 0)
                {
                    return BuscarModelo(mod.Nombre, mod.Marca);
                }
                return BuscarModelo(mod.Nombre);
            }
            else if (mod.Marca > 0)
            {
                return BuscarModelo(mod.Marca);
            }
            else
            {
                return BuscarModelo();
            }
        }
        public List<Modelos> BuscarModeloID(long ID)
        {
            var modelos = (from a in _context.Modelo
                           where a.ID == ID
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
        //Buscar por Nombre y Marca
        public List<Modelos> BuscarModelo()
        {
            var modelos = (from a in _context.Modelo
                           join b in _context.Marca on a.Marca equals b.ID
                           select new Modelos
                           {
                               ID = a.ID,
                               Nombre = a.Nombre,
                               Marca = a.Marca,
                               MarcaNombre = b.Nombre,
                               UsuarioAlta = a.UsuarioAlta,
                               UsuarioMod = a.UsuarioMod,
                               FechaAlta = a.FechaAlta,
                               FechaMod = a.FechaMod
                           }).ToList();
            return modelos;
        }
        public List<Modelos> BuscarModelo(String Nombre)
        {
            var modelos = (from a in _context.Modelo
                           join b in _context.Marca on a.Marca equals b.ID
                           where a.Nombre.ToUpper().Contains(Nombre.ToUpper())
                           select new Modelos
                           {
                               ID = a.ID,
                               Nombre = a.Nombre,
                               Marca = a.Marca,
                               MarcaNombre = b.Nombre,
                               UsuarioAlta = a.UsuarioAlta,
                               UsuarioMod = a.UsuarioMod,
                               FechaAlta = a.FechaAlta,
                               FechaMod = a.FechaMod
                           }).ToList();
            return modelos;
        }
        public List<Modelos> BuscarModelo(long? Marca)
        {
            var modelos = (from a in _context.Modelo
                           join b in _context.Marca on a.Marca equals b.ID
                           where a.Marca == Marca
                           select new Modelos
                           {
                               ID = a.ID,
                               Nombre = a.Nombre,
                               Marca = a.Marca,
                               MarcaNombre = b.Nombre,
                               UsuarioAlta = a.UsuarioAlta,
                               UsuarioMod = a.UsuarioMod,
                               FechaAlta = a.FechaAlta,
                               FechaMod = a.FechaMod
                           }).ToList();
            return modelos;
        }
        public List<Modelos> BuscarModelo(String Nombre, long? Marca)
        {
            var modelos = (from a in _context.Modelo
                           join b in _context.Marca on a.Marca equals b.ID
                           where a.Nombre.ToUpper().Contains(Nombre.ToUpper()) && a.Marca == Marca
                           select new Modelos
                           {
                               ID = a.ID,
                               Nombre = a.Nombre,
                               Marca = a.Marca,
                               MarcaNombre = b.Nombre,
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
        public List<Colores> SelectColor(Colores col)
        {
            if(!String.IsNullOrWhiteSpace(col.Nombre))
            {
                return BuscarColor(col.Nombre);
            }
            return BuscarColor();
        }
        public List<Colores> BuscarColorID(long ID)
        {
            var colores = (from a in _context.Color
                           where a.ID == ID
                           select new Colores
                           {
                               ID = a.ID,
                               Nombre = a.Nombre
                           }).ToList();
            return colores;
        }
        //Buscar Colores por Nombre
        public List<Colores> BuscarColor()
        {
            var colores = (from a in _context.Color
                           select new Colores
                           {
                               ID = a.ID,
                               Nombre = a.Nombre
                           }).ToList();
            return colores;
        }
        public List<Colores> BuscarColor(String Nombre)
        {
            var colores = (from a in _context.Color
                           where a.Nombre.ToUpper().Contains(Nombre.ToUpper())
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
        public List<TipoProductos> SelectTipoProducto(TipoProductos tip)
        {
            if (!String.IsNullOrWhiteSpace(tip.Nombre))
            {
                return BuscarTipoProducto(tip.Nombre);
            }
            return BuscarTipoProducto();
        }
        public List<TipoProductos> BuscarTipoProductoID(long ID)
        {
            var tipos = (from a in _context.TipoProducto
                         where a.ID == ID
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
        //Buscar Tipo de Producto por Nombre
        public List<TipoProductos> BuscarTipoProducto()
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
        public List<TipoProductos> BuscarTipoProducto(String Nombre)
        {
            var tipos = (from a in _context.TipoProducto
                         where a.Nombre.ToUpper().Contains(Nombre.ToUpper())
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
        public List<Empleados> SelectEmpleado(Empleados emp)
        {
            var empleados = (from a in _context.Empleado
                             join b in _context.Estado on a.Estado equals b.ID
                             select new Empleados
                             {
                                 ID = a.ID,
                                 Nombre = a.Nombre,
                                 RFC = a.RFC,
                                 Apellido = a.Apellido,
                                 Apellido2 = a.Apellido2,
                                 Calle = a.Calle,
                                 NumeroInterior = a.NumeroInterior,
                                 NumeroExterior = a.NumeroExterior,
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
                                 FechaMod = a.FechaMod,
                                 Pais = b.Pais
                             }).ToList();
            empleados = empleados.Where(p => string.IsNullOrWhiteSpace(emp.Nombre) || p.Nombre.ToUpper().Contains(emp.Nombre.ToUpper())).ToList();
            empleados = empleados.Where(p => string.IsNullOrWhiteSpace(emp.Apellido) || (p.Apellido.ToUpper().Contains(emp.Apellido.ToUpper()) 
                || p.Apellido2.ToUpper().Contains(emp.Apellido.ToUpper()))).ToList();
            empleados = empleados.Where(p => string.IsNullOrWhiteSpace(emp.CURP) || p.CURP.ToUpper().Contains(emp.CURP.ToUpper())).ToList();
            empleados = empleados.Where(p => emp.Pais < 0 || p.Pais == emp.Pais).ToList();
            empleados = empleados.Where(p => emp.Estado < 0 || p.Estado == emp.Estado).ToList();
            empleados = empleados.Where(p => string.IsNullOrWhiteSpace(emp.Ciudad) || p.Ciudad.ToUpper().Contains(emp.Ciudad.ToUpper())).ToList();
            return empleados;          
        }      
        public List<Empleados> BuscarEmpleadoID(long? ID)
        {
            var empleados = (from a in _context.Empleado
                             join b in _context.Estado on a.Estado equals b.ID
                             where a.ID == ID
                             select new Empleados
                             {
                                 ID = a.ID,
                                 Nombre = a.Nombre,
                                 RFC = a.RFC,
                                 Apellido = a.Apellido,
                                 Apellido2 = a.Apellido2,
                                 Calle = a.Calle,
                                 NumeroInterior = a.NumeroInterior,
                                 NumeroExterior = a.NumeroExterior,
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
                                 FechaMod = a.FechaMod,
                                 Pais = b.Pais
                             }).ToList();
            return empleados;
        }    
        #endregion
        
        #region Tabla Vehiculo 
        // buscar por Marca, Modelo, Año, Color y Numero de Serie
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
        public List<Vehiculos> SelectVehiculos(Vehiculos veh)
        {
            var vehiculos = (from a in _context.Vehiculo
                             join b in _context.Modelo on a.Modelo equals b.ID
                             join c in _context.Marca on b.Marca equals c.ID
                           select new Vehiculos
                           {
                               ID = a.ID,
                               NoSerie = a.NoSerie,
                               Modelo = a.Modelo,
                               ModeloNombre = b.Nombre,
                               Marca = c.ID,
                               MarcaNombre = c.Nombre,
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
            vehiculos = vehiculos.Where(p => veh.Marca < 0 || p.Marca == veh.Marca).ToList();
            vehiculos = vehiculos.Where(p => veh.Modelo < 0 || p.Modelo == veh.Modelo).ToList();
            vehiculos = vehiculos.Where(p => veh.Ano < 0 || p.Ano == veh.Ano).ToList();
            vehiculos = vehiculos.Where(p => string.IsNullOrWhiteSpace(veh.Color) || p.Color.ToUpper().Contains(veh.Color.ToUpper())).ToList();
            vehiculos = vehiculos.Where(p => string.IsNullOrWhiteSpace(veh.NoSerie) || p.NoSerie.ToUpper().Contains(veh.NoSerie.ToUpper())).ToList();
            return vehiculos;
        }
        
        public List<Vehiculos> BuscarVehiculosID(long? ID)
        {
            var vehiculos = (from a in _context.Vehiculo
                             join b in _context.Modelo on a.Modelo equals b.ID
                             join c in _context.Marca on b.Marca equals c.ID

                           where a.ID == ID
                             select new Vehiculos
                             {
                                 ID = a.ID,
                                 NoSerie = a.NoSerie,
                                 Modelo = a.Modelo,
                                 ModeloNombre = b.Nombre,
                                 Marca = c.ID,
                                 MarcaNombre = c.Nombre,
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
        // Buscar Por Nombre, RFC, Pais, Estado, Ciudad
        public List<Proveedores> SelectProveedor(Proveedores pro)
        {
            var proveedores = (from a in _context.Proveedor
                               join b in _context.Estado on a.Estado equals b.ID
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
                             Pais = b.Pais,
                             UsuarioAlta = a.UsuarioAlta,
                             UsuarioMod = a.UsuarioMod,
                             FechaAlta = a.FechaAlta,
                             FechaMod = a.FechaMod
                         }).ToList();
            proveedores = proveedores.Where(p => String.IsNullOrEmpty(pro.Nombre) || p.Nombre.ToUpper().Contains(pro.Nombre.ToUpper())).ToList();
            proveedores = proveedores.Where(p => String.IsNullOrEmpty(pro.Apellido) || p.Apellido.ToUpper().Contains(pro.Apellido.ToUpper()) 
                || p.Apellido2.ToUpper().Contains(pro.Apellido.ToUpper())).ToList();
            proveedores = proveedores.Where(p => pro.Pais < 0  || p.Pais == pro.Pais).ToList();
            proveedores = proveedores.Where(p => pro.Estado < 0 || p.Estado == pro.Estado).ToList();
            proveedores = proveedores.Where(p => String.IsNullOrEmpty(pro.Ciudad) || p.Ciudad.ToUpper().Contains(pro.Ciudad.ToUpper())).ToList();
            return proveedores;
        }
        public List<Proveedores> BuscarProveedorID(long? ID)
        {
            var proveedores = (from a in _context.Proveedor
                               join b in _context.Estado on a.Estado equals b.ID
                               where a.ID == ID
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
                                   Pais = b.Pais,
                                   UsuarioAlta = a.UsuarioAlta,
                                   UsuarioMod = a.UsuarioMod,
                                   FechaAlta = a.FechaAlta,
                                   FechaMod = a.FechaMod
                               }).ToList();
            return proveedores;
        }
        #endregion
        
        #region Tabla Producto
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
                    IVA = pro.IVA,
                    PrecioCompra = pro.PrecioCompra,
                    Observaciones = pro.Observaciones,
                    IVAExcencto = pro.IVAExcento,
                    Especial = pro.Especial,
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
            
            var prodb = (from a in _context.Producto
                            where a.ID == pro.ID
                            select a).FirstOrDefault();

            prodb.Codigo = pro.Codigo;
            prodb.Descripcion = pro.Descripcion;
            prodb.PrecioVenta = pro.PrecioVenta;
            prodb.PrecioCompra = pro.PrecioCompra;
            prodb.IVA = pro.IVA;
            prodb.IVAExcencto = pro.IVAExcento;
            prodb.Observaciones = pro.Observaciones;
            prodb.Especial = pro.Especial;
            prodb.TipoProducto = pro.TipoProducto;
            prodb.Proveedor = pro.Proveedor;
            prodb.UsuarioMod = pro.UsuarioMod;
            prodb.FechaMod = DateTime.Now;

            
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
        //Filtrar productos por tipo, proveedor, codigo y descripcion
        public List<Productos> SelectProducto(Productos pro)
        {
            var productos = (from a in _context.Producto
                             join b in _context.Proveedor on a.Proveedor equals b.ID into JoinProveedor
                             join c in _context.TipoProducto on a.TipoProducto equals c.ID
                             from b in JoinProveedor.DefaultIfEmpty()
                               select new Productos
                               {
                                   ID = a.ID,
                                   Codigo = a.Codigo,
                                   Descripcion = a.Descripcion,
                                   PrecioVenta = a.PrecioVenta,
                                   PrecioCompra = a.PrecioCompra,
                                   Observaciones = a.Observaciones,
                                   IVAExcento = a.IVAExcencto,
                                   TipoProducto = a.TipoProducto,
                                   Proveedor = a.Proveedor,
                                   ProveedorNombre = b.Nombre,
                                   IVA = a.IVA,
                                   Especial = a.Especial,
                                   ProveedorApellido = b.Apellido,
                                   ProveedorApellido2 = b.Apellido2,
                                   TipoProductoNombre = c.Nombre,
                                   UsuarioAlta = a.UsuarioAlta,
                                   UsuarioMod = a.UsuarioMod,
                                   FechaAlta = a.FechaAlta,
                                   FechaMod = a.FechaMod
                               }).ToList();
            productos = productos.Where(p => pro.TipoProducto < 0 || p.TipoProducto == pro.TipoProducto ).ToList();
            productos = productos.Where(p => pro.Proveedor < 0 || p.Proveedor == pro.Proveedor).ToList();
            productos = productos.Where(p => string.IsNullOrWhiteSpace(pro.Codigo) || p.Codigo.ToUpper().Contains(pro.Codigo.ToUpper())).ToList();
            productos = productos.Where(p => string.IsNullOrWhiteSpace(pro.Descripcion) || p.Descripcion.ToUpper().Contains(pro.Descripcion.ToUpper())).ToList();
            return productos;
        }
        public List<Productos> BuscarProductoID(long? ID)
        {
            var productos = (from a in _context.Producto
                             join b in _context.Proveedor on a.Proveedor equals b.ID into JoinProveedor
                             join c in _context.TipoProducto on a.TipoProducto equals c.ID
                             from b in JoinProveedor.DefaultIfEmpty()
                             where a.ID == ID
                             select new Productos
                             {
                                 ID = a.ID,
                                 Codigo = a.Codigo,
                                 Descripcion = a.Descripcion,
                                 PrecioVenta = a.PrecioVenta,
                                 PrecioCompra = a.PrecioCompra,
                                 Observaciones = a.Observaciones,
                                 Especial = a.Especial,
                                 IVA = a.IVA,
                                 IVAExcento = a.IVAExcencto,
                                 TipoProducto = a.TipoProducto,
                                 Proveedor = a.Proveedor,
                                 ProveedorNombre = b.Nombre + " " + b.Apellido + " " + b.Apellido2,
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
        public List<GrupoClientes> SelectGrupoCliente(GrupoClientes gcl)
        {
            if (!String.IsNullOrWhiteSpace(gcl.Nombre))
            {
                return BuscarGrupoCliente(gcl.Nombre);
            }
            return BuscarGrupoCliente();
        }
        public List<GrupoClientes> BuscarGrupoClienteID(long ID)
        {
            var grupos = (from a in _context.GrupoCliente
                          where a.ID == ID
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
        //Buscar por nombre
        public List<GrupoClientes> BuscarGrupoCliente()
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
        public List<GrupoClientes> BuscarGrupoCliente(String Nombre)
        {
            var grupos = (from a in _context.GrupoCliente
                          where a.Nombre.ToUpper().Contains(Nombre.ToUpper())
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
                            select a.Nombre).FirstOrDefault();
            if (string.IsNullOrEmpty(clidb))
            {
                Cliente cliNew = new Cliente()
                {
                    Tipo = cli.Tipo,
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
            
            var clidb = (from a in _context.Cliente
                            where a.ID == cli.ID
                            select a).FirstOrDefault();
            cli.Tipo = cli.Tipo;
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
        // Buscar por Nombre, RFC , Tipo, Pais, Estado, Ciudad
        public List<Clientes> SelectCliente(Clientes cli)
        {
            var clientes = (from a in _context.Cliente
                            join b in _context.GrupoCliente on a.GrupoCliente equals b.ID into JoinGrupoCliente
                            join c in _context.Estado on a.Estado equals c.ID
                            from b in JoinGrupoCliente.DefaultIfEmpty()
                            select new Clientes
                          {
                              ID = a.ID,
                              Tipo = a.Tipo,
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
                              Pais = c.Pais,
                              GrupoCliente = a.GrupoCliente,
                              GrupoClienteNombre = b.Nombre,
                              UsuarioAlta = a.UsuarioAlta,
                              UsuarioMod = a.UsuarioMod,
                              FechaAlta = a.FechaAlta,
                              FechaMod = a.FechaMod
                          }).ToList();
            clientes = clientes.Where(p => string.IsNullOrWhiteSpace(cli.Nombre) || p.Nombre.ToUpper().Contains(cli.Nombre.ToUpper()) ).ToList();
            clientes = clientes.Where(p => string.IsNullOrWhiteSpace(cli.RFC) || p.RFC.ToUpper().Contains(cli.RFC.ToUpper())).ToList();
            clientes = clientes.Where(p => cli.GrupoCliente < 0 || p.GrupoCliente == cli.GrupoCliente).ToList();
            clientes = clientes.Where(p => cli.Pais < 0 || p.Pais == cli.Pais).ToList();
            clientes = clientes.Where(p => cli.Estado < 0 || p.Estado == cli.Estado).ToList();
            clientes = clientes.Where(p => string.IsNullOrWhiteSpace(cli.Ciudad) || p.Ciudad.ToUpper().Contains(cli.Ciudad.ToUpper())).ToList();
            return clientes;
        }
        public List<Clientes> BuscarClienteID(long? ID)
        {
            var clientes = (from a in _context.Cliente
                            join b in _context.GrupoCliente on a.GrupoCliente equals b.ID into JoinGrupoCliente
                            join c in _context.Estado on a.Estado equals c.ID
                            from b in JoinGrupoCliente.DefaultIfEmpty()
                            where a.ID == ID
                            select new Clientes
                            {
                                ID = a.ID,
                                Tipo = a.Tipo,
                                Nombre = a.Nombre,
                                Apellido = a.Apellido,
                                Apellido2 = a.Apellido2,
                                RFC = a.RFC,
                                Calle = a.Calle,
                                NumeroExterior = a.NumeroExterior,
                                NumeroInterior = a.NumeroInterior,
                                Colonia = a.Colonia,
                                CP = a.CP,
                                Localidad = a.Localidad,
                                Ciudad = a.Ciudad,
                                Telefono = a.Telefono,
                                Email = a.Email,
                                Estado = a.Estado,
                                Pais = c.Pais,
                                GrupoCliente = a.GrupoCliente,
                                GrupoClienteNombre = b.Nombre,
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
            Paquete paqNew;
            string paqdb = (from a in _context.Paquete
                            where a.Nombre.ToUpper() == paq.Nombre.ToUpper()
                            select a.Nombre).FirstOrDefault();
            if (string.IsNullOrEmpty(paqdb))
            {
                paqNew = new Paquete()
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
                resultado.IdGuardado = _context.SaveChanges();
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
            resultado.IdGuardado = paqNew.ID;
            return resultado;
        }
        public Resultado UpdatePaquete(Paquetes paq)
        {
            Resultado resultado = new Resultado();
            
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
        //Buscar por Nombre/Descripcion activo y grupoCliente
        public List<Paquetes> SelectPaquete(Paquetes paq)
        {
            var paquetes = (from a in _context.Paquete where a.Activo == true
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
            foreach(Paquetes p in paquetes)
            {
                if ((p.FechaFin != null && p.FechaFin < DateTime.Now) && (p.FechaInicio != null && p.FechaInicio > DateTime.Now))
                {
                    p.Activo = false;
                }
            }
            paquetes = paquetes.Where(p => string.IsNullOrWhiteSpace(paq.Nombre) || p.Nombre.ToUpper().Contains(paq.Nombre.ToUpper())
                || p.Descripcion.ToUpper().Contains(paq.Nombre.ToUpper()) ).ToList();
            paquetes = paquetes.Where(p => paq.Activo == null || p.Activo == paq.Activo).ToList();
            paquetes = paquetes.Where(p => paq.ParaGrupoCliente == null || p.ParaGrupoCliente == paq.ParaGrupoCliente).ToList();

            return paquetes;
        }
        public List<Paquetes> BuscarPaqueteID(long? ID)
        {
            var paquetes = (from a in _context.Paquete
                            where a.ID == ID
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
        public List<PaqueteDias> BuscarPaqueteDiaID(long? ID)
        {
            var paquetes = (from a in _context.PaqueteDia
                            where a.Paquete == ID
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
        public List<PaqueteGrupoClientes> BuscarPaqueteGrupoClienteID(long? ID)
        {
            var paquetes = (from a in _context.PaqueteGrupoCliente
                            where a.Paquete == ID
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
        public List<PaqueteProductos> BuscarPaqueteProductoID(long? ID)
        {
            var paquetes = (from a in _context.PaqueteProducto
                            where a.Paquete == ID
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
            Promocion proNew;
            string prodb = (from a in _context.Promocion
                            where a.Nombre.ToUpper() == pro.Nombre.ToUpper()
                            select a.Nombre).FirstOrDefault();
            if (string.IsNullOrEmpty(prodb))
            {
                proNew = new Promocion()
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
            resultado.IdGuardado = proNew.ID;
            return resultado;
        }
        public Resultado UpdatePromocion(Promociones pro)
        {
            Resultado resultado = new Resultado();
            
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
        //Buscar por Tipo, Nombre, Activa, GrupoCliente, Tipo Producto,Producto, Paquete
        public List<Promociones> SelectPromocion(Promociones pro)
        {
            var promociones = (from a in _context.Promocion where a.Activo == true
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
            foreach (Promociones p in promociones)
            {
                if ((p.FechaFin != null && p.FechaFin < DateTime.Now)&&(p.FechaInicio != null && p.FechaInicio > DateTime.Now))
                {
                    p.Activo = false;
                }
            }
            promociones = promociones.Where(p => pro.Tipo < 0 || p.Tipo == pro.Tipo ).ToList();
            promociones = promociones.Where(p => string.IsNullOrWhiteSpace(pro.Nombre) || p.Nombre.ToUpper().Contains(pro.Nombre.ToUpper())
                ||p.Descripcion.ToUpper().Contains(pro.Nombre.ToUpper())).ToList();
            promociones = promociones.Where(p => pro.Activo == null || p.Activo == pro.Activo).ToList();
            promociones = promociones.Where(p => pro.ParaGrupoCliente == null || p.ParaGrupoCliente == pro.ParaGrupoCliente).ToList();
            promociones = promociones.Where(p => pro.ParaTipoProducto == null || p.ParaTipoProducto == pro.ParaTipoProducto).ToList();
            promociones = promociones.Where(p => pro.ParaProducto == null || p.ParaProducto == pro.ParaProducto).ToList();
            promociones = promociones.Where(p => pro.ParaPaquete == null || p.ParaPaquete == pro.ParaPaquete).ToList();
            return promociones;
        }
        public List<Promociones> BuscarPromocionID(long? ID)
        {
            var promociones = (from a in _context.Promocion
                               where a.ID == ID
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
        public List<PromocionDias> BuscarPromocionDiaID(long? ID)
        {
            var promocion = (from a in _context.PromocionDia
                             where a.Promocion == ID
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
        public List<PromocionPaquetes> BuscarPromocionPaqueteID(long? ID)
        {
            var promos = (from a in _context.PromocionPaquete
                          where a.Promocion == ID
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
        public List<PromocionTipoProductos> BuscarPromocionTipoProductoID(long? ID)
        {
            var promos = (from a in _context.PromocionTipoProducto
                          where a.Promocion == ID
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
        public List<PromocionProductos> BuscarPromocionProductoID(long? ID)
        {
            var promos = (from a in _context.PromocionProducto
                          where a.Promocion == ID
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
        public List<PromocionGrupoClientes> BuscarPromocionGrupoClienteID(long? ID)
        {
            var promos = (from a in _context.PromocionTipoCliente
                          where a.Promocion == ID
                          select new PromocionGrupoClientes
                          {
                              ID = a.ID,
                              Promocion = a.Promocion,
                              GrupoCliente = a.GrupoCliente
                          }).ToList();
            return promos;
        }
        #endregion

        #region Tabla Venta
        public Resultado InsertVenta(Ventas ven, List<VentaDetalles> venDet)
        {
            long? IDVenta;
            Resultado resultado = new Resultado();

            Venta venNew = new Venta()
            {
                Total = ven.Total,
                Fecha = ven.Fecha,
                Cliente = ven.Cliente,
                UsuarioVenta = ven.UsuarioVenta
            };
            _context.Venta.Add(venNew);
            try
            {
                _context.SaveChanges();
                IDVenta = venNew.ID;
                foreach (VentaDetalles vd in venDet)
                {
                    VentaDetalle vedNew = new VentaDetalle()
                    {
                        Subtotal = vd.Subtotal,
                        Descripcion = vd.Descripcion,
                        Color = vd.Color,
                        Venta = IDVenta,
                        Producto = vd.Producto,
                        Vehiculo = vd.Vehiculo,
                        Paquete = vd.Paquete,
                        Promocion = vd.Promocion
                    };
                    _context.VentaDetalle.Add(vedNew);
                }

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
        public Resultado DeleteVenta(Ventas ven)
        {
            Resultado resultado = new Resultado();
            var venDelete = (from a in _context.Venta
                             where a.ID == ven.ID
                             select a).FirstOrDefault();
            _context.Venta.Remove(venDelete);
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
        public List<Ventas> SelectVenta()
        {
            var ventas = (from a in _context.Venta
                          select new Ventas
                          {
                              ID = a.ID,
                              Total = a.Total,
                              Fecha = a.Fecha,
                              Cliente = a.Cliente,
                              UsuarioVenta = a.UsuarioVenta
                          }).ToList();
            return ventas;
        }
        #endregion

        #region Tabla Venta Detalle
        public Resultado InsertVentaDetalle(VentaDetalles ved)
        {
            Resultado resultado = new Resultado();

            VentaDetalle vedNew = new VentaDetalle()
            {
                Subtotal = ved.Subtotal,
                Descripcion = ved.Descripcion,
                Color = ved.Color,
                Venta = ved.Venta,
                Producto = ved.Producto,
                Vehiculo = ved.Vehiculo,
                Paquete = ved.Paquete,
                Promocion = ved.Promocion
            };
            _context.VentaDetalle.Add(vedNew);
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
        public Resultado DeleteVentaDetalle(VentaDetalles ved)
        {
            Resultado resultado = new Resultado();
            var vedDelete = (from a in _context.VentaDetalle
                             where a.ID == ved.ID
                             select a).FirstOrDefault();
            _context.VentaDetalle.Remove(vedDelete);
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
        public List<VentaDetalles> SelectVentaDetalle(long? ID)
        {
            var venta = (from a in _context.VentaDetalle
                         where a.Venta == ID
                          select new VentaDetalles
                          {
                              ID = a.ID,
                              Subtotal = a.Subtotal,
                              Descripcion = a.Descripcion,
                              Color = a.Color,
                              Venta = a.Venta,
                              Producto = a.Producto,
                              Vehiculo = a.Vehiculo,
                              Paquete = a.Paquete,
                              Promocion = a.Promocion
                          }).ToList();
            return venta;
        }
        #endregion

        #region Tabla Venta Dia
        public Resultado InsertVentaDia(VentaDias ved)
        {
            Resultado resultado = new Resultado();

            VentaDia vedNew = new VentaDia()
            {
                Fecha = ved.Fecha,
                Total = ved.Total
            };
            _context.VentaDia.Add(vedNew);
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
        public Resultado DeleteVentaDia(VentaDias ved)
        {
            Resultado resultado = new Resultado();
            var vedDelete = (from a in _context.VentaDia
                             where a.ID == ved.ID
                             select a).FirstOrDefault();
            _context.VentaDia.Remove(vedDelete);
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
        public List<VentaDias> SelectVentaDia()
        {
            var venta = (from a in _context.VentaDia
                         select new VentaDias
                         {
                             ID = a.ID,
                             Fecha = a.Fecha,
                             Total = a.Total
                         }).ToList();
            return venta;
        }
        #endregion

        #region Tabla Logs
        public Resultado InsertLog(Log log)
        {
            Resultado resultado = new Resultado();

            Logs logNew = new Logs()
            {
                Fecha = log.Fecha,
                Descripcion = log.Descripcion,
                Usuario = log.Usuario
            };
            _context.Logs.Add(logNew);
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
        public List<Log> SelectLog()
        {
            var logs = (from a in _context.Logs
                         select new Log
                         {
                             ID = a.ID,
                             Fecha = a.Fecha,
                             Descripcion = a.Descripcion,
                             Usuario = a.Usuario
                         }).ToList();
            return logs;
        }
        #endregion
    }
}
