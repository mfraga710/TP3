using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace TP3
{
    internal class DAL
    {
        private string connectionString;
        public DAL()
        {
            //Cargo la cadena de conexión desde el archivo de properties
            connectionString = Properties.Resources.ConnectionString;
        }
        public List<Usuario> inicializarUsuarios()
        {
            List<Usuario> misUsuarios = new List<Usuario>();

            //Defino el string con la consulta que quiero realizar
            string queryString = "SELECT * from dbo.Usuarios";

            // Creo una conexión SQL con un Using, de modo que al finalizar, la conexión se cierra y se liberan recursos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Defino el comando a enviar al motor SQL con la consulta y la conexión
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    //Abro la conexión
                    connection.Open();
                    //mi objecto DataReader va a obtener los resultados de la consulta, notar que a comando se le pide ExecuteReader()
                    SqlDataReader reader = command.ExecuteReader();
                    Usuario aux;
                    //mientras haya registros/filas en mi DataReader, sigo leyendo
                    while (reader.Read())
                    {
                        aux = new Usuario(reader.GetInt32(0), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(1), reader.GetString(5), reader.GetInt32(6), reader.GetBoolean(7), reader.GetBoolean(8));
                        misUsuarios.Add(aux);
                    }
                    //En este punto ya recorrí todas las filas del resultado de la query
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return misUsuarios;
        }
        public int agregarUsuario(int Dni, string Nombre, string Apellido, string Mail, string Password, int IntentosFallidos, bool Bloqueado, bool IsAdm)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            int idNuevoUsuario = -1;
            string connectionString = Properties.Resources.ConnectionString;
            string queryString =
                "INSERT INTO [dbo].[Usuarios] ([Dni],[Nombre],[Apellido],[Mail],[Password],[IntentosFallidos],[Bloqueado],[IsAdmin]) " +
                "VALUES (@dni,@nombre,@apellido,@mail,@password,@intentos, @bloqueado,@IsAdmin );";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@dni", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@apellido", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@mail", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@intentos", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@bloqueado", SqlDbType.Bit));
                command.Parameters.Add(new SqlParameter("@IsAdmin", SqlDbType.Bit));
                command.Parameters["@dni"].Value = Dni;
                command.Parameters["@nombre"].Value = Nombre;
                command.Parameters["@apellido"].Value = Apellido;
                command.Parameters["@mail"].Value = Mail;
                command.Parameters["@password"].Value = Password;
                command.Parameters["@intentos"].Value = IntentosFallidos;
                command.Parameters["@bloqueado"].Value = Bloqueado;
                command.Parameters["@IsAdmin"].Value = IsAdm;

                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    resultadoQuery = command.ExecuteNonQuery();

                    //*******************************************
                    //Ahora hago esta query para obtener el ID
                    string ConsultaID = "SELECT MAX([IdUsuario]) FROM [dbo].[Usuarios]";
                    command = new SqlCommand(ConsultaID, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    idNuevoUsuario = reader.GetInt32(0);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }
                return idNuevoUsuario;
            }
        }
        //devuelve la cantidad de elementos modificados en la base (debería ser 1 si anduvo bien)
        public int eliminarUsuario(int Id)
        {
            string connectionString = Properties.Resources.ConnectionString;
            string queryString = "DELETE FROM [dbo].[Usuarios] WHERE IdUsuario=@Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
                command.Parameters["@Id"].Value = Id;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }
        //devuelve la cantidad de elementos modificados en la base (debería ser 1 si anduvo bien)
        public int modificarUsuario(int IdUsuario, string Nombre, string Apellido, string Mail, int Dni, bool Bloqueado, bool IsAdm)
        {
            string connectionString = Properties.Resources.ConnectionString;
            string queryString = "UPDATE [dbo].[Usuarios] SET Nombre=@nombre, Apellido=@apellido, Mail=@mail, Dni=@dni, Bloqueado=@bloqueado, IsAdmin=@isadm WHERE IdUsuario=@id;";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@apellido", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@mail", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@dni", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@bloqueado", SqlDbType.Bit));
                command.Parameters.Add(new SqlParameter("@isadm", SqlDbType.Bit));
                command.Parameters["@id"].Value = IdUsuario;
                command.Parameters["@dni"].Value = Dni;
                command.Parameters["@nombre"].Value = Nombre;
                command.Parameters["@apellido"].Value = Apellido;
                command.Parameters["@mail"].Value = Mail;
                command.Parameters["@bloqueado"].Value = Bloqueado;
                command.Parameters["@isadm"].Value = IsAdm;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }
        public int bloqUsuario(int IdUsuario, bool Bloqueado)
        {
            string connectionString = Properties.Resources.ConnectionString;
            string queryString = "UPDATE [dbo].[Usuarios] SET Bloqueado=@bloqueado WHERE IdUsuario=@id;";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@bloqueado", SqlDbType.Bit));
                command.Parameters["@id"].Value = IdUsuario;
                command.Parameters["@bloqueado"].Value = Bloqueado;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }
        public List<Post> inicializarPosts()
        {
            List<Post> misPosts = new List<Post>();
            List<Usuario> usuarios = inicializarUsuarios();

            //Defino el string con la consulta que quiero realizar
            string queryString = "SELECT * from dbo.Post";

            // Creo una conexión SQL con un Using, de modo que al finalizar, la conexión se cierra y se liberan recursos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Defino el comando a enviar al motor SQL con la consulta y la conexión
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    //Abro la conexión
                    connection.Open();
                    //mi objecto DataReader va a obtener los resultados de la consulta, notar que a comando se le pide ExecuteReader()
                    SqlDataReader reader = command.ExecuteReader();
                    Post auxPost;
                    Usuario usuarioAux = null;
                    //mientras haya registros/filas en mi DataReader, sigo leyendo
                    while (reader.Read())
                    {
                        foreach (Usuario u in usuarios)
                        {
                            if (u.id == reader.GetInt32(1))
                            {
                                usuarioAux = u;
                            }
                        }
                        auxPost = new Post(reader.GetInt32(0), usuarioAux, reader.GetString(2));
                        misPosts.Add(auxPost);
                    }
                    //En este punto ya recorrí todas las filas del resultado de la query
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return misPosts;
        }
        public int agregarPost(Usuario user, string contenido)
        {
            DateTime fecha = DateTime.Now;
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            int idNuevoPost = -1;
            string connectionString = Properties.Resources.ConnectionString;
            string queryString =
                "INSERT INTO [dbo].[Post] ([IdUsuario],[Contenido],[Fecha]) " +
                "VALUES (@idUser,@contenido,@fecha);";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@idUser", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@contenido", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime));

                command.Parameters["@idUser"].Value = user.id;
                command.Parameters["@contenido"].Value = contenido;
                command.Parameters["@fecha"].Value = fecha;

                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    resultadoQuery = command.ExecuteNonQuery();

                    //*******************************************
                    //Ahora hago esta query para obtener el ID
                    string ConsultaID = "SELECT MAX([IdPost]) FROM [dbo].[Post]";
                    command = new SqlCommand(ConsultaID, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    idNuevoPost = reader.GetInt32(0);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }
                return idNuevoPost;
            }
        }
        public int modificarPost(int idPost, Usuario user, string contenido)
        {
            string connectionString = Properties.Resources.ConnectionString;
            string queryString = "UPDATE [dbo].[Post] SET [IdUsuario]=@usuario, [Contenido]=@contenido WHERE IdPost=@id;";
            int auxUserId = user.id;

            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@usuario", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@contenido", SqlDbType.NVarChar));
                command.Parameters["@id"].Value = idPost;
                command.Parameters["@usuario"].Value = auxUserId;
                command.Parameters["@contenido"].Value = contenido;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }
        public int modificarPostAdm(int postId, string contenido)
        {
            string connectionString = Properties.Resources.ConnectionString;
            string queryString = "UPDATE [dbo].[Post] SET [Contenido]=@contenido WHERE IdPost=@id;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@contenido", SqlDbType.NVarChar));
                command.Parameters["@id"].Value = postId;
                command.Parameters["@contenido"].Value = contenido;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }
        public int modificarCommentAdm(int commentId, string contenido)
        {
            string connectionString = Properties.Resources.ConnectionString;
            string queryString = "UPDATE [dbo].[Comentarios] SET [Contenido]=@contenido WHERE IdComentario=@id;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@contenido", SqlDbType.NVarChar));
                command.Parameters["@id"].Value = commentId;
                command.Parameters["@contenido"].Value = contenido;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }
        public int eliminarPost(int postId)
        {
            string connectionString = Properties.Resources.ConnectionString;
            string queryString = "DELETE FROM [dbo].[Post] WHERE [IdPost]=@Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
                command.Parameters["@Id"].Value = postId;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }
        public List<Comentario> inicializarComentarios()
        {


            List<Comentario> misComentarios = new List<Comentario>();
            List<Usuario> usuarios = inicializarUsuarios();
            List<Post> posts = inicializarPosts();


            //Defino el string con la consulta que quiero realizar
            string queryString = "SELECT * from dbo.Comentarios";

            // Creo una conexión SQL con un Using, de modo que al finalizar, la conexión se cierra y se liberan recursos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Defino el comando a enviar al motor SQL con la consulta y la conexión
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    //Abro la conexión
                    connection.Open();
                    //mi objecto DataReader va a obtener los resultados de la consulta, notar que a comando se le pide ExecuteReader()
                    SqlDataReader reader = command.ExecuteReader();
                    Comentario auxComentario;
                    Usuario usuarioAux = null;
                    Post postAux = null;
                    //mientras haya registros/filas en mi DataReader, sigo leyendo
                    while (reader.Read())
                    {
                        foreach (Usuario u in usuarios)
                        {
                            foreach (Post p in posts)
                            {
                                if (u.id == reader.GetInt32(1) && p.id == reader.GetInt32(3))
                                {
                                    usuarioAux = u;
                                    postAux = p;
                                }
                            }
                        }
                        auxComentario = new Comentario(reader.GetInt32(0), postAux, usuarioAux, reader.GetString(2));
                        misComentarios.Add(auxComentario);
                    }
                    //En este punto ya recorrí todas las filas del resultado de la query
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return misComentarios;
        }
        public int agregarComentario(Post post, Usuario usuario, string contenido)
        {
            DateTime fecha = DateTime.Now;
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            int idNuevoComentario = -1;
            string connectionString = Properties.Resources.ConnectionString;
            string queryString =
                "INSERT INTO [dbo].[Comentarios] ([IdUsuario],[Contenido],[IdPost],[Fecha]) " +
                "VALUES (@idUser,@contenido,@IdPost,@fecha);";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@idUser", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@contenido", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@idPost", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime));

                command.Parameters["@idUser"].Value = usuario.id;
                command.Parameters["@contenido"].Value = contenido;
                command.Parameters["@idPost"].Value = post.id;
                command.Parameters["@fecha"].Value = fecha;


                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    resultadoQuery = command.ExecuteNonQuery();

                    //*******************************************
                    //Ahora hago esta query para obtener el ID
                    string ConsultaID = "SELECT MAX([IdComentario]) FROM [dbo].[Comentarios]";
                    command = new SqlCommand(ConsultaID, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    idNuevoComentario = reader.GetInt32(0);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }
                return idNuevoComentario;
            }
        }
        public int modificarComent(Comentario c)
        {
            string connectionString = Properties.Resources.ConnectionString;
            string queryString = "UPDATE [dbo].[Comentarios] SET [Contenido]=@contenido WHERE IdComentario=@id;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@contenido", SqlDbType.NVarChar));
                command.Parameters["@id"].Value = c.id;
                command.Parameters["@contenido"].Value = c.contenido;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }
        public int eliminarComent (int comentarioId)
        {
            string connectionString = Properties.Resources.ConnectionString;
            string queryString = "DELETE FROM [dbo].[Comentarios] WHERE [IdComentario]=@Id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int));
                command.Parameters["@Id"].Value = comentarioId;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }
        public List<Reaccion> inicializarReaccion()
        {
            List<Reaccion> misReacciones = new List<Reaccion>();
            List<Usuario> usuarios = inicializarUsuarios();
            List<Post> posts = inicializarPosts();

            //Defino el string con la consulta que quiero realizar
            string queryString = "SELECT * from dbo.Reacciones";

            // Creo una conexión SQL con un Using, de modo que al finalizar, la conexión se cierra y se liberan recursos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Defino el comando a enviar al motor SQL con la consulta y la conexión
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    //Abro la conexión
                    connection.Open();
                    //mi objecto DataReader va a obtener los resultados de la consulta, notar que a comando se le pide ExecuteReader()
                    SqlDataReader reader = command.ExecuteReader();
                    Reaccion auxReaccion;
                    Usuario usuarioAux = null;
                    Post postAux = null;
                    //mientras haya registros/filas en mi DataReader, sigo leyendo
                    while (reader.Read())
                    {
                        foreach (Usuario u in usuarios)
                        {
                            foreach (Post p in posts)
                            {
                                if (u.id == reader.GetInt32(2) && p.id == reader.GetInt32(3))
                                {
                                    usuarioAux = u;
                                    postAux = p;
                                }
                            }
                        }
                        auxReaccion = new Reaccion(reader.GetInt32(0),reader.GetString(1), postAux, usuarioAux);
                        misReacciones.Add(auxReaccion);
                    }
                    //En este punto ya recorrí todas las filas del resultado de la query
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return misReacciones;
        }
        public int agregarReaccion(string tipoReaccion, int postId, int userId)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            int idNuevaReaccion = -1;

            string connectionString = Properties.Resources.ConnectionString;
            string queryString =
                "INSERT INTO [dbo].[Reacciones] ([Tipo],[IdUsuario],[IdPost]) " +
                "VALUES (@tipo,@idUsuario,@idPost);";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@tipo", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@idUsuario", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@idPost", SqlDbType.Int));

                command.Parameters["@tipo"].Value = tipoReaccion;
                command.Parameters["@idUsuario"].Value = postId;
                command.Parameters["@idPost"].Value = userId;

                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    resultadoQuery = command.ExecuteNonQuery();

                    //*******************************************
                    //Ahora hago esta query para obtener el ID
                    string ConsultaID = "SELECT MAX([IdReaccion]) FROM [dbo].[Reacciones]";
                    command = new SqlCommand(ConsultaID, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    idNuevaReaccion = reader.GetInt32(0);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }
                return idNuevaReaccion;
            }
        }
        public int modificarReaccion(int idReaccion, string tipo )
        {
            string connectionString = Properties.Resources.ConnectionString;
            string queryString = "UPDATE [dbo].[Reacciones] SET [Tipo]=@tipo WHERE [IdReaccion]=@id;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@tipo", SqlDbType.NVarChar));
                command.Parameters["@id"].Value = idReaccion;
                command.Parameters["@tipo"].Value = tipo;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }
        public int eliminarReaccion(int postId, int userId)
        {
            string connectionString = Properties.Resources.ConnectionString;
            string queryString = "DELETE FROM [dbo].[Reacciones] WHERE [IdPost]=@IdP AND [IdUsuario] = @IdU";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@IdP", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@IdU", SqlDbType.Int));
                command.Parameters["@IdP"].Value = postId;
                command.Parameters["@IdU"].Value = userId;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }
        public List<Tag> inicializarTags()
        {
            List<Tag> misTags = new List<Tag>();
            List<Usuario> usuarios = inicializarUsuarios();
            List<Post> posts = inicializarPosts();


            //Defino el string con la consulta que quiero realizar
            string queryString = "SELECT * from dbo.Tags";

            // Creo una conexión SQL con un Using, de modo que al finalizar, la conexión se cierra y se liberan recursos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Defino el comando a enviar al motor SQL con la consulta y la conexión
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    //Abro la conexión
                    connection.Open();
                    //mi objecto DataReader va a obtener los resultados de la consulta, notar que a comando se le pide ExecuteReader()
                    SqlDataReader reader = command.ExecuteReader();
                    Tag auxTag;
                    
                    //mientras haya registros/filas en mi DataReader, sigo leyendo
                    while (reader.Read())
                    {
                        List<Post> postAux = new List<Post>();
                        foreach (Post p in posts)
                        {
                            if (p.id == reader.GetInt32(2))
                            {
                                postAux.Add(p);
                            }
                        }                        
                        auxTag = new Tag(reader.GetInt32(0), reader.GetString(1), postAux);
                        misTags.Add(auxTag);
                    }
                    //En este punto ya recorrí todas las filas del resultado de la query
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return misTags;
        }
        public int relTag(int idTag, int idPost)
        {
            DateTime fecha = DateTime.Now;
            //primero me aseguro que lo pueda agregar a la base

            string connectionString = Properties.Resources.ConnectionString;
            string queryString =
                "INSERT INTO [dbo].[Post_Tag] ([IdTag],[IdPost]) " +
                "VALUES (@idTag,@idPost);";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@idTag", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@idPost", SqlDbType.Int));
                command.Parameters["@idTag"].Value = idTag;
                command.Parameters["@idPost"].Value = idPost;

                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }
        public int agregarTag(string palabra,int idPost)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            int idNuevoTag=-1;
            string connectionString = Properties.Resources.ConnectionString;
            string queryString =
                "INSERT INTO [dbo].[Tags] ([Palabra],[IdPost]) " +
                "VALUES (@palabra,@idPost);";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@palabra", SqlDbType.VarChar));
                command.Parameters.Add(new SqlParameter("@idPost", SqlDbType.Int));

                command.Parameters["@palabra"].Value = palabra;
                command.Parameters["@idPost"].Value = idPost;
                

                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    resultadoQuery = command.ExecuteNonQuery();

                    //*******************************************
                    //Ahora hago esta query para obtener el ID
                    string ConsultaID = "SELECT MAX([IdTag]) FROM [dbo].[Tags]";
                    command = new SqlCommand(ConsultaID, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    idNuevoTag = reader.GetInt32(0);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }
                return idNuevoTag;
            }
        }
        public int eliminarTagRel(int tagId)
        {
            string connectionString = Properties.Resources.ConnectionString;
            string queryString = "DELETE FROM [dbo].[Post_Tag] WHERE [IdTag]=@Idt";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@Idt", SqlDbType.Int));
                command.Parameters["@Idt"].Value = tagId;

                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }
        public int eliminarTag(int tagId)
        {
            string connectionString = Properties.Resources.ConnectionString;
            string queryString = "DELETE FROM [dbo].[Tags] WHERE [IdTag]=@Idt";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@Idt", SqlDbType.Int));
                command.Parameters["@Idt"].Value = tagId;

                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }
        public List<AmigosRel> inicializarAmigos()
        {
            List<AmigosRel> idAmigosUsers = new List<AmigosRel>();

            //Defino el string con la consulta que quiero realizar
            string queryString = "SELECT * from dbo.Usuario_Amigo";

            // Creo una conexión SQL con un Using, de modo que al finalizar, la conexión se cierra y se liberan recursos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Defino el comando a enviar al motor SQL con la consulta y la conexión
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    //Abro la conexión
                    connection.Open();
                    //mi objecto DataReader va a obtener los resultados de la consulta, notar que a comando se le pide ExecuteReader()
                    SqlDataReader reader = command.ExecuteReader();
                    AmigosRel aux;
                    //mientras haya registros/filas en mi DataReader, sigo leyendo
                    while (reader.Read())
                    {
                        aux = new AmigosRel(reader.GetInt32(0), reader.GetInt32(1));
                        idAmigosUsers.Add(aux);
                    }
                    //En este punto ya recorrí todas las filas del resultado de la query
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return idAmigosUsers;
        }
        public int agregarAmigo(int amigoId,int userId)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            int idNuevoAmigo;
            string connectionString = Properties.Resources.ConnectionString;
            string queryString =
                "INSERT INTO [dbo].[Usuario_Amigo] ([idAmigo],[idUsuario]) " +
                "VALUES (@idA,@idU);";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@idA", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@idU", SqlDbType.Int));
                command.Parameters["@idA"].Value = amigoId;
                command.Parameters["@idU"].Value = userId;

                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    resultadoQuery = command.ExecuteNonQuery();

                    //*******************************************
                    //Ahora hago esta query para obtener el ID
                    string ConsultaID = "SELECT MAX([IdAmigo]) FROM [dbo].[Usuario_Amigo]";
                    command = new SqlCommand(ConsultaID, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    idNuevoAmigo = reader.GetInt32(0);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }
                return idNuevoAmigo;
            }
        }

        public int eliminarAmigo(int idAmigo, int idUser)
        {
            string connectionString = Properties.Resources.ConnectionString;
            string queryString = "DELETE FROM [dbo].[Usuario_Amigo] WHERE [IdAmigo]=@IdA AND [IdUsuario]=@idB";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@IdA", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@IdB", SqlDbType.Int));
                command.Parameters["@IdA"].Value = idAmigo;
                command.Parameters["@IdB"].Value = idUser;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query                    
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }
    }
}

