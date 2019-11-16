﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClasesMarcacion
{
    public enum TipoUsuario
    {
        Empleado,
        Administrador
    }
    public class Usuari
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NroDocumento { get; set; }
        public string CodigoHumano { get; set; }
        public Departamento departamento   { get; set; }
        public Cargo cargo  { get; set; }
        public DateTime FechaIngreso  { get; set; }
        public TipoUsuario tipoUsuario { get; set; }

        public static List<Usuari> listarUsuario  = new List<Usuari>();

        public Usuari() { }


        public static void AgregarUsuario(Usuari p)
        {
            
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))

            {
                con.Open(); 
                string textoCmd = "insert into Usuario (Nombre, Apellido, NroDocumento, CodigoHumano, departamento, cargo, FechaIngreso, tipoUsuario) VALUES (@Nombre, @Apellido, @NroDocumneto, @CodigoHumano, @departamento, @cargo, @FechaIngreso, @tipoUsuario)";
                SqlCommand cmd = new SqlCommand(textoCmd, con);

                SqlParameter p1 = new SqlParameter("@Nombre", p.Nombre);
                SqlParameter p2 = new SqlParameter("@Apellido", p.Apellido);
                SqlParameter p3 = new SqlParameter("@NroDocumneto", p.NroDocumento);
                SqlParameter p4 = new SqlParameter("@CodigoHumano", p.CodigoHumano);
                SqlParameter p5 = new SqlParameter("@departamento", p.departamento);
                SqlParameter p6 = new SqlParameter("@cargo", p.cargo);
                SqlParameter p7 = new SqlParameter("@FechaIngreso", p.FechaIngreso);
                SqlParameter p8 = new SqlParameter("@tipoUsuario", p.tipoUsuario);

                
                p1.SqlDbType = SqlDbType.VarChar;
                p2.SqlDbType = SqlDbType.VarChar;
                p3.SqlDbType = SqlDbType.VarChar;
                p4.SqlDbType = SqlDbType.VarChar;
                p5.SqlDbType = SqlDbType.Int;
                p6.SqlDbType = SqlDbType.Int;
                p7.SqlDbType = SqlDbType.DateTime;
                p8.SqlDbType = SqlDbType.Int;
                

                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
                cmd.Parameters.Add(p7);
                cmd.Parameters.Add(p8);

                cmd.ExecuteNonQuery();

            }



        }
        public static void EditarUsuario(int index, Usuari p)
        {
            
            using (SqlConnection con = new SqlConnection(SqlServer.CADENA_CONEXION))
            {
                con.Open();
                string textoCMD = "UPDATE Usuario SET Nombre = @Nombre, Apellido = @Apellido, NroDocumento = @NroDocumneto, CodigoHumano = @CodigoHumano, departamento = @departamento, cargo = @cargo, FechaIngreso = @FechaIngreso, tipoUsuario = @tipoUsuario where Id = @Id";

                SqlCommand cmd = new SqlCommand(textoCMD, con);

                SqlParameter p1 = new SqlParameter("@Nombre", p.Nombre);
                SqlParameter p2 = new SqlParameter("@Apellido", p.Apellido);
                SqlParameter p3 = new SqlParameter("@NroDocumneto", p.NroDocumento);
                SqlParameter p4 = new SqlParameter("@CodigoHumano", p.CodigoHumano);
                SqlParameter p5 = new SqlParameter("@departamento", p.departamento);
                SqlParameter p6 = new SqlParameter("@cargo", p.cargo);
                SqlParameter p7 = new SqlParameter("@FechaIngreso", p.FechaIngreso);
                SqlParameter p8 = new SqlParameter("@tipoUsuario", p.tipoUsuario);
                SqlParameter p9 = new SqlParameter("@Id", p.Id);

                p1.SqlDbType = SqlDbType.VarChar;
                p2.SqlDbType = SqlDbType.VarChar;
                p3.SqlDbType = SqlDbType.VarChar;
                p4.SqlDbType = SqlDbType.VarChar;
                p5.SqlDbType = SqlDbType.Int;
                p6.SqlDbType = SqlDbType.Int;
                p7.SqlDbType = SqlDbType.DateTime;
                p8.SqlDbType = SqlDbType.Int;
                p9.SqlDbType = SqlDbType.Int;



                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
                cmd.Parameters.Add(p7);
                cmd.Parameters.Add(p8);
                cmd.Parameters.Add(p9);

                cmd.ExecuteNonQuery();
            }
        }


        public static void EliminiarUsuario(Usuari user)
        {
            listarUsuario.Remove(user);
        }

        public static List<Usuari> ObtenerUsuario()
        {
            return listarUsuario;
        }

        public override string ToString()
        {
            return this.Nombre + " " + Apellido;
        }
    }
}
