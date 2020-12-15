using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abastecedor_Estrella
{
    class Comm
    {
        //public static bool autorizado;
        public static int userid;

        //SQL connection String
        public static SqlConnection RetornaAcceso()
        {
            SqlConnection conecta = new SqlConnection();
            conecta.ConnectionString = "Data Source=grupodbserver.database.windows.net; Initial Catalog = 'grupodb' ;" +
                                       " User Id = admin2020; Password = Ulacit123!";
            return conecta;
        }

        //SQL queries [register user]

        //Metodo para la validacion de las credenciales (almacenados en la base de datos)
        public static Boolean claveValida(String Usr, String Pwd)
        {
            Boolean Res;
            SqlConnection Conn = RetornaAcceso(); //Se iguala la variable 'Conn' al la conexion que retorna el metodo RetornaAcceso()
            SqlCommand Query = new SqlCommand("SELECT COUNT(ID_PERSONA) as DATA FROM PERSONA WHERE ID_PERSONA=@Usr AND CONTRASENA=@Pass");
            Query.Parameters.AddWithValue("Usr", Usr);
            Query.Parameters.AddWithValue("Pass", Pwd);
            Query.Connection = Conn;
            SqlDataAdapter QueryAdapter = new SqlDataAdapter(Query);
            DataSet QueryRes = new DataSet();
            Conn.Open();
            QueryAdapter.Fill(QueryRes);
            Res = QueryRes.Tables[0].Rows[0]["DATA"].ToString().Equals("1");
            QueryRes.Dispose();
            Conn.Close();
            return Res;
        }

        //Metodo para registrar nuevas personas a la base de datos popr medio de querys INSERT
        public static void RegistrarPersona(int IdPersona, String Nombre, String PApellido, String SApellido, String Telefono, String Contrasena)
        {
            SqlConnection Conn = RetornaAcceso();
            using (SqlCommand Query = new SqlCommand("INSERT INTO PERSONA(ID_PERSONA, NOMBRE, PRIMER_APELLIDO, SEGUNDO_APELLIDO, TELEFONO, CONTRASENA) " +
                "VALUES (@IdPersona, @Nombre, @PApellido, @SApellido, @Telefono, @Contrasena)"))
            {
                Query.Parameters.AddWithValue("IdPersona", IdPersona);
                Query.Parameters.AddWithValue("Nombre", Nombre);
                Query.Parameters.AddWithValue("PApellido", PApellido);
                Query.Parameters.AddWithValue("SApellido", SApellido);
                Query.Parameters.AddWithValue("Telefono", Telefono);
                Query.Parameters.AddWithValue("Contrasena", Contrasena);
                Query.Connection = Conn;
                Conn.Open();
                Query.ExecuteNonQuery();
                Conn.Close();
            }
        }

        //Metodo para registrar un cliente en la base de datos
        public static void RegistrarCliente(int ID, String Correo, int Edad, int IDTarjeta, int IDDireccion)
        {
            SqlConnection Conn = RetornaAcceso();
            String Insert;
            if (IDTarjeta == -1)
            {
                Insert = "INSERT INTO Cliente(ID_Persona_Cliente, Correo, Edad, ID_Direccion_Cliente)" +
                "VALUES(@ID, @Correo, @Edad, @Direccion)";
            }
            else
            {
                Insert = "INSERT INTO Cliente(ID_Persona_Cliente, Correo, Edad, ID_Credito_Cliente, ID_Direccion_Cliente)" +
                "VALUES(@ID, @Correo, @Edad, @Tarjeta, @Direccion)";
            }    
            SqlCommand Query = new SqlCommand(Insert, Conn);
            Conn.Open();
            Query.Parameters.AddWithValue("@ID", ID);
            Query.Parameters.AddWithValue("@Correo", Correo);
            Query.Parameters.AddWithValue("@Edad", Edad);
            if(IDTarjeta != -1)
                Query.Parameters.AddWithValue("@Tarjeta", IDTarjeta);
            Query.Parameters.AddWithValue("@Direccion", IDDireccion);
            Query.ExecuteNonQuery();
            Conn.Close();
        }

        //Metodo para registrar direcciones
        public static int RegistrarDireccion(String Linea1, String Linea2, int IDGeo)
        {
            SqlConnection Conn = RetornaAcceso();
            SqlCommand ConsecSelect = new SqlCommand("SELECT COUNT(1) FROM Direccion", Conn);
            SqlCommand DireccionInsert = new SqlCommand("INSERT INTO Direccion(ID_Direccion, Linea1, Linea2, ID_Geografia_Direccion)" +
                " VALUES(@ID, @Lin1, @Lin2, @IDGeo)", Conn);
            Conn.Open();
            int ConsecDir = (int) ConsecSelect.ExecuteScalar();
            ConsecDir++;
            DireccionInsert.Parameters.AddWithValue("@ID", ConsecDir);
            DireccionInsert.Parameters.AddWithValue("@Lin1", Linea1);
            DireccionInsert.Parameters.AddWithValue("@Lin2", Linea2);
            DireccionInsert.Parameters.AddWithValue("@IDGeo", IDGeo);
            DireccionInsert.ExecuteNonQuery();
            Conn.Close();
            return ConsecDir;
        }

        public static int RegistrarTarjeta(String NumTarjeta, DateTime FecVencimiento, int Codigo, String Proveedor)
        {
            SqlConnection Conn = RetornaAcceso();
            SqlCommand ConsecSelect = new SqlCommand("SELECT COUNT(1) FROM Credito", Conn);
            SqlCommand TarjetaInsert = new SqlCommand("INSERT INTO Credito(ID_Credito, Numero_Tarjeta, Fecha_Vencimiento, Codigo, Proveedor)" +
                "VALUES(@IdTarjeta, @NumTarjeta, @FecVencimiento, @Codigo, @Proveedor)", Conn);
            Conn.Open();
            int Consec = (int) ConsecSelect.ExecuteScalar();
            Consec++;
            TarjetaInsert.Parameters.AddWithValue("@IdTarjeta", Consec);
            TarjetaInsert.Parameters.AddWithValue("@NumTarjeta", NumTarjeta);
            TarjetaInsert.Parameters.AddWithValue("@FecVencimiento", FecVencimiento);
            TarjetaInsert.Parameters.AddWithValue("@Codigo", Codigo);
            TarjetaInsert.Parameters.AddWithValue("@Proveedor", Proveedor);
            TarjetaInsert.ExecuteNonQuery();
            Conn.Close();
            return Consec;
        }

        public static void RegistrarMensajero(int IdPersona)
        {
            SqlConnection Conn = RetornaAcceso();
            using (SqlCommand Query = new SqlCommand("INSERT INTO MENSAJERO(ID_PERSONA_MENSAJERO, ESTADO_MENSAJERO) " +
                "VALUES (@IdPersona, 'Pendiente')"))
            {
                Query.Parameters.AddWithValue("IdPersona", IdPersona);
                Query.Connection = Conn;
                Conn.Open();
                Query.ExecuteNonQuery();
                Conn.Close();
            }
        }

        public static Boolean EsCliente(String Usr)
        {
            Boolean Res;
            SqlConnection Conn = RetornaAcceso();
            SqlCommand Query = new SqlCommand("SELECT COUNT(ID_PERSONA_CLIENTE) as DATA FROM CLIENTE WHERE ID_PERSONA_CLIENTE=@Usr");
            Query.Parameters.AddWithValue("Usr", Usr);
            Query.Connection = Conn;
            SqlDataAdapter QueryAdapter = new SqlDataAdapter(Query);
            DataSet QueryRes = new DataSet();
            Conn.Open();
            QueryAdapter.Fill(QueryRes);
            Res = QueryRes.Tables[0].Rows[0]["DATA"].ToString().Equals("1");
            QueryRes.Dispose();
            Conn.Close();
            return Res;
        }

        public static String GetNombre(int userName)
        {
            SqlConnection conx = new SqlConnection();
            conx = RetornaAcceso();
            String Nombre;
            SqlCommand da = new SqlCommand("SELECT NOMBRE AS DATA FROM PERSONA " +
                "where ID_Persona = '" + userName + "' ", conx);
            conx.Open();
            Nombre = (String)da.ExecuteScalar();
            conx.Close();
            return Nombre;
        }

        public static DataSet GetInfoCliente(int IDCliente)
        {
            SqlConnection conx = new SqlConnection();
            conx = RetornaAcceso();
            SqlCommand Cmd = new SqlCommand("SELECT Nombre, Primer_Apellido, Segundo_Apellido, Telefono, Correo, Edad, " +
            "GeoDist.Descripcion_Geografica Distrito, GeoCant.Descripcion_Geografica Canton, GeoProv.Descripcion_Geografica Provincia, " +
            "Descripcion_Pais FROM Persona " +
            "INNER JOIN Cliente ON Cliente.ID_Persona_Cliente = Persona.ID_Persona " +
            "INNER JOIN Direccion ON Direccion.ID_Direccion = Cliente.ID_Direccion_Cliente " +
            "INNER JOIN Geografia GeoDist ON GeoDist.ID_Geografia = Direccion.ID_Geografia_Direccion " +
            "INNER JOIN Geografia GeoCant ON GeoCant.ID_Geografia = GeoDist.ID_Geografia_FK " +
            "INNER JOIN Geografia GeoProv ON GeoProv.ID_Geografia = GeoCant.ID_Geografia_FK " +
            "INNER JOIN Pais ON GeoProv.ID_Pais = Pais.ID_Pais " +
            "WHERE ID_Persona = @Cliente", conx);
            SqlDataAdapter Adapter = new SqlDataAdapter(Cmd);
            DataSet Datos = new DataSet();
            Cmd.Parameters.AddWithValue("@Cliente", IDCliente);
            conx.Open();
            Adapter.Fill(Datos);
            conx.Close();
            return Datos;
        }

        public static void ActualizaCliente(int IDCliente, String Correo, String Telefono, int Edad, int IDGeo)
        {
            SqlConnection Conx = RetornaAcceso();
            SqlCommand SelectDireccion = new SqlCommand("SELECT ID_Direccion_Cliente FROM Cliente WHERE ID_Persona_Cliente = @Cliente", Conx);
            SqlCommand UpdateCliente = new SqlCommand("UPDATE Cliente SET Correo = @Correo, Edad = @Edad " +
                "WHERE ID_Persona_Cliente = @Cliente", Conx);
            SqlCommand UpdatePersona = new SqlCommand("UPDATE Persona SET Telefono = @Telefono WHERE ID_Persona = @Cliente", Conx);
            SqlCommand UpdateDireccion = new SqlCommand("UPDATE Direccion SET ID_Geografia_Direccion = @Geo WHERE ID_Direccion = @Direccion", Conx);
            int IDDireccion = 0;
            SelectDireccion.Parameters.AddWithValue("@Cliente", IDCliente);
            UpdateCliente.Parameters.AddWithValue("@Cliente", IDCliente);
            UpdateCliente.Parameters.AddWithValue("@Correo", Correo);
            UpdateCliente.Parameters.AddWithValue("@Edad", Edad);
            UpdatePersona.Parameters.AddWithValue("@Cliente", IDCliente);
            UpdatePersona.Parameters.AddWithValue("@Telefono", Telefono);
            Conx.Open();
            IDDireccion = (int) SelectDireccion.ExecuteScalar();
            UpdateDireccion.Parameters.AddWithValue("@Direccion", IDDireccion);
            UpdateDireccion.Parameters.AddWithValue("@Geo", IDGeo);
            UpdateCliente.ExecuteNonQuery();
            UpdatePersona.ExecuteNonQuery();
            UpdateDireccion.ExecuteNonQuery();
            Conx.Close();
        }

        public static void AsignarTarjeta(int IDCliente, int IDTarjeta)
        {
            SqlConnection Conx = RetornaAcceso();
            SqlCommand AsignaTarjeta = new SqlCommand("UPDATE Cliente SET ID_Credito_Cliente = @Tarjeta WHERE ID_Persona_Cliente = @Cliente", Conx);
            AsignaTarjeta.Parameters.AddWithValue("@Cliente", IDCliente);
            AsignaTarjeta.Parameters.AddWithValue("@Tarjeta", IDTarjeta);
            Conx.Open();
            AsignaTarjeta.ExecuteNonQuery();
            Conx.Close();
        }

        public static void ActualizarTarjeta(int IDTarjeta, String NumTarjeta, DateTime FecVencimiento, int Codigo, String Proveedor)
        {
            SqlConnection Conx = RetornaAcceso();
            SqlCommand AsignaTarjeta = new SqlCommand("UPDATE Credito SET " +
            "Numero_Tarjeta = @NumTarjeta, Fecha_Vencimiento = @FecVencimiento, Codigo = @Codigo, Proveedor = @Proveedor " + 
            "WHERE ID_Credito = @Tarjeta", Conx);
            AsignaTarjeta.Parameters.AddWithValue("@Tarjeta", IDTarjeta);
            AsignaTarjeta.Parameters.AddWithValue("@NumTarjeta", NumTarjeta);
            AsignaTarjeta.Parameters.AddWithValue("@FecVencimiento", FecVencimiento);
            AsignaTarjeta.Parameters.AddWithValue("@Codigo", Codigo);
            AsignaTarjeta.Parameters.AddWithValue("@Proveedor", Proveedor);
            Conx.Open();
            AsignaTarjeta.ExecuteNonQuery();
            Conx.Close();
        }
        //-----------------------------------------------

        public static int GetIDMetodoPago(int userID)
        {
            SqlConnection conx = new SqlConnection();
            conx = RetornaAcceso();
            int IDMetodo;
            SqlCommand Cmd = new SqlCommand("SELECT ID_CREDITO_CLIENTE FROM CLIENTE where ID_Persona_Cliente = @ClienteID", conx);
            Cmd.Parameters.AddWithValue("@ClienteID", userID);
            conx.Open();
            var Result = Cmd.ExecuteScalar();
            IDMetodo = (Result != null && Result.ToString() != "") ? (int) Result : -1;
            conx.Close();
            return IDMetodo;
        }

        public static DataSet GetInfoTarjeta(int IDTarjeta)
        {
            SqlConnection conx = new SqlConnection();
            conx = RetornaAcceso();
            SqlCommand Cmd = new SqlCommand("SELECT * FROM Credito where ID_Credito = @IDTarjeta", conx);
            Cmd.Parameters.AddWithValue("@IDTarjeta", IDTarjeta);
            SqlDataAdapter Adapter = new SqlDataAdapter(Cmd);
            conx.Open();
            DataSet InfoTarjeta = new DataSet();
            Adapter.Fill(InfoTarjeta);
            return InfoTarjeta;
        }

        //SQL queries [location]

        public static String IngresarPais(int idPais1, String Descripcion)
        {
            if (idPais1 >= 1 && Descripcion != "")
            {
                SqlConnection conx = new SqlConnection();
                conx = RetornaAcceso();
                using (SqlCommand cmd = new SqlCommand("insert into Pais(ID_Pais,Descripcion_Pais) values(@idPais,@DescripcionPais)", conx))
                    try
                    {
                        cmd.Parameters.AddWithValue("@IdPais", idPais1);
                        cmd.Parameters.AddWithValue("@DescripcionPais", Descripcion);
                        cmd.Connection = conx;
                        conx.Open();
                        cmd.ExecuteNonQuery();
                        conx.Close();
                        return "Dato creado";
                    }
                    catch
                    {
                        return ("Este valor de ID ya existe en Pais!");
                    }
            }
            else
            {
                return "Datos no detectados, por favor ingresar";
            }
        }

        public static DataSet GetDataPais()
        {
            SqlConnection conx = new SqlConnection();
            conx = RetornaAcceso();
            conx.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Pais", conx);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conx.Close();
            return ds;
        }

        public static String ModificarPais(String idPais1, String Descripcion)
        {
            if (idPais1 != "" && Descripcion != "")
            {
                SqlConnection conx = new SqlConnection();
                conx = RetornaAcceso();
                using (SqlCommand cmd = new SqlCommand("update Pais set Descripcion_Pais=@DescripcionPais,ID_Pais=@IdPais where ID_Pais=@IdPais OR Descripcion_Pais=@DescripcionPais", conx))
                    try
                    {
                        cmd.Parameters.AddWithValue("@IdPais", idPais1);
                        cmd.Parameters.AddWithValue("@DescripcionPais", Descripcion);
                        cmd.Connection = conx;
                        conx.Open();
                        cmd.ExecuteNonQuery();
                        conx.Close();
                        return "Dato actualizado";
                    }
                    catch
                    {
                        return ("Este valor de ID ya existe en Pais!");
                    }
            }
            else
            {
                return "Datos no detectados, por favor ingresar";
            }
        }


        public static String EliminarPais(String idPais1)
        {
            if (idPais1 != "")
            {
                SqlConnection conx = new SqlConnection();
                conx = RetornaAcceso();
                using (SqlCommand cmd = new SqlCommand("delete Pais where ID_Pais=@IdPais", conx))

                {
                    cmd.Parameters.AddWithValue("@IdPais", idPais1);
                    cmd.Connection = conx;
                    conx.Open();
                    cmd.ExecuteNonQuery();
                    conx.Close();
                    return "Dato eliminado";
                }

            }
            else
            {
                return "Datos no detectados, por favor ingresar";
            }

        }

        public static DataTable cargaComboGeografia()
        {
            using (SqlDataAdapter da = new SqlDataAdapter("SELECT ID_Tipo_Geografia_PK, Descripcion FROM tipo_geografia", RetornaAcceso()))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                RetornaAcceso().Close();
                return dt;
            }
        }

        public static DataSet GetDataGeografia(int tipoGeograf, int IDPais)
        {
            SqlConnection conx = new SqlConnection();
            conx = RetornaAcceso();
            conx.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Geografia where ID_Tipo_Geografia = " + tipoGeograf + " AND ID_Pais = " + IDPais, conx);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conx.Close();
            return ds;
        }

        public static DataSet GetGeografiasHijas(int TipoGeo, int GeoFK)
        {
            SqlConnection Conn = RetornaAcceso();
            Conn.Open();
            SqlCommand GeoSelect = new SqlCommand("SELECT * FROM Geografia " +
                "WHERE ID_Geografia_FK = @GeoFK AND ID_Tipo_Geografia = @TipoGeo", Conn);
            GeoSelect.Parameters.AddWithValue("@GeoFK", GeoFK);
            GeoSelect.Parameters.AddWithValue("@TipoGeo", TipoGeo);
            SqlDataAdapter Adapter = new SqlDataAdapter(GeoSelect);
            DataSet Geos = new DataSet();
            Adapter.Fill(Geos);
            Conn.Close();
            return Geos;
        }



        public static String IngresoGeografia(String idGeo, String DespGeo, int idGeoFK, String idTipo, String idPais)
        {

            if (idGeo != "" && DespGeo != "" && idTipo != "" && idPais != "")
            {
                SqlConnection conx = new SqlConnection();
                conx = RetornaAcceso();
                using (SqlCommand cmd = new SqlCommand("insert into Geografia(ID_Geografia,Descripcion_Geografica,ID_Geografia_FK,ID_Tipo_Geografia,ID_Pais) values(@idGeografia,@Descripcion,case when @idGeoFK = '' then null else @idGeoFK end,@idGeoTipo,@idGeoPais)", conx))
                    try
                    {
                        cmd.Parameters.AddWithValue("@idGeografia", idGeo);
                        cmd.Parameters.AddWithValue("@Descripcion", DespGeo);
                    if(idGeoFK == null)
                    {
                        cmd.Parameters.AddWithValue("@idGeoFK", System.Data.SqlTypes.SqlInt32.Null);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@idGeoFK", idGeoFK);
                    }
                        cmd.Parameters.AddWithValue("@idGeoTipo", idTipo);
                        cmd.Parameters.AddWithValue("@idGeoPais", idPais);
                        cmd.Connection = conx;
                        conx.Open();
                        cmd.ExecuteNonQuery();
                        conx.Close();
                        return "Dato creado";
                    }
                  catch
                   {
                      return ("Error al procesar datos, por favor revisar bandeja de errores!");
                    }

            }
            else
            {
                return "Datos no detectados, por favor ingresar";
            }
        }

        public static String ActualizaGeografia(String idGeo, String DespGeo, String idGeoFK, String idTipo, String idPais)
        {

            if (idGeo != "" && DespGeo != "" && idTipo != "" && idPais != "")
            {
                SqlConnection conx = new SqlConnection();
                conx = RetornaAcceso();
                using (SqlCommand cmd = new SqlCommand("update Geografia set ID_Geografia=@idGeografia,Descripcion_Geografica=@Descripcion,ID_Geografia_FK=case when @idGeoFK = '' then null else @idGeoFK end,ID_Tipo_Geografia=@idGeoTipo,ID_Pais=@idGeoPais where ID_Geografia=@idGeografia OR Descripcion_Geografica=@Descripcion", conx))
               try
                {
                    cmd.Parameters.AddWithValue("@idGeografia", idGeo);
                    cmd.Parameters.AddWithValue("@Descripcion", DespGeo);
                    cmd.Parameters.AddWithValue("@idGeoFK", idGeoFK);
                    cmd.Parameters.AddWithValue("@idGeoTipo", idTipo);
                    cmd.Parameters.AddWithValue("@idGeoPais", idPais);
                    cmd.Connection = conx;
                    conx.Open();
                    cmd.ExecuteNonQuery();
                    conx.Close();
                    return "Dato actualizado";
                }
               catch
                 {
                   return ("Error al procesar datos, por favor revisar bandeja de errores!");
                 }

            }
            else
            {
                return "Datos no detectados, por favor ingresar.";
            }
        }

        public static String EliminarGeografia(String idGeo)
        {
            if (idGeo != "")
            {
                SqlConnection conx = new SqlConnection();
                conx = RetornaAcceso();
                using (SqlCommand cmd = new SqlCommand("delete Geografia where ID_Geografia=@idGeografia", conx))
                {
                    cmd.Parameters.AddWithValue("@idGeografia", idGeo);
                    cmd.Connection = conx;
                    conx.Open();
                    cmd.ExecuteNonQuery();
                    conx.Close();
                    return "Dato eliminado";
                }
            }
            else
            {
                return "Datos no detectados, por favor ingresar";
            }
        }

        public static DataTable cargaComboPerteneceGeografia(int idTipoGeografia, int id_Pais)
        {
            using (SqlDataAdapter da = new SqlDataAdapter("select descripcion_geografica, id_geografia from geografia where id_pais = " +id_Pais+ " and ID_Tipo_Geografia = " +idTipoGeografia, RetornaAcceso()))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                RetornaAcceso().Close();
                return dt;
            }
        }


        //SQL queries [products]

        public static String IngresoProducto(String idProducto1, String Cantidad1, String Precio1, String Marca1, String Descrp1, String idTipoProducto1, String image)
        {
            byte[] rawData = File.ReadAllBytes(image);
            FileInfo info = new FileInfo(image);
            int fileSize = Convert.ToInt32(info.Length);


            if (idProducto1 != "" && Cantidad1 != "" && Precio1 != "" && Marca1 != "" && Descrp1 != "" && idTipoProducto1 != "")
            {
                SqlConnection conx = new SqlConnection();
                conx = RetornaAcceso();
                using (SqlCommand cmd = new SqlCommand("insert into Producto(Id_Producto,Cantidad,Precio,Marca,Descrp,Id_Tipo_TipoProducto, ProductoImagen) values(@idProducto,@CantidadP,@PrecioP,@MarcaP,@DescrpP,@idTipoProducto, @ProductoImagen)", conx))
                    try
                    {
                        cmd.Parameters.AddWithValue("@idProducto", idProducto1);
                        cmd.Parameters.AddWithValue("@CantidadP", Cantidad1);
                        cmd.Parameters.AddWithValue("@PrecioP", Precio1);
                        cmd.Parameters.AddWithValue("@MarcaP", Marca1);
                        cmd.Parameters.AddWithValue("@DescrpP", Descrp1);
                        cmd.Parameters.AddWithValue("@idTipoProducto", idTipoProducto1);
                        cmd.Parameters.Add("@ProductoImagen", SqlDbType.VarBinary, rawData.Length).Value = rawData;
                        cmd.Connection = conx;
                        conx.Open();
                        cmd.ExecuteNonQuery();
                        conx.Close();
                        return "Dato creado";
                    }
                    catch
                    {
                        return ("Este valor de ID ya existe en Producto!");
                    }

            }
            else
            {
                return "Datos no detectados, por favor ingresar";
            }
        }

        public static DataSet GetDataProductos()
        {
            SqlConnection conx = new SqlConnection();
            conx = RetornaAcceso();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Producto", conx);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public static String ModificarProducto(String idProducto1, String Cantidad1, String Precio1, String Marca1, String Descrp1, String idTipoProducto1)
        {

            if (idProducto1 != "" && Descrp1 != "")
            {
                SqlConnection conx = new SqlConnection();
                conx = RetornaAcceso();
                using (SqlCommand cmd = new SqlCommand("update Producto set Cantidad=@CantidadP,Precio=@PrecioP,Marca=@MarcaP,Descrp=@DescrpP,Id_Tipo_TipoProducto=@idTipoProducto where Id_Producto=@idProducto OR Descrp=@DescrpP", conx))
                    try
                    {
                        cmd.Parameters.AddWithValue("@idProducto", idProducto1);
                        cmd.Parameters.AddWithValue("@CantidadP", Cantidad1);
                        cmd.Parameters.AddWithValue("@PrecioP", Precio1);
                        cmd.Parameters.AddWithValue("@MarcaP", Marca1);
                        cmd.Parameters.AddWithValue("@DescrpP", Descrp1);
                        cmd.Parameters.AddWithValue("@idTipoProducto", idTipoProducto1);
                        cmd.Connection = conx;
                        conx.Open();
                        cmd.ExecuteNonQuery();
                        conx.Close();
                        return "Dato actualizado";
                    }
                    catch
                    {
                        return ("Este valor de ID ya existe en Producto!");
                    }

            }
            else
            {
                return "Datos no detectados, por favor ingresar";
            }
        }


       /** public static String EliminarProducto(String idProducto1)
        {
            if (idProducto1 != "")
            {
                SqlConnection conx = new SqlConnection();
                conx = RetornaAcceso();
                using (SqlCommand cmd = new SqlCommand("delete Producto where Id_Producto=@idProducto", conx))
                {
                    cmd.Parameters.AddWithValue("@idProducto", idProducto1);
                    cmd.Connection = conx;
                    conx.Open();
                    cmd.ExecuteNonQuery();
                    conx.Close();
                    return "Dato eliminado";
                }
            }
            else
            {
                return "Datos no detectados, por favor ingresar";
            }
        } **/

        public static SqlDataReader GetDataProductosById(int idProducto)
        {
            SqlConnection conx = new SqlConnection();
            conx = RetornaAcceso();
            conx.Open();
            SqlCommand Query = new SqlCommand("Select PRODUCTOIMAGEN, ID_PRODUCTO, CANTIDAD, PRECIO, MARCA, DESCRP, ID_TIPO_TIPOPRODUCTO from Producto where id_producto = " + idProducto, conx);
            SqlDataReader dr;
            dr = Query.ExecuteReader();
            //conx.Close();
            return dr;
        }

        public static int RegistrarOrden(enumTipoPago Pago, double Precio)
        {
            SqlConnection Conn = RetornaAcceso();
            SqlCommand ConsecSelect = new SqlCommand("SELECT COUNT(1) FROM ORDEN", Conn);
            SqlCommand OrdenInsert = new SqlCommand("INSERT INTO ORDEN(ID_Orden, TipoPago, PrecioTotal, EstadoOrden, Fecha, Id_Cliente_Orden)" +
                " VALUES(@ID, @TipPag, @PrecTotal, @EstOrden, @Fec, @Id_Cliente)", Conn);
            Conn.Open();
            int ConsecOrd = (int) ConsecSelect.ExecuteScalar();
            ConsecOrd++;
            OrdenInsert.Parameters.AddWithValue("@ID", ConsecOrd);
            OrdenInsert.Parameters.AddWithValue("@TipPag", Pago.ToString());
            OrdenInsert.Parameters.AddWithValue("@PrecTotal", Precio);
            OrdenInsert.Parameters.AddWithValue("@EstOrden", enumEstadoOrden.Enviada.ToString());
            OrdenInsert.Parameters.AddWithValue("@Fec", DateTime.Now);
            OrdenInsert.Parameters.AddWithValue("@Id_Cliente", userid);
            OrdenInsert.ExecuteNonQuery();
            Conn.Close();
            return ConsecOrd;
        }

        public static void RegistrarDetalleOrden(int IDOrden, int IDProducto, int Cantidad, double Total)
        {
            SqlConnection Conn = RetornaAcceso();
            SqlCommand OrdenInsert = new SqlCommand("INSERT INTO DetalleOrden(ID_Orden, ID_Producto, Cantidad, Total_Compra)" +
                " VALUES(@IDOrden, @Producto, @Cantidad, @Total)", Conn);
            SqlCommand RestaProducto = new SqlCommand("UPDATE Producto SET Cantidad = Cantidad - @Cantidad WHERE ID_Producto = @Producto", Conn);
            Conn.Open();
            OrdenInsert.Parameters.AddWithValue("@IDOrden", IDOrden);
            OrdenInsert.Parameters.AddWithValue("@Producto", IDProducto);
            OrdenInsert.Parameters.AddWithValue("@Cantidad", Cantidad);
            OrdenInsert.Parameters.AddWithValue("@Total", Total);
            OrdenInsert.ExecuteNonQuery();
            RestaProducto.Parameters.AddWithValue("@Cantidad", Cantidad);
            RestaProducto.Parameters.AddWithValue("@Producto", IDProducto);
            RestaProducto.ExecuteNonQuery();
            Conn.Close();
        }

        public static int GetInventarioProducto(int IDProducto)
        {
            SqlConnection Conx = RetornaAcceso();
            SqlCommand Cmd = new SqlCommand("SELECT Cantidad FROM Producto WHERE Id_Producto = @Producto", Conx);
            int Cantidad;
            Cmd.Parameters.AddWithValue("@Producto", IDProducto);
            Conx.Open();
            Cantidad = (int) Cmd.ExecuteScalar();
            Conx.Close();
            return Cantidad;
        }

        public static DataSet GetDatosOrdenes()
        {
            SqlConnection conx = new SqlConnection();
            conx = RetornaAcceso();
            SqlCommand Cmd = new SqlCommand("SELECT CONCAT(NOMBRE,' ',  PRIMER_APELLIDO) 'Cliente', TIPOPAGO 'Medio de Pago'," +
            " PRECIOTOTAL 'Monto de Compra', FECHA 'Fecha de Compra', " + 
            "CONCAT(GeoDist.Descripcion_Geografica, ', ', GeoCant.Descripcion_Geografica, ', ', GeoProv.Descripcion_Geografica) 'Ubicacion'," +
            " ID_ORDEN, ID_CLIENTE_ORDEN " +
            "FROM ORDEN INNER JOIN PERSONA ON PERSONA.ID_PERSONA = ORDEN.ID_CLIENTE_ORDEN " +
            "INNER JOIN Cliente ON PERSONA.ID_Persona = Cliente.ID_Persona_Cliente " +
            "INNER JOIN Direccion ON Direccion.ID_Direccion = Cliente.ID_Direccion_Cliente " +
            "INNER JOIN Geografia GeoDist ON GeoDist.ID_Geografia = Direccion.ID_Geografia_Direccion " +
            "INNER JOIN Geografia GeoCant ON GeoCant.ID_Geografia = GeoDist.ID_Geografia_FK " +
            "INNER JOIN Geografia GeoProv ON GeoProv.ID_Geografia = GeoCant.ID_Geografia_FK " +
            "WHERE ESTADOORDEN = @Estado", conx);
            SqlDataAdapter Adapter = new SqlDataAdapter(Cmd);
            DataSet Datos = new DataSet();
            Cmd.Parameters.AddWithValue("@Estado", enumEstadoOrden.Enviada.ToString());
            conx.Open();
            Adapter.Fill(Datos);
            conx.Close();
            return Datos;
        }

        public static void RegistrarEnvio(int IDOrden, int IDMensajero, int IDCliente)
        {
            SqlConnection Conn = RetornaAcceso();
            SqlCommand EnvioInsert = new SqlCommand("INSERT INTO Envio(ID_Orden_Envio, ID_PersonaMensajero_Envio, Estado_Envio, ID_Persona_Cliente)" +
                " VALUES(@Orden, @Mensajero, @Estado, @Cliente)", Conn);
            Conn.Open();
            EnvioInsert.Parameters.AddWithValue("@Orden", IDOrden);
            EnvioInsert.Parameters.AddWithValue("@Mensajero", IDMensajero);
            EnvioInsert.Parameters.AddWithValue("@Estado", enumEstadoEnvio.Preparando.ToString());
            EnvioInsert.Parameters.AddWithValue("@Cliente", IDCliente);
            EnvioInsert.ExecuteNonQuery();
            Conn.Close();
        }

        public static void ActualizarEstadoOrden(int IDOrden, enumEstadoOrden Estado)
        {
            SqlConnection Conn = RetornaAcceso();
            SqlCommand OrdenUpdate = new SqlCommand("UPDATE Orden SET EstadoOrden = @Estado" +
                " WHERE ID_Orden = @Orden", Conn);
            Conn.Open();
            OrdenUpdate.Parameters.AddWithValue("@Orden", IDOrden);
            OrdenUpdate.Parameters.AddWithValue("@Estado", Estado.ToString());
            OrdenUpdate.ExecuteNonQuery();
            Conn.Close();
        }

        public static void ActualizarEstadoEnvio(int IDOrden, enumEstadoEnvio Estado)
        {
            SqlConnection Conn = RetornaAcceso();
            SqlCommand EnvioUpdate = new SqlCommand("UPDATE Envio SET Estado_Envio = @Estado" +
                " WHERE ID_Orden_Envio = @Orden", Conn);
            Conn.Open();
            EnvioUpdate.Parameters.AddWithValue("@Orden", IDOrden);
            EnvioUpdate.Parameters.AddWithValue("@Estado", Estado.ToString());
            EnvioUpdate.ExecuteNonQuery();
            Conn.Close();
        }

        public static int GetOrdenMensajero(int IDMensajero)
        {
            SqlConnection Conx = RetornaAcceso();
            SqlCommand Cmd = new SqlCommand("SELECT ID_Orden_Envio FROM Envio" + 
                " WHERE ID_PersonaMensajero_Envio = @Mensajero AND Estado_Envio != @Entregado", Conx);
            int IDOrden;
            Cmd.Parameters.AddWithValue("@Mensajero", IDMensajero);
            Cmd.Parameters.AddWithValue("@Entregado", enumEstadoEnvio.Entregado.ToString());
            Conx.Open();
            var Result = Cmd.ExecuteScalar();
            IDOrden = (Result != null && Result.ToString() != "") ? (int) Result :  -1;
            Conx.Close();
            return IDOrden;
        }

        public static DataSet GetInfoEnvio(int IDOrden)
        {
            SqlConnection conx = new SqlConnection();
            conx = RetornaAcceso();
            SqlCommand Cmd = new SqlCommand("SELECT * FROM Envio" +
            " WHERE ID_Orden_Envio = @Orden", conx);
            SqlDataAdapter Adapter = new SqlDataAdapter(Cmd);
            DataSet Datos = new DataSet();
            Cmd.Parameters.AddWithValue("@Orden", IDOrden);
            conx.Open();
            Adapter.Fill(Datos);
            conx.Close();
            return Datos;
        }

        public static DataSet GetDetalleOrden(int IDOrden)
        {
            SqlConnection conx = new SqlConnection();
            conx = RetornaAcceso();
            SqlCommand Cmd = new SqlCommand("SELECT CONCAT(NOMBRE,' ',  PRIMER_APELLIDO) 'Cliente', TIPOPAGO 'Medio de Pago'," +
            " PRECIOTOTAL 'Monto de Compra', FECHA 'Fecha de Compra', " +
            "CONCAT(GeoDist.Descripcion_Geografica, ', ', GeoCant.Descripcion_Geografica, ', ', GeoProv.Descripcion_Geografica) 'Ubicacion'," +
            " ID_ORDEN, ID_CLIENTE_ORDEN " +
            "FROM ORDEN INNER JOIN PERSONA ON PERSONA.ID_PERSONA = ORDEN.ID_CLIENTE_ORDEN " +
            "INNER JOIN Cliente ON PERSONA.ID_Persona = Cliente.ID_Persona_Cliente " +
            "INNER JOIN Direccion ON Direccion.ID_Direccion = Cliente.ID_Direccion_Cliente " +
            "INNER JOIN Geografia GeoDist ON GeoDist.ID_Geografia = Direccion.ID_Geografia_Direccion " +
            "INNER JOIN Geografia GeoCant ON GeoCant.ID_Geografia = GeoDist.ID_Geografia_FK " +
            "INNER JOIN Geografia GeoProv ON GeoProv.ID_Geografia = GeoCant.ID_Geografia_FK " +
            "WHERE ID_ORDEN = @Orden", conx);
            SqlDataAdapter Adapter = new SqlDataAdapter(Cmd);
            DataSet Datos = new DataSet();
            Cmd.Parameters.AddWithValue("@Orden", IDOrden);
            conx.Open();
            Adapter.Fill(Datos);
            conx.Close();
            return Datos;
        }

        public static DataSet GetInfoOrdenesCliente(int IDCliente)
        {
            SqlConnection conx = new SqlConnection();
            conx = RetornaAcceso();
            SqlCommand Cmd = new SqlCommand("SELECT TIPOPAGO 'Medio de Pago', PRECIOTOTAL 'Monto de Compra', FECHA 'Fecha de Compra', ESTADOORDEN 'Estado'" +
            " FROM ORDEN WHERE ID_CLIENTE_ORDEN = @Cliente", conx);
            SqlDataAdapter Adapter = new SqlDataAdapter(Cmd);
            DataSet Datos = new DataSet();
            Cmd.Parameters.AddWithValue("@Cliente", IDCliente);
            conx.Open();
            Adapter.Fill(Datos);
            conx.Close();
            return Datos;
        }

        public static DataSet GetOrdenesCompletadas(int IDMensajero)
        {
            SqlConnection conx = new SqlConnection();
            conx = RetornaAcceso();
            SqlCommand Cmd = new SqlCommand("SELECT TIPOPAGO 'Medio de Pago', PRECIOTOTAL 'Monto de Compra', FECHA 'Fecha de Compra', " +
            "CONCAT(GeoDist.Descripcion_Geografica, ', ', GeoCant.Descripcion_Geografica, ', ', GeoProv.Descripcion_Geografica) 'Ubicacion' " +
            "FROM ORDEN INNER JOIN ENVIO ON ENVIO.ID_ORDEN_ENVIO = ORDEN.ID_ORDEN " +
            "INNER JOIN PERSONA ON PERSONA.ID_PERSONA = ORDEN.ID_CLIENTE_ORDEN " +
            "INNER JOIN Cliente ON PERSONA.ID_Persona = Cliente.ID_Persona_Cliente " +
            "INNER JOIN Direccion ON Direccion.ID_Direccion = Cliente.ID_Direccion_Cliente " +
            "INNER JOIN Geografia GeoDist ON GeoDist.ID_Geografia = Direccion.ID_Geografia_Direccion " +
            "INNER JOIN Geografia GeoCant ON GeoCant.ID_Geografia = GeoDist.ID_Geografia_FK " +
            "INNER JOIN Geografia GeoProv ON GeoProv.ID_Geografia = GeoCant.ID_Geografia_FK " +
            "WHERE ID_PERSONAMENSAJERO_ENVIO = @Mensajero AND ESTADO_ENVIO = @Entregado", conx);
            SqlDataAdapter Adapter = new SqlDataAdapter(Cmd);
            DataSet Datos = new DataSet();
            Cmd.Parameters.AddWithValue("@Mensajero", IDMensajero);
            Cmd.Parameters.AddWithValue("@Entregado", enumEstadoEnvio.Entregado.ToString());
            conx.Open();
            Adapter.Fill(Datos);
            conx.Close();
            return Datos;
        }

    }
}
